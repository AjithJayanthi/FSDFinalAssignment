..\..\..\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe -target:..\..\..\ProjectManager.Test\bin\Debug\test.bat -register:user -filter:"+[ProjectManager.BusinessLayer]* +[ProjectManager.Service]* -[*]*.*Config -[ProjectManager.Service]WebApiConfig.cs -[ProjectManager.Service]Global.asax"

..\..\..\packages\ReportGenerator.3.1.2\tools\ReportGenerator.exe -reports:results.xml -targetdir:coverage  
pause