# Unity Markdown Viewer (UMV)
> A markdown viewer for unity

UMV is a Unity editor extension for displaying markdown files in the inspector window.

It should _just work_ without any setup or configuration.

## Installation

There are a number of options for installing the package, choose your preference :)

### Asset Store

The project is available on the [Unity Asset Store](https://assetstore.unity.com/packages/tools/utilities/markdown-viewer-138882).

### Asset Import

* Download the `.unitypackage` file from the [releases page](https://github.com/gwaredd/UnityMarkdownViewer/releases).
* In the editor - `Assets -> Import Package -> Custom Package ...`

### Package Manager

You can use the unity package manager to install and manage the library direct from github. You should have `git` installed and available in your system's PATH.

Add the following line to your project `Packages/manifest.json` file.

    "com.mischief.markdownviewer": "https://github.com/gwaredd/UnityMarkdownViewer.git",

It should look something like things

    {
      "dependencies": {
        "com.mischief.markdownviewer": "https://github.com/gwaredd/UnityMarkdownViewer.git",
        "com.unity.package-manager-ui": "2.1.2",
        "com.unity.modules.ai": "1.0.0",
        "com.unity.modules.animation": "1.0.0",
        ...
      }
    }

It will install automatically.

## Screenshots

![Screenshot](https://raw.githubusercontent.com/gwaredd/UnityMarkdownViewer/master/Documentation/images/Screenshot_render_v2.png)

![Screenshot](https://raw.githubusercontent.com/gwaredd/UnityMarkdownViewer/master/Documentation/images/Screenshot_render_v1.png)

