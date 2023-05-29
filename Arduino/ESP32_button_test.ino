#include "BluetoothSerial.h"

#if !defined(CONFIG_BT_ENABLED) || !defined(CONFIG_BLUEDROID_ENABLED)
#error Bluetooth is not enabled! Please run `make menuconfig` to and enable it
#endif

// Pin Assingment

/*  ESP32側 ⇔ MPU6050側, タクトスイッチ側, 操作ボタン側のPIN配置
 *   
 *  ※ESPは好きなピンで指定できる  
 *  　ATmega(Arduino)は固定のピン(A4, A5 or SCL, SDA)でしか使えない
 *   
 *  
 *                                   ESP32側
 *   3.3v   GND   IO15    IO0   IO19    IO5   IO16   IO21   IO22   IO23    EN
 *    |      |      |      |      |      |      |      |      |      |      |
 *   VCC    GND    SCL    SDA     |      |      |      |      |      |      |
 *           MPU6050側            1F     2F     3F    Left  Right  Enter  RESET
 *                                 タクトスイッチ側             操作ボタン側   
 *
 */

const int FirstButton = 18;   // IO19
const int SecondButton = 23;  // IO5
const int ThirdButton = 13;   // IO16
const int LeftButton = 14;    // IO21
const int RightButton = 16;   // IO22
const int EnterButton = 25;   // IO23
const int ResetButton = 26;   // IO18
const int X = 15;           // IO15  I2Cピン SCL
const int Y = 0;            // IO0   I2Cピン SDA

BluetoothSerial SerialBT;

void setup()
{
  SerialBT.begin("ESP32");    // Bluetooth device name

  pinMode(FirstButton, INPUT_PULLUP);    // IO19
  pinMode(SecondButton, INPUT_PULLUP);   // IO5
  pinMode(ThirdButton, INPUT_PULLUP);    // IO16
  pinMode(LeftButton, INPUT_PULLUP);     // IO21
  pinMode(RightButton, INPUT_PULLUP);    // IO22
  pinMode(EnterButton, INPUT_PULLUP);    // IO23
  pinMode(ResetButton, INPUT_PULLUP);    // IO18
  pinMode(X, INPUT);                   // A6ピンを入力ピンにする
  pinMode(Y, INPUT);                   // A7ピンを入力ピンにする
  Serial.println("----- RESET -----");
}

void loop()
{
  button();
  delay(100);
}

void button()
{
  /* 以下、ボタンを押された時の処理 */
  if(digitalRead(FirstButton) == LOW)
  {
    SerialBT.println("1F");
  }
  else if(digitalRead(SecondButton) == LOW)
  {
    SerialBT.println("2F");
  }
  else if(digitalRead(ThirdButton) == LOW)
  {
    SerialBT.println("3F");
  }
  else if(digitalRead(LeftButton) == LOW)
  {
    SerialBT.println("Left");
  }
  else if(digitalRead(RightButton) == LOW)
  {
    SerialBT.println("Right");
  }
  else if(digitalRead(EnterButton) == LOW)
  {
    SerialBT.println("Enter");
  }
  else if(digitalRead(ResetButton) == LOW)
  {
    SerialBT.println("Reset");
  }
  else
  {
    SerialBT.println("null");
  }
}
