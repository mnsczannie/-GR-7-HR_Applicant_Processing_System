**Journal/My Short AI Usage in this Project**


(**Disclaimer:** Along with all the problems stated below, I was able to resolve and learned from it through the use, guide, and help of AI.)


**Day 1: Figuring Out What I Was Actually Supposed to Do**


Honestly the first day was mostly just me reading our spec doc over and over trying to make sure I understood my part correctly. I thought my task only covered the screening, interview scheduling, interview evaluation, and hiring decision forms. I figured the login form was already handled since it was already sitting in the repo from the start. Turns out I was wrong — when I went back and checked the actual task breakdown again, frmHRLogin was actually part of my assignment too, and there was this random file called HRApplicantForms.cs that literally nobody in the group had claimed. So that was already a bit of a scramble, having to go back and build stuff I thought wasn't mine in the first place.


**Day 2: The Designer File Nightmare**


This was probably the most annoying day out of all of them. I had all my code ready to go, but I kept messing up how I added the files in Visual Studio. I wasn't sure if I was supposed to add them as a "Class" or as an actual "Windows Form," and picking the wrong one kept generating this empty Designer file that didn't match what I was trying to paste in. Our group leader told us to always use Windows Form and to never manually create the Designer file ourselves, which honestly saved me a lot of headache once I actually listened to that. But even after doing it the right way, I realized a bunch of my files were still just the default blank template — like it still had nothing but InitializeComponent() in there. I had actually already committed and pushed some of these empty files without noticing because Visual Studio opens the design view first, not the code, so I had no idea it was empty until I pressed F7 or the option to right click and view the code to check. Once I started actually pasting the real code in, I got hit with a wall of errors saying things like a textbox or dropdown "doesn't exist in the current context." Took me a while to realize that just fixing the .cs file isn't enough — you have to fix the Designer file too, since that's actually where all those controls get declared. Annoying lesson, but I get it now.


**Day 3: Trying to Connect to the Database and Just Getting Timeouts**


This day was mostly just me fumbling around in SQL Server Management Studio trying to connect to our Azure database for the first time. I've literally never connected to anything on Azure before so I had no clue what half the settings meant — Encrypt, Trust Server Certificate, none of it made sense to me at first. I tried connecting and just got hit with a Connection Timeout error, which freaked me out a bit because I thought maybe the server was down or my account got blocked or something. Took some trial and error to figure out it was just a setting issue — once I switched Encrypt to Mandatory it actually worked. Then when I tried running my CREATE TABLE scripts I got errors saying the tables already existed, which low-key worried me until I checked and realized someone else in the group had already made them. Kind of a relief honestly, but also made me realize I should've checked first before assuming I needed to run anything.


**Day 4: Realizing How I Commit Actually Matters**


This day wasn't really about coding, it was more about cleaning up how I was doing my commits. I had just been doing one big commit with everything dumped in at once, but then I remembered our requirements literally say the instructor can reject stuff that looks like it was all generated in one bulk commit. So I had to redo my whole approach and start committing form by form instead, with messages that actually made sense and looked like normal progress instead of one giant dump. Also had to deal with the fact that some of my earlier commits on GitHub were the broken empty versions from Day 2's mess, so I had to go back, actually do the correct code everywhere, rebuild to make sure nothing new broke, and commit again properly. There were still some errors left over but those were because of stuff that wasn't done on my teammates' end yet, not because of anything I did wrong, so I just pushed my part anyway since it wasn't stopping my own code from showing up correctly.


**Day 5: Going Back to Check Everything Against the Actual Capstone Requirements**


Last day I basically sat down with our official requirements PDF and went through it line by line against everything I had already built. Turns out the status names I was using in my code didn't actually match what the requirements wanted — I had stuff like "screened" and "interviewed" when it should've been "shortlisted" and "for_interview" and so on. Had to go through like five different files just to fix all the status values so everything lined up properly.
Also noticed my hiring decision form only let HR pick Accepted or Rejected, but the requirements clearly mention there should be an On Hold option too, so I added that in. While I was double checking everything against the defense checklist I found a few more small things missing too — no way to mark something as Withdrawn, no validation stopping someone from scheduling an interview in the past even though that's literally one of the required test cases, no refresh button on the dashboard, and reports could only export to CSV with no print option. Fixed all of those one at a time so my commits still looked normal and not like I dumped everything at once.


**Looking Back**


Honestly most of the actual coding wasn't that bad once I understood how the database was structured. What actually got me stuck most of the time wasn't the C# logic itself, it was all the process stuff — getting the Designer files to match up correctly, figuring out Azure settings I'd never touched and do before, realizing commit history actually counts toward our grade, and just generally going back to double check my assumptions against what was actually written in the requirements instead of what I thought I remembered. That's probably the biggest thing I'm taking away from this — it's not just about getting the code to run, it's about actually doing the process right too.
