using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vue
{
    /// <summary>
    /// Logique d'interaction pour SimulationPassageCarte.xaml
    /// </summary>
    public partial class SimulationPassageCarte : UserControl
    {
        // global declaration
        int hContext;       //card reader context handle
        int hCard;          //card connection handle
        int ActiveProtocol, retcode;
        int Aprotocol, i;
        byte[] rdrlist = new byte[100];
        byte[] array = new byte[256];
        byte[] SendBuff = new byte[262];
        byte[] RecvBuff = new byte[262];
        byte[] tmpArray = new byte[56];
        ModWinsCard.APDURec apdu = new ModWinsCard.APDURec();
        ModWinsCard.SCARD_IO_REQUEST sIO = new ModWinsCard.SCARD_IO_REQUEST();
        int indx, SendBuffLen, RecvBuffLen;
        string tmpStr = "", sTemp;
        byte HiAddr, LoAddr, dataLen;
        bool connActive = false;
        bool cartepresente = false;
        string cdReader;

       

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        MainWindow parent;

        public SimulationPassageCarte(MainWindow m)
        {
            InitializeComponent();
            parent = m;
            string ReaderList = "" + Convert.ToChar(0);
            char[] delimiter = new char[1];
            carteDeconnecter();
            initialise();

        }

        public void initialise()
        {
            byte[] returnData = null;   // Will hold the reader names after the call to SCardListReaders
            int readerCount = 0;        // Total length of the reader names
            //string readerNames = "";    // Will hold the reader names after converting from byte array to a single string.
            //string[] readerList = null; // String array of the Reader Names
           // int idx = 0;

            // Established using ScardEstablishedContext()
            retcode = ModWinsCard.SCardEstablishContext(ModWinsCard.SCARD_SCOPE_USER, 0, 0, ref hContext);
            if (retcode != ModWinsCard.SCARD_S_SUCCESS)
            {
                return;
            }

            // List PC/SC card readers installed in the system

            // Call SCardListReaders to get the total length of the reader names
            retcode = ModWinsCard.SCardListReaders(this.hContext, null, null, ref readerCount);
            if (retcode != ModWinsCard.SCARD_S_SUCCESS)
            {
                return;
            }
            else
            {
                returnData = new byte[readerCount];

                // Call SCardListReaders this time passing the array to hold the return data.
                retcode = ModWinsCard.SCardListReaders(this.hContext, null, returnData, ref readerCount);
                if (retcode != ModWinsCard.SCARD_S_SUCCESS)
                {
                    return;
                }
                else
                {
                    //displayOut(0, 0, "SCardListReaders...OK");

                    // Convert the return data to a string
                    cdReader = System.Text.ASCIIEncoding.ASCII.GetString(returnData);

                    // Parse the string and split the reader names. Delimited by \0.
                    //readerList = readerNames.Split('\0');

                    // Clear the combo list of all items.
                   // cbReader.Items.Clear();

                    // For each string in the array, add them to the combo list
                    /*for (idx = 0; idx < readerList.Length; idx++)
                    {
                        cdReader = readerList[idx];
                    }*/

                    //cbReader.SelectedIndex = 0;
                }
            }
            //btnReset.Enabled = true;
        }

        private void carteConnecter()
        {

            // Connect to selected reader using hContext handle and obtain hCard handle
            if (connActive)
                retcode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD);

            // Connect to the reader using hContext handle and obtain hCard handle  
            retcode = ModWinsCard.SCardConnect(hContext, cdReader, ModWinsCard.SCARD_SHARE_EXCLUSIVE, 0 | 1, ref hCard, ref ActiveProtocol);
            if (retcode != ModWinsCard.SCARD_S_SUCCESS)
            {
                // displayOut(0, 0, "probleme de connexion");
                return;
            }
            else
            {
                connActive = true;
            }

            cartepresente = true;

            format();
            //Pour convertir en string 
           /* string s = "001";
            try
            {
               int i =  Int32.Parse(s);
                
            }
            catch  { }*/
        }


        private void format()
        {
            //Send IC Code
            // displayOut(0, 0, "Submit Code");
            SubmitIC();
            if (retcode != ModWinsCard.SCARD_S_SUCCESS)
                return;

            //Select FF 02
            //displayOut(0, 0, "Select FF 02");
            SelectFile(0xFF, 0x02);
            if (retcode != ModWinsCard.SCARD_S_SUCCESS)
                return;

            /* Write to FF 02
			This will create 3 User files, no Option registers and
			Security Option registers defined, Personalization bit is not set */
            tmpArray[0] = 0x00;      // 00    Option registers
            tmpArray[1] = 0x00;      // 00    Security option register
            tmpArray[2] = 0x03;      // 03    No of user files
            tmpArray[3] = 0x00;      // 00    Personalization bit

            writeRecord(0x00, 0x00, 0x04, 0x04, ref tmpArray);
            if (retcode != ModWinsCard.SCARD_S_SUCCESS)
                return;

            //Select FF 04
            // displayOut(0, 0, "Select FF 04");
            SelectFile(0xFF, 0x04);
            if (retcode != ModWinsCard.SCARD_S_SUCCESS)
                return;

            // Send IC Code
            //displayOut(0, 0, "Submit Code");
            SubmitIC();
            if (retcode != ModWinsCard.SCARD_S_SUCCESS)
                return;

            /* Write to FF 04
			 Write to first record of FF 04 */
            tmpArray[0] = 0x0A;       // 10    Record length
            tmpArray[1] = 0x03;       // 3     No of records
            tmpArray[2] = 0x00;       // 00    Read security attribute
            tmpArray[3] = 0x00;       // 00    Write security attribute
            tmpArray[4] = 0xAA;       // AA    File identifier
            tmpArray[5] = 0x11;       // 11    File identifier
            tmpArray[6] = 0x00;       // 00    File Access Flag Bit

            writeRecord(0x00, 0x00, 0x07, 0x07, ref tmpArray);
            if (retcode != ModWinsCard.SCARD_S_SUCCESS)
                return;

            //displayOut(0, 0, "User File AA 11 is defined");

            //Write to second record of FF 04
            tmpArray[0] = 0x10;         // 16    Record length
            tmpArray[1] = 0x02;         // 2     No of records
            tmpArray[2] = 0x00;         // 00    Read security attribute
            tmpArray[3] = 0x00;         // 00    Write security attribute
            tmpArray[4] = 0xBB;         // BB    File identifier
            tmpArray[5] = 0x22;			// 22    File identifier
            tmpArray[6] = 0x00;         // 00    File Access Flag Bit

            writeRecord(0x00, 0x01, 0x07, 0x07, ref tmpArray);
            if (retcode != ModWinsCard.SCARD_S_SUCCESS)
                return;

            // displayOut(0, 0, "User File BB 22 is defined");

            //Write to third record of FF 04
            tmpArray[0] = 0x20;       // 32    Record length
            tmpArray[1] = 0x04;       // 4     No of records
            tmpArray[2] = 0x00;       // 00    Read security attribute
            tmpArray[3] = 0x00;       // 00    Write security attribute
            tmpArray[4] = 0xCC;       // CC    File identifier
            tmpArray[5] = 0x33;       // 33    File identifier
            tmpArray[6] = 0x00;       // 00    File Access Flag Bit

            writeRecord(0x00, 0x02, 0x07, 0x07, ref tmpArray);
            if (retcode != ModWinsCard.SCARD_S_SUCCESS)
                return;

            //  displayOut(0, 0, "User File CC 33 is defined");

        
        }

        private void SubmitIC()
        {
            //Send IC Code
            apdu.Data = array;

            apdu.bCLA = 0x80;          // CLA
            apdu.bINS = 0x20;          // INS
            apdu.bP1 = 0x07;           // P1
            apdu.bP2 = 0x00;           // P2
            apdu.bP3 = 0x08;           // P3
            apdu.Data[0] = 0x41;       // A
            apdu.Data[1] = 0x43;       // C
            apdu.Data[2] = 0x4F;       // O
            apdu.Data[3] = 0x53;       // S
            apdu.Data[4] = 0x54;       // T
            apdu.Data[5] = 0x45;       // E
            apdu.Data[6] = 0x53;       // S
            apdu.Data[7] = 0x54;       // T
            apdu.IsSend = true;

            PerformTransmitAPDU(ref apdu);
            if (retcode != ModWinsCard.SCARD_S_SUCCESS)
                return;

            if (RecvBuff[0] != 0x90 && RecvBuff[1] != 0x00)
            {
                retcode = -450;
                return;
            }
        }

        private void SelectFile(byte HiAddr, byte LoAddr)
        {
            apdu.Data = array;

            apdu.bCLA = 0x080;       // CLA
            apdu.bINS = 0x0A4;       // INS
            apdu.bP1 = 0x00;         // P1
            apdu.bP2 = 0x00;         // P2
            apdu.bP3 = 0x02;         // P3
            apdu.Data[0] = HiAddr;      // Value of High Byte
            apdu.Data[1] = LoAddr;      // Value of Low Byte
            apdu.IsSend = true;

            PerformTransmitAPDU(ref apdu);
            if (retcode != ModWinsCard.SCARD_S_SUCCESS)
                return;
        }

        private void writeRecord(int caseType, byte RecNo, byte maxLen, byte DataLen, ref byte[] ApduIn)
        {
            if (caseType == 1)    // If card data is to be erased before writing new data. Re-initialize card values to $00
            {
                apdu.bCLA = 0x80;       // CLA
                apdu.bINS = 0xD2;       // INS
                apdu.bP1 = RecNo;       // Record No
                apdu.bP2 = 0x00;        // P2
                apdu.bP3 = maxLen;      // Length of Data
                apdu.IsSend = true;

                for (i = 0; i < maxLen; i++)
                {
                    apdu.Data[i] = ApduIn[i];
                }

                PerformTransmitAPDU(ref apdu);
                if (retcode != ModWinsCard.SCARD_S_SUCCESS)
                    return;

                if (RecvBuff[0] != 0x90 && RecvBuff[1] != 0x00)
                {
                    retcode = -450;
                    return;
                }
            }

            //Write data to card
            apdu.bCLA = 0x80;       // CLA
            apdu.bINS = 0xD2;       // INS
            apdu.bP1 = RecNo;       // Record No
            apdu.bP2 = 0x00;        // P2
            apdu.bP3 = DataLen;     // Length of Data
            apdu.IsSend = true;

            for (i = 0; i < maxLen; i++)
            {
                apdu.Data[i] = ApduIn[i];
            }

            PerformTransmitAPDU(ref apdu);
            if (retcode != ModWinsCard.SCARD_S_SUCCESS)
                return;

            if (RecvBuff[0] != 0x90 && RecvBuff[1] != 0x00)
            {
                retcode = -450;
                return;
            }
        }

        private void PerformTransmitAPDU(ref ModWinsCard.APDURec apdu)
        {
            ModWinsCard.SCARD_IO_REQUEST SendRequest;
            ModWinsCard.SCARD_IO_REQUEST RecvRequest;

            SendBuff[0] = apdu.bCLA;
            SendBuff[1] = apdu.bINS;
            SendBuff[2] = apdu.bP1;
            SendBuff[3] = apdu.bP2;
            SendBuff[4] = apdu.bP3;

            if (apdu.IsSend)
            {
                for (indx = 0; indx < apdu.bP3; indx++)
                {
                    SendBuff[5 + indx] = apdu.Data[indx];
                }

                SendBuffLen = 5 + apdu.bP3;
                RecvBuffLen = 2;
            }
            else
            {
                SendBuffLen = 5;
                RecvBuffLen = 2 + apdu.bP3;
            }

            SendRequest.dwProtocol = Aprotocol;
            SendRequest.cbPciLength = 8;

            RecvRequest.dwProtocol = Aprotocol;
            RecvRequest.cbPciLength = 8;

            retcode = ModWinsCard.SCardTransmit(hCard, ref SendRequest, ref SendBuff[0], SendBuffLen, ref SendRequest, ref RecvBuff[0], ref RecvBuffLen);
            if (retcode != ModWinsCard.SCARD_S_SUCCESS)
            {
                return;
            }

            sTemp = "";
            // do loop for sendbuffLen
            for (indx = 0; indx < SendBuffLen; indx++)
            {
                sTemp = sTemp + " " + string.Format("{0:X2}", SendBuff[indx]);
            }

            // Display Send Buffer Value
            //displayOut(2, 0, sTemp); 

            sTemp = "";
            // do loop for RecvbuffLen
            for (indx = 0; indx < RecvBuffLen; indx++)
            {
                sTemp = sTemp + " " + string.Format("{0:X2}", RecvBuff[indx]);
            }

            // Display Receive Buffer Value
            // displayOut(3, 0, sTemp);

            if (apdu.IsSend == false)
            {
                for (indx = 0; indx < apdu.bP3 + 2; indx++)
                {
                    apdu.Data[indx] = RecvBuff[indx];
                }
            }
        }

        public void read()
        {
            int indx;

            // Check User File selected by user
         
                HiAddr = 0xAA;
                LoAddr = 0x11;
                dataLen = 0x0A;
            

            /*if (RBBB22.Checked == true)
            {
                HiAddr = 0xBB;
                LoAddr = 0x22;
                dataLen = 0x10;
            }

            if (RBCC33.Checked == true)
            {
                HiAddr = 0xCC;
                LoAddr = 0x33;
                dataLen = 0x20;
            }*/

            // Select User File
            SelectFile(HiAddr, LoAddr);
            if (retcode != ModWinsCard.SCARD_S_SUCCESS)
                return ;

            // Read First Record of User File selected
            readRecord(0x00, dataLen);
            if (retcode != ModWinsCard.SCARD_S_SUCCESS)
                return ;

            // Display data read from card to textbox
            tmpStr = "";
            indx = 0;

            while (RecvBuff[indx] != 0x00)
            {
                if (indx < 10)
                {
                    tmpStr = tmpStr + Chr(RecvBuff[indx]);
                }
                indx = indx + 1;
            }
           
        }

        private void carteDeconnecter()
        {

            retcode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD);
            cartepresente = false;
 

        }

        Char Chr(int i)
		{
			//Return the character of the given character value
			return Convert.ToChar(i);
		}

        private void readRecord(byte RecNo, byte dataLen)
        {
            apdu.Data = array;

            // Read data from card
            apdu.bCLA = 0x80;        // CLA
            apdu.bINS = 0xB2;         // INS
            apdu.bP1 = RecNo;        // Record No
            apdu.bP2 = 0x00;         // P2
            apdu.bP3 = dataLen;      // Length of Data
            apdu.IsSend = false;

            PerformTransmitAPDU(ref apdu);
            if (retcode != ModWinsCard.SCARD_S_SUCCESS)
                return;
        }


        private void clickOK(object sender, RoutedEventArgs e)
        {
            carteConnecter();
            read();

            if (parent.self.findUsager(tmpStr))
            {
                parent.setUC(new Caisse(parent));
            }else
            {
                MessageBox.Show("Pas de client trouvé avec ce numéro de carte");
            }
        }
    }
}
