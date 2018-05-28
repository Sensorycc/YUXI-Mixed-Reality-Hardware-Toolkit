#!/usr/bin/env python

import sys
import time
from pySpacebrew.spacebrew import Spacebrew
import RPi.GPIO as GPIO

# publish button press - bool
# listen for light changes - bool
brew = Spacebrew("PyLightMRHT", description="Python Ligth controller",  server="10.1.1.214", port=9000)
brew.addSubscriber("flipLight", "boolean")
brew.addPublisher("buttonPress", "boolean")

CHECK_FREQ = 0.1 # check mail every 60 seconds

GPIO.setwarnings(False)
GPIO.setmode(GPIO.BCM)
GREEN_LED = 18
RED_LED = 23
GPIO.setup(GREEN_LED, GPIO.OUT)
GPIO.setup(RED_LED, GPIO.OUT)
GPIO.setup(24, GPIO.IN)
lightOn = False

def handleBoolean(value):
    global lightOn
    print("Received: "+str(value))
    if (value == 'true' or str(value) == 'True'):
        lightOn = not lightOn
        #GPIO.output(GREEN_LED, True)

brew.subscribe("flipLight", handleBoolean)

try:
    brew.start()
    #print("Should be looping")
    print("Press Ctrl-C to quit.")
    while True:
        #print("LOOP")
        GPIO.output(GREEN_LED, False)
        if (GPIO.input(24) == False):
		    print("Button Pushed")
		    brew.publish('buttonPress', True)
        GPIO.output(GREEN_LED, lightOn)
        time.sleep(CHECK_FREQ)
    
finally:
    GPIO.cleanup()
    brew.stop()

