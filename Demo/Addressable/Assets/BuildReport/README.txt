Build Report Tool README

Note: If you are upgrading Build Report Tool in your project, delete the current BuildReport folder first before importing the new one! This will eliminate any potential metadata file conflicts with the old Build Report Tool.




To show the Build Report Window, go to Window > Show Build Report.

If Build Report Tool doesn't show up when you do that, you may have to reset your Unity Editor layout. Choose Window > Layouts > Default.

Then try opening the Build Report Window again.




=== Saved Options ===

Options are saved to an XML file named "BuildReportToolOptions.xml".

By default this file is saved inside the BuildReport folder, but can be moved to, and will be recognized at certain paths:
1. inside the BuildReport folder itself
2. inside the topmost Assets folder of your project
3. outside the topmost Assets folder (i.e. in your project folder)
4. in your project folder's ProjectSettings folder
5. in the user's My Documents (inside the same folder where Build Report XML files are saved)

This is in prioritized order, so even if there is an options file in the My Documents folder, if there is also one in the project folder, it will use the one in the project folder instead.

If at any time no options file is found anywhere, it will create a new one inside the BuildReport folder with default values. You can move this file elsewhere in the above mentioned places if you don't want it inside the BuildReport folder.




=== Batchmode Builds ===

You can call BuildReportTool.ReportGenerator.CreateReport() to manually create a build report. Use this in your build scripts to properly create build reports. It should be called after BuildPipeline.BuildPlayer().

Check the file in BuildReport/CustomBuildScriptExample.txt for example code on how it's done.




=== Important Notes ===

In case you get any build errors that you think might be caused by the Build Report Tool, try disabling the Build Report Window from showing automatically whenever you build.

You can do this by opening the Build Report window, going to options, then uncheck "Collect and save build info automatically after building". If that doesn't work, you can simply delete the files in the Build Report Tool as a last resort.




=== Erroneous Values ===

The Build Report Tool gets much of its data from the Unity Editor's log file. Extremely large projects with large file sizes may get erroneous values. If you experience this, check your Editor log file: Go to your Console View (go to Window > Console, or press ctrl + shift + C). In the Console View's upper right corner, click the button "Open Editor Log".

If the Unity Editor's log file itself is showing wrong values for your file sizes, you may want to submit a bug report to Unity (go to Help > Report a Bug).




=== How to use ===

To show the Build Report Window, go to Window > Show Build Report.

Make sure you build your project first. If not, Build Report Tool has no data to get and will not work.

However, it won't care if the project you built last time isn't the same one you currently have open. So it's always best to build your project before you look at the Build Report Window.

You can also save build reports to XML files, or open previously saved ones. Whenever you build your project, the Build Report Tool will automatically generate a build report and save it. If you don't want the Build Report Tool to do that automatically, you can disable it in the options.




=== Parts ===

A build report is broken into five main categories:

1. Overview: Summary of the report.
2. Project Settings: Shows project settings that were used upon time of building.
3. Size Stats: Shows the build's file size, and a table breaking down of which assets are taking up what percentage of space on the build.
4. Used Assets: Shows a list of *all* assets that were included in the build, along with how much space they take.
5. Unused Assets: Shows a list of assets in the project that were *not* used for the build. This is useful for finding out which assets are not used anymore that perhaps you may want to delete to save space.




=== What's counted in the Build Report ===

The Build Report only takes into account your assets' size, plus managed DLLs. The real final size of your build may be larger or smaller depending on the platform.

In desktop and mobile builds, the build size reflects the size of the resulting sharedassets0.assets, sharedassets1.assets (and so on) files that are generated. Also counted are the files in the "Managed" folder (Mono DLLs, your scripts in compiled DLL form, plus other managed DLLs in your project).

All other files are not counted in the total build size. That includes native plugins.

But take note, native plugins will still show up in the asset lists, it is only that their size that is not counted in the "Total Used Assets Size".


Files in your StreamingAssets folder are not included in the "Used Assets Size Breakdown" table. However, their total size is still indicated, and those files are still included in the "Used Assets" list.


In desktop builds, you may find a "unity default resources" file in your build. Inside that are defaults, like the default GUI Skin, default font for the GUI, default shaders, the built-in cube, cylinder, or capsule, default white material, etc.

That file is also not counted in the Build Report.

See discussion here: http://forum.unity3d.com/threads/120081-unity-default-resources


In Windows, your resulting .exe file is also not considered in the Build Report as that is considered a "boilerplate" resource. The contents of your .exe file is largely standard among all Windows programs built in Unity, with some minor changes.


In web builds, your .unity3d file is a compressed archive of all your used assets, your Unity scene files, your scripts' resulting managed DLLs, any managed DLLs from the Mono standard library your build needs, plus any managed DLLs that you explicitly included.

Take note there are several Mono libraries that cannot be included for web due to considerations for web browser security.


In iOS builds, the total build size only represents the size of the game before it gets compiled and packaged into an .app file in Xcode. The size may get smaller once it gets packaged into an .ipa file.


Note: Managed DLLs mean DLL files containing compiled .NET/Mono code. Native DLLs mean DLL files built out of code that wasn't .NET/Mono (usually C/C++).




=== Prefab Instances in Scenes ===

If you have prefab instances in a scene, they don't actually count in the editor log's build info. Why exactly, I'm not sure.

My guess is things work this way: Actually during runtime, the concept of prefabs do not exist anymore. As far as Unity is concerned, they are all just game objects.

Instantiate actually merely duplicates/clones an existing game object (whether it is currently residing in the scene or exists as a prefab in the assets folder). (side note: you can actually use Instantiate to duplicate a game object, even if it is not a prefab)

As such, during runtime, prefab connections get lost. Once you run the game, prefab instances are simply considered regular game objects. I assume the same thing happens when you build your game.

So the prefab files in your project are not included in the build. Instead, the individual prefab instances that are in your scenes are the ones counted in the file size (technically their file sizes are in the scene files' file sizes).

Two exceptions:

1. If your prefab file is in a Resources folder, it gets included in the build.
2. If your prefab is referenced from a script via a variable/field, then it is included in the build.

Basically what it means is if you created your code in such a way that you need to instantiate a prefab at runtime (regardless of whether an instance of it is in the scene already or not) then Unity has no choice but to include it in the build.

So you may find some prefab files in the "Used Assets" section that do not show a size reading. Those are the prefabs that were used in scenes but are not in a Resources folder, nor referenced as a variable.




=== Size Readings ===

Why is the build size larger when shown in Windows Explorer?

You may find that the sizes in the Build Report Tool are different from the sizes of the files on disk. This is normal. Here is a good explanation why:  http://superuser.com/questions/66825/what-is-the-difference-between-size-and-size-on-disk

Quote:

We know that a disk is made up of Tracks and Sectors. In Windows that means the OS allocates space for files in "clusters" or "allocation units".

The size of a cluster can vary, but typical ranges are from 512 bytes to 32K or more. For example, on my C:\ drive, the allocation unit is 4096 bytes. This means that Windows will allocate 4096 bytes for any file or portion of a file that is from 1 to 4096 bytes in length.

...

Another example would be if I have a file that is 2000 bytes in size. The file size on disk would be 4096 bytes. The reason is, because even though the entire file can fit inside one allocation unit, it still takes up 4096 of space (one allocation unit) on disk (only one file can use an allocation unit and cannot be shared with other files).

So the size on disk is the space of all those sectors in which the file is saved. That means, usually, the size on disk is always greater than the actual size.

End quote.


Suffice to say that when your game/app will be downloaded over the Internet, the amount that needs to be transferred is the size reading that you see in the Build Report Tool, not the size reading on your disk.

Side note: Size readings in the Build Report window that have fractional parts are rounded up by two decimal places.




=== Licenses ===

Build Report Tool uses FuzzyString (https://fuzzystring.codeplex.com/). FuzzyString is in the Eclipse Public License (EPL).




=== Additional Notes ===

Don't worry, the assets that the Build Report Tool itself uses won't be included in your build.



Copyright © 2013-2019 by Anomalous Underdog

For support, you can either:

* send me a tweet at http://twitter.com/AnomalusUndrdog
* send me a private message in the Unity forums (http://forum.unity3d.com/members/8479-AnomalusUndrdog)
* send me an email at anomalous_underdog@yahoo.com


