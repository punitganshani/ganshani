// Main.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "arduino.h"

#define MICROPHONE A0
#define LED D3
#define THRESHOLD_VALUE 450

void pins_init()
{
	pinMode(LED, OUTPUT);
	pinMode(MICROPHONE, INPUT);
}
void turnOnLED()
{
	digitalWrite(LED, HIGH);
}
void turnOffLED()
{
	digitalWrite(LED, LOW);
}

int _tmain(int argc, _TCHAR* argv[])
{
	return RunArduinoSketch();
}

void setup()
{
	Serial.begin(9600);
	pins_init();
}

void loop()
{
	int sensorValue = analogRead(MICROPHONE);
	Serial.print("sensorValue");
	Serial.println(sensorValue);

	if (sensorValue > THRESHOLD_VALUE)
	{
		Log("OK, got something worth listening\n");
		turnOnLED();
		delay(2000);
	}

	turnOffLED();
}

