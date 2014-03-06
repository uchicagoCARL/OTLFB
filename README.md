OTLFB
=====

About:
======
The TIMELINE FOLLOWBACK (TLFB) is an interview-based assessment that was developed and copyrighted by Sobell & Sobell (2000). The TLFB derives subjects' retrospective daily estimates of alcohol consumption patterns. Using a calendar as a visual aid, special events, and other memory cues, subjects are guided through the process of recalling and reporting daily drinking estimates.

Requirements for Installation:
============
1. Windows Web Server (IIS) with .NET Framework version 3.5 installed
2. Microsoft SQL (MSSQL) Server (2005 or later)
3. Any text editor (e.g. Microsoft Notepad, Notepad++, etc.)

Installation:
============

1. Download all files from the GitHub repository to a local directory (e.g. c:\OTLFB)
2. Edit database creation script, changing the default password
	a. Open "CalendarSurveyDB.sql" in your text editor
	b. Edit line 6 (CREATE LOGIN cs_dbo WITH PASSWORD='cs_dbo123321qweewq';) changing the string value enclosed in single-quotes (cs_dbo123321qweewq) to a password of your choice
	c. Save "CalendarSurveyDB.sql"
3. Create database
	a. Connect to SQL Server using an account with at least dbcreator and securityadmin roles assigned to it
	b. Execute the saved script "CalendarSurveyDB.sql"
	c. The database should now be ready
4. Prepare web server source code
	a. Open the "web.config" file downloaded from GitHub
	b. Edit line 17 (<add key="ConnectionString" value="server=SqlServerIpAddress;uid='cs_dbo';password='SqlUserPassword';initial catalog='calendarsurvey' "/>), replacing:
		i. "SqlServerIpAddress" with the IP address of your SQL Server
		ii. "SqlUserPassword" with the password you used in step 2b above.
	c. Save "web.config"
	d. The source code should now be ready
5. Configure web server
	a. Copy the modified local directory (e.g. c:\OTLFB) and all its contents to your web server. Note: The web root directory is typically located in c:\inetpub\www\, so a possible location would be c:\inetpub\www\OTLFB\
	b. Within IIS, configure a new website with its document root being the location from step 5a above, and assigning it to an application pool running .NET 3.5
		i. For more information on creating websites within IIS, consult the following: http://technet.microsoft.com/en-us/library/cc772350(v=ws.10).aspx
6. The Online TLFB (O-TLFB) is now set up and operational.  
	a. Login with the following default credentials (be sure to change them after logging in)
		i. Username: csadmin
		ii. Password: csadmin123
	b. Please refer to the attached file for further instructions on how to create additional users.


	
TO ADD NEW USERS AND ADMINISTRATORS
=================================== 
1. Login using Administrator login credentials (e.g. those defined during installation)
2. Click on the 'Admin Page' link in the top, left-hand corner
3. Click on 'Users and Privileges' in the left array  
4. Enter in a 'Login ID' and 'Password' and reenter the password for verification
5. Choose the role you would like to assign to the login information from the drop down menu (either 'Administrator' or 'User')
6. Press 'Submit'

TO EXPORT RESPONSES AND CURRENT USERS
=====================================
1. Login using Administrator login credentials (e.g. those defined during installation)
2. Click on the 'Admin Page' link in the top, left-hand corner
3. Click on 'Data Management' in the left array  
4. Click on the appropriate links to either export responses or a listing of current users to MS Excel