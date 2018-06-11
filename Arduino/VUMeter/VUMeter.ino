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


#include <FastLED.h>
#include <stdio.h>
#include <string.h>


#define NUM_LEDS 36

// Data pin that led data will be written out over
#define DATA_PIN 3


CRGB leds[NUM_LEDS];

void setup() 
{
  FastLED.addLeds<NEOPIXEL, DATA_PIN>(leds, NUM_LEDS);
  FastLED.setBrightness(10);
  /* Setup serial */
  Serial.begin(115200);
  updateLEDs();
}

byte level[2] = {0,0};
int count = 0;

void loop() 
{
  
  if (Serial.available()) {
    byte inByte = Serial.read();
    if (inByte == '\r')
    {
      count = 0;

      //char buf [10];
      //sprintf(buf, "%d,%d", level[0], level[1]);
      
    
      //client.publish(MQTTtopic, buf);
      updateLEDs();
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

void updateLEDs()
{
	float percent = (float)level[0]/(float)255;
	int LEDs = percent*NUM_LEDS;

	for (int i = 0; i<LEDs; i++)
	{
		leds[i] = CRGB(0, 255, 0);
	}
  for (int i = LEDs; i<NUM_LEDS; i++)
  {
    leds[i] = CRGB(0, 0, 0);
  }
  


	/* apply */
	FastLED.show();
}
