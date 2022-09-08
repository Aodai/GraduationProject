# GraduationProject  

## Requirements
Eventify requires the following to run:  
* .NET 6.0
* Visual Studio 2022
* Microsoft SQL Server

## Setup instructions
To run this project you need to set the connection string in `appsettings.json` in `GraduationProject` project directory and run this command to apply the migrations to the database:
```
dotnet tool install --global dotnet-ef  
dotnet ef database update
```
Then you can run the project using Visual Studio.