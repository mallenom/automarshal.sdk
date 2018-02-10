set target=%1\data\
@echo %target%
mkdir %target%
copy /Y data\* %target%