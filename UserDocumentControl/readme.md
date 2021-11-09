# About

A fictitious utility appliction which allows a user to create an archive .zip file with one or more directories where directories are dropped into a window.

- Directory selections are saved to a json file for remembering from session to session, see figure 1.
  - `IncludeFolder` true to include in zip, false to exclude from zip
  - `DirectoryName` is the directory to include
  - `ShortName` is the Windows short name for DirectoryName
- Logging is setup in Program.cs and enabled/disabled with a key in App.config, `UseLogging` and the file name key is `ListenerLogName`.

**Figure 1**
```json
[
  {
    "IncludeFolder": false,
    "DirectoryName": "C:\\OED\\Dotnetland\\VS2019\\ImportingCsvFiles",
    "ShortName": "C:\\OED\\DOTNET~1\\VS2019\\IMPORT~1"
  },
  {
    "IncludeFolder": false,
    "DirectoryName": "C:\\Users\\paynek\\Documents\\DotNetTraining",
    "ShortName": "C:\\Users\\paynek\\DOCUME~1\\DOTNET~1"
  },
  {
    "IncludeFolder": false,
    "DirectoryName": "C:\\OED\\Dotnetland\\VS2019\\configuration-helpers",
    "ShortName": "C:\\OED\\DOTNET~1\\VS2019\\CONFIG~1"
  },
  {
    "IncludeFolder": false,
    "DirectoryName": "C:\\OED\\Dotnetland\\VS2019\\KP_ConverterLibrary",
    "ShortName": "C:\\OED\\DOTNET~1\\VS2019\\KP_CON~1"
  },
  {
    "IncludeFolder": false,
    "DirectoryName": "C:\\OED\\Dotnetland\\VS2019\\EntityFrameworkCoreGettingStarted",
    "ShortName": "C:\\OED\\DOTNET~1\\VS2019\\ENTITY~1"
  }
]
```