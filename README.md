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

* [Controlling a Power Relay from Mixed Reality](https://github.com/Sensorycc/Mixed-Reality-Hardware-Toolkit/wiki/Powering-any-device-on-and-off-using-Raspberry-Pi,-SpaceBrew-and-Mixed-Reality)
* [Connecting a Motorized Slide Pot to Spacebrew and Unity](https://github.com/Sensorycc/Mixed-Reality-Hardware-Toolkit/wiki/Connecting-a-Motorized-Slide-Pot-to-Spacebrew-and-Unity)
* [Virtual Wheel of Items with a Physical Knob](https://github.com/Sensorycc/Mixed-Reality-Hardware-Toolkit/wiki/Controlling-a-Virtual-Wheel-of-Items-in-Unity-by-Turning-a-Physical-Knob-Through-a-Servo-Hat-Using-Spacebrew-and-Unity)
* [weathAR: Weather AR with Motorized Contorl](https://github.com/Sensorycc/Mixed-Reality-Hardware-Toolkit/wiki/weathAR:-Weather-AR-simulation-using-Raspberry-pi,-Unity-and-Spacebrew)
* [Skywriter Hat, RPI and the Allegory of the duck](https://github.com/Sensorycc/Mixed-Reality-Hardware-Toolkit/wiki/Skywriter-SpaceBrew-Unity-Tutorial:-(The-allegory-of-the-Virtual-Cave-with-real-rubber-duck))
* [Surojit & Axel](https://github.com/Sensorycc/Mixed-Reality-Hardware-Toolkit/wiki/Tutorial-6)
* [AR-Fishing](https://github.com/Sensorycc/Mixed-Reality-Hardware-Toolkit/wiki/AR-Fishing)
* [Popping AR Balloons](https://github.com/Sensorycc/Mixed-Reality-Hardware-Toolkit/wiki/Popping-AR-Balloons-with-Adafruit's-Capacitive-Touch-Hat-for-Raspberry-Pi)
* [Touch Virtual Spiders](https://github.com/Sensorycc/Mixed-Reality-Hardware-Toolkit/wiki/Use-a-Touch-Sensor-to-make-an-Interactive-Box-of-Live-Spiders!)
* [Servos Control a Virtual Marble](https://github.com/Sensorycc/Mixed-Reality-Hardware-Toolkit/wiki/Servos-Control-a-Virtual-Marble)
* [Cat and Mouse: with a motorized slide pot](https://github.com/Sensorycc/Mixed-Reality-Hardware-Toolkit/wiki/Connecting-a-motorized-slide-pot-to-Unity-via-Spacebrew)

Documentation here: https://www.sensory.cc/mrht

YUXI has primarily been created by JOSHUA WALTON and JAMES TICHENOR, with the help of the the CIID IDP Class of 2018: FAHMIDA AZAD, ANNA SMERAGLIUOLO, ALEX PENMAN, MANTAS LILIS, ABHISHEK KUMAR, JULIANA LEWIS, FEDERICO PELITI, JING YU, RINA SHUMYLO, JULIUS INGEMANN BREITENSTEIN, MICOL GALEOTTI, REUBEN JEROME DSILVA, SAMI DÉSIR, SAREENA AVADHANY, SHALIN SHAH, SINDHUMANDARI, SUROJIT DEY, YUXI LIU, CHAERI BONG, AXEL JORGENSEN, RAPHAEL KATZ, RAUNAQ PATEL, UBALDO ANDREA DESIATO, VARENYA RAJ
