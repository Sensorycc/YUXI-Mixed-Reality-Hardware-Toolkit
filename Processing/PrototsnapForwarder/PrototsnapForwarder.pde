import cc.arduino.*;
import org.firmata.*;
import spacebrew.*;
import processing.serial.*;

String server = "127.0.0.1";
String name = "Arduino Protosnap" + floor(random(1000));
String description = "This is forwards the output and input coming from the Arduino Protosnap";
Arduino arduino;

int bright = 0;   // the value of the phtocell we weill send over spacebrew
boolean button;
int buttonPin = 7;  // button is connected to pin 7
int ledPin = 13;  // LED's connected to pin 13
int buttonState = 0;

Spacebrew spacebrewConnection;  // Spacebrew connection object
//Serial myPort;          // Serial port object 

void setup() {
  size(400, 200);

  // instantiate the spacebrew object
  spacebrewConnection = new Spacebrew( this );
  
  // add each thing you publish to
  spacebrewConnection.addPublish( "button", button ); 

  // connect to spacebrew
  spacebrewConnection.connect(server, name, description );

  // print list of serial devices to console
  println(Serial.list());
  //myPort = new Serial(this, Serial.list()[0], 9600); // CONFIRM the port that your arduino is connect to
  arduino = new Arduino(this, "/dev/cu.usbserial-A900fwrb", 57600);
  arduino.pinMode(ledPin, Arduino.OUTPUT);
  arduino.pinMode(buttonPin, Arduino.INPUT);

  //myPort.bufferUntil('\n');
}

void draw() {
    for (int i = 0; i <= 13; i++) {
      
    }
    
  buttonState = arduino.analogRead(buttonPin);
  //println("The buttonState is ", buttonState);

  if (buttonState == LOW) {
    digitalWrite(ledPin, HIGH);  // If the button's pressed turn the LED on
  }
  else {
    digitalWrite(ledPin, LOW);  // Otherwise, turn the LED off
  }
  
  //arduino.digitalWrite(ledPin, Arduino.HIGH);
  //delay(500);
  //arduino.digitalWrite(ledPin, Arduino.LOW);
  //delay(1000);

}


//void serialEvent (Serial myPort) {
//  // read data as an ASCII string:
//  String inString = myPort.readStringUntil('\n');

//  if (inString != null) {
//    // trim off whitespace
//    inString = trim(inString);

//    // convert value from string to an integer
//    bright = int(inString); 

//    // publish the value to spacebrew if app is connected to spacebrew
//    if (spacebrewConnection.connected()) {
//      spacebrewConnection.send( "brightness", bright );
//    }
//  }
//}