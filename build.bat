@echo off

SET DIR=%~dp0%

@PowerShell -NoProfile -ExecutionPolicy unrestricted -Command "& '%DIR%Scripts\BuildChocolatey.ps1' %*"