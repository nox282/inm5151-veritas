# Tiled2UnityLite Download link : http://www.seanba.com/tiled2unity
NOTE : Please make sure to download the Tiled2UnityLite version which is the only one available for all plateforms!

# Prerequisites for Tiled2UnityLite 
- cs-script (http://www.csscript.net/CurrentRelease.html)
- mono C# compiler (http://www.mono-project.com/download/)
> NOTE : for linux installation, please refer to your distribution documentation

# Description
When you unzip Tiled2UnityLite, the folder contains 2 components
### The unity part
`Tiled2Unity.1.0.9.7.unitypackage` which is already installed on the Veritas unity project repository. In case you'd need to reinstall it, the process is as follow:

    dropdown menu Assets > Import Package > Custom Package... then select the .unitypackage file.
    
### The cli tool part
`Tiled2UnityLite.cs` which is already on the Veritas unity project repository. This is where you need the prerequisites  in order to run it. CS-Script is a utility that lets you run c# code as scripts. Mono is a standard c# compiler (and is required by cs-script). Whenever you want to run C# as script you need to call mono with the cscs.exe file which you will find at the installation directory of cs-script.
This solution simplify the usage of Tiled2Unity. Once setup you will need only a single command to export tmx file. (Awesome!)

# Commands :
### export tmx to unity
    mono [pathToCS-Script]/cscs.exe Tiled2UnityLite.cs [pathToTmxFile]/file.tmx [pathToUnityProject]/Assets/Tiled2Unity/
### help
    mono [pathToCS-Script]/cscs.exe Tiles2UnityLite.cs --help
This command will provide you with a number of arguments you can add to your export command

#Troubleshooting

If - when importing a .tmx file - the prefab doesn't update itself, you will need to remove the `Tiled2Unity` folder and re-import it. this is done by:
	
	dropdown menu Assets > Import Package > Custom Package... then select the .unitypackage file.