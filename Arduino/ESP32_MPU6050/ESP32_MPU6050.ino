#include <Wire.h>
//#include <SoftwareSerial.h>

#define ACC_RATE_2G 1671.8 // 加速度(2G)用の変換係数(生値→[m/s2]) ※32767/2/9.8
#define GYO_RATE_250 131.1 // 角速度(250[deg/s])用の変換係数(生値→[deg/s])

#define SCL_PIN 18
#define SDA_PIN 23

#define RESET_BUTTON_PIN 2

//SoftwareSerial serial(10, 11); // RX, TXピンを適宜変更

volatile uint8_t data[14]; //センサからのデータ格納用配列

volatile float ax = 0;   //出力データ(X軸加速度)
volatile float ay = 0;   //出力データ(Y軸加速度)
volatile float az = 0;   //出力データ(Z軸加速度)

volatile float rx = 0;   //出力データ(X軸角速度)
volatile float ry = 0;   //出力データ(Y軸角速度)
volatile float rz = 0;   //出力データ(Z軸角速度)

const int FirstButton = 19;   // IO19
const int SecondButton = 5;  // IO5
const int ThirdButton = 12;   // IO16
const int LeftButton = 27;    // IO21
const int RightButton = 17;   // IO22
const int EnterButton = 26;   // IO23
//const int ResetButton = 26;   // IO18

bool buttonFlag = false;
void setup() {
  //Serial.begin(115200);
  Wire.begin(SDA_PIN, SCL_PIN); // I2C通信を開始する
  Serial.begin(115200); // シリアル通信を開始する

  i2cWriteReg(0x68, 0x6b, 0x00); //センサーをONにする
  i2cWriteReg(0x68, 0x1b, 0x00); //角速度レンジ設定(±250[deg/s])
  i2cWriteReg(0x68, 0x1c, 0x00); //加速度レンジ設定(±2G)

  pinMode(BUTTON_PIN, INPUT_PULLUP);
  pinMode(FirstButton, INPUT_PULLUP);    // IO19
  pinMode(SecondButton, INPUT_PULLUP);   // IO5
  pinMode(ThirdButton, INPUT_PULLUP);    // IO16
  pinMode(LeftButton, INPUT_PULLUP);     // IO21
  pinMode(RightButton, INPUT_PULLUP);    // IO22
  pinMode(EnterButton, INPUT_PULLUP);    // IO23
  pinMode(ResetButton, INPUT_PULLUP);    // IO18

}

void loop() {
  MPU_DATAGET();

  // データをシリアルポートに送信する
  // 出力は以下の順番
  //ax,ay,az,rx,ry,rz
  Serial.print(ax);
  Serial.print(",");
  Serial.print(ay);
  Serial.print(",");
  Serial.print(az);
  Serial.print(",");
  Serial.print(rx);
  Serial.print(",");
  Serial.print(ry);
  Serial.print(",");
  Serial.println(rz);
  // Serial.print("X axis acceleration: "); Serial.println(ax);
  // Serial.print("Y axis acceleration: "); Serial.println(ay);
  // Serial.print("Z axis acceleration: "); Serial.println(az);
  // Serial.print("X axis angular velocity: "); Serial.println(rx);
  // Serial.print("Y axis angular velocity: "); Serial.println(ry);
  // Serial.print("Z axis angular velocity: "); Serial.println(rz);

  delay(100);
}
void Button(){
    /* 以下、ボタンを押された時の処理 */
  if (digitalRead(BUTTON_PIN) == LOW) {
    // ax = 0;
    // ay = 0;
    // az = 0;
    // rx = 0;
    // ry = 0;
    // rz = 0;
    buttonFlag = true;
    Serial.print(buttonFlag);
  }
  else if(digitalRead(FirstButton) == LOW)
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
  else
  {
    SerialBT.println("null");
  }
}
void MPU_DATAGET() {
  Wire.beginTransmission(0x68); //送信処理を開始する
  Wire.write(0x3b);             //(取得値の先頭を指定)
  Wire.endTransmission();       //送信を終了する
  Wire.requestFrom(0x68, 14);   //データを要求する(0x3bから14バイトが6軸の値)

  uint8_t i = 0;
  while (Wire.available()) {
    data[i++] = Wire.read();//データを読み込む
  }

                 //2byteの値
  ax = (float)((data[0] << 8) | data[1]) / ACC_RATE_2G; //LowとHighを連結して、値を取得する
  ay = (float)((data[2] << 8) | data[3]) / ACC_RATE_2G; //LowとHighを連結して、値を取得する
  az = (float)((data[4] << 8) | data[5]) / ACC_RATE_2G; //LowとHighを連結して、値を取得する

  rx = (float)((data[8] << 8) | data[9]) / GYO_RATE_250; //LowとHighを連結して、値を取得する
  ry = (float)((data[10] << 8) | data[11]) / GYO_RATE_250; //LowとHighを連結して、値を取得する
  rz = (float)((data[12] << 8) | data[13]) / GYO_RATE_250; //LowとHighを連結して、値を取得する
}

//レジスタ書き込み
void i2cWriteReg(uint8_t ad, uint8_t reg, volatile uint8_t data) {
  Wire.beginTransmission(ad); //送信処理を開始する
  Wire.write(reg);            //レジスタを指定
  Wire.write(data);           //データを書き込み
  Wire.endTransmission();     //送信を終了する
}
