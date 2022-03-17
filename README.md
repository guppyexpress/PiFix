# PiFix
 fixes the pimax lighting issue on beatsaber. simple enough. have a pimax. dont want Parallel Projections?
get this mod!
<br>

>*known bugs. reflections still do not match, but are no longer painful to look at so they will not negitively impact your gameplay*


# WARNING! WILL CAUSE LIGHTING PROBLEMS ON NON PIMAX HEADSETS

<br>

# <h3> If you have downloaded the mod through ModAssistant or BeatDrop please follow the instructions below </h3>


<br>

If you have downloaded PiFix off of Mod Assistant or BeatDrop please follow these instructions.
once downloaded the mod will not be working. This is because it downloads a zip folder. this zip folder can not run as a mod
visit your beatsaber install folder 
>most often at "C:\Program Files (x86)\Steam\steamapps\common\Beat Saber\Plugins" 

there will be a zipped folder inside of the plugins folder called "PiFix5k" or "PiFix8k" depending on if you have downloaded the 5k or 8k version of this mod. 
please extract the zipped folder by right clicking the zip file, and clicking extract. once extracted you can delete the zipped folder. There will be a folder inside of your "\steamapps\common\Beat Saber\Plugins" called "PiFix5k" or "PiFix8k" depending on which was downloaded. open up that folder and it will have another folder called "Plugins" click into that folder. Inside there should be a DLL for either PiFix-5k or PiFix-8k depending on whichever one you have downloaded. drag and drop that file from "\steamapps\common\Beat Saber\Plugins\PiFix8k\Plugins\" or "\steamapps\common\Beat Saber\Plugins\PiFix5k\Plugins\" depending on whichever one you have downloaded your file structure should look like one of those two. Please put the mod's DLL into your **MAIN PLUGINS FOLDER** which is located at "C:\Program Files (x86)\Steam\steamapps\common\Beat Saber\Plugins". Once properly added to that file location. Pimax users will be able to see lighting properly without the need for parallel projections and will have no double vision.



# Q&A

<h2> Why is it downloaded in a zip file off of mod assistant? Why doesnt it download a dll like every other mod?" </h2>

>PiFix offsets the lighting effects to fix the issue found on pimax headsets. non Pimax headsets such as Oculus, Valve Index, HTC and Windows Mixed Reality will get their lighting and vision offcentered. causing double vision. there is currently no way that I can grab a hardware ID from a Pimax headset. and so to avoid someone accidentally installing PiFix while on an Oculus, HTC, Windows Mixed Reality, or Valve Index and then complaining that they now have double vision and it ruined their game. It just downloads as a zip folder and you have to manually enable the mod.

<h2> How do I know which headset I have? PiFix8k and PiFix5k what do they mean?</h2>

PiFix-5k is for these headsets

>- 5k+
>- 5kXR
>- 5ks
>- Artisan


PiFix-8k is for these headsets

>- 8k
>- 8k+
>- 8kx

<h2> Why are there 2 seperate DLLs for the mods? couldnt you have made them one dll? </h2>

>The Pimax 5k series  (Artisan, 5k+, 5kSuper, 5kXR) actually renders games differently than how the Pimax 8k series renders. due to this, there has to be 2 different mods, one for the 5k series and one for the 8k series. If you were to install PiFix-5k.dll and you own a Pimax 8kx, you will notice the lighting is not fixed, but rather still broken. Same thing would happen if you owned a 5kSuper and you downloaded PiFix-8k.dll This is because each mod is designed to work specifically with only 1 rendering method. and they can not be merged due to the same reasons as why it is i nside of a zipped folder.

<h2> My beatsaber lighting is still messed up, your mod is broken. why dont you fix it?</h2>

>If the mod is not working after you have installed it. please make sure that the proper game version is being used for this version of the mod. as well as be sure that BSIPA is installed to the version required for that version of beatsaber. As this mod requires BSIPA in order to work. If you have the properly installed game version, as well as the proper BSIPA version and the correct mod version. check in PiTool. if you have Parallel Projections enabled. Please turn it off. Parallel projections not only cuts your frame rate. But also causes your Pimax device to behave just like any other headset and you would be getting the double vision that is outlined in question 1. if you are still having double vision and it is not working, please check PiTool to see what device your headset is. Next please check inside of "\steamapps\common\Beat Saber\Plugins\PiFix8k\Plugins\" and make sure that you have the coresponding mod **DLL** if the DLL for the mod is not in the **main plugins folder** that will cause those problems. please refer to the install instructions to actually have the mod installed. 
