@echo off

ECHO Copying program files...
IF NOT EXIST "%ProgramFiles%\dicom2mov" mkdir "%ProgramFiles%\dicom2mov"
xcopy program\* "%ProgramFiles%\dicom2mov\" /E /Y >nul

ECHO Copying presets and user profiles.
IF NOT EXIST "%USERPROFILE%\AppData\Roaming\dicom2mov" mkdir "%USERPROFILE%\AppData\Roaming\dicom2mov"
xcopy appdata\* "%USERPROFILE%\AppData\Roaming\dicom2mov\" /E /Y >nul

ECHO Done.