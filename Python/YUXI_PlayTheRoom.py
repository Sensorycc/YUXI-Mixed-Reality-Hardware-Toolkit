
##############################################################
# YUXI Play The Room 2018 Sensory cc
# Author: James Tichenor
# This script adds Spacebrew to the Adafruit TouchHat example
# Each of the 12 connections on the TouchHat will publish
# to the spaccebrew server
# by default this will be the sandbox
##############################################################

import sys
import time
import subprocess
from pySpacebrew.spacebrew import Spacebrew
import socket
import Adafruit_MPR121.MPR121 as MPR121
from uuid import getnode as get_mac

time.sleep(10)

print('YUXI Play The Room')

mac = get_mac()
macString = ':'.join(("%012X" % mac)[i:i+2] for i in range(0, 12, 2))

def get_ip():
    s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    try:
        # doesn't even have to be reachable
        s.connect(('10.255.255.255', 1))
        IP = s.getsockname()[0]
    except:
        IP = '127.0.0.1'
    finally:
        s.close()
    return IP 

# Create MPR121 instance.
cap = MPR121.MPR121()

# Setup Spacebrew for Publishing
brew = Spacebrew("YUXI_PlayTheRoom : " + macString[-5:], description='[ capacitiveSwitches ] [local ip' + get_ip() + '] [MAC Address ' + macString + '] ',  server="sandbox.spacebrew.cc", port=9000)
for i in range (12):
    brew.addPublisher('P{0}'.format(i),'boolean')
connected = False

# Initialize communication with MPR121 using default I2C bus of device, and
# default I2C address (0x5A).  On BeagleBone Black will default to I2C bus 0.
if not cap.begin():
    print('Error initializing MPR121.  Check your wiring!')
    sys.exit(1)

# Alternatively, specify a custom I2C address such as 0x5B (ADDR tied to 3.3V),
# 0x5C (ADDR tied to SDA), or 0x5D (ADDR tied to SCL).
#cap.begin(address=0x5B)

# Also you can specify an optional I2C bus with the bus keyword parameter.
#cap.begin(busnum=1)

# Main loop to print a message every time a pin is touched.
try:
    brew.start()
    print('Press Ctrl-C to quit.')
    last_touched = cap.touched()

    while True:
        current_touched = cap.touched()
        # Check each pin's last and current state to see if it was pressed or released.
        for i in range(12):
            # Each pin is represented by a bit in the touched value.  A value of 1
            # means the pin is being touched, and 0 means it is not being touched.
            pin_bit = 1 << i
            # First check if transitioned from not touched to touched. 
            if current_touched & pin_bit and not last_touched & pin_bit:
                brew.publish('P{0}'.format(i),True)
                print('P{0} touched!'.format(i),True)
                time.sleep(0.1)
            # Next check if transitioned from touched to not touched.
            if not current_touched & pin_bit and last_touched & pin_bit:
                brew.publish('P{0}'.format(i),False)
                print('P{0} released!'.format(i),False)
                time.sleep(0.1)
        # Update last state and wait a short period before repeating.
        last_touched = current_touched
        time.sleep(0.1)
finally:
    brew.stop()
    
##############################################################
# Orignial Adaruit licnece

# Copyright (c) 2014 Adafruit Industries
# Author: Tony DiCola
#
# Permission is hereby granted, free of charge, to any person obtaining a copy
# of this software and associated documentation files (the "Software"), to deal
# in the Software without restriction, including without limitation the rights
# to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
# copies of the Software, and to permit persons to whom the Software is
# furnished to do so, subject to the following conditions:
#
# The above copyright notice and this permission notice shall be included in
# all copies or substantial portions of the Software.
#
# THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
# IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
# FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
# AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
# LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
# OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
# THE SOFTWARE.
