@set target=%1
@set refs=%target%..\..\..\..\refs\
@cd "%~dp0"
@xcopy %refs%*.dll %target%  /Y/Q/S /EXCLUDE:exclude 
