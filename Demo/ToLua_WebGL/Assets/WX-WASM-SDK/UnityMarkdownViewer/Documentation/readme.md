# Markdown Viewer for Unity
> v0.9

## About
Markdown Viewer for Unity is a custom inspector for markdown documents.

This means you can embed documentation directly into your project, complete with hyperlinks and images.

See the [cheatsheet.md](cheatsheet.md) file for a quick start of the markdown format.

---

## The Plugin

### Markdown Files
Markdown files are any file with the extension `.md` or `.markdown`.

### Refreshing a file
You can reload a file with `Asset -> Reimport` menu option (or context menu in the project window)

### Viewing the source
You can toggle between the raw markdown source and the rendered view by clicking the file icon in the top right corner.

### Creating markdown files
You can create a new markdown document from the assets create menu `Assets -> Create -> Markdown`.

You can specify the initial contents by creating a template file in your project called `Editor Default Resources\MarkdownTemplate.md`.

### Adding markdown files to the project
You can include markdown files in your C# project automatically by adding the extension to the project generation settings.

`Edit -> Project Settings -> C# Project Generation -> Additional extensions to include`

### Links
Links to images or documents with the project are are relative, for example.

```
[Sibling Document](a_sibling.md)
[Parent Directory](../parent_document.md)
![An Image](an_image.png)
```

Or from the project root

```
[Project Document](/Assets/Docs/some_document.md)
```

Or linked externally

```
[External Document](http://www.myproject.com/somefile.html)
[Some Shared File](file:///U:/ProjectShare/mystats.xlsx)
```

Or links to a section heading within the same document

```
[Another Section](#another-section)
```


### JIRA
The viewer can automatically convert JIRA issue items (e.g. XX-1234) to external links.

To do this set the URL to your JIRA project in the preferences.

`Edit -> Preferences ... -> Markdown`

### Embedded HTML
The unity viewer does not support embedding HTML into your markdown documents. By default any HTML is stripped out. You can change this behaviour in the preferences.

`Edit -> Preferences ... -> Markdown`



## Roadmap
The plugin, like many projects is a work in progress and new features and improvements will be added over time depending on the demand and popularity of the plugin.

These are the currently planned features on the roadmap in priority order.

#### Quick Editing
Allowing editing of the markdown directly in the inspector rather than in an external text editor or IDE.

#### Syntax Highlighting
Syntax highlighting for code samples.

#### Table Support
Adding support for the table extension.

#### Popular Markdown Extensions
Adding support for popular extensions to the markdown format (such as to do lists and strike through).


### Support
Questions or feature requests can be sent to me at [gwaredd@hotmail.com](mailto:gwaredd@hotmail.com)

GL & HF

