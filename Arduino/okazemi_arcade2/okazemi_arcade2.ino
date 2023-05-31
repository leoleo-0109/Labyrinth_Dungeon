#include "BluetoothSerial.h"

#if !defined(CONFIG_BT_ENABLED) || !defined(CONFIG_BLUEDROID_ENABLED)
#error Bluetooth is not enabled! Please run `make menuconfig` to and enable it
#endif

// Pin Assingment

const int buttonUp = 23;     // 23
const int buttonDown = 17;   // 19
const int buttonLeft = 25;    // 5 
const int buttonRight = 26;  // 18

BluetoothSerial SerialBT;

void setup() {
  SerialBT.begin("ESP32"); //Bluetooth device name
  //Serial.begin(115200);
  pinMode(buttonUp, INPUT_PULLUP);
  pinMode(buttonDown, INPUT_PULLUP);
  pinMode(buttonLeft, INPUT_PULLUP);
  pinMode(buttonRight, INPUT_PULLUP);
}

void loop() 
{
  //Serial.print("NO FORMAT");
  if(digitalRead(buttonUp) == LOW)
  {
    SerialBT.println("Up");
  }
  else if(digitalRead(buttonDown) == LOW)
  {
    SerialBT.println("Down");
  }
  else if(digitalRead(buttonLeft) == LOW)
  {
    SerialBT.println("Left");
  }
  else if(digitalRead(buttonRight) == LOW)
  {
    SerialBT.println("Right");
  }
  else {
    SerialBT.println("null");
  }
  delay(100);
}
