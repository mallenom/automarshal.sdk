@echo Looking for RegAsm...
@for %%f in (
	"%WINDIR%\Microsoft.NET\Framework\v4.0.30319\regasm.exe"
) do @if exist %%f (
	@echo RegAsm found at %%f
	@set regasm=%%f /unregister /verbose
	@goto regasmfound
)
@echo RegAsm was not found
@pause
@exit /b 1

:regasmfound
@echo Unregistering %~dp0recar2.com.dll...
@%regasm% "%~dp0recar2.com.dll"
@if %ERRORLEVEL% neq 0 goto error
@pause
exit /b 0

:error
@pause
@exit /b 1
