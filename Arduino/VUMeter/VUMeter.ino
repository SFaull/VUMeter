/* 
 * Author: Sam Faull
 * Details: TeaUp
 *            - master unit has button to be pressed when tea is ready
 *            - All slave units will activate an LED for 10 seconds when they receive confirmation that tea is ready
 * 
 * Pin allocations: 
 * Button - D1
 * LED    - BUILT_IN
 */

#include <ESP8266WiFi.h>
#include <PubSubClient.h>
#include <ESP8266mDNS.h>
#include <WiFiUdp.h>
#include <DNSServer.h>
#include <ESP8266WebServer.h>
#include <ArduinoOTA.h>
#include <WiFiManager.h>
#include <config.h> // this stores the private variables such as wifi ssid and password etc.
#include <stdio.h>
#include <string.h>


/* Physical connections */
#define button        D1               //button on pin D1
#define LED_BUILTIN   D6

/* Timers */
#define INPUT_READ_TIMEOUT     50     //check for button pressed every 50ms
#define TEA_READY_TIMEOUT      10000  // tea alarm active for 10 seconds

WiFiClient espClient;
PubSubClient client(espClient);

const char* deviceName          = "TeaUp_master";
const char* MQTTtopic           = "TeaUp";

unsigned long runTime         = 0,
              teaTimer        = 0,
              readInputTimer  = 0;


// Flags
bool pending_button_press = false; // true if a button press has been registered
bool tea_ready = false;

void setup() 
{
  /* Setup I/O */
  pinMode(LED_BUILTIN, OUTPUT);     // Initialize the BUILTIN_LED pin as an output
  pinMode(button, INPUT_PULLUP);  // Enables the internal pull-up resistor
  //digitalWrite(LED_BUILTIN, HIGH); 
  
  /* Setup serial */
  Serial.begin(115200);
  Serial.flush();
 

  /* Setup WiFi and MQTT */ 
  //Local intialization. Once its business is done, there is no need to keep it around
  WiFiManager wifiManager;
  wifiManager.autoConnect(deviceName);

  client.setServer(MQTTserver, MQTTport);
  client.setCallback(callback);

  initOTA();
}

byte level[2];
int count = 0;

void loop() 
{
  /* Check WiFi Connection */
  if (!client.connected()) 
    reconnect();
  client.loop();
  ArduinoOTA.handle();
  
  if (Serial.available()) {
    byte inByte = Serial.read();
    if (inByte == '\r')
    {
      count = 0;

      char buf [10];
      sprintf(buf, "%d,%d", level[0], level[1]);
      
    
      client.publish(MQTTtopic, buf);
      updateLED();
    }
    else
    {
      if (count < 2)
      {
        level[count] = inByte;
        count++;
      }
      else
        count = 0;
    }
    //char msg[inByte.length()];
    //inByte.toCharArray(msg, inByte.length());
    //int left = (int)msg[0];
    //int right = (int)msg[1];


  }
  
}



void updateLED()
{
  // use level[0] (left) and level[1] (right) to write to a number of LEDs
  analogWrite(LED_BUILTIN,level[0]*4);
}




void callback(char* topic, byte* payload, unsigned int length) 
{
  Serial.print("Message arrived [");
  Serial.print(topic);
  Serial.print("] ");
  
  /* --------------- Print incoming message to serial ------------------ */
  char input[length+1];
  for (int i = 0; i < length; i++) 
    input[i] = (char)payload[i];  // store payload as char array
  input[length] = '\0'; // dont forget to add a termination character
  
  Serial.println(input);    
  
  if(strcmp(input,"Tea")==0)
  {
    Serial.println("Tea Ready");
  }
}

void reconnect() {
  // Loop until we're reconnected
  while (!client.connected()) 
  {
    Serial.print("Attempting MQTT connection... ");
    // Attempt to connect
    if (client.connect(deviceName, MQTTuser, MQTTpassword)) 
    {
      Serial.println("Connected");
      // Once connected, publish an announcement...
      //client.publish("/LampNode/Announcements", "LampNode02 connected");  // potentially not necessary
      // ... and resubscribe
      client.subscribe(MQTTtopic);
    } 
    else 
    {
      Serial.print("failed, rc=");
      Serial.print(client.state());
      Serial.println(" try again in 5 seconds");
      // Wait 5 seconds before retrying
      delay(5000);
    }
  }
}


void initOTA(void)
{
  ArduinoOTA.onStart([]() {
    Serial.println("OTA Update Started");
  });
  ArduinoOTA.onEnd([]() {
    Serial.println("\nOTA Update Complete");
  });
  ArduinoOTA.onProgress([](unsigned int progress, unsigned int total) {
    Serial.printf("Progress: %u%%\r", (progress / (total / 100)));
  });
  ArduinoOTA.onError([](ota_error_t error) {
    Serial.printf("Error[%u]: ", error);
    if (error == OTA_AUTH_ERROR) Serial.println("Auth Failed");
    else if (error == OTA_BEGIN_ERROR) Serial.println("Begin Failed");
    else if (error == OTA_CONNECT_ERROR) Serial.println("Connect Failed");
    else if (error == OTA_RECEIVE_ERROR) Serial.println("Receive Failed");
    else if (error == OTA_END_ERROR) Serial.println("End Failed");
  });
  ArduinoOTA.begin();
}
