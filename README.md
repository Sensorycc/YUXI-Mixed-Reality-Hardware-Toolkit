# YUXI: The Mixed Reality Hardware Toolkit

The original inspiration behind YUXI was to create a set of methodologies, toolchains, and examples to mix physical computing with VR/AR/MR projects. The project examples currently a Raspberry Pi and breadboard mounted to a trackable base plate. From there we use <a href="http://www.spacebrew.cc">Spacebrew</a> to connect the inputs and outputs to Unity. 

[Getting Started](Getting_Started.md)

YUXI has 3 example projects that it comes with and there are many more that have been documented on the <a href="https://github.com/Sensorycc/Mixed-Reality-Hardware-Toolkit/wiki">Tutorial Wiki</a>

<img src="https://github.com/Sensorycc/YUXI-Mixed-Reality-Hardware-Toolkit/blob/master/Assets/Screenshots/YUXI_Hello_World.gif" width="900">


## Example 1: Hello World
This project creates the connection between the Python script on the Rapsberry Pi which publishes the wifi routers which it sees on its network and sends them to Spacebrew. The Unity side animates satellites for each incoming message. When connected the Python script will send each new Wifi Router to animate as a satellite in Unity. There is no need to connect additional hardware to the Raspberry Pi for this example to work. 


<img src="https://github.com/Sensorycc/YUXI-Mixed-Reality-Hardware-Toolkit/blob/master/Assets/Screenshots/YUXI_Lights_Buttons.gif" width="900">

## Example 2: Lights and Buttons
Using a breadboard to connect a button and an LED light, this example has identical Spacebrew publishers and subscribers in the 'physical' and 'virtual' side of the project. Both the Unity and Python side publish button pressed events and subscribe to a toggle light event. On their own, pushing the button will not perform any action. However you can route the physical button to either the physical or virtual light in order to control it. When deployed on an iOS device you can tap the virtual button on the screen to control the lights.  

<img src="https://github.com/Sensorycc/YUXI-Mixed-Reality-Hardware-Toolkit/blob/master/Assets/Screenshots/YUXI_SenseHat.gif" width="900">

## Example 3: SenseHat Letters
This example require connecting a SenseHat shield to the Raspberry Pi. The Python side of this example can listen for letters sent to it and display them on the LED matrix. Joystick directional presses are published from the board. On the Unity side letters can be sent to animate as a set of voxels, floating off into space. When routed together letter sent are shown on the LED matrix and then transfer to the augmented voxel space. 

Additional In-Progress Tutorials:

* [Connecting YUXI to a Power Relay](https://github.com/Sensorycc/YUXI-Mixed-Reality-Hardware-Toolkit/wiki/Connecting-XR-to-a-Power-Relay)
* [Connecting a Motorized Slide Pot to Spacebrew and Unity](https://github.com/Sensorycc/Mixed-Reality-Hardware-Toolkit/wiki/Connecting-a-Motorized-Slide-Pot-to-Spacebrew-and-Unity)
* [Virtual Wheel of Items with a Physical Knob using Servos Motors](https://github.com/Sensorycc/YUXI-Mixed-Reality-Hardware-Toolkit/wiki/Virtual-Wheel-of-Items-with-a-Physical-Knob-using-Servos-Motors)
* [weathAR: Weather AR with Motorized Contorl](https://github.com/Sensorycc/Mixed-Reality-Hardware-Toolkit/wiki/weathAR:-Weather-AR-simulation-using-Raspberry-pi,-Unity-and-Spacebrew)
* [Skywriter Hat, RPI and the Allegory of the duck](https://github.com/Sensorycc/Mixed-Reality-Hardware-Toolkit/wiki/Skywriter-SpaceBrew-Unity-Tutorial:-(The-allegory-of-the-Virtual-Cave-with-real-rubber-duck))
* [Sending images from Spacebrew to Unity](https://github.com/Sensorycc/YUXI-Mixed-Reality-Hardware-Toolkit/wiki/Workaround-for-sending-images-from-Spacebrew-to-Unity)
* [AR-Fishing](https://github.com/Sensorycc/Mixed-Reality-Hardware-Toolkit/wiki/AR-Fishing)
* [Popping AR Balloons](https://github.com/Sensorycc/Mixed-Reality-Hardware-Toolkit/wiki/Popping-AR-Balloons-with-Adafruit's-Capacitive-Touch-Hat-for-Raspberry-Pi)
* [Touch Virtual Spiders](https://github.com/Sensorycc/Mixed-Reality-Hardware-Toolkit/wiki/Use-a-Touch-Sensor-to-make-an-Interactive-Box-of-Live-Spiders!)
* [Servos Control a Virtual Marble](https://github.com/Sensorycc/Mixed-Reality-Hardware-Toolkit/wiki/Servos-Control-a-Virtual-Marble)
* [Cat and Mouse: with a motorized slide pot](https://github.com/Sensorycc/Mixed-Reality-Hardware-Toolkit/wiki/Connecting-a-motorized-slide-pot-to-Unity-via-Spacebrew)


writing some stuff here
and some more stuff here.

Documentation here: https://www.sensory.cc/yuxi

YUXI has primarily been created by Joshua Walton and James Tichenor, with the help of the the CIID IDP Class of 2018: Fahmida Azad, Anna Smeraglioulo, Alex Penman, Mantas Lilis, Abhishek Kumar, Juliana Lewis, Federico Peliti, Jing Yu, Rina Shumylo, Julius Ingemann Breitstein, Micol Galeotti, Reuben Jerome Dsilva, Sami Desir, Sareena Avadhany, Shalin Shad, Sindhumandari, Surojit Dey, Yuxi Liu (where the project gets its name), Chaeri Bong, Axel Jorgensen, Raphael Katz, Raunaq Patel, Ubaldo Andrea Desiato, Varenya Raj
