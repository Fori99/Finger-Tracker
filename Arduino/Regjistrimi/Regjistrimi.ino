#include <Adafruit_Fingerprint.h>
#include <SoftwareSerial.h>
#include <LiquidCrystal.h>
SoftwareSerial mySerial(3, 2);

const int rs = 12, en = 11, d4 = 10, d5 = 9, d6 = 8, d7 = 7;
LiquidCrystal lcd(rs, en, d4, d5, d6, d7);

Adafruit_Fingerprint finger = Adafruit_Fingerprint(&mySerial);

uint8_t id;
bool rei;

void setup()  
{
  Serial.begin(9600);
  lcd.begin(16,2);
  while (!Serial);  // For Yun/Leo/Micro/Zero/...
  delay(100);
  //Serial.println("\n\nAdafruit Fingerprint sensor enrollment");

  // set the data rate for the sensor serial port
  finger.begin(57600);
  
  if (finger.verifyPassword()) 
  {
    //delay(5000);
    //lcd.print("Found fingerprint sensor!");
  } 
  else 
  {    
    lcd.setCursor(2, 0);
    lcd.print("Did Not Find ");
    lcd.setCursor(5, 1);
    lcd.print("Sensor ");
    while (1) { delay(1); }
  }
    
  // Try to get the templates for fingers 1 through 10
  for (int finger = 1; finger < 127; finger++) 
  {
    downloadFingerprintTemplate(finger);
        
    //if (rei == true)
    //{
      //Serial.println("");
      //break;
    //}
  }
}

uint8_t readnumber(void) 
{
  uint8_t num = 0;
  
  while (num == 0) 
  {
    while (! Serial.available());
    num = Serial.parseInt();
  }
  return num;
}


uint8_t downloadFingerprintTemplate(uint16_t id)
{
  //Serial.println("------------------------------------");
  //Serial.print("Attempting to load #"); Serial.println(id);
  uint8_t p = finger.loadModel(id);
  
  switch (p) 
  {
    case FINGERPRINT_OK:
      //Serial.print("Template "); Serial.print(id); Serial.println(" loaded");
      break;
      
    case FINGERPRINT_PACKETRECIEVEERR:
      lcd.print("Communication error");
      return p;
      
    default:      
      //lcd.print("Enrolling ID #");
      //lcd.print(id);
      rei = true ;
      
      while (!  getFingerprintEnroll(id) ); 
      return rei;            
  }
}

void loop()                     
{  
}

uint8_t getFingerprintEnroll(uint16_t id) 
{
  int p = -1;
  lcd.clear();
  lcd.setCursor(2, 0);  
  lcd.print("Waiting For ");
  lcd.setCursor(0, 1);
  lcd.print("Finger To Enroll..."); 
  //Serial.print("Waiting for finger to enroll..."); Serial.println(id);
  
  while (p != FINGERPRINT_OK) 
  {
    p = finger.getImage();    
    switch (p) 
    {
    case FINGERPRINT_OK:
      lcd.clear();
      lcd.setCursor(2, 0); 
      lcd.print("Image Taken");
      break;
      
    case FINGERPRINT_NOFINGER:
      //Serial.println(".");
      break;
      
    case FINGERPRINT_PACKETRECIEVEERR:
      lcd.clear();
      lcd.setCursor(4, 0); 
      lcd.print("Error");
      //Serial.println("Communication error");
      break;
      
    case FINGERPRINT_IMAGEFAIL:
      lcd.clear();
      lcd.setCursor(4, 0); 
      lcd.print("Error");
      //Serial.println("Imaging error");
      break;
      
    default:
      lcd.clear();
      lcd.setCursor(4, 0); 
      lcd.print("Error");
      //Serial.println("Unknown error");
      break;
    }
  }

  // OK success!
  p = finger.image2Tz(1);  
  switch (p) 
  {
    case FINGERPRINT_OK:
      lcd.clear();
      lcd.setCursor(0, 0); 
      lcd.print("Image Converted");
      //Serial.println("Image converted");
      break;
      
    case FINGERPRINT_IMAGEMESS:
      lcd.clear();
      lcd.setCursor(4, 0); 
      lcd.print("Error");
      //Serial.println("Image too messy");
      return p;
      
    case FINGERPRINT_PACKETRECIEVEERR:
      lcd.clear();
      lcd.setCursor(4, 0); 
      lcd.print("Error");
      //Serial.println("Communication error");
      return p;
      
    case FINGERPRINT_FEATUREFAIL:
      lcd.clear();
      lcd.setCursor(4, 0); 
      lcd.print("Error");
      //Serial.println("Could not find fingerprint features");
      return p;
      
    case FINGERPRINT_INVALIDIMAGE:
      lcd.clear();
      lcd.setCursor(4, 0); 
      lcd.print("Error");
      //Serial.println("Could not find fingerprint features");
      return p;
      
    default:
      lcd.clear();
      lcd.setCursor(4, 0); 
      lcd.print("Error");
      //Serial.println("Unknown error");
      return p;
  }

  lcd.clear();
  lcd.setCursor(1, 0); 
  lcd.print("Remove Finger");
  //Serial.println("Remove finger");
  delay(2000);
  
  p = 0;
  while (p != FINGERPRINT_NOFINGER) 
  {
    p = finger.getImage();
  }
  Serial.print("ID : "); Serial.println(id);
  p = -1;
  lcd.clear();
  lcd.setCursor(3, 0); 
  lcd.print("Place Same");
  lcd.setCursor(2, 1); 
  lcd.print("Finger Again");
  //Serial.println("Place same finger again");
  
  while (p != FINGERPRINT_OK) 
  {
    p = finger.getImage();
    switch (p) 
    {      
    case FINGERPRINT_OK:
      //Serial.println("Image taken");
      lcd.clear();
      lcd.setCursor(2, 0); 
      lcd.print("Image Taken");
      break;
      
    case FINGERPRINT_NOFINGER:
      //Serial.print(".");
      break;
      
    case FINGERPRINT_PACKETRECIEVEERR:
      //Serial.println("Communication error");
      lcd.clear();
      lcd.setCursor(4, 0); 
      lcd.print("Error");
      break;
      
    case FINGERPRINT_IMAGEFAIL:
      //Serial.println("Imaging error");
      lcd.clear();
      lcd.setCursor(4, 0); 
      lcd.print("Error");
      break;
      
    default:
      //Serial.println("Unknown error");
      lcd.clear();
      lcd.setCursor(4, 0); 
      lcd.print("Error");
      break;
    }
  }

  // OK success!
  p = finger.image2Tz(2);  
  switch (p) 
  {
    case FINGERPRINT_OK:
      //Serial.println("Image converted");
      lcd.clear();
      lcd.setCursor(0, 0); 
      lcd.print("Image Converted");
      break;
      
    case FINGERPRINT_IMAGEMESS:
      //Serial.println("Image too messy");
      lcd.clear();
      lcd.setCursor(4, 0); 
      lcd.print("Error");
      return p;
      
    case FINGERPRINT_PACKETRECIEVEERR:
      //Serial.println("Communication error");
      lcd.clear();
      lcd.setCursor(4, 0); 
      lcd.print("Error");
      return p;
      
    case FINGERPRINT_FEATUREFAIL:
      //Serial.println("Could not find fingerprint features");
      lcd.clear();
      lcd.setCursor(4, 0); 
      lcd.print("Error");
      return p;
      
    case FINGERPRINT_INVALIDIMAGE:
      //Serial.println("Could not find fingerprint features");
      lcd.clear();
      lcd.setCursor(4, 0); 
      lcd.print("Error");
      return p;
      
    default:
      //Serial.println("Unknown error");
      lcd.clear();
      lcd.setCursor(4, 0); 
      lcd.print("Error");
      return p;
  }
  
  // OK converted!
  Serial.print("Creating model for #");  Serial.println(id);
  
  p = finger.createModel();
  
  if (p == FINGERPRINT_OK) 
  {
    Serial.println("Prints matched!");
    lcd.clear();
    lcd.setCursor(1, 0); 
    lcd.print("Prints matched");
    delay(2000);
  }   
  else if (p == FINGERPRINT_PACKETRECIEVEERR) 
  {
    //Serial.println("Communication error");
    lcd.clear();
    lcd.setCursor(4, 0); 
    lcd.print("Error");
    return p;
  }   
  else if (p == FINGERPRINT_ENROLLMISMATCH) 
  {
    Serial.println("Fingerprints did not match");
    lcd.clear();
    lcd.setCursor(1, 0); 
    lcd.print("Fingerprints");
    lcd.setCursor(2,1);
    lcd.print("Did Not Match");
    delay(2000);
    return p;
  }   
  else 
  {
    //Serial.println("Unknown error");
    lcd.clear();
    lcd.setCursor(4, 0); 
    lcd.print("Error");
    return p;
  }   

  Serial.print("ID : "); Serial.println(id);
  lcd.clear();
  lcd.setCursor(5, 0); 
  lcd.print("ID : "); lcd.print(id);
  delay(2000);
  p = finger.storeModel(id);
  
  if (p == FINGERPRINT_OK) 
  {
    Serial.println("Stored!");
    lcd.clear();
    lcd.setCursor(5, 0); 
    lcd.print("Stored");
    for(;;);
  }   
  else if (p == FINGERPRINT_PACKETRECIEVEERR) 
  {
    //Serial.println("Communication error");
    lcd.clear();
    lcd.setCursor(4, 0); 
    lcd.print("Error");
    return p;
  }   
  else if (p == FINGERPRINT_BADLOCATION) 
  {    
    //Serial.println("Could not store in that location");
    lcd.clear();
    lcd.setCursor(4, 0); 
    lcd.print("Error");
    return p;
  }   
  else if (p == FINGERPRINT_FLASHERR) 
  {    
    //Serial.println("Error writing to flash");
    lcd.clear();
    lcd.setCursor(4, 0); 
    lcd.print("Error");
    return p;
  }   
  else 
  {    
    //Serial.println("Unknown error");
    lcd.clear();
    lcd.setCursor(4, 0); 
    lcd.print("Error");
    return p;
  }   
}
