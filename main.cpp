#include <stdio.h>
#define DEBUG

const int Debug = 1;

union CharInt_converter
{
    unsigned char tChar[4]; ///< four chars
    unsigned int  tInt;     ///< 4-byte integer number
} Conv; ///< union to convert 
#include "CData.cpp"



int main()
{
    FILE *fdata;
    FILE *fout;
    //char name[200] = "./data/SIPMZynq_v1_192.168.1.200.bin";
    char name[200] = "02061001.001";
    char nameout[200] = "SIPMZynq_v1_192.168.1.200.txt";
    //unsigned int  inw;

    strcpy(nameout, name);
    strcat(nameout, ".txt");


    if((fdata = fopen(name, "rb")) == NULL)
    {
        printf("Error in file %s opening!\n\n", name);
        return 1;
    }
    if((fout = fopen(nameout, "wt")) == NULL)
    {
        printf("Error in file %s opening!\n\n", nameout);
        return 2;
    }


    CData data(fdata);

    data.read_header();
    data.print_header(stdout);
    data.print_header(fout);
    data.read_event();
    data.print_event(fout);

    fclose(fdata);
    fclose(fout);
}
