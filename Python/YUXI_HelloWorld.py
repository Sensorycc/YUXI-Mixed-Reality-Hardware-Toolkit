#!/usr/bin/env python

##############################################################
# YUXI Hello World Example
# This script will ask the Raspberry Pi for what wifi networks
# it can see and then send them as Spacebrew events
##############################################################

import sys
import time
import subprocess
from pySpacebrew.spacebrew import Spacebrew


# Setup Spacebrew for Publishing
brew = Spacebrew("MRHT_HelloWorld", description="Animate some wifi networks",  server="ciidspacebrew.local", port=9000)
brew.addPublisher("networkEvent", "boolean");
brew.addPublisher("wifi", "string")
connected = False

CHECK_FREQ = 2 # time to sleep between adding items 
CURR_INDEX = 0 # Create a queue of items

def makeArray():
    # Check for a list of wifi networks that the RPi can see
    cmdCall = subprocess.check_output('sudo iwlist wlan0 scan | grep ESSID', shell=True)
    output = cmdCall.decode("utf-8").splitlines()
    for i, s in enumerate(output):
        output[i] = s[27:-1] #trim out all the stuff we don't need
        
    return output

try:
    brew.start()
    print("Press Ctrl-C to quit.")
    wifiNetworks = makeArray()

    while True:
        if (connected == True):
            if (CURR_INDEX < len(wifiNetworks)-1):
                CURR_INDEX += 1
            else:
                CURR_INDEX = 0
            #print("Wifi Sent")
            print(wifiNetworks[CURR_INDEX])        
            currentWifi = wifiNetworks[CURR_INDEX] 
            brew.publish('wifi', currentWifi)
	    brew.publish('networkEvent',  True);
        connected = True
        time.sleep(CHECK_FREQ)

finally:
    brew.stop()
