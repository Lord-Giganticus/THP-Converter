; The name of the installer
Name "THP-Converter"

; The file to write
OutFile "THP-Converter.exe"

; Request application privileges for Windows Vista
RequestExecutionLevel user

; Build Unicode installer
Unicode True

; The default installation directory
InstallDir "$DESKTOP\THP-Converter"

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
  File "THP-Converter-CS.exe"
  
SectionEnd ; end the section