; The name of the installer
Name "THP-Converter-PY"

; The file to write
OutFile "THP-Converter-PY.exe"

; Request application privileges for Windows Vista
RequestExecutionLevel user

; Build Unicode installer
Unicode True

; The default installation directory
InstallDir "$DESKTOP\THP-Converter\PY"

;--------------------------------

; Pages

Page directory
Page instfiles

;--------------------------------
; The stuff to install
Section "" ;No components page, name is not important
  ; Set output path to the installation directory.
  SetOutPath $INSTDIR
  
  ; Put file there
  File "THPConv.exe"
  File "dsptool.dll"
  File "dist\mp4tothp.exe"
  File "dist\thptomp4.exe"
  
SectionEnd ; end the section