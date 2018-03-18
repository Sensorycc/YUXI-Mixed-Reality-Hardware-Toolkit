/* 
 Serial String Reader
 Context: Processing
 */
 
import processing.serial.*;     // import the Processing serial library
import spacebrew.*;
 
Serial myPort;                  // The serial port
String resultString;            // string for the results
 
String server = "127.0.0.1";
String name = "Arduino Protosnap" + floor(random(1000));
String description = "This is forwards the output and input coming from the Arduino Protosnap";
Spacebrew sb;  // Spacebrew connection object
int bright = 0;   // the value of the phtocell we weill send over spacebrew
int red, green, blue;

void setup() {
  size(480, 130);               // set the size of the applet window
  
  // instantiate the spacebrew object
  sb = new Spacebrew( this );
  
  // add each thing you publish to
  sb.addPublish( "brightness", bright ); 
  sb.addSubscribe( "red", "range" );
  sb.addSubscribe( "green", "range" );
  sb.addSubscribe( "blue", "range" );
  
  // connect to spacebrew
  sb.connect(server, name, description );
  
  printArray(Serial.list());    // List all the available serial ports
 
  // get the name of your port from the serial list.
  // The first port in the serial list on my computer 
  // is generally my microcontroller, so I open Serial.list()[0].
  // Change the 0 to the number of the serial port 
  // to which your microcontroller is attached:
  String portName = Serial.list()[3];
  // open the serial port:
  myPort = new Serial(this, portName, 9600);
 
  // read bytes into a buffer until you get a linefeed (ASCII 10):
  myPort.bufferUntil('\n');
}
 
void draw() {
  // set the background and fill color for the applet window:
  background(#044f6f);
  fill(#ffffff);
  // show a string in the window:
  if (resultString != null) {
    text(resultString, 10, height/2);
  }
  writeToLED(); 
  if (mousePressed == true) {
     writeToLED(); 
  }
}
 

void writeToLED() {
  
  int r = (int) map(red, 0, 1024, 0, 9);
  int g = (int) map(green, 0, 1024, 0, 9);
  int b = (int) map(blue, 0, 1024, 0, 9);
  //int r = (int) random(0,9);
  //int g = (int) random(0,9);
  //int b = (int) random(0,9);
  println(r,g,b);
  
  myPort.write('r');
  myPort.write(Integer.toString(r));
  myPort.write('g');
  myPort.write(Integer.toString(g));
  myPort.write('b');
  myPort.write(Integer.toString(b));
  //myPort.write('\n');
}
 
// serialEvent method is run automatically by the Processing sketch
// whenever the buffer reaches the byte value set in the bufferUntil() 
// method in the setup():
 
void serialEvent(Serial myPort) { 
  // read the serial buffer:
  String inputString = myPort.readStringUntil('\n');
 
  // trim the carriage return and linefeed from the input string:
  inputString = trim(inputString);
  // clear the resultString:
  resultString = "";
 
  // split the input string at the commas
  // and convert the sections into integers:
  int sensors[] = int(split(inputString, ','));
 
  // add the values to the result string:
  for (int sensorNum = 0; sensorNum < sensors.length; sensorNum++) {
    map(sensorNum, 0, 255, 0, 1023);
    resultString += "Sensor " + sensorNum + ": ";
     sb.send("brightness", sensorNum);
    resultString += sensors[sensorNum] + "\t";
  }
  // print the results to the console:
  
  sb.send("brightness",resultString);
  println(resultString);
}

void onRangeMessage( String name, int value ){
  println("got range message " + name + " : " + value);
  //remote_slider_val = value;
  if (name.equals("red") == true) {
    if (value >= 0 && value <= 1023) {
      red = value;
    }
  }
  if (name.equals("green") == true) {
    if (value >= 0 && value <= 1023) {
      green = value;
      print("GOT GREEEN");
    }
  }
    if (name.equals("blue") == true) {
    if (value >= 0 && value <= 1023) {
      blue = value;
    }
  }
}