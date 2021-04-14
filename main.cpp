#include <stdio.h>
#define DEBUG

const int Debug = 0;

union CharInt_converter
{
    unsigned char tChar[4]; ///< four chars
    unsigned int  tInt;     ///< 4-byte integer number
} Conv; ///< union to convert 
#include "CData.cpp"



int main()
{
    FILE *fdata;
    char name[200] = "./data/SIPMZynq_v1_192.168.1.200.bin";
    //unsigned int  inw;

    if((fdata = fopen(name, "rb")) == NULL)
    {
        printf("Error in file %s opening!\n\n", name);
        return 1;
    }

    CData data(fdata);

    data.read_header();
    data.print_header(stdout);
    data.get_event();
    data.print_event(stdout);

    fclose(fdata);
}
