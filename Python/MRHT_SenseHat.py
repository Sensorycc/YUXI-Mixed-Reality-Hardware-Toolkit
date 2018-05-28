#!/usr/bin/env python

import sys
import time
from pySpacebrew.spacebrew import Spacebrew
from sense_hat import SenseHat

# Publish
# Joystick shows a letter
# publish up, down, left, right, middle

# Subscribe to letters
# Strings

# publish button press - bool
# listen for light changes - bool
brew = Spacebrew("MRHT_SenseHat", description="Joystick and LED letters",  server="10.10.2.47", port=9000)
brew.addSubscriber("letters", "string")
brew.addPublisher("joystick", "string")

# Setup SenseHat for animation on LED array
sense = SenseHat()
sense.set_rotation(180)

w = [255, 255, 255]
e = [0, 0, 0]
current_rate = 1.0
sense.clear()

def handleString(value):
    # grab only the first letter sent
    letter = value[0]
    print(letter)
    sense.show_letter(letter)
    time.sleep(0.5)
    sense.clear()

brew.subscribe("letters", handleString)

try:
    
    print("Press Ctrl-C to quit.")
    brew.start()

    while True:
        for event in sense.stick.get_events():
            # Check if the joystick was pressed
            if event.action == "pressed":

                # Check which direction
                if event.direction == "up":
                    sense.show_letter("U")      # Up arrow
                elif event.direction == "down":
                    sense.show_letter("D")      # Down arrow
                elif event.direction == "left": 
                    sense.show_letter("L")      # Left arrow
                elif event.direction == "right":
                    sense.show_letter("R")      # Right arrow
                elif event.direction == "middle":
                    sense.show_letter("M")      # Enter key

                # publish the joystick press to Spacebrew
                brew.publish('joystick', event.direction)

                # Wait a while and then clear the screen
                time.sleep(0.5)
                sense.clear()

finally:
    brew.stop()