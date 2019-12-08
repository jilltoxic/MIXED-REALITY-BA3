# MIXED-REALITY-BA3


Hello! Welcome to the GitHub Hub! From here on you can access mainly the Unity project we will be working on together as well as any other files/assets/writing/code etc.
This is just a reminder that you please consider all the rules set in place prior to any actions. I know it is a bit tedious right now but otherwise GitHub will probably
go to the shits and that is really annoying. 

Befor commiting, always have a personal set of the files just in case we have to re-calibrate the repository.

Proper Git Commit Formatting
-------------------------------------
A properly formed Git commit subject line should always be able to complete the following sentence:
If applied, this commit will your subject line here
Examples:
If applied, this commit will refactor subsystem X for readability
If applied, this commit will update getting started documentation
If applied, this commit will remove deprecated methods

General Conventions
------------------------
Before pushing a commit:
ALWAYS pull. Before commiting. Before pushing. Before doing anything. ALWAYS pull.
When updating files:
Do not give updated files new names. Replace the outdated ones. Doesn't work otherwise.
Files and Folders:
File names for sprites, models, animations etc always lowercase. Example: test_sprite_with_only_lowercase.png
Folder names always Uppercase. Example: Sprites/Entities/Characters/...
Always sort everything into its corresponding (sub-) folders. Example: lucy_walk_forward goes into Animations/Animation Clips/Lucy/Walk
Please don't forget that each sub-state (in case of animations, for example) should still get it's own folder.

In case GitHub goes to the shits
--------------------------------------
Please consult me if something happens. Regardless of what GitHub tells you, please ask me first.
Send me a screenshot of the error message and tell me what you did.
If I tell you to re-clone the repo, do the following:
1. Make sure that no important files are in the github folder. So never put a file in there without having a copy if it!
2. Go to Repository > Remove (Ctrl + Delete)
3. Check Also move this Repository to the Recycle Bin and click Remove.
4. Add the repo again using File > Clone Repository and then select sleepily/narrative again.
5. After it finished cloning, change to the current branch, fetch/pull and you're set.


Adding, Modifying, Moving and Replacing Files
-------------------------------------------------------
You can add new files either through the windows explorer or drag them into Unity. Both work.
When you modified a file outside of Unity, you need to replace the file in the windows explorer. 
Otherwise, Unity will think it's a new file and add a number to the file name.
If you want to move a file, you may only do so through Unity. 
Otherwise, it doesn't know what you did and gets confused, since it thinks you deleted the file and added a new one somewhere else. 
Prefabs using the file will break and Unity will create new (hidden) .meta files, so please refrain from doing otherwise.

One more GitHub thing
----------------------------
Two people can't work on the same file at the same time. Otherwise, someone has to redo their work. 
So - when you want to work on the main scene for example, please tell the others. 
I will try to maybe work in an additive scene for now with new things being added, but I dunno if it's gonna stay that way. 
So, at least when you're working on the Main Scene.unity file, tell the others