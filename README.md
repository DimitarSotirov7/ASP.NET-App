# ASP.NET-App
Final Web-App project

- If you want to run the app you should download MS SQL Server.
Automaticully, there will be created database according to latest migration.
- If you need sending emails function you should create appsettings.Development.json file in path: ~\ASP.NET-App\src\Web\Application.Web.
After that put "SendGrid" section with 3 properies:
	- ApiKey - can get it from https://sendgrid.com/
	- FromEmail - put email sender and register it in the site above.
	- ToEmail - put email receiver
- if you need admin account seeder add section Admin in appsettings.Development.json file with 3 properies:
	- Username
	- Email
	- Password
You can also change the other data for this account in ~\ASP.NET-App\src\Data\Application.Data\Seeding\AdminAccountSeeder.cs.