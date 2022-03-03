; The name of the installer
Name "THP-Converter-CS-CLI"

; The file to write
OutFile "THP-Converter-CS-CLI.exe"

; Request application privileges for Windows Vista
RequestExecutionLevel user

; Build Unicode installer
Unicode True

; The default installation directory
InstallDir "$DESKTOP\THP-Converter\CS\CLI"

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
  File "THP-Converter-CS-CLI.exe"
  File /nonfatal "THP-Converter-CS-CLI.dll"
  File /nonfatal "THP-Converter-CS-CLI.runtimeconfig.json"
  File /nonfatal "FFmpeg.NET.dll"
  
SectionEnd ; end the section