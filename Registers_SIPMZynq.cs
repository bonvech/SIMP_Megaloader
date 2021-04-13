using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace RemoteXilUpdate
{
    public partial class Form1
    {

        /******************* Registers Programming*******************/
        private void RegistersInit_SIPMZynq()
        {
            int num;

			////**************************** ADC Config *********************************//
			num = XilWriteReg(0x200018, 0x2810); // пишем во все АЦП одновременно (Reg 0x28)
            num = XilWriteReg(0x20001A, 0x8100); // Bit-wise
            Thread.Sleep(10);
            num = XilWriteReg(0x200018, 0x4610); // пишем во все АЦП одновременно (Reg 0x46)
            num = XilWriteReg(0x20001A, 0x8201); // Enable Reg, 12 bit, two-wire
			Thread.Sleep(10);
            num = XilWriteReg(0x200018, 0x4210); // пишем во все АЦП одновременно (Reg 0x42)
            num = XilWriteReg(0x20001A, 0x8000); // LCLK Phase
            Thread.Sleep(10);

            num = XilWriteReg(0x200028, 0x1);   // 50 MHz (0 - 100MHz, 1 - 50 MHz, 2 - 33 MHz, 3 - 25 MHz, 4 - 20 MHz)
			////************************************************************************//


            num = XilWriteReg(0x90028, 0); // Сглаживание Channel 0
            num = XilWriteReg(0x98028, 0); // Сглаживание Channel 2

            num = XilWriteReg(0xb0028, 0); // Сглаживание Channel 4
            num = XilWriteReg(0xb8028, 0); // Сглаживание Channel 6

            num = XilWriteReg(0xd0028, 0); // Сглаживание Channel 8
            num = XilWriteReg(0xd8028, 0); // Сглаживание Channel A

            //*********** Смещение данных ***********//
            num = XilWriteReg(0x90040, 0); // Data Offset Channel 0
            num = XilWriteReg(0x90042, 0); // Data Offset Channel 1
            num = XilWriteReg(0x98040, 0); // Data Offset Channel 2
            num = XilWriteReg(0x98042, 0); // Data Offset Channel 3

            num = XilWriteReg(0xb0040, 0); // Data Offset Channel 4
            num = XilWriteReg(0xb0042, 0); // Data Offset Channel 5
            num = XilWriteReg(0xb8040, 0); // Data Offset Channel 6
            num = XilWriteReg(0xb8042, 0); // Data Offset Channel 7

            num = XilWriteReg(0xd0040, 0); // Data Offset Channel 8
            num = XilWriteReg(0xd0042, 0); // Data Offset Channel 9
            num = XilWriteReg(0xd8040, 0); // Data Offset Channel A
            num = XilWriteReg(0xd8042, 0); // Data Offset Channel B

            //*********** Длина данных ***********//
            //num = XilWriteReg(0x90044, 4); // Data Length Channel 0
            //num = XilWriteReg(0x90046, 4); // Data Length Channel 1
            //num = XilWriteReg(0x98044, 4); // Data Length Channel 2
            //num = XilWriteReg(0x98046, 4); // Data Length Channel 3

            //num = XilWriteReg(0xb0044, 4); // Data Length Channel 4
            //num = XilWriteReg(0xb0046, 4); // Data Length Channel 5
            //num = XilWriteReg(0xb8044, 4); // Data Length Channel 6
            //num = XilWriteReg(0xb8046, 4); // Data Length Channel 7

            //num = XilWriteReg(0xd0044, 4); // Data Length Channel 8
            //num = XilWriteReg(0xd0046, 4); // Data Length Channel 9
            //num = XilWriteReg(0xd8044, 4); // Data Length Channel A
            //num = XilWriteReg(0xd8046, 4); // Data Length Channel B

            num = XilWriteReg(0x90044, 2048); // Data Length Channel 0
            num = XilWriteReg(0x90046, 2048); // Data Length Channel 1
            num = XilWriteReg(0x98044, 2048); // Data Length Channel 2
            num = XilWriteReg(0x98046, 2048); // Data Length Channel 3

            num = XilWriteReg(0xb0044, 2048); // Data Length Channel 4
            num = XilWriteReg(0xb0046, 2048); // Data Length Channel 5
            num = XilWriteReg(0xb8044, 2048); // Data Length Channel 6
            num = XilWriteReg(0xb8046, 2048); // Data Length Channel 7

            num = XilWriteReg(0xd0044, 2048); // Data Length Channel 8
            num = XilWriteReg(0xd0046, 2048); // Data Length Channel 9
            num = XilWriteReg(0xd8044, 2048); // Data Length Channel A
            num = XilWriteReg(0xd8046, 2048); // Data Length Channel B

			//num = XilWriteReg(0x9000e, 100); // Stop Delay
			//num = XilWriteReg(0x9800e, 100); // Stop Delay
			//num = XilWriteReg(0xb000e, 100); // Stop Delay
			//num = XilWriteReg(0xb800e, 100); // Stop Delay
			//num = XilWriteReg(0xd000e, 100); // Stop Delay
			//num = XilWriteReg(0xd800e, 100); // Stop Delay

			//num = XilWriteReg(0x9000e, 0); // Stop Delay
			//num = XilWriteReg(0x9800e, 0); // Stop Delay
			//num = XilWriteReg(0xb000e, 0); // Stop Delay
			//num = XilWriteReg(0xb800e, 0); // Stop Delay
			//num = XilWriteReg(0xd000e, 0); // Stop Delay
			//num = XilWriteReg(0xd800e, 0); // Stop Delay

			//*********** Пороги ***********//
            uint thrL = 2148;
            uint thrH = 2158;

			num = XilWriteReg(0x90010, thrL); // Threshold 0 L
			num = XilWriteReg(0x90014, thrL); // Threshold 1 L
			num = XilWriteReg(0x90020, thrH); // Threshold 0 H
			num = XilWriteReg(0x90024, thrH); // Threshold 1 H
			num = XilWriteReg(0x98010, thrL); // Threshold 2 L
			num = XilWriteReg(0x98014, thrL); // Threshold 3 L
			num = XilWriteReg(0x98020, thrH); // Threshold 2 H
			num = XilWriteReg(0x98024, thrH); // Threshold 3 H

			num = XilWriteReg(0xb0010, thrL); // Threshold 4 L
			num = XilWriteReg(0xb0014, thrL); // Threshold 5 L
			num = XilWriteReg(0xb0020, thrH); // Threshold 4 H
			num = XilWriteReg(0xb0024, thrH); // Threshold 5 H
			num = XilWriteReg(0xb8010, thrL); // Threshold 6 L
			num = XilWriteReg(0xb8014, thrL); // Threshold 7 L
			num = XilWriteReg(0xb8020, thrH); // Threshold 6 H
			num = XilWriteReg(0xb8024, thrH); // Threshold 7 H

			num = XilWriteReg(0xd0010, thrL); // Threshold 8 L
			num = XilWriteReg(0xd0014, thrL); // Threshold 9 L
			num = XilWriteReg(0xd0020, thrH); // Threshold 8 H
			num = XilWriteReg(0xd0024, thrH); // Threshold 9 H
			num = XilWriteReg(0xd8010, thrL); // Threshold A L
			num = XilWriteReg(0xd8014, thrL); // Threshold B L
			num = XilWriteReg(0xd8020, thrH); // Threshold A H
			num = XilWriteReg(0xd8024, thrH); // Threshold B H
            //***********************//

			//num = XilWriteReg(0x20000C, 0xffff); //маска каналов
			//num = XilWriteReg(0x20000D, 0xffff); //маска каналов

			num = XilWriteReg(0x20000C, 0x80); //маска каналов
			num = XilWriteReg(0x20000D, 0x0); //маска каналов

            //num = XilWriteReg(0x200006, 0x101); // кратность совпадений и внешнее подтверждение
            //			num = XilWriteReg(0x200006, 0x301); // кратность совпадений и OPTICAL подтверждение
                      num = XilWriteReg(0x200006, 0x1); // кратность совпадений и внутреннее подтверждение

            num = XilWriteReg(0x20000a, 25); // окно совпадений
            
			//for (uint j = 0; j < 12; j++)
			//{
			//    num = XilWriteReg(0x200050 + j * 2, (uint)(1 << (int)j)); // матрица совпадений
			//}

            num = XilWriteReg(0x200206, 0x0); // Request Delay

            num = XilWriteReg(0x200020, 0x1); // DMA enable  //// !!!!!!!!!!!!!!!!!!!!
            num = XilWriteReg(0x200200, 0x1); // Trigger Enable


//            while (true)
//            {
//                //XilWriteReg(0x200004 + 0x30, 0x1);// start soft trigger

////                num = XilWriteReg(0x200000 + 24, 0x4610); // пишем во все АЦП одновременно (Reg 0x46)
////                num = XilWriteReg(0x200000 + 26, 0x8201); // Enable Reg, 12 bit, two-wire


//                //num = XilWriteReg(0x200000 + 24, 0xa510); // пишем во все АЦП одновременно (Reg 0x46)
//                //num = XilWriteReg(0x200000 + 26, 0x8201); // Enable Reg, 12 bit, two-wire
                
//                Thread.Sleep(100);
//                Application.DoEvents();
//            }


        }

        /*******************************************************/
    }

}