using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.VirtualServer.Interop;
using System.Text.RegularExpressions;
using System.Xml;
using System.Reflection;
using System.Text;
using System.Threading;


namespace VSPlus
{
	/// <summary>
	/// Summary description for frmVMProperty.
	/// </summary>
	public class frmVMProperty : System.Windows.Forms.Form
	{
	

		// Initialize COM with Impersonate first
		private InitVS myAppProp;
		// Connect locally or remotely
		private VMVirtualServer myVS;

		private VMVirtualMachine myVM;

		private string thisServerAddress = "";
		private string thisServerDisplayName = "";
		private bool configUpdated = false;
		private bool ConfigUpdated 
		{
			get 
			{	
				return configUpdated;
			}
			set
			{
				configUpdated = value;
				if (configUpdated) 
				{
					btnApply.Enabled = true;
				} 
				else 
				{
					btnApply.Enabled = false;
				}
			}
		}



		// Path to config.xml
		static string CONFIGFILE = frmMain.conf.CONFIGFILE ;

		// If Password or Username box changed, mark this
		static bool UpdateRunAs = false;

		// Connect to parent form
		private frmMain frmMain;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TabPage tbpGeneral;
		private System.Windows.Forms.TextBox txtStartDelay;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cmbStartAction;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cmbShutdownAction;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox ckbRunAs;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtVMName;
		private System.Windows.Forms.TextBox txtNotes;
		private System.Windows.Forms.Label lblVMName;
		private System.Windows.Forms.TabPage tbpMemory;
		private System.Windows.Forms.Label lblMemoryNote;
		private System.Windows.Forms.Label lblMemory;
		private System.Windows.Forms.TrackBar tkbMemory;
		private System.Windows.Forms.TextBox txtMemory;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TabPage tbpSCSI;
		private System.Windows.Forms.TabPage tbpNetwork;
		private System.Windows.Forms.TabPage tbpFloppy;
		private System.Windows.Forms.TabPage tbpCOM;
		private System.Windows.Forms.TabPage tbpLPT;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.RadioButton rdbNoMedia;
		private System.Windows.Forms.RadioButton rdbPhysicalDrive;
		private System.Windows.Forms.RadioButton rdbVFDImage;
		private System.Windows.Forms.TextBox txtVFDPath;
		private System.Windows.Forms.Button btnVFDSelect;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.CheckBox ckbLPT;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.TabControl tabMain;
		private System.Windows.Forms.ComboBox cmbVFDD;
		private System.Windows.Forms.OpenFileDialog ofdMain;
		private System.Windows.Forms.RadioButton rdbCOM1None;
		private System.Windows.Forms.RadioButton rdbCOM1Port;
		private System.Windows.Forms.RadioButton rdbCOM1File;
		private System.Windows.Forms.RadioButton rdbCOM1NamedPipe;
		private System.Windows.Forms.TextBox txtCOM1File;
		private System.Windows.Forms.TextBox txtCOM1NamedPipe;
		private System.Windows.Forms.CheckBox ckbCOM1Modem;
		private System.Windows.Forms.CheckBox ckbCOM2Modem;
		private System.Windows.Forms.TextBox txtCOM2NamedPipe;
		private System.Windows.Forms.TextBox txtCOM2File;
		private System.Windows.Forms.RadioButton rdbCOM2NamedPipe;
		private System.Windows.Forms.RadioButton rdbCOM2File;
		private System.Windows.Forms.RadioButton rdbCOM2Port;
		private System.Windows.Forms.RadioButton rdbCOM2None;
		private System.Windows.Forms.ComboBox cmbCOM1;
		private System.Windows.Forms.ComboBox cmbCOM2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnCOM1Select;
		private System.Windows.Forms.Button btnCOM2Select;
		private System.Windows.Forms.TabPage tbpVHD;
		private System.Windows.Forms.ListBox lstVHD;
		private System.Windows.Forms.Button btnRemoveVHD;
		private System.Windows.Forms.Button btnUpdateVHD;
		private System.Windows.Forms.Button btnVHDSelect;
		private System.Windows.Forms.TextBox txtVHDFilePath;
		private System.Windows.Forms.Button btnAddVHD;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.TabPage tbpDVD;
		private System.Windows.Forms.Button btnUpdateDVD;
		private System.Windows.Forms.Button btnRemoveDVD;
		private System.Windows.Forms.ListBox lstDVD;
		private System.Windows.Forms.ComboBox cmbChannelDVD;
		private System.Windows.Forms.Button btnSelectDVD;
		private System.Windows.Forms.TextBox txtDVDImage;
		private System.Windows.Forms.ComboBox cmbDVDHostDrive;
		private System.Windows.Forms.RadioButton rdbDVDImage;
		private System.Windows.Forms.RadioButton rdbDVDHostDrive;
		private System.Windows.Forms.RadioButton rdbDVDNoMedia;
		private System.Windows.Forms.Button btnAddDVD;
		private System.Windows.Forms.ListBox lstNIC;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Button btnAddNIC;
		private System.Windows.Forms.Button btnRemoveNIC;
		private System.Windows.Forms.Button btnUpdateNIC;
		private System.Windows.Forms.CheckBox ckbNICMACStatic;
		private System.Windows.Forms.TextBox txtNICMAC;
		private System.Windows.Forms.ComboBox cmbVNetwork;
		private System.Windows.Forms.ListBox lstSCSI;
		private System.Windows.Forms.Button btnAddSCSI;
		private System.Windows.Forms.Button btnUpdateSCSI;
		private System.Windows.Forms.Button btnRemoveSCSI;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox cmbSCSIID;
		private System.Windows.Forms.CheckBox ckbSCSIShare;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cmbVHDChannel;
		private System.Windows.Forms.CheckBox ckbEnableUndoDisk;
		private System.Windows.Forms.TabPage tbpEvent;
		private System.Windows.Forms.Label lblEventMessage;
		private System.Windows.Forms.Label label65;
		private System.Windows.Forms.ListView lvEvent;
		private System.Windows.Forms.ColumnHeader colType;
		private System.Windows.Forms.ColumnHeader colDate;
		private System.Windows.Forms.ColumnHeader colTime;
		private System.Windows.Forms.ColumnHeader colCategory;
		private System.Windows.Forms.ColumnHeader colEvent;
		private System.Windows.Forms.ColumnHeader colUser;
		private System.Windows.Forms.ColumnHeader colComputer;
		private System.Windows.Forms.ColumnHeader colMessage;
		private System.Windows.Forms.ComboBox cmbEventMax;
		private System.Windows.Forms.Button btnRefreshEvent;
		private System.Windows.Forms.Label label20;
		private System.Diagnostics.EventLog eventLog1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TabPage tbpStatus;
		private System.Windows.Forms.Timer tmrStatus;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.PictureBox pboxVM;
		private System.Windows.Forms.Label lblStatusVMName;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.PictureBox pboxCPU;
		private System.Windows.Forms.Label lblStatusDiskIO;
		private System.Windows.Forms.Label lblStatusVMCFile;
		private System.Windows.Forms.Label lblStatusNetworkIO;
		private System.Windows.Forms.Label lblStatusGuestOS;
		private System.Windows.Forms.Label lblStatusVMAdditions;
		private System.Windows.Forms.Label lblStatusHeartbeat;
		private System.Windows.Forms.Label lblStatusCPU;
		private System.Windows.Forms.Label lblStatusRuntime;
		private System.Windows.Forms.Label lblStatusState;
		private System.Windows.Forms.Button btnVSProperty;
		private System.Windows.Forms.TabPage tbpScripts;
		private System.Windows.Forms.ColumnHeader colScriptEvent;
		private System.Windows.Forms.ColumnHeader colScripts;
		private System.Windows.Forms.ListView lvScripts;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Button btnScriptAttach;
		private System.Windows.Forms.Button btnScriptRemove;
		private System.Windows.Forms.Label lblScriptEvent;
		private System.Windows.Forms.TextBox txtScript;
		private System.Windows.Forms.Button btnScriptUpdate;
		private System.Windows.Forms.Label lblScriptNote;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label lblVSScript;
		private System.Windows.Forms.Button btnCancel;


		public frmVMProperty(string ServerAddress, string ServerDisplayName, InitVS myApp, frmMain frmMainVMP)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			
			myAppProp = myApp;
			thisServerAddress = ServerAddress;
			thisServerDisplayName = ServerDisplayName;
			frmMain = frmMainVMP;
			this.Text = @"Properties for VM " + ServerDisplayName + " on " + ServerAddress; 
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmVMProperty));
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.tbpGeneral = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtNotes = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtStartDelay = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.cmbShutdownAction = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.cmbStartAction = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.ckbRunAs = new System.Windows.Forms.CheckBox();
			this.txtVMName = new System.Windows.Forms.TextBox();
			this.lblVMName = new System.Windows.Forms.Label();
			this.tbpMemory = new System.Windows.Forms.TabPage();
			this.lblMemoryNote = new System.Windows.Forms.Label();
			this.lblMemory = new System.Windows.Forms.Label();
			this.tkbMemory = new System.Windows.Forms.TrackBar();
			this.txtMemory = new System.Windows.Forms.TextBox();
			this.tbpVHD = new System.Windows.Forms.TabPage();
			this.ckbEnableUndoDisk = new System.Windows.Forms.CheckBox();
			this.label9 = new System.Windows.Forms.Label();
			this.btnUpdateVHD = new System.Windows.Forms.Button();
			this.btnAddVHD = new System.Windows.Forms.Button();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.cmbVHDChannel = new System.Windows.Forms.ComboBox();
			this.txtVHDFilePath = new System.Windows.Forms.TextBox();
			this.lstVHD = new System.Windows.Forms.ListBox();
			this.btnRemoveVHD = new System.Windows.Forms.Button();
			this.btnVHDSelect = new System.Windows.Forms.Button();
			this.tbpSCSI = new System.Windows.Forms.TabPage();
			this.label8 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnRemoveSCSI = new System.Windows.Forms.Button();
			this.btnUpdateSCSI = new System.Windows.Forms.Button();
			this.btnAddSCSI = new System.Windows.Forms.Button();
			this.lstSCSI = new System.Windows.Forms.ListBox();
			this.cmbSCSIID = new System.Windows.Forms.ComboBox();
			this.ckbSCSIShare = new System.Windows.Forms.CheckBox();
			this.tabMain = new System.Windows.Forms.TabControl();
			this.tbpStatus = new System.Windows.Forms.TabPage();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.pboxCPU = new System.Windows.Forms.PictureBox();
			this.lblStatusRuntime = new System.Windows.Forms.Label();
			this.lblStatusCPU = new System.Windows.Forms.Label();
			this.lblStatusHeartbeat = new System.Windows.Forms.Label();
			this.lblStatusVMAdditions = new System.Windows.Forms.Label();
			this.lblStatusGuestOS = new System.Windows.Forms.Label();
			this.lblStatusNetworkIO = new System.Windows.Forms.Label();
			this.lblStatusVMCFile = new System.Windows.Forms.Label();
			this.lblStatusDiskIO = new System.Windows.Forms.Label();
			this.lblStatusState = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.lblStatusVMName = new System.Windows.Forms.Label();
			this.pboxVM = new System.Windows.Forms.PictureBox();
			this.tbpScripts = new System.Windows.Forms.TabPage();
			this.btnScriptUpdate = new System.Windows.Forms.Button();
			this.btnScriptRemove = new System.Windows.Forms.Button();
			this.btnScriptAttach = new System.Windows.Forms.Button();
			this.txtScript = new System.Windows.Forms.TextBox();
			this.label26 = new System.Windows.Forms.Label();
			this.lblScriptEvent = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.lvScripts = new System.Windows.Forms.ListView();
			this.colScriptEvent = new System.Windows.Forms.ColumnHeader();
			this.colScripts = new System.Windows.Forms.ColumnHeader();
			this.tbpEvent = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label20 = new System.Windows.Forms.Label();
			this.btnRefreshEvent = new System.Windows.Forms.Button();
			this.cmbEventMax = new System.Windows.Forms.ComboBox();
			this.lvEvent = new System.Windows.Forms.ListView();
			this.colType = new System.Windows.Forms.ColumnHeader();
			this.colDate = new System.Windows.Forms.ColumnHeader();
			this.colTime = new System.Windows.Forms.ColumnHeader();
			this.colCategory = new System.Windows.Forms.ColumnHeader();
			this.colEvent = new System.Windows.Forms.ColumnHeader();
			this.colUser = new System.Windows.Forms.ColumnHeader();
			this.colComputer = new System.Windows.Forms.ColumnHeader();
			this.colMessage = new System.Windows.Forms.ColumnHeader();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.lblEventMessage = new System.Windows.Forms.Label();
			this.label65 = new System.Windows.Forms.Label();
			this.tbpDVD = new System.Windows.Forms.TabPage();
			this.btnAddDVD = new System.Windows.Forms.Button();
			this.label30 = new System.Windows.Forms.Label();
			this.btnUpdateDVD = new System.Windows.Forms.Button();
			this.btnRemoveDVD = new System.Windows.Forms.Button();
			this.lstDVD = new System.Windows.Forms.ListBox();
			this.label29 = new System.Windows.Forms.Label();
			this.cmbChannelDVD = new System.Windows.Forms.ComboBox();
			this.btnSelectDVD = new System.Windows.Forms.Button();
			this.txtDVDImage = new System.Windows.Forms.TextBox();
			this.cmbDVDHostDrive = new System.Windows.Forms.ComboBox();
			this.rdbDVDImage = new System.Windows.Forms.RadioButton();
			this.rdbDVDHostDrive = new System.Windows.Forms.RadioButton();
			this.rdbDVDNoMedia = new System.Windows.Forms.RadioButton();
			this.tbpNetwork = new System.Windows.Forms.TabPage();
			this.btnUpdateNIC = new System.Windows.Forms.Button();
			this.btnRemoveNIC = new System.Windows.Forms.Button();
			this.btnAddNIC = new System.Windows.Forms.Button();
			this.label17 = new System.Windows.Forms.Label();
			this.lstNIC = new System.Windows.Forms.ListBox();
			this.ckbNICMACStatic = new System.Windows.Forms.CheckBox();
			this.txtNICMAC = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.cmbVNetwork = new System.Windows.Forms.ComboBox();
			this.tbpFloppy = new System.Windows.Forms.TabPage();
			this.btnVFDSelect = new System.Windows.Forms.Button();
			this.txtVFDPath = new System.Windows.Forms.TextBox();
			this.cmbVFDD = new System.Windows.Forms.ComboBox();
			this.rdbVFDImage = new System.Windows.Forms.RadioButton();
			this.rdbPhysicalDrive = new System.Windows.Forms.RadioButton();
			this.rdbNoMedia = new System.Windows.Forms.RadioButton();
			this.tbpLPT = new System.Windows.Forms.TabPage();
			this.ckbLPT = new System.Windows.Forms.CheckBox();
			this.label31 = new System.Windows.Forms.Label();
			this.tbpCOM = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnCOM2Select = new System.Windows.Forms.Button();
			this.rdbCOM2NamedPipe = new System.Windows.Forms.RadioButton();
			this.rdbCOM2File = new System.Windows.Forms.RadioButton();
			this.ckbCOM2Modem = new System.Windows.Forms.CheckBox();
			this.txtCOM2NamedPipe = new System.Windows.Forms.TextBox();
			this.cmbCOM2 = new System.Windows.Forms.ComboBox();
			this.txtCOM2File = new System.Windows.Forms.TextBox();
			this.rdbCOM2Port = new System.Windows.Forms.RadioButton();
			this.rdbCOM2None = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnCOM1Select = new System.Windows.Forms.Button();
			this.cmbCOM1 = new System.Windows.Forms.ComboBox();
			this.txtCOM1File = new System.Windows.Forms.TextBox();
			this.rdbCOM1None = new System.Windows.Forms.RadioButton();
			this.rdbCOM1File = new System.Windows.Forms.RadioButton();
			this.rdbCOM1Port = new System.Windows.Forms.RadioButton();
			this.txtCOM1NamedPipe = new System.Windows.Forms.TextBox();
			this.rdbCOM1NamedPipe = new System.Windows.Forms.RadioButton();
			this.ckbCOM1Modem = new System.Windows.Forms.CheckBox();
			this.ofdMain = new System.Windows.Forms.OpenFileDialog();
			this.btnApply = new System.Windows.Forms.Button();
			this.eventLog1 = new System.Diagnostics.EventLog();
			this.tmrStatus = new System.Windows.Forms.Timer(this.components);
			this.btnVSProperty = new System.Windows.Forms.Button();
			this.lblScriptNote = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.lblVSScript = new System.Windows.Forms.Label();
			this.tbpGeneral.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.tbpMemory.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tkbMemory)).BeginInit();
			this.tbpVHD.SuspendLayout();
			this.tbpSCSI.SuspendLayout();
			this.tabMain.SuspendLayout();
			this.tbpStatus.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.tbpScripts.SuspendLayout();
			this.tbpEvent.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tbpDVD.SuspendLayout();
			this.tbpNetwork.SuspendLayout();
			this.tbpFloppy.SuspendLayout();
			this.tbpLPT.SuspendLayout();
			this.tbpCOM.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(312, 592);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(96, 23);
			this.btnOK.TabIndex = 7;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(544, 592);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(88, 23);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// tbpGeneral
			// 
			this.tbpGeneral.Controls.Add(this.groupBox4);
			this.tbpGeneral.Controls.Add(this.txtVMName);
			this.tbpGeneral.Controls.Add(this.lblVMName);
			this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
			this.tbpGeneral.Name = "tbpGeneral";
			this.tbpGeneral.Size = new System.Drawing.Size(672, 550);
			this.tbpGeneral.TabIndex = 0;
			this.tbpGeneral.Text = "General";
			this.tbpGeneral.Click += new System.EventHandler(this.tbpGeneral_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.label1);
			this.groupBox4.Controls.Add(this.txtNotes);
			this.groupBox4.Controls.Add(this.label5);
			this.groupBox4.Controls.Add(this.txtStartDelay);
			this.groupBox4.Controls.Add(this.label7);
			this.groupBox4.Controls.Add(this.cmbShutdownAction);
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Controls.Add(this.label6);
			this.groupBox4.Controls.Add(this.txtUsername);
			this.groupBox4.Controls.Add(this.cmbStartAction);
			this.groupBox4.Controls.Add(this.label3);
			this.groupBox4.Controls.Add(this.txtPassword);
			this.groupBox4.Controls.Add(this.ckbRunAs);
			this.groupBox4.Location = new System.Drawing.Point(16, 72);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(640, 456);
			this.groupBox4.TabIndex = 15;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Virtual Machine RunAs Properties";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 224);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Notes:";
			// 
			// txtNotes
			// 
			this.txtNotes.AcceptsReturn = true;
			this.txtNotes.Location = new System.Drawing.Point(112, 224);
			this.txtNotes.Multiline = true;
			this.txtNotes.Name = "txtNotes";
			this.txtNotes.Size = new System.Drawing.Size(368, 208);
			this.txtNotes.TabIndex = 3;
			this.txtNotes.Text = "";
			this.txtNotes.TextChanged += new System.EventHandler(this.txtNotes_TextChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(32, 176);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(176, 23);
			this.label5.TabIndex = 9;
			this.label5.Text = "Action when Virtual Server stops:";
			// 
			// txtStartDelay
			// 
			this.txtStartDelay.Location = new System.Drawing.Point(376, 144);
			this.txtStartDelay.Name = "txtStartDelay";
			this.txtStartDelay.TabIndex = 14;
			this.txtStartDelay.Text = "0";
			this.txtStartDelay.TextChanged += new System.EventHandler(this.txtStartDelay_TextChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(32, 144);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(312, 23);
			this.label7.TabIndex = 13;
			this.label7.Text = "Seconds to delay automatically turning on a virtual machine";
			// 
			// cmbShutdownAction
			// 
			this.cmbShutdownAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbShutdownAction.ItemHeight = 13;
			this.cmbShutdownAction.Items.AddRange(new object[] {
																   "Shutdown",
																   "Turn Off",
																   "Save State"});
			this.cmbShutdownAction.Location = new System.Drawing.Point(208, 176);
			this.cmbShutdownAction.Name = "cmbShutdownAction";
			this.cmbShutdownAction.Size = new System.Drawing.Size(272, 21);
			this.cmbShutdownAction.TabIndex = 10;
			this.cmbShutdownAction.TextChanged += new System.EventHandler(this.cmbShutdownAction_TextChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(24, 80);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 24);
			this.label4.TabIndex = 6;
			this.label4.Text = "Password";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(32, 112);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(176, 23);
			this.label6.TabIndex = 11;
			this.label6.Text = "Action when Virtual Server starts:";
			// 
			// txtUsername
			// 
			this.txtUsername.Location = new System.Drawing.Point(96, 48);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(224, 20);
			this.txtUsername.TabIndex = 5;
			this.txtUsername.Text = "";
			this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
			// 
			// cmbStartAction
			// 
			this.cmbStartAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbStartAction.ItemHeight = 13;
			this.cmbStartAction.Items.AddRange(new object[] {
																"Always automatically turn on virtual machine",
																"Automatically turn on virtual machine if was running when Virtual Server stopped",
																"Never automatically turn on virtual machine"});
			this.cmbStartAction.Location = new System.Drawing.Point(208, 112);
			this.cmbStartAction.Name = "cmbStartAction";
			this.cmbStartAction.Size = new System.Drawing.Size(424, 21);
			this.cmbStartAction.TabIndex = 12;
			this.cmbStartAction.TextChanged += new System.EventHandler(this.cmbStartAction_TextChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Username";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtPassword
			// 
			this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtPassword.Location = new System.Drawing.Point(96, 80);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(224, 22);
			this.txtPassword.TabIndex = 7;
			this.txtPassword.Text = "";
			this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
			// 
			// ckbRunAs
			// 
			this.ckbRunAs.Location = new System.Drawing.Point(24, 16);
			this.ckbRunAs.Name = "ckbRunAs";
			this.ckbRunAs.Size = new System.Drawing.Size(312, 24);
			this.ckbRunAs.TabIndex = 8;
			this.ckbRunAs.Text = "Run virtual machine under the following user account:";
			this.ckbRunAs.CheckedChanged += new System.EventHandler(this.ckbRunAs_CheckedChanged);
			// 
			// txtVMName
			// 
			this.txtVMName.Location = new System.Drawing.Point(96, 32);
			this.txtVMName.Name = "txtVMName";
			this.txtVMName.Size = new System.Drawing.Size(224, 20);
			this.txtVMName.TabIndex = 1;
			this.txtVMName.Text = "";
			this.txtVMName.TextChanged += new System.EventHandler(this.txtVMName_TextChanged);
			// 
			// lblVMName
			// 
			this.lblVMName.Location = new System.Drawing.Point(24, 32);
			this.lblVMName.Name = "lblVMName";
			this.lblVMName.Size = new System.Drawing.Size(72, 23);
			this.lblVMName.TabIndex = 0;
			this.lblVMName.Text = "VM Name";
			this.lblVMName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbpMemory
			// 
			this.tbpMemory.Controls.Add(this.lblMemoryNote);
			this.tbpMemory.Controls.Add(this.lblMemory);
			this.tbpMemory.Controls.Add(this.tkbMemory);
			this.tbpMemory.Controls.Add(this.txtMemory);
			this.tbpMemory.Location = new System.Drawing.Point(4, 22);
			this.tbpMemory.Name = "tbpMemory";
			this.tbpMemory.Size = new System.Drawing.Size(672, 550);
			this.tbpMemory.TabIndex = 1;
			this.tbpMemory.Text = "Memory";
			// 
			// lblMemoryNote
			// 
			this.lblMemoryNote.Location = new System.Drawing.Point(56, 32);
			this.lblMemoryNote.Name = "lblMemoryNote";
			this.lblMemoryNote.Size = new System.Drawing.Size(560, 23);
			this.lblMemoryNote.TabIndex = 3;
			this.lblMemoryNote.Text = "Note:";
			// 
			// lblMemory
			// 
			this.lblMemory.Location = new System.Drawing.Point(184, 152);
			this.lblMemory.Name = "lblMemory";
			this.lblMemory.Size = new System.Drawing.Size(96, 23);
			this.lblMemory.TabIndex = 0;
			this.lblMemory.Text = "Memory: (in MB)";
			// 
			// tkbMemory
			// 
			this.tkbMemory.Location = new System.Drawing.Point(104, 80);
			this.tkbMemory.Name = "tkbMemory";
			this.tkbMemory.Size = new System.Drawing.Size(456, 45);
			this.tkbMemory.SmallChange = 5;
			this.tkbMemory.TabIndex = 1;
			this.tkbMemory.Tag = "";
			this.tkbMemory.Scroll += new System.EventHandler(this.tkbMemory_Scroll);
			// 
			// txtMemory
			// 
			this.txtMemory.Location = new System.Drawing.Point(288, 152);
			this.txtMemory.Name = "txtMemory";
			this.txtMemory.Size = new System.Drawing.Size(128, 20);
			this.txtMemory.TabIndex = 2;
			this.txtMemory.Text = "";
			this.txtMemory.TextChanged += new System.EventHandler(this.txtMemory_TextChanged);
			this.txtMemory.Leave += new System.EventHandler(this.txtMemory_Leave);
			// 
			// tbpVHD
			// 
			this.tbpVHD.Controls.Add(this.ckbEnableUndoDisk);
			this.tbpVHD.Controls.Add(this.label9);
			this.tbpVHD.Controls.Add(this.btnUpdateVHD);
			this.tbpVHD.Controls.Add(this.btnAddVHD);
			this.tbpVHD.Controls.Add(this.label16);
			this.tbpVHD.Controls.Add(this.label15);
			this.tbpVHD.Controls.Add(this.cmbVHDChannel);
			this.tbpVHD.Controls.Add(this.txtVHDFilePath);
			this.tbpVHD.Controls.Add(this.lstVHD);
			this.tbpVHD.Controls.Add(this.btnRemoveVHD);
			this.tbpVHD.Controls.Add(this.btnVHDSelect);
			this.tbpVHD.Location = new System.Drawing.Point(4, 22);
			this.tbpVHD.Name = "tbpVHD";
			this.tbpVHD.Size = new System.Drawing.Size(672, 550);
			this.tbpVHD.TabIndex = 3;
			this.tbpVHD.Text = "Harddisk";
			// 
			// ckbEnableUndoDisk
			// 
			this.ckbEnableUndoDisk.Location = new System.Drawing.Point(48, 304);
			this.ckbEnableUndoDisk.Name = "ckbEnableUndoDisk";
			this.ckbEnableUndoDisk.Size = new System.Drawing.Size(144, 24);
			this.ckbEnableUndoDisk.TabIndex = 11;
			this.ckbEnableUndoDisk.Text = "Enable Undo Disks";
			this.ckbEnableUndoDisk.CheckedChanged += new System.EventHandler(this.ckbEnableUndoDisk_CheckedChanged);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(48, 24);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(152, 23);
			this.label9.TabIndex = 10;
			this.label9.Text = "Existing Virtual Hard Disk:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnUpdateVHD
			// 
			this.btnUpdateVHD.Location = new System.Drawing.Point(256, 416);
			this.btnUpdateVHD.Name = "btnUpdateVHD";
			this.btnUpdateVHD.Size = new System.Drawing.Size(104, 24);
			this.btnUpdateVHD.TabIndex = 9;
			this.btnUpdateVHD.Text = "Update";
			this.btnUpdateVHD.Click += new System.EventHandler(this.btnUpdateVHD_Click);
			// 
			// btnAddVHD
			// 
			this.btnAddVHD.Location = new System.Drawing.Point(136, 416);
			this.btnAddVHD.Name = "btnAddVHD";
			this.btnAddVHD.Size = new System.Drawing.Size(96, 23);
			this.btnAddVHD.TabIndex = 8;
			this.btnAddVHD.Text = "Add";
			this.btnAddVHD.Click += new System.EventHandler(this.btnAddVHD_Click);
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(48, 368);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(40, 23);
			this.label16.TabIndex = 6;
			this.label16.Text = "Path:";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(48, 336);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(56, 23);
			this.label15.TabIndex = 5;
			this.label15.Text = "Channel:";
			// 
			// cmbVHDChannel
			// 
			this.cmbVHDChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbVHDChannel.ItemHeight = 13;
			this.cmbVHDChannel.Location = new System.Drawing.Point(112, 336);
			this.cmbVHDChannel.Name = "cmbVHDChannel";
			this.cmbVHDChannel.Size = new System.Drawing.Size(288, 21);
			this.cmbVHDChannel.TabIndex = 4;
			this.cmbVHDChannel.TextChanged += new System.EventHandler(this.cmbVHDChannel_TextChanged);
			this.cmbVHDChannel.SelectedIndexChanged += new System.EventHandler(this.cmbChannel_SelectedIndexChanged);
			// 
			// txtVHDFilePath
			// 
			this.txtVHDFilePath.Location = new System.Drawing.Point(112, 368);
			this.txtVHDFilePath.Name = "txtVHDFilePath";
			this.txtVHDFilePath.Size = new System.Drawing.Size(424, 20);
			this.txtVHDFilePath.TabIndex = 1;
			this.txtVHDFilePath.Text = "";
			this.txtVHDFilePath.TextChanged += new System.EventHandler(this.txtVHDFilePath_TextChanged);
			// 
			// lstVHD
			// 
			this.lstVHD.HorizontalScrollbar = true;
			this.lstVHD.Location = new System.Drawing.Point(48, 56);
			this.lstVHD.Name = "lstVHD";
			this.lstVHD.Size = new System.Drawing.Size(592, 238);
			this.lstVHD.TabIndex = 0;
			this.lstVHD.SelectedIndexChanged += new System.EventHandler(this.lstVHD_SelectedIndexChanged);
			// 
			// btnRemoveVHD
			// 
			this.btnRemoveVHD.Location = new System.Drawing.Point(384, 416);
			this.btnRemoveVHD.Name = "btnRemoveVHD";
			this.btnRemoveVHD.Size = new System.Drawing.Size(96, 24);
			this.btnRemoveVHD.TabIndex = 7;
			this.btnRemoveVHD.Text = "Remove";
			this.btnRemoveVHD.Click += new System.EventHandler(this.btnRemoveVHD_Click);
			// 
			// btnVHDSelect
			// 
			this.btnVHDSelect.Location = new System.Drawing.Point(560, 368);
			this.btnVHDSelect.Name = "btnVHDSelect";
			this.btnVHDSelect.Size = new System.Drawing.Size(80, 24);
			this.btnVHDSelect.TabIndex = 2;
			this.btnVHDSelect.Text = "Browse...";
			this.btnVHDSelect.Click += new System.EventHandler(this.btnVHDSelect_Click);
			// 
			// tbpSCSI
			// 
			this.tbpSCSI.Controls.Add(this.label8);
			this.tbpSCSI.Controls.Add(this.label2);
			this.tbpSCSI.Controls.Add(this.btnRemoveSCSI);
			this.tbpSCSI.Controls.Add(this.btnUpdateSCSI);
			this.tbpSCSI.Controls.Add(this.btnAddSCSI);
			this.tbpSCSI.Controls.Add(this.lstSCSI);
			this.tbpSCSI.Controls.Add(this.cmbSCSIID);
			this.tbpSCSI.Controls.Add(this.ckbSCSIShare);
			this.tbpSCSI.Location = new System.Drawing.Point(4, 22);
			this.tbpSCSI.Name = "tbpSCSI";
			this.tbpSCSI.Size = new System.Drawing.Size(672, 550);
			this.tbpSCSI.TabIndex = 4;
			this.tbpSCSI.Text = "SCSI Controller";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(72, 304);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(72, 23);
			this.label8.TabIndex = 25;
			this.label8.Text = "Channel:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(48, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(168, 23);
			this.label2.TabIndex = 24;
			this.label2.Text = "Virtual SCSI Adapters:";
			// 
			// btnRemoveSCSI
			// 
			this.btnRemoveSCSI.Location = new System.Drawing.Point(400, 376);
			this.btnRemoveSCSI.Name = "btnRemoveSCSI";
			this.btnRemoveSCSI.TabIndex = 23;
			this.btnRemoveSCSI.Text = "Remove";
			this.btnRemoveSCSI.Click += new System.EventHandler(this.btnRemoveSCSI_Click);
			// 
			// btnUpdateSCSI
			// 
			this.btnUpdateSCSI.Location = new System.Drawing.Point(288, 376);
			this.btnUpdateSCSI.Name = "btnUpdateSCSI";
			this.btnUpdateSCSI.TabIndex = 22;
			this.btnUpdateSCSI.Text = "Update";
			this.btnUpdateSCSI.Click += new System.EventHandler(this.btnUpdateSCSI_Click);
			// 
			// btnAddSCSI
			// 
			this.btnAddSCSI.Location = new System.Drawing.Point(176, 376);
			this.btnAddSCSI.Name = "btnAddSCSI";
			this.btnAddSCSI.TabIndex = 21;
			this.btnAddSCSI.Text = "Add";
			this.btnAddSCSI.Click += new System.EventHandler(this.btnAddSCSI_Click);
			// 
			// lstSCSI
			// 
			this.lstSCSI.Location = new System.Drawing.Point(48, 64);
			this.lstSCSI.Name = "lstSCSI";
			this.lstSCSI.Size = new System.Drawing.Size(552, 212);
			this.lstSCSI.TabIndex = 20;
			this.lstSCSI.SelectedIndexChanged += new System.EventHandler(this.lstSCSI_SelectedIndexChanged);
			// 
			// cmbSCSIID
			// 
			this.cmbSCSIID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSCSIID.Location = new System.Drawing.Point(152, 304);
			this.cmbSCSIID.Name = "cmbSCSIID";
			this.cmbSCSIID.Size = new System.Drawing.Size(176, 21);
			this.cmbSCSIID.TabIndex = 4;
			this.cmbSCSIID.SelectedIndexChanged += new System.EventHandler(this.cmbSCSIID_SelectedIndexChanged);
			// 
			// ckbSCSIShare
			// 
			this.ckbSCSIShare.Location = new System.Drawing.Point(352, 304);
			this.ckbSCSIShare.Name = "ckbSCSIShare";
			this.ckbSCSIShare.Size = new System.Drawing.Size(192, 24);
			this.ckbSCSIShare.TabIndex = 2;
			this.ckbSCSIShare.Text = "Share SCSI bus for clustering";
			this.ckbSCSIShare.CheckedChanged += new System.EventHandler(this.ckbSCSIShare_CheckedChanged);
			// 
			// tabMain
			// 
			this.tabMain.Controls.Add(this.tbpStatus);
			this.tabMain.Controls.Add(this.tbpGeneral);
			this.tabMain.Controls.Add(this.tbpMemory);
			this.tabMain.Controls.Add(this.tbpVHD);
			this.tabMain.Controls.Add(this.tbpDVD);
			this.tabMain.Controls.Add(this.tbpSCSI);
			this.tabMain.Controls.Add(this.tbpNetwork);
			this.tabMain.Controls.Add(this.tbpFloppy);
			this.tabMain.Controls.Add(this.tbpLPT);
			this.tabMain.Controls.Add(this.tbpScripts);
			this.tabMain.Controls.Add(this.tbpEvent);
			this.tabMain.Controls.Add(this.tbpCOM);
			this.tabMain.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabMain.ItemSize = new System.Drawing.Size(49, 18);
			this.tabMain.Location = new System.Drawing.Point(0, 0);
			this.tabMain.Multiline = true;
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(680, 576);
			this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
			this.tabMain.TabIndex = 6;
			// 
			// tbpStatus
			// 
			this.tbpStatus.Controls.Add(this.groupBox5);
			this.tbpStatus.Location = new System.Drawing.Point(4, 40);
			this.tbpStatus.Name = "tbpStatus";
			this.tbpStatus.Size = new System.Drawing.Size(672, 532);
			this.tbpStatus.TabIndex = 11;
			this.tbpStatus.Text = "Status";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.pboxCPU);
			this.groupBox5.Controls.Add(this.lblStatusRuntime);
			this.groupBox5.Controls.Add(this.lblStatusCPU);
			this.groupBox5.Controls.Add(this.lblStatusHeartbeat);
			this.groupBox5.Controls.Add(this.lblStatusVMAdditions);
			this.groupBox5.Controls.Add(this.lblStatusGuestOS);
			this.groupBox5.Controls.Add(this.lblStatusNetworkIO);
			this.groupBox5.Controls.Add(this.lblStatusVMCFile);
			this.groupBox5.Controls.Add(this.lblStatusDiskIO);
			this.groupBox5.Controls.Add(this.lblStatusState);
			this.groupBox5.Controls.Add(this.label24);
			this.groupBox5.Controls.Add(this.label23);
			this.groupBox5.Controls.Add(this.label22);
			this.groupBox5.Controls.Add(this.label21);
			this.groupBox5.Controls.Add(this.label19);
			this.groupBox5.Controls.Add(this.label14);
			this.groupBox5.Controls.Add(this.label13);
			this.groupBox5.Controls.Add(this.label12);
			this.groupBox5.Controls.Add(this.label11);
			this.groupBox5.Controls.Add(this.lblStatusVMName);
			this.groupBox5.Controls.Add(this.pboxVM);
			this.groupBox5.Location = new System.Drawing.Point(24, 16);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(616, 504);
			this.groupBox5.TabIndex = 0;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Status";
			// 
			// pboxCPU
			// 
			this.pboxCPU.Location = new System.Drawing.Point(472, 128);
			this.pboxCPU.Name = "pboxCPU";
			this.pboxCPU.Size = new System.Drawing.Size(120, 100);
			this.pboxCPU.TabIndex = 21;
			this.pboxCPU.TabStop = false;
			// 
			// lblStatusRuntime
			// 
			this.lblStatusRuntime.Location = new System.Drawing.Point(192, 144);
			this.lblStatusRuntime.Name = "lblStatusRuntime";
			this.lblStatusRuntime.Size = new System.Drawing.Size(104, 23);
			this.lblStatusRuntime.TabIndex = 20;
			this.lblStatusRuntime.Text = "n/a";
			this.lblStatusRuntime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblStatusCPU
			// 
			this.lblStatusCPU.Location = new System.Drawing.Point(192, 176);
			this.lblStatusCPU.Name = "lblStatusCPU";
			this.lblStatusCPU.Size = new System.Drawing.Size(232, 23);
			this.lblStatusCPU.TabIndex = 19;
			this.lblStatusCPU.Text = "n/a";
			this.lblStatusCPU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblStatusHeartbeat
			// 
			this.lblStatusHeartbeat.Location = new System.Drawing.Point(192, 208);
			this.lblStatusHeartbeat.Name = "lblStatusHeartbeat";
			this.lblStatusHeartbeat.Size = new System.Drawing.Size(232, 23);
			this.lblStatusHeartbeat.TabIndex = 18;
			this.lblStatusHeartbeat.Text = "n/a";
			this.lblStatusHeartbeat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblStatusVMAdditions
			// 
			this.lblStatusVMAdditions.Location = new System.Drawing.Point(192, 336);
			this.lblStatusVMAdditions.Name = "lblStatusVMAdditions";
			this.lblStatusVMAdditions.Size = new System.Drawing.Size(176, 23);
			this.lblStatusVMAdditions.TabIndex = 17;
			this.lblStatusVMAdditions.Text = "n/a";
			this.lblStatusVMAdditions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblStatusGuestOS
			// 
			this.lblStatusGuestOS.Location = new System.Drawing.Point(192, 304);
			this.lblStatusGuestOS.Name = "lblStatusGuestOS";
			this.lblStatusGuestOS.Size = new System.Drawing.Size(232, 23);
			this.lblStatusGuestOS.TabIndex = 16;
			this.lblStatusGuestOS.Text = "n/a";
			this.lblStatusGuestOS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblStatusNetworkIO
			// 
			this.lblStatusNetworkIO.Location = new System.Drawing.Point(192, 272);
			this.lblStatusNetworkIO.Name = "lblStatusNetworkIO";
			this.lblStatusNetworkIO.Size = new System.Drawing.Size(176, 23);
			this.lblStatusNetworkIO.TabIndex = 15;
			this.lblStatusNetworkIO.Text = "n/a";
			this.lblStatusNetworkIO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblStatusVMCFile
			// 
			this.lblStatusVMCFile.Location = new System.Drawing.Point(192, 368);
			this.lblStatusVMCFile.Name = "lblStatusVMCFile";
			this.lblStatusVMCFile.Size = new System.Drawing.Size(408, 40);
			this.lblStatusVMCFile.TabIndex = 13;
			this.lblStatusVMCFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblStatusDiskIO
			// 
			this.lblStatusDiskIO.Location = new System.Drawing.Point(192, 240);
			this.lblStatusDiskIO.Name = "lblStatusDiskIO";
			this.lblStatusDiskIO.Size = new System.Drawing.Size(176, 23);
			this.lblStatusDiskIO.TabIndex = 12;
			this.lblStatusDiskIO.Text = "n/a";
			this.lblStatusDiskIO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblStatusState
			// 
			this.lblStatusState.Location = new System.Drawing.Point(192, 112);
			this.lblStatusState.Name = "lblStatusState";
			this.lblStatusState.TabIndex = 11;
			this.lblStatusState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label24
			// 
			this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label24.Location = new System.Drawing.Point(24, 336);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(152, 23);
			this.label24.TabIndex = 10;
			this.label24.Text = "Virtual Machine Additions";
			this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label23
			// 
			this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label23.Location = new System.Drawing.Point(24, 368);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(152, 23);
			this.label23.TabIndex = 9;
			this.label23.Text = ".vmc file";
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label22
			// 
			this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label22.Location = new System.Drawing.Point(24, 144);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(152, 23);
			this.label22.TabIndex = 8;
			this.label22.Text = "Running time";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label21
			// 
			this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label21.Location = new System.Drawing.Point(24, 176);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(152, 23);
			this.label21.TabIndex = 7;
			this.label21.Text = "Physical CPU utilization";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label19
			// 
			this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label19.Location = new System.Drawing.Point(24, 208);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(152, 23);
			this.label19.TabIndex = 6;
			this.label19.Text = "Heartbeat (in 1 minute)";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label14
			// 
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label14.Location = new System.Drawing.Point(24, 240);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(152, 23);
			this.label14.TabIndex = 5;
			this.label14.Text = "Disk I/O";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label13
			// 
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label13.Location = new System.Drawing.Point(24, 272);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(152, 23);
			this.label13.TabIndex = 4;
			this.label13.Text = "Network I/O";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label12.Location = new System.Drawing.Point(24, 304);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(152, 23);
			this.label12.TabIndex = 3;
			this.label12.Text = "Guest operating system";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label11.Location = new System.Drawing.Point(24, 112);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(152, 23);
			this.label11.TabIndex = 2;
			this.label11.Text = "Virtual Machine Status";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblStatusVMName
			// 
			this.lblStatusVMName.Location = new System.Drawing.Point(104, 56);
			this.lblStatusVMName.Name = "lblStatusVMName";
			this.lblStatusVMName.Size = new System.Drawing.Size(192, 23);
			this.lblStatusVMName.TabIndex = 1;
			this.lblStatusVMName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pboxVM
			// 
			this.pboxVM.Location = new System.Drawing.Point(24, 31);
			this.pboxVM.Name = "pboxVM";
			this.pboxVM.Size = new System.Drawing.Size(64, 48);
			this.pboxVM.TabIndex = 0;
			this.pboxVM.TabStop = false;
			// 
			// tbpScripts
			// 
			this.tbpScripts.Controls.Add(this.lblVSScript);
			this.tbpScripts.Controls.Add(this.label25);
			this.tbpScripts.Controls.Add(this.lblScriptNote);
			this.tbpScripts.Controls.Add(this.btnScriptUpdate);
			this.tbpScripts.Controls.Add(this.btnScriptRemove);
			this.tbpScripts.Controls.Add(this.btnScriptAttach);
			this.tbpScripts.Controls.Add(this.txtScript);
			this.tbpScripts.Controls.Add(this.label26);
			this.tbpScripts.Controls.Add(this.lblScriptEvent);
			this.tbpScripts.Controls.Add(this.label10);
			this.tbpScripts.Controls.Add(this.lvScripts);
			this.tbpScripts.Location = new System.Drawing.Point(4, 40);
			this.tbpScripts.Name = "tbpScripts";
			this.tbpScripts.Size = new System.Drawing.Size(672, 532);
			this.tbpScripts.TabIndex = 12;
			this.tbpScripts.Text = "Scripts";
			// 
			// btnScriptUpdate
			// 
			this.btnScriptUpdate.Location = new System.Drawing.Point(320, 456);
			this.btnScriptUpdate.Name = "btnScriptUpdate";
			this.btnScriptUpdate.TabIndex = 9;
			this.btnScriptUpdate.Text = "Update";
			this.btnScriptUpdate.Click += new System.EventHandler(this.btnScriptUpdate_Click);
			// 
			// btnScriptRemove
			// 
			this.btnScriptRemove.Location = new System.Drawing.Point(416, 456);
			this.btnScriptRemove.Name = "btnScriptRemove";
			this.btnScriptRemove.TabIndex = 8;
			this.btnScriptRemove.Text = "Remove";
			this.btnScriptRemove.Click += new System.EventHandler(this.btnScriptRemove_Click);
			// 
			// btnScriptAttach
			// 
			this.btnScriptAttach.Location = new System.Drawing.Point(224, 456);
			this.btnScriptAttach.Name = "btnScriptAttach";
			this.btnScriptAttach.TabIndex = 7;
			this.btnScriptAttach.Text = "Attach";
			this.btnScriptAttach.Click += new System.EventHandler(this.btnScriptAttach_Click);
			// 
			// txtScript
			// 
			this.txtScript.Location = new System.Drawing.Point(128, 416);
			this.txtScript.Name = "txtScript";
			this.txtScript.Size = new System.Drawing.Size(488, 20);
			this.txtScript.TabIndex = 6;
			this.txtScript.Text = "";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(24, 416);
			this.label26.Name = "label26";
			this.label26.TabIndex = 5;
			this.label26.Text = "Script:";
			this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblScriptEvent
			// 
			this.lblScriptEvent.Location = new System.Drawing.Point(128, 320);
			this.lblScriptEvent.Name = "lblScriptEvent";
			this.lblScriptEvent.Size = new System.Drawing.Size(488, 23);
			this.lblScriptEvent.TabIndex = 4;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(24, 320);
			this.label10.Name = "label10";
			this.label10.TabIndex = 3;
			this.label10.Text = "Event:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lvScripts
			// 
			this.lvScripts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.colScriptEvent,
																						this.colScripts});
			this.lvScripts.FullRowSelect = true;
			this.lvScripts.Location = new System.Drawing.Point(24, 56);
			this.lvScripts.MultiSelect = false;
			this.lvScripts.Name = "lvScripts";
			this.lvScripts.Size = new System.Drawing.Size(632, 248);
			this.lvScripts.TabIndex = 2;
			this.lvScripts.View = System.Windows.Forms.View.Details;
			this.lvScripts.SelectedIndexChanged += new System.EventHandler(this.lvScripts_SelectedIndexChanged);
			// 
			// colScriptEvent
			// 
			this.colScriptEvent.Text = "Event";
			this.colScriptEvent.Width = 309;
			// 
			// colScripts
			// 
			this.colScripts.Text = "Scripts";
			this.colScripts.Width = 317;
			// 
			// tbpEvent
			// 
			this.tbpEvent.Controls.Add(this.groupBox3);
			this.tbpEvent.Location = new System.Drawing.Point(4, 40);
			this.tbpEvent.Name = "tbpEvent";
			this.tbpEvent.Size = new System.Drawing.Size(672, 532);
			this.tbpEvent.TabIndex = 10;
			this.tbpEvent.Text = "Events";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label20);
			this.groupBox3.Controls.Add(this.btnRefreshEvent);
			this.groupBox3.Controls.Add(this.cmbEventMax);
			this.groupBox3.Controls.Add(this.lvEvent);
			this.groupBox3.Controls.Add(this.lblEventMessage);
			this.groupBox3.Controls.Add(this.label65);
			this.groupBox3.Location = new System.Drawing.Point(16, 24);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(640, 512);
			this.groupBox3.TabIndex = 15;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Past Events";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(304, 16);
			this.label20.Name = "label20";
			this.label20.TabIndex = 8;
			this.label20.Text = "Maximum Events:";
			// 
			// btnRefreshEvent
			// 
			this.btnRefreshEvent.Location = new System.Drawing.Point(552, 16);
			this.btnRefreshEvent.Name = "btnRefreshEvent";
			this.btnRefreshEvent.TabIndex = 10;
			this.btnRefreshEvent.Text = "Refresh";
			this.btnRefreshEvent.Click += new System.EventHandler(this.btnRefreshEvent_Click);
			// 
			// cmbEventMax
			// 
			this.cmbEventMax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEventMax.Items.AddRange(new object[] {
															 "10",
															 "30",
															 "50",
															 "100"});
			this.cmbEventMax.Location = new System.Drawing.Point(416, 16);
			this.cmbEventMax.Name = "cmbEventMax";
			this.cmbEventMax.Size = new System.Drawing.Size(121, 21);
			this.cmbEventMax.TabIndex = 11;
			// 
			// lvEvent
			// 
			this.lvEvent.AutoArrange = false;
			this.lvEvent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					  this.colType,
																					  this.colDate,
																					  this.colTime,
																					  this.colCategory,
																					  this.colEvent,
																					  this.colUser,
																					  this.colComputer,
																					  this.colMessage});
			this.lvEvent.FullRowSelect = true;
			this.lvEvent.GridLines = true;
			this.lvEvent.Location = new System.Drawing.Point(16, 48);
			this.lvEvent.MultiSelect = false;
			this.lvEvent.Name = "lvEvent";
			this.lvEvent.Size = new System.Drawing.Size(616, 376);
			this.lvEvent.SmallImageList = this.imageList1;
			this.lvEvent.TabIndex = 12;
			this.lvEvent.View = System.Windows.Forms.View.Details;
			this.lvEvent.SelectedIndexChanged += new System.EventHandler(this.lvEvent_SelectedIndexChanged);
			// 
			// colType
			// 
			this.colType.Text = "";
			this.colType.Width = 20;
			// 
			// colDate
			// 
			this.colDate.Text = "Date";
			this.colDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colDate.Width = 78;
			// 
			// colTime
			// 
			this.colTime.Text = "Time";
			this.colTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// colCategory
			// 
			this.colCategory.Text = "Category";
			this.colCategory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colCategory.Width = 97;
			// 
			// colEvent
			// 
			this.colEvent.Text = "Event";
			this.colEvent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colEvent.Width = 51;
			// 
			// colUser
			// 
			this.colUser.Text = "User";
			this.colUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colUser.Width = 161;
			// 
			// colComputer
			// 
			this.colComputer.Text = "Computer";
			this.colComputer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colComputer.Width = 74;
			// 
			// colMessage
			// 
			this.colMessage.Text = "Message";
			this.colMessage.Width = 71;
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// lblEventMessage
			// 
			this.lblEventMessage.Location = new System.Drawing.Point(104, 448);
			this.lblEventMessage.Name = "lblEventMessage";
			this.lblEventMessage.Size = new System.Drawing.Size(520, 48);
			this.lblEventMessage.TabIndex = 14;
			// 
			// label65
			// 
			this.label65.Location = new System.Drawing.Point(16, 448);
			this.label65.Name = "label65";
			this.label65.TabIndex = 13;
			this.label65.Text = "Event Message:";
			// 
			// tbpDVD
			// 
			this.tbpDVD.Controls.Add(this.btnAddDVD);
			this.tbpDVD.Controls.Add(this.label30);
			this.tbpDVD.Controls.Add(this.btnUpdateDVD);
			this.tbpDVD.Controls.Add(this.btnRemoveDVD);
			this.tbpDVD.Controls.Add(this.lstDVD);
			this.tbpDVD.Controls.Add(this.label29);
			this.tbpDVD.Controls.Add(this.cmbChannelDVD);
			this.tbpDVD.Controls.Add(this.btnSelectDVD);
			this.tbpDVD.Controls.Add(this.txtDVDImage);
			this.tbpDVD.Controls.Add(this.cmbDVDHostDrive);
			this.tbpDVD.Controls.Add(this.rdbDVDImage);
			this.tbpDVD.Controls.Add(this.rdbDVDHostDrive);
			this.tbpDVD.Controls.Add(this.rdbDVDNoMedia);
			this.tbpDVD.Location = new System.Drawing.Point(4, 22);
			this.tbpDVD.Name = "tbpDVD";
			this.tbpDVD.Size = new System.Drawing.Size(672, 550);
			this.tbpDVD.TabIndex = 9;
			this.tbpDVD.Text = "DVD/CDROM";
			// 
			// btnAddDVD
			// 
			this.btnAddDVD.Location = new System.Drawing.Point(136, 464);
			this.btnAddDVD.Name = "btnAddDVD";
			this.btnAddDVD.Size = new System.Drawing.Size(96, 23);
			this.btnAddDVD.TabIndex = 25;
			this.btnAddDVD.Text = "Add";
			this.btnAddDVD.Click += new System.EventHandler(this.btnAddDVD_Click);
			// 
			// label30
			// 
			this.label30.Location = new System.Drawing.Point(32, 24);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(192, 23);
			this.label30.TabIndex = 24;
			this.label30.Text = "Existing Virtual CDROM/DVD Drive";
			// 
			// btnUpdateDVD
			// 
			this.btnUpdateDVD.Enabled = false;
			this.btnUpdateDVD.Location = new System.Drawing.Point(256, 464);
			this.btnUpdateDVD.Name = "btnUpdateDVD";
			this.btnUpdateDVD.Size = new System.Drawing.Size(104, 24);
			this.btnUpdateDVD.TabIndex = 21;
			this.btnUpdateDVD.Text = "Update";
			this.btnUpdateDVD.Click += new System.EventHandler(this.btnUpdateDVD_Click);
			// 
			// btnRemoveDVD
			// 
			this.btnRemoveDVD.Enabled = false;
			this.btnRemoveDVD.Location = new System.Drawing.Point(376, 464);
			this.btnRemoveDVD.Name = "btnRemoveDVD";
			this.btnRemoveDVD.Size = new System.Drawing.Size(104, 24);
			this.btnRemoveDVD.TabIndex = 18;
			this.btnRemoveDVD.Text = "Remove";
			this.btnRemoveDVD.Click += new System.EventHandler(this.btnRemoveDVD_Click);
			// 
			// lstDVD
			// 
			this.lstDVD.HorizontalScrollbar = true;
			this.lstDVD.Location = new System.Drawing.Point(40, 48);
			this.lstDVD.Name = "lstDVD";
			this.lstDVD.Size = new System.Drawing.Size(592, 186);
			this.lstDVD.TabIndex = 13;
			this.lstDVD.SelectedIndexChanged += new System.EventHandler(this.lstDVD_SelectedIndexChanged);
			// 
			// label29
			// 
			this.label29.Location = new System.Drawing.Point(48, 256);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(56, 23);
			this.label29.TabIndex = 15;
			this.label29.Text = "Channel:";
			// 
			// cmbChannelDVD
			// 
			this.cmbChannelDVD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbChannelDVD.ItemHeight = 13;
			this.cmbChannelDVD.Location = new System.Drawing.Point(112, 256);
			this.cmbChannelDVD.Name = "cmbChannelDVD";
			this.cmbChannelDVD.Size = new System.Drawing.Size(288, 21);
			this.cmbChannelDVD.TabIndex = 14;
			this.cmbChannelDVD.TextChanged += new System.EventHandler(this.cmbChannelDVD_TextChanged);
			this.cmbChannelDVD.SelectedIndexChanged += new System.EventHandler(this.cmbChannelDVD_SelectedIndexChanged);
			// 
			// btnSelectDVD
			// 
			this.btnSelectDVD.Enabled = false;
			this.btnSelectDVD.Location = new System.Drawing.Point(552, 368);
			this.btnSelectDVD.Name = "btnSelectDVD";
			this.btnSelectDVD.TabIndex = 23;
			this.btnSelectDVD.Text = "Browse...";
			this.btnSelectDVD.Click += new System.EventHandler(this.btnSelectDVD_Click);
			// 
			// txtDVDImage
			// 
			this.txtDVDImage.Enabled = false;
			this.txtDVDImage.Location = new System.Drawing.Point(240, 368);
			this.txtDVDImage.Name = "txtDVDImage";
			this.txtDVDImage.Size = new System.Drawing.Size(296, 20);
			this.txtDVDImage.TabIndex = 22;
			this.txtDVDImage.Text = "";
			this.txtDVDImage.TextChanged += new System.EventHandler(this.txtDVDImage_TextChanged);
			// 
			// cmbDVDHostDrive
			// 
			this.cmbDVDHostDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDVDHostDrive.Enabled = false;
			this.cmbDVDHostDrive.Location = new System.Drawing.Point(240, 328);
			this.cmbDVDHostDrive.Name = "cmbDVDHostDrive";
			this.cmbDVDHostDrive.Size = new System.Drawing.Size(168, 21);
			this.cmbDVDHostDrive.TabIndex = 20;
			this.cmbDVDHostDrive.TextChanged += new System.EventHandler(this.cmbDVDHostDrive_TextChanged);
			this.cmbDVDHostDrive.SelectedIndexChanged += new System.EventHandler(this.cmbDVDHostDrive_SelectedIndexChanged);
			// 
			// rdbDVDImage
			// 
			this.rdbDVDImage.Location = new System.Drawing.Point(48, 368);
			this.rdbDVDImage.Name = "rdbDVDImage";
			this.rdbDVDImage.Size = new System.Drawing.Size(176, 24);
			this.rdbDVDImage.TabIndex = 19;
			this.rdbDVDImage.Text = "Use CDROM/DVD image";
			this.rdbDVDImage.CheckedChanged += new System.EventHandler(this.rdbDVDImage_CheckedChanged);
			// 
			// rdbDVDHostDrive
			// 
			this.rdbDVDHostDrive.Location = new System.Drawing.Point(48, 328);
			this.rdbDVDHostDrive.Name = "rdbDVDHostDrive";
			this.rdbDVDHostDrive.Size = new System.Drawing.Size(176, 24);
			this.rdbDVDHostDrive.TabIndex = 17;
			this.rdbDVDHostDrive.Text = "Use Physical CD/DVD Drive";
			this.rdbDVDHostDrive.CheckedChanged += new System.EventHandler(this.rdbDVDHostDrive_CheckedChanged);
			// 
			// rdbDVDNoMedia
			// 
			this.rdbDVDNoMedia.Checked = true;
			this.rdbDVDNoMedia.Location = new System.Drawing.Point(48, 288);
			this.rdbDVDNoMedia.Name = "rdbDVDNoMedia";
			this.rdbDVDNoMedia.Size = new System.Drawing.Size(176, 24);
			this.rdbDVDNoMedia.TabIndex = 16;
			this.rdbDVDNoMedia.TabStop = true;
			this.rdbDVDNoMedia.Text = "No Media";
			this.rdbDVDNoMedia.CheckedChanged += new System.EventHandler(this.rdbDVDNoMedia_CheckedChanged);
			// 
			// tbpNetwork
			// 
			this.tbpNetwork.Controls.Add(this.btnUpdateNIC);
			this.tbpNetwork.Controls.Add(this.btnRemoveNIC);
			this.tbpNetwork.Controls.Add(this.btnAddNIC);
			this.tbpNetwork.Controls.Add(this.label17);
			this.tbpNetwork.Controls.Add(this.lstNIC);
			this.tbpNetwork.Controls.Add(this.ckbNICMACStatic);
			this.tbpNetwork.Controls.Add(this.txtNICMAC);
			this.tbpNetwork.Controls.Add(this.label18);
			this.tbpNetwork.Controls.Add(this.cmbVNetwork);
			this.tbpNetwork.Location = new System.Drawing.Point(4, 22);
			this.tbpNetwork.Name = "tbpNetwork";
			this.tbpNetwork.Size = new System.Drawing.Size(672, 550);
			this.tbpNetwork.TabIndex = 5;
			this.tbpNetwork.Text = "Network Adapter";
			// 
			// btnUpdateNIC
			// 
			this.btnUpdateNIC.Enabled = false;
			this.btnUpdateNIC.Location = new System.Drawing.Point(256, 352);
			this.btnUpdateNIC.Name = "btnUpdateNIC";
			this.btnUpdateNIC.TabIndex = 43;
			this.btnUpdateNIC.Text = "Update";
			this.btnUpdateNIC.Click += new System.EventHandler(this.btnUpdateNIC_Click);
			// 
			// btnRemoveNIC
			// 
			this.btnRemoveNIC.Enabled = false;
			this.btnRemoveNIC.Location = new System.Drawing.Point(368, 352);
			this.btnRemoveNIC.Name = "btnRemoveNIC";
			this.btnRemoveNIC.TabIndex = 42;
			this.btnRemoveNIC.Text = "Remove";
			this.btnRemoveNIC.Click += new System.EventHandler(this.btnRemoveNIC_Click);
			// 
			// btnAddNIC
			// 
			this.btnAddNIC.Location = new System.Drawing.Point(144, 352);
			this.btnAddNIC.Name = "btnAddNIC";
			this.btnAddNIC.TabIndex = 41;
			this.btnAddNIC.Text = "Add";
			this.btnAddNIC.Click += new System.EventHandler(this.btnAddNIC_Click);
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(48, 24);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(200, 23);
			this.label17.TabIndex = 40;
			this.label17.Text = "Existing Network Adapters:";
			// 
			// lstNIC
			// 
			this.lstNIC.Location = new System.Drawing.Point(48, 56);
			this.lstNIC.Name = "lstNIC";
			this.lstNIC.Size = new System.Drawing.Size(584, 173);
			this.lstNIC.TabIndex = 39;
			this.lstNIC.SelectedIndexChanged += new System.EventHandler(this.lstNIC_SelectedIndexChanged);
			// 
			// ckbNICMACStatic
			// 
			this.ckbNICMACStatic.Location = new System.Drawing.Point(144, 296);
			this.ckbNICMACStatic.Name = "ckbNICMACStatic";
			this.ckbNICMACStatic.Size = new System.Drawing.Size(72, 24);
			this.ckbNICMACStatic.TabIndex = 38;
			this.ckbNICMACStatic.Text = "Static";
			this.ckbNICMACStatic.CheckedChanged += new System.EventHandler(this.ckbNICMACStatic_CheckedChanged);
			// 
			// txtNICMAC
			// 
			this.txtNICMAC.Location = new System.Drawing.Point(216, 296);
			this.txtNICMAC.Name = "txtNICMAC";
			this.txtNICMAC.Size = new System.Drawing.Size(296, 20);
			this.txtNICMAC.TabIndex = 37;
			this.txtNICMAC.Text = "";
			this.txtNICMAC.TextChanged += new System.EventHandler(this.txtNICMAC_TextChanged);
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(72, 264);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(72, 23);
			this.label18.TabIndex = 3;
			this.label18.Text = "Connect to:";
			// 
			// cmbVNetwork
			// 
			this.cmbVNetwork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbVNetwork.Location = new System.Drawing.Point(144, 264);
			this.cmbVNetwork.Name = "cmbVNetwork";
			this.cmbVNetwork.Size = new System.Drawing.Size(296, 21);
			this.cmbVNetwork.TabIndex = 2;
			this.cmbVNetwork.TextChanged += new System.EventHandler(this.cmbVNetwork_TextChanged);
			// 
			// tbpFloppy
			// 
			this.tbpFloppy.Controls.Add(this.btnVFDSelect);
			this.tbpFloppy.Controls.Add(this.txtVFDPath);
			this.tbpFloppy.Controls.Add(this.cmbVFDD);
			this.tbpFloppy.Controls.Add(this.rdbVFDImage);
			this.tbpFloppy.Controls.Add(this.rdbPhysicalDrive);
			this.tbpFloppy.Controls.Add(this.rdbNoMedia);
			this.tbpFloppy.Location = new System.Drawing.Point(4, 22);
			this.tbpFloppy.Name = "tbpFloppy";
			this.tbpFloppy.Size = new System.Drawing.Size(672, 550);
			this.tbpFloppy.TabIndex = 6;
			this.tbpFloppy.Text = "Floppy Drive";
			// 
			// btnVFDSelect
			// 
			this.btnVFDSelect.Enabled = false;
			this.btnVFDSelect.Location = new System.Drawing.Point(552, 176);
			this.btnVFDSelect.Name = "btnVFDSelect";
			this.btnVFDSelect.TabIndex = 5;
			this.btnVFDSelect.Text = "Browse...";
			this.btnVFDSelect.Click += new System.EventHandler(this.btnVFDSelect_Click);
			// 
			// txtVFDPath
			// 
			this.txtVFDPath.Enabled = false;
			this.txtVFDPath.Location = new System.Drawing.Point(232, 176);
			this.txtVFDPath.Name = "txtVFDPath";
			this.txtVFDPath.Size = new System.Drawing.Size(296, 20);
			this.txtVFDPath.TabIndex = 4;
			this.txtVFDPath.Text = "";
			this.txtVFDPath.TextChanged += new System.EventHandler(this.txtVFDPath_TextChanged);
			// 
			// cmbVFDD
			// 
			this.cmbVFDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbVFDD.Enabled = false;
			this.cmbVFDD.Items.AddRange(new object[] {
														 "Drive A"});
			this.cmbVFDD.Location = new System.Drawing.Point(232, 136);
			this.cmbVFDD.Name = "cmbVFDD";
			this.cmbVFDD.Size = new System.Drawing.Size(168, 21);
			this.cmbVFDD.TabIndex = 3;
			this.cmbVFDD.TextChanged += new System.EventHandler(this.cmbVFDD_TextChanged);
			this.cmbVFDD.SelectedIndexChanged += new System.EventHandler(this.cmbVFDD_SelectedIndexChanged);
			// 
			// rdbVFDImage
			// 
			this.rdbVFDImage.Location = new System.Drawing.Point(40, 176);
			this.rdbVFDImage.Name = "rdbVFDImage";
			this.rdbVFDImage.Size = new System.Drawing.Size(176, 24);
			this.rdbVFDImage.TabIndex = 2;
			this.rdbVFDImage.Text = "Use Virtual Floppy Disk image";
			this.rdbVFDImage.CheckedChanged += new System.EventHandler(this.rdbVFDImage_CheckedChanged);
			// 
			// rdbPhysicalDrive
			// 
			this.rdbPhysicalDrive.Location = new System.Drawing.Point(40, 136);
			this.rdbPhysicalDrive.Name = "rdbPhysicalDrive";
			this.rdbPhysicalDrive.Size = new System.Drawing.Size(176, 24);
			this.rdbPhysicalDrive.TabIndex = 1;
			this.rdbPhysicalDrive.Text = "Use Physical Drive";
			this.rdbPhysicalDrive.CheckedChanged += new System.EventHandler(this.rdbPhysicalDrive_CheckedChanged);
			// 
			// rdbNoMedia
			// 
			this.rdbNoMedia.Checked = true;
			this.rdbNoMedia.Location = new System.Drawing.Point(40, 96);
			this.rdbNoMedia.Name = "rdbNoMedia";
			this.rdbNoMedia.Size = new System.Drawing.Size(176, 24);
			this.rdbNoMedia.TabIndex = 0;
			this.rdbNoMedia.TabStop = true;
			this.rdbNoMedia.Text = "No Floppy drive";
			this.rdbNoMedia.CheckedChanged += new System.EventHandler(this.rdbNoMedia_CheckedChanged);
			// 
			// tbpLPT
			// 
			this.tbpLPT.Controls.Add(this.ckbLPT);
			this.tbpLPT.Controls.Add(this.label31);
			this.tbpLPT.Location = new System.Drawing.Point(4, 22);
			this.tbpLPT.Name = "tbpLPT";
			this.tbpLPT.Size = new System.Drawing.Size(672, 550);
			this.tbpLPT.TabIndex = 8;
			this.tbpLPT.Text = "LPT Port";
			// 
			// ckbLPT
			// 
			this.ckbLPT.Location = new System.Drawing.Point(192, 112);
			this.ckbLPT.Name = "ckbLPT";
			this.ckbLPT.Size = new System.Drawing.Size(240, 24);
			this.ckbLPT.TabIndex = 1;
			this.ckbLPT.Text = "LPT1 (378h-37Fh)";
			this.ckbLPT.CheckedChanged += new System.EventHandler(this.ckbLPT_CheckedChanged);
			// 
			// label31
			// 
			this.label31.Location = new System.Drawing.Point(72, 112);
			this.label31.Name = "label31";
			this.label31.TabIndex = 0;
			this.label31.Text = "LPT Port1";
			// 
			// tbpCOM
			// 
			this.tbpCOM.Controls.Add(this.groupBox2);
			this.tbpCOM.Controls.Add(this.groupBox1);
			this.tbpCOM.Location = new System.Drawing.Point(4, 22);
			this.tbpCOM.Name = "tbpCOM";
			this.tbpCOM.Size = new System.Drawing.Size(672, 550);
			this.tbpCOM.TabIndex = 7;
			this.tbpCOM.Text = "COM Port";
			this.tbpCOM.Click += new System.EventHandler(this.tbpCOM_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnCOM2Select);
			this.groupBox2.Controls.Add(this.rdbCOM2NamedPipe);
			this.groupBox2.Controls.Add(this.rdbCOM2File);
			this.groupBox2.Controls.Add(this.ckbCOM2Modem);
			this.groupBox2.Controls.Add(this.txtCOM2NamedPipe);
			this.groupBox2.Controls.Add(this.cmbCOM2);
			this.groupBox2.Controls.Add(this.txtCOM2File);
			this.groupBox2.Controls.Add(this.rdbCOM2Port);
			this.groupBox2.Controls.Add(this.rdbCOM2None);
			this.groupBox2.Location = new System.Drawing.Point(32, 256);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(624, 272);
			this.groupBox2.TabIndex = 23;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "COM2";
			// 
			// btnCOM2Select
			// 
			this.btnCOM2Select.Location = new System.Drawing.Point(528, 144);
			this.btnCOM2Select.Name = "btnCOM2Select";
			this.btnCOM2Select.TabIndex = 22;
			this.btnCOM2Select.Text = "Select";
			this.btnCOM2Select.Click += new System.EventHandler(this.btnCOM2Select_Click);
			// 
			// rdbCOM2NamedPipe
			// 
			this.rdbCOM2NamedPipe.Location = new System.Drawing.Point(40, 176);
			this.rdbCOM2NamedPipe.Name = "rdbCOM2NamedPipe";
			this.rdbCOM2NamedPipe.TabIndex = 18;
			this.rdbCOM2NamedPipe.Text = "Named Pipe:";
			this.rdbCOM2NamedPipe.CheckedChanged += new System.EventHandler(this.rdbCOM2NamedPipe_CheckedChanged);
			// 
			// rdbCOM2File
			// 
			this.rdbCOM2File.Location = new System.Drawing.Point(40, 144);
			this.rdbCOM2File.Name = "rdbCOM2File";
			this.rdbCOM2File.TabIndex = 17;
			this.rdbCOM2File.Text = "Text File:";
			this.rdbCOM2File.CheckedChanged += new System.EventHandler(this.rdbCOM2File_CheckedChanged);
			// 
			// ckbCOM2Modem
			// 
			this.ckbCOM2Modem.Enabled = false;
			this.ckbCOM2Modem.Location = new System.Drawing.Point(88, 112);
			this.ckbCOM2Modem.Name = "ckbCOM2Modem";
			this.ckbCOM2Modem.Size = new System.Drawing.Size(264, 24);
			this.ckbCOM2Modem.TabIndex = 21;
			this.ckbCOM2Modem.Text = "Wait for modem command to open port";
			// 
			// txtCOM2NamedPipe
			// 
			this.txtCOM2NamedPipe.Enabled = false;
			this.txtCOM2NamedPipe.Location = new System.Drawing.Point(216, 176);
			this.txtCOM2NamedPipe.Name = "txtCOM2NamedPipe";
			this.txtCOM2NamedPipe.Size = new System.Drawing.Size(304, 20);
			this.txtCOM2NamedPipe.TabIndex = 20;
			this.txtCOM2NamedPipe.Text = "";
			this.txtCOM2NamedPipe.TextChanged += new System.EventHandler(this.txtCOM2NamedPipe_TextChanged);
			// 
			// cmbCOM2
			// 
			this.cmbCOM2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCOM2.Enabled = false;
			this.cmbCOM2.Location = new System.Drawing.Point(216, 88);
			this.cmbCOM2.Name = "cmbCOM2";
			this.cmbCOM2.Size = new System.Drawing.Size(304, 21);
			this.cmbCOM2.TabIndex = 14;
			this.cmbCOM2.TextChanged += new System.EventHandler(this.cmbCOM2_TextChanged);
			this.cmbCOM2.SelectedIndexChanged += new System.EventHandler(this.cmbCOM2_SelectedIndexChanged);
			// 
			// txtCOM2File
			// 
			this.txtCOM2File.Enabled = false;
			this.txtCOM2File.Location = new System.Drawing.Point(216, 144);
			this.txtCOM2File.Name = "txtCOM2File";
			this.txtCOM2File.Size = new System.Drawing.Size(304, 20);
			this.txtCOM2File.TabIndex = 19;
			this.txtCOM2File.Text = "";
			this.txtCOM2File.TextChanged += new System.EventHandler(this.txtCOM2File_TextChanged);
			// 
			// rdbCOM2Port
			// 
			this.rdbCOM2Port.Location = new System.Drawing.Point(40, 88);
			this.rdbCOM2Port.Name = "rdbCOM2Port";
			this.rdbCOM2Port.Size = new System.Drawing.Size(176, 24);
			this.rdbCOM2Port.TabIndex = 16;
			this.rdbCOM2Port.Text = "Physical computer serial port:";
			this.rdbCOM2Port.CheckedChanged += new System.EventHandler(this.rdbCOM2Port_CheckedChanged);
			// 
			// rdbCOM2None
			// 
			this.rdbCOM2None.Location = new System.Drawing.Point(40, 56);
			this.rdbCOM2None.Name = "rdbCOM2None";
			this.rdbCOM2None.TabIndex = 15;
			this.rdbCOM2None.Text = "None";
			this.rdbCOM2None.CheckedChanged += new System.EventHandler(this.rdbCOM2None_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnCOM1Select);
			this.groupBox1.Controls.Add(this.cmbCOM1);
			this.groupBox1.Controls.Add(this.txtCOM1File);
			this.groupBox1.Controls.Add(this.rdbCOM1None);
			this.groupBox1.Controls.Add(this.rdbCOM1File);
			this.groupBox1.Controls.Add(this.rdbCOM1Port);
			this.groupBox1.Controls.Add(this.txtCOM1NamedPipe);
			this.groupBox1.Controls.Add(this.rdbCOM1NamedPipe);
			this.groupBox1.Controls.Add(this.ckbCOM1Modem);
			this.groupBox1.Location = new System.Drawing.Point(32, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(624, 224);
			this.groupBox1.TabIndex = 22;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "COM1";
			// 
			// btnCOM1Select
			// 
			this.btnCOM1Select.Location = new System.Drawing.Point(520, 136);
			this.btnCOM1Select.Name = "btnCOM1Select";
			this.btnCOM1Select.TabIndex = 14;
			this.btnCOM1Select.Text = "Select";
			this.btnCOM1Select.Click += new System.EventHandler(this.btnCOM1Select_Click);
			// 
			// cmbCOM1
			// 
			this.cmbCOM1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCOM1.Enabled = false;
			this.cmbCOM1.Location = new System.Drawing.Point(224, 72);
			this.cmbCOM1.Name = "cmbCOM1";
			this.cmbCOM1.Size = new System.Drawing.Size(288, 21);
			this.cmbCOM1.TabIndex = 3;
			this.cmbCOM1.TextChanged += new System.EventHandler(this.cmbCOM1_TextChanged);
			this.cmbCOM1.SelectedIndexChanged += new System.EventHandler(this.cmbCOM1_SelectedIndexChanged);
			// 
			// txtCOM1File
			// 
			this.txtCOM1File.Enabled = false;
			this.txtCOM1File.Location = new System.Drawing.Point(224, 136);
			this.txtCOM1File.Name = "txtCOM1File";
			this.txtCOM1File.Size = new System.Drawing.Size(288, 20);
			this.txtCOM1File.TabIndex = 11;
			this.txtCOM1File.Text = "";
			this.txtCOM1File.TextChanged += new System.EventHandler(this.txtCOM1File_TextChanged);
			// 
			// rdbCOM1None
			// 
			this.rdbCOM1None.Location = new System.Drawing.Point(40, 40);
			this.rdbCOM1None.Name = "rdbCOM1None";
			this.rdbCOM1None.TabIndex = 7;
			this.rdbCOM1None.Text = "None";
			this.rdbCOM1None.CheckedChanged += new System.EventHandler(this.rdbCOM1None_CheckedChanged);
			// 
			// rdbCOM1File
			// 
			this.rdbCOM1File.Location = new System.Drawing.Point(40, 128);
			this.rdbCOM1File.Name = "rdbCOM1File";
			this.rdbCOM1File.TabIndex = 9;
			this.rdbCOM1File.Text = "Text File:";
			this.rdbCOM1File.CheckedChanged += new System.EventHandler(this.rdbCOM1File_CheckedChanged);
			// 
			// rdbCOM1Port
			// 
			this.rdbCOM1Port.Location = new System.Drawing.Point(40, 72);
			this.rdbCOM1Port.Name = "rdbCOM1Port";
			this.rdbCOM1Port.Size = new System.Drawing.Size(176, 24);
			this.rdbCOM1Port.TabIndex = 8;
			this.rdbCOM1Port.Text = "Physical computer serial port:";
			this.rdbCOM1Port.CheckedChanged += new System.EventHandler(this.rdbCOM1Port_CheckedChanged);
			// 
			// txtCOM1NamedPipe
			// 
			this.txtCOM1NamedPipe.Enabled = false;
			this.txtCOM1NamedPipe.Location = new System.Drawing.Point(224, 168);
			this.txtCOM1NamedPipe.Name = "txtCOM1NamedPipe";
			this.txtCOM1NamedPipe.Size = new System.Drawing.Size(288, 20);
			this.txtCOM1NamedPipe.TabIndex = 12;
			this.txtCOM1NamedPipe.Text = "";
			this.txtCOM1NamedPipe.TextChanged += new System.EventHandler(this.txtCOM1NamedPipe_TextChanged);
			// 
			// rdbCOM1NamedPipe
			// 
			this.rdbCOM1NamedPipe.Location = new System.Drawing.Point(40, 160);
			this.rdbCOM1NamedPipe.Name = "rdbCOM1NamedPipe";
			this.rdbCOM1NamedPipe.TabIndex = 10;
			this.rdbCOM1NamedPipe.Text = "Named Pipe:";
			this.rdbCOM1NamedPipe.CheckedChanged += new System.EventHandler(this.rdbCOM1NamedPipe_CheckedChanged);
			// 
			// ckbCOM1Modem
			// 
			this.ckbCOM1Modem.Enabled = false;
			this.ckbCOM1Modem.Location = new System.Drawing.Point(88, 96);
			this.ckbCOM1Modem.Name = "ckbCOM1Modem";
			this.ckbCOM1Modem.Size = new System.Drawing.Size(264, 24);
			this.ckbCOM1Modem.TabIndex = 13;
			this.ckbCOM1Modem.Text = "Wait for modem command to open port";
			// 
			// ofdMain
			// 
			this.ofdMain.DefaultExt = "vhd";
			this.ofdMain.Filter = "VHD files (*.vhd)|*.vhd|ISO files|*.iso (*.iso)|All files (*.*)|*.*";
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(440, 592);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(80, 23);
			this.btnApply.TabIndex = 9;
			this.btnApply.Text = "Apply";
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// eventLog1
			// 
			this.eventLog1.SynchronizingObject = this;
			// 
			// tmrStatus
			// 
			this.tmrStatus.Enabled = true;
			this.tmrStatus.Interval = 1000;
			this.tmrStatus.Tick += new System.EventHandler(this.tmrStatus_Tick);
			// 
			// btnVSProperty
			// 
			this.btnVSProperty.Location = new System.Drawing.Point(16, 592);
			this.btnVSProperty.Name = "btnVSProperty";
			this.btnVSProperty.Size = new System.Drawing.Size(136, 23);
			this.btnVSProperty.TabIndex = 10;
			this.btnVSProperty.Text = "Virtual Server Properties";
			this.btnVSProperty.Click += new System.EventHandler(this.btnVSProperty_Click);
			// 
			// lblScriptNote
			// 
			this.lblScriptNote.ForeColor = System.Drawing.Color.Red;
			this.lblScriptNote.Location = new System.Drawing.Point(24, 32);
			this.lblScriptNote.Name = "lblScriptNote";
			this.lblScriptNote.Size = new System.Drawing.Size(600, 23);
			this.lblScriptNote.TabIndex = 10;
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(24, 344);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(100, 32);
			this.label25.TabIndex = 11;
			this.label25.Text = "VS Script on this event";
			this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblVSScript
			// 
			this.lblVSScript.Location = new System.Drawing.Point(128, 344);
			this.lblVSScript.Name = "lblVSScript";
			this.lblVSScript.Size = new System.Drawing.Size(488, 48);
			this.lblVSScript.TabIndex = 12;
			// 
			// frmVMProperty
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(680, 637);
			this.Controls.Add(this.btnVSProperty);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.tabMain);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmVMProperty";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "VM Properties";
			this.Load += new System.EventHandler(this.frmVMProperty_Load);
			this.tbpGeneral.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.tbpMemory.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tkbMemory)).EndInit();
			this.tbpVHD.ResumeLayout(false);
			this.tbpSCSI.ResumeLayout(false);
			this.tabMain.ResumeLayout(false);
			this.tbpStatus.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.tbpScripts.ResumeLayout(false);
			this.tbpEvent.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.tbpDVD.ResumeLayout(false);
			this.tbpNetwork.ResumeLayout(false);
			this.tbpFloppy.ResumeLayout(false);
			this.tbpLPT.ResumeLayout(false);
			this.tbpCOM.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmVMProperty_Load(object sender, System.EventArgs e)
		{

			// Get VS
			myVS = Utility.getVS(thisServerAddress);

			// Get VM
			myVM = Utility.getVM(thisServerAddress, thisServerDisplayName);
			

			

			if ( myVM == null ) 
			{
				MessageBox.Show( "Unable to find this virtual machine.");
				return;
			}

			// VM Properties can be updated only when the VM is turned off.
//			if ( myVM.State != VMVMState.vmVMState_TurnedOff ) 
//			{
//				MessageBox.Show("The Virtual Machine is not turned off. Properties will not be saved.");
//			}

			// Note: The following sections should be moved to seperate methods. 
			// In this way, 'Reset to default' is easy.

	
			// Fill Status Tab
			FillTab_Status();

			// Fill General Tab
			FillTab_General();

		
			// Fill Memory Tab
			FillTab_Memory();


			// Fill Virtual Disk Drive Tab			
			FillTab_VHD();
			
			// Fill CDROM/DVD Tab
			FillTab_DVD();


			// Fill SCSI Controller Tab
			FillTab_SCSI();
			
		
			// Fill Network Adapter Tab
			FillTab_Network();


			// Fill Floppy Drive Tab
			FillTab_Floppy();


			// Fill COM Port Tab
			FillTab_COM();

			// Fill LPT Port Tab
			FillTab_LPT();

			// Fill Event tab
			FillTab_Event();

			// Fill Scripts Tab
			FillTab_Scripts();

			ConfigUpdated = false;

		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			if (ConfigUpdated) 
			{
				if ( MessageBox.Show("Are you sure to discard changes?", "Confirmation", 
					MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)  
				{
					this.Close();
				}
			}
		}

		private void tbpGeneral_Click(object sender, System.EventArgs e)
		{
		
		}

		private void tkbMemory_Scroll(object sender, System.EventArgs e)
		{
			txtMemory.Text = tkbMemory.Value.ToString();
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			// If Apply failed
			if (ConfigUpdated) 
			{
				btnApply_Click(this, new System.EventArgs());
			}

			if (ConfigUpdated) 
			{
				MessageBox.Show("There are errors in the configuration. Please check it.");
			}
			else 
			{
				this.Close();
			}

		}

		private void tbpCOM_Click(object sender, System.EventArgs e)
		{
		
		}

		private void lstVHD_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int SelectedItem = lstVHD.SelectedIndex + 1 ;

			txtVHDFilePath.Text = myVM.HardDiskConnections[SelectedItem].HardDisk.File;

			UpdateVHDChannel();

			if ( cmbVHDChannel.Text.IndexOf("No")>=0 ) 
			{
				btnAddVHD.Enabled = false;
			}

			cmbVHDChannel.Items.Add( ConvertVHDChannel(myVM.HardDiskConnections[SelectedItem].busType, 
				myVM.HardDiskConnections[SelectedItem].busNumber,
				myVM.HardDiskConnections[SelectedItem].deviceNumber) );

			cmbVHDChannel.Text = cmbVHDChannel.Items[cmbVHDChannel.Items.Count-1].ToString();

			btnUpdateVHD.Enabled = true;
			btnRemoveVHD.Enabled = true;

		}

		private void btnVHDSelect_Click(object sender, System.EventArgs e)
		{
			ofdMain.Filter = "VHD files (*.vhd)|*.vhd";
			if(ofdMain.ShowDialog() == DialogResult.OK)
			{
				//string VDDFile = txtVDDFilePath.Text;

				if( ofdMain.FileName != "") 
				{
					// Insert code to read the stream here.
					txtVHDFilePath.Text = ofdMain.FileName;
				}
			}

		}

		private void btnApply_Click(object sender, System.EventArgs e)
		{
			if (!ConfigUpdated) return;

			switch (tabMain.TabPages[tabMain.SelectedIndex].Text) 
			{
				case "General":
					applyGeneral();
					break;
				case "Memory":
					applyMemory();
					break;
				case "Network Adapter":
					applyNetworkAdapter();
					break;
				case "Harddisk":
					applyVHD();
					break;
				case "DVD/CDROM":
					applyDVD();
					break;
				case "SCSI Controller":
					applySCSIController();
					break;
				case "Floppy Drive":
					applyFloppyDrive();
					break;
				case "COM Port":
					applyCOMPort();
					break;
				case "LPT Port":
					applyLPTPort();
					break;
				default:
					break;
			}

			// Reset Pointer
			ConfigUpdated = false;

			btnApply.Enabled = false;
			
		}



		// Fill Tabs
		private void FillTab_Status() 
		{
			lblStatusVMName.Text = myVM.Name;
			lblStatusState.Text = Utility.ConvertVMStateToString(myVM.State);
			lblStatusVMCFile.Text = myVM.File;
			lblStatusRuntime.Text = Utility.ConvertUptimeToString(myVM.Accountant.UpTime);
			
			try
			{ 
				pboxVM.Image = Utility.GenerateThumbnail(myVM.Display);
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
				tmrStatus.Interval = 60000;
			}
			pboxCPU.Image = Utility.GenerateCPUUsage(myVM, myVS, CPUUsageSize.Large);


			if (myVM.State == VMVMState.vmVMState_Running || myVM.State == VMVMState.vmVMState_Paused ) 
			{

				lblStatusCPU.Text = "Average in last 60 seconds: " + Utility.AverageCPUUsage(myVM) + "%";

				lblStatusDiskIO.Text = Utility.ConvertByteToString(myVM.Accountant.DiskBytesRead.ToString()) + " read, " +
					Utility.ConvertByteToString(myVM.Accountant.DiskBytesWritten.ToString()) + " written";
				lblStatusNetworkIO.Text = Utility.ConvertByteToString(myVM.Accountant.NetworkBytesReceived.ToString()) + " received, " +
					Utility.ConvertByteToString(myVM.Accountant.NetworkBytesSent.ToString()) + " sent";

				// Debug, Is there a way to avoid this exception when there is no Additions installed?
				try 
				{
					lblStatusVMAdditions.Text = myVM.GuestOS.AdditionsVersion;
					if (myVM.GuestOS.IsHeartbeating) 
					{
						lblStatusHeartbeat.Text = "Received " + myVM.GuestOS.HeartbeatPercentage.ToString() + "% of expected heartbeats";
					}
					else 
					{
						lblStatusHeartbeat.Text = "n/a";
					}
					lblStatusGuestOS.Text = myVM.GuestOS.OSName;
				}
				catch 
				{
					// NO VM Additions installed
					lblStatusVMAdditions.Text = "n/a";
					lblStatusHeartbeat.Text = "n/a";
					lblStatusGuestOS.Text = "n/a";
				}


			}
		}
		private void FillTab_General()
		{
			txtVMName.Text = thisServerDisplayName;
			ckbRunAs.Checked = myVM.RunAsDefinedAccount;

			if (ckbRunAs.Checked) 
			{
				txtUsername.Text = myVM.AccountName;
				txtPassword.Text = "**********";
			}

			cmbStartAction.Text = ConvertStartupActionString(myVM.AutoStartAtLaunch);
			txtStartDelay.Text = myVM.AutoStartAtLaunchDelay.ToString();
			cmbShutdownAction.Text = ConvertShutdownActionString(myVM.ShutdownActionOnQuit);
			txtNotes.Text = myVM.Notes;

			if (!ckbRunAs.Checked) 
			{
				txtUsername.Enabled  = false;
				txtPassword.Enabled = false;
				cmbStartAction.Enabled = false;
				txtStartDelay.Enabled = false;	
			}
		}

		private void FillTab_Memory() 
		{
			txtMemory.Text = myVM.Memory.ToString();
			lblMemoryNote.Text = "The amount of memory can be from " +  myVS.MinimumMemoryPerVM + " MB through " + myVS.MaximumMemoryPerVM + " MB (" + myVS.SuggestedMaximumMemoryPerVM + " MB is the maximum recommended value).";
			tkbMemory.Minimum = myVS.MinimumMemoryPerVM;
			tkbMemory.Maximum = myVS.MaximumMemoryPerVM;
			tkbMemory.Value = myVM.Memory;
			tkbMemory.TickFrequency = myVS.MaximumMemoryPerVM/20;
		}
		private void FillTab_VHD() 
		{
			lstVHD.Items.Clear();
			foreach (IVMHardDiskConnection vhd in myVM.HardDiskConnections) 
			{
				lstVHD.Items.Add(vhd.HardDisk.File.ToString());
				lstVHD.SelectedIndex = -1;
			}


			btnUpdateVHD.Enabled = false;
			btnRemoveVHD.Enabled = false;

			ckbEnableUndoDisk.Checked = myVM.Undoable;

			
			UpdateVHDChannel();
			cmbVHDChannel.Text = cmbVHDChannel.Items[0].ToString();

			if ( cmbVHDChannel.Text.IndexOf("No")>=0 ) 
			{
				btnAddVHD.Enabled = false;
			}

		}
		private void FillTab_DVD() 
		{
			lstDVD.Items.Clear();
			for (int i=1; i<=myVM.DVDROMDrives.Count; i++) 
			{
				if (myVM.DVDROMDrives[i].Attachment == VMDVDDriveAttachmentType.vmDVDDrive_None) 
				{
					lstDVD.Items.Add("DVD/CDROM Drive " + i + " (" + myVM.DVDROMDrives[i].busNumber + ":" + myVM.DVDROMDrives[i].deviceNumber + "): No Media" );
				}
				if (myVM.DVDROMDrives[i].Attachment == VMDVDDriveAttachmentType.vmDVDDrive_Image ) 
				{
					lstDVD.Items.Add("DVD/CDROM Drive " + i + " (" + myVM.DVDROMDrives[i].busNumber + ":" + myVM.DVDROMDrives[i].deviceNumber + "): " + myVM.DVDROMDrives[i].ImageFile  );
				}
				if (myVM.DVDROMDrives[i].Attachment == VMDVDDriveAttachmentType.vmDVDDrive_HostDrive  ) 
				{
					lstDVD.Items.Add("DVD/CDROM Drive " + i + " (" + myVM.DVDROMDrives[i].busNumber + ":" + myVM.DVDROMDrives[i].deviceNumber + "): Host DVD/CDROM Drive " + myVM.DVDROMDrives[i].HostDriveLetter + ":");
				}
			}
			lstDVD.SelectedIndex = -1;


			if (myVM.DVDROMDrives.Count ==0) 
			{
				btnRemoveDVD.Enabled = false;
			}
			else 
			{	
				btnRemoveDVD.Enabled = true;
			}


			btnUpdateDVD.Enabled = false;
			btnRemoveDVD.Enabled = false;


			UpdateDVDHostDrive( );
			UpdateDVDChannel();

			cmbChannelDVD.Text = cmbChannelDVD.Items[0].ToString();
			cmbDVDHostDrive.Text = cmbDVDHostDrive.Items[0].ToString(); 
			
			if ( cmbChannelDVD.Text.IndexOf("No")>=0 || cmbDVDHostDrive.Text.IndexOf("No")>=0 ) 
			{
				btnAddDVD.Enabled = false;
			}


		}
		private void FillTab_SCSI() 
		{
			// Fill lstSCSI 
			lstSCSI.Items.Clear();
			string busShared = "(independent)";
			for (int i=0; i<myVM.SCSIControllers.Count; i++) 
			{
				if ( myVM.SCSIControllers[i+1].isBusShared) 
				{
					busShared = "(shared)";
				} 
				else 
				{
					busShared = "(independent)";
				}
				lstSCSI.Items.Add("SCSI Adapter " + i + "  ID: " + myVM.SCSIControllers[i+1].SCSIID.ToString() + "  " + busShared);				
			}

			cmbSCSIID.Items.Clear();
			cmbSCSIID.Items.Add("6");
			cmbSCSIID.Items.Add("7");
			cmbSCSIID.Text = "6";
			ckbSCSIShare.Checked = false;

			if (myVM.SCSIControllers.Count == 4) 
			{
				btnAddSCSI.Enabled = false;
			}

			btnUpdateSCSI.Enabled = false;
			btnRemoveSCSI.Enabled = false;

		}
		private void FillTab_Network() 
		{
			lstNIC.Items.Clear();
			for (int i=1; i<=myVM.NetworkAdapters.Count; i++) 
			{
				if (myVM.NetworkAdapters[i].virtualNetwork!=null) 
				{
					lstNIC.Items.Add("Network Adapter " + i + ": " + 
						"Connected to: " + myVM.NetworkAdapters[i].virtualNetwork.Name +
						" (Ethernet Address: " + myVM.NetworkAdapters[i].EthernetAddress + ")");
				} 
				else 
				{
					lstNIC.Items.Add("Network Adapter " + i + ": " + 
						"Connected to: " + "None" +
						" (Ethernet Address: " + myVM.NetworkAdapters[i].EthernetAddress + ")");
				}
			}

		
			cmbVNetwork.Items.Clear();
			cmbVNetwork.Items.Add("Not Connected");
			for (int i=1; i<=myVS.VirtualNetworks.Count; i++) 
			{
				cmbVNetwork.Items.Add(myVS.VirtualNetworks[i].Name);
			}
			cmbVNetwork.Text = cmbVNetwork.Items[0].ToString();

			ckbNICMACStatic.Checked = false;
			txtNICMAC.Text = "";
			txtNICMAC.Enabled = false;

		}
		private void FillTab_Floppy() 
		{
			if (myVM.FloppyDrives[1].Attachment  == VMFloppyDriveAttachmentType.vmFloppyDrive_HostDrive) 
			{
				cmbVFDD.Items.Add("Drive " + myVM.FloppyDrives[1].HostDriveLetter);
				cmbVFDD.Text = "Drive " + myVM.FloppyDrives[1].HostDriveLetter;
				cmbVFDD.Enabled = true;
				rdbPhysicalDrive.Checked = true;
			} 
			else if (myVM.FloppyDrives[1].Attachment  == VMFloppyDriveAttachmentType.vmFloppyDrive_Image ) 
			{
				rdbVFDImage.Checked = true;
				txtVFDPath.Text = myVM.FloppyDrives[1].ImageFile;
				txtVFDPath.Enabled = true;
			} 
			else 
			{
				rdbNoMedia.Checked = true;
			}
			
		}
		private void FillTab_COM() 
		{
			for (int i=1; i<=(myVS.HostInfo.SerialPorts.Length/5); i++) 
			{
				cmbCOM1.Items.Add("COM"+i);
				cmbCOM2.Items.Add("COM"+i);
			}
			cmbCOM1.Text = "COM1";
			cmbCOM2.Text = "COM2";

			switch (myVM.SerialPorts[1].Type) 
			{
				case VMSerialPortType.vmSerialPort_Null:
					rdbCOM1None.Checked = true;	
					break;
				case VMSerialPortType.vmSerialPort_HostPort:
					rdbCOM1Port.Checked = true;
					cmbCOM1.Enabled = true;
					cmbCOM1.Text = "COM1";
					ckbCOM1Modem.Checked = myVM.SerialPorts[1].connectImmediately;
					break;
				case VMSerialPortType.vmSerialPort_TextFile:
					rdbCOM1File.Checked = true;
					txtCOM1File.Enabled = true;
					txtCOM1File.Text = myVM.SerialPorts[1].Name.ToString();
					break;
				case VMSerialPortType.vmSerialPort_NamedPipe:
					rdbCOM1NamedPipe.Checked = true;
					txtCOM1NamedPipe.Enabled = true;
					txtCOM1NamedPipe.Text = myVM.SerialPorts[1].Name.ToString();
					break;
				default:
					break;
			}

			switch (myVM.SerialPorts[2].Type) 
			{
				case VMSerialPortType.vmSerialPort_Null:
					rdbCOM2None.Checked = true;	
					break;
				case VMSerialPortType.vmSerialPort_HostPort:
					rdbCOM2Port.Checked = true;
					cmbCOM2.Enabled = true;
					cmbCOM2.Text = "COM2";
					ckbCOM2Modem.Checked = myVM.SerialPorts[2].connectImmediately;
					break;
				case VMSerialPortType.vmSerialPort_TextFile:
					rdbCOM2File.Checked = true;
					txtCOM2File.Enabled = true;
					txtCOM2File.Text = myVM.SerialPorts[2].Name.ToString();
					break;
				case VMSerialPortType.vmSerialPort_NamedPipe:
					rdbCOM2NamedPipe.Checked = true;
					txtCOM2NamedPipe.Enabled = true;
					txtCOM2NamedPipe.Text = myVM.SerialPorts[2].Name.ToString();
					break;
				default:
					break;
			}		
		}
		private void FillTab_LPT() 
		{
			if (myVM.ParallelPorts[1].Name!="") 
			{
				ckbLPT.Checked = true;
				ckbLPT.Text = myVM.ParallelPorts[1].Name;
			}
		}

		private void FillTab_Event() 
		{
			// Load Events from System log.
			eventLog1.MachineName = thisServerAddress;
			eventLog1.Log = "Virtual Server";
			eventLog1.Source = "Virtual Server";
			cmbEventMax.Text = cmbEventMax.Items[0].ToString();

			btnRefreshEvent_Click(this, new System.EventArgs());
		}

		private void FillTab_Scripts() 
		{
			// if VS disabled script on VM, disable all controls
			if (myVS.VMScriptsEnabled) 
			{
				// Enable all controls
				lblScriptNote.Text = "";
				lvScripts.Enabled = true;
			}
			else 
			{
				// Disable all controls
				lblScriptNote.Text = "Virtual Server disabled scripts attached to virtual machines.";
				lvScripts.Enabled = false;
			}

			// Display 
			string[] myItems = new string[] {"",""};

			string[] sVMEvent = new string[] {	"When Virtual Server starts",
												 "When Virtual Server stops",
												 "When this VM is turned on",
												 "When this VM is restored",
												 "When this VM is saved and turned off",
												 "When this VM is turned off (and not saved)",
												 "When this VM is turned off within the guest environment",
												 "When this VM is reset",
												 "When this VM has no heartbeat detected",
												 "When this VM experiences a guest processor error",
												 "When this VM receives a warning due to low disk space on the physical computer",
												 "When this VM receives an error due to low disk space on the physical computer"
											 };

			ListViewItem lvi = null;

			lvScripts.Items.Clear();
			for (int i=2; i<12; i++) 
			{
				myItems[0] = sVMEvent[i];
				myItems[1] = myVM.FetchScriptByEvent( (VMEventType)i );
				lvi = new ListViewItem(myItems);
				lvScripts.Items.Add(lvi);
			}

			btnScriptAttach.Enabled = false;
			btnScriptRemove.Enabled = false;
			btnScriptUpdate.Enabled = false;
			lblScriptEvent.Text = "";
			lblScriptEvent.Enabled = false;
			txtScript.Text = "";
			txtScript.Enabled = false;

		}
			
	
		private void applyGeneral() 
		{
			// Update name
			if (txtVMName.Text != myVM.Name) 
			{

				// Rename record in XML and reload tab
//				XmlDocument xmlDoc = new XmlDocument();
//				// Load config.xml
//				xmlDoc.Load(CONFIGFILE);
				// Read last TabIndex fromXml
				XmlNodeList nodeList = frmMain.xmlConfig.SelectNodes("//VirtualServer");

				
				// Find and delete this node from config.xml. 
				foreach (XmlNode xmlNode in nodeList) 
				{	
					if ( myVM.Name == xmlNode.SelectSingleNode("ServerDisplayName").InnerText  &&
						thisServerAddress == xmlNode.SelectSingleNode("ServerAddress").InnerText ) 
					{
						try 
						{
							myVM.Name = txtVMName.Text;
							xmlNode.SelectSingleNode("ServerDisplayName").InnerText  = txtVMName.Text;
						}
						catch (Exception err) 
						{	
							txtVMName.Focus();
							MessageBox.Show(err.Message);
							return;
						}	
					}
				}
//				xmlDoc.Save(CONFIGFILE);
				frmMain.touchTab();
				frmMain.conf.ConfigUpdated = true;

			}

			// Update RUNAS
			if (ckbRunAs.Checked) 
			{
				if (UpdateRunAs) 
				{
					try 
					{
						myVM.SetAccountNameAndPassword(txtUsername.Text, txtPassword.Text);
					}
					catch (Exception err) 
					{
						txtVMName.Focus();
						MessageBox.Show("Hit" + err.Message);
						return;
					}
				}

				try 
				{
					myVM.AutoStartAtLaunch = ConvertStringStartupAction(cmbStartAction.Text);
					myVM.AutoStartAtLaunchDelay = int.Parse(txtStartDelay.Text);
					myVM.RunAsDefinedAccount = true;
				}
				catch (Exception err)
				{
					txtVMName.Focus();
					MessageBox.Show(err.Message);
					return;
				}
			}
			
			// Update Shutdown action
			if (ConvertStringShutdownAction(cmbShutdownAction.Text) != myVM.ShutdownActionOnQuit) 
			{
				try
				{
					myVM.ShutdownActionOnQuit = ConvertStringShutdownAction(cmbShutdownAction.Text);
				} 
				catch(Exception err)
				{
					txtVMName.Focus();
					MessageBox.Show(err.Message);
					return;
				}
			}


			// Update Notes
			if (txtNotes.Text != myVM.Notes) 
			{
				try 
				{
					myVM.Notes = txtNotes.Text;}
				catch(Exception err)
				{
					txtVMName.Focus();
					MessageBox.Show(err.Message);
					return;
				}
			}
			
		}

		private void applyMemory() 
		{
			if (txtMemory.Text != myVM.Memory.ToString()) 
			{
				try 
				{
					myVM.Memory = int.Parse(txtMemory.Text);
				}
				catch(Exception err) 
				{
					txtMemory.Focus();
					MessageBox.Show(err.Message);
				}
			}
		}
		private void applyVHD() 
		{
			myVM.Undoable = ckbEnableUndoDisk.Checked;
		}
		private void applyDVD() 
		{

		}
		private void applyNetworkAdapter() 
		{
			FillTab_Network();
		}
		private void applySCSIController() 
		{

		}
		private void applyFloppyDrive() 
		{			
			if (rdbNoMedia.Checked) 
			{
				try
				{
					if (myVM.FloppyDrives[1].Attachment  == VMFloppyDriveAttachmentType.vmFloppyDrive_HostDrive) 
					{
						myVM.FloppyDrives[1].ReleaseHostDrive();
					}

					if (myVM.FloppyDrives[1].Attachment  == VMFloppyDriveAttachmentType.vmFloppyDrive_Image) 
					{
						myVM.FloppyDrives[1].ReleaseImage();
					}
					
				} 
				catch (Exception err) 
				{
					tbpFloppy.Focus();
					MessageBox.Show(err.Message);
					return;
				}
			}

			if (rdbPhysicalDrive.Checked) 
			{
				try 
				{
					myVM.FloppyDrives[1].AttachHostDrive("A");
				} 
				catch (Exception err) 
				{
					tbpFloppy.Focus();
					MessageBox.Show(err.Message);
					return;
				}
			}
			
			if (rdbVFDImage.Checked) 
			{
				try 
				{
					myVM.FloppyDrives[1].AttachImage(txtVFDPath.Text);
				} 
				catch (Exception err) 
				{
					tbpFloppy.Focus();
					MessageBox.Show(err.Message);
					return;
				}
			}


		}
		private void applyCOMPort() 
		{
			// COM1 Port
			if (rdbCOM1None.Checked) 
			{
				try
				{
					myVM.SerialPorts[1].Configure(VMSerialPortType.vmSerialPort_Null, "COM1", false);
				}
				catch (Exception err) 
				{
					tbpCOM.Focus();
					MessageBox.Show(err.Message);
					return;
				}
			}
			if (rdbCOM1Port.Checked) 
			{
				try 
				{
					myVM.SerialPorts[1].Configure(VMSerialPortType.vmSerialPort_HostPort, "COM1", ckbCOM1Modem.Checked);
				}
				catch (Exception err) 
				{
					tbpCOM.Focus();
					MessageBox.Show(err.Message);
					return;
				}
			}
			if (rdbCOM1File.Checked) 
			{
				try 
				{
					myVM.SerialPorts[1].Configure(VMSerialPortType.vmSerialPort_TextFile, txtCOM1File.Text, true);
				}
				catch (Exception err) 
				{
					tbpCOM.Focus();
					MessageBox.Show(err.Message);
					return;
				}
			}
			if (rdbCOM1NamedPipe.Checked) 
			{
				try
				{
					myVM.SerialPorts[1].Configure(VMSerialPortType.vmSerialPort_NamedPipe, txtCOM1NamedPipe.Text, true);
				}
				catch (Exception err) 
				{
					tbpCOM.Focus();
					MessageBox.Show(err.Message);
					return;
				}
			}


			// COM2 Port
			if (rdbCOM2None.Checked) 
			{
				try
				{
					myVM.SerialPorts[2].Configure(VMSerialPortType.vmSerialPort_Null, "COM2", false);
				}
				catch (Exception err) 
				{
					tbpCOM.Focus();
					MessageBox.Show(err.Message);
					return;
				}
			}
			if (rdbCOM2Port.Checked) 
			{
				try 
				{
					myVM.SerialPorts[2].Configure(VMSerialPortType.vmSerialPort_HostPort, "COM2", ckbCOM1Modem.Checked);
				}
				catch (Exception err) 
				{
					tbpCOM.Focus();
					MessageBox.Show(err.Message);
					return;
				}
			}
			if (rdbCOM2File.Checked) 
			{
				try
				{
					myVM.SerialPorts[2].Configure(VMSerialPortType.vmSerialPort_TextFile, txtCOM2File.Text, true);
				}
				catch (Exception err) 
				{
					tbpCOM.Focus();
					MessageBox.Show(err.Message);
					return;
				}
			}
			if (rdbCOM2NamedPipe.Checked) 
			{
				try
				{
					myVM.SerialPorts[2].Configure(VMSerialPortType.vmSerialPort_NamedPipe, txtCOM2NamedPipe.Text, true);
				}
				catch (Exception err) 
				{
					tbpCOM.Focus();
					MessageBox.Show(err.Message);
					return;
				}
			}



		}
		private void applyLPTPort() 
		{
			// Add LPT Port
			if (myVM.ParallelPorts[1].Name=="" && ckbLPT.Checked) 
			{
				try
				{
					myVM.ParallelPorts[1].Name = ckbLPT.Text;
				}
				catch (Exception err)
				{
					tbpLPT.Focus();
					MessageBox.Show(err.Message);
					return;
				}
			}

			// Remove LPT Port
			if (myVM.ParallelPorts[1].Name!="" && !ckbLPT.Checked) 
			{
				try
				{
					myVM.ParallelPorts[1].Name = "";
				}
				catch (Exception err)
				{
					tbpLPT.Focus();
					MessageBox.Show(err.Message);
					return;
				}
			}

		}




		private void ckbRunAs_CheckedChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
			if (ckbRunAs.Checked) 
			{
				txtUsername.Enabled = true;
				txtPassword.Enabled = true;
				txtStartDelay.Enabled = true;
				cmbStartAction.Enabled = true;
			} 
			else
			{
				txtUsername.Enabled = false;
				txtPassword.Enabled = false;
				txtStartDelay.Enabled = false;
				cmbStartAction.Enabled = false;
			}
		}

		private string ConvertShutdownActionString(VMShutdownAction VMAction) 
		{
			string sVMAction = "";
			switch (VMAction) 
			{
				case VMShutdownAction.vmShutdownAction_Save:
					sVMAction = "Save State";
					break;
				case VMShutdownAction.vmShutdownAction_Shutdown:
					sVMAction = "Shutdown";
					break;
				case VMShutdownAction.vmShutdownAction_TurnOff:
					sVMAction = "Turn Off";
					break;										  
			}
			return sVMAction;
		}

		private VMShutdownAction ConvertStringShutdownAction(string VMAction) 
		{
			VMShutdownAction vmVMAction = VMShutdownAction.vmShutdownAction_Save ;
			switch (VMAction) 
			{
				case "Save State":
					vmVMAction = VMShutdownAction.vmShutdownAction_Save ;
					break;
				case "Shutdown":
					vmVMAction = VMShutdownAction.vmShutdownAction_Shutdown;
					break;
				case "Turn Off":
					vmVMAction = VMShutdownAction.vmShutdownAction_TurnOff;
					break;										  
			}
			return vmVMAction;
		}


		private string ConvertStartupActionString(VMAutoStartType VMAction) 
		{
			string sVMAction = "";
			switch (VMAction) 
			{
				case VMAutoStartType.vmAutoStart_Always :
					sVMAction = "Always automatically turn on virtual machine";
					break;
				case VMAutoStartType.vmAutoStart_IfRunningAtQuit :
					sVMAction = "Automatically turn on virtual machine if was running when Virtual Server stopped";
					break;
				case VMAutoStartType.vmAutoStart_Never :
					sVMAction = "Never automatically turn on virtual machine";
					break;										  
			}
			return sVMAction;
		}

		private VMAutoStartType ConvertStringStartupAction(string VMAction) 
		{
			VMAutoStartType vmVMAction = VMAutoStartType.vmAutoStart_IfRunningAtQuit  ;
			switch (VMAction) 
			{
				case "Always automatically turn on virtual machine":
					vmVMAction = VMAutoStartType.vmAutoStart_Always ;
					break;
				case  "Automatically turn on virtual machine if was running when Virtual Server stopped":
					vmVMAction = VMAutoStartType.vmAutoStart_IfRunningAtQuit;
					break;
				case  "Never automatically turn on virtual machine":
					vmVMAction = VMAutoStartType.vmAutoStart_Never;
					break;										  
			}
			return vmVMAction;
		}




		private void btnSelectNew_Click(object sender, System.EventArgs e)
		{
			ofdMain.Filter = "VHD files (*.vhd)|*.vhd";
			if(ofdMain.ShowDialog() == DialogResult.OK)
			{
				//string VDDFile = txtNewVDDFilePath.Text;

				if( ofdMain.FileName != "") 
				{
					// Insert code to read the stream here.
					txtVHDFilePath.Text = ofdMain.FileName;
				}
			}
		}

		private void txtMemory_Leave(object sender, System.EventArgs e)
		{
			int thisMemory = int.Parse(txtMemory.Text);
			if (thisMemory < myVS.MaximumMemoryPerVM && thisMemory > myVS.MinimumMemoryPerVM ) 
			{
				tkbMemory.Value = thisMemory;
			} 
			else 
			{
				MessageBox.Show("Please enter a value between " + myVS.MinimumMemoryPerVM + " and " + myVS.MaximumMemoryPerVM + ".");
				txtMemory.Focus();
			}
		}



		private void txtVMName_TextChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void txtUsername_TextChanged(object sender, System.EventArgs e)
		{
			UpdateRunAs = true;
			ConfigUpdated = true;
		}

		private void txtPassword_TextChanged(object sender, System.EventArgs e)
		{
			UpdateRunAs = true;
			ConfigUpdated = true;
		}

		private void txtStartDelay_TextChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
			if (Regex.IsMatch(txtStartDelay.Text,"[^0-9]")) 
			{
				MessageBox.Show("Please enter a number.");
				txtStartDelay.Text = myVM.AutoStartAtLaunchDelay.ToString();
				txtStartDelay.Focus();
			}

		}

		private void cmbStartAction_TextChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void cmbShutdownAction_TextChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void txtNotes_TextChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void txtMemory_TextChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;

			if (Regex.IsMatch(txtMemory.Text,"[^0-9]")) 
			{
				MessageBox.Show("Please enter a number.");
				txtMemory.Text = myVM.Memory.ToString();
				tkbMemory.Value = myVM.Memory;
				txtMemory.Focus();
			}

		}



		private void ckbLPT_CheckedChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}


		private void rdbPhysicalDrive_CheckedChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
			if (rdbPhysicalDrive.Checked) 
			{
				cmbVFDD.Enabled = true;
			} 
			else 
			{
				cmbVFDD.Enabled = false;
			}
		}

		private void rdbVFDImage_CheckedChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;

			if (rdbVFDImage.Checked) 
			{
				txtVFDPath.Enabled = true;
				btnVFDSelect.Enabled = true;
			}
			else 
			{
				txtVFDPath.Enabled = false;
				btnVFDSelect.Enabled = false;
			}
		}

		private void btnVFDSelect_Click(object sender, System.EventArgs e)
		{	
			ofdMain.Filter = "Virtual Floppy Disk files (*.vfd)|*.vfd";
			if(ofdMain.ShowDialog() == DialogResult.OK)
			{
				if( ofdMain.FileName != "") 
				{
					// Insert code to read the stream here.
					txtVFDPath.Text = ofdMain.FileName;
				}
			}
		}

		private void btnAddVHD_Click(object sender, System.EventArgs e)
		{
			// If Channel is empty or in use, Prompt for input
			if (cmbVHDChannel.Text.IndexOf("Current")>=0 || cmbVHDChannel.Text.IndexOf("No")>=0 ) 
			{
				MessageBox.Show("Please select a valid channel");
				return;
			}

			// If Channel is in use. Prompt for input
			if (txtVHDFilePath.Text =="") 
			{
				MessageBox.Show("Please enter a valid Virtual Disk file");
				return;
			}

			// Add it.
			try 
			{
				myVM.AddHardDiskConnection( txtVHDFilePath.Text, 
					getChannelBusType(cmbVHDChannel.Text), 
					getChannelBusNumber(cmbVHDChannel.Text),
					getChannelDeviceNumber(cmbVHDChannel.Text) );
				
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}

			FillTab_VHD();
			UpdateDVDChannel();
		}

		private void rdbCOM1None_CheckedChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
			if (rdbCOM1None.Checked) 
			{
				cmbCOM1.Enabled = false;
				ckbCOM1Modem.Enabled = false;
				txtCOM1File.Enabled = false;
				txtCOM1NamedPipe.Enabled = false;
			}
		}

		private void rdbCOM1Port_CheckedChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
			if (rdbCOM1Port.Checked) 
			{
				cmbCOM1.Enabled = true;
				ckbCOM1Modem.Enabled = true;
				txtCOM1File.Enabled = false;
				txtCOM1NamedPipe.Enabled = false;
			}
		}

		private void rdbCOM1File_CheckedChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
			if (rdbCOM1File.Checked) 
			{
				cmbCOM1.Enabled = false;
				ckbCOM1Modem.Enabled = false;
				txtCOM1File.Enabled = true;
				txtCOM1NamedPipe.Enabled = false;				
			}
		}

		private void rdbCOM1NamedPipe_CheckedChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
			if (rdbCOM1NamedPipe.Checked) 
			{
				cmbCOM1.Enabled = false;
				ckbCOM1Modem.Enabled = false;
				txtCOM1File.Enabled = false;
				txtCOM1NamedPipe.Enabled = true;
			}
		}

		private void rdbCOM2None_CheckedChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
			if (rdbCOM2None.Checked) 
			{
				cmbCOM2.Enabled = false;
				ckbCOM2Modem.Enabled = false;
				txtCOM2File.Enabled = false;
				txtCOM2NamedPipe.Enabled = false;
			}
		}

		private void rdbCOM2Port_CheckedChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
			if (rdbCOM2Port.Checked) 
			{
				cmbCOM2.Enabled = true;
				ckbCOM2Modem.Enabled = true;
				txtCOM2File.Enabled = false;
				txtCOM2NamedPipe.Enabled = false;
			}
		}

		private void rdbCOM2File_CheckedChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
			if (rdbCOM2File.Checked) 
			{
				cmbCOM2.Enabled = false;
				ckbCOM2Modem.Enabled = false;
				txtCOM2File.Enabled = true;
				txtCOM2NamedPipe.Enabled = false;				
			}
		}

		private void rdbCOM2NamedPipe_CheckedChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
			if (rdbCOM2NamedPipe.Checked) 
			{
				cmbCOM2.Enabled = false;
				ckbCOM2Modem.Enabled = false;
				txtCOM2File.Enabled = false;
				txtCOM2NamedPipe.Enabled = true;
			}
		}

		private void btnCOM1Select_Click(object sender, System.EventArgs e)
		{
			ofdMain.Filter = "All Files (*.*)|*.*";
			if(ofdMain.ShowDialog() == DialogResult.OK)
			{
				if( ofdMain.FileName != "") 
				{
					// Insert code to read the stream here.
					txtCOM1File.Text = ofdMain.FileName;
				}
			}
		}

		private void btnCOM2Select_Click(object sender, System.EventArgs e)
		{
			ofdMain.Filter = "All Files (*.*)|*.*";
			if(ofdMain.ShowDialog() == DialogResult.OK)
			{
				if( ofdMain.FileName != "") 
				{
					// Insert code to read the stream here.
					txtCOM2File.Text = ofdMain.FileName;
				}
			}
		}

		private void btnUpdateVHD_Click(object sender, System.EventArgs e)
		{
			// Remove it and then add it.
			try 
			{
				myVM.RemoveHardDiskConnection(myVM.HardDiskConnections[lstVHD.SelectedIndex+1]);
				myVM.AddHardDiskConnection( txtVHDFilePath.Text, 
					getChannelBusType(cmbVHDChannel.Text), 
					getChannelBusNumber(cmbVHDChannel.Text),
					getChannelDeviceNumber(cmbVHDChannel.Text) );
				myVM.Undoable = ckbEnableUndoDisk.Checked;
				
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
			FillTab_VHD();
			UpdateDVDChannel();
		}


		private void UpdateVHDChannel() 
		{
			cmbVHDChannel.Items.Clear();

			// Display all IDE channels 
			int[,] IDEarray = new int[4,2] { {0, 0}, {0, 0}, {0, 0}, {0, 0} };
			string Channel = "";
			for (int i=1; i<=myVM.HardDiskConnections.Count; i++)
			{
				if (myVM.HardDiskConnections[i].busType == VMDriveBusType.vmDriveBusType_IDE) 
				{
					IDEarray[myVM.HardDiskConnections[i].busNumber, myVM.HardDiskConnections[i].deviceNumber] = 1;
				}
			}
			for (int i=1; i<=myVM.DVDROMDrives.Count; i++) 
			{
				IDEarray[myVM.DVDROMDrives[i].busNumber, myVM.DVDROMDrives[i].deviceNumber] = 1;
			}

			// Fill ComboBox for IDE channels
			for (int i=0; i<2; i++) 
			{
				Channel = (i==0)?"Primary Channel":"Secondary Channel";
				
				// For each device
				for (int j=0; j<2; j++) 
				{
					// In use or Not in use?
					if ( IDEarray[i,j] == 0 ) 
					{
						cmbVHDChannel.Items.Add(Channel + " (" + j + ")");
						
					}
					else 
					{
						//cmbChannel.Items.Add(Channel + " (" + j + ") (IN USE)");
						//cmbChannelNewVHD.Items.Add(Channel + " (" + j + ") (IN USE)");
					}	
				}
			}

			// Display all SCSI Channels
			int[,] SCSIarray = new int[myVM.SCSIControllers.Count,7];

			// Initialize the value to 0;
			for (int i=0; i<myVM.SCSIControllers.Count; i++) 
			{
				for (int j=0; j<=6; j++) 
				{
					SCSIarray[i,j]=0;
				}
			}

			// Loop, if the current SCSI adapter is occupied, mark it.
			for (int i=0; i<myVM.HardDiskConnections.Count; i++)
			{
				if (myVM.HardDiskConnections.Count>0 && myVM.HardDiskConnections[i+1].busType == VMDriveBusType.vmDriveBusType_SCSI) 
				{
					SCSIarray[myVM.HardDiskConnections[i+1].busNumber, myVM.HardDiskConnections[i+1].deviceNumber] = 1;
				}
			}

			// Fill ComboBox for SCSI Channels
			for (int i=0; i<myVM.SCSIControllers.Count; i++) 
			{
				Channel = "SCSI " + i;
				
				// For each device
				for (int j=0; j<=6; j++) 
				{
					// In use or Not in use?
					if ( SCSIarray[i,j] == 0 ) 
					{
						cmbVHDChannel.Items.Add(Channel + " ID " + j );
					}
					else 
					{
						//cmbChannel.Items.Add(Channel + " ID " + j + " (IN USE)");
						//cmbChannelNewVHD.Items.Add(Channel + " ID " + j + " (IN USE)");
					}	
				}
			}
			
			if (cmbVHDChannel.Items.Count>0) 
			{
				cmbVHDChannel.Text = cmbVHDChannel.Items[0].ToString();
			}
			else 
			{
				cmbVHDChannel.Items.Add("No IDE or SCSI Channel Available");
				cmbVHDChannel.Text = "No IDE or SCSI Channel Available";
			}

			if (cmbVHDChannel.Items.Count == 4) 
			{	
				btnAddVHD.Enabled = false;
			}
			else 
			{
				btnAddVHD.Enabled = true;
			}
		}

		private void UpdateDVDChannel() 
		{
			// DVD/CDROM drive can be connected to IDE channel only.


			cmbChannelDVD.Items.Clear();
			// Display all IDE channels 
			int[,] IDEarray = new int[4,2] { {0, 0}, {0, 0}, {0, 0}, {0, 0} };
			string Channel = "";
			for (int i=1; i<=myVM.HardDiskConnections.Count; i++)
			{
				if (myVM.HardDiskConnections[i].busType == VMDriveBusType.vmDriveBusType_IDE) 
				{
					IDEarray[myVM.HardDiskConnections[i].busNumber, myVM.HardDiskConnections[i].deviceNumber] = 1;
				}
			}
			for (int i=1; i<=myVM.DVDROMDrives.Count; i++) 
			{
				IDEarray[myVM.DVDROMDrives[i].busNumber, myVM.DVDROMDrives[i].deviceNumber] = 1;
			}

			// Fill ComboBox for IDE Channels
			for (int i=0; i<2; i++) 
			{
				Channel = (i==0)?"Primary Channel":"Secondary Channel";
				
				// For each device
				for (int j=0; j<2; j++) 
				{
					// In use or Not in use?
					if ( IDEarray[i,j] == 0 ) 
					{
						cmbChannelDVD.Items.Add(Channel + " (" + j + ")");
					}
					else 
					{
						//cmbChannelDVD.Items.Add(Channel + " (" + j + ") (IN USE)");
					}	
				}
			}
			
			if (cmbChannelDVD.Items.Count>0) 
			{
				cmbChannelDVD.Text = cmbChannelDVD.Items[0].ToString();
			}
			else 
			{
				cmbChannelDVD.Items.Add("No IDE Channel Available");
				cmbChannelDVD.Text = "No IDE Channel Available";
			}

			if (cmbChannelDVD.Items.Count == 4) 
			{	
				btnAddDVD.Enabled = false;
			}
			else 
			{
				btnAddDVD.Enabled = true;
			}

		}

		private void UpdateDVDHostDrive() 
		{
			
			cmbDVDHostDrive.Items.Clear();
			bool inUse = false;

			foreach ( Object vdvd in (IEnumerable)myVS.HostInfo.DVDDrives) 
			{
				inUse = false;

				for (int i=1; i<=myVM.DVDROMDrives.Count; i++) 
				{		
					if (myVM.DVDROMDrives[i].Attachment == VMDVDDriveAttachmentType.vmDVDDrive_HostDrive &&
						myVM.DVDROMDrives[i].HostDriveLetter == ((char)(int.Parse(vdvd.ToString()))).ToString() ) 
					{
						inUse = true;
						break;
					} 
				}

				if (inUse) 
				{

					//cmbDVDHostDrive.Items.Add("Drive " +  (char)(int.Parse(vdvd.ToString()))  + ": (IN USE)" );
				}
				else
				{
					cmbDVDHostDrive.Items.Add("Drive " +  (char)(int.Parse(vdvd.ToString()))  + ":" );
				}
				
			}
			
			if (cmbDVDHostDrive.Items.Count>0) 
			{
				cmbDVDHostDrive.Text = cmbDVDHostDrive.Items[0].ToString();
			}
			else 
			{
				cmbDVDHostDrive.Items.Add("No Host Drive Available");
				cmbDVDHostDrive.Text = "No Host Drive Available";
			}


		}


		private VMDriveBusType getChannelBusType(string channel) 
		{
			if ( channel.IndexOf("SCSI")>-1 ) 
			{
				return VMDriveBusType.vmDriveBusType_SCSI;
			} 
			else 
			{
				return VMDriveBusType.vmDriveBusType_IDE;
			}

		}

		private int getChannelBusNumber(string channel)
		{
			if (channel.IndexOf("Primary")>-1) 
			{
				// Return 0, if there is a 'Primary'
				return 0;
			} 
			else if (channel.IndexOf("Secondary")>-1) 
			{
				// Return 1, if there is a 'Secondary'
				return 1;
			} 
			else 
			{
				// Return SCSI channel number
				return int.Parse(channel.Substring(5,1));
			}
		}

		private int	getChannelDeviceNumber(string channel)
		{
			
			if (channel.IndexOf("(")>-1) 
			{
				// Return x in the 'Primary Channel (x)' or 'Secondary Channel (x)'
				return int.Parse(channel.Substring( channel.IndexOf("(") + 1, 1));
			}
			else  
			{
				// Return x in the 'SCSI n ID x'
				return int.Parse( channel.Substring( channel.IndexOf("ID") + 2, 1) );
			}

		}

		


		private void btnRemoveVHD_Click(object sender, System.EventArgs e)
		{
			try 
			{
				myVM.RemoveHardDiskConnection(myVM.HardDiskConnections[lstVHD.SelectedIndex+1]);
			}
			catch (Exception err) 
			{
				MessageBox.Show(err.Message);
			}
			FillTab_VHD();
			UpdateDVDChannel();
		}

		private void cmbChannelNewVHD_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void txtNewVHDFilePath_TextChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void cmbChannel_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
			if ( cmbVHDChannel.Text.IndexOf("No")>=0) 
			{
				btnAddVHD.Enabled = false;
			}
			else 
			{
				btnAddVHD.Enabled = true;
			}
		}

		private void txtVHDFilePath_TextChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void cmbCOM1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void txtCOM1File_TextChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void txtCOM1NamedPipe_TextChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void cmbCOM2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void txtCOM2File_TextChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void txtCOM2NamedPipe_TextChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void rdbNoMedia_CheckedChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void cmbVFDD_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void txtVFDPath_TextChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void cmbChannelDVD_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
			if (cmbChannelDVD.Text.IndexOf("No")>=0 || cmbDVDHostDrive.Text.IndexOf("No")>=0) 
			{
				btnAddDVD.Enabled = false;
			}
			else
			{
				btnAddDVD.Enabled = true;
			}
		}
		private void cmbDVDHostDrive_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
			if (cmbDVDHostDrive.Text.IndexOf("No")>=0 || cmbChannelDVD.Text.IndexOf("No")>=0 ) 
			{
				btnAddDVD.Enabled = false;
			}
			else
			{
				btnAddDVD.Enabled = true;
			}

		}

		private void rdbDVDNoMedia_CheckedChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
			cmbDVDHostDrive.Enabled  = false;
			txtDVDImage.Enabled = false;
			btnSelectDVD.Enabled = false;
		}

		private void rdbDVDHostDrive_CheckedChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
			cmbDVDHostDrive.Enabled = true;
			txtDVDImage.Enabled = false;
			btnSelectDVD.Enabled = false;
		}

		private void rdbDVDImage_CheckedChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
			cmbDVDHostDrive.Enabled = false;
			txtDVDImage.Enabled = true;
			btnSelectDVD.Enabled = true;
		}


		private void txtDVDImage_TextChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void lstDVD_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int SelectedItem = lstDVD.SelectedIndex +1 ;
			if ( myVM.DVDROMDrives[SelectedItem].Attachment == VMDVDDriveAttachmentType.vmDVDDrive_None)
			{
				rdbDVDNoMedia.Checked = true;
			}
			else if ( myVM.DVDROMDrives[SelectedItem].Attachment == VMDVDDriveAttachmentType.vmDVDDrive_HostDrive) 
			{
				rdbDVDHostDrive.Checked = true;
				UpdateDVDHostDrive();
				cmbDVDHostDrive.Items.Add("Drive " + myVM.DVDROMDrives[SelectedItem].HostDriveLetter + ": (Current)");
				cmbDVDHostDrive.SelectedIndex = cmbDVDHostDrive.Items.Count -1;
			} 
			else 
			{
				rdbDVDImage.Checked = true;
				txtDVDImage.Text = myVM.DVDROMDrives[SelectedItem].ImageFile;
			}

			UpdateDVDChannel();
			
			// If the channel is not available, disable the add button.
			if ( cmbChannelDVD.Text.IndexOf("No")>=0 ) 
			{
				btnAddDVD.Enabled = false;
			}

			// Add channel of the selected dvd to the list			
			cmbChannelDVD.Items.Add( ConvertDVDChannel(	myVM.DVDROMDrives[SelectedItem].busNumber,
				myVM.DVDROMDrives[SelectedItem].deviceNumber));

			cmbChannelDVD.Text = cmbChannelDVD.Items[cmbChannelDVD.Items.Count-1].ToString();

			btnRemoveDVD.Enabled = true;
			btnUpdateDVD.Enabled = true;
		}


		private string ConvertDVDChannel(int channel, int device) 
		{
			string sChannel = "";

			if (channel ==0) 
			{
				sChannel = "Primary Channel (" + device + ")" + "  (Current)";
			} 
			else 
			{
				sChannel = "Secondary Channel (" + device + ")" + "  (Current)";
			}


			return sChannel;
		}

		private string ConvertVHDChannel(VMDriveBusType bustype, int channel, int device) 
		{
			string sChannel = "";

			if (bustype == VMDriveBusType.vmDriveBusType_SCSI) 
			{
				sChannel = "SCSI " + channel + " ID " + device + "  (Current)";	
			} 
			else 
			{
				if (channel == 0) 
				{
					sChannel = "Primary Channel (" + device + ")" + "  (Current)";
				} 
				else 
				{
					sChannel = "Secondary Channel (" + device + ")" + "  (Current)";
				}
			}
	
			return sChannel;
		}



		private void btnSelectDVD_Click(object sender, System.EventArgs e)
		{
			ofdMain.Filter = "DVD/CDROM image files (*.iso)|*.iso";
			if(ofdMain.ShowDialog() == DialogResult.OK)
			{
				if( ofdMain.FileName != "") 
				{
					// Insert code to read the stream here.
					txtDVDImage.Text = ofdMain.FileName;
				}
			}
		}

		private void btnRemoveDVD_Click(object sender, System.EventArgs e)
		{
			try 
			{
				myVM.RemoveDVDROMDrive(myVM.DVDROMDrives[lstDVD.SelectedIndex+1]);
			}
			catch (Exception err) 
			{
				MessageBox.Show(err.Message);
			}
			FillTab_DVD();
			UpdateVHDChannel();
			btnRemoveDVD.Enabled = false;
			btnUpdateDVD.Enabled = false;
		}

		private void btnAddDVD_Click(object sender, System.EventArgs e)
		{
			// Add based on checkbox.
			int DVDIndex = -1;

			// Connect to No media
			if (rdbDVDNoMedia.Checked) 
			{
				// If Channel is empty or in use, Prompt for input
				if (cmbChannelDVD.Text.IndexOf("Current")>=0 || cmbChannelDVD.Text.IndexOf("No")>=0) 
				{
					MessageBox.Show("Please select a valid channel");
					return;
				}

				try 
				{
					btnAddDVD.Enabled = false;
					
					myVM.AddDVDROMDrive(getChannelBusType(cmbChannelDVD.Text), 
						getChannelBusNumber(cmbChannelDVD.Text), 
						getChannelDeviceNumber(cmbChannelDVD.Text) );
				} 
				catch (Exception err) 
				{
					btnAddDVD.Enabled = true;
					MessageBox.Show(err.Message);
					return;
				}
			} 
			
			// Connect to Host driver
			if (rdbDVDHostDrive.Checked) 
			{
				if (cmbChannelDVD.Text.IndexOf("Current")>=0  || cmbChannelDVD.Text.IndexOf("No")>=0 || cmbDVDHostDrive.Text.IndexOf("No")>=0) 
				{
					MessageBox.Show("Please select a valid channel or Host drive");
					return;
				}


				if (cmbDVDHostDrive.Text.IndexOf("No")<0 ) 
				{
					try 
					{
						btnAddDVD.Enabled = false;
						myVM.AddDVDROMDrive(getChannelBusType(cmbChannelDVD.Text), 
							getChannelBusNumber(cmbChannelDVD.Text), 
							getChannelDeviceNumber(cmbChannelDVD.Text) );
					} 
					catch (Exception err) 
					{
						btnAddDVD.Enabled = true;
						MessageBox.Show(err.Message);
						return;
					}

					try 
					{
						// Primary channel: 0:0 and 0:1, Secondary channel: 1:0 and 1:1
						DVDIndex = getChannelBusNumber(cmbChannelDVD.Text)*2 + getChannelDeviceNumber(cmbChannelDVD.Text) + 1;
						myVM.DVDROMDrives[DVDIndex].AttachHostDrive( cmbDVDHostDrive.Text.Substring(6, 1));
					} 
					catch (Exception err) 
					{
						btnAddDVD.Enabled = true;
						MessageBox.Show(err.Message);
						return;
					}


				}			
				else 
				{
					MessageBox.Show("Cannot connect a channel which is already in use.");
					return;
				}

			} 


			// Connect to an ISO image
			if (rdbDVDImage.Checked) 
			{
				if (cmbChannelDVD.Text.IndexOf("Current")>=0  || cmbChannelDVD.Text.IndexOf("No")>=0 || txtDVDImage.Text == "") 
				{
					MessageBox.Show("Please select a valid channel or image file");
					return;
				}

				if (txtDVDImage.Text != "") 
				{
					try 
					{
						//btnAddDVD.Enabled = false;
						myVM.AddDVDROMDrive(getChannelBusType(cmbChannelDVD.Text), 
							getChannelBusNumber(cmbChannelDVD.Text), 
							getChannelDeviceNumber(cmbChannelDVD.Text) );					

					} 
					catch (Exception err) 
					{
						btnAddDVD.Enabled = true;
						MessageBox.Show(err.Message);
						return;
					}

					try 
					{
						DVDIndex = getChannelBusNumber(cmbChannelDVD.Text)*2 + getChannelDeviceNumber(cmbChannelDVD.Text) + 1;
						myVM.DVDROMDrives[DVDIndex].AttachImage(txtDVDImage.Text);
					}					
					catch (Exception err) 
					{
						btnAddDVD.Enabled = true;
						MessageBox.Show(err.Message + 2);
						return;
					}

				}
				else 
				{
					MessageBox.Show("Invalid Image File Name.");
					return;
				}
			} 

			FillTab_DVD();
			UpdateVHDChannel();
			btnAddDVD.Enabled = true;
		}

		private void btnUpdateDVD_Click(object sender, System.EventArgs e)
		{			
			VMDVDDrive dvd = myVM.DVDROMDrives[lstDVD.SelectedIndex+1];

			// Release any attached host drive or image file. Attach if necessary
				
			// Try to release attached host drive.
			try 
			{
				if (dvd.HostDriveLetter != null) dvd.ReleaseHostDrive();
			} 
			catch (System.Runtime.InteropServices.COMException err) 
			{
				// If exception catched, this dvd drive did not attached to a host drive.
			}
	
			// Try to release attached image
			try 
			{
				if (dvd.ImageFile != null) dvd.ReleaseImage();
			} 
			catch (System.Runtime.InteropServices.COMException err) 
			{
				// If exception catched, this dvd drive did not attached to an image file.
			}

			// Update BUS channel for dvd
			if (cmbChannelDVD.Text == "No IDE Channel Available") 
			{
				MessageBox.Show("Please select a valid channel");
				return;
			} 
			else 
			{
				// Update channel
				try 
				{
					dvd.SetBusLocation(VMDriveBusType.vmDriveBusType_IDE, getChannelBusNumber(cmbChannelDVD.Text),getChannelDeviceNumber(cmbChannelDVD.Text));
				}
				catch (Exception err) 
				{
					MessageBox.Show(err.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}


			// Set up dvd attachement properties.
			// No media
			if (rdbDVDNoMedia.Checked) 
			{

			} 
			
			// Connect to Host driver
			if (rdbDVDHostDrive.Checked) 
			{
				if (cmbDVDHostDrive.Text != "No Host Drive Available" ) 
				{

					btnAddDVD.Enabled = false;

					try
					{
						dvd.AttachHostDrive(cmbDVDHostDrive.Text.Substring(6, 1));
					}
					catch (Exception err) 
					{
						btnAddDVD.Enabled = true;
						MessageBox.Show( err.Message);
						return;
					}
				}			
				else 
				{
					MessageBox.Show("Unable to update. No host drive available.");
					return;
				}
			} 


			// Connect to an ISO image
			if (rdbDVDImage.Checked) 
			{
				if (txtDVDImage.Text != "") 
				{	
					try 
					{
						dvd.AttachImage(txtDVDImage.Text);
					}
					catch (Exception err) 
					{
						btnAddDVD.Enabled = true;
						MessageBox.Show( err.Message);
						return;
					}
				}
				else 
				{
					MessageBox.Show("Invalid Image File Name");
					return;
				}
			} 

			FillTab_DVD();
			UpdateVHDChannel();
			btnUpdateDVD.Enabled = false;
			btnRemoveDVD.Enabled = false;

		}


		private void lstNIC_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (myVM.NetworkAdapters[lstNIC.SelectedIndex+1].virtualNetwork != null) 
			{
				cmbVNetwork.Text = myVM.NetworkAdapters[lstNIC.SelectedIndex+1].virtualNetwork.Name;
			} 
			else 
			{
				cmbVNetwork.Text = "Not Connected";
			}

			if (myVM.NetworkAdapters[lstNIC.SelectedIndex+1].IsEthernetAddressDynamic) 
			{
				// Dynamic MAC Address
				ckbNICMACStatic.Checked = false;
				txtNICMAC.Enabled = false;
			}
			else 
			{
				// Static MAC address
				ckbNICMACStatic.Checked = true;
				txtNICMAC.Enabled = true;
			}

			txtNICMAC.Text = myVM.NetworkAdapters[lstNIC.SelectedIndex+1].EthernetAddress;


				 
			btnUpdateNIC.Enabled = true;
			btnRemoveNIC.Enabled = true;
		}

		private void btnRemoveNIC_Click(object sender, System.EventArgs e)
		{
			myVM.RemoveNetworkAdapter(myVM.NetworkAdapters[lstNIC.SelectedIndex+1]);
			FillTab_Network();
			btnRemoveNIC.Enabled = false;
			btnUpdateNIC.Enabled = false;
		}

		private void btnUpdateNIC_Click(object sender, System.EventArgs e)
		{
			int NICIndex = lstNIC.SelectedIndex+1;
			//btnRemoveNIC_Click(this, new System.EventArgs());
			
			if (cmbVNetwork.Text != "Not Connected") 
			{
				myVM.NetworkAdapters[NICIndex].AttachToVirtualNetwork(myVS.VirtualNetworks[cmbVNetwork.SelectedIndex]);
			} 
			else 
			{
				myVM.NetworkAdapters[NICIndex].DetachFromVirtualNetwork();
			}

			if (ckbNICMACStatic.Checked) 
			{
				myVM.NetworkAdapters[NICIndex].IsEthernetAddressDynamic = false;
				myVM.NetworkAdapters[NICIndex].EthernetAddress = txtNICMAC.Text;
			} 
			else 
			{
				myVM.NetworkAdapters[NICIndex].IsEthernetAddressDynamic = true;
			}

			

			FillTab_Network();
		}

		private void btnAddNIC_Click(object sender, System.EventArgs e)
		{
			myVM.AddNetworkAdapter();

			int NICIndex = myVM.NetworkAdapters.Count ;
			//btnRemoveNIC_Click(this, new System.EventArgs());
			
			if (cmbVNetwork.Text != "Not Connected") 
			{
				myVM.NetworkAdapters[NICIndex].AttachToVirtualNetwork(myVS.VirtualNetworks[cmbVNetwork.SelectedIndex]);
			} 
			else 
			{
				myVM.NetworkAdapters[NICIndex].DetachFromVirtualNetwork();
			}

			if (ckbNICMACStatic.Checked) 
			{
				myVM.NetworkAdapters[NICIndex].IsEthernetAddressDynamic = false;
				myVM.NetworkAdapters[NICIndex].EthernetAddress = txtNICMAC.Text;
			} 
			else 
			{
				myVM.NetworkAdapters[NICIndex].IsEthernetAddressDynamic = true;
			}
			

			FillTab_Network();
		}

		private void validateMAC() 
		{

			
		}

		private void ckbNICMACStatic_CheckedChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;

			if (ckbNICMACStatic.Checked) 
			{
				txtNICMAC.Enabled = true;
			}
			else 
			{
				txtNICMAC.Enabled = false;
			}
		}

		private void btnAddSCSI_Click(object sender, System.EventArgs e)
		{
			if (cmbSCSIID.Text == "" ) 
			{
				MessageBox.Show("Please choose a valid SCSI ID");
				return;
			}

			myVM.AddSCSIController();
			
			
			myVM.SCSIControllers[myVM.SCSIControllers.Count].Configure( ckbSCSIShare.Checked, int.Parse(cmbSCSIID.Text));
			FillTab_SCSI();

		}

		private void btnUpdateSCSI_Click(object sender, System.EventArgs e)
		{
			myVM.SCSIControllers[lstSCSI.SelectedIndex+1].Configure( ckbSCSIShare.Checked, int.Parse(cmbSCSIID.Text));
			FillTab_SCSI();
		}

		private void btnRemoveSCSI_Click(object sender, System.EventArgs e)
		{
			myVM.RemoveSCSIController( myVM.SCSIControllers[lstSCSI.SelectedIndex+1]);
			FillTab_SCSI();
		}

		private void lstSCSI_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			cmbSCSIID.Text = myVM.SCSIControllers[lstSCSI.SelectedIndex+1].SCSIID.ToString();

			ckbSCSIShare.Checked = myVM.SCSIControllers[lstSCSI.SelectedIndex+1].isBusShared;

			btnUpdateSCSI.Enabled = true;
			btnRemoveSCSI.Enabled = true;
		}

		private void btnRefreshEvent_Click(object sender, System.EventArgs e)
		{

			string[] myItems = new string[] {"","","","","","","",""};
			System.Diagnostics.EventLogEntry thisEventEntry = null;
			ListViewItem lvi = null;
			

			lvEvent.Items.Clear();
		

			if (eventLog1.Entries.Count > 0) 
			{
				int EventLogMax = ( eventLog1.Entries.Count < int.Parse(cmbEventMax.Text))?eventLog1.Entries.Count:int.Parse(cmbEventMax.Text);
				
				string thisVM = myVM.Name;
				int k = int.Parse(cmbEventMax.Text);

				for (int i=eventLog1.Entries.Count-1; i>=0; i--)
				{

					if ( eventLog1.Entries[i].Category== "Virtual Machine" &&
						eventLog1.Entries[i].Message.IndexOf(thisVM)>=0 ) 
					{
						thisEventEntry = eventLog1.Entries[i];
						//myItems[0] = thisEventEntry.EntryType.ToString();
						myItems[1] = thisEventEntry.TimeGenerated.Month + "/" + thisEventEntry.TimeGenerated.Day + "/" + thisEventEntry.TimeGenerated.Year;
						myItems[2] = Utility.FormatTimeNumber(thisEventEntry.TimeGenerated.Hour) + ":" 
							+ Utility.FormatTimeNumber(thisEventEntry.TimeGenerated.Minute) + ":" 
							+ Utility.FormatTimeNumber(thisEventEntry.TimeGenerated.Second);
						myItems[3] = thisEventEntry.Category.ToString();
						myItems[4] = (thisEventEntry.EventID & 0xffff) +"";
						myItems[5] = thisEventEntry.UserName;
						myItems[6] = thisEventEntry.MachineName;
						myItems[7] = thisEventEntry.Message;

						lvi = new ListViewItem(myItems);

						// Display icon
						switch (thisEventEntry.EntryType.ToString()) 
						{
							case "Information":
								lvi.ImageIndex=0;
								break;
							case "Warning":
								lvi.ImageIndex=1;
								break;
							case "Error":
								lvi.ImageIndex=2;
								break;
							default:
								lvi.ImageIndex=0;
								break;
						}

						lvEvent.Items.Add(lvi);
						if (k>1) 
						{
							k--;
						}
						else
						{
							break;
						}
					}

				}
						

			}
		



		}

		private void lvEvent_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lvEvent.SelectedItems.Count !=0 ) 
			{
				lblEventMessage.Text  = lvEvent.SelectedItems[0].SubItems[7].Text;
			}
		}

		private void cmbVHDChannel_TextChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void ckbEnableUndoDisk_CheckedChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void cmbChannelDVD_TextChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void cmbDVDHostDrive_TextChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void ckbSCSIShare_CheckedChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void cmbSCSIID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void cmbVNetwork_TextChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void txtNICMAC_TextChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void cmbVFDD_TextChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void cmbCOM1_TextChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void cmbCOM2_TextChanged(object sender, System.EventArgs e)
		{
			ConfigUpdated = true;
		}

		private void tmrStatus_Tick(object sender, System.EventArgs e)
		{
			FillTab_Status();
		}

		private void btnVSProperty_Click(object sender, System.EventArgs e)
		{
			frmVSProperty frm1 = new frmVSProperty(thisServerAddress, myAppProp);
			frm1.ShowDialog();
		}


		private void lvScripts_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lvScripts.SelectedItems.Count !=0) 
			{
				lblScriptEvent.Text = lvScripts.Items[lvScripts.SelectedIndices[0]].SubItems[0].Text;
				txtScript.Text = lvScripts.Items[lvScripts.SelectedIndices[0]].SubItems[1].Text;
				lblVSScript.Text = myVS.FetchScriptByEvent( (VMEventType)(lvScripts.SelectedIndices[0]+2) );


				if (txtScript.Text!="") 
				{
					btnScriptAttach.Enabled = false;
					btnScriptRemove.Enabled = true;
					btnScriptUpdate.Enabled = true;
				}
				else
				{
					btnScriptAttach.Enabled = true;
					btnScriptRemove.Enabled = false;
					btnScriptUpdate.Enabled = false;
				}
				txtScript.Enabled = true;
				lblScriptEvent.Enabled = true;
			}
		}

		private void btnScriptAttach_Click(object sender, System.EventArgs e)
		{
			int VMEventIndex = lvScripts.SelectedIndices[0] + 2;
			try 
			{
				myVM.AttachScriptToEvent( (VMEventType)VMEventIndex, txtScript.Text);
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
			FillTab_Scripts();
		}

		private void btnScriptRemove_Click(object sender, System.EventArgs e)
		{
			int VMEventIndex = lvScripts.SelectedIndices[0] + 2;
			try
			{
				myVM.RemoveScriptFromEvent( (VMEventType)VMEventIndex);
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
			FillTab_Scripts();
		}

		private void btnScriptUpdate_Click(object sender, System.EventArgs e)
		{
			int VMEventIndex = lvScripts.SelectedIndices[0] + 2;
			try
			{
				myVM.RemoveScriptFromEvent( (VMEventType)VMEventIndex);
				myVM.AttachScriptToEvent( (VMEventType)VMEventIndex, txtScript.Text);
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
			FillTab_Scripts();
		}



	
	}
}
