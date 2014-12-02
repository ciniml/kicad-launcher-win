@ECHO OFF

REM kicad-launcher-win build script.
REM Copyright 2014 Kenta IDA
REM 
REM This program is free software: you can redistribute it and/or modify
REM it under the terms of the GNU General Public License as published by
REM the Free Software Foundation, either version 3 of the License, or
REM (at your option) any later version.
REM 
REM This program is distributed in the hope that it will be useful,
REM but WITHOUT ANY WARRANTY; without even the implied warranty of
REM MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
REM GNU General Public License for more details.
REM 
REM You should have received a copy of the GNU General Public License
REM along with this program.  If not, see <http://www.gnu.org/licenses/>.
REM 

REM Find latest available .NET Framework version.
SET DOTNET_BASE=%SystemRoot%\Microsoft.NET\Framework
SET DOTNET_ROOT=%DOTNET_BASE%\v4.0.30319
IF NOT EXIST "%DOTNET_ROOT%" SET DOTNET_ROOT=%DOTNET_BASE%\v2.0.50727
IF NOT EXIST "%DOTNET_ROOT%" (
	ECHO ERROR: No .NET Framework available.
	ECHO Please confirm that .NET Framework or above are installed correctly.
	GOTO :END
	)
ECHO Using .NET Framework at "%DOTNET_ROOT%"
SET CSC="%DOTNET_ROOT%\csc.exe"
SET OUTPUT=KiCadLauncherWin.exe

ECHO Compiling...
%CSC% /target:winexe /out:%OUTPUT% /win32icon:..\kicad\bitmaps_png\icons\icon_kicad.ico /optimize+ Program.cs AssemblyInfo.cs
COPY /Y %OUTPUT% ..\..\
ECHO Done.

:END
PAUSE
