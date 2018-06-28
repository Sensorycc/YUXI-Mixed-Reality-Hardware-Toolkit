#!/usr/bin/env python
# Never mix tabs and spaces.

##############################################################
# YUXI Lights and Buttons Example
# This script uses a Button wired to pin 24 and an LED light
# wired to pin 18. It publishes the button presses and listens
# for Spacebrew events to turn the light on. To use the button
# to turn off and on the light, connect them in Spacebrew.
##############################################################

import sys
import time
from pySpacebrew.spacebrew import Spacebrew
import RPi.GPIO as GPIO

# Setup Spacebrew with Publishers and Subscribers
brew = Spacebrew("YUXI_Light_Button", description="Python Light and Button controller",  server="ciidspacebrew.local", port=9000)
brew.addSubscriber("flipLight", "boolean")
brew.addPublisher("buttonPress", "boolean")

CHECK_FREQ = 0.1 # How often to check the hardware

GPIO.setwarnings(False)
GPIO.setmode(GPIO.BCM)
GREEN_LED = 18
RED_LED = 23
GPIO.setup(GREEN_LED, GPIO.OUT)
GPIO.setup(RED_LED, GPIO.OUT)
GPIO.setup(24, GPIO.IN) #down is False
lightOn = False 
alreadySent = False # to 'debounce' the button

def handleBoolean(value):
    global lightOn
    print("Received: "+str(value))
    if (value == 'true' or str(value) == 'True'):
        lightOn = not lightOn

# for handling messages coming through spacebrew 
brew.subscribe("flipLight", handleBoolean)

try:
    brew.start()
    print("Press Ctrl-C to quit.")
    while True:
        GPIO.output(GREEN_LED, False)
        if (GPIO.input(24) == False):
            if (alreadySent == False):
              print("Button Pushed")
              brew.publish('buttonPress', True)
              alreadySent = True
        GPIO.output(GREEN_LED, lightOn)
        time.sleep(CHECK_FREQ)
        if (GPIO.input(24) == True):
            alreadySent = False
    
finally:
    GPIO.cleanup()
    brew.stop()

