

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
#include <SerialCommand.h>

// Data pin that led data will be written out over
#define DATA_PIN 3
#define NUM_LEDS 50

CRGB leds[NUM_LEDS];
SerialCommand sCmd;     // The demo SerialCommand object

void setup() 
{
  Serial.begin(115200);
  commands_init();


}

void loop() 
{
  sCmd.readSerial();     // process serial commands
}
