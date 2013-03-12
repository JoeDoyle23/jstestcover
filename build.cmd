@echo off

set target=%1

if "%target%" == "" (
   set target=Release
)

if "%1%" == "tests" (
   set target=Debug
)

%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild src\jstestcover.sln /t:Rebuild /p:Configuration=%target% /v:m

echo.
echo.

if "%1%" == "tests" (
   tests\NUnit\nunit-console tests\jstestcover.tests.dll /framework:net-4.0
)
