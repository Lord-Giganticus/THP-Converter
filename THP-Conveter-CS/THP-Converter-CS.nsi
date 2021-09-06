; The name of the installer
Name "THP-Converter-CS"

; The file to write
OutFile "THP-Converter-CS.exe"

; Request application privileges for Windows Vista
RequestExecutionLevel user

; Build Unicode installer
Unicode True

; The default installation directory
InstallDir "$DESKTOP\THP-Converter\CS"

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
  File "THP-Converter-CS.exe"
  File /nonfatal "THP-Converter-CS.dll"
  File /nonfatal "THP-Converter-CS.runtimeconfig.json"
  File /nonfatal "FFmpeg.NET.dll"
  
SectionEnd ; end the section