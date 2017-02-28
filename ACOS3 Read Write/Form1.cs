/*============================================================================================
'   Author :  Mary Anne C.A. Arana
'   Module :  ModWinscard.cs
'   Company:  Advanced Card Systems Ltd.
'   Date   :  July 11, 2005
'
'   Revision: (Date /Author/Description)
'             (06/23/2008/ Daryl M. Rojas / Added File Access Flag Bit to FF 04)
'             (04/19/2010/ Gil Bagaporo   / Standardized UI.
'                                         / Fixed error 69-81 when reading AA-11
'
'=============================================================================================*/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;

namespace ACOSReadWrite
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{

		// global declaration
		int hContext;		//card reader context handle
		int hCard;			//card connection handle
		int ActiveProtocol, retcode;
        int Aprotocol, i;
		byte[] rdrlist = new byte [100];				
		byte[] array = new byte[256]; 
		byte[] SendBuff = new byte[262];
		byte[] RecvBuff = new byte[262];
		byte[] tmpArray =  new byte[56];		
		ModWinsCard.APDURec apdu  = new ModWinsCard.APDURec();			
		ModWinsCard.SCARD_IO_REQUEST sIO = new ModWinsCard.SCARD_IO_REQUEST(); 
		int indx, SendBuffLen, RecvBuffLen;
        string tmpStr, sTemp; 		
		byte HiAddr, LoAddr, dataLen; 		
        bool connActive = false;
        bool cartepresente = false;

		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TextBox txtData;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.Button btnWrite;
		internal System.Windows.Forms.Button btnRead;
		internal System.Windows.Forms.GroupBox GBUserFile;
		internal System.Windows.Forms.RadioButton RBBB22;
		internal System.Windows.Forms.RadioButton RBAA11;
		internal System.Windows.Forms.RadioButton RBCC33;
		internal System.Windows.Forms.Button btnExit;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Button btnClear;
		internal System.Windows.Forms.Button btnConnect;
        internal System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.Button btnReaderPort;
        private ComboBox cbReader;
        internal Label labelApduLogs;
        private RichTextBox richTextBoxLogs;
        private Button btnFormat;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			string ReaderList = ""+Convert.ToChar(0);
			char[] delimiter = new char[1];
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Label3 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.GBUserFile = new System.Windows.Forms.GroupBox();
            this.RBBB22 = new System.Windows.Forms.RadioButton();
            this.RBAA11 = new System.Windows.Forms.RadioButton();
            this.RBCC33 = new System.Windows.Forms.RadioButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnReaderPort = new System.Windows.Forms.Button();
            this.cbReader = new System.Windows.Forms.ComboBox();
            this.labelApduLogs = new System.Windows.Forms.Label();
            this.richTextBoxLogs = new System.Windows.Forms.RichTextBox();
            this.btnFormat = new System.Windows.Forms.Button();
            this.GroupBox2.SuspendLayout();
            this.GBUserFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(12, 240);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(144, 23);
            this.Label3.TabIndex = 32;
            this.Label3.Text = "String Value in Data";
            // 
            // txtData
            // 
            this.txtData.Enabled = false;
            this.txtData.Location = new System.Drawing.Point(12, 264);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(275, 23);
            this.txtData.TabIndex = 31;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.btnWrite);
            this.GroupBox2.Controls.Add(this.btnRead);
            this.GroupBox2.Enabled = false;
            this.GroupBox2.Location = new System.Drawing.Point(136, 122);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(151, 96);
            this.GroupBox2.TabIndex = 30;
            this.GroupBox2.TabStop = false;
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(24, 56);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(104, 24);
            this.btnWrite.TabIndex = 1;
            this.btnWrite.Text = "Write";
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(24, 24);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(104, 24);
            this.btnRead.TabIndex = 0;
            this.btnRead.Text = "Read";
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // GBUserFile
            // 
            this.GBUserFile.Controls.Add(this.RBBB22);
            this.GBUserFile.Controls.Add(this.RBAA11);
            this.GBUserFile.Controls.Add(this.RBCC33);
            this.GBUserFile.Enabled = false;
            this.GBUserFile.Location = new System.Drawing.Point(12, 122);
            this.GBUserFile.Name = "GBUserFile";
            this.GBUserFile.Size = new System.Drawing.Size(115, 96);
            this.GBUserFile.TabIndex = 29;
            this.GBUserFile.TabStop = false;
            this.GBUserFile.Text = "User File";
            // 
            // RBBB22
            // 
            this.RBBB22.Location = new System.Drawing.Point(21, 44);
            this.RBBB22.Name = "RBBB22";
            this.RBBB22.Size = new System.Drawing.Size(75, 18);
            this.RBBB22.TabIndex = 1;
            this.RBBB22.Text = "BB 22";
            this.RBBB22.CheckedChanged += new System.EventHandler(this.RBBB22_CheckedChanged);
            this.RBBB22.Click += new System.EventHandler(this.RBBB22_Click);
            // 
            // RBAA11
            // 
            this.RBAA11.Location = new System.Drawing.Point(21, 21);
            this.RBAA11.Name = "RBAA11";
            this.RBAA11.Size = new System.Drawing.Size(75, 17);
            this.RBAA11.TabIndex = 0;
            this.RBAA11.Text = "AA 11";
            this.RBAA11.CheckedChanged += new System.EventHandler(this.RBAA11_CheckedChanged);
            this.RBAA11.Click += new System.EventHandler(this.RBAA11_Click);
            // 
            // RBCC33
            // 
            this.RBCC33.Location = new System.Drawing.Point(21, 64);
            this.RBCC33.Name = "RBCC33";
            this.RBCC33.Size = new System.Drawing.Size(75, 26);
            this.RBCC33.TabIndex = 19;
            this.RBCC33.Text = "CC 33";
            this.RBCC33.CheckedChanged += new System.EventHandler(this.RBCC33_CheckedChanged);
            this.RBCC33.Click += new System.EventHandler(this.RBCC33_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(541, 295);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 24);
            this.btnExit.TabIndex = 35;
            this.btnExit.Text = "Quit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(12, 9);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(115, 16);
            this.Label2.TabIndex = 26;
            this.Label2.Text = "Select Reader";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(305, 295);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(112, 24);
            this.btnClear.TabIndex = 33;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Enabled = false;
            this.btnConnect.Location = new System.Drawing.Point(175, 62);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(112, 24);
            this.btnConnect.TabIndex = 27;
            this.btnConnect.Text = "Disconnect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(423, 295);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(112, 24);
            this.btnReset.TabIndex = 34;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnReaderPort
            // 
            this.btnReaderPort.Location = new System.Drawing.Point(15, 62);
            this.btnReaderPort.Name = "btnReaderPort";
            this.btnReaderPort.Size = new System.Drawing.Size(112, 24);
            this.btnReaderPort.TabIndex = 26;
            this.btnReaderPort.Text = "Initialize";
            this.btnReaderPort.Click += new System.EventHandler(this.btnReaderPort_Click);
            // 
            // cbReader
            // 
            this.cbReader.FormattingEnabled = true;
            this.cbReader.Location = new System.Drawing.Point(15, 28);
            this.cbReader.Name = "cbReader";
            this.cbReader.Size = new System.Drawing.Size(272, 24);
            this.cbReader.TabIndex = 25;
            // 
            // labelApduLogs
            // 
            this.labelApduLogs.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelApduLogs.Location = new System.Drawing.Point(303, 9);
            this.labelApduLogs.Name = "labelApduLogs";
            this.labelApduLogs.Size = new System.Drawing.Size(115, 16);
            this.labelApduLogs.TabIndex = 36;
            this.labelApduLogs.Text = "APDU Logs";
            // 
            // richTextBoxLogs
            // 
            this.richTextBoxLogs.Location = new System.Drawing.Point(306, 28);
            this.richTextBoxLogs.Name = "richTextBoxLogs";
            this.richTextBoxLogs.Size = new System.Drawing.Size(347, 259);
            this.richTextBoxLogs.TabIndex = 37;
            this.richTextBoxLogs.Text = "";
            // 
            // btnFormat
            // 
            this.btnFormat.Enabled = false;
            this.btnFormat.Location = new System.Drawing.Point(175, 92);
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.Size = new System.Drawing.Size(112, 24);
            this.btnFormat.TabIndex = 28;
            this.btnFormat.Text = "Format Card";
            this.btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(669, 332);
            this.Controls.Add(this.richTextBoxLogs);
            this.Controls.Add(this.labelApduLogs);
            this.Controls.Add(this.cbReader);
            this.Controls.Add(this.btnReaderPort);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GBUserFile);
            this.Controls.Add(this.btnFormat);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnReset);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reading and Writing to ACOS3 card";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GroupBox2.ResumeLayout(false);
            this.GBUserFile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		}

		private void btnReaderPort_Click(object sender, System.EventArgs e)
		{
            byte[] returnData = null;   // Will hold the reader names after the call to SCardListReaders
            int readerCount = 0;        // Total length of the reader names
            string readerNames = "";    // Will hold the reader names after converting from byte array to a single string.
            string[] readerList = null; // String array of the Reader Names
            int idx = 0;

            // Established using ScardEstablishedContext()
            retcode = ModWinsCard.SCardEstablishContext(ModWinsCard.SCARD_SCOPE_USER, 0, 0, ref hContext);
            if (retcode != ModWinsCard.SCARD_S_SUCCESS)
            {
                displayOut(1, retcode, "");
                return;
            }

            // List PC/SC card readers installed in the system

            // Call SCardListReaders to get the total length of the reader names
            retcode = ModWinsCard.SCardListReaders(this.hContext, null, null, ref readerCount);
            if (retcode != ModWinsCard.SCARD_S_SUCCESS)
            {
                displayOut(1, retcode, "");
                return;
            }
            else
            {
                returnData = new byte[readerCount];

                // Call SCardListReaders this time passing the array to hold the return data.
                retcode = ModWinsCard.SCardListReaders(this.hContext, null, returnData, ref readerCount);
                if (retcode != ModWinsCard.SCARD_S_SUCCESS)
                {
                    displayOut(1, retcode, "");
                    return;
                }
                else
                {
                    //displayOut(0, 0, "SCardListReaders...OK");

                    // Convert the return data to a string
                    readerNames = System.Text.ASCIIEncoding.ASCII.GetString(returnData);

                    // Parse the string and split the reader names. Delimited by \0.
                    readerList = readerNames.Split('\0');

                    // Clear the combo list of all items.
                    cbReader.Items.Clear();

                    // For each string in the array, add them to the combo list
                    for (idx = 0; idx < readerList.Length; idx++)
                    {
                        cbReader.Items.Add(readerList[idx]);
                    }

                    cbReader.SelectedIndex = 0;
                }
            }
            btnReset.Enabled = true;
            boucle();
            


        }
        private void boucle()
        {
            while (true)
            {
                if (cartepresente)
                {
                    btnConnect.Enabled = true;
                    break;
                }
                carteConnecter();
            }
        }

        private void carteConnecter()
        {
            
            // Connect to selected reader using hContext handle and obtain hCard handle
            if (connActive)
                    retcode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD);

                // Connect to the reader using hContext handle and obtain hCard handle  
                retcode = ModWinsCard.SCardConnect(hContext, cbReader.Text, ModWinsCard.SCARD_SHARE_EXCLUSIVE, 0 | 1, ref hCard, ref ActiveProtocol);
                if (retcode != ModWinsCard.SCARD_S_SUCCESS)
                {
                   // displayOut(0, 0, "probleme de connexion");
                    return;
                }
                else
                {
                    displayOut(0, 0, "Connection OK");
                    //format();
                    connActive = true;
                }

                btnFormat.Enabled = true;
                RBAA11.Checked = true;
                cartepresente = true;
            
        }

        private void carteDeconnecter()
        {
            displayOut(0, 0, "Deconnexion OK");

            retcode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD);

            btnFormat.Enabled = false;
            cartepresente = false;
            RBAA11.Checked = false;
            RBBB22.Checked = false;
            RBCC33.Checked = false;
            txtData.Enabled = false;
            GroupBox2.Enabled = false;
            GBUserFile.Enabled = false;
            boucle();

        }

		private void btnConnect_Click(object sender, System.EventArgs e)
		{
            carteDeconnecter();
        }

        private void btnDisconnect_Click(object sender, System.EventArgs e)
		{
			//Disconnect and unpower card
            if (connActive)
                retcode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD);

            retcode = ModWinsCard.SCardReleaseContext(hContext);

            connActive = false;
			btnFormat.Enabled = false;
            btnConnect.Enabled = false;
            btnReset.Enabled = false;
            txtData.Enabled = false;
            txtData.Text = "";
            richTextBoxLogs.Clear();
            cbReader.Items.Clear();
            cbReader.Text = "";
            GroupBox2.Enabled = false;
			GBUserFile.Enabled = false;
            RBAA11.Checked = false;
            RBBB22.Checked = false;
            RBCC33.Checked = false;
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

            GBUserFile.Enabled = true;
            GroupBox2.Enabled = true;
            txtData.Enabled = true;
        }

		private void btnClear_Click(object sender, System.EventArgs e)
		{
            richTextBoxLogs.Clear();
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			//terminate the application			
			retcode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD);
            retcode = ModWinsCard.SCardReleaseContext(hContext);
			Application.Exit();
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

			retcode = ModWinsCard.SCardTransmit(hCard, ref SendRequest,  ref SendBuff[0], SendBuffLen, ref SendRequest,  ref RecvBuff[0], ref RecvBuffLen);
			if (retcode != ModWinsCard.SCARD_S_SUCCESS) 
			{
                displayOut(1, retcode, "");
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

		private void btnFormat_Click(object sender, System.EventArgs e)
		{
            format();
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

		private void  writeRecord(int caseType, byte RecNo, byte maxLen, byte DataLen, ref byte[] ApduIn)
		{																										
			if (caseType == 1)    // If card data is to be erased before writing new data. Re-initialize card values to $00
			{
				apdu.bCLA = 0x80;       // CLA
				apdu.bINS = 0xD2;       // INS
				apdu.bP1 = RecNo;		// Record No
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

		private void RBAA11_Click(object sender, System.EventArgs e)
		{
			txtData.Text = "";
			txtData.MaxLength = 10;
		}

		private void RBBB22_Click(object sender, System.EventArgs e)
		{
			txtData.Text = "";
			txtData.MaxLength = 16;
		}

		private void RBCC33_Click(object sender, System.EventArgs e)
		{
			txtData.Text = "";
			txtData.MaxLength = 32;
		}

		private void btnRead_Click(object sender, System.EventArgs e)
		{
			int indx; 			

			// Check User File selected by user
			if (RBAA11.Checked == true) 
			{
				HiAddr = 0xAA;
				LoAddr = 0x11;
				dataLen = 0x0A;				
			}

			if (RBBB22.Checked == true) 
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
			}

			// Select User File
			SelectFile(HiAddr, LoAddr);
			if (retcode != ModWinsCard.SCARD_S_SUCCESS)			
				return;			
			
			// Read First Record of User File selected
			readRecord(0x00, dataLen);
			if (retcode != ModWinsCard.SCARD_S_SUCCESS)			
				return;			
			
			// Display data read from card to textbox
			tmpStr = "";
			indx = 0;

			while (RecvBuff[indx] != 0x00)
			{
				if (indx < txtData.MaxLength) 
				{
					tmpStr = tmpStr + Chr(RecvBuff[indx]);
				}
				indx = indx + 1;
			}
			txtData.Text = tmpStr;

            displayOut(0, 0, "Data read from card is displayed");			
		}

		private void readRecord(byte RecNo, byte dataLen)
		{
			apdu.Data = array;
		
			// Read data from card
			apdu.bCLA = 0x80;        // CLA
			apdu.bINS =0xB2;         // INS
			apdu.bP1 = RecNo;        // Record No
			apdu.bP2 = 0x00;         // P2
			apdu.bP3 = dataLen;      // Length of Data
			apdu.IsSend = false;

			PerformTransmitAPDU(ref apdu);
            if (retcode != ModWinsCard.SCARD_S_SUCCESS)
                return;
		}

		Char Chr(int i)
		{
			//Return the character of the given character value
			return Convert.ToChar(i);
		}

		private void btnWrite_Click(object sender, System.EventArgs e)
		{	
			// Validate input template
			if (txtData.Text == "") 
			{
				txtData.Focus();
                return;
			}

			//Check User File selected by user
			if (RBAA11.Checked == true) 
			{
				HiAddr = 0xAA;
				LoAddr = 0x11;
				dataLen = 0x0A;				
			}

			if (RBBB22.Checked == true)
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
			}

			// Select User File
			SelectFile(HiAddr, LoAddr);
			if (retcode != ModWinsCard.SCARD_S_SUCCESS) 			
				return;
						
			tmpStr = ""; 
			tmpStr = txtData.Text;
			
            //Clear the data first
            for (indx = 0; indx < tmpArray.Length; indx++)
            {
                tmpArray[indx] = 0x00;
            }

            writeRecord(0x01, 0x00, (byte)tmpArray.Length, (byte)tmpArray.Length, ref tmpArray);
            if (retcode != ModWinsCard.SCARD_S_SUCCESS)
                return;
            
            //Now write the data to the card
            for (indx = 0; indx < tmpStr.Length; indx++)
            {
                tmpArray[indx] = (byte)Asc(tmpStr.Substring(indx, 1));
            }
			 		
			writeRecord(0x01, 0x00, dataLen, dataLen, ref tmpArray);	
			if (retcode != ModWinsCard.SCARD_S_SUCCESS) 			
				return;

            displayOut(0, 0, "Data read from Text Box is written to card.");			
		}
	
		public static string Mid(string tmpStr, int start)
		{
			return tmpStr.Substring(start, tmpStr.Length - start);
		}

		int Asc(string character)
		{
			if (character.Length == 1)
			{
				System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
				int intAsciiCode = (int)asciiEncoding.GetBytes(character)[0];
				return (intAsciiCode);
			}
			else
			{
				throw new Exception("Character is not valid.");
			}
		}

        void ClearBuffers()
        {
            int indx = 0;
            for (indx = 0; indx < 262; indx++)
            {
                SendBuff[indx] = 0x00;
                RecvBuff[indx] = 0x00;
            }
        }

        private void displayOut(int errType, int retVal, string PrintText)
        {
            switch (errType)
            {
                case 0:
                    break;
                case 1:
                    PrintText = ModWinsCard.GetScardErrMsg(retVal);
                    break;
                case 2:
                    PrintText = "<" + PrintText;
                    break;
                case 3:
                    PrintText = ">" + PrintText;
                    break;
            }

            richTextBoxLogs.Select(richTextBoxLogs.Text.Length, 0);
            richTextBoxLogs.SelectedText = PrintText + "\r\n";
            richTextBoxLogs.ScrollToCaret();
        }

        private void RBAA11_CheckedChanged(object sender, EventArgs e)
        {
            txtData.Text = "";
            txtData.MaxLength = 10;
        }

        private void RBBB22_CheckedChanged(object sender, EventArgs e)
        {
            txtData.Text = "";
            txtData.MaxLength = 16;
        }

        private void RBCC33_CheckedChanged(object sender, EventArgs e)
        {
            txtData.Text = "";
            txtData.MaxLength = 16;
        }

    }
}

/*=================================================================================
 *  Description :  This sample program demonstrates on how to format  ACOS card 
 *                 and how to read/write data into it using the PC/SC platform    
 * ================================================================================*/