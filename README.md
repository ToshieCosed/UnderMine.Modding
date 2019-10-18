Important:

**VERY IMPORTANT**
After Patching, and moving your UnderMine_Patched.dll to the game folder and replacing UnderMine.dll with it,
by deleting or backing up UnderMine.dll and then renaming UnderMine_Patched.dll to UnderMine.dll
a mods folder will be created in your UnderMine game directory.
This is where you place mod dll files that you've compiled.
The demonstration mod SpeedMod is available to you, which can only access the class instance of SimulationPlayer, once
per frame.

When you build this you will need to reference UnderMine.dll from your UnderMine game folder in steamapps,
it's in 'UnderMine\UnderMine_Data\Managed', as well as the UnityEngine.dll file which, if you have not installed
Unity you will either need to install Unity or find the dll from their packages.

If you do have Unity installed you can find it somewhere in the default installpath on Windows.
On 64-bit systems it is found in: Program Files\Unity\Editor\Data\Managed\UnityEngine.dll

Once you add these references you can begin to build your mods.
To decompile the UnderMine.dll from your games folder use DnSpy it's great, or you can use IlSpy,
It will give you insight to how the game ticks and how to begin modding.

Modding is very limited right now, as we don't have many hooks.
If you would like to suggest a hook to something in the game's files,
you can open a new issue and document the hook and where you would like it, and we will attempt it.

At the moment we have to patch the UnderMine.dll directly by opening and editing it and injecting references by hand.
However -- A patcher known as Xdelta with binary diff files on Windows works great.

Remember to follow these instructions carefully, and always keep track of what you are naming your files/folders.

Happy Modding.