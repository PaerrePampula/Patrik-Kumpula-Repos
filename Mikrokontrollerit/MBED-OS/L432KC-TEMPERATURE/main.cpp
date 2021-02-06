#include "mbed.h"
#include "Adafruit_SSD1331.h" 
#include "Adafruit_GFX.h" 
Adafruit_SSD1331 OLED(D9, D6, D10, D11, NC, D13); // cs, res, dc, mosi, (nc), sck  

//DigitalOut LED(LED1);     // LED1, LED2, LED3 and LED4 are the D13 PB_3 pin in this board and 
                            //can not be used as a LED because of the SPI
DigitalOut VCCEN(D3);
DigitalOut PMODEN(D5);
AnalogIn tempSensor(A3);
// Definition of colours on the OLED display
#define Black 0x0000
#define Blue 0x001F
#define Red 0xF800
#define Green 0x07E0
#define Cyan 0x07FF
#define Magenta 0xF81F
#define Yellow 0xFFE0
#define White 0xFFFF


int first = 0;
float tempsTotal = 0.0;

void resetSampling()
{
    tempsTotal = 0.0;
}
//Attempt measuring the temperature from the vout. This should be sampled in order to stabilize readings
void doSampling()
{
    resetSampling();
    //Do a 10 sample run
    for (int i = 0; i<10; i++) 
    {
        tempsTotal += tempSensor*3300; //USING A 3.3V
        ThisThread::sleep_for((10ms));
    }    
}
float getTemp()
{
    doSampling();
    float var = (((tempsTotal)/10.0)- 500.0f) / 10.0f;
    float flooredAndRounded = floorf(var*100.0)/100.0;
    return flooredAndRounded;
}
int main()
{
        VCCEN = 1;
        PMODEN = 1;
        OLED.begin(); // initialization of display object
        OLED.clearScreen();   
    while (true) {

        OLED.setTextColor(Cyan); // colour of text in cyan
        ThisThread::sleep_for(300ms);
        OLED.setCursor(0,0); // cursor is in x=0 and y=0
        OLED.clearScreen();
        OLED.printf("Temp %.2lf Celsius\n\r",getTemp());
        ThisThread::sleep_for(100ms);
    }
}

