using HRApplicantSystem.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace HRApplicantSystem.Forms.Applicant
{
    public partial class frmJobVacancies : Form
    {
        private string userEmail;

        public frmJobVacancies(string email)
        {
            InitializeComponent();
            userEmail = email;
            UITheme.Apply(this);
        }

        private void frmJobVacancies_Load(object sender, EventArgs e)
        {
            SetupListView();
            LoadDepartments();
            LoadJobList();
        }

        private void SetupListView()
        {
            listViewJobs.View = System.Windows.Forms.View.Details;
            listViewJobs.FullRowSelect = true;
            listViewJobs.GridLines = true;
            listViewJobs.Columns.Clear();
            listViewJobs.Columns.Add("Vacancy ID", 80);
            listViewJobs.Columns.Add("Position", 180);
            listViewJobs.Columns.Add("Department", 160);
            listViewJobs.Columns.Add("Type", 110);
            listViewJobs.Columns.Add("Slots", 60);
            listViewJobs.Columns.Add("Description", 580);
            listViewJobs.Columns.Add("Qualifications", 580);
        }

        private void LoadJobList(string searchText = "", string department = "")
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query =
                        @"SELECT
                            v.vacancy_id,
                            p.title,
                            d.name        AS department,
                            et.label      AS employment_type,
                            v.slots,
                            v.description,
                            v.qualifications
                          FROM job_vacancies v
                          INNER JOIN positions        p   ON v.position_id        = p.position_id
                          INNER JOIN departments      d   ON v.department_id      = d.department_id
                          INNER JOIN employment_types et  ON v.employment_type_id = et.type_id
                          WHERE v.status = 'open'";

                    if (!string.IsNullOrEmpty(searchText))
                        query += " AND (p.title LIKE @Search OR d.name LIKE @Search)";

                    if (!string.IsNullOrEmpty(department) && department != "All Departments")
                        query += " AND d.name = @Department";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(searchText))
                            cmd.Parameters.AddWithValue("@Search", "%" + searchText + "%");

                        if (!string.IsNullOrEmpty(department) && department != "All Departments")
                            cmd.Parameters.AddWithValue("@Department", department);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            listViewJobs.Items.Clear();
                            while (dr.Read())
                            {
                                ListViewItem item = new ListViewItem(dr["vacancy_id"].ToString());
                                item.SubItems.Add(dr["title"].ToString());
                                item.SubItems.Add(dr["department"].ToString());
                                item.SubItems.Add(dr["employment_type"].ToString());
                                item.SubItems.Add(dr["slots"].ToString());

                                string desc = dr["description"] == DBNull.Value
                                    ? "" : dr["description"].ToString();
                                string quals = dr["qualifications"] == DBNull.Value
                                    ? "" : dr["qualifications"].ToString();

                                item.SubItems.Add(SingleLine(desc));
                                item.SubItems.Add(SingleLine(quals));
                                item.Tag = new string[] { desc, quals };

                                listViewJobs.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading jobs: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string SingleLine(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            string flat = text.Replace("\r\n", " ")
                               .Replace("\n", " ")
                               .Replace("\r", " ")
                               .Trim();
            return flat.Length > 180 ? flat.Substring(0, 180) + "…" : flat;
        }

        private void LoadDepartments()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    cboDepartment.Items.Clear();
                    cboDepartment.Items.Add("All Departments");

                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT name FROM departments ORDER BY name", conn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                                cboDepartment.Items.Add(dr["name"].ToString());
                        }
                    }

                    cboDepartment.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading departments: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadJobList(txtSearch.Text, cboDepartment.Text);
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadJobList(txtSearch.Text, cboDepartment.Text);
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (listViewJobs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a job first.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem sel = listViewJobs.SelectedItems[0];
            string description = "";
            string qualifications = "";
            if (sel.Tag is string[] full)
            {
                description = full[0];
                qualifications = full[1];
            }

            string details =
                $"Position        : {sel.SubItems[1].Text}\n" +
                $"Department      : {sel.SubItems[2].Text}\n" +
                $"Employment Type : {sel.SubItems[3].Text}\n" +
                $"Slots           : {sel.SubItems[4].Text}\n\n" +
                $"Description:\n{description}\n\n" +
                $"Qualifications:\n{qualifications}";

            MessageBox.Show(details, "Job Details",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool IsProfileComplete(
            SqlConnection conn, string email, out string missingFields)
        {
            missingFields = "";

            using (SqlCommand cmd = new SqlCommand(
                @"SELECT full_name, birthdate, address, city, province,
                         zip_code, phone, gender, school, degree,
                         year_grad, skills, company, position, duration
                  FROM applicants WHERE email = @Email", conn))
            {
                cmd.Parameters.AddWithValue("@Email", email);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (!dr.Read())
                    {
                        missingFields = "Profile not found.";
                        return false;
                    }

                    var missing = new List<string>();

                    void Check(string col, string label)
                    {
                        if (dr[col] == DBNull.Value ||
                            string.IsNullOrWhiteSpace(dr[col].ToString()))
                            missing.Add(label);
                    }

                    Check("full_name", "Full Name");
                    if (dr["birthdate"] == DBNull.Value) missing.Add("Birthdate");
                    Check("address", "Address");
                    Check("city", "City");
                    Check("province", "Province");
                    Check("zip_code", "Zip Code");
                    Check("phone", "Phone");
                    Check("gender", "Gender");
                    Check("school", "School");
                    Check("degree", "Degree");
                    Check("year_grad", "Year Graduated");
                    Check("skills", "Skills");
                    Check("company", "Company");
                    Check("position", "Work Position");
                    Check("duration", "Work Duration");

                    if (missing.Count > 0)
                    {
                        missingFields = string.Join(", ", missing);
                        return false;
                    }
                    return true;
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (listViewJobs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a job to apply for.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string vacancyIdStr = listViewJobs.SelectedItems[0].Text.Trim();
            string jobTitle = listViewJobs.SelectedItems[0].SubItems[1].Text;

            if (MessageBox.Show(
                    $"Save a draft application for:\n  {jobTitle}\n\n" +
                    "You can review and submit it from the My Application page.",
                    "Confirm Apply",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // 1. Get applicant_id
                    int applicantId;
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT applicant_id FROM applicants WHERE email = @Email", conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", userEmail);
                        object result = cmd.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("Applicant account not found.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        applicantId = Convert.ToInt32(result);
                    }

                    // 2. Profile must be complete before applying.
                    if (!IsProfileComplete(conn, userEmail, out string missing))
                    {
                        DialogResult go = MessageBox.Show(
                            $"Please complete your profile before applying.\n\n" +
                            $"Missing: {missing}\n\nGo to My Profile now?",
                            "Profile Incomplete",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (go == DialogResult.Yes)
                        {
                            using (var frm = new frmMyProfile(userEmail))
                                frm.ShowDialog();
                        }
                        return;
                    }

                    // 3. Parse vacancy ID
                    if (!int.TryParse(vacancyIdStr, out int vacancyId) || vacancyId <= 0)
                    {
                        MessageBox.Show("Invalid job vacancy selected.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 4. Duplicate check
                    using (SqlCommand cmd = new SqlCommand(
                        @"SELECT status FROM applications
                          WHERE applicant_id = @ApplicantId
                            AND vacancy_id   = @VacancyId", conn))
                    {
                        cmd.Parameters.AddWithValue("@ApplicantId", applicantId);
                        cmd.Parameters.AddWithValue("@VacancyId", vacancyId);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string existingStatus = dr["status"].ToString();
                                MessageBox.Show(
                                    "You have already applied for this position.\n\n" +
                                    $"Current status: {existingStatus}\n\n" +
                                    "Check My Application to manage it.",
                                    "Already Applied",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }

                    // 5. Confirm vacancy is still open.
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT 1 FROM job_vacancies " +
                        "WHERE vacancy_id = @VacancyId AND status = 'open'", conn))
                    {
                        cmd.Parameters.AddWithValue("@VacancyId", vacancyId);
                        if (cmd.ExecuteScalar() == null)
                        {
                            MessageBox.Show("This vacancy is no longer open.",
                                "Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // 6. INSERT as DRAFT
                    int newAppId;
                    using (SqlCommand cmd = new SqlCommand(
                        @"INSERT INTO applications
                            (applicant_id, vacancy_id, status, last_updated)
                          OUTPUT INSERTED.application_id
                          VALUES (@ApplicantId, @VacancyId, 'draft', GETDATE())", conn))
                    {
                        cmd.Parameters.AddWithValue("@ApplicantId", applicantId);
                        cmd.Parameters.AddWithValue("@VacancyId", vacancyId);
                        newAppId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // 7. Seed applicant_documents from this vacancy's job_requirements.
                    using (SqlCommand cmd = new SqlCommand(
                        @"INSERT INTO applicant_documents (applicant_id, req_type_id, status)
                          SELECT @ApplicantId, req_type_id, 'missing'
                          FROM   job_requirements
                          WHERE  job_id = @VacancyId
                            AND  NOT EXISTS (
                                SELECT 1 FROM applicant_documents
                                WHERE  applicant_id = @ApplicantId
                                  AND  req_type_id  = job_requirements.req_type_id
                            )", conn))
                    {
                        cmd.Parameters.AddWithValue("@ApplicantId", applicantId);
                        cmd.Parameters.AddWithValue("@VacancyId", vacancyId);
                        cmd.ExecuteNonQuery();
                    }

                    // 8. Log the draft creation in status_history.
                    StatusHistoryLogger.LogStatusChange(
                        newAppId,
                        previousStatus: null,
                        newStatus: "draft",
                        changedByUserId: applicantId,
                        remarks: "Applicant created draft application from Job Vacancies.");

                    MessageBox.Show(
                        "Draft application saved!\n\n" +
                        "Go to My Application to review and submit it.",
                        "Draft Saved",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadJobList(txtSearch.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error applying for job: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is frmApplicantDashboard)
                {
                    f.Show();
                    f.BringToFront();
                    break;
                }
            }
            this.Close();
        }

        private void listViewJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}