# Recycling-VR-Game-in-School-Hallway
A virtual reality game that is build on Android using google cardboard sdk

### Description
The hallway is designed to be endless. Once the player triggers an invisible game object at the end of the hallway, 
it will initialize a new hallway and connects to the very end. The hallway in the very beginning will be destroyed after a certain time 
period to avoid too many game objects existing at the same time. The trash are rendered randomly for each category. 
There are green, blue, and black colors on the floor indicating the  correct trash bin color that trash. For example, 
the trash that appears on the top of blue section floor should be collected with blue trash bin.

### How to Play?
The game is controlled via head-tracking using **Google cardboard VR**. The player can press the button to switch trash bins. 
The player can look left or right to change the directions. Whenever the player looks down at a certain degree, 
the player will constantly moving forward. If the player looks up, it would stop moving.

### Demo
<img width=600px src="./demos/game_demo.gif">

### Unity Version
- **2019.4.19f1**

### Packages
- [GVR SDK for Unity v1.200.1](https://github.com/googlevr/gvr-unity-sdk/releases)

### Build Support 
- Android Build Support
- Andriod SDK & NDK Tools

