# v1.1    
Added version manager - now you can use any verison of GMS1.4 you want    
Updated default version to 1.4.9999   
Fixed a bug where changing the project wouldnt update the preview.   
Fixed a bug where if you never opened "Global Game Settings" in GameMaker    
Then GayMaker would crash (IT WAS A STRANGE PARSER DIFFERNTAL xD)    
See issue [#9 on GayMaker](https://bitbucket.org/SilicaAndPina/gaymaker/issues/9/global-game-settings)    
Added an update-checker it'll ask you if you want to update when a new update is avalible.          

Download: https://bitbucket.org/SilicaAndPina/gaymaker-studio/downloads/GayMaker-Studio%201.1.zip    

# v1.0
Inital Release!   

Download: https://bitbucket.org/SilicaAndPina/gaymaker-studio/downloads/GayMaker-Studio.zip     
     
#GayMaker: Studio

Homebrew GM:S Export tool (Based off the original [GayMaker Tool for PSVita](https://bitbucket.org/SilicaAndPina/gaymaker))

Run the program. and browse to a GameMaker Studio project file (.gmx).
you can also change the images, Title. and TitleID and then your game will be 
"compiled" for PS4 and saved as a PKG to whereever you choose to save it

All projects are compiled using GameMaker 1.4.1804 - the latest version that works on 5.05  
Packages are created using LibOrbisPkg, No changes made to the original source of the Libary.  
However some snippits where taken from the PkgEditor and changed to not read from clipboard / drag n drop  

Please show me any games you make with it! (though, please note i wont be too interested unless a girl dies)

#Shaders
When you compile a project that uses Shaders for the first time. you'll be prompted to browse to 'orbis-wave-psslc.exe'
This file will then be placed into the GayMaker: Studio install folder and you wont have to do it again after that.
Shaders will compile into the GXP format. which will then work on the console itself.

For *reasons*, i will not provide a link to orbis-wave-psslc.exe


# Controller Mapping 
  
To Check DS4 Controls use the [GamePad](https://docs.yoyogames.com/source/dadiospice/002_reference/mouse,%20keyboard%20and%20other%20controls/gamepad%20input/index.html) commands    
Here is what each control maps to:  

gp_face1 = CROSS  
gp_face2 = SQUARE  
gp_face3 = CIRCLE  
gp_face4 = TRIANGLE  
  
gp_shoulderl = L1  
gp_shoulderr = R1  
gp_shoulderlb = L2  
gp_shoulderrb = R2  
  
gp_select = SELECT  
gp_start = START  
  
gp_stickl = L3  
gp_stickr = R3  
  
gp_padu = DPAD UP  
gp_padd = DPAD DOWN  
gp_padl = DPAD LEFT  
gp_padr = DPAD RIGHT  
  
gp_axislh = LEFT ANOLOUGE HORIZONTAL AXIES  
gp_axislv = LEFT ANOLOUGE VERTICAL AXIES  
  
gp_axisrh = RIGHT ANOLOUGE HORIZONTAL AXIES  
gp_axisrv = RIGHT ANOLOUGE VERTICAL AXIES  

# Homebrew Repo  
This repository has some GameMaker: Studio Homebrew games / ports.   
https://bitbucket.org/SilicaAndPina/gm-shb  

# Credits  
Thanks YoYoGames for GameMaker, "YOYO_DEV_ENABLE", and having a unsecured CDN    
Thanks To the devs of DnSpy for indirectly making this possible ;)   
Thanks To MaxTon for [LibOrbisPkg](https://github.com/maxton/LibOrbisPkg)   
Thanks To ignacio1420 and Nagato for Testing!    
Thanks To flat_z for [make_fself.py](https://twitter.com/flat_z/status/954856357664100354)