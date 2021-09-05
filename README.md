# THP-Conveter
* ![Python application](https://github.com/Lord-Giganticus/THP-Conveter/workflows/Python%20application/badge.svg)
* ![CodeQL](https://github.com/Lord-Giganticus/THP-Conveter/workflows/CodeQL/badge.svg)

Python scripts to convert folders with wii/gc era thp videos into mp4 files and vice versa.
Plus a now working C# version!
I haven't seen any good coverters for this file type so I wrote one.

# Requirements for compiling the C# project
- .NET 5.0 runtime [(link to runtime)](https://dotnet.microsoft.com/download/dotnet/5.0/runtime)
- `THPConv.exe` and `dsptool.dll` in the `THP-Conveter-CS` folder. **Due to both files being part of the RVL SDK (Wii SDK), I can not provide the links to these.** ~~May or may not be in the resources for the C# program and required to be in the folder for building~~ ;)
# Conributing:
Refer to [CONTRIBUTING.md](https://github.com/Lord-Giganticus/THP-Conveter/blob/master/CONTRIBUTING.md) for info.

# Known issues:
- ~~`THPconv.exe` has this odd frame glitch when putting audio into it. [#1](https://github.com/Lord-Giganticus/THP-Conveter/issues/1)
*This might never be fixed*~~ This has been finally fixed

# To add issues:
Refer to this [template.](https://github.com/Lord-Giganticus/THP-Conveter/blob/master/.github/ISSUE_TEMPLATE/bug_report.md)
