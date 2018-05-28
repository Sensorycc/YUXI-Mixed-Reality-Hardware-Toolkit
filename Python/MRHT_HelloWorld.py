#!/usr/bin/python
import sys
from pySpacebrew.spacebrew import Spacebrew 
import time

name = "MRHT_HelloWorld"
description = "MRHT Hello World Wifi Sensor"
server = "10.1.1.126"
brew = Spacebrew(name, description=description, server=server)
checkFrequency = 0.5

def handleBoolean(value):
    print(value)
    print("Flipped the light")

try: 
    brew.addPublisher("buttonPress", "boolean")
    brew.addSubscriber("lightFlip", "boolean")
    brew.start()

    brew.subscribe("lightFlip", handleBoolean)

    while True:
        print("ACK")
        brew.publish('buttonPress', True)
        time.sleep(checkFrequency)

except (Exception, KeyboardInterrupt) as exc:
        sys.exit(exc)

finally:
    brew.stop()