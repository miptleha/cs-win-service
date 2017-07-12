# Windows service on .NET

Starting project for windows service with some C# code and installation script

Project contains:

- config file
- log4net support
- core logic for service execution (Service1.cs)

## Compilation, installation, uninstallation:

- Open sln or csproj file in Visual Studio
- Build project
- Open in Explorer bin/Debug folder and run _install.bat
- Open Services in Windows and find WinService
- If it not started, start it, then stop in couple of seconds
- See log in bin/Debug/log
- In bin/Debug folder run _unintall.bat

## Renaming and coding

To change name of service edit ProjectInstaller.Designer.cs file.
For full renaming change in each file 'WinService' for your own name.
This service is just a starting project for coding.
Implement custom logic Process/ServiceProcess.cs file.
Add own classes to work with database, xml, queue server and so on. There only logging support. 

