/*************************************************** 
  This is an example sketch for our optical Fingerprint sensor

  Designed specifically to work with the Adafruit BMP085 Breakout 
  ----> http://www.adafruit.com/products/751

  These displays use TTL Serial to communicate, 2 pins are required to 
  interface
  Adafruit invests time and resources providing this open source code, 
  please support Adafruit and open-source hardware by purchasing 
  products from Adafruit!

  Written by Limor Fried/Ladyada for Adafruit Industries.  
  BSD license, all text above must be included in any redistribution
 ****************************************************/


#include <Adafruit_Fingerprint.h>

// On Leonardo/Micro or others with hardware serial, use those! #0 is green wire, #1 is white
// uncomment this line:
// #define mySerial Serial1

// For UNO and others without hardware serial, we must use software serial...
// pin #2 is IN from sensor (GREEN wire)
// pin #3 is OUT from arduino  (WHITE wire)
// comment these two lines if using hardware serial
#include <SoftwareSerial.h>
#include <LiquidCrystal.h>

SoftwareSerial mySerial(3, 2);

const int rs = 12, en = 11, d4 = 10, d5 = 9, d6 = 8, d7 = 7;
LiquidCrystal lcd(rs, en, d4, d5, d6, d7);

Adafruit_Fingerprint finger = Adafruit_Fingerprint(&mySerial);

void setup()  
{
  pinMode(5, OUTPUT);
  pinMode(6, OUTPUT);
  Serial.begin(9600);
  lcd.begin(16, 2);
  while (!Serial);  // For Yun/Leo/Micro/Zero/...
  delay(100);
  //Serial.println("\n\nAdafruit finger detect test");

  // set the data rate for the sensor serial port
  finger.begin(57600);
  
  if (finger.verifyPassword()) 
  {
    delay(5000);
    //Serial.print("Found fingerprint sensor!");
  } 
  else 
  {
    lcd.setCursor(2, 0);
    lcd.print("Did Not Find ");
    lcd.setCursor(5, 1);
    lcd.print("Sensor ");
    
    while (1) 
    { 
      delay(1); 
    }
  }

  finger.getTemplateCount();
  //Serial.print("Sensor contains "); Serial.print(finger.templateCount); Serial.println(" templates");
  
}

void loop()                     // run over and over again
{
  int id = getFingerprintIDez();
  lcd.clear();
  lcd.print("Waiting For");
  lcd.setCursor(1, 1);
  lcd.print("Valid Finger...");
  if (id > 0)
  {
    lcd.clear();
    lcd.setCursor(0, 0);
    lcd.print("Found ID #"); lcd.print(finger.fingerID);    
    digitalWrite(5, HIGH);
    delay(2000);
    digitalWrite(5, LOW);
  }
  else if (id == -3)
  {
    lcd.clear();
    lcd.setCursor(2, 0);
    lcd.print("Finger Not");
    lcd.setCursor(4, 1);
    lcd.print("Recognized ");
    digitalWrite(6, HIGH);
    delay(2000);
    digitalWrite(6, LOW);
  }
  //delay(50);            //don't ned to run this at full speed.
}

uint8_t getFingerprintID() {
  uint8_t p = finger.getImage();
  switch (p) {
    case FINGERPRINT_OK:
    delay(1000);
      Serial.println("Image taken");
      break;
    case FINGERPRINT_NOFINGER:
    delay(1000);
      Serial.println("No finger detected");
      return p;
    case FINGERPRINT_PACKETRECIEVEERR:
    delay(1000);
      Serial.println("Communication error");
      return p;
    case FINGERPRINT_IMAGEFAIL:
    delay(1000);
      Serial.println("Imaging error");
      return p;
    default:
    delay(1000);
      Serial.println("Unknown error");
      return p;
  }

  // OK success!

  p = finger.image2Tz();
  switch (p) {
    case FINGERPRINT_OK:
    delay(1000);
      Serial.println("Image converted");
      break;
    case FINGERPRINT_IMAGEMESS:
    delay(1000);
      Serial.println("Image too messy");
      return p;
    case FINGERPRINT_PACKETRECIEVEERR:
    delay(1000);
      Serial.println("Communication error");
      return p;
    case FINGERPRINT_FEATUREFAIL:
    delay(1000);
      Serial.println("Could not find fingerprint features");
      return p;
    case FINGERPRINT_INVALIDIMAGE:
    delay(1000);
      Serial.println("Could not find fingerprint features");
      return p;
    default:
    delay(1000);
      Serial.println("Unknown error");
      return p;
  }
  
  // OK converted!
  p = finger.fingerFastSearch();
  if (p == FINGERPRINT_OK) {
    delay(1000);
    Serial.println("Found a print match!");
  } else if (p == FINGERPRINT_PACKETRECIEVEERR) {
    delay(1000);
    Serial.println("Communication error");
    return p;
  } else if (p == FINGERPRINT_NOTFOUND) {
    delay(1000);
    Serial.println("Did not find a match");
    return p;
  } else {
    delay(1000);
    Serial.println("Unknown error");
    return p;
  }   
  
  // found a match!
  Serial.print("Found ID #"); Serial.print(finger.fingerID); 
  Serial.print(" with confidence of "); Serial.println(finger.confidence); 

  return finger.fingerID;
}

// returns -1 if failed, otherwise returns ID #
int getFingerprintIDez() 
{
  uint8_t p = finger.getImage();
  if (p != FINGERPRINT_OK)  return -1;

  p = finger.image2Tz();
  if (p != FINGERPRINT_OK)  return -2;

  p = finger.fingerFastSearch();
  if (p != FINGERPRINT_OK)  return -3;
  
  // found a match!
  Serial.println(finger.fingerID); 
  //Serial.println(" with confidence of "); Serial.println(finger.confidence);
  return finger.fingerID; 
}
