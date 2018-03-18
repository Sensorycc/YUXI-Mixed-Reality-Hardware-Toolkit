/*
  Two way communication with the protosnap board
  Context: Arduino Protosnap from Sparkfun
  
  Component Pin	Arduino Pin
  Button	7
  Light Sensor	A0
  Green LED	5
  Blue LED	6
  Red LED	3
  Buzzer	2

*/
// constants to hold the output pin numbers:
// The defaults are for the MKR1000. For the 101, use numbers in comments
const int redPin = 3;     // for 101 use 3
const int greenPin = 5;   // for 101 use 6
const int bluePin = 6;    // for 101 use 5
int currentPin = 0; // current pin to be faded
int brightness = 0; // current brightness level
int lightPin = A0;  // Light sensor's connected to analog pin 0
int lightReading;  // variable we'll use to store light sensor reading

void setup() {
  // initiate serial communication:
  Serial.begin(9600);
  // initialize the LED pins as outputs:
  pinMode(redPin, OUTPUT);
  pinMode(greenPin, OUTPUT);
  pinMode(bluePin, OUTPUT);
}

void loop() {
  // if there's any serial data in the buffer, read a byte:
  if (Serial.available() > 0) {
    int inByte = Serial.read(); 
    // respond to the values 'r', 'g', 'b', or '0' through '9'.
    // you don't care about any other value:
    if (inByte == 'r') {
      currentPin = redPin; 
    }
    if (inByte == 'g') {
      currentPin = greenPin; 
    }
    if (inByte == 'b') {
      currentPin = bluePin; 
    } 
    if (inByte >= '0' && inByte <= '9') {
      // map incoming byte value to the range of the analogRead() command:
      brightness = map(inByte, '0', '9', 0, 255);  
      // set the current pin to the current brightness:
      analogWrite(currentPin, brightness);    
    } 
  }
  
  lightReading = analogRead(lightPin);  // read the light sensor
  Serial.println(lightReading, DEC);  // print the sensor reading
  //delay(250);
}
