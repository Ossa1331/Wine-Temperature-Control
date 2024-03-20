#include <LiquidCrystal.h>
#include <BAE910.h>
#include <DS18B20.h>
#include <DS2401.h>
#include <DS2405.h>
#include <DS2408.h>
#include <DS2413.h>
#include <DS2423.h>
#include <DS2431.h>
#include <DS2433.h>
#include <DS2438.h>
#include <DS2450.h>
#include <DS2502.h>
#include <DS2506.h>
#include <DS2890.h>
#include <OneWireHub.h>
#include <SoftwareSerial.h>
SoftwareSerial link(5, 5);
#include <OneWireHub_config.h>
#include <OneWireItem.h>
#include <platform.h>

#include <DallasTemperature.h>
#include <OneWire.h>

#include <Wire.h>

#include <OneWire.h>
#include <DallasTemperature.h>

// Data wire is plugged into digital pin 2 on the Arduino
#define ONE_WIRE_BUS 2

// Setup a oneWire instance to communicate with any OneWire device
OneWire oneWire(ONE_WIRE_BUS);  

// Pass oneWire reference to DallasTemperature library
DallasTemperature sensors(&oneWire);

LiquidCrystal lcd(12, 11, 6, 5, 4, 3);

DeviceAddress Thermometer;

int led1 = 5;
int deviceCount = 0;
float tempC;
float tempC1;
float tempC2;
float tempC3;
float tempC4;
int deviceCount1 = 2;
int deviceCount2 = 0;
int a_temp = 4; 
boolean state = false;
boolean state1 = true;




void setup(void)
{
  Wire.begin(); 
  sensors.begin();  
  Serial.begin(9600); //initialize serial communication at 115200 bps
  deviceCount = sensors.getDeviceCount();
  pinMode(led1,OUTPUT);
  pinMode(a_temp, INPUT);
  pinMode(8, OUTPUT);
  pinMode(9, OUTPUT);
  pinMode(10, OUTPUT);
  pinMode(11, OUTPUT);
  pinMode(12, OUTPUT);
  pinMode(13, OUTPUT);
}

void loop(void)
{ 
  
  //lcd.setCursor(0,0);
// ---------------------------------------------- senzor 1
  sensors.requestTemperatures();
  tempC = sensors.getTempCByIndex(0);

  

    for (int i = 0;  i < deviceCount;  i++)
    {
      /*
      lcd.print("Sensor ");
      lcd.print(1);
      lcd.print(" : ");
      lcd.print(tempC);
      lcd.print((char)176);
      */
      Serial.print("1_");
      Serial.print(tempC);
      Serial.print("\n");
    }

// ---------------------------------------------- senzor 2
    
  sensors.requestTemperatures();
  tempC1 = sensors.getTempCByIndex(1);
  

    for (int i = 1;  i < deviceCount;  i++)
    {
      /*
      lcd.setCursor(0,1);
      lcd.print("Sensor ");
      lcd.print(i+1);
      lcd.print(" : ");
      lcd.print(tempC1);
      lcd.print((char)176);
      */
      Serial.print("2_");
      Serial.print(tempC1);
      Serial.print("\n");
    }

// ---------------------------------------------- senzor 3
    
  sensors.requestTemperatures();
  tempC2 = sensors.getTempCByIndex(2);
  

    for (int i = 2;  i < deviceCount;  i++)
    {
      /*
      lcd.setCursor(0,1);
      lcd.print("Sensor ");
      lcd.print(i+1);
      lcd.print(" : ");
      lcd.print(tempC1);
      lcd.print((char)176);
      */
      Serial.print("3_");
      Serial.print(tempC2);
      Serial.print("\n");
    }

   // ---------------------------------------------- senzor 4
    
  sensors.requestTemperatures();
  tempC3 = sensors.getTempCByIndex(3);
  

    for (int i = 3;  i < deviceCount;  i++)
    {
      /*
      lcd.setCursor(0,1);
      lcd.print("Sensor ");
      lcd.print(i+1);
      lcd.print(" : ");
      lcd.print(tempC1);
      lcd.print((char)176);
      */
      Serial.print("4_");
      Serial.print(tempC3);
      Serial.print("\n");
    }

    // ---------------------------------------------- senzor 4
    
  sensors.requestTemperatures();
  tempC4 = sensors.getTempCByIndex(4);
  

    for (int i = 4;  i < deviceCount;  i++)
    {
      /*
      lcd.setCursor(0,1);
      lcd.print("Sensor ");
      lcd.print(i+1);
      lcd.print(" : ");
      lcd.print(tempC1);
      lcd.print((char)176);
      */
      Serial.print("5_");
      Serial.print(tempC4);
      Serial.print("\n");
    }

char (data) = Serial.read();
switch (data)
{
case 'a': digitalWrite(8,HIGH);break;
case 'b': digitalWrite(8,LOW);break;

case 'c': digitalWrite(9,HIGH);break;
case 'd': digitalWrite(9,LOW);break;

case 'e': digitalWrite(10,HIGH);break;
case 'f': digitalWrite(10,LOW);break;

case 'g': digitalWrite(11,HIGH);break;
case 'h': digitalWrite(11,LOW);break;

case 'i': digitalWrite(12,HIGH);break;
case 'j': digitalWrite(12,LOW);break;

case 'k': digitalWrite(13,HIGH);break;
case 'l': digitalWrite(13,LOW);break;
}


}
 




  
