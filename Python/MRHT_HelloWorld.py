#!/usr/bin/env python

import sys
import time
import subprocess
from pySpacebrew.spacebrew import Spacebrew

# publish button press - bool
# listen for light changes - bool
brew = Spacebrew("MRHT_HelloWorld", description="Animate some wifi networks",  server="10.0.1.7", port=9000)
#brew.addSubscriber("satellite", "string")
brew.addPublisher("networkEvent", "boolean");
brew.addPublisher("wifi", "string")
connected = False

CHECK_FREQ = 2 # check mail every 60 seconds
CURR_INDEX = 0 # Create a queue of items

def makeArray():
    cmdCall = subprocess.check_output('sudo iwlist wlan0 scan | grep ESSID', shell=True)
    output = cmdCall.decode("utf-8").splitlines()
    for i, s in enumerate(output):
        output[i] = s[27:-1] #trim out all the stuff we don't need
        
    return output
    #return subprocess.call('sudo iwlist wlan0 scan | grep ESSID', shell=True).splitlines()
    # return str(os.system('sudo iwlist wlan0 scan | grep ESSID')).splitlines()

# def handleString(value):
#     print("Received: "+str(value))

# brew.subscribe("satellite", handleString)

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
            currentWifi = wifiNetworks[CURR_INDEX] #wifiNetworks[0]
            # currentWifi = "The Griffith Guest"
            brew.publish('wifi', currentWifi)
	    brew.publish('networkEvent',  True);
        connected = True
        time.sleep(CHECK_FREQ)




    
finally:
    brew.stop()
