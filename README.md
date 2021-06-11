# CIEDemo
Demo app created for CIE code challenge

# How to test
Everything is contained under the `CIEDemo.sln` solution file.

The SQL Server backup file icluded in the `DatabaseBackup` folder is needed to run the application. Restore that to your running SQL Server instance, changing the connection string in `appsettings.json` as appropriate.

Building the app *SHOULD* install the NuGet packages as well, but if not, running a NuGet package restore should resolve the issue.

You will need to run `npm install` from a command line in the `ClientApp` folder, so that all the npm packages used are installed properly.

Start it up in debug mode in Visual Studio and test away!!

Sample login is as follows:

username: `johndoe`

pass: `cie2021`

**NOTE**: The user profile page is a template only, no functionality is added. 
