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
#define MIDPOINT NUM_LEDS/2
#define CLIP_COUNT 4
#define CLIP_LOWER CLIP_COUNT
#define CLIP_UPPER (NUM_LEDS-CLIP_COUNT)

// Data pin that led data will be written out over
#define DATA_PIN 3


CRGB leds[NUM_LEDS];

int LEDMap_left[MIDPOINT];
int LEDMap_right[MIDPOINT];

void setup() 
{
	for (int i = 0; i < MIDPOINT; i++)
	{
		LEDMap_left[i] = (MIDPOINT - 1) - i;
	}
	for (int i = 0; i < MIDPOINT; i++)
	{
		LEDMap_right[i] = MIDPOINT + i;
	}

  FastLED.addLeds<NEOPIXEL, DATA_PIN>(leds, NUM_LEDS);
  FastLED.setBrightness(3);
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
	float percent_left = (float)level[0]/(float)255;
	int LEDs_left = percent_left * MIDPOINT;

	float percent_right = (float)level[1] / (float)255;
	int LEDs_right = percent_right * MIDPOINT;

	for (int i = 0; i < MIDPOINT; i++)
	{
		if (i >= LEDs_left)
			leds[LEDMap_left[i]] = CRGB(0, 0, 0);
		else
		{
			if (i > MIDPOINT-CLIP_COUNT)
				leds[LEDMap_left[i]] = CRGB(255, 0, 0);
			else
				leds[LEDMap_left[i]] = CRGB(0, 255, 0);
		}

		if (i >= LEDs_right)
			leds[LEDMap_right[i]] = CRGB(0, 0, 0);
		else
		{
			if (i > MIDPOINT - CLIP_COUNT)
				leds[LEDMap_right[i]] = CRGB(255, 0, 0);
			else
				leds[LEDMap_right[i]] = CRGB(0, 255, 0);
		}
	}
  
	// apply 
	FastLED.show();
}