void commands_init() 
{                         
  // Setup callbacks for SerialCommand commands
  // Max length of command is SERIALCOMMAND_MAXCOMMANDLENGTH 8
  // Max length of command line is SERIALCOMMAND_BUFFER 32
  
  // Common Commands
  sCmd.addCommand("*IDN?",            command_idn);

  // Control Commands
  sCmd.addCommand("INIT",             command_init);  // TODO
  sCmd.addCommand("SET:LED:INDEX",    command_set_led);
  sCmd.addCommand("SET:LED:RANGE",    command_set_led_range);
  
  sCmd.setDefaultHandler(unrecognized);      // Handler for command that isn't matched  (says "What?")

}

// This gets set as the default handler, and gets called when no other command matches.
void unrecognized(const char *command) {
  Serial.println("What?");
}

// Returns standard *IDN response
void command_idn() 
{
  // TODO
}

void command_init() 
{
  FastLED.addLeds<NEOPIXEL, DATA_PIN>(leds, NUM_LEDS);
  FastLED.setBrightness(10);
  /*
  char *arg;
  unsigned int index;
    
  arg = sCmd.next();    // Get the next argument from the SerialCommand object buffer
  if (arg != NULL) 
  { 
    index = atoi(arg);
    {
      
    }
  }
  */

    for(int i = 0; i<NUM_LEDS; i++)
      leds[i] = CRGB(0, 0, 0);

  FastLED.show();
}


void command_set_led() 
{
  const int ARG_COUNT = 4;
  char *arg[ARG_COUNT]; // expecting 4 args
 
  uint8_t index, r, g, b;

  for(int i = 0; i<ARG_COUNT; i++)
  {
    arg[i] = sCmd.next();
    if(arg[i] == NULL)
      return; // escape
  }

  index = atoi(arg[0]);
  r = atoi(arg[1]);
  g = atoi(arg[2]);
  b = atoi(arg[3]);

  if (index >= NUM_LEDS || r > 255 || g > 255 || b > 255)
    return;
      
  // todo specify colour
  leds[index] = CRGB(r, g, b);
  FastLED.show();
}

void command_set_led_range() 
{
  const int ARG_COUNT = 5;
  char *arg[ARG_COUNT]; // expecting 4 args
 
  uint8_t index_start, index_end, r, g, b;

  for(int i = 0; i<ARG_COUNT; i++)
  {
    arg[i] = sCmd.next();
    if(arg[i] == NULL)
      return; // escape
  }

  index_start = atoi(arg[0]);
  index_end = atoi(arg[1]);
  r = atoi(arg[2]);
  g = atoi(arg[3]);
  b = atoi(arg[4]);

  // check values are valid
  if (index_start >= NUM_LEDS || index_end >= NUM_LEDS || index_start > index_end || r > 255 || g > 255 || b > 255)
    return;
      
  // todo specify colour
  for(int i = index_start; i <= index_end; i++)
    leds[i] = CRGB(r, g, b);

  FastLED.show();
}
