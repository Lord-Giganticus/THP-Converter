# THP-Conveter
* ![Python application](https://github.com/Lord-Giganticus/THP-Conveter/workflows/Python%20application/badge.svg)
* ![CodeQL](https://github.com/Lord-Giganticus/THP-Conveter/workflows/CodeQL/badge.svg)

Python scripts to convert folders with wii/gc era thp videos into mp4 files and vice versa.
I hadn't really seen any good coverters for this file type so I wrote one.

# Requirements:
- Python 3.x (Preferably 3.7 and above.)
- FFMPEG installed to PATH. [Latest Windows Binary Release](https://github.com/GyanD/codexffmpeg/releases) [How to install to PATH](https://blog.gregzaal.com/how-to-install-ffmpeg-on-windows/)
- `THPConv.exe` installed to PATH and `dsptool.dll` in the same folder as `THPConv.exe`. **Due to both files being property of Nintendo, I can not provide the links to these. ~~There is a link to a zip of the files in `MP4toTHP.py`~~**

# Conributing:
Refer to [CONTRIBUTING.md](https://github.com/Lord-Giganticus/THP-Conveter/blob/master/CONTRIBUTING.md) for info.

# Known issues:
- `THPconv.exe` has this odd frame glitch when putting audio into it. [#1](https://github.com/Lord-Giganticus/THP-Conveter/issues/1)
*This may never be fixed*

# To add issues:
Refer to this [template.](https://github.com/Lord-Giganticus/THP-Conveter/blob/master/.github/ISSUE_TEMPLATE/bug_report.md)
