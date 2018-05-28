#!/usr/bin/python

from pySpacebrew.spacebrew import Spacebrew 
import time
import sys

# SETUP SPACEBREW
name = "MRHT_HelloWorld"
description = "MRHT Hello World Wifi Sensor"
server = "10.1.1.126"
port = 9000
brew = Spacebrew(name=name, description=description, server=server, port=port)

# ADD PUBLISHERS AND SUBSCRIBERS
# Types are: boolean, string, range
brew.addPublisher("buttonPress", "boolean")
brew.addSubscriber("lightFlip", "boolean")
brew.start()

checkFrequency = 0.1
fakeButton = True

def handleBoolean(value):
    print(value)
    print("Flipped the light")

brew.subscribe("lightFlip", handleBoolean)

while True:
    #brew.publish('buttonPress', fakeButton)
    print("Button")
    time.sleep(checkFrequency)
