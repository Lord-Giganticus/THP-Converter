# THP-Conveter
* ![Python application](https://github.com/Lord-Giganticus/THP-Conveter/workflows/Python%20application/badge.svg)
* ![CodeQL](https://github.com/Lord-Giganticus/THP-Conveter/workflows/CodeQL/badge.svg)

Python scripts to convert folders with wii/gc era thp videos into mp4 files and vice versa.
I haven't seen any good coverters for this file type so I wrote one.

# Requirements:
- Python 3.x (Preferably 3.7 and above), .NET 5.0 runtime [(link to runtime)](https://dotnet.microsoft.com/download/dotnet/5.0/runtime)
- FFMPEG installed to PATH. [Latest Windows Binary Release](https://github.com/GyanD/codexffmpeg/releases) [How to install to PATH](https://blog.gregzaal.com/how-to-install-ffmpeg-on-windows/)
- `THPConv.exe` and `dsptool.dll` in the same folder as `THPConv.exe`. **Due to both files being part of the RVL SDK (Wii SDK), I can not provide the links to these.** ~~May or may not be in the resources for the C# program and required to be in the folder for building~~ ;)
# Conributing:
Refer to [CONTRIBUTING.md](https://github.com/Lord-Giganticus/THP-Conveter/blob/master/CONTRIBUTING.md) for info.

# Known issues:
- `THPconv.exe` has this odd frame glitch when putting audio into it. [#1](https://github.com/Lord-Giganticus/THP-Conveter/issues/1)
*This might never be fixed*

# To add issues:
Refer to this [template.](https://github.com/Lord-Giganticus/THP-Conveter/blob/master/.github/ISSUE_TEMPLATE/bug_report.md)
