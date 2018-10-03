..\..\..\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe -target:..\..\..\ProjectManager.Test\bin\Debug\runTests.bat -register:user -filter:"+[ProjectManager.BusinessLayer],+[ProjectManager.Service]*"

..\..\..\packages\ReportGenerator.3.1.2\tools\ReportGenerator.exe -reports:TestResult.xml -targetdir:coverage  
pause