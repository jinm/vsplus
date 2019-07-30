using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.VirtualServer.Interop;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Runtime.InteropServices;
using System.Data;
using System.IO;



namespace VSPlus
{
	/// <summary>
	/// Summary description for frmVSProperty.
	/// </summary>
	public class frmVSProperty : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblVSVersion;
		private System.Windows.Forms.Label lblAdminWebVersion;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblUptime;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblProductID;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tbpGeneral;
		private System.Windows.Forms.TabPage tbpVMRC;
		private System.Windows.Forms.TabPage tbpSearchPath;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox groupBox1;


		// Initialize COM with Impersonate first
		private InitVS myAppVSProp;
		// Connect locally or remotely
		private VMVirtualServer myVS;
		// Vistual Server Address
		private string thisVSAddress;
		private System.Windows.Forms.ListBox lstSupportDrivers;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.ListBox lstSearchPath;
		private System.Windows.Forms.TextBox txtConfFolder;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.CheckBox ckbVMRCEnable;
		private System.Windows.Forms.ComboBox cmbVMRCAddress;
		private System.Windows.Forms.TextBox txtVMRCPort;
		private System.Windows.Forms.ComboBox cmbVMRCAuth;
		private System.Windows.Forms.CheckBox ckbIdleEnable;
		private System.Windows.Forms.TextBox txtVMRCTimeout;
		private System.Windows.Forms.TextBox txtSearchPathNew;
		private System.Windows.Forms.Button btnSelectNewSearchPath;
		private System.Windows.Forms.Button btnAddSearchPath;
		private System.Windows.Forms.Button btnRemoveSearchPath;
		private System.Windows.Forms.FolderBrowserDialog fbdMain;
		private System.Windows.Forms.TabPage tbpEvent;
		private System.Windows.Forms.TabPage tbpResource;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.ComboBox cmbFilter;
		private System.Windows.Forms.Button btnRefreshEvent;
		private System.Windows.Forms.ComboBox cmbEventMax;
		private System.Windows.Forms.Button btnUpdateVMRC;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ComboBox cmbScrRes;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.CheckBox ckbSSLEnable;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.TextBox txtSSLHost;
		private System.Windows.Forms.TextBox txtSSLOrg;
		private System.Windows.Forms.TextBox txtSSLOU;
		private System.Windows.Forms.TextBox txtSSLCity;
		private System.Windows.Forms.TextBox txtSSLState;
		private System.Windows.Forms.TextBox txtSSLCountry;
		private System.Windows.Forms.ComboBox cmbSSLKeyLength;
		private System.Windows.Forms.RadioButton rdbSSLKeep;
		private System.Windows.Forms.RadioButton rdbSSLRequest;
		private System.Windows.Forms.RadioButton rdbSSLUpload;
		private System.Windows.Forms.RadioButton rdbSSLDelete;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Button btnSSLBrowse;
		private System.Windows.Forms.OpenFileDialog ofdMain;
		private System.Windows.Forms.TabPage tbpPC;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ListBox lstNIC;
		private System.Windows.Forms.Label lblProcFeature;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label lblProcVersion;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label lblProcType;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label lblProcSpeed;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label lblLProc;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lblPProc;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblTotalMemory;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label lblAvailableMemory;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label lblOS;
		private System.Windows.Forms.TextBox txtSSLCertificate;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ListView lvResource;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label lblTCR;
		private System.Windows.Forms.Label lblACR;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label lblRSC;
		private System.Windows.Forms.TextBox txtMCC;
		private System.Windows.Forms.TextBox txtRCC;
		private System.Windows.Forms.TextBox txtRW;
		private System.Windows.Forms.Label lblVM;
		private System.Windows.Forms.Button btnUpdateResource;
		private System.Windows.Forms.Label lblMSC;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.GroupBox grpSSLCertificate;
		private System.Windows.Forms.TabPage tbpVN;
		private System.Windows.Forms.ListBox lstVN;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.TabPage tbpVD;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.Label label58;
		private System.Windows.Forms.Label label59;
		private System.Windows.Forms.Label label60;
		private System.Windows.Forms.Label label61;
		private System.Windows.Forms.Label label62;
		private System.Windows.Forms.Label label63;
		private System.Windows.Forms.Button btnAddVN;
		private System.Windows.Forms.Button btnUpdateVN;
		private System.Windows.Forms.Button btnRemoveVN;
		private System.Windows.Forms.ListBox lstVNVM;
		private System.Windows.Forms.TextBox txtVNName;
		private System.Windows.Forms.ComboBox cmbPhysicanNIC;
		private System.Windows.Forms.TextBox txtVNNotes;
		private System.Windows.Forms.ComboBox cmbDHCPLeaseRenewal;
		private System.Windows.Forms.TextBox txtDHCPLeaseRenewal;
		private System.Windows.Forms.ComboBox cmbDHCPIPLease;
		private System.Windows.Forms.TextBox txtDHCPIPLease;
		private System.Windows.Forms.TextBox txtDHCPWINS;
		private System.Windows.Forms.TextBox txtDHCPDNS;
		private System.Windows.Forms.TextBox txtDHCPGW;
		private System.Windows.Forms.TextBox txtDHCPEndIP;
		private System.Windows.Forms.TextBox txtDHCPStartIP;
		private System.Windows.Forms.TextBox txtDHCPServerAddress;
		private System.Windows.Forms.TextBox txtDHCPNetMask;
		private System.Windows.Forms.CheckBox ckbVNDHCPEnable;
		private System.Windows.Forms.TextBox txtDHCPLeaseRebinding;
		private System.Windows.Forms.ComboBox cmbDHCPLeaseRebinding;
		private System.Windows.Forms.TextBox txtDHCPNetworkAddress;
		private System.Windows.Forms.Label label67;
		private System.Windows.Forms.Label label66;
		private System.Windows.Forms.Label label71;
		private System.Windows.Forms.Label label74;
		private System.Windows.Forms.Label label75;
		private System.Windows.Forms.TabControl tabControl2;
		private System.Windows.Forms.Label label72;
		private System.Windows.Forms.Label label73;
		private System.Windows.Forms.TabPage tbpDEVHD;
		private System.Windows.Forms.TabPage tbpFSVHD;
		private System.Windows.Forms.TabPage tbpDVHD;
		private System.Windows.Forms.TabPage tbpLVHD;
		private System.Windows.Forms.TabPage tbpVFD;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.TextBox txtVDDEFilename;
		private System.Windows.Forms.TextBox txtVDDESize;
		private System.Windows.Forms.ComboBox cmbVDDEUnit;
		private System.Windows.Forms.Button btnVDDEBrowse;
		private System.Windows.Forms.Label label69;
		private System.Windows.Forms.Label label70;
		private System.Windows.Forms.Button btnVDFSBrowse;
		private System.Windows.Forms.ComboBox cmbVDFSUnit;
		private System.Windows.Forms.TextBox txtVDFSFilename;
		private System.Windows.Forms.TextBox txtVDFSSize;
		private System.Windows.Forms.Button btnVDDDParent;
		private System.Windows.Forms.Button btnVDDDDiff;
		private System.Windows.Forms.TextBox txtVDDDDiff;
		private System.Windows.Forms.TextBox txtVDDDParent;
		private System.Windows.Forms.TextBox txtVDLDFilename;
		private System.Windows.Forms.Button btnVDLDBrowse;
		private System.Windows.Forms.ComboBox cmbVDLDPDrive;
		private System.Windows.Forms.TabPage tbpVDT;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.Button btnConvertBrowse;
		private System.Windows.Forms.TextBox txtConvertVHD;
		private System.Windows.Forms.Label label77;
		private System.Windows.Forms.Button btnConvertVHD;
		private System.Windows.Forms.Button btnCompact;
		private System.Windows.Forms.Label lblIVDCurrentSize;
		private System.Windows.Forms.Label label82;
		private System.Windows.Forms.Label lblIVDMaxSize;
		private System.Windows.Forms.Label label80;
		private System.Windows.Forms.Label lblFQPath;
		private System.Windows.Forms.Label label78;
		private System.Windows.Forms.Label lblVDType;
		private System.Windows.Forms.Label label76;
		private System.Windows.Forms.Button btnInspectVD;
		private System.Windows.Forms.Label label68;
		private System.Windows.Forms.Button btnVDFD;
		private System.Windows.Forms.TextBox txtVDFDFilename;
		private System.Windows.Forms.Button btnCreateVDDE;
		private System.Windows.Forms.Button btnCreateVDFS;
		private System.Windows.Forms.Button btnCreateVDLD;
		private System.Windows.Forms.Button btnCreateVDDD;
		private System.Windows.Forms.Button btnCreateVDFD;
		private System.Windows.Forms.Button btnBrowseIVD;
		private System.Windows.Forms.TextBox txtInspectVDFilename;
		private System.Diagnostics.EventLog eventLog1;
		private System.Windows.Forms.Label label64;
		private System.Windows.Forms.TextBox txtSSLCertPath;
		private System.Windows.Forms.ColumnHeader colType;
		private System.Windows.Forms.ColumnHeader colDate;
		private System.Windows.Forms.ColumnHeader colTime;
		private System.Windows.Forms.ColumnHeader colCategory;
		private System.Windows.Forms.ColumnHeader colEvent;
		private System.Windows.Forms.ColumnHeader colUser;
		private System.Windows.Forms.ColumnHeader colComputer;
		private System.Windows.Forms.ListView lvEvent;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label label65;
		private System.Windows.Forms.Label lblEventMessage;
		private System.Windows.Forms.ColumnHeader colMessage;
		private System.Windows.Forms.ImageList imglistThumbnail;

		private System.Windows.Forms.TabPage tbpSecurity;
		private System.Windows.Forms.DataGrid dgSecurity;
		private System.Windows.Forms.ImageList imgSecurity;
		private System.Windows.Forms.Label label79;
		private System.Windows.Forms.Label label81;
		private System.Windows.Forms.Label label83;
		private System.Windows.Forms.Label label84;
		private System.Windows.Forms.TextBox txtSecEntryUser;
		private System.Windows.Forms.RadioButton rdbSecEntryAllow;
		private System.Windows.Forms.RadioButton rdbSecEntryDeny;
		private System.Windows.Forms.CheckBox ckbSecEntryFull;
		private System.Windows.Forms.CheckBox ckbSecEntrySpecial;
		private System.Windows.Forms.CheckBox ckbSecEntryControl;
		private System.Windows.Forms.CheckBox ckbSecEntryChange;
		private System.Windows.Forms.CheckBox ckbSecEntryRemove;
		private System.Windows.Forms.CheckBox ckbSecEntryView;
		private System.Windows.Forms.CheckBox ckbSecEntryModify;
		private System.Windows.Forms.Button btnSecEntryAdd;
		private System.Windows.Forms.Button btnSecEntryRemove;
		private System.Windows.Forms.Label label85;
		private System.Windows.Forms.TabPage tbpScripts;
		private System.Windows.Forms.CheckBox ckbScriptVSEnabled;
		private System.Windows.Forms.CheckBox ckbScriptVMEnabled;
		private System.Windows.Forms.Button btnScriptUpdate;
		private System.Windows.Forms.Button btnScriptRemove;
		private System.Windows.Forms.Button btnScriptAttach;
		private System.Windows.Forms.TextBox txtScript;
		private System.Windows.Forms.Label label86;
		private System.Windows.Forms.Label lblScriptEvent;
		private System.Windows.Forms.Label label87;
		private System.Windows.Forms.ListView lvScripts;
		private System.Windows.Forms.ColumnHeader colScriptEvent;
		private System.Windows.Forms.ColumnHeader colScriptAction;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.Button btnScriptVSVMUpdate;
		private System.Windows.Forms.TabPage tbpVSView;
		private System.Windows.Forms.DataGrid dgVSView;
		private System.Windows.Forms.Timer tmrVS;
		private System.Windows.Forms.Button btnVNAddExisting;
		private System.ComponentModel.IContainer components;

		public frmVSProperty(string VSAddress, InitVS myAppConnectVS)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			thisVSAddress = VSAddress;
			myAppVSProp = myAppConnectVS;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmVSProperty));
			this.label1 = new System.Windows.Forms.Label();
			this.lblVSVersion = new System.Windows.Forms.Label();
			this.lblAdminWebVersion = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lblUptime = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.lblProductID = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tbpGeneral = new System.Windows.Forms.TabPage();
			this.grpSSLCertificate = new System.Windows.Forms.GroupBox();
			this.label39 = new System.Windows.Forms.Label();
			this.txtSSLCertificate = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lstSupportDrivers = new System.Windows.Forms.ListBox();
			this.tbpSecurity = new System.Windows.Forms.TabPage();
			this.label85 = new System.Windows.Forms.Label();
			this.btnSecEntryRemove = new System.Windows.Forms.Button();
			this.btnSecEntryAdd = new System.Windows.Forms.Button();
			this.ckbSecEntryModify = new System.Windows.Forms.CheckBox();
			this.ckbSecEntryView = new System.Windows.Forms.CheckBox();
			this.ckbSecEntryRemove = new System.Windows.Forms.CheckBox();
			this.ckbSecEntryChange = new System.Windows.Forms.CheckBox();
			this.ckbSecEntryControl = new System.Windows.Forms.CheckBox();
			this.ckbSecEntrySpecial = new System.Windows.Forms.CheckBox();
			this.ckbSecEntryFull = new System.Windows.Forms.CheckBox();
			this.rdbSecEntryDeny = new System.Windows.Forms.RadioButton();
			this.rdbSecEntryAllow = new System.Windows.Forms.RadioButton();
			this.label84 = new System.Windows.Forms.Label();
			this.label83 = new System.Windows.Forms.Label();
			this.txtSecEntryUser = new System.Windows.Forms.TextBox();
			this.label81 = new System.Windows.Forms.Label();
			this.label79 = new System.Windows.Forms.Label();
			this.dgSecurity = new System.Windows.Forms.DataGrid();
			this.tbpVSView = new System.Windows.Forms.TabPage();
			this.dgVSView = new System.Windows.Forms.DataGrid();
			this.tbpVMRC = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label64 = new System.Windows.Forms.Label();
			this.btnSSLBrowse = new System.Windows.Forms.Button();
			this.txtSSLCertPath = new System.Windows.Forms.TextBox();
			this.label38 = new System.Windows.Forms.Label();
			this.cmbSSLKeyLength = new System.Windows.Forms.ComboBox();
			this.label37 = new System.Windows.Forms.Label();
			this.txtSSLCountry = new System.Windows.Forms.TextBox();
			this.label36 = new System.Windows.Forms.Label();
			this.txtSSLState = new System.Windows.Forms.TextBox();
			this.label35 = new System.Windows.Forms.Label();
			this.txtSSLCity = new System.Windows.Forms.TextBox();
			this.label34 = new System.Windows.Forms.Label();
			this.txtSSLOU = new System.Windows.Forms.TextBox();
			this.label33 = new System.Windows.Forms.Label();
			this.txtSSLOrg = new System.Windows.Forms.TextBox();
			this.label32 = new System.Windows.Forms.Label();
			this.txtSSLHost = new System.Windows.Forms.TextBox();
			this.label31 = new System.Windows.Forms.Label();
			this.rdbSSLDelete = new System.Windows.Forms.RadioButton();
			this.rdbSSLUpload = new System.Windows.Forms.RadioButton();
			this.rdbSSLRequest = new System.Windows.Forms.RadioButton();
			this.rdbSSLKeep = new System.Windows.Forms.RadioButton();
			this.label30 = new System.Windows.Forms.Label();
			this.ckbSSLEnable = new System.Windows.Forms.CheckBox();
			this.label29 = new System.Windows.Forms.Label();
			this.cmbScrRes = new System.Windows.Forms.ComboBox();
			this.label25 = new System.Windows.Forms.Label();
			this.txtVMRCPort = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.cmbVMRCAddress = new System.Windows.Forms.ComboBox();
			this.label23 = new System.Windows.Forms.Label();
			this.ckbVMRCEnable = new System.Windows.Forms.CheckBox();
			this.label22 = new System.Windows.Forms.Label();
			this.txtVMRCTimeout = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.ckbIdleEnable = new System.Windows.Forms.CheckBox();
			this.label27 = new System.Windows.Forms.Label();
			this.cmbVMRCAuth = new System.Windows.Forms.ComboBox();
			this.label26 = new System.Windows.Forms.Label();
			this.btnUpdateVMRC = new System.Windows.Forms.Button();
			this.tbpSearchPath = new System.Windows.Forms.TabPage();
			this.btnRemoveSearchPath = new System.Windows.Forms.Button();
			this.btnAddSearchPath = new System.Windows.Forms.Button();
			this.btnSelectNewSearchPath = new System.Windows.Forms.Button();
			this.txtSearchPathNew = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.txtConfFolder = new System.Windows.Forms.TextBox();
			this.lstSearchPath = new System.Windows.Forms.ListBox();
			this.label17 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.tbpEvent = new System.Windows.Forms.TabPage();
			this.lblEventMessage = new System.Windows.Forms.Label();
			this.label65 = new System.Windows.Forms.Label();
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
			this.cmbEventMax = new System.Windows.Forms.ComboBox();
			this.btnRefreshEvent = new System.Windows.Forms.Button();
			this.cmbFilter = new System.Windows.Forms.ComboBox();
			this.label20 = new System.Windows.Forms.Label();
			this.tbpResource = new System.Windows.Forms.TabPage();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.label47 = new System.Windows.Forms.Label();
			this.label46 = new System.Windows.Forms.Label();
			this.label45 = new System.Windows.Forms.Label();
			this.label44 = new System.Windows.Forms.Label();
			this.label43 = new System.Windows.Forms.Label();
			this.label41 = new System.Windows.Forms.Label();
			this.btnUpdateResource = new System.Windows.Forms.Button();
			this.txtRW = new System.Windows.Forms.TextBox();
			this.lblVM = new System.Windows.Forms.Label();
			this.lblMSC = new System.Windows.Forms.Label();
			this.lblRSC = new System.Windows.Forms.Label();
			this.txtMCC = new System.Windows.Forms.TextBox();
			this.txtRCC = new System.Windows.Forms.TextBox();
			this.btnLoad = new System.Windows.Forms.Button();
			this.lblACR = new System.Windows.Forms.Label();
			this.label42 = new System.Windows.Forms.Label();
			this.lblTCR = new System.Windows.Forms.Label();
			this.label40 = new System.Windows.Forms.Label();
			this.lvResource = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.tbpScripts = new System.Windows.Forms.TabPage();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.ckbScriptVSEnabled = new System.Windows.Forms.CheckBox();
			this.ckbScriptVMEnabled = new System.Windows.Forms.CheckBox();
			this.btnScriptVSVMUpdate = new System.Windows.Forms.Button();
			this.btnScriptUpdate = new System.Windows.Forms.Button();
			this.btnScriptRemove = new System.Windows.Forms.Button();
			this.btnScriptAttach = new System.Windows.Forms.Button();
			this.txtScript = new System.Windows.Forms.TextBox();
			this.label86 = new System.Windows.Forms.Label();
			this.lblScriptEvent = new System.Windows.Forms.Label();
			this.label87 = new System.Windows.Forms.Label();
			this.lvScripts = new System.Windows.Forms.ListView();
			this.colScriptEvent = new System.Windows.Forms.ColumnHeader();
			this.colScriptAction = new System.Windows.Forms.ColumnHeader();
			this.tbpPC = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lstNIC = new System.Windows.Forms.ListBox();
			this.lblProcFeature = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.lblProcVersion = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.lblProcType = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.lblProcSpeed = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.lblLProc = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.lblPProc = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lblTotalMemory = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.lblAvailableMemory = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.lblOS = new System.Windows.Forms.Label();
			this.tbpVN = new System.Windows.Forms.TabPage();
			this.btnVNAddExisting = new System.Windows.Forms.Button();
			this.btnRemoveVN = new System.Windows.Forms.Button();
			this.btnUpdateVN = new System.Windows.Forms.Button();
			this.btnAddVN = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.cmbDHCPLeaseRenewal = new System.Windows.Forms.ComboBox();
			this.txtDHCPLeaseRenewal = new System.Windows.Forms.TextBox();
			this.label62 = new System.Windows.Forms.Label();
			this.cmbDHCPIPLease = new System.Windows.Forms.ComboBox();
			this.txtDHCPIPLease = new System.Windows.Forms.TextBox();
			this.label61 = new System.Windows.Forms.Label();
			this.txtDHCPWINS = new System.Windows.Forms.TextBox();
			this.label60 = new System.Windows.Forms.Label();
			this.txtDHCPDNS = new System.Windows.Forms.TextBox();
			this.label59 = new System.Windows.Forms.Label();
			this.txtDHCPGW = new System.Windows.Forms.TextBox();
			this.label58 = new System.Windows.Forms.Label();
			this.txtDHCPEndIP = new System.Windows.Forms.TextBox();
			this.txtDHCPStartIP = new System.Windows.Forms.TextBox();
			this.label57 = new System.Windows.Forms.Label();
			this.label56 = new System.Windows.Forms.Label();
			this.txtDHCPServerAddress = new System.Windows.Forms.TextBox();
			this.label55 = new System.Windows.Forms.Label();
			this.txtDHCPNetMask = new System.Windows.Forms.TextBox();
			this.label54 = new System.Windows.Forms.Label();
			this.txtDHCPNetworkAddress = new System.Windows.Forms.TextBox();
			this.label53 = new System.Windows.Forms.Label();
			this.ckbVNDHCPEnable = new System.Windows.Forms.CheckBox();
			this.label52 = new System.Windows.Forms.Label();
			this.txtDHCPLeaseRebinding = new System.Windows.Forms.TextBox();
			this.cmbDHCPLeaseRebinding = new System.Windows.Forms.ComboBox();
			this.label63 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label48 = new System.Windows.Forms.Label();
			this.label51 = new System.Windows.Forms.Label();
			this.txtVNNotes = new System.Windows.Forms.TextBox();
			this.label49 = new System.Windows.Forms.Label();
			this.txtVNName = new System.Windows.Forms.TextBox();
			this.cmbPhysicanNIC = new System.Windows.Forms.ComboBox();
			this.label50 = new System.Windows.Forms.Label();
			this.lstVNVM = new System.Windows.Forms.ListBox();
			this.lstVN = new System.Windows.Forms.ListBox();
			this.tbpVD = new System.Windows.Forms.TabPage();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tbpDEVHD = new System.Windows.Forms.TabPage();
			this.btnVDDEBrowse = new System.Windows.Forms.Button();
			this.cmbVDDEUnit = new System.Windows.Forms.ComboBox();
			this.txtVDDEFilename = new System.Windows.Forms.TextBox();
			this.label67 = new System.Windows.Forms.Label();
			this.txtVDDESize = new System.Windows.Forms.TextBox();
			this.label66 = new System.Windows.Forms.Label();
			this.btnCreateVDDE = new System.Windows.Forms.Button();
			this.tbpFSVHD = new System.Windows.Forms.TabPage();
			this.btnCreateVDFS = new System.Windows.Forms.Button();
			this.btnVDFSBrowse = new System.Windows.Forms.Button();
			this.cmbVDFSUnit = new System.Windows.Forms.ComboBox();
			this.txtVDFSFilename = new System.Windows.Forms.TextBox();
			this.label69 = new System.Windows.Forms.Label();
			this.txtVDFSSize = new System.Windows.Forms.TextBox();
			this.label70 = new System.Windows.Forms.Label();
			this.tbpDVHD = new System.Windows.Forms.TabPage();
			this.btnCreateVDDD = new System.Windows.Forms.Button();
			this.btnVDDDDiff = new System.Windows.Forms.Button();
			this.btnVDDDParent = new System.Windows.Forms.Button();
			this.txtVDDDParent = new System.Windows.Forms.TextBox();
			this.txtVDDDDiff = new System.Windows.Forms.TextBox();
			this.label72 = new System.Windows.Forms.Label();
			this.label73 = new System.Windows.Forms.Label();
			this.tbpLVHD = new System.Windows.Forms.TabPage();
			this.btnCreateVDLD = new System.Windows.Forms.Button();
			this.cmbVDLDPDrive = new System.Windows.Forms.ComboBox();
			this.btnVDLDBrowse = new System.Windows.Forms.Button();
			this.txtVDLDFilename = new System.Windows.Forms.TextBox();
			this.label74 = new System.Windows.Forms.Label();
			this.label71 = new System.Windows.Forms.Label();
			this.tbpVFD = new System.Windows.Forms.TabPage();
			this.btnCreateVDFD = new System.Windows.Forms.Button();
			this.btnVDFD = new System.Windows.Forms.Button();
			this.txtVDFDFilename = new System.Windows.Forms.TextBox();
			this.label75 = new System.Windows.Forms.Label();
			this.tbpVDT = new System.Windows.Forms.TabPage();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.btnConvertBrowse = new System.Windows.Forms.Button();
			this.txtConvertVHD = new System.Windows.Forms.TextBox();
			this.label77 = new System.Windows.Forms.Label();
			this.btnConvertVHD = new System.Windows.Forms.Button();
			this.btnCompact = new System.Windows.Forms.Button();
			this.lblIVDCurrentSize = new System.Windows.Forms.Label();
			this.label82 = new System.Windows.Forms.Label();
			this.lblIVDMaxSize = new System.Windows.Forms.Label();
			this.label80 = new System.Windows.Forms.Label();
			this.lblFQPath = new System.Windows.Forms.Label();
			this.label78 = new System.Windows.Forms.Label();
			this.lblVDType = new System.Windows.Forms.Label();
			this.label76 = new System.Windows.Forms.Label();
			this.btnInspectVD = new System.Windows.Forms.Button();
			this.btnBrowseIVD = new System.Windows.Forms.Button();
			this.label68 = new System.Windows.Forms.Label();
			this.txtInspectVDFilename = new System.Windows.Forms.TextBox();
			this.imglistThumbnail = new System.Windows.Forms.ImageList(this.components);
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.fbdMain = new System.Windows.Forms.FolderBrowserDialog();
			this.ofdMain = new System.Windows.Forms.OpenFileDialog();
			this.eventLog1 = new System.Diagnostics.EventLog();
			this.imgSecurity = new System.Windows.Forms.ImageList(this.components);
			this.tmrVS = new System.Windows.Forms.Timer(this.components);
			this.tabControl1.SuspendLayout();
			this.tbpGeneral.SuspendLayout();
			this.grpSSLCertificate.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tbpSecurity.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgSecurity)).BeginInit();
			this.tbpVSView.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgVSView)).BeginInit();
			this.tbpVMRC.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tbpSearchPath.SuspendLayout();
			this.tbpEvent.SuspendLayout();
			this.tbpResource.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.tbpScripts.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.tbpPC.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tbpVN.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.tbpVD.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tbpDEVHD.SuspendLayout();
			this.tbpFSVHD.SuspendLayout();
			this.tbpDVHD.SuspendLayout();
			this.tbpLVHD.SuspendLayout();
			this.tbpVFD.SuspendLayout();
			this.tbpVDT.SuspendLayout();
			this.groupBox8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(176, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Virtual Server Version";
			// 
			// lblVSVersion
			// 
			this.lblVSVersion.Location = new System.Drawing.Point(256, 32);
			this.lblVSVersion.Name = "lblVSVersion";
			this.lblVSVersion.Size = new System.Drawing.Size(352, 23);
			this.lblVSVersion.TabIndex = 1;
			// 
			// lblAdminWebVersion
			// 
			this.lblAdminWebVersion.Location = new System.Drawing.Point(256, 56);
			this.lblAdminWebVersion.Name = "lblAdminWebVersion";
			this.lblAdminWebVersion.Size = new System.Drawing.Size(352, 23);
			this.lblAdminWebVersion.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(32, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(176, 23);
			this.label4.TabIndex = 2;
			this.label4.Text = "Administration Website version";
			// 
			// lblUptime
			// 
			this.lblUptime.Location = new System.Drawing.Point(256, 80);
			this.lblUptime.Name = "lblUptime";
			this.lblUptime.Size = new System.Drawing.Size(352, 23);
			this.lblUptime.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(32, 80);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(176, 23);
			this.label6.TabIndex = 4;
			this.label6.Text = "Running time";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(32, 104);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(176, 23);
			this.label8.TabIndex = 4;
			this.label8.Text = "Support drivers";
			// 
			// lblProductID
			// 
			this.lblProductID.Location = new System.Drawing.Point(256, 184);
			this.lblProductID.Name = "lblProductID";
			this.lblProductID.Size = new System.Drawing.Size(352, 23);
			this.lblProductID.TabIndex = 7;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(32, 184);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(176, 23);
			this.label10.TabIndex = 6;
			this.label10.Text = "Product ID";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tbpGeneral);
			this.tabControl1.Controls.Add(this.tbpSecurity);
			this.tabControl1.Controls.Add(this.tbpVSView);
			this.tabControl1.Controls.Add(this.tbpVMRC);
			this.tabControl1.Controls.Add(this.tbpSearchPath);
			this.tabControl1.Controls.Add(this.tbpEvent);
			this.tabControl1.Controls.Add(this.tbpResource);
			this.tabControl1.Controls.Add(this.tbpScripts);
			this.tabControl1.Controls.Add(this.tbpPC);
			this.tabControl1.Controls.Add(this.tbpVN);
			this.tabControl1.Controls.Add(this.tbpVD);
			this.tabControl1.Controls.Add(this.tbpVDT);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Multiline = true;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(680, 656);
			this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
			this.tabControl1.TabIndex = 1;
			// 
			// tbpGeneral
			// 
			this.tbpGeneral.Controls.Add(this.grpSSLCertificate);
			this.tbpGeneral.Controls.Add(this.groupBox1);
			this.tbpGeneral.Location = new System.Drawing.Point(4, 40);
			this.tbpGeneral.Name = "tbpGeneral";
			this.tbpGeneral.Size = new System.Drawing.Size(672, 612);
			this.tbpGeneral.TabIndex = 0;
			this.tbpGeneral.Text = "General";
			// 
			// grpSSLCertificate
			// 
			this.grpSSLCertificate.Controls.Add(this.label39);
			this.grpSSLCertificate.Controls.Add(this.txtSSLCertificate);
			this.grpSSLCertificate.Location = new System.Drawing.Point(16, 272);
			this.grpSSLCertificate.Name = "grpSSLCertificate";
			this.grpSSLCertificate.Size = new System.Drawing.Size(632, 336);
			this.grpSSLCertificate.TabIndex = 9;
			this.grpSSLCertificate.TabStop = false;
			this.grpSSLCertificate.Text = "VMRC SSL certificate request";
			// 
			// label39
			// 
			this.label39.Location = new System.Drawing.Point(16, 24);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(568, 23);
			this.label39.TabIndex = 1;
			this.label39.Text = "Copy the following text and send it to the Certificate Authority to complete proc" +
				"essing of the request:";
			// 
			// txtSSLCertificate
			// 
			this.txtSSLCertificate.AcceptsReturn = true;
			this.txtSSLCertificate.Location = new System.Drawing.Point(16, 48);
			this.txtSSLCertificate.Multiline = true;
			this.txtSSLCertificate.Name = "txtSSLCertificate";
			this.txtSSLCertificate.ReadOnly = true;
			this.txtSSLCertificate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtSSLCertificate.Size = new System.Drawing.Size(600, 272);
			this.txtSSLCertificate.TabIndex = 0;
			this.txtSSLCertificate.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lstSupportDrivers);
			this.groupBox1.Controls.Add(this.lblUptime);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.lblProductID);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.lblAdminWebVersion);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.lblVSVersion);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(16, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(632, 232);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Virtual Server Information";
			// 
			// lstSupportDrivers
			// 
			this.lstSupportDrivers.BackColor = System.Drawing.SystemColors.Control;
			this.lstSupportDrivers.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lstSupportDrivers.Location = new System.Drawing.Point(256, 104);
			this.lstSupportDrivers.Name = "lstSupportDrivers";
			this.lstSupportDrivers.SelectionMode = System.Windows.Forms.SelectionMode.None;
			this.lstSupportDrivers.Size = new System.Drawing.Size(352, 78);
			this.lstSupportDrivers.TabIndex = 8;
			this.lstSupportDrivers.TabStop = false;
			// 
			// tbpSecurity
			// 
			this.tbpSecurity.Controls.Add(this.label85);
			this.tbpSecurity.Controls.Add(this.btnSecEntryRemove);
			this.tbpSecurity.Controls.Add(this.btnSecEntryAdd);
			this.tbpSecurity.Controls.Add(this.ckbSecEntryModify);
			this.tbpSecurity.Controls.Add(this.ckbSecEntryView);
			this.tbpSecurity.Controls.Add(this.ckbSecEntryRemove);
			this.tbpSecurity.Controls.Add(this.ckbSecEntryChange);
			this.tbpSecurity.Controls.Add(this.ckbSecEntryControl);
			this.tbpSecurity.Controls.Add(this.ckbSecEntrySpecial);
			this.tbpSecurity.Controls.Add(this.ckbSecEntryFull);
			this.tbpSecurity.Controls.Add(this.rdbSecEntryDeny);
			this.tbpSecurity.Controls.Add(this.rdbSecEntryAllow);
			this.tbpSecurity.Controls.Add(this.label84);
			this.tbpSecurity.Controls.Add(this.label83);
			this.tbpSecurity.Controls.Add(this.txtSecEntryUser);
			this.tbpSecurity.Controls.Add(this.label81);
			this.tbpSecurity.Controls.Add(this.label79);
			this.tbpSecurity.Controls.Add(this.dgSecurity);
			this.tbpSecurity.Location = new System.Drawing.Point(4, 40);
			this.tbpSecurity.Name = "tbpSecurity";
			this.tbpSecurity.Size = new System.Drawing.Size(672, 612);
			this.tbpSecurity.TabIndex = 10;
			this.tbpSecurity.Text = "Security";
			// 
			// label85
			// 
			this.label85.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label85.Location = new System.Drawing.Point(24, 24);
			this.label85.Name = "label85";
			this.label85.Size = new System.Drawing.Size(160, 23);
			this.label85.TabIndex = 20;
			this.label85.Text = "Existing Permission Entries:";
			this.label85.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnSecEntryRemove
			// 
			this.btnSecEntryRemove.Location = new System.Drawing.Point(336, 464);
			this.btnSecEntryRemove.Name = "btnSecEntryRemove";
			this.btnSecEntryRemove.TabIndex = 18;
			this.btnSecEntryRemove.Text = "Remove";
			this.btnSecEntryRemove.Click += new System.EventHandler(this.btnSecEntryRemove_Click);
			// 
			// btnSecEntryAdd
			// 
			this.btnSecEntryAdd.Location = new System.Drawing.Point(216, 464);
			this.btnSecEntryAdd.Name = "btnSecEntryAdd";
			this.btnSecEntryAdd.Size = new System.Drawing.Size(80, 23);
			this.btnSecEntryAdd.TabIndex = 17;
			this.btnSecEntryAdd.Text = "Add";
			this.btnSecEntryAdd.Click += new System.EventHandler(this.btnSecEntryAdd_Click);
			// 
			// ckbSecEntryModify
			// 
			this.ckbSecEntryModify.Location = new System.Drawing.Point(208, 392);
			this.ckbSecEntryModify.Name = "ckbSecEntryModify";
			this.ckbSecEntryModify.Size = new System.Drawing.Size(64, 24);
			this.ckbSecEntryModify.TabIndex = 16;
			this.ckbSecEntryModify.Text = "Modify";
			this.ckbSecEntryModify.CheckedChanged += new System.EventHandler(this.ckbSecEntryModify_CheckedChanged);
			// 
			// ckbSecEntryView
			// 
			this.ckbSecEntryView.Location = new System.Drawing.Point(272, 392);
			this.ckbSecEntryView.Name = "ckbSecEntryView";
			this.ckbSecEntryView.Size = new System.Drawing.Size(56, 24);
			this.ckbSecEntryView.TabIndex = 15;
			this.ckbSecEntryView.Text = "View";
			this.ckbSecEntryView.CheckedChanged += new System.EventHandler(this.ckbSecEntryView_CheckedChanged);
			// 
			// ckbSecEntryRemove
			// 
			this.ckbSecEntryRemove.Location = new System.Drawing.Point(336, 392);
			this.ckbSecEntryRemove.Name = "ckbSecEntryRemove";
			this.ckbSecEntryRemove.Size = new System.Drawing.Size(72, 24);
			this.ckbSecEntryRemove.TabIndex = 14;
			this.ckbSecEntryRemove.Text = "Remove";
			this.ckbSecEntryRemove.CheckedChanged += new System.EventHandler(this.ckbSecEntryRemove_CheckedChanged);
			// 
			// ckbSecEntryChange
			// 
			this.ckbSecEntryChange.Location = new System.Drawing.Point(408, 392);
			this.ckbSecEntryChange.Name = "ckbSecEntryChange";
			this.ckbSecEntryChange.Size = new System.Drawing.Size(128, 24);
			this.ckbSecEntryChange.TabIndex = 13;
			this.ckbSecEntryChange.Text = "Change Permissions";
			this.ckbSecEntryChange.CheckedChanged += new System.EventHandler(this.ckbSecEntryChange_CheckedChanged);
			// 
			// ckbSecEntryControl
			// 
			this.ckbSecEntryControl.Location = new System.Drawing.Point(144, 416);
			this.ckbSecEntryControl.Name = "ckbSecEntryControl";
			this.ckbSecEntryControl.Size = new System.Drawing.Size(64, 24);
			this.ckbSecEntryControl.TabIndex = 12;
			this.ckbSecEntryControl.Text = "Control";
			this.ckbSecEntryControl.CheckedChanged += new System.EventHandler(this.ckbSecEntryControl_CheckedChanged);
			// 
			// ckbSecEntrySpecial
			// 
			this.ckbSecEntrySpecial.Enabled = false;
			this.ckbSecEntrySpecial.Location = new System.Drawing.Point(208, 416);
			this.ckbSecEntrySpecial.Name = "ckbSecEntrySpecial";
			this.ckbSecEntrySpecial.Size = new System.Drawing.Size(136, 24);
			this.ckbSecEntrySpecial.TabIndex = 11;
			this.ckbSecEntrySpecial.Text = "Special Permissions";
			// 
			// ckbSecEntryFull
			// 
			this.ckbSecEntryFull.Location = new System.Drawing.Point(144, 392);
			this.ckbSecEntryFull.Name = "ckbSecEntryFull";
			this.ckbSecEntryFull.Size = new System.Drawing.Size(56, 24);
			this.ckbSecEntryFull.TabIndex = 10;
			this.ckbSecEntryFull.Text = "Full";
			this.ckbSecEntryFull.CheckedChanged += new System.EventHandler(this.ckbSecEntryFull_CheckedChanged);
			// 
			// rdbSecEntryDeny
			// 
			this.rdbSecEntryDeny.Checked = true;
			this.rdbSecEntryDeny.Location = new System.Drawing.Point(208, 360);
			this.rdbSecEntryDeny.Name = "rdbSecEntryDeny";
			this.rdbSecEntryDeny.TabIndex = 9;
			this.rdbSecEntryDeny.TabStop = true;
			this.rdbSecEntryDeny.Text = "Deny";
			// 
			// rdbSecEntryAllow
			// 
			this.rdbSecEntryAllow.Location = new System.Drawing.Point(144, 360);
			this.rdbSecEntryAllow.Name = "rdbSecEntryAllow";
			this.rdbSecEntryAllow.Size = new System.Drawing.Size(64, 24);
			this.rdbSecEntryAllow.TabIndex = 8;
			this.rdbSecEntryAllow.Text = "Allow";
			// 
			// label84
			// 
			this.label84.Location = new System.Drawing.Point(64, 392);
			this.label84.Name = "label84";
			this.label84.Size = new System.Drawing.Size(80, 23);
			this.label84.TabIndex = 7;
			this.label84.Text = "Permissions:";
			this.label84.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label83
			// 
			this.label83.Location = new System.Drawing.Point(64, 360);
			this.label83.Name = "label83";
			this.label83.Size = new System.Drawing.Size(80, 23);
			this.label83.TabIndex = 6;
			this.label83.Text = "Type:";
			this.label83.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtSecEntryUser
			// 
			this.txtSecEntryUser.Location = new System.Drawing.Point(144, 328);
			this.txtSecEntryUser.Name = "txtSecEntryUser";
			this.txtSecEntryUser.Size = new System.Drawing.Size(160, 20);
			this.txtSecEntryUser.TabIndex = 3;
			this.txtSecEntryUser.Text = "";
			// 
			// label81
			// 
			this.label81.Location = new System.Drawing.Point(64, 325);
			this.label81.Name = "label81";
			this.label81.Size = new System.Drawing.Size(80, 23);
			this.label81.TabIndex = 2;
			this.label81.Text = "User or group:";
			this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label79
			// 
			this.label79.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label79.Location = new System.Drawing.Point(24, 280);
			this.label79.Name = "label79";
			this.label79.TabIndex = 1;
			this.label79.Text = "Permission Entry";
			// 
			// dgSecurity
			// 
			this.dgSecurity.DataMember = "";
			this.dgSecurity.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgSecurity.Location = new System.Drawing.Point(24, 56);
			this.dgSecurity.Name = "dgSecurity";
			this.dgSecurity.ReadOnly = true;
			this.dgSecurity.Size = new System.Drawing.Size(624, 208);
			this.dgSecurity.TabIndex = 0;
			this.dgSecurity.CurrentCellChanged += new System.EventHandler(this.dgSecurity_CurrentCellChanged);
			// 
			// tbpVSView
			// 
			this.tbpVSView.Controls.Add(this.dgVSView);
			this.tbpVSView.Location = new System.Drawing.Point(4, 40);
			this.tbpVSView.Name = "tbpVSView";
			this.tbpVSView.Size = new System.Drawing.Size(672, 612);
			this.tbpVSView.TabIndex = 9;
			this.tbpVSView.Text = "VS View";
			// 
			// dgVSView
			// 
			this.dgVSView.DataMember = "";
			this.dgVSView.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgVSView.Location = new System.Drawing.Point(24, 16);
			this.dgVSView.Name = "dgVSView";
			this.dgVSView.Size = new System.Drawing.Size(632, 568);
			this.dgVSView.TabIndex = 13;
			// 
			// tbpVMRC
			// 
			this.tbpVMRC.Controls.Add(this.groupBox3);
			this.tbpVMRC.Controls.Add(this.btnUpdateVMRC);
			this.tbpVMRC.Location = new System.Drawing.Point(4, 40);
			this.tbpVMRC.Name = "tbpVMRC";
			this.tbpVMRC.Size = new System.Drawing.Size(672, 612);
			this.tbpVMRC.TabIndex = 1;
			this.tbpVMRC.Text = "VMRC Properties";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label64);
			this.groupBox3.Controls.Add(this.btnSSLBrowse);
			this.groupBox3.Controls.Add(this.txtSSLCertPath);
			this.groupBox3.Controls.Add(this.label38);
			this.groupBox3.Controls.Add(this.cmbSSLKeyLength);
			this.groupBox3.Controls.Add(this.label37);
			this.groupBox3.Controls.Add(this.txtSSLCountry);
			this.groupBox3.Controls.Add(this.label36);
			this.groupBox3.Controls.Add(this.txtSSLState);
			this.groupBox3.Controls.Add(this.label35);
			this.groupBox3.Controls.Add(this.txtSSLCity);
			this.groupBox3.Controls.Add(this.label34);
			this.groupBox3.Controls.Add(this.txtSSLOU);
			this.groupBox3.Controls.Add(this.label33);
			this.groupBox3.Controls.Add(this.txtSSLOrg);
			this.groupBox3.Controls.Add(this.label32);
			this.groupBox3.Controls.Add(this.txtSSLHost);
			this.groupBox3.Controls.Add(this.label31);
			this.groupBox3.Controls.Add(this.rdbSSLDelete);
			this.groupBox3.Controls.Add(this.rdbSSLUpload);
			this.groupBox3.Controls.Add(this.rdbSSLRequest);
			this.groupBox3.Controls.Add(this.rdbSSLKeep);
			this.groupBox3.Controls.Add(this.label30);
			this.groupBox3.Controls.Add(this.ckbSSLEnable);
			this.groupBox3.Controls.Add(this.label29);
			this.groupBox3.Controls.Add(this.cmbScrRes);
			this.groupBox3.Controls.Add(this.label25);
			this.groupBox3.Controls.Add(this.txtVMRCPort);
			this.groupBox3.Controls.Add(this.label24);
			this.groupBox3.Controls.Add(this.cmbVMRCAddress);
			this.groupBox3.Controls.Add(this.label23);
			this.groupBox3.Controls.Add(this.ckbVMRCEnable);
			this.groupBox3.Controls.Add(this.label22);
			this.groupBox3.Controls.Add(this.txtVMRCTimeout);
			this.groupBox3.Controls.Add(this.label28);
			this.groupBox3.Controls.Add(this.ckbIdleEnable);
			this.groupBox3.Controls.Add(this.label27);
			this.groupBox3.Controls.Add(this.cmbVMRCAuth);
			this.groupBox3.Controls.Add(this.label26);
			this.groupBox3.Location = new System.Drawing.Point(32, 16);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(608, 552);
			this.groupBox3.TabIndex = 15;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Virtual Machine Remote Control (VMRC) Server Properties";
			// 
			// label64
			// 
			this.label64.Location = new System.Drawing.Point(32, 464);
			this.label64.Name = "label64";
			this.label64.Size = new System.Drawing.Size(416, 23);
			this.label64.TabIndex = 39;
			this.label64.Text = "It may take more time to generate a certificate with key length over 4096 bits.";
			this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnSSLBrowse
			// 
			this.btnSSLBrowse.Enabled = false;
			this.btnSSLBrowse.Location = new System.Drawing.Point(440, 512);
			this.btnSSLBrowse.Name = "btnSSLBrowse";
			this.btnSSLBrowse.TabIndex = 38;
			this.btnSSLBrowse.Text = "Browse...";
			this.btnSSLBrowse.Click += new System.EventHandler(this.btnSSLBrowse_Click);
			// 
			// txtSSLCertPath
			// 
			this.txtSSLCertPath.Enabled = false;
			this.txtSSLCertPath.Location = new System.Drawing.Point(152, 512);
			this.txtSSLCertPath.Name = "txtSSLCertPath";
			this.txtSSLCertPath.Size = new System.Drawing.Size(280, 20);
			this.txtSSLCertPath.TabIndex = 37;
			this.txtSSLCertPath.Text = "";
			// 
			// label38
			// 
			this.label38.Location = new System.Drawing.Point(32, 512);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(120, 23);
			this.label38.TabIndex = 36;
			this.label38.Text = "Upload this certificate:";
			// 
			// cmbSSLKeyLength
			// 
			this.cmbSSLKeyLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSSLKeyLength.Enabled = false;
			this.cmbSSLKeyLength.Items.AddRange(new object[] {
																 "512",
																 "1024",
																 "2048",
																 "4096",
																 "8192",
																 "16384"});
			this.cmbSSLKeyLength.Location = new System.Drawing.Point(152, 488);
			this.cmbSSLKeyLength.Name = "cmbSSLKeyLength";
			this.cmbSSLKeyLength.Size = new System.Drawing.Size(144, 21);
			this.cmbSSLKeyLength.TabIndex = 35;
			// 
			// label37
			// 
			this.label37.Location = new System.Drawing.Point(32, 488);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(112, 23);
			this.label37.TabIndex = 34;
			this.label37.Text = "Key length (in bits): ";
			// 
			// txtSSLCountry
			// 
			this.txtSSLCountry.Enabled = false;
			this.txtSSLCountry.Location = new System.Drawing.Point(152, 440);
			this.txtSSLCountry.Name = "txtSSLCountry";
			this.txtSSLCountry.Size = new System.Drawing.Size(280, 20);
			this.txtSSLCountry.TabIndex = 33;
			this.txtSSLCountry.Text = "";
			// 
			// label36
			// 
			this.label36.Location = new System.Drawing.Point(32, 440);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(112, 23);
			this.label36.TabIndex = 32;
			this.label36.Text = "Country/Region";
			// 
			// txtSSLState
			// 
			this.txtSSLState.Enabled = false;
			this.txtSSLState.Location = new System.Drawing.Point(152, 416);
			this.txtSSLState.Name = "txtSSLState";
			this.txtSSLState.Size = new System.Drawing.Size(280, 20);
			this.txtSSLState.TabIndex = 31;
			this.txtSSLState.Text = "";
			// 
			// label35
			// 
			this.label35.Location = new System.Drawing.Point(32, 416);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(112, 23);
			this.label35.TabIndex = 30;
			this.label35.Text = "State/Province";
			// 
			// txtSSLCity
			// 
			this.txtSSLCity.Enabled = false;
			this.txtSSLCity.Location = new System.Drawing.Point(152, 392);
			this.txtSSLCity.Name = "txtSSLCity";
			this.txtSSLCity.Size = new System.Drawing.Size(280, 20);
			this.txtSSLCity.TabIndex = 29;
			this.txtSSLCity.Text = "";
			// 
			// label34
			// 
			this.label34.Location = new System.Drawing.Point(32, 392);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(112, 23);
			this.label34.TabIndex = 28;
			this.label34.Text = "City:";
			// 
			// txtSSLOU
			// 
			this.txtSSLOU.Enabled = false;
			this.txtSSLOU.Location = new System.Drawing.Point(152, 368);
			this.txtSSLOU.Name = "txtSSLOU";
			this.txtSSLOU.Size = new System.Drawing.Size(280, 20);
			this.txtSSLOU.TabIndex = 27;
			this.txtSSLOU.Text = "";
			// 
			// label33
			// 
			this.label33.Location = new System.Drawing.Point(32, 368);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(112, 23);
			this.label33.TabIndex = 26;
			this.label33.Text = "Organizational unit:";
			// 
			// txtSSLOrg
			// 
			this.txtSSLOrg.Enabled = false;
			this.txtSSLOrg.Location = new System.Drawing.Point(152, 344);
			this.txtSSLOrg.Name = "txtSSLOrg";
			this.txtSSLOrg.Size = new System.Drawing.Size(280, 20);
			this.txtSSLOrg.TabIndex = 25;
			this.txtSSLOrg.Text = "";
			// 
			// label32
			// 
			this.label32.Location = new System.Drawing.Point(32, 344);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(112, 23);
			this.label32.TabIndex = 24;
			this.label32.Text = "Organization:";
			// 
			// txtSSLHost
			// 
			this.txtSSLHost.Enabled = false;
			this.txtSSLHost.Location = new System.Drawing.Point(152, 320);
			this.txtSSLHost.Name = "txtSSLHost";
			this.txtSSLHost.Size = new System.Drawing.Size(280, 20);
			this.txtSSLHost.TabIndex = 23;
			this.txtSSLHost.Text = "";
			// 
			// label31
			// 
			this.label31.Location = new System.Drawing.Point(32, 320);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(112, 23);
			this.label31.TabIndex = 22;
			this.label31.Text = "Host Name:";
			// 
			// rdbSSLDelete
			// 
			this.rdbSSLDelete.Enabled = false;
			this.rdbSSLDelete.Location = new System.Drawing.Point(384, 288);
			this.rdbSSLDelete.Name = "rdbSSLDelete";
			this.rdbSSLDelete.Size = new System.Drawing.Size(72, 24);
			this.rdbSSLDelete.TabIndex = 21;
			this.rdbSSLDelete.Text = "Delete";
			this.rdbSSLDelete.CheckedChanged += new System.EventHandler(this.rdbSSLDelete_CheckedChanged);
			// 
			// rdbSSLUpload
			// 
			this.rdbSSLUpload.Enabled = false;
			this.rdbSSLUpload.Location = new System.Drawing.Point(312, 288);
			this.rdbSSLUpload.Name = "rdbSSLUpload";
			this.rdbSSLUpload.Size = new System.Drawing.Size(64, 24);
			this.rdbSSLUpload.TabIndex = 20;
			this.rdbSSLUpload.Text = "Upload";
			this.rdbSSLUpload.CheckedChanged += new System.EventHandler(this.rdbSSLUpload_CheckedChanged);
			// 
			// rdbSSLRequest
			// 
			this.rdbSSLRequest.Enabled = false;
			this.rdbSSLRequest.Location = new System.Drawing.Point(240, 288);
			this.rdbSSLRequest.Name = "rdbSSLRequest";
			this.rdbSSLRequest.Size = new System.Drawing.Size(72, 24);
			this.rdbSSLRequest.TabIndex = 19;
			this.rdbSSLRequest.Text = "Request";
			this.rdbSSLRequest.CheckedChanged += new System.EventHandler(this.rdbSSLRequest_CheckedChanged);
			// 
			// rdbSSLKeep
			// 
			this.rdbSSLKeep.Checked = true;
			this.rdbSSLKeep.Enabled = false;
			this.rdbSSLKeep.Location = new System.Drawing.Point(176, 288);
			this.rdbSSLKeep.Name = "rdbSSLKeep";
			this.rdbSSLKeep.Size = new System.Drawing.Size(56, 24);
			this.rdbSSLKeep.TabIndex = 18;
			this.rdbSSLKeep.TabStop = true;
			this.rdbSSLKeep.Text = "Keep";
			this.rdbSSLKeep.CheckedChanged += new System.EventHandler(this.rdbSSLKeep_CheckedChanged);
			// 
			// label30
			// 
			this.label30.Location = new System.Drawing.Point(24, 288);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(144, 23);
			this.label30.TabIndex = 17;
			this.label30.Text = "SSL 3.0/TLS 1.0 certificate";
			// 
			// ckbSSLEnable
			// 
			this.ckbSSLEnable.Location = new System.Drawing.Point(184, 256);
			this.ckbSSLEnable.Name = "ckbSSLEnable";
			this.ckbSSLEnable.TabIndex = 16;
			this.ckbSSLEnable.Text = "Enable";
			this.ckbSSLEnable.CheckedChanged += new System.EventHandler(this.ckbSSLEnable_CheckedChanged);
			// 
			// label29
			// 
			this.label29.Location = new System.Drawing.Point(24, 256);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(152, 23);
			this.label29.TabIndex = 15;
			this.label29.Text = "SSL 3.0/TLS 1.0 encryption";
			// 
			// cmbScrRes
			// 
			this.cmbScrRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbScrRes.Location = new System.Drawing.Point(192, 128);
			this.cmbScrRes.Name = "cmbScrRes";
			this.cmbScrRes.Size = new System.Drawing.Size(232, 21);
			this.cmbScrRes.TabIndex = 14;
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(16, 128);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(136, 23);
			this.label25.TabIndex = 6;
			this.label25.Text = "Default screen resolution";
			// 
			// txtVMRCPort
			// 
			this.txtVMRCPort.Enabled = false;
			this.txtVMRCPort.Location = new System.Drawing.Point(192, 96);
			this.txtVMRCPort.Name = "txtVMRCPort";
			this.txtVMRCPort.Size = new System.Drawing.Size(232, 20);
			this.txtVMRCPort.TabIndex = 5;
			this.txtVMRCPort.Text = "";
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(32, 96);
			this.label24.Name = "label24";
			this.label24.TabIndex = 4;
			this.label24.Text = "TCP/IP Port:";
			// 
			// cmbVMRCAddress
			// 
			this.cmbVMRCAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbVMRCAddress.Enabled = false;
			this.cmbVMRCAddress.Location = new System.Drawing.Point(192, 64);
			this.cmbVMRCAddress.Name = "cmbVMRCAddress";
			this.cmbVMRCAddress.Size = new System.Drawing.Size(232, 21);
			this.cmbVMRCAddress.TabIndex = 3;
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(32, 64);
			this.label23.Name = "label23";
			this.label23.TabIndex = 2;
			this.label23.Text = "TCP/IP Address:";
			// 
			// ckbVMRCEnable
			// 
			this.ckbVMRCEnable.Location = new System.Drawing.Point(192, 32);
			this.ckbVMRCEnable.Name = "ckbVMRCEnable";
			this.ckbVMRCEnable.TabIndex = 1;
			this.ckbVMRCEnable.Text = "Enable";
			this.ckbVMRCEnable.CheckedChanged += new System.EventHandler(this.ckbVMRCEnable_CheckedChanged);
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(32, 32);
			this.label22.Name = "label22";
			this.label22.TabIndex = 0;
			this.label22.Text = "VMRC Server";
			// 
			// txtVMRCTimeout
			// 
			this.txtVMRCTimeout.Enabled = false;
			this.txtVMRCTimeout.Location = new System.Drawing.Point(424, 208);
			this.txtVMRCTimeout.Name = "txtVMRCTimeout";
			this.txtVMRCTimeout.TabIndex = 13;
			this.txtVMRCTimeout.Text = "";
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(304, 208);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(120, 23);
			this.label28.TabIndex = 12;
			this.label28.Text = "Timeout (in minutes):";
			// 
			// ckbIdleEnable
			// 
			this.ckbIdleEnable.Enabled = false;
			this.ckbIdleEnable.Location = new System.Drawing.Point(192, 207);
			this.ckbIdleEnable.Name = "ckbIdleEnable";
			this.ckbIdleEnable.TabIndex = 11;
			this.ckbIdleEnable.Text = "Enable";
			this.ckbIdleEnable.CheckedChanged += new System.EventHandler(this.ckbIdleEnable_CheckedChanged);
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(24, 208);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(152, 23);
			this.label27.TabIndex = 10;
			this.label27.Text = "Disconnect idle connections";
			// 
			// cmbVMRCAuth
			// 
			this.cmbVMRCAuth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbVMRCAuth.Enabled = false;
			this.cmbVMRCAuth.Location = new System.Drawing.Point(192, 168);
			this.cmbVMRCAuth.Name = "cmbVMRCAuth";
			this.cmbVMRCAuth.Size = new System.Drawing.Size(232, 21);
			this.cmbVMRCAuth.TabIndex = 9;
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(32, 168);
			this.label26.Name = "label26";
			this.label26.TabIndex = 8;
			this.label26.Text = "Authentication";
			// 
			// btnUpdateVMRC
			// 
			this.btnUpdateVMRC.Location = new System.Drawing.Point(288, 576);
			this.btnUpdateVMRC.Name = "btnUpdateVMRC";
			this.btnUpdateVMRC.TabIndex = 14;
			this.btnUpdateVMRC.Text = "Update";
			this.btnUpdateVMRC.Click += new System.EventHandler(this.btnUpdateVMRC_Click);
			// 
			// tbpSearchPath
			// 
			this.tbpSearchPath.Controls.Add(this.btnRemoveSearchPath);
			this.tbpSearchPath.Controls.Add(this.btnAddSearchPath);
			this.tbpSearchPath.Controls.Add(this.btnSelectNewSearchPath);
			this.tbpSearchPath.Controls.Add(this.txtSearchPathNew);
			this.tbpSearchPath.Controls.Add(this.button1);
			this.tbpSearchPath.Controls.Add(this.txtConfFolder);
			this.tbpSearchPath.Controls.Add(this.lstSearchPath);
			this.tbpSearchPath.Controls.Add(this.label17);
			this.tbpSearchPath.Controls.Add(this.label13);
			this.tbpSearchPath.Location = new System.Drawing.Point(4, 40);
			this.tbpSearchPath.Name = "tbpSearchPath";
			this.tbpSearchPath.Size = new System.Drawing.Size(672, 612);
			this.tbpSearchPath.TabIndex = 2;
			this.tbpSearchPath.Text = "Search Path";
			// 
			// btnRemoveSearchPath
			// 
			this.btnRemoveSearchPath.Location = new System.Drawing.Point(336, 544);
			this.btnRemoveSearchPath.Name = "btnRemoveSearchPath";
			this.btnRemoveSearchPath.TabIndex = 10;
			this.btnRemoveSearchPath.Text = "Remove";
			this.btnRemoveSearchPath.Click += new System.EventHandler(this.btnRemoveSearchPath_Click);
			// 
			// btnAddSearchPath
			// 
			this.btnAddSearchPath.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAddSearchPath.Location = new System.Drawing.Point(216, 544);
			this.btnAddSearchPath.Name = "btnAddSearchPath";
			this.btnAddSearchPath.TabIndex = 9;
			this.btnAddSearchPath.Text = "Add";
			this.btnAddSearchPath.Click += new System.EventHandler(this.btnAddSearchPath_Click);
			// 
			// btnSelectNewSearchPath
			// 
			this.btnSelectNewSearchPath.Location = new System.Drawing.Point(520, 504);
			this.btnSelectNewSearchPath.Name = "btnSelectNewSearchPath";
			this.btnSelectNewSearchPath.TabIndex = 8;
			this.btnSelectNewSearchPath.Text = "Select";
			this.btnSelectNewSearchPath.Click += new System.EventHandler(this.btnSelectNewSearchPath_Click);
			// 
			// txtSearchPathNew
			// 
			this.txtSearchPathNew.Location = new System.Drawing.Point(104, 504);
			this.txtSearchPathNew.Name = "txtSearchPathNew";
			this.txtSearchPathNew.Size = new System.Drawing.Size(384, 20);
			this.txtSearchPathNew.TabIndex = 7;
			this.txtSearchPathNew.Text = "";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(536, 80);
			this.button1.Name = "button1";
			this.button1.TabIndex = 6;
			this.button1.Text = "Select";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtConfFolder
			// 
			this.txtConfFolder.Location = new System.Drawing.Point(32, 80);
			this.txtConfFolder.Name = "txtConfFolder";
			this.txtConfFolder.Size = new System.Drawing.Size(480, 20);
			this.txtConfFolder.TabIndex = 5;
			this.txtConfFolder.Text = "";
			// 
			// lstSearchPath
			// 
			this.lstSearchPath.Location = new System.Drawing.Point(32, 168);
			this.lstSearchPath.Name = "lstSearchPath";
			this.lstSearchPath.Size = new System.Drawing.Size(576, 316);
			this.lstSearchPath.TabIndex = 4;
			this.lstSearchPath.SelectedIndexChanged += new System.EventHandler(this.lstSearchPath_SelectedIndexChanged);
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(24, 136);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(352, 23);
			this.label17.TabIndex = 2;
			this.label17.Text = "Search paths: (to enter multiple paths, enter each on a separate line)";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(32, 40);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(240, 23);
			this.label13.TabIndex = 1;
			this.label13.Text = "Default virtual machine configuration folder:";
			// 
			// tbpEvent
			// 
			this.tbpEvent.Controls.Add(this.lblEventMessage);
			this.tbpEvent.Controls.Add(this.label65);
			this.tbpEvent.Controls.Add(this.lvEvent);
			this.tbpEvent.Controls.Add(this.cmbEventMax);
			this.tbpEvent.Controls.Add(this.btnRefreshEvent);
			this.tbpEvent.Controls.Add(this.cmbFilter);
			this.tbpEvent.Controls.Add(this.label20);
			this.tbpEvent.Location = new System.Drawing.Point(4, 40);
			this.tbpEvent.Name = "tbpEvent";
			this.tbpEvent.Size = new System.Drawing.Size(672, 612);
			this.tbpEvent.TabIndex = 3;
			this.tbpEvent.Text = "Events";
			// 
			// lblEventMessage
			// 
			this.lblEventMessage.Location = new System.Drawing.Point(128, 472);
			this.lblEventMessage.Name = "lblEventMessage";
			this.lblEventMessage.Size = new System.Drawing.Size(528, 120);
			this.lblEventMessage.TabIndex = 7;
			// 
			// label65
			// 
			this.label65.Location = new System.Drawing.Point(24, 472);
			this.label65.Name = "label65";
			this.label65.TabIndex = 6;
			this.label65.Text = "Event Message:";
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
			this.lvEvent.Location = new System.Drawing.Point(24, 88);
			this.lvEvent.MultiSelect = false;
			this.lvEvent.Name = "lvEvent";
			this.lvEvent.Size = new System.Drawing.Size(632, 368);
			this.lvEvent.SmallImageList = this.imageList1;
			this.lvEvent.TabIndex = 5;
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
			this.colUser.Width = 177;
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
			// cmbEventMax
			// 
			this.cmbEventMax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEventMax.Items.AddRange(new object[] {
															 "10",
															 "30",
															 "50",
															 "100"});
			this.cmbEventMax.Location = new System.Drawing.Point(320, 40);
			this.cmbEventMax.Name = "cmbEventMax";
			this.cmbEventMax.Size = new System.Drawing.Size(121, 21);
			this.cmbEventMax.TabIndex = 4;
			// 
			// btnRefreshEvent
			// 
			this.btnRefreshEvent.Location = new System.Drawing.Point(480, 40);
			this.btnRefreshEvent.Name = "btnRefreshEvent";
			this.btnRefreshEvent.TabIndex = 2;
			this.btnRefreshEvent.Text = "Refresh";
			this.btnRefreshEvent.Click += new System.EventHandler(this.btnRefreshEvent_Click);
			// 
			// cmbFilter
			// 
			this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFilter.Items.AddRange(new object[] {
														   "All Events",
														   "Virtual Server Events",
														   "Virtual Disk Operation Events",
														   "Setting Change Events",
														   "Remote Control Events"});
			this.cmbFilter.Location = new System.Drawing.Point(144, 40);
			this.cmbFilter.Name = "cmbFilter";
			this.cmbFilter.Size = new System.Drawing.Size(160, 21);
			this.cmbFilter.TabIndex = 1;
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(32, 40);
			this.label20.Name = "label20";
			this.label20.TabIndex = 0;
			this.label20.Text = "Current filter:";
			// 
			// tbpResource
			// 
			this.tbpResource.Controls.Add(this.groupBox5);
			this.tbpResource.Controls.Add(this.lblACR);
			this.tbpResource.Controls.Add(this.label42);
			this.tbpResource.Controls.Add(this.lblTCR);
			this.tbpResource.Controls.Add(this.label40);
			this.tbpResource.Controls.Add(this.lvResource);
			this.tbpResource.Location = new System.Drawing.Point(4, 40);
			this.tbpResource.Name = "tbpResource";
			this.tbpResource.Size = new System.Drawing.Size(672, 612);
			this.tbpResource.TabIndex = 4;
			this.tbpResource.Text = "Resource";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.label47);
			this.groupBox5.Controls.Add(this.label46);
			this.groupBox5.Controls.Add(this.label45);
			this.groupBox5.Controls.Add(this.label44);
			this.groupBox5.Controls.Add(this.label43);
			this.groupBox5.Controls.Add(this.label41);
			this.groupBox5.Controls.Add(this.btnUpdateResource);
			this.groupBox5.Controls.Add(this.txtRW);
			this.groupBox5.Controls.Add(this.lblVM);
			this.groupBox5.Controls.Add(this.lblMSC);
			this.groupBox5.Controls.Add(this.lblRSC);
			this.groupBox5.Controls.Add(this.txtMCC);
			this.groupBox5.Controls.Add(this.txtRCC);
			this.groupBox5.Controls.Add(this.btnLoad);
			this.groupBox5.Location = new System.Drawing.Point(8, 448);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(656, 152);
			this.groupBox5.TabIndex = 11;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Update Resource Allocation";
			// 
			// label47
			// 
			this.label47.Location = new System.Drawing.Point(544, 40);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(104, 23);
			this.label47.TabIndex = 17;
			this.label47.Text = "Maximum System%";
			// 
			// label46
			// 
			this.label46.Location = new System.Drawing.Point(440, 40);
			this.label46.Name = "label46";
			this.label46.TabIndex = 16;
			this.label46.Text = "Reserved Sysem%";
			// 
			// label45
			// 
			this.label45.Location = new System.Drawing.Point(344, 40);
			this.label45.Name = "label45";
			this.label45.TabIndex = 15;
			this.label45.Text = "Maximum CPU%";
			// 
			// label44
			// 
			this.label44.Location = new System.Drawing.Point(248, 40);
			this.label44.Name = "label44";
			this.label44.TabIndex = 14;
			this.label44.Text = "Reserved CPU%";
			// 
			// label43
			// 
			this.label43.Location = new System.Drawing.Point(152, 40);
			this.label43.Name = "label43";
			this.label43.TabIndex = 13;
			this.label43.Text = "Relative Weight";
			// 
			// label41
			// 
			this.label41.Location = new System.Drawing.Point(8, 40);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(144, 23);
			this.label41.TabIndex = 12;
			this.label41.Text = "Virtual Machine";
			// 
			// btnUpdateResource
			// 
			this.btnUpdateResource.Enabled = false;
			this.btnUpdateResource.Location = new System.Drawing.Point(296, 112);
			this.btnUpdateResource.Name = "btnUpdateResource";
			this.btnUpdateResource.Size = new System.Drawing.Size(104, 23);
			this.btnUpdateResource.TabIndex = 11;
			this.btnUpdateResource.Text = "Update";
			this.btnUpdateResource.Click += new System.EventHandler(this.btnUpdateResource_Click);
			// 
			// txtRW
			// 
			this.txtRW.Location = new System.Drawing.Point(152, 72);
			this.txtRW.Name = "txtRW";
			this.txtRW.Size = new System.Drawing.Size(88, 20);
			this.txtRW.TabIndex = 6;
			this.txtRW.Text = "";
			// 
			// lblVM
			// 
			this.lblVM.Location = new System.Drawing.Point(8, 72);
			this.lblVM.Name = "lblVM";
			this.lblVM.Size = new System.Drawing.Size(152, 23);
			this.lblVM.TabIndex = 5;
			this.lblVM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMSC
			// 
			this.lblMSC.Location = new System.Drawing.Point(544, 72);
			this.lblMSC.Name = "lblMSC";
			this.lblMSC.TabIndex = 10;
			this.lblMSC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblRSC
			// 
			this.lblRSC.Location = new System.Drawing.Point(440, 72);
			this.lblRSC.Name = "lblRSC";
			this.lblRSC.TabIndex = 9;
			this.lblRSC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMCC
			// 
			this.txtMCC.Location = new System.Drawing.Point(352, 72);
			this.txtMCC.Name = "txtMCC";
			this.txtMCC.Size = new System.Drawing.Size(80, 20);
			this.txtMCC.TabIndex = 8;
			this.txtMCC.Text = "";
			// 
			// txtRCC
			// 
			this.txtRCC.Location = new System.Drawing.Point(248, 72);
			this.txtRCC.Name = "txtRCC";
			this.txtRCC.Size = new System.Drawing.Size(88, 20);
			this.txtRCC.TabIndex = 7;
			this.txtRCC.Text = "";
			// 
			// btnLoad
			// 
			this.btnLoad.Location = new System.Drawing.Point(192, 112);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(88, 23);
			this.btnLoad.TabIndex = 12;
			this.btnLoad.Text = "Load";
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// lblACR
			// 
			this.lblACR.BackColor = System.Drawing.Color.YellowGreen;
			this.lblACR.Location = new System.Drawing.Point(448, 32);
			this.lblACR.Name = "lblACR";
			this.lblACR.TabIndex = 4;
			this.lblACR.Text = "100%";
			this.lblACR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label42
			// 
			this.label42.BackColor = System.Drawing.Color.YellowGreen;
			this.label42.Location = new System.Drawing.Point(280, 32);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(168, 23);
			this.label42.TabIndex = 3;
			this.label42.Text = "Available Capacity Remaining";
			// 
			// lblTCR
			// 
			this.lblTCR.BackColor = System.Drawing.Color.YellowGreen;
			this.lblTCR.Location = new System.Drawing.Point(448, 16);
			this.lblTCR.Name = "lblTCR";
			this.lblTCR.TabIndex = 2;
			this.lblTCR.Text = "0%";
			this.lblTCR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label40
			// 
			this.label40.BackColor = System.Drawing.Color.YellowGreen;
			this.label40.Location = new System.Drawing.Point(280, 16);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(168, 23);
			this.label40.TabIndex = 1;
			this.label40.Text = "Total Capacity Reserved";
			// 
			// lvResource
			// 
			this.lvResource.AutoArrange = false;
			this.lvResource.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.columnHeader1,
																						 this.columnHeader2,
																						 this.columnHeader3,
																						 this.columnHeader4,
																						 this.columnHeader5,
																						 this.columnHeader6});
			this.lvResource.FullRowSelect = true;
			this.lvResource.GridLines = true;
			this.lvResource.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvResource.Location = new System.Drawing.Point(16, 56);
			this.lvResource.MultiSelect = false;
			this.lvResource.Name = "lvResource";
			this.lvResource.Size = new System.Drawing.Size(640, 352);
			this.lvResource.TabIndex = 0;
			this.lvResource.View = System.Windows.Forms.View.Details;
			this.lvResource.SelectedIndexChanged += new System.EventHandler(this.lvResource_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Virtual Machine";
			this.columnHeader1.Width = 152;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Relative Weight";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader2.Width = 90;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Reserved CPU%";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader3.Width = 92;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Maximum CPU%";
			this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader4.Width = 89;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Reserved System%";
			this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader5.Width = 108;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Maximum System%";
			this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader6.Width = 104;
			// 
			// tbpScripts
			// 
			this.tbpScripts.Controls.Add(this.groupBox9);
			this.tbpScripts.Controls.Add(this.btnScriptUpdate);
			this.tbpScripts.Controls.Add(this.btnScriptRemove);
			this.tbpScripts.Controls.Add(this.btnScriptAttach);
			this.tbpScripts.Controls.Add(this.txtScript);
			this.tbpScripts.Controls.Add(this.label86);
			this.tbpScripts.Controls.Add(this.lblScriptEvent);
			this.tbpScripts.Controls.Add(this.label87);
			this.tbpScripts.Controls.Add(this.lvScripts);
			this.tbpScripts.Location = new System.Drawing.Point(4, 40);
			this.tbpScripts.Name = "tbpScripts";
			this.tbpScripts.Size = new System.Drawing.Size(672, 612);
			this.tbpScripts.TabIndex = 11;
			this.tbpScripts.Text = "Scripts";
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.ckbScriptVSEnabled);
			this.groupBox9.Controls.Add(this.ckbScriptVMEnabled);
			this.groupBox9.Controls.Add(this.btnScriptVSVMUpdate);
			this.groupBox9.Location = new System.Drawing.Point(24, 24);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(624, 88);
			this.groupBox9.TabIndex = 18;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Scripts for Virtual Server and Virtual Machines";
			// 
			// ckbScriptVSEnabled
			// 
			this.ckbScriptVSEnabled.Location = new System.Drawing.Point(8, 24);
			this.ckbScriptVSEnabled.Name = "ckbScriptVSEnabled";
			this.ckbScriptVSEnabled.Size = new System.Drawing.Size(208, 24);
			this.ckbScriptVSEnabled.TabIndex = 1;
			this.ckbScriptVSEnabled.Text = "Enable scripts attached to this server";
			this.ckbScriptVSEnabled.CheckedChanged += new System.EventHandler(this.ckbScriptVSEnabled_CheckedChanged);
			// 
			// ckbScriptVMEnabled
			// 
			this.ckbScriptVMEnabled.Location = new System.Drawing.Point(224, 24);
			this.ckbScriptVMEnabled.Name = "ckbScriptVMEnabled";
			this.ckbScriptVMEnabled.Size = new System.Drawing.Size(352, 24);
			this.ckbScriptVMEnabled.TabIndex = 2;
			this.ckbScriptVMEnabled.Text = "Enable scripts attached to virtual machines running on this server";
			this.ckbScriptVMEnabled.CheckedChanged += new System.EventHandler(this.ckbScriptVMEnabled_CheckedChanged);
			// 
			// btnScriptVSVMUpdate
			// 
			this.btnScriptVSVMUpdate.Enabled = false;
			this.btnScriptVSVMUpdate.Location = new System.Drawing.Point(528, 56);
			this.btnScriptVSVMUpdate.Name = "btnScriptVSVMUpdate";
			this.btnScriptVSVMUpdate.TabIndex = 17;
			this.btnScriptVSVMUpdate.Text = "Update";
			this.btnScriptVSVMUpdate.Click += new System.EventHandler(this.btnScriptVMVMUpdate_Click);
			// 
			// btnScriptUpdate
			// 
			this.btnScriptUpdate.Location = new System.Drawing.Point(328, 512);
			this.btnScriptUpdate.Name = "btnScriptUpdate";
			this.btnScriptUpdate.TabIndex = 16;
			this.btnScriptUpdate.Text = "Update";
			this.btnScriptUpdate.Click += new System.EventHandler(this.btnScriptUpdate_Click);
			// 
			// btnScriptRemove
			// 
			this.btnScriptRemove.Location = new System.Drawing.Point(424, 512);
			this.btnScriptRemove.Name = "btnScriptRemove";
			this.btnScriptRemove.TabIndex = 15;
			this.btnScriptRemove.Text = "Remove";
			this.btnScriptRemove.Click += new System.EventHandler(this.btnScriptRemove_Click);
			// 
			// btnScriptAttach
			// 
			this.btnScriptAttach.Location = new System.Drawing.Point(232, 512);
			this.btnScriptAttach.Name = "btnScriptAttach";
			this.btnScriptAttach.TabIndex = 14;
			this.btnScriptAttach.Text = "Attach";
			this.btnScriptAttach.Click += new System.EventHandler(this.btnScriptAttach_Click);
			// 
			// txtScript
			// 
			this.txtScript.Location = new System.Drawing.Point(136, 464);
			this.txtScript.Name = "txtScript";
			this.txtScript.Size = new System.Drawing.Size(488, 20);
			this.txtScript.TabIndex = 13;
			this.txtScript.Text = "";
			// 
			// label86
			// 
			this.label86.Location = new System.Drawing.Point(32, 464);
			this.label86.Name = "label86";
			this.label86.TabIndex = 12;
			this.label86.Text = "Script:";
			// 
			// lblScriptEvent
			// 
			this.lblScriptEvent.Location = new System.Drawing.Point(136, 440);
			this.lblScriptEvent.Name = "lblScriptEvent";
			this.lblScriptEvent.Size = new System.Drawing.Size(488, 23);
			this.lblScriptEvent.TabIndex = 11;
			// 
			// label87
			// 
			this.label87.Location = new System.Drawing.Point(32, 440);
			this.label87.Name = "label87";
			this.label87.TabIndex = 10;
			this.label87.Text = "Event:";
			// 
			// lvScripts
			// 
			this.lvScripts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.colScriptEvent,
																						this.colScriptAction});
			this.lvScripts.FullRowSelect = true;
			this.lvScripts.Location = new System.Drawing.Point(32, 128);
			this.lvScripts.MultiSelect = false;
			this.lvScripts.Name = "lvScripts";
			this.lvScripts.Size = new System.Drawing.Size(608, 296);
			this.lvScripts.TabIndex = 0;
			this.lvScripts.View = System.Windows.Forms.View.Details;
			this.lvScripts.SelectedIndexChanged += new System.EventHandler(this.lvScripts_SelectedIndexChanged);
			// 
			// colScriptEvent
			// 
			this.colScriptEvent.Text = "Virtual Server Event";
			this.colScriptEvent.Width = 261;
			// 
			// colScriptAction
			// 
			this.colScriptAction.Text = "Script";
			this.colScriptAction.Width = 343;
			// 
			// tbpPC
			// 
			this.tbpPC.Controls.Add(this.groupBox2);
			this.tbpPC.Location = new System.Drawing.Point(4, 40);
			this.tbpPC.Name = "tbpPC";
			this.tbpPC.Size = new System.Drawing.Size(672, 612);
			this.tbpPC.TabIndex = 5;
			this.tbpPC.Text = "Physical Computer";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lstNIC);
			this.groupBox2.Controls.Add(this.lblProcFeature);
			this.groupBox2.Controls.Add(this.label18);
			this.groupBox2.Controls.Add(this.lblProcVersion);
			this.groupBox2.Controls.Add(this.label16);
			this.groupBox2.Controls.Add(this.lblProcType);
			this.groupBox2.Controls.Add(this.label14);
			this.groupBox2.Controls.Add(this.lblProcSpeed);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.lblLProc);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.lblPProc);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.lblTotalMemory);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.lblAvailableMemory);
			this.groupBox2.Controls.Add(this.label15);
			this.groupBox2.Controls.Add(this.label19);
			this.groupBox2.Controls.Add(this.label21);
			this.groupBox2.Controls.Add(this.lblOS);
			this.groupBox2.Location = new System.Drawing.Point(24, 24);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(632, 352);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Physical Computer Properties";
			// 
			// lstNIC
			// 
			this.lstNIC.BackColor = System.Drawing.SystemColors.Control;
			this.lstNIC.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lstNIC.Location = new System.Drawing.Point(152, 208);
			this.lstNIC.Name = "lstNIC";
			this.lstNIC.SelectionMode = System.Windows.Forms.SelectionMode.None;
			this.lstNIC.Size = new System.Drawing.Size(464, 91);
			this.lstNIC.TabIndex = 13;
			this.lstNIC.TabStop = false;
			// 
			// lblProcFeature
			// 
			this.lblProcFeature.Location = new System.Drawing.Point(272, 144);
			this.lblProcFeature.Name = "lblProcFeature";
			this.lblProcFeature.Size = new System.Drawing.Size(344, 23);
			this.lblProcFeature.TabIndex = 12;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(112, 144);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(152, 23);
			this.label18.TabIndex = 11;
			this.label18.Text = "Processor features:";
			// 
			// lblProcVersion
			// 
			this.lblProcVersion.Location = new System.Drawing.Point(272, 120);
			this.lblProcVersion.Name = "lblProcVersion";
			this.lblProcVersion.Size = new System.Drawing.Size(344, 23);
			this.lblProcVersion.TabIndex = 10;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(112, 120);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(152, 23);
			this.label16.TabIndex = 9;
			this.label16.Text = "Processor version:";
			// 
			// lblProcType
			// 
			this.lblProcType.Location = new System.Drawing.Point(272, 96);
			this.lblProcType.Name = "lblProcType";
			this.lblProcType.Size = new System.Drawing.Size(344, 23);
			this.lblProcType.TabIndex = 8;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(112, 96);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(152, 23);
			this.label14.TabIndex = 7;
			this.label14.Text = "Processor type:";
			// 
			// lblProcSpeed
			// 
			this.lblProcSpeed.Location = new System.Drawing.Point(272, 72);
			this.lblProcSpeed.Name = "lblProcSpeed";
			this.lblProcSpeed.Size = new System.Drawing.Size(344, 23);
			this.lblProcSpeed.TabIndex = 6;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(112, 72);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(152, 23);
			this.label12.TabIndex = 5;
			this.label12.Text = "Processor speed:";
			// 
			// lblLProc
			// 
			this.lblLProc.Location = new System.Drawing.Point(272, 48);
			this.lblLProc.Name = "lblLProc";
			this.lblLProc.Size = new System.Drawing.Size(344, 23);
			this.lblLProc.TabIndex = 4;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(112, 48);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(152, 23);
			this.label9.TabIndex = 3;
			this.label9.Text = "Logical processors:";
			// 
			// lblPProc
			// 
			this.lblPProc.Location = new System.Drawing.Point(272, 24);
			this.lblPProc.Name = "lblPProc";
			this.lblPProc.Size = new System.Drawing.Size(344, 23);
			this.lblPProc.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(112, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(152, 23);
			this.label3.TabIndex = 1;
			this.label3.Text = "Physical processors:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "Processors";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 176);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(96, 23);
			this.label5.TabIndex = 0;
			this.label5.Text = "Physical Memory";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(152, 176);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 23);
			this.label7.TabIndex = 11;
			this.label7.Text = "Total:";
			// 
			// lblTotalMemory
			// 
			this.lblTotalMemory.Location = new System.Drawing.Point(192, 176);
			this.lblTotalMemory.Name = "lblTotalMemory";
			this.lblTotalMemory.Size = new System.Drawing.Size(72, 23);
			this.lblTotalMemory.TabIndex = 11;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(336, 176);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(56, 23);
			this.label11.TabIndex = 11;
			this.label11.Text = "Available:";
			// 
			// lblAvailableMemory
			// 
			this.lblAvailableMemory.Location = new System.Drawing.Point(392, 176);
			this.lblAvailableMemory.Name = "lblAvailableMemory";
			this.lblAvailableMemory.Size = new System.Drawing.Size(72, 23);
			this.lblAvailableMemory.TabIndex = 11;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(16, 208);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(112, 23);
			this.label15.TabIndex = 0;
			this.label15.Text = "Network connections";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(16, 208);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(112, 23);
			this.label19.TabIndex = 0;
			this.label19.Text = "Network connections";
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(16, 312);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(112, 23);
			this.label21.TabIndex = 0;
			this.label21.Text = "Operating System";
			// 
			// lblOS
			// 
			this.lblOS.Location = new System.Drawing.Point(144, 312);
			this.lblOS.Name = "lblOS";
			this.lblOS.Size = new System.Drawing.Size(472, 23);
			this.lblOS.TabIndex = 12;
			// 
			// tbpVN
			// 
			this.tbpVN.Controls.Add(this.btnVNAddExisting);
			this.tbpVN.Controls.Add(this.btnRemoveVN);
			this.tbpVN.Controls.Add(this.btnUpdateVN);
			this.tbpVN.Controls.Add(this.btnAddVN);
			this.tbpVN.Controls.Add(this.groupBox6);
			this.tbpVN.Controls.Add(this.groupBox4);
			this.tbpVN.Controls.Add(this.label50);
			this.tbpVN.Controls.Add(this.lstVNVM);
			this.tbpVN.Controls.Add(this.lstVN);
			this.tbpVN.Location = new System.Drawing.Point(4, 40);
			this.tbpVN.Name = "tbpVN";
			this.tbpVN.Size = new System.Drawing.Size(672, 612);
			this.tbpVN.TabIndex = 6;
			this.tbpVN.Text = "Virtual Network";
			// 
			// btnVNAddExisting
			// 
			this.btnVNAddExisting.Location = new System.Drawing.Point(144, 576);
			this.btnVNAddExisting.Name = "btnVNAddExisting";
			this.btnVNAddExisting.Size = new System.Drawing.Size(112, 23);
			this.btnVNAddExisting.TabIndex = 16;
			this.btnVNAddExisting.Text = "Add Existing VN";
			this.btnVNAddExisting.Click += new System.EventHandler(this.btnVNAddExisting_Click);
			// 
			// btnRemoveVN
			// 
			this.btnRemoveVN.Location = new System.Drawing.Point(480, 576);
			this.btnRemoveVN.Name = "btnRemoveVN";
			this.btnRemoveVN.TabIndex = 15;
			this.btnRemoveVN.Text = "Remove";
			this.btnRemoveVN.Click += new System.EventHandler(this.btnRemoveVN_Click);
			// 
			// btnUpdateVN
			// 
			this.btnUpdateVN.Location = new System.Drawing.Point(384, 576);
			this.btnUpdateVN.Name = "btnUpdateVN";
			this.btnUpdateVN.TabIndex = 14;
			this.btnUpdateVN.Text = "Update";
			this.btnUpdateVN.Click += new System.EventHandler(this.btnUpdateVN_Click);
			// 
			// btnAddVN
			// 
			this.btnAddVN.Location = new System.Drawing.Point(280, 576);
			this.btnAddVN.Name = "btnAddVN";
			this.btnAddVN.Size = new System.Drawing.Size(80, 23);
			this.btnAddVN.TabIndex = 13;
			this.btnAddVN.Text = "Add";
			this.btnAddVN.Click += new System.EventHandler(this.btnAddVN_Click);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.cmbDHCPLeaseRenewal);
			this.groupBox6.Controls.Add(this.txtDHCPLeaseRenewal);
			this.groupBox6.Controls.Add(this.label62);
			this.groupBox6.Controls.Add(this.cmbDHCPIPLease);
			this.groupBox6.Controls.Add(this.txtDHCPIPLease);
			this.groupBox6.Controls.Add(this.label61);
			this.groupBox6.Controls.Add(this.txtDHCPWINS);
			this.groupBox6.Controls.Add(this.label60);
			this.groupBox6.Controls.Add(this.txtDHCPDNS);
			this.groupBox6.Controls.Add(this.label59);
			this.groupBox6.Controls.Add(this.txtDHCPGW);
			this.groupBox6.Controls.Add(this.label58);
			this.groupBox6.Controls.Add(this.txtDHCPEndIP);
			this.groupBox6.Controls.Add(this.txtDHCPStartIP);
			this.groupBox6.Controls.Add(this.label57);
			this.groupBox6.Controls.Add(this.label56);
			this.groupBox6.Controls.Add(this.txtDHCPServerAddress);
			this.groupBox6.Controls.Add(this.label55);
			this.groupBox6.Controls.Add(this.txtDHCPNetMask);
			this.groupBox6.Controls.Add(this.label54);
			this.groupBox6.Controls.Add(this.txtDHCPNetworkAddress);
			this.groupBox6.Controls.Add(this.label53);
			this.groupBox6.Controls.Add(this.ckbVNDHCPEnable);
			this.groupBox6.Controls.Add(this.label52);
			this.groupBox6.Controls.Add(this.txtDHCPLeaseRebinding);
			this.groupBox6.Controls.Add(this.cmbDHCPLeaseRebinding);
			this.groupBox6.Controls.Add(this.label63);
			this.groupBox6.Location = new System.Drawing.Point(24, 336);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(632, 224);
			this.groupBox6.TabIndex = 12;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "DHCP Server Settings";
			// 
			// cmbDHCPLeaseRenewal
			// 
			this.cmbDHCPLeaseRenewal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDHCPLeaseRenewal.Enabled = false;
			this.cmbDHCPLeaseRenewal.Items.AddRange(new object[] {
																	 "Days",
																	 "Hours",
																	 "Minutes",
																	 "Seconds"});
			this.cmbDHCPLeaseRenewal.Location = new System.Drawing.Point(512, 152);
			this.cmbDHCPLeaseRenewal.Name = "cmbDHCPLeaseRenewal";
			this.cmbDHCPLeaseRenewal.Size = new System.Drawing.Size(104, 21);
			this.cmbDHCPLeaseRenewal.TabIndex = 23;
			// 
			// txtDHCPLeaseRenewal
			// 
			this.txtDHCPLeaseRenewal.Enabled = false;
			this.txtDHCPLeaseRenewal.Location = new System.Drawing.Point(456, 152);
			this.txtDHCPLeaseRenewal.Name = "txtDHCPLeaseRenewal";
			this.txtDHCPLeaseRenewal.Size = new System.Drawing.Size(48, 20);
			this.txtDHCPLeaseRenewal.TabIndex = 22;
			this.txtDHCPLeaseRenewal.Text = "18";
			// 
			// label62
			// 
			this.label62.Location = new System.Drawing.Point(344, 152);
			this.label62.Name = "label62";
			this.label62.Size = new System.Drawing.Size(112, 23);
			this.label62.TabIndex = 21;
			this.label62.Text = "Lease renewal time:";
			// 
			// cmbDHCPIPLease
			// 
			this.cmbDHCPIPLease.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDHCPIPLease.Enabled = false;
			this.cmbDHCPIPLease.Items.AddRange(new object[] {
																"Days",
																"Hours",
																"Minutes",
																"Seconds"});
			this.cmbDHCPIPLease.Location = new System.Drawing.Point(200, 152);
			this.cmbDHCPIPLease.Name = "cmbDHCPIPLease";
			this.cmbDHCPIPLease.Size = new System.Drawing.Size(88, 21);
			this.cmbDHCPIPLease.TabIndex = 20;
			// 
			// txtDHCPIPLease
			// 
			this.txtDHCPIPLease.Enabled = false;
			this.txtDHCPIPLease.Location = new System.Drawing.Point(136, 152);
			this.txtDHCPIPLease.Name = "txtDHCPIPLease";
			this.txtDHCPIPLease.Size = new System.Drawing.Size(56, 20);
			this.txtDHCPIPLease.TabIndex = 19;
			this.txtDHCPIPLease.Text = "36";
			// 
			// label61
			// 
			this.label61.Location = new System.Drawing.Point(8, 152);
			this.label61.Name = "label61";
			this.label61.Size = new System.Drawing.Size(120, 23);
			this.label61.TabIndex = 18;
			this.label61.Text = "IP address lease time:";
			// 
			// txtDHCPWINS
			// 
			this.txtDHCPWINS.Enabled = false;
			this.txtDHCPWINS.Location = new System.Drawing.Point(400, 120);
			this.txtDHCPWINS.Name = "txtDHCPWINS";
			this.txtDHCPWINS.Size = new System.Drawing.Size(224, 20);
			this.txtDHCPWINS.TabIndex = 17;
			this.txtDHCPWINS.Text = "";
			// 
			// label60
			// 
			this.label60.Location = new System.Drawing.Point(320, 120);
			this.label60.Name = "label60";
			this.label60.Size = new System.Drawing.Size(80, 23);
			this.label60.TabIndex = 16;
			this.label60.Text = "WINS servers:";
			// 
			// txtDHCPDNS
			// 
			this.txtDHCPDNS.Enabled = false;
			this.txtDHCPDNS.Location = new System.Drawing.Point(88, 120);
			this.txtDHCPDNS.Name = "txtDHCPDNS";
			this.txtDHCPDNS.Size = new System.Drawing.Size(224, 20);
			this.txtDHCPDNS.TabIndex = 15;
			this.txtDHCPDNS.Text = "";
			// 
			// label59
			// 
			this.label59.Location = new System.Drawing.Point(8, 120);
			this.label59.Name = "label59";
			this.label59.Size = new System.Drawing.Size(80, 23);
			this.label59.TabIndex = 14;
			this.label59.Text = "DNS servers:";
			// 
			// txtDHCPGW
			// 
			this.txtDHCPGW.Enabled = false;
			this.txtDHCPGW.Location = new System.Drawing.Point(512, 56);
			this.txtDHCPGW.Name = "txtDHCPGW";
			this.txtDHCPGW.Size = new System.Drawing.Size(96, 20);
			this.txtDHCPGW.TabIndex = 13;
			this.txtDHCPGW.Text = "";
			// 
			// label58
			// 
			this.label58.Location = new System.Drawing.Point(424, 56);
			this.label58.Name = "label58";
			this.label58.Size = new System.Drawing.Size(88, 23);
			this.label58.TabIndex = 12;
			this.label58.Text = "Default gateway:";
			// 
			// txtDHCPEndIP
			// 
			this.txtDHCPEndIP.Enabled = false;
			this.txtDHCPEndIP.Location = new System.Drawing.Point(328, 88);
			this.txtDHCPEndIP.Name = "txtDHCPEndIP";
			this.txtDHCPEndIP.Size = new System.Drawing.Size(96, 20);
			this.txtDHCPEndIP.TabIndex = 11;
			this.txtDHCPEndIP.Text = "";
			// 
			// txtDHCPStartIP
			// 
			this.txtDHCPStartIP.Enabled = false;
			this.txtDHCPStartIP.Location = new System.Drawing.Point(112, 88);
			this.txtDHCPStartIP.Name = "txtDHCPStartIP";
			this.txtDHCPStartIP.Size = new System.Drawing.Size(96, 20);
			this.txtDHCPStartIP.TabIndex = 10;
			this.txtDHCPStartIP.Text = "";
			// 
			// label57
			// 
			this.label57.Location = new System.Drawing.Point(224, 88);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(104, 23);
			this.label57.TabIndex = 9;
			this.label57.Text = "Ending IP address:";
			// 
			// label56
			// 
			this.label56.Location = new System.Drawing.Point(8, 88);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(120, 23);
			this.label56.TabIndex = 8;
			this.label56.Text = "Starting IP address:";
			// 
			// txtDHCPServerAddress
			// 
			this.txtDHCPServerAddress.Enabled = false;
			this.txtDHCPServerAddress.Location = new System.Drawing.Point(440, 24);
			this.txtDHCPServerAddress.Name = "txtDHCPServerAddress";
			this.txtDHCPServerAddress.Size = new System.Drawing.Size(112, 20);
			this.txtDHCPServerAddress.TabIndex = 7;
			this.txtDHCPServerAddress.Text = "";
			// 
			// label55
			// 
			this.label55.Location = new System.Drawing.Point(264, 24);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(176, 23);
			this.label55.TabIndex = 6;
			this.label55.Text = "Virtual DHCP server address:";
			// 
			// txtDHCPNetMask
			// 
			this.txtDHCPNetMask.Enabled = false;
			this.txtDHCPNetMask.Location = new System.Drawing.Point(312, 56);
			this.txtDHCPNetMask.Name = "txtDHCPNetMask";
			this.txtDHCPNetMask.Size = new System.Drawing.Size(96, 20);
			this.txtDHCPNetMask.TabIndex = 5;
			this.txtDHCPNetMask.Text = "";
			// 
			// label54
			// 
			this.label54.Location = new System.Drawing.Point(224, 56);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(88, 23);
			this.label54.TabIndex = 4;
			this.label54.Text = "Network mask:";
			// 
			// txtDHCPNetworkAddress
			// 
			this.txtDHCPNetworkAddress.Enabled = false;
			this.txtDHCPNetworkAddress.Location = new System.Drawing.Point(112, 56);
			this.txtDHCPNetworkAddress.Name = "txtDHCPNetworkAddress";
			this.txtDHCPNetworkAddress.Size = new System.Drawing.Size(96, 20);
			this.txtDHCPNetworkAddress.TabIndex = 3;
			this.txtDHCPNetworkAddress.Text = "";
			// 
			// label53
			// 
			this.label53.Location = new System.Drawing.Point(8, 56);
			this.label53.Name = "label53";
			this.label53.TabIndex = 2;
			this.label53.Text = "Network address:";
			// 
			// ckbVNDHCPEnable
			// 
			this.ckbVNDHCPEnable.Location = new System.Drawing.Point(120, 23);
			this.ckbVNDHCPEnable.Name = "ckbVNDHCPEnable";
			this.ckbVNDHCPEnable.TabIndex = 1;
			this.ckbVNDHCPEnable.Text = "Enable";
			this.ckbVNDHCPEnable.CheckedChanged += new System.EventHandler(this.ckbVNDHCPEnable_CheckedChanged);
			// 
			// label52
			// 
			this.label52.Location = new System.Drawing.Point(8, 24);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(112, 23);
			this.label52.TabIndex = 0;
			this.label52.Text = "Virtual DHCP server";
			this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDHCPLeaseRebinding
			// 
			this.txtDHCPLeaseRebinding.Enabled = false;
			this.txtDHCPLeaseRebinding.Location = new System.Drawing.Point(136, 184);
			this.txtDHCPLeaseRebinding.Name = "txtDHCPLeaseRebinding";
			this.txtDHCPLeaseRebinding.Size = new System.Drawing.Size(56, 20);
			this.txtDHCPLeaseRebinding.TabIndex = 19;
			this.txtDHCPLeaseRebinding.Text = "27";
			// 
			// cmbDHCPLeaseRebinding
			// 
			this.cmbDHCPLeaseRebinding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDHCPLeaseRebinding.Enabled = false;
			this.cmbDHCPLeaseRebinding.Items.AddRange(new object[] {
																	   "Days",
																	   "Hours",
																	   "Minutes",
																	   "Seconds"});
			this.cmbDHCPLeaseRebinding.Location = new System.Drawing.Point(200, 184);
			this.cmbDHCPLeaseRebinding.Name = "cmbDHCPLeaseRebinding";
			this.cmbDHCPLeaseRebinding.Size = new System.Drawing.Size(88, 21);
			this.cmbDHCPLeaseRebinding.TabIndex = 20;
			// 
			// label63
			// 
			this.label63.Location = new System.Drawing.Point(8, 184);
			this.label63.Name = "label63";
			this.label63.Size = new System.Drawing.Size(120, 23);
			this.label63.TabIndex = 18;
			this.label63.Text = "Lease rebinding time:";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.label48);
			this.groupBox4.Controls.Add(this.label51);
			this.groupBox4.Controls.Add(this.txtVNNotes);
			this.groupBox4.Controls.Add(this.label49);
			this.groupBox4.Controls.Add(this.txtVNName);
			this.groupBox4.Controls.Add(this.cmbPhysicanNIC);
			this.groupBox4.Location = new System.Drawing.Point(24, 168);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(632, 152);
			this.groupBox4.TabIndex = 11;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Network Settings";
			// 
			// label48
			// 
			this.label48.Location = new System.Drawing.Point(16, 24);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(120, 23);
			this.label48.TabIndex = 3;
			this.label48.Text = "Virtual network name:";
			this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label51
			// 
			this.label51.Location = new System.Drawing.Point(16, 88);
			this.label51.Name = "label51";
			this.label51.TabIndex = 9;
			this.label51.Text = "Notes";
			this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtVNNotes
			// 
			this.txtVNNotes.AcceptsReturn = true;
			this.txtVNNotes.Location = new System.Drawing.Point(128, 88);
			this.txtVNNotes.Multiline = true;
			this.txtVNNotes.Name = "txtVNNotes";
			this.txtVNNotes.Size = new System.Drawing.Size(488, 56);
			this.txtVNNotes.TabIndex = 10;
			this.txtVNNotes.Text = "";
			// 
			// label49
			// 
			this.label49.Location = new System.Drawing.Point(16, 56);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(200, 23);
			this.label49.TabIndex = 4;
			this.label49.Text = "Network adapter on physical computer:";
			this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtVNName
			// 
			this.txtVNName.Location = new System.Drawing.Point(136, 24);
			this.txtVNName.Name = "txtVNName";
			this.txtVNName.Size = new System.Drawing.Size(480, 20);
			this.txtVNName.TabIndex = 5;
			this.txtVNName.Text = "";
			// 
			// cmbPhysicanNIC
			// 
			this.cmbPhysicanNIC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPhysicanNIC.Location = new System.Drawing.Point(216, 56);
			this.cmbPhysicanNIC.Name = "cmbPhysicanNIC";
			this.cmbPhysicanNIC.Size = new System.Drawing.Size(400, 21);
			this.cmbPhysicanNIC.TabIndex = 6;
			// 
			// label50
			// 
			this.label50.Location = new System.Drawing.Point(32, 96);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(112, 40);
			this.label50.TabIndex = 8;
			this.label50.Text = "Connected virtual network adapters";
			// 
			// lstVNVM
			// 
			this.lstVNVM.BackColor = System.Drawing.SystemColors.Control;
			this.lstVNVM.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lstVNVM.Location = new System.Drawing.Point(160, 96);
			this.lstVNVM.Name = "lstVNVM";
			this.lstVNVM.Size = new System.Drawing.Size(480, 52);
			this.lstVNVM.TabIndex = 7;
			this.lstVNVM.TabStop = false;
			this.lstVNVM.UseTabStops = false;
			// 
			// lstVN
			// 
			this.lstVN.Location = new System.Drawing.Point(32, 24);
			this.lstVN.Name = "lstVN";
			this.lstVN.Size = new System.Drawing.Size(608, 69);
			this.lstVN.TabIndex = 2;
			this.lstVN.SelectedIndexChanged += new System.EventHandler(this.lstVN_SelectedIndexChanged);
			// 
			// tbpVD
			// 
			this.tbpVD.Controls.Add(this.groupBox7);
			this.tbpVD.Location = new System.Drawing.Point(4, 40);
			this.tbpVD.Name = "tbpVD";
			this.tbpVD.Size = new System.Drawing.Size(672, 612);
			this.tbpVD.TabIndex = 7;
			this.tbpVD.Text = "Virtual Disk";
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.tabControl2);
			this.groupBox7.Location = new System.Drawing.Point(16, 16);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(640, 240);
			this.groupBox7.TabIndex = 24;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Create new virtual disks:";
			// 
			// tabControl2
			// 
			this.tabControl2.Controls.Add(this.tbpDEVHD);
			this.tabControl2.Controls.Add(this.tbpFSVHD);
			this.tabControl2.Controls.Add(this.tbpDVHD);
			this.tabControl2.Controls.Add(this.tbpLVHD);
			this.tabControl2.Controls.Add(this.tbpVFD);
			this.tabControl2.Location = new System.Drawing.Point(24, 24);
			this.tabControl2.Multiline = true;
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(592, 192);
			this.tabControl2.TabIndex = 21;
			// 
			// tbpDEVHD
			// 
			this.tbpDEVHD.Controls.Add(this.btnVDDEBrowse);
			this.tbpDEVHD.Controls.Add(this.cmbVDDEUnit);
			this.tbpDEVHD.Controls.Add(this.txtVDDEFilename);
			this.tbpDEVHD.Controls.Add(this.label67);
			this.tbpDEVHD.Controls.Add(this.txtVDDESize);
			this.tbpDEVHD.Controls.Add(this.label66);
			this.tbpDEVHD.Controls.Add(this.btnCreateVDDE);
			this.tbpDEVHD.Location = new System.Drawing.Point(4, 22);
			this.tbpDEVHD.Name = "tbpDEVHD";
			this.tbpDEVHD.Size = new System.Drawing.Size(584, 166);
			this.tbpDEVHD.TabIndex = 0;
			this.tbpDEVHD.Text = "Dynamically Expanding Disk";
			// 
			// btnVDDEBrowse
			// 
			this.btnVDDEBrowse.Location = new System.Drawing.Point(496, 16);
			this.btnVDDEBrowse.Name = "btnVDDEBrowse";
			this.btnVDDEBrowse.TabIndex = 17;
			this.btnVDDEBrowse.Text = "Browse...";
			this.btnVDDEBrowse.Click += new System.EventHandler(this.btnVDDEBrowse_Click);
			// 
			// cmbVDDEUnit
			// 
			this.cmbVDDEUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbVDDEUnit.Items.AddRange(new object[] {
															 "GB",
															 "MB"});
			this.cmbVDDEUnit.Location = new System.Drawing.Point(184, 80);
			this.cmbVDDEUnit.Name = "cmbVDDEUnit";
			this.cmbVDDEUnit.Size = new System.Drawing.Size(96, 21);
			this.cmbVDDEUnit.TabIndex = 15;
			// 
			// txtVDDEFilename
			// 
			this.txtVDDEFilename.Location = new System.Drawing.Point(128, 16);
			this.txtVDDEFilename.Multiline = true;
			this.txtVDDEFilename.Name = "txtVDDEFilename";
			this.txtVDDEFilename.Size = new System.Drawing.Size(360, 40);
			this.txtVDDEFilename.TabIndex = 12;
			this.txtVDDEFilename.Text = "";
			// 
			// label67
			// 
			this.label67.Location = new System.Drawing.Point(16, 80);
			this.label67.Name = "label67";
			this.label67.TabIndex = 13;
			this.label67.Text = "Size";
			// 
			// txtVDDESize
			// 
			this.txtVDDESize.Location = new System.Drawing.Point(128, 80);
			this.txtVDDESize.Name = "txtVDDESize";
			this.txtVDDESize.Size = new System.Drawing.Size(56, 20);
			this.txtVDDESize.TabIndex = 14;
			this.txtVDDESize.Text = "16";
			// 
			// label66
			// 
			this.label66.Location = new System.Drawing.Point(16, 16);
			this.label66.Name = "label66";
			this.label66.Size = new System.Drawing.Size(200, 23);
			this.label66.TabIndex = 11;
			this.label66.Text = "Filename";
			// 
			// btnCreateVDDE
			// 
			this.btnCreateVDDE.Location = new System.Drawing.Point(240, 120);
			this.btnCreateVDDE.Name = "btnCreateVDDE";
			this.btnCreateVDDE.Size = new System.Drawing.Size(120, 23);
			this.btnCreateVDDE.TabIndex = 16;
			this.btnCreateVDDE.Text = "Create";
			this.btnCreateVDDE.Click += new System.EventHandler(this.btnCreateVDDE_Click);
			// 
			// tbpFSVHD
			// 
			this.tbpFSVHD.Controls.Add(this.btnCreateVDFS);
			this.tbpFSVHD.Controls.Add(this.btnVDFSBrowse);
			this.tbpFSVHD.Controls.Add(this.cmbVDFSUnit);
			this.tbpFSVHD.Controls.Add(this.txtVDFSFilename);
			this.tbpFSVHD.Controls.Add(this.label69);
			this.tbpFSVHD.Controls.Add(this.txtVDFSSize);
			this.tbpFSVHD.Controls.Add(this.label70);
			this.tbpFSVHD.Location = new System.Drawing.Point(4, 22);
			this.tbpFSVHD.Name = "tbpFSVHD";
			this.tbpFSVHD.Size = new System.Drawing.Size(584, 166);
			this.tbpFSVHD.TabIndex = 1;
			this.tbpFSVHD.Text = "Fixed Size Disk";
			// 
			// btnCreateVDFS
			// 
			this.btnCreateVDFS.Location = new System.Drawing.Point(232, 120);
			this.btnCreateVDFS.Name = "btnCreateVDFS";
			this.btnCreateVDFS.Size = new System.Drawing.Size(120, 23);
			this.btnCreateVDFS.TabIndex = 26;
			this.btnCreateVDFS.Text = "Create";
			this.btnCreateVDFS.Click += new System.EventHandler(this.btnCreateVDFS_Click);
			// 
			// btnVDFSBrowse
			// 
			this.btnVDFSBrowse.Location = new System.Drawing.Point(484, 16);
			this.btnVDFSBrowse.Name = "btnVDFSBrowse";
			this.btnVDFSBrowse.TabIndex = 25;
			this.btnVDFSBrowse.Text = "Browse...";
			this.btnVDFSBrowse.Click += new System.EventHandler(this.btnVDFSBrowse_Click);
			// 
			// cmbVDFSUnit
			// 
			this.cmbVDFSUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbVDFSUnit.Items.AddRange(new object[] {
															 "GB",
															 "MB"});
			this.cmbVDFSUnit.Location = new System.Drawing.Point(200, 76);
			this.cmbVDFSUnit.Name = "cmbVDFSUnit";
			this.cmbVDFSUnit.Size = new System.Drawing.Size(96, 21);
			this.cmbVDFSUnit.TabIndex = 23;
			// 
			// txtVDFSFilename
			// 
			this.txtVDFSFilename.Location = new System.Drawing.Point(128, 16);
			this.txtVDFSFilename.Multiline = true;
			this.txtVDFSFilename.Name = "txtVDFSFilename";
			this.txtVDFSFilename.Size = new System.Drawing.Size(348, 40);
			this.txtVDFSFilename.TabIndex = 20;
			this.txtVDFSFilename.Text = "";
			// 
			// label69
			// 
			this.label69.Location = new System.Drawing.Point(20, 76);
			this.label69.Name = "label69";
			this.label69.TabIndex = 21;
			this.label69.Text = "Size";
			// 
			// txtVDFSSize
			// 
			this.txtVDFSSize.Location = new System.Drawing.Point(132, 76);
			this.txtVDFSSize.Name = "txtVDFSSize";
			this.txtVDFSSize.Size = new System.Drawing.Size(68, 20);
			this.txtVDFSSize.TabIndex = 22;
			this.txtVDFSSize.Text = "";
			// 
			// label70
			// 
			this.label70.Location = new System.Drawing.Point(16, 16);
			this.label70.Name = "label70";
			this.label70.TabIndex = 19;
			this.label70.Text = "Filename";
			// 
			// tbpDVHD
			// 
			this.tbpDVHD.Controls.Add(this.btnCreateVDDD);
			this.tbpDVHD.Controls.Add(this.btnVDDDDiff);
			this.tbpDVHD.Controls.Add(this.btnVDDDParent);
			this.tbpDVHD.Controls.Add(this.txtVDDDParent);
			this.tbpDVHD.Controls.Add(this.txtVDDDDiff);
			this.tbpDVHD.Controls.Add(this.label72);
			this.tbpDVHD.Controls.Add(this.label73);
			this.tbpDVHD.Location = new System.Drawing.Point(4, 22);
			this.tbpDVHD.Name = "tbpDVHD";
			this.tbpDVHD.Size = new System.Drawing.Size(584, 166);
			this.tbpDVHD.TabIndex = 2;
			this.tbpDVHD.Text = "Differencing Disk";
			// 
			// btnCreateVDDD
			// 
			this.btnCreateVDDD.Location = new System.Drawing.Point(248, 128);
			this.btnCreateVDDD.Name = "btnCreateVDDD";
			this.btnCreateVDDD.Size = new System.Drawing.Size(120, 23);
			this.btnCreateVDDD.TabIndex = 24;
			this.btnCreateVDDD.Text = "Create";
			this.btnCreateVDDD.Click += new System.EventHandler(this.btnCreateVDDD_Click);
			// 
			// btnVDDDDiff
			// 
			this.btnVDDDDiff.Location = new System.Drawing.Point(496, 80);
			this.btnVDDDDiff.Name = "btnVDDDDiff";
			this.btnVDDDDiff.TabIndex = 23;
			this.btnVDDDDiff.Text = "Browse...";
			this.btnVDDDDiff.Click += new System.EventHandler(this.btnVDDDDiff_Click);
			// 
			// btnVDDDParent
			// 
			this.btnVDDDParent.Location = new System.Drawing.Point(496, 32);
			this.btnVDDDParent.Name = "btnVDDDParent";
			this.btnVDDDParent.TabIndex = 22;
			this.btnVDDDParent.Text = "Browse...";
			this.btnVDDDParent.Click += new System.EventHandler(this.btnVDDDParent_Click);
			// 
			// txtVDDDParent
			// 
			this.txtVDDDParent.Location = new System.Drawing.Point(144, 24);
			this.txtVDDDParent.Multiline = true;
			this.txtVDDDParent.Name = "txtVDDDParent";
			this.txtVDDDParent.Size = new System.Drawing.Size(344, 40);
			this.txtVDDDParent.TabIndex = 21;
			this.txtVDDDParent.Text = "";
			// 
			// txtVDDDDiff
			// 
			this.txtVDDDDiff.Location = new System.Drawing.Point(144, 72);
			this.txtVDDDDiff.Multiline = true;
			this.txtVDDDDiff.Name = "txtVDDDDiff";
			this.txtVDDDDiff.Size = new System.Drawing.Size(344, 40);
			this.txtVDDDDiff.TabIndex = 20;
			this.txtVDDDDiff.Text = "";
			// 
			// label72
			// 
			this.label72.Location = new System.Drawing.Point(40, 72);
			this.label72.Name = "label72";
			this.label72.TabIndex = 19;
			this.label72.Text = "Differencing disk";
			// 
			// label73
			// 
			this.label73.Location = new System.Drawing.Point(40, 24);
			this.label73.Name = "label73";
			this.label73.TabIndex = 17;
			this.label73.Text = "Parent disk ";
			// 
			// tbpLVHD
			// 
			this.tbpLVHD.Controls.Add(this.btnCreateVDLD);
			this.tbpLVHD.Controls.Add(this.cmbVDLDPDrive);
			this.tbpLVHD.Controls.Add(this.btnVDLDBrowse);
			this.tbpLVHD.Controls.Add(this.txtVDLDFilename);
			this.tbpLVHD.Controls.Add(this.label74);
			this.tbpLVHD.Controls.Add(this.label71);
			this.tbpLVHD.Location = new System.Drawing.Point(4, 22);
			this.tbpLVHD.Name = "tbpLVHD";
			this.tbpLVHD.Size = new System.Drawing.Size(584, 166);
			this.tbpLVHD.TabIndex = 3;
			this.tbpLVHD.Text = "Linked Disk";
			// 
			// btnCreateVDLD
			// 
			this.btnCreateVDLD.Location = new System.Drawing.Point(232, 112);
			this.btnCreateVDLD.Name = "btnCreateVDLD";
			this.btnCreateVDLD.Size = new System.Drawing.Size(120, 23);
			this.btnCreateVDLD.TabIndex = 17;
			this.btnCreateVDLD.Text = "Create";
			this.btnCreateVDLD.Click += new System.EventHandler(this.btnCreateVDLD_Click);
			// 
			// cmbVDLDPDrive
			// 
			this.cmbVDLDPDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbVDLDPDrive.Location = new System.Drawing.Point(128, 72);
			this.cmbVDLDPDrive.Name = "cmbVDLDPDrive";
			this.cmbVDLDPDrive.Size = new System.Drawing.Size(344, 21);
			this.cmbVDLDPDrive.TabIndex = 15;
			// 
			// btnVDLDBrowse
			// 
			this.btnVDLDBrowse.Location = new System.Drawing.Point(488, 16);
			this.btnVDLDBrowse.Name = "btnVDLDBrowse";
			this.btnVDLDBrowse.TabIndex = 14;
			this.btnVDLDBrowse.Text = "Browse...";
			this.btnVDLDBrowse.Click += new System.EventHandler(this.btnVDLDBrowse_Click);
			// 
			// txtVDLDFilename
			// 
			this.txtVDLDFilename.Location = new System.Drawing.Point(128, 16);
			this.txtVDLDFilename.Multiline = true;
			this.txtVDLDFilename.Name = "txtVDLDFilename";
			this.txtVDLDFilename.Size = new System.Drawing.Size(344, 40);
			this.txtVDLDFilename.TabIndex = 13;
			this.txtVDLDFilename.Text = "";
			// 
			// label74
			// 
			this.label74.Location = new System.Drawing.Point(24, 16);
			this.label74.Name = "label74";
			this.label74.TabIndex = 9;
			this.label74.Text = "Filename:";
			// 
			// label71
			// 
			this.label71.Location = new System.Drawing.Point(24, 72);
			this.label71.Name = "label71";
			this.label71.TabIndex = 11;
			this.label71.Text = "Physical drive";
			// 
			// tbpVFD
			// 
			this.tbpVFD.Controls.Add(this.btnCreateVDFD);
			this.tbpVFD.Controls.Add(this.btnVDFD);
			this.tbpVFD.Controls.Add(this.txtVDFDFilename);
			this.tbpVFD.Controls.Add(this.label75);
			this.tbpVFD.Location = new System.Drawing.Point(4, 22);
			this.tbpVFD.Name = "tbpVFD";
			this.tbpVFD.Size = new System.Drawing.Size(584, 166);
			this.tbpVFD.TabIndex = 4;
			this.tbpVFD.Text = "Floppy Disk";
			// 
			// btnCreateVDFD
			// 
			this.btnCreateVDFD.Location = new System.Drawing.Point(232, 72);
			this.btnCreateVDFD.Name = "btnCreateVDFD";
			this.btnCreateVDFD.Size = new System.Drawing.Size(120, 23);
			this.btnCreateVDFD.TabIndex = 17;
			this.btnCreateVDFD.Text = "Create";
			this.btnCreateVDFD.Click += new System.EventHandler(this.btnCreateVDFD_Click);
			// 
			// btnVDFD
			// 
			this.btnVDFD.Location = new System.Drawing.Point(480, 16);
			this.btnVDFD.Name = "btnVDFD";
			this.btnVDFD.TabIndex = 15;
			this.btnVDFD.Text = "Browse...";
			this.btnVDFD.Click += new System.EventHandler(this.btnVDFD_Click);
			// 
			// txtVDFDFilename
			// 
			this.txtVDFDFilename.Location = new System.Drawing.Point(136, 16);
			this.txtVDFDFilename.Name = "txtVDFDFilename";
			this.txtVDFDFilename.Size = new System.Drawing.Size(328, 20);
			this.txtVDFDFilename.TabIndex = 12;
			this.txtVDFDFilename.Text = "";
			// 
			// label75
			// 
			this.label75.Location = new System.Drawing.Point(24, 16);
			this.label75.Name = "label75";
			this.label75.TabIndex = 11;
			this.label75.Text = "Filename:";
			// 
			// tbpVDT
			// 
			this.tbpVDT.Controls.Add(this.groupBox8);
			this.tbpVDT.Location = new System.Drawing.Point(4, 40);
			this.tbpVDT.Name = "tbpVDT";
			this.tbpVDT.Size = new System.Drawing.Size(672, 612);
			this.tbpVDT.TabIndex = 8;
			this.tbpVDT.Text = "Virtual Disk Tools";
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.btnConvertBrowse);
			this.groupBox8.Controls.Add(this.txtConvertVHD);
			this.groupBox8.Controls.Add(this.label77);
			this.groupBox8.Controls.Add(this.btnConvertVHD);
			this.groupBox8.Controls.Add(this.btnCompact);
			this.groupBox8.Controls.Add(this.lblIVDCurrentSize);
			this.groupBox8.Controls.Add(this.label82);
			this.groupBox8.Controls.Add(this.lblIVDMaxSize);
			this.groupBox8.Controls.Add(this.label80);
			this.groupBox8.Controls.Add(this.lblFQPath);
			this.groupBox8.Controls.Add(this.label78);
			this.groupBox8.Controls.Add(this.lblVDType);
			this.groupBox8.Controls.Add(this.label76);
			this.groupBox8.Controls.Add(this.btnInspectVD);
			this.groupBox8.Controls.Add(this.btnBrowseIVD);
			this.groupBox8.Controls.Add(this.label68);
			this.groupBox8.Controls.Add(this.txtInspectVDFilename);
			this.groupBox8.Location = new System.Drawing.Point(16, 16);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(640, 496);
			this.groupBox8.TabIndex = 24;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Inspect Virtual Disk";
			// 
			// btnConvertBrowse
			// 
			this.btnConvertBrowse.Location = new System.Drawing.Point(536, 264);
			this.btnConvertBrowse.Name = "btnConvertBrowse";
			this.btnConvertBrowse.TabIndex = 20;
			this.btnConvertBrowse.Text = "Browse...";
			// 
			// txtConvertVHD
			// 
			this.txtConvertVHD.Location = new System.Drawing.Point(160, 264);
			this.txtConvertVHD.Multiline = true;
			this.txtConvertVHD.Name = "txtConvertVHD";
			this.txtConvertVHD.Size = new System.Drawing.Size(360, 40);
			this.txtConvertVHD.TabIndex = 19;
			this.txtConvertVHD.Text = "";
			// 
			// label77
			// 
			this.label77.Location = new System.Drawing.Point(16, 264);
			this.label77.Name = "label77";
			this.label77.Size = new System.Drawing.Size(144, 23);
			this.label77.TabIndex = 18;
			this.label77.Text = "Converted hard disk name:";
			// 
			// btnConvertVHD
			// 
			this.btnConvertVHD.Location = new System.Drawing.Point(272, 320);
			this.btnConvertVHD.Name = "btnConvertVHD";
			this.btnConvertVHD.Size = new System.Drawing.Size(104, 23);
			this.btnConvertVHD.TabIndex = 17;
			this.btnConvertVHD.Text = "Convert";
			this.btnConvertVHD.Click += new System.EventHandler(this.btnConvertVHD_Click);
			// 
			// btnCompact
			// 
			this.btnCompact.Location = new System.Drawing.Point(504, 216);
			this.btnCompact.Name = "btnCompact";
			this.btnCompact.Size = new System.Drawing.Size(80, 23);
			this.btnCompact.TabIndex = 12;
			this.btnCompact.Text = "Compact";
			this.btnCompact.Click += new System.EventHandler(this.btnCompact_Click);
			// 
			// lblIVDCurrentSize
			// 
			this.lblIVDCurrentSize.Location = new System.Drawing.Point(392, 216);
			this.lblIVDCurrentSize.Name = "lblIVDCurrentSize";
			this.lblIVDCurrentSize.TabIndex = 11;
			// 
			// label82
			// 
			this.label82.Location = new System.Drawing.Point(288, 216);
			this.label82.Name = "label82";
			this.label82.TabIndex = 10;
			this.label82.Text = "Current Size:";
			// 
			// lblIVDMaxSize
			// 
			this.lblIVDMaxSize.Location = new System.Drawing.Point(184, 216);
			this.lblIVDMaxSize.Name = "lblIVDMaxSize";
			this.lblIVDMaxSize.TabIndex = 9;
			// 
			// label80
			// 
			this.label80.Location = new System.Drawing.Point(32, 216);
			this.label80.Name = "label80";
			this.label80.Size = new System.Drawing.Size(152, 23);
			this.label80.TabIndex = 8;
			this.label80.Text = "Maximum size";
			// 
			// lblFQPath
			// 
			this.lblFQPath.Location = new System.Drawing.Point(184, 176);
			this.lblFQPath.Name = "lblFQPath";
			this.lblFQPath.Size = new System.Drawing.Size(400, 32);
			this.lblFQPath.TabIndex = 7;
			// 
			// label78
			// 
			this.label78.Location = new System.Drawing.Point(32, 176);
			this.label78.Name = "label78";
			this.label78.Size = new System.Drawing.Size(152, 23);
			this.label78.TabIndex = 6;
			this.label78.Text = "Fully qualified path to file:";
			// 
			// lblVDType
			// 
			this.lblVDType.Location = new System.Drawing.Point(184, 152);
			this.lblVDType.Name = "lblVDType";
			this.lblVDType.Size = new System.Drawing.Size(400, 23);
			this.lblVDType.TabIndex = 5;
			// 
			// label76
			// 
			this.label76.Location = new System.Drawing.Point(32, 152);
			this.label76.Name = "label76";
			this.label76.TabIndex = 4;
			this.label76.Text = "Virtual disk type:";
			// 
			// btnInspectVD
			// 
			this.btnInspectVD.Location = new System.Drawing.Point(200, 88);
			this.btnInspectVD.Name = "btnInspectVD";
			this.btnInspectVD.Size = new System.Drawing.Size(96, 23);
			this.btnInspectVD.TabIndex = 3;
			this.btnInspectVD.Text = "Inspect";
			this.btnInspectVD.Click += new System.EventHandler(this.btnInspectVD_Click);
			// 
			// btnBrowseIVD
			// 
			this.btnBrowseIVD.Location = new System.Drawing.Point(528, 32);
			this.btnBrowseIVD.Name = "btnBrowseIVD";
			this.btnBrowseIVD.TabIndex = 2;
			this.btnBrowseIVD.Text = "Browse...";
			this.btnBrowseIVD.Click += new System.EventHandler(this.btnBrowseIVD_Click);
			// 
			// label68
			// 
			this.label68.Location = new System.Drawing.Point(16, 32);
			this.label68.Name = "label68";
			this.label68.TabIndex = 1;
			this.label68.Text = "Filename";
			// 
			// txtInspectVDFilename
			// 
			this.txtInspectVDFilename.Location = new System.Drawing.Point(120, 32);
			this.txtInspectVDFilename.Multiline = true;
			this.txtInspectVDFilename.Name = "txtInspectVDFilename";
			this.txtInspectVDFilename.Size = new System.Drawing.Size(392, 40);
			this.txtInspectVDFilename.TabIndex = 0;
			this.txtInspectVDFilename.Text = "";
			// 
			// imglistThumbnail
			// 
			this.imglistThumbnail.ImageSize = new System.Drawing.Size(64, 48);
			this.imglistThumbnail.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(432, 672);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(88, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(544, 672);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// eventLog1
			// 
			this.eventLog1.SynchronizingObject = this;
			// 
			// imgSecurity
			// 
			this.imgSecurity.ImageSize = new System.Drawing.Size(16, 16);
			this.imgSecurity.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgSecurity.ImageStream")));
			this.imgSecurity.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// tmrVS
			// 
			this.tmrVS.Interval = 5000;
			this.tmrVS.Tick += new System.EventHandler(this.tmrVS_Tick);
			// 
			// frmVSProperty
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(680, 710);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.tabControl1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmVSProperty";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Virtual Server Properties";
			this.Load += new System.EventHandler(this.frmVSProperty_Load);
			this.tabControl1.ResumeLayout(false);
			this.tbpGeneral.ResumeLayout(false);
			this.grpSSLCertificate.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tbpSecurity.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgSecurity)).EndInit();
			this.tbpVSView.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgVSView)).EndInit();
			this.tbpVMRC.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.tbpSearchPath.ResumeLayout(false);
			this.tbpEvent.ResumeLayout(false);
			this.tbpResource.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.tbpScripts.ResumeLayout(false);
			this.groupBox9.ResumeLayout(false);
			this.tbpPC.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.tbpVN.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.tbpVD.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.tabControl2.ResumeLayout(false);
			this.tbpDEVHD.ResumeLayout(false);
			this.tbpFSVHD.ResumeLayout(false);
			this.tbpDVHD.ResumeLayout(false);
			this.tbpLVHD.ResumeLayout(false);
			this.tbpVFD.ResumeLayout(false);
			this.tbpVDT.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmVSProperty_Load(object sender, System.EventArgs e)
		{
			// Connect to the Virtual Server
			try 
			{
				myVS = myAppVSProp.GetVMVirtualServerClass(thisVSAddress);
			}
			catch
			{
				MessageBox.Show("Cannot connect to Virtual Server: " + thisVSAddress);

				// Improve: when the VS cannot be connected, this VSProperty form should not be displayed.
				//			Check mnuVSProperties_Click() in Main.cs.
				//			The following statement does not looks like a good solution but it works.
				this.Close();

				return;
			}

			// Enable timer to update VS info
			// The timer has to be off when the form initialized. Otherwise, it may raise with problems when the form goes to acquire server address.
			tmrVS.Enabled = true;

			// Fill General Tab
			FillTab_General();

			// Fill Physical Computer Information
			FillTab_PhysicalComputer();

			// Fill Security Tab
			FillTab_Security();
			
			// Fill VMRC Tab
			FillTab_VMRC();
	
			// Fill Search Path Tab
			FillTab_SearchPath();

			// Fill Event Tab
			FillTab_Event();

			// Fill Resource Tab
			FillTab_Resource();

			// Fill Virtual Network tab
			FillTab_VN();

			// Fill Virtual Disk tab
			FillTab_VD();

			// Fill VS View tab
			FillTab_VSView();

			// Fill Scripts tab
			FillTab_Scripts();

		}



		private void FillTab_General() 
		{
			lblVSVersion.Text = myVS.Version;
			lblAdminWebVersion.Text = myVS.Version;
			lblUptime.Text = ConvertSecToString(myVS.UpTime);

			lstSupportDrivers.Items.Clear();
			for (int i=1; i<=myVS.SupportDrivers.Count; i++) 
			{
				lstSupportDrivers.Items.Add(myVS.SupportDrivers[i].Description + " (Version: " + myVS.SupportDrivers[i].Version + ")");
			}
			lblProductID.Text = myVS.ProductID;

			if (myVS.VMRCEncryptionCertificateRequest != "") 
			{
				
				txtSSLCertificate.Text = myVS.VMRCEncryptionCertificateRequest ;
			}
			else 
			{
				grpSSLCertificate.Visible = false;
			}

		}

		private void FillTab_PhysicalComputer() 
		{
			lblPProc.Text = myVS.HostInfo.PhysicalProcessorCount.ToString();
			lblLProc.Text = myVS.HostInfo.LogicalProcessorCount.ToString();
			lblProcSpeed.Text = myVS.HostInfo.ProcessorSpeed.ToString();
			lblProcType.Text = myVS.HostInfo.ProcessorManufacturerString;
			lblProcVersion.Text = myVS.HostInfo.ProcessorVersionString;
			lblProcFeature.Text = myVS.HostInfo.ProcessorFeaturesString;
			lblTotalMemory.Text = myVS.HostInfo.MemoryTotalString;
			lblAvailableMemory.Text = myVS.HostInfo.MemoryAvailString;
			
			lstNIC.Items.Clear();
			foreach ( Object nic in (IEnumerable)myVS.HostInfo.NetworkAdapters) 
			{
				lstNIC.Items.Add(" " + nic.ToString());
			}
			lblOS.Text = myVS.HostInfo.OperatingSystem + " v" + myVS.HostInfo.OSVersionString;

		}

		private void FillTab_Security() 
		{
			// Current Security object
			VMSecurity security = myVS.Security;

			// Image
			ArrayList bitMaps = new ArrayList();
			bitMaps.Add(imgSecurity.Images[0]);
			bitMaps.Add(imgSecurity.Images[1]);
			bitMaps.Add(imgSecurity.Images[2]);

			//create a datatable
			DataTable dt = new DataTable("VSSecurity");

			dt.Columns.Add(new DataColumn("User/Group"));
			dt.Columns.Add(new DataColumn("Type",typeof(int)));
			dt.Columns.Add(new DataColumn("Full",typeof(int)));
			dt.Columns.Add(new DataColumn("Modify",typeof(int)));
			dt.Columns.Add(new DataColumn("View",typeof(int)));
			dt.Columns.Add(new DataColumn("Remove",typeof(int)));
			dt.Columns.Add(new DataColumn("Change Permissions",typeof(int)));
			dt.Columns.Add(new DataColumn("Control",typeof(int)));
			dt.Columns.Add(new DataColumn("Special Permissions",typeof(int)));


			int SecEntryCount = security.AccessRights.Count;
			for(int i = 1; i <=SecEntryCount; ++i)
			{
				if (security.AccessRights[i].Name != "SYSTEM" && security.AccessRights[i].Name!="NETWORK SERVICE" && security.AccessRights[i].Name!="CREATOR OWNER") 
				{
					DataRow dr = dt.NewRow();
					// Yes: 0
					// No: 1
					// Unknown/Not apply: 2
					dr[0] = security.AccessRights[i].Name;
					dr[1] = (security.AccessRights[i].Type==VMAccessRightsType.vmAccessRights_Allowed)?0:1;
					dr[2] = 1;	// Full Control
					
					dr[3] = (security.AccessRights[i].WriteAccess==true)?0:1;			// Modify
					dr[4] = (security.AccessRights[i].ReadAccess==true)?0:1;			// View
					dr[5] = (security.AccessRights[i].DeleteAccess==true)?0:1;			// Remove
					dr[6] = (security.AccessRights[i].ChangePermissions==true)?0:1;	// Change Permissions
					dr[7] = (security.AccessRights[i].ExecuteAccess==true)?0:1; // Control
					
					// Full Control is the combination of all regular permissions
					dr[2] = ((int)dr[3]+(int)dr[4]+(int)dr[5]+(int)dr[6]+(int)dr[7]==0)?0:1;
					
					dr[8] = (security.AccessRights[i].SpecialAccess==true)?0:1; // Special Permissions
					
					dt.Rows.Add(dr);
				}
			}

			
			// Define table style
			DataGridTableStyle tableStyle = new DataGridTableStyle();
			tableStyle.MappingName = "VSSecurity";
			
			
			// Add column styles

			// Username or Group
			DataGridTextBoxColumn tbc = new DataGridTextBoxColumn();
			tbc.MappingName = "User/Group";
			tbc.HeaderText = "User/Group";
			tbc.Alignment = HorizontalAlignment.Center;
			tbc.Width = 110;
			tableStyle.GridColumnStyles.Add(tbc);

			// Graphic column
			DataGridImageCell imgtbc ;
			// Type 
			imgtbc = new DataGridImageCell();
			imgtbc.MappingName = "Type";
			imgtbc.HeaderText = "Type";
			imgtbc.theImages = bitMaps;
			imgtbc.Width = 40;
			tableStyle.GridColumnStyles.Add(imgtbc);

			// Full
			imgtbc = new DataGridImageCell();
			imgtbc.MappingName = "Full";
			imgtbc.HeaderText = "Full";

			imgtbc.theImages = bitMaps;
			imgtbc.Width = 40;
			tableStyle.GridColumnStyles.Add(imgtbc);

			// Modify
			imgtbc = new DataGridImageCell();
			imgtbc.MappingName = "Modify";
			imgtbc.HeaderText = "Modify";

			imgtbc.theImages = bitMaps;
			imgtbc.Width = 45;
			tableStyle.GridColumnStyles.Add(imgtbc);

			// View
			imgtbc = new DataGridImageCell();
			imgtbc.MappingName = "View";
			imgtbc.HeaderText = "View";

			imgtbc.theImages = bitMaps;
			imgtbc.Width = 40;
			tableStyle.GridColumnStyles.Add(imgtbc);
	
			// Remove
			imgtbc = new DataGridImageCell();
			imgtbc.MappingName = "Remove";
			imgtbc.HeaderText = "Remove";

			imgtbc.theImages = bitMaps;
			imgtbc.Width = 50;
			tableStyle.GridColumnStyles.Add(imgtbc);
			dgSecurity.DataSource = dt;

			// Change Permissions
			imgtbc = new DataGridImageCell();
			imgtbc.MappingName = "Change Permissions";
			imgtbc.HeaderText = "Change Permissions";

			imgtbc.theImages = bitMaps;
			imgtbc.Width = 105;
			tableStyle.GridColumnStyles.Add(imgtbc);

			// Control 
			imgtbc = new DataGridImageCell();
			imgtbc.MappingName = "Control";
			imgtbc.HeaderText = "Control";
			imgtbc.Alignment = HorizontalAlignment.Center;
			imgtbc.theImages = bitMaps;
			imgtbc.Width = 50;
			tableStyle.GridColumnStyles.Add(imgtbc);

			// Special Permission
			imgtbc = new DataGridImageCell();
			imgtbc.MappingName = "Special Permissions";
			imgtbc.HeaderText = "Special Permissions";
			imgtbc.theImages = bitMaps;
			imgtbc.Width = 105;
			tableStyle.GridColumnStyles.Add(imgtbc);

			dgSecurity.TableStyles.Clear();
			dgSecurity.TableStyles.Add(tableStyle);
			dgSecurity.DataSource = dt;
			dt.DefaultView.AllowNew = false;

			Rectangle rect = dgSecurity.GetCellBounds(0,0);
			int topPos = rect.Top;
			int height = (dgSecurity.ClientSize.Height - topPos - SecEntryCount) / SecEntryCount;
			tableStyle.PreferredRowHeight = height;
			dgSecurity.DataSource = null;
			dgSecurity.DataSource = dt;

			// Disable Remove button for the first row: Administrators
			btnSecEntryRemove.Enabled = false;

		}
		private void FillTab_VMRC() 
		{
			// VMRC properties
			ckbVMRCEnable.Checked = myVS.VMRCEnabled;
			if (ckbVMRCEnable.Checked) 
			{
				cmbVMRCAddress.Enabled = true;

				if (myVS.VMRCAdminAddress == "") 
				{
					cmbVMRCAddress.Items.Add("(All unassigned)");
					cmbVMRCAddress.Text = cmbVMRCAddress.Items[0].ToString();
				}
				else
				{
					cmbVMRCAddress.Text = myVS.VMRCAdminAddress;
					cmbVMRCAddress.Items.Add("(All unassigned)");
				}

				foreach ( Object IP in (IEnumerable)myVS.HostInfo.NetworkAddresses) 
				{		
					cmbVMRCAddress.Items.Add(IP.ToString());
				}
				
				txtVMRCPort.Enabled = true;
				txtVMRCPort.Text = myVS.VMRCAdminPortNumber.ToString();

				cmbScrRes.Enabled = true;
				cmbScrRes.Items.Add("640 x 480");
				cmbScrRes.Items.Add("800 x 600");
				cmbScrRes.Items.Add("1024 x 768");
				cmbScrRes.Items.Add("1280 x 1024");
				cmbScrRes.Text = myVS.VMRCXResolution.ToString() + " x " + myVS.VMRCYResolution.ToString();

				cmbVMRCAuth.Enabled = true;
				for (int i=1; i<=myVS.VMRCAuthenticators.Count;i++) 
				{
					cmbVMRCAuth.Items.Add(myVS.VMRCAuthenticators[i].Name);
				}
				cmbVMRCAuth.Text = myVS.VMRCAuthenticator.Name;

				ckbIdleEnable.Enabled = true;
				ckbIdleEnable.Checked = myVS.VMRCIdleConnectionTimeoutEnabled;

				if (ckbIdleEnable.Checked) 
				{
					txtVMRCTimeout.Enabled = true;
					txtVMRCTimeout.Text = (myVS.VMRCIdleConnectionTimeout/60).ToString();
				}

			

				// VMRC SSL Encryption properties
				ckbSSLEnable.Checked = myVS.VMRCEncryptionEnabled;
				cmbSSLKeyLength.Text = "1024";
				if (ckbSSLEnable.Checked) 
				{

					// Get Certificate from VS.VMRCEncryptionCertificate
					byte[] certByte = new byte[myVS.VMRCEncryptionCertificate.Length];
					for (int i=0; i<myVS.VMRCEncryptionCertificate.Length; i++) 
					{
						certByte[i] = (byte)myVS.VMRCEncryptionCertificate[i];
					}
					
					String certString = Encoding.ASCII.GetString(certByte);
					StringBuilder sb = new StringBuilder(certString);
					certByte = Convert.FromBase64String(sb.ToString());
					X509Certificate cert = new X509Certificate(certByte);


					// Parse certificate to get issuer information
					string issuer = cert.GetIssuerName();
					string issuertemp = "";

					
					if (issuer.IndexOf("CN=")>=0) 
					{
						issuertemp = issuer.Substring(issuer.IndexOf("CN="));
						txtSSLHost.Text = issuertemp.Substring( issuertemp.IndexOf("CN=")+3, issuertemp.IndexOf(",")-3);
					}
			
					if (issuer.IndexOf("OU")>=0 ) 
					{
						issuertemp = issuer.Substring(issuer.IndexOf("OU="));
						txtSSLOU.Text = issuertemp.Substring( issuertemp.IndexOf("OU=")+3, issuertemp.IndexOf(",")-3);
					}

					if (issuer.IndexOf("O=")>=0 )
					{	
						issuertemp = issuer.Substring(issuer.IndexOf("O="));
						txtSSLOrg.Text = issuertemp.Substring( issuertemp.IndexOf("O=")+2, issuertemp.IndexOf(",")-2);
					}
		
					if ( issuer.IndexOf("L=")>=0) 
					{
						issuertemp = issuer.Substring(issuer.IndexOf("L="));
						txtSSLCity.Text = issuertemp.Substring( issuertemp.IndexOf("L=")+2, issuertemp.IndexOf(",")-2);
					}

					if (issuer.IndexOf("S=")>=0) 
					{
						issuertemp = issuer.Substring(issuer.IndexOf("S="));
						txtSSLState.Text = issuertemp.Substring(issuertemp.IndexOf("S=")+2, issuertemp.IndexOf(",")-2);
					}

					if (issuer.IndexOf("C=")>=0) 
					{
						issuertemp = issuer.Substring(issuer.IndexOf("C="));
						txtSSLCountry.Text = issuertemp.Substring (issuertemp.IndexOf("C=")+2);
					}
		
					RSACryptoServiceProvider rsacsp = GetPublicKeyFromX509Certificate(cert);
					cmbSSLKeyLength.Text = rsacsp.KeySize.ToString();
				}
			}

		}

		private void FillTab_SearchPath() 
		{
			txtConfFolder.Text = myVS.DefaultVMConfigurationPath;

			lstSearchPath.Items.Clear();
			foreach (Object SearchPath in (IEnumerable)myVS.SearchPaths) 
			{
				lstSearchPath.Items.Add(SearchPath.ToString());
			}

			if (lstSearchPath.Items.Count>0) 
			{
				btnRemoveSearchPath.Enabled = true;
			}
			else 
			{
				btnRemoveSearchPath.Enabled = false;
			}

		}

		private void FillTab_Event()
		{

			// Load Events from System log.
			eventLog1.MachineName = thisVSAddress;
			eventLog1.Log = "Virtual Server";
			eventLog1.Source = "Virtual Server";
			cmbEventMax.Text = cmbEventMax.Items[0].ToString();

			// Load cmbFilter
			cmbFilter.Items.Clear();
			cmbFilter.Items.AddRange(new object[] {
													  "All Events",
													  "Virtual Server Events",
													  "Virtual Disk Operation Events",
													  "Perference Change Events",
													  "Remote Control Events"});
			for (int i=1; i<=myVS.VirtualMachines.Count;i++) 
			{
				cmbFilter.Items.Add( myVS.VirtualMachines[i].Name + " Events");
			}
			cmbFilter.Text = cmbFilter.Items[0].ToString();

			btnRefreshEvent_Click(this, new System.EventArgs());
			
			//
			//			// Load Events from System log.
			//			eventLog1.MachineName = thisVSAddress;
			//			eventLog1.Log = "Virtual Server";
			//			eventLog1.Source = "Virtual Server";
			//			cmbEventMax.Text = cmbEventMax.Items[0].ToString();
			//
			//			lstEvent.Items.Clear();
			//
			//			if (eventLog1.Entries.Count > 0) 
			//			{
			//				int EventLogMax = ( eventLog1.Entries.Count < int.Parse(cmbEventMax.Text))?eventLog1.Entries.Count:int.Parse(cmbEventMax.Text);
			//				
			//				for (int i=eventLog1.Entries.Count-1 ; i>= eventLog1.Entries.Count-EventLogMax ; i--) 
			//				{
			//					lstEvent.Items.Add(eventLog1.Entries[i].Message);
			//				}				
			//			}
			//
			//			string[] myItems = new string[] {"","","","","","",""};
			//			System.Diagnostics.EventLogEntry thisEventEntry = null;
			//			ListViewItem lvi = null;
			//			
			//			lvEvent.Items.Clear();
			//			if (eventLog1.Entries.Count > 0) 
			//			{
			//				int EventLogMax = ( eventLog1.Entries.Count < int.Parse(cmbEventMax.Text))?eventLog1.Entries.Count:int.Parse(cmbEventMax.Text);
			//				
			//				for (int i=eventLog1.Entries.Count-1 ; i>= eventLog1.Entries.Count-EventLogMax ; i--) 
			//				{
			//					thisEventEntry = eventLog1.Entries[i];
			//					myItems[0] = thisEventEntry.EntryType.ToString();
			//					myItems[1] = thisEventEntry.TimeGenerated.Month + "/" + thisEventEntry.TimeGenerated.Day + "/" + thisEventEntry.TimeGenerated.Year;
			//					myItems[2] = thisEventEntry.TimeGenerated.Hour + ":" + thisEventEntry.TimeGenerated.Minute + ":" + thisEventEntry.TimeGenerated.Second;
			//					myItems[3] = thisEventEntry.Category.ToString();
			//					myItems[4] = (thisEventEntry.EventID & 0xffff) +"";
			//					myItems[5] = thisEventEntry.UserName;
			//					myItems[6] = thisEventEntry.MachineName;
			//
			//					lvi = new ListViewItem(myItems);
			//					lvEvent.Items.Add(lvi);
			//				}				
			//			}


		}

		private void FillTab_Resource() 
		{
			string[] myItems = new string[] {"","","","","",""};
			float reservedSystemCapacity = 0;
			float MaximumSystemCapacity = 0;
			float TotalCapacityReserved = 0;
			float AvailableCapacityRemaining =0;

			lvResource.Items.Clear();
			// List running machines first.
			for (int i=1; i<=myVS.VirtualMachines.Count; i++) 
			{
				if (myVS.VirtualMachines[i].State == VMVMState.vmVMState_Running) 
				{
					reservedSystemCapacity = float.Parse(myVS.VirtualMachines[i].Accountant.reservedSystemCapacity.ToString())/myVS.HostInfo.LogicalProcessorCount;
					TotalCapacityReserved = TotalCapacityReserved + reservedSystemCapacity;
					MaximumSystemCapacity = float.Parse(myVS.VirtualMachines[i].Accountant.MaximumSystemCapacity.ToString());
					myItems[0] = myVS.VirtualMachines[i].Name;
					myItems[1] = myVS.VirtualMachines[i].Accountant.relativeWeight.ToString();
					myItems[2] = myVS.VirtualMachines[i].Accountant.reservedSystemCapacity.ToString();
					myItems[3] = float.Parse(myVS.VirtualMachines[i].Accountant.MaximumSystemCapacity.ToString()) * myVS.HostInfo.LogicalProcessorCount +"";
					myItems[4] = reservedSystemCapacity.ToString();
					myItems[5] = MaximumSystemCapacity.ToString();
																							
					ListViewItem lvi = new ListViewItem(myItems);

					lvi.BackColor = Color.YellowGreen;
					
					// Insert items.
					lvResource.Items.Add(lvi);
				}
			}
			
			// Fill Total Capacity Reserved and Available Capacity Remaining
			AvailableCapacityRemaining = 100 - TotalCapacityReserved;
			lblTCR.Text = TotalCapacityReserved.ToString() + "%";
			lblACR.Text = (100-TotalCapacityReserved) + "%";
			
			// List VM not running
			for (int i=1; i<=myVS.VirtualMachines.Count; i++) 
			{
				if (myVS.VirtualMachines[i].State != VMVMState.vmVMState_Running ) 
				{
					reservedSystemCapacity = float.Parse(myVS.VirtualMachines[i].Accountant.reservedSystemCapacity.ToString())/myVS.HostInfo.LogicalProcessorCount;
					MaximumSystemCapacity = float.Parse(myVS.VirtualMachines[i].Accountant.MaximumSystemCapacity.ToString());
					myItems[0] = myVS.VirtualMachines[i].Name;
					myItems[1] = myVS.VirtualMachines[i].Accountant.relativeWeight.ToString();
					myItems[2] = myVS.VirtualMachines[i].Accountant.reservedSystemCapacity.ToString();
					myItems[3] = float.Parse(myVS.VirtualMachines[i].Accountant.MaximumSystemCapacity.ToString()) * myVS.HostInfo.LogicalProcessorCount +"";
					myItems[4] = reservedSystemCapacity.ToString();
					myItems[5] = MaximumSystemCapacity.ToString();
																							
					ListViewItem lvi = new ListViewItem(myItems);
				
					// Insert items.
					lvResource.Items.Add(lvi);
				}
			}

			

		}

		private void FillTab_VN()
		{
			lstVN.Items.Clear();
			for (int i=1; i<=myVS.VirtualNetworks.Count; i++) 
			{
				lstVN.Items.Add(myVS.VirtualNetworks[i].Name);
			}

			cmbPhysicanNIC.Items.Clear();
			cmbPhysicanNIC.Items.Add("None (Guest only)");
			foreach ( Object nic in (IEnumerable)myVS.HostInfo.NetworkAdapters) 
			{
				cmbPhysicanNIC.Items.Add(nic.ToString());
				cmbPhysicanNIC.Text = cmbPhysicanNIC.Items[0].ToString();
			}
			cmbDHCPIPLease.Text = cmbDHCPIPLease.Items[1].ToString();
			cmbDHCPLeaseRebinding.Text = cmbDHCPLeaseRebinding.Items[1].ToString();
			cmbDHCPLeaseRenewal.Text = cmbDHCPLeaseRenewal.Items[1].ToString();

		}

		private void FillTab_VD() 
		{
			// Physical Drive

			cmbVDLDPDrive.Items.Clear();
			foreach ( Object hd in (IEnumerable)myVS.HostInfo.HostDrives) 
			{
				cmbVDLDPDrive.Items.Add( hd.ToString());
			}

			cmbVDDEUnit.Text = "GB";
			cmbVDFSUnit.Text = "GB";
			cmbVDLDPDrive.Text = cmbVDLDPDrive.Items[0].ToString();

		}

		private void FillTab_VSView() 
		{
			dgVSView  = Utility.getVSViewGrid(myVS, dgVSView);
			dgVSView.Enabled = false;
		}
		private void FillTab_Scripts() 
		{

			ckbScriptVSEnabled.Checked = myVS.VSScriptsEnabled;
			ckbScriptVMEnabled.Checked = myVS.VMScriptsEnabled;

			// if VS disabled script on VM, disable all controls
			if (myVS.VSScriptsEnabled) 
			{
				// Enable all controls
				lvScripts.Enabled = true;
			}
			else 
			{
				// Disable all controls
				lvScripts.Enabled = false;
			}

			// Display 
			string[] myItems = new string[] {"",""};

			string[] sVSEvent = new string[] {	"When Virtual Server starts",
												 "When Virtual Server stops",
												 "When any VM is turned on",
												 "When any VM is restored",
												 "When any VM is saved and turned off",
												 "When any VM is turned off (and not saved)",
												 "When any VM is turned off within the guest environment",
												 "When any VM is reset",
												 "When any VM has no heartbeat detected",
												 "When any VM experiences a guest processor error",
												 "When any VM receives a warning due to low disk space on the physical computer",
												 "When any VM receives an error due to low disk space on the physical computer"
											 };

			ListViewItem lvi = null;

			lvScripts.Items.Clear();
			for (int i=0; i<12; i++) 
			{
				myItems[0] = sVSEvent[i];
				myItems[1] = myVS.FetchScriptByEvent( (VMEventType)i );
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
		private void button1_Click(object sender, System.EventArgs e)
		{
			if(fbdMain.ShowDialog() == DialogResult.OK)
			{
				if( fbdMain.SelectedPath  != "") 
				{
					// Insert code to read the stream here.
					txtConfFolder.Text = fbdMain.SelectedPath;
				}
			}
		}



		private void btnSelectNewSearchPath_Click(object sender, System.EventArgs e)
		{
			if(fbdMain.ShowDialog() == DialogResult.OK)
			{
				if( fbdMain.SelectedPath  != "") 
				{
					// Insert code to read the stream here.
					txtSearchPathNew.Text = fbdMain.SelectedPath;
				}
			}
		}

		private void lstSearchPath_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstSearchPath.Enabled) 
			{
				txtSearchPathNew.Text = lstSearchPath.SelectedItem.ToString();
			}
		}

		private void btnAddSearchPath_Click(object sender, System.EventArgs e)
		{

			lstSearchPath.Items.Add(txtSearchPathNew.Text);

			string[] sSearchPath = new string[lstSearchPath.Items.Count];
			for (int i=0; i<lstSearchPath.Items.Count; i++) 
			{
				sSearchPath[i] = lstSearchPath.Items[i].ToString();
			}


			myVS.SearchPaths = sSearchPath;

			//myVS.SearchPaths = lstSearchPath.Items;

			FillTab_SearchPath();

		}

		private void btnRemoveSearchPath_Click(object sender, System.EventArgs e)
		{

			// Delete from lstSearchPath box.
			lstSearchPath.Enabled = false;
			lstSearchPath.Items.RemoveAt(lstSearchPath.SelectedIndex);


			// Construct string array to feed myVS.SearchPaths
			string[] sSearchPath = new string[lstSearchPath.Items.Count];
			for (int i=0; i<lstSearchPath.Items.Count; i++) 
			{
				sSearchPath[i] = lstSearchPath.Items[i].ToString();
			}
			myVS.SearchPaths = sSearchPath;

			// Refresh
			FillTab_SearchPath();
			lstSearchPath.Enabled = true;
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
				
				switch (cmbFilter.Text) 
				{
					case "All Events":
						for (int i=eventLog1.Entries.Count-1 ; i>= eventLog1.Entries.Count-EventLogMax ; i--) 
						{
							thisEventEntry = eventLog1.Entries[i];

							//myItems[0] = thisEventEntry.EntryType.ToString();
							myItems[1] = thisEventEntry.TimeGenerated.Month + "/" + thisEventEntry.TimeGenerated.Day + "/" + thisEventEntry.TimeGenerated.Year;
							myItems[2] = thisEventEntry.TimeGenerated.Hour + ":" + thisEventEntry.TimeGenerated.Minute + ":" + thisEventEntry.TimeGenerated.Second;
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
						}	
						break;
					case "Virtual Server Events":
					case "Virtual Disk Operation Events":
					case "Remote Control Events":
					case "Setting Change Events":
						int j = int.Parse(cmbEventMax.Text);

						for (int i=eventLog1.Entries.Count-1; i>=0; i--)
						{

							if (eventLog1.Entries[i].Category==cmbFilter.Text.Substring(0, cmbFilter.Text.IndexOf("Event")-1) ) 
							{
								thisEventEntry = eventLog1.Entries[i];
								//myItems[0] = thisEventEntry.EntryType.ToString();
								myItems[1] = thisEventEntry.TimeGenerated.Month + "/" + thisEventEntry.TimeGenerated.Day + "/" + thisEventEntry.TimeGenerated.Year;
								myItems[2] = thisEventEntry.TimeGenerated.Hour + ":" + thisEventEntry.TimeGenerated.Minute + ":" + thisEventEntry.TimeGenerated.Second;
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
								if (j>1) 
								{
									j--;
								}
								else
								{
									break;
								}
							}

						}
						break;
					default:
						string thisVM = cmbFilter.Text.Substring(0, cmbFilter.Text.IndexOf("Event")-1);
						int k = int.Parse(cmbEventMax.Text);

						for (int i=eventLog1.Entries.Count-1; i>=0; i--)
						{

							if ( eventLog1.Entries[i].Category== "Virtual Machine" &&
								eventLog1.Entries[i].Message.IndexOf(thisVM)>=0 ) 
							{
								thisEventEntry = eventLog1.Entries[i];
								//myItems[0] = thisEventEntry.EntryType.ToString();
								myItems[1] = thisEventEntry.TimeGenerated.Month + "/" + thisEventEntry.TimeGenerated.Day + "/" + thisEventEntry.TimeGenerated.Year;
								myItems[2] = thisEventEntry.TimeGenerated.Hour + ":" + thisEventEntry.TimeGenerated.Minute + ":" + thisEventEntry.TimeGenerated.Second;
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
						break;

				}
			}



		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void ckbVMRCEnable_CheckedChanged(object sender, System.EventArgs e)
		{
			if (ckbVMRCEnable.Checked) 
			{
				cmbVMRCAddress.Enabled = true;
				txtVMRCPort.Enabled = true;
				cmbScrRes.Enabled = true;
				cmbVMRCAuth.Enabled = true;
				ckbIdleEnable.Enabled = true;
				txtVMRCTimeout.Enabled = true;
			}
			else
			{
				cmbVMRCAddress.Enabled = false;
				txtVMRCPort.Enabled = false;
				cmbScrRes.Enabled = false;
				cmbVMRCAuth.Enabled = false;
				ckbIdleEnable.Enabled = false;
				txtVMRCTimeout.Enabled = false;
			}
		}

		private void ckbIdleEnable_CheckedChanged(object sender, System.EventArgs e)
		{
			if (ckbIdleEnable.Checked) 
			{
				txtVMRCTimeout.Enabled = true;
			}
			else
			{
				txtVMRCTimeout.Enabled = false;
			}
		}

		private void btnUpdateVMRC_Click(object sender, System.EventArgs e)
		{
			myVS.VMRCEnabled = ckbVMRCEnable.Checked;
			if (myVS.VMRCEnabled) 
			{
				
				if (cmbVMRCAddress.Text=="(All unassigned)")
				{
					myVS.VMRCAdminAddress = "";
				} 
				else 
				{
					myVS.VMRCAdminAddress = cmbVMRCAddress.Text;
				}

				try 
				{
					myVS.VMRCAdminPortNumber = int.Parse(txtVMRCPort.Text);
					
				}
				catch (Exception err) 
				{
					MessageBox.Show(err.Message);
				}

				myVS.VMRCXResolution = int.Parse(cmbScrRes.Text.Substring(0, cmbScrRes.Text.IndexOf("x")-2));
				myVS.VMRCYResolution = int.Parse(cmbScrRes.Text.Substring( cmbScrRes.Text.IndexOf("x")+2) );

				//MessageBox.Show(int.Parse(cmbScrRes.Text.Substring(0, cmbScrRes.Text.IndexOf("x")-2)) + "x" + int.Parse(cmbScrRes.Text.Substring( cmbScrRes.Text.IndexOf("x")+2) ));
				//myVS.VMRCAuthenticator.Name = cmbVMRCAuth.Text;
				
				if (ckbIdleEnable.Checked) 
				{
					myVS.VMRCIdleConnectionTimeoutEnabled = ckbIdleEnable.Checked;
					myVS.VMRCIdleConnectionTimeout = int.Parse(txtVMRCTimeout.Text)*60;
				} 


				myVS.VMRCEncryptionEnabled = ckbSSLEnable.Checked;
				if (myVS.VMRCEncryptionEnabled) 
				{
					if (rdbSSLDelete.Checked) 
					{
						myVS.VMRCEncryptionCertificate = "";
					}

					if (rdbSSLUpload.Checked) 
					{


						try
						{
							System.IO.StreamReader sr = System.IO.File.OpenText(txtSSLCertPath.Text);
							String filestr = sr.ReadToEnd();
							sr.Close();
							StringBuilder sb = new StringBuilder(filestr) ;
							sb.Replace("-----BEGIN CERTIFICATE-----", "") ;
							sb.Replace("-----END CERTIFICATE-----", "") ;
							myVS.VMRCEncryptionCertificate = sb.ToString();

						} 
						catch (Exception err) 
						{
							MessageBox.Show(err.Message);
							
						}

				
						
					}

					if (rdbSSLRequest.Checked) 
					{
						string SSLString = "";
						SSLString  = "CN=" + txtSSLHost.Text + ",";
						SSLString += "O=" + txtSSLOrg.Text + ",";
						SSLString += "OU=" + txtSSLOU.Text + ",";
						SSLString += "L=" + txtSSLCity.Text + ",";
						SSLString += "S=" + txtSSLState.Text + ",";
						SSLString += "C=" + txtSSLCountry.Text ;
						myVS.VMRCCreateEncryptionCertificateRequest(SSLString, int.Parse(cmbSSLKeyLength.Text));
						txtSSLCertificate.Text = "-----BEGIN NEW CERTIFICATE REQUEST-----" + myVS.VMRCEncryptionCertificate + "-----END NEW CERTIFICATE REQUEST-----";
						rdbSSLKeep.Checked = true;
					}
				}


			} 
		
			

		}

		private void ckbSSLEnable_CheckedChanged(object sender, System.EventArgs e)
		{
			if (ckbSSLEnable.Checked) 
			{
				rdbSSLDelete.Enabled = true;
				rdbSSLKeep.Enabled = true;
				rdbSSLRequest.Enabled = true;
				rdbSSLUpload.Enabled = true;
				if (!rdbSSLKeep.Checked) 
				{
					rdbSSLKeep_CheckedChanged(this, new System.EventArgs());
				}
				
				if (rdbSSLDelete.Checked) 
				{
					rdbSSLDelete_CheckedChanged(this, new System.EventArgs());
				}

				if (rdbSSLRequest.Checked) 
				{
					rdbSSLRequest_CheckedChanged(this, new System.EventArgs());
				}

				if (rdbSSLUpload.Checked) 
				{
					rdbSSLUpload_CheckedChanged(this, new System.EventArgs());
				}

			}
			else 
			{
				rdbSSLDelete.Enabled = false;
				rdbSSLKeep.Enabled = false;
				rdbSSLRequest.Enabled = false;
				rdbSSLUpload.Enabled = false;
				cmbSSLKeyLength.Enabled = false;
				txtSSLCity.Enabled = false;
				txtSSLHost.Enabled = false;
				txtSSLOrg.Enabled = false;
				txtSSLOU.Enabled = false;
				txtSSLState.Enabled = false;
				txtSSLCountry.Enabled = false;
				txtSSLCertPath.Enabled = false;
				btnSSLBrowse.Enabled = false;
			}
		}

		private void rdbSSLKeep_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbSSLKeep.Checked )
			{
				txtSSLCity.Enabled = false;
				txtSSLHost.Enabled = false;
				txtSSLOrg.Enabled = false;
				txtSSLOU.Enabled = false;
				txtSSLState.Enabled = false;
				txtSSLCountry.Enabled = false;
				txtSSLCertPath.Enabled = false;
				btnSSLBrowse.Enabled = false;
				cmbSSLKeyLength.Enabled = false;
			}
		}

		private void rdbSSLRequest_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbSSLRequest.Checked) 
			{
				txtSSLCity.Enabled = true;
				txtSSLHost.Enabled = true;
				txtSSLOrg.Enabled = true;
				txtSSLOU.Enabled = true;
				txtSSLState.Enabled = true;
				txtSSLCountry.Enabled = true;
				txtSSLCertPath.Enabled = false;
				btnSSLBrowse.Enabled = false;
				cmbSSLKeyLength.Enabled = true;
			}
		}

		private void rdbSSLUpload_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbSSLUpload.Checked) 
			{
				txtSSLCity.Enabled = false;
				txtSSLHost.Enabled = false;
				txtSSLOrg.Enabled = false;
				txtSSLOU.Enabled = false;
				txtSSLState.Enabled = false;
				txtSSLCountry.Enabled = false;
				cmbSSLKeyLength.Enabled = false;
				txtSSLCertPath.Enabled = true;
				btnSSLBrowse.Enabled = true;
			} 
		}

		private void rdbSSLDelete_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbSSLDelete.Checked )
			{
				txtSSLCity.Enabled = false;
				txtSSLHost.Enabled = false;
				txtSSLOrg.Enabled = false;
				txtSSLOU.Enabled = false;
				txtSSLState.Enabled = false;
				txtSSLCountry.Enabled = false;
				cmbSSLKeyLength.Enabled = false;
				txtSSLCertPath.Enabled = false;
				btnSSLBrowse.Enabled = false;
			}
		}

		private void btnSSLBrowse_Click(object sender, System.EventArgs e)
		{
			ofdMain.Filter = "All files (*.*)|*.*";
			if(ofdMain.ShowDialog() == DialogResult.OK)
			{
				if( ofdMain.FileName != "") 
				{
					// Insert code to read the stream here.
					txtSSLCertPath.Text = ofdMain.FileName;
				}
			
			}




		}

		private void lvResource_SelectedIndexChanged(object sender, System.EventArgs e)
		{


			if (lvResource.SelectedItems.Count != 0) 
			{

				int VMIndex = -1;
				//MessageBox.Show(lvResource.FocusedItem.SubItems.Count.ToString());
				// Find out the VM index 
				if (myVS.VirtualMachines.Count >0 ) 
				{
					for(int i=1; i<=myVS.VirtualMachines.Count; i++) 
					{	
						if (myVS.VirtualMachines[i].Name == lvResource.SelectedItems[0].SubItems[0].Text ) 
						{
							VMIndex = i;
							break;
						}
					}
				}

				lblVM.Text = myVS.VirtualMachines[VMIndex].Name;
				txtRW.Text = myVS.VirtualMachines[VMIndex].Accountant.relativeWeight.ToString();
				txtRCC.Text = myVS.VirtualMachines[VMIndex].Accountant.reservedSystemCapacity.ToString();
				txtMCC.Text = float.Parse(myVS.VirtualMachines[VMIndex].Accountant.MaximumSystemCapacity.ToString()) * myVS.HostInfo.LogicalProcessorCount +"";
				lblRSC.Text = float.Parse(myVS.VirtualMachines[VMIndex].Accountant.reservedSystemCapacity.ToString())/myVS.HostInfo.LogicalProcessorCount + "";
				lblMSC.Text = float.Parse(myVS.VirtualMachines[VMIndex].Accountant.MaximumSystemCapacity.ToString()) + "";
			
				btnUpdateResource.Enabled = true;
			}
			else 
			{
				return;
			}
			
			
	
		}

		private void btnLoad_Click(object sender, System.EventArgs e)
		{
			if (lvResource.SelectedItems.Count != 0) 
			{
				int VMIndex = -1;
				//MessageBox.Show(lvResource.FocusedItem.SubItems.Count.ToString());
				// Find out the VM index 
				if (myVS.VirtualMachines.Count >0 ) 
				{
					for(int i=1; i<=myVS.VirtualMachines.Count; i++) 
					{	
						if (myVS.VirtualMachines[i].Name == lvResource.SelectedItems[0].SubItems[0].Text ) 
						{
							VMIndex = i;
							break;
						}
					}
				}

				lblVM.Text = myVS.VirtualMachines[VMIndex].Name;
				txtRW.Text = myVS.VirtualMachines[VMIndex].Accountant.relativeWeight.ToString();
				txtRCC.Text = myVS.VirtualMachines[VMIndex].Accountant.reservedSystemCapacity.ToString();
				txtMCC.Text = float.Parse(myVS.VirtualMachines[VMIndex].Accountant.MaximumSystemCapacity.ToString()) * myVS.HostInfo.LogicalProcessorCount +"";
				lblRSC.Text = float.Parse(myVS.VirtualMachines[VMIndex].Accountant.reservedSystemCapacity.ToString())/myVS.HostInfo.LogicalProcessorCount + "";
				lblMSC.Text = float.Parse(myVS.VirtualMachines[VMIndex].Accountant.MaximumSystemCapacity.ToString()) + "";
			
				btnUpdateResource.Enabled = true;
			} 
			else 
			{
				MessageBox.Show("Please select a virtual machine above.");
			}
		}

		private void btnUpdateResource_Click(object sender, System.EventArgs e)
		{
			if ( float.Parse(txtRW.Text) >100 || float.Parse(txtRW.Text) <0 ) 
			{
				MessageBox.Show("Wrong Relative Weight number");
				return;
			}

			if ( float.Parse(txtRCC.Text) >100 || float.Parse(txtRCC.Text) <0 ) 
			{
				MessageBox.Show("Wrong Reserved CPU Capacity");
				return;
			}

			if ( float.Parse(txtMCC.Text) >100 || float.Parse(txtMCC.Text) <0 ) 
			{
				MessageBox.Show("Wrong Maximum CPU Capacity");
				return;
			}

			// If the sum of Reserved CPU Capacity > 100, Error and return
			

			// Save
			int VMIndex = -1;
			//MessageBox.Show(lvResource.FocusedItem.SubItems.Count.ToString());
			// Find out the VM index 
			if (myVS.VirtualMachines.Count >0 ) 
			{
				for(int i=1; i<=myVS.VirtualMachines.Count; i++) 
				{	
					if (myVS.VirtualMachines[i].Name == lvResource.SelectedItems[0].SubItems[0].Text ) 
					{
						VMIndex = i;
						break;
					}
				}
			}
			myVS.VirtualMachines[VMIndex].Accountant.SetSchedulingParameters(txtRCC.Text, float.Parse(txtMCC.Text)/myVS.HostInfo.PhysicalProcessorCount , int.Parse(txtRW.Text));

			btnUpdateResource.Enabled = false;
			// Reload
			FillTab_Resource();

		}

		private void lstVN_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Simplify 
			

			// Display VM which use this VN
			lstVNVM.Items.Clear();
			for (int i=1; i<=myVS.VirtualMachines.Count; i++) 
			{
				for (int j=1; j<=myVS.VirtualMachines[i].NetworkAdapters.Count; j++) 
				{
					if ( myVS.VirtualMachines[i].NetworkAdapters[j].virtualNetwork != null  && 
						myVS.VirtualMachines[i].NetworkAdapters[j].virtualNetwork.Name == lstVN.Items[lstVN.SelectedIndex].ToString()) 
					{
						lstVNVM.Items.Add(myVS.VirtualMachines[i].Name);
					}
					
				}
			}

			// Fill Network Settings
			txtVNName.Text = myVS.VirtualNetworks[lstVN.SelectedIndex+1].Name;
			if (myVS.VirtualNetworks[lstVN.SelectedIndex+1].HostAdapter == "") 
			{
				cmbPhysicanNIC.Text = "None (Guest only)";
			}
			else 
			{
				cmbPhysicanNIC.Text = myVS.VirtualNetworks[lstVN.SelectedIndex+1].HostAdapter;
			}
			txtVNNotes.Text = myVS.VirtualNetworks[lstVN.SelectedIndex+1].Notes;
			
			ckbVNDHCPEnable.Checked = myVS.VirtualNetworks[lstVN.SelectedIndex+1].DHCPVirtualNetworkServer.isEnabled;

			if (ckbVNDHCPEnable.Checked) 
			{
				txtDHCPServerAddress.Enabled = true;
				txtDHCPServerAddress.Text = myVS.VirtualNetworks[lstVN.SelectedIndex+1].DHCPVirtualNetworkServer.ServerIPAddress;

				txtDHCPNetworkAddress.Enabled = true;
				txtDHCPNetworkAddress.Text = myVS.VirtualNetworks[lstVN.SelectedIndex+1].DHCPVirtualNetworkServer.network;

				txtDHCPNetMask.Enabled = true;
				txtDHCPNetMask.Text = myVS.VirtualNetworks[lstVN.SelectedIndex+1].DHCPVirtualNetworkServer.networkMask;

				txtDHCPGW.Enabled = true;
				txtDHCPGW.Text = myVS.VirtualNetworks[lstVN.SelectedIndex+1].DHCPVirtualNetworkServer.DefaultGatewayAddress;

				txtDHCPStartIP.Enabled = true;
				txtDHCPStartIP.Text = myVS.VirtualNetworks[lstVN.SelectedIndex+1].DHCPVirtualNetworkServer.startingIPAddress;

				txtDHCPEndIP.Enabled = true;
				txtDHCPEndIP.Text = myVS.VirtualNetworks[lstVN.SelectedIndex+1].DHCPVirtualNetworkServer.endingIPAddress;

				txtDHCPDNS.Enabled = true;
				txtDHCPDNS.Text = myVS.VirtualNetworks[lstVN.SelectedIndex+1].DHCPVirtualNetworkServer.DNSServers;

				txtDHCPWINS.Enabled = true;
				txtDHCPWINS.Text = myVS.VirtualNetworks[lstVN.SelectedIndex+1].DHCPVirtualNetworkServer.WINSServers;

				cmbDHCPIPLease.Enabled = true;
				cmbDHCPIPLease.Text = ConvertTimeLabel(long.Parse(myVS.VirtualNetworks[lstVN.SelectedIndex+1].DHCPVirtualNetworkServer.leaseTime.ToString()));
				txtDHCPIPLease.Enabled = true;
				txtDHCPIPLease.Text = ConvertTimeToString(cmbDHCPIPLease.Text, long.Parse(myVS.VirtualNetworks[lstVN.SelectedIndex+1].DHCPVirtualNetworkServer.leaseTime.ToString()));

				cmbDHCPLeaseRenewal.Enabled = true;
				cmbDHCPLeaseRenewal.Text = ConvertTimeLabel(long.Parse(myVS.VirtualNetworks[lstVN.SelectedIndex+1].DHCPVirtualNetworkServer.leaseRenewalTime.ToString()));
				txtDHCPLeaseRenewal.Enabled = true;
				txtDHCPLeaseRenewal.Text = ConvertTimeToString(cmbDHCPLeaseRenewal.Text, long.Parse(myVS.VirtualNetworks[lstVN.SelectedIndex+1].DHCPVirtualNetworkServer.leaseRenewalTime.ToString()));

				cmbDHCPLeaseRebinding.Enabled = true;	
				cmbDHCPLeaseRebinding.Text = ConvertTimeLabel(long.Parse(myVS.VirtualNetworks[lstVN.SelectedIndex+1].DHCPVirtualNetworkServer.leaseRebindingTime.ToString()));
				txtDHCPLeaseRebinding.Enabled = true;
				txtDHCPLeaseRebinding.Text = ConvertTimeToString(cmbDHCPLeaseRebinding.Text, long.Parse(myVS.VirtualNetworks[lstVN.SelectedIndex+1].DHCPVirtualNetworkServer.leaseRebindingTime.ToString()));
			}

		}

		private string ConvertTimeLabel(long Timein) 
		{
			string sTimeout = "";

			if ( Timein>=86400 && Timein%86400==0) 
			{
				sTimeout = "Days";
			}

			if (Timein> 86400 && Timein%86400!=0)
			{
				sTimeout = "Hours";
			}

			if ( Timein>=3600 && Timein<86400 && Timein%3600==0) 
			{
				sTimeout = "Hours";
			}

			if ( Timein>3600 && Timein<86400 && Timein%3600!=0) 
			{
				sTimeout = "Minutes";
			}

			if ( Timein>=60 && Timein<3600 && Timein%60==0) 
			{
				sTimeout = "Minutes";
			}
			
			if (Timein>60 && Timein<3600 && Timein%60!=0)
			{
				sTimeout = "Seconds";
			}

			if (Timein<60)
			{
				sTimeout = "Seconds";
			}
			

			return sTimeout;
		}

		private string ConvertTimeToString(string label, long Timein) 
		{
			long Timeout = 0;
			switch (label) 
			{
				case "Days":
					Timeout = Timein/86400;
					break;
				case "Hours":
					Timeout = Timein/3600;
					break;
				case "Minutes":
					Timeout = Timein/60;
					break;
				case "Seconds":
					Timeout = Timein;
					break;
				default:
					break;
			}

			return Timeout.ToString();
			
		}
		private long ConvertStringToTime(string label, string Timein)
		{
			long Timeout = 0;
			
			switch (label) 
			{
				case "Days":
					Timeout = long.Parse(Timein) * 86400;
					break;
				case "Hours":
					Timeout = long.Parse(Timein) * 3600;
					break;
				case "Minutes":
					Timeout = long.Parse(Timein) * 60;
					break;
				case "Seconds":
					Timeout = long.Parse(Timein);
					break;
				default:
					break;
			}

			return Timeout;
		}

		private string ConvertSizeToString(long iSize) 
		{
			string sSize = "";

			if (iSize >= 1073741824) 
			{
				sSize = Math.Round(iSize/1073741824.0,2) + " GB"; 
			}

			if ( iSize < 1073741824 && iSize >= 1048576 )
			{
				sSize = Math.Round(iSize/1048576.0, 2) + " MB";
			}

			if (iSize <1048576 && iSize>=1024) 
			{
				sSize = Math.Round(iSize/1024.0,2) + " KB";
			}

			if (iSize <1024) 
			{
				sSize = iSize + " Bytes";
			}
			
			return sSize;
		}

		private string ConvertSecToString(long Runtime) 
		{
			string sRuntime = "";

			sRuntime  = Runtime/86400 + " days, " ;
			sRuntime += (Runtime%84600)/3600 + " hours, ";
			sRuntime += (Runtime%3600)/60 + " minutes, ";
			sRuntime += (Runtime%60) + " seconds";

			return sRuntime;
		}

		private void ckbVNDHCPEnable_CheckedChanged(object sender, System.EventArgs e)
		{
			if (ckbVNDHCPEnable.Checked) 
			{
				txtDHCPServerAddress.Enabled = true;
				txtDHCPNetworkAddress.Enabled = true;
				txtDHCPNetMask.Enabled = true;
				txtDHCPGW.Enabled = true;
				txtDHCPStartIP.Enabled = true;
				txtDHCPEndIP.Enabled = true;
				txtDHCPDNS.Enabled = true;
				txtDHCPWINS.Enabled = true;
				txtDHCPIPLease.Enabled = true;
				cmbDHCPIPLease.Enabled = true;
				txtDHCPLeaseRenewal.Enabled = true;
				cmbDHCPLeaseRenewal.Enabled = true;
				txtDHCPLeaseRebinding.Enabled = true;
				cmbDHCPLeaseRebinding.Enabled = true;

			}
			else 
			{
				txtDHCPServerAddress.Enabled = false;
				txtDHCPNetworkAddress.Enabled = false;
				txtDHCPNetMask.Enabled = false;
				txtDHCPGW.Enabled = false;
				txtDHCPStartIP.Enabled = false;
				txtDHCPEndIP.Enabled = false;
				txtDHCPDNS.Enabled = false;
				txtDHCPWINS.Enabled = false;
				txtDHCPIPLease.Enabled = false;
				cmbDHCPIPLease.Enabled = false;
				txtDHCPLeaseRenewal.Enabled = false;
				cmbDHCPLeaseRenewal.Enabled = false;
				txtDHCPLeaseRebinding.Enabled = false;
				cmbDHCPLeaseRebinding.Enabled = false;

			}
		}

		private void btnRemoveVN_Click(object sender, System.EventArgs e)
		{
			try 
			{
				myVS.UnregisterVirtualNetwork(myVS.VirtualNetworks[lstVN.SelectedIndex+1]);
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
				return;
			}
			FillTab_VN();
		}

		private void btnAddVN_Click(object sender, System.EventArgs e)
		{
			//MessageBox.Show( myVS.DefaultVNConfigurationPath );
			try 
			{
				myVS.CreateVirtualNetwork(txtVNName.Text, myVS.DefaultVNConfigurationPath );
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
				return;
			}
			
			myVS.VirtualNetworks[myVS.VirtualNetworks.Count].HostAdapter = (cmbPhysicanNIC.Text == "" || cmbPhysicanNIC.Text == "None (Guest only)")?"":cmbPhysicanNIC.Text;
			myVS.VirtualNetworks[myVS.VirtualNetworks.Count].Notes = txtVNNotes.Text;
			
			FillTab_VN();

		}

		private void btnUpdateVN_Click(object sender, System.EventArgs e)
		{
			VMVirtualNetwork thisVN;
			try 
			{
				thisVN = myVS.VirtualNetworks[lstVN.SelectedIndex+1];
			} 
			catch (Exception err) 
			{
				MessageBox.Show(err.Message);
				return;
			}

			// Update Network Settings
			try 
			{
				thisVN.Name = txtVNName.Text ;
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
				return;
			}

			if (cmbPhysicanNIC.Text == "None (Guest only)" || cmbPhysicanNIC.Text =="") 
			{
				thisVN.HostAdapter = "";
			}
			else 
			{
				thisVN.HostAdapter = cmbPhysicanNIC.Text;
			}

			thisVN.Notes = txtVNNotes.Text;


			// Update DHCP Settings
			if (ckbVNDHCPEnable.Checked) 
			{
				thisVN.DHCPVirtualNetworkServer.isEnabled = true;
				thisVN.DHCPVirtualNetworkServer.ConfigureDHCPServer(txtDHCPNetworkAddress.Text, txtDHCPNetMask.Text, txtDHCPStartIP.Text, txtDHCPEndIP.Text, txtDHCPServerAddress.Text);
				thisVN.DHCPVirtualNetworkServer.DefaultGatewayAddress = txtDHCPGW.Text; 
				thisVN.DHCPVirtualNetworkServer.DNSServers = txtDHCPDNS.Text ;
				thisVN.DHCPVirtualNetworkServer.WINSServers = txtDHCPWINS.Text;

				try 
				{
					thisVN.DHCPVirtualNetworkServer.ConfigureDHCPLeaseTimes(ConvertStringToTime(cmbDHCPIPLease.Text, txtDHCPIPLease.Text),
						ConvertStringToTime(cmbDHCPLeaseRenewal.Text, txtDHCPLeaseRenewal.Text),
						ConvertStringToTime(cmbDHCPLeaseRebinding.Text, txtDHCPLeaseRebinding.Text));
				} 
				catch (Exception err)
				{
					MessageBox.Show(err.Message);
					return;
				}

			}
			else
			{
				thisVN.DHCPVirtualNetworkServer.isEnabled = false;
			}
			
		}

		private void btnBrowseVD_Click_1(object sender, System.EventArgs e)
		{
			ofdMain.Filter = "VHD files (*.vhd)|*.vhd";
			if(ofdMain.ShowDialog() == DialogResult.OK)
			{
				//string VDDFile = txtVDDFilePath.Text;

				if( ofdMain.FileName != "") 
				{
					// Insert code to read the stream here.
					txtInspectVDFilename.Text = ofdMain.FileName;
				}
			}
		}

		private void btnVNAddExisting_Click(object sender, System.EventArgs e)
		{
			string vncFile = ""; 

			ofdMain.Filter = "Virtual Network files (*.vnc)|*.vnc";
			if(ofdMain.ShowDialog() == DialogResult.OK)
			{
				if( ofdMain.FileName != "") 
				{
					// Insert code to read the stream here.
					vncFile = ofdMain.FileName;
				}
			}
			
			if (File.Exists(vncFile)) 
			{
				FileInfo fi = new FileInfo(vncFile);
			
				try 
				{
					myVS.RegisterVirtualNetwork(fi.Name, fi.DirectoryName);
					MessageBox.Show("Virtual Network is added.");
				}
				catch (Exception err)
				{
					MessageBox.Show(err.Message);
				}
				FillTab_VN();
			}

			
		}


		private void btnVDDEBrowse_Click(object sender, System.EventArgs e)
		{
			//ofdMain.Filter = "VHD files (*.vhd)|*.vhd";
			if(fbdMain.ShowDialog() == DialogResult.OK)
			{
				//string VDDFile = txtVDDFilePath.Text;

				if( fbdMain.SelectedPath != "") 
				{
					// Insert code to read the stream here.
					txtVDDEFilename.Text = fbdMain.SelectedPath;
				}
			}
		}

		private void btnVDDDParent_Click(object sender, System.EventArgs e)
		{
			ofdMain.Filter = "VHD files (*.vhd)|*.vhd";
			if(ofdMain.ShowDialog() == DialogResult.OK)
			{
				//string VDDFile = txtVDDFilePath.Text;

				if( ofdMain.FileName != "") 
				{
					// Insert code to read the stream here.
					txtVDDDParent.Text = ofdMain.FileName;
				}
			}
		}

		private void btnVDDDDiff_Click(object sender, System.EventArgs e)
		{
			//ofdMain.Filter = "VHD files (*.vhd)|*.vhd";
			if(fbdMain.ShowDialog() == DialogResult.OK)
			{
				//string VDDFile = txtVDDFilePath.Text;

				if( fbdMain.SelectedPath != "") 
				{
					// Insert code to read the stream here.
					txtVDDDDiff.Text = fbdMain.SelectedPath;
				}
			}
		}

		private void btnVDLDBrowse_Click(object sender, System.EventArgs e)
		{
			//ofdMain.Filter = "VHD files (*.vhd)|*.vhd";
			if(fbdMain.ShowDialog() == DialogResult.OK)
			{
				//string VDDFile = txtVDDFilePath.Text;

				if( fbdMain.SelectedPath != "") 
				{
					// Insert code to read the stream here.
					txtVDLDFilename.Text = fbdMain.SelectedPath;
				}
			}
		}

		private void btnVDFSBrowse_Click(object sender, System.EventArgs e)
		{
			//ofdMain.Filter = "VHD files (*.vhd)|*.vhd";
			if(fbdMain.ShowDialog() == DialogResult.OK)
			{
				//string VDDFile = txtVDDFilePath.Text;

				if( fbdMain.SelectedPath != "") 
				{
					// Insert code to read the stream here.
					txtVDFSFilename.Text = fbdMain.SelectedPath;
				}
			}
		}



		private void btnBrowseVD_Click(object sender, System.EventArgs e)
		{
			ofdMain.Filter = "VHD files (*.vhd)|*.vhd";
			if(ofdMain.ShowDialog() == DialogResult.OK)
			{
				//string VDDFile = txtVDDFilePath.Text;

				if( ofdMain.FileName != "") 
				{
					// Insert code to read the stream here.
					txtInspectVDFilename.Text = ofdMain.FileName;
				}
			}
		}

		private void btnInspectVD_Click(object sender, System.EventArgs e)
		{
			VMHardDisk thisVD;
			try 
			{
				thisVD = myVS.GetHardDisk(txtInspectVDFilename.Text);
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
				return;
			}
			
			switch (thisVD.Type) 
			{
				case VMHardDiskType.vmDiskType_Dynamic:
					lblVDType.Text =  "Dynamically Expanding Virtual Hard Disk";
					btnConvertVHD.Enabled = true;
					btnCompact.Enabled = true;
					break;
				case VMHardDiskType.vmDiskType_FixedSize:
					lblVDType.Text = "Fixed Size Virtual Hard Disk";
					btnConvertVHD.Enabled = true;
					btnCompact.Enabled = false;
					break;
				case VMHardDiskType.vmDiskType_Differencing:
					lblVDType.Text = "Differencing Virtual Hard DIsk";
					btnConvertVHD.Enabled = false;
					btnCompact.Enabled = false;
					break;
				case VMHardDiskType.vmDiskType_HostDrive:
					lblVDType.Text = "Linked Virtual Hard Disk";
					btnConvertVHD.Enabled = true;
					btnCompact.Enabled = false;
					break;
				default:
					lblVDType.Text = "Unknown Hard Disk Type";
					btnConvertVHD.Enabled = false;
					btnCompact.Enabled = false;
					break;
			}
			lblFQPath.Text = thisVD.File;
			lblIVDMaxSize.Text = ConvertSizeToString( long.Parse(thisVD.SizeInGuest.ToString()));

			lblIVDCurrentSize.Text =  ConvertSizeToString( long.Parse(thisVD.SizeOnHost.ToString()));

		}

		private void btnCompact_Click(object sender, System.EventArgs e)
		{
			try 
			{
				VMHardDisk thisVD = myVS.GetHardDisk(txtInspectVDFilename.Text);
				thisVD.Compact();
			}
			catch (Exception err) 
			{
				MessageBox.Show(err.Message);
			}

			btnInspectVD_Click(this, new System.EventArgs());
			
		}

		private void btnConvertBrowse_Click(object sender, System.EventArgs e)
		{	
			//ofdMain.Filter = "VHD files (*.vhd)|*.vhd";
			if(fbdMain.ShowDialog() == DialogResult.OK)
			{
				//string VDDFile = txtVDDFilePath.Text;

				if( fbdMain.SelectedPath != "") 
				{
					// Insert code to read the stream here.
					txtVDLDFilename.Text = fbdMain.SelectedPath;
				}
			}
		}

		private void btnCreateVDDE_Click(object sender, System.EventArgs e)
		{
			int size = 0;
			
			if  (cmbVDDEUnit.Text == "GB" ) 
			{
				size = int.Parse(txtVDDESize.Text)*1073741824;
			}
			else 
			{
				size = int.Parse(txtVDDESize.Text)*1048576;
			}
			
			try 
			{
				myVS.CreateDynamicVirtualHardDisk(txtVDDEFilename.Text , size);
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void btnBrowseIVD_Click(object sender, System.EventArgs e)
		{
			ofdMain.Filter = "VHD files (*.vhd)|*.vhd";
			if(ofdMain.ShowDialog() == DialogResult.OK)
			{
				//string VDDFile = txtVDDFilePath.Text;

				if( ofdMain.FileName != "") 
				{
					// Insert code to read the stream here.
					txtInspectVDFilename.Text = ofdMain.FileName;
				}
			}
		}

		private void btnCreateVDFS_Click(object sender, System.EventArgs e)
		{
			int size = 0;
			
			if  (cmbVDFSUnit.Text == "GB" ) 
			{
				size = int.Parse(txtVDFSSize.Text)*1073741824;
			}
			else 
			{
				size = int.Parse(txtVDFSSize.Text)*1048576;
			}

			try 
			{
				myVS.CreateFixedVirtualHardDisk(txtVDFSFilename.Text , size);
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void btnCreateVDDD_Click(object sender, System.EventArgs e)
		{
			try 
			{
				myVS.CreateDifferencingVirtualHardDisk(txtVDDDDiff.Text, txtVDDDParent.Text);
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void btnCreateVDLD_Click(object sender, System.EventArgs e)
		{
			try 
			{
				myVS.CreateHostDriveVirtualHardDisk(txtVDLDFilename.Text, cmbVDLDPDrive.Text, true);
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void btnVDFD_Click(object sender, System.EventArgs e)
		{
			//ofdMain.Filter = "VHD files (*.vhd)|*.vhd";
			if(fbdMain.ShowDialog() == DialogResult.OK)
			{
				//string VDDFile = txtVDDFilePath.Text;

				if( fbdMain.SelectedPath != "") 
				{
					// Insert code to read the stream here.
					txtVDFDFilename.Text = fbdMain.SelectedPath;
				}
			}
		}

		private void btnCreateVDFD_Click(object sender, System.EventArgs e)
		{
			try 
			{
				myVS.CreateFloppyDiskImage(txtVDFDFilename.Text, VMFloppyDiskImageType.vmFloppyDiskImage_HighDensity);
			}
			catch (Exception err) 
			{
				MessageBox.Show(err.Message);
			}
		}

		private void btnConvertVHD_Click(object sender, System.EventArgs e)
		{
			VMHardDisk thisVD = myVS.GetHardDisk(txtInspectVDFilename.Text);
			VMHardDiskType newVDType;

			switch (thisVD.Type) 
			{
				case VMHardDiskType.vmDiskType_Dynamic:
					newVDType = VMHardDiskType.vmDiskType_FixedSize;
					break;
				case VMHardDiskType.vmDiskType_FixedSize:
					newVDType = VMHardDiskType.vmDiskType_Dynamic;
					break;
				case VMHardDiskType.vmDiskType_Differencing:
					newVDType =  VMHardDiskType.vmDiskType_Dynamic;
					break;
				case VMHardDiskType.vmDiskType_HostDrive:
				default:
					newVDType = VMHardDiskType.vmDiskType_HostDrive;
					break;
			}
			
			if (newVDType != VMHardDiskType.vmDiskType_HostDrive) 
			{
				try 
				{
					thisVD.Convert(txtConvertVHD.Text,newVDType);
				}
				catch (Exception err) 
				{
					MessageBox.Show(err.Message);
				}
			} 
			else 
			{
				MessageBox.Show("Linked Virtual Disk does not support converting.");
			}
		}

		private void lvEvent_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lvEvent.SelectedItems.Count !=0 ) 
			{
				lblEventMessage.Text  = lvEvent.SelectedItems[0].SubItems[7].Text;
			}
		}

		


		private void lvVM_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//			frmVMProperty frm1 = new frmVMProperty();
			//			frm1.ShowDialog();
		}

		private void dgSecurity_CurrentCellChanged(object sender, System.EventArgs e)
		{
			BindingManagerBase bmb = null;
			bmb = dgSecurity.BindingContext[dgSecurity.DataSource, dgSecurity.DataMember];
			DataRow dr = null;
			dr = ((DataRowView)bmb.Current).Row;
	
			txtSecEntryUser.Text = dr[0].ToString();

			// Administrators cannot be removed from the security
			if (txtSecEntryUser.Text == "Administrators") 
			{
				btnSecEntryRemove.Enabled = false;
			}
			else
			{
				btnSecEntryRemove.Enabled = true;
			}
			
			rdbSecEntryAllow.Checked = (dr[1].ToString()=="0")?true:false;
			rdbSecEntryDeny.Checked = !rdbSecEntryAllow.Checked;

			ckbSecEntryFull.Checked = (dr[2].ToString()=="0")?true:false;
			ckbSecEntryModify.Checked = (dr[3].ToString()=="0")?true:false;
			ckbSecEntryView.Checked = (dr[4].ToString()=="0")?true:false;
			ckbSecEntryRemove.Checked = (dr[5].ToString()=="0")?true:false;
			ckbSecEntryChange.Checked = (dr[6].ToString()=="0")?true:false;
			ckbSecEntryControl.Checked = (dr[7].ToString()=="0")?true:false;
			ckbSecEntrySpecial.Checked = (dr[8].ToString()=="0")?true:false;

		}



		private void btnSecEntryRemove_Click(object sender, System.EventArgs e)
		{
			
			BindingManagerBase bmb = null;
			bmb = dgSecurity.BindingContext[dgSecurity.DataSource, dgSecurity.DataMember];
			DataRow dr = null;
			dr = ((DataRowView)bmb.Current).Row;
				
			VMAccessRights vmaccess = null;
			
			try
			{
				VMSecurity vsSecurity = myVS.Security;
				vmaccess = vsSecurity.FindEntry(dr[0].ToString(), (dr[1].ToString()=="0")?VMAccessRightsType.vmAccessRights_Allowed:VMAccessRightsType.vmAccessRights_Denied);
				vsSecurity.RemoveEntry(vmaccess);
				myVS.Security = vsSecurity;
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
			
			FillTab_Security();
		}

		private void btnSecEntryAdd_Click(object sender, System.EventArgs e)
		{
			if (rdbSecEntryAllow.Checked)	
			{
				VMSecurity vsSecurity = myVS.Security;
				VMAccessRights vmaccess = null;
				
				try
				{
					vmaccess = vsSecurity.AddEntry(txtSecEntryUser.Text, (rdbSecEntryAllow.Checked)?VMAccessRightsType.vmAccessRights_Allowed:VMAccessRightsType.vmAccessRights_Denied);
					vmaccess.WriteAccess = ckbSecEntryModify.Checked;
					vmaccess.ReadAccess = ckbSecEntryView.Checked;
					vmaccess.DeleteAccess = ckbSecEntryRemove.Checked;
					vmaccess.ChangePermissions = ckbSecEntryChange.Checked;
					vmaccess.ExecuteAccess = ckbSecEntryControl.Checked;
					vmaccess.SpecialAccess = ckbSecEntrySpecial.Checked;
				
					myVS.Security = vsSecurity;
				}
				catch (Exception err)
				{
					MessageBox.Show(err.Message);
				}

				FillTab_Security();
				
			}
			else if (rdbSecEntryDeny.Checked) 
			{
				if (ckbSecEntryFull.Checked || ckbSecEntryModify.Checked || ckbSecEntryView.Checked || 
					ckbSecEntryRemove.Checked || ckbSecEntryChange.Checked || ckbSecEntryControl.Checked)
				{
				
					VMSecurity vsSecurity = myVS.Security;
					VMAccessRights vmaccess = null;
				
					try
					{
						vmaccess = vsSecurity.AddEntry(txtSecEntryUser.Text, (rdbSecEntryAllow.Checked)?VMAccessRightsType.vmAccessRights_Allowed:VMAccessRightsType.vmAccessRights_Denied);
						vmaccess.WriteAccess = ckbSecEntryModify.Checked;
						vmaccess.ReadAccess = ckbSecEntryView.Checked;
						vmaccess.DeleteAccess = ckbSecEntryRemove.Checked;
						vmaccess.ChangePermissions = ckbSecEntryChange.Checked;
						vmaccess.ExecuteAccess = ckbSecEntryControl.Checked;
						vmaccess.SpecialAccess = ckbSecEntrySpecial.Checked;
						
						myVS.Security = vsSecurity;
					}
					catch (Exception err)
					{
						MessageBox.Show(err.Message);
					}

					FillTab_Security();

				}
				else
				{
					MessageBox.Show("Please choose at least one access permission.");
				}

			}else
			{
				MessageBox.Show("Please select access type.");
			}
				
		}

		private void ckbSecEntryFull_CheckedChanged(object sender, System.EventArgs e)
		{
			if (ckbSecEntryFull.Checked)
			{
				ckbSecEntryChange.Checked = true;
				ckbSecEntryModify.Checked = true;
				ckbSecEntryRemove.Checked = true;
				ckbSecEntryView.Checked = true;
				ckbSecEntryControl.Checked = true;
			}
		}

		private void ckbSecEntryModify_CheckedChanged(object sender, System.EventArgs e)
		{
			if (!ckbSecEntryModify.Checked)
			{
				ckbSecEntryFull.Checked = false;
			}
		}

		private void ckbSecEntryView_CheckedChanged(object sender, System.EventArgs e)
		{
			if (!ckbSecEntryView.Checked)
			{
				ckbSecEntryFull.Checked = false;
			}		
		}

		private void ckbSecEntryRemove_CheckedChanged(object sender, System.EventArgs e)
		{
			if (!ckbSecEntryRemove.Checked)
			{
				ckbSecEntryFull.Checked = false;
			}		
		}

		private void ckbSecEntryChange_CheckedChanged(object sender, System.EventArgs e)
		{
			if (!ckbSecEntryChange.Checked)
			{
				ckbSecEntryFull.Checked = false;
			}		
		}

		private void ckbSecEntryControl_CheckedChanged(object sender, System.EventArgs e)
		{
			if (!ckbSecEntryControl.Checked)
			{
				ckbSecEntryFull.Checked = false;
			}		
		}
		private void btnScriptAttach_Click(object sender, System.EventArgs e)
		{
			int VSEventIndex = lvScripts.SelectedIndices[0] ;
			try 
			{
				myVS.AttachScriptToEvent( (VMEventType)VSEventIndex, txtScript.Text);
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
			FillTab_Scripts();
		}

		private void btnScriptUpdate_Click(object sender, System.EventArgs e)
		{
			int VSEventIndex = lvScripts.SelectedIndices[0];
			try
			{
				myVS.RemoveScriptFromEvent( (VMEventType)VSEventIndex);
				myVS.AttachScriptToEvent( (VMEventType)VSEventIndex, txtScript.Text);
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}

			FillTab_Scripts();
		}

		private void btnScriptRemove_Click(object sender, System.EventArgs e)
		{
			int VSEventIndex = lvScripts.SelectedIndices[0] ;
			try
			{
				myVS.RemoveScriptFromEvent( (VMEventType)VSEventIndex);
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
			FillTab_Scripts();
		}

		private void ckbScriptVSEnabled_CheckedChanged(object sender, System.EventArgs e)
		{
			if (ckbScriptVSEnabled.Checked) 
			{
				lvScripts.Enabled = true;
			}
			else
			{
				lvScripts.Enabled = false;
			}
			lblScriptEvent.Text = "";
			lblScriptEvent.Enabled = false;
			txtScript.Text = "";
			txtScript.Enabled = false;
			btnScriptAttach.Enabled = false;
			btnScriptRemove.Enabled = false;
			btnScriptUpdate.Enabled = false;
			btnScriptVSVMUpdate.Enabled = true;

		}

		private void btnScriptVMVMUpdate_Click(object sender, System.EventArgs e)
		{
			myVS.VSScriptsEnabled = ckbScriptVSEnabled.Checked ;
			myVS.VMScriptsEnabled = ckbScriptVMEnabled.Checked ;
			btnScriptVSVMUpdate.Enabled = false;
		}

		private void ckbScriptVMEnabled_CheckedChanged(object sender, System.EventArgs e)
		{
			btnScriptVSVMUpdate.Enabled = true;
		}


		private void lvScripts_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lvScripts.SelectedItems.Count !=0) 
			{
				lblScriptEvent.Text = lvScripts.Items[lvScripts.SelectedIndices[0]].SubItems[0].Text;
				txtScript.Text = lvScripts.Items[lvScripts.SelectedIndices[0]].SubItems[1].Text;
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


		private void tmrVS_Tick(object sender, System.EventArgs e)
		{	
			FillTab_VSView();
		}







		#region Get bitlength of the public key. Is there a easier way?
		// From http://support.microsoft.com/default.aspx?scid=kb;en-us;320602
		public RSACryptoServiceProvider GetPublicKeyFromX509Certificate (X509Certificate x509)
		{
			const int X509_ASN_ENCODING = 1;
			const int PROV_RSA_FULL = 1;
			const uint PKCS_7_ASN_ENCODING = 0x00010000;
			const int CRYPT_NEWKEYSET = 8;
			const int PUBLICKEYBLOB = 6; 


			RSACryptoServiceProvider rsacsp = null;
			uint hProv = 0;
			IntPtr pPublicKeyBlob = IntPtr.Zero;
			// Get a pointer to a CERT_CONTEXT structure from the raw certificate data.
			IntPtr pCertContext = IntPtr.Zero;
			pCertContext = (IntPtr)Crypt32.CertCreateCertificateContext(X509_ASN_ENCODING | PKCS_7_ASN_ENCODING,
				x509.GetRawCertData(),x509.GetRawCertData().Length);
			if (pCertContext == IntPtr.Zero)
			{
				MessageBox.Show("CertCreateCertificateContext failed: " + Marshal.GetLastWin32Error().ToString());
				goto Cleanup;
			}
			if (!Crypt32.CryptAcquireContext(ref hProv, null, null, PROV_RSA_FULL, 0)) 
			{ 
				if (!Crypt32.CryptAcquireContext(ref hProv, null, null, PROV_RSA_FULL, CRYPT_NEWKEYSET)) 
				{ 
					MessageBox.Show("CryptAcquireContext failed: " + Marshal.GetLastWin32Error().ToString());
					goto Cleanup;
				}
			}
         
			// Get a pointer to the CERT_INFO structure.
			// This pointer is the fourth DWORD of the CERT_CONTEXT structure.
         
			IntPtr pCertInfo = (IntPtr)Marshal.ReadInt32(pCertContext, 12);
         
			// Get a pointer to the CERT_PUBLIC_KEY_INFO structure.
			// This structure is located starting at the fifty-seventh byte
			// of the CERT_INFO structure.
         
			IntPtr pSubjectPublicKeyInfo = (IntPtr)(pCertInfo.ToInt32() + 56);
         
			// Import the public key information from the certificate context
			// into a key container by passing the pointer to the SubjectPublicKeyInfo
			// member of the CERT_INFO structure to the CryptImportPublicKeyInfoEx
			// Win32 API function.
         
			uint hKey = 0;
			if (!Crypt32.CryptImportPublicKeyInfo(hProv,X509_ASN_ENCODING | PKCS_7_ASN_ENCODING,
				pSubjectPublicKeyInfo,ref hKey)) 
			{
				MessageBox.Show("CryptImportPublicKeyInfoEx failed: " + Marshal.GetLastWin32Error().ToString());
				goto Cleanup;
			}

			// Get the size of the buffer that is needed to contain the PUBLICKEYBLOB structure, and then
			// call the CryptExportKey Win32 API function to export the public key to the PUBLICKEYBLOB format.

			uint dwDataLen = 0;
			if (!Crypt32.CryptExportKey(hKey, 0, PUBLICKEYBLOB, 0, 0, ref dwDataLen))
			{
				MessageBox.Show("CryptExportKey failed: " + Marshal.GetLastWin32Error().ToString());
				goto Cleanup;
			}
         
			// Export the public key to the PUBLICKEYBLOB format.
         
			pPublicKeyBlob = Marshal.AllocHGlobal((int)dwDataLen);
			if (!Crypt32.CryptExportKey(hKey, 0, PUBLICKEYBLOB, 0, (uint)pPublicKeyBlob.ToInt32(), ref dwDataLen))
			{
				MessageBox.Show("CryptExportKey failed: " + Marshal.GetLastWin32Error().ToString());
				goto Cleanup;
			}
         
			// Get the public exponent.
			// The public exponent is located in bytes 17 through 20 of the 
			// earlier PUBLICKEYBLOB structure.
         
			byte[] Exponent = new byte[4];
			Marshal.Copy((IntPtr)(pPublicKeyBlob.ToInt32() + 16), Exponent, 0, 4);
			Array.Reverse(Exponent); // Reverse the byte order.

			// Reverse the byte order.
			// Get the length of the modulus.
			// To do this, extract the bit length of the modulus from the PUBLICKEYBLOB structure.
			// The bit length of the modulus is located in bytes 13 through 17 of the PUBLICKEYBLOB structure.
         
			int BitLength = Marshal.ReadInt32(pPublicKeyBlob, 12);

			// Get the modulus.
			// The modulus starts at the twenty-first byte of the PUBLICKEYBLOB structure,
			// and is BitLength/8 bytes in length.
         
			byte[] Modulus = new byte[BitLength / 8];
			Marshal.Copy((IntPtr)(pPublicKeyBlob.ToInt32() + 20), Modulus, 0, BitLength / 8);
			Array.Reverse(Modulus);
         
			// Reverse the byte order.
			// Put the modulus and the exponent into an RSAParameters object.
         
			RSAParameters rsaparms = new RSAParameters();
			rsaparms.Exponent = Exponent;
			rsaparms.Modulus = Modulus;
         
			// Import the modulus and the exponent into an RSACryptoServiceProvider object
			// by using the RSAParameters object.
         
			rsacsp = new RSACryptoServiceProvider();
			rsacsp.ImportParameters(rsaparms);
			Cleanup:
				if (pCertContext != IntPtr.Zero)
					Crypt32.CertFreeCertificateContext(pCertContext.ToInt32());
			if (hProv != 0)
				Crypt32.CryptReleaseContext(hProv, 0);
			if (pPublicKeyBlob != IntPtr.Zero)
				Marshal.FreeHGlobal(pPublicKeyBlob);
			return rsacsp;
		}




		public class Crypt32
		{
			[DllImport("Crypt32.dll", CharSet=CharSet.Auto)]
			internal extern static uint CertOpenSystemStore(int hprov, string szSubsystemProtocol);
			[DllImport("Crypt32.dll", CharSet=CharSet.Auto)]
			internal extern static uint CertEnumCertificatesInStore(uint hCertStore, uint pPrevCertContext);
			[DllImport("Crypt32.dll", CharSet=CharSet.Auto)]
			internal extern static uint CertDuplicateCertificateContext(uint pPrevCertContext);
			[DllImport("Crypt32.dll", CharSet=CharSet.Auto,SetLastError=true)]
			[return : MarshalAs(UnmanagedType.Bool)]
			internal extern static bool CertGetCertificateContextProperty(int pCertContext,int dwPropId,
				IntPtr pvData, ref uint pcbData);
			[DllImport("Crypt32.dll", CharSet=CharSet.Auto)]
			internal extern static uint CertCreateCertificateContext(uint dwCertEncodingType,
				[MarshalAs(UnmanagedType.LPArray)]byte[] pbCertEncoded, int cbCertEncoded);
			[DllImport("Advapi32.dll", CharSet=CharSet.Auto,SetLastError=true)]
			[return : MarshalAs(UnmanagedType.Bool)]
			internal extern static bool CryptAcquireContext(ref uint phProv,string pszContainer,
				string pszProvider,uint dwProvType,uint dwFlags);
			[DllImport("Crypt32.dll", CharSet=CharSet.Auto,SetLastError=true)]
			[return : MarshalAs(UnmanagedType.Bool)]
			internal extern static bool CryptImportPublicKeyInfoEx(uint hCryptProv ,uint dwCertEncodingType, 
				IntPtr pInfo, uint aiKeyAlg, uint dwFlags ,uint pvAuxInfo, ref uint phKey); 
			[DllImport("Crypt32.dll", CharSet=CharSet.Auto,SetLastError=true)]
			[return : MarshalAs(UnmanagedType.Bool)]
			internal extern static bool CryptImportPublicKeyInfo(uint hCryptProv ,uint dwCertEncodingType, 
				IntPtr pInfo, ref uint phKey); 
			[DllImport("Advapi32.dll", CharSet=CharSet.Auto,SetLastError=true)]
			[return : MarshalAs(UnmanagedType.Bool)]
			internal extern static bool CryptExportKey(uint hKey,uint hExpKey, uint dwBlobType, 
				uint dwFlags ,uint pbData, ref uint pdwDataLen);
			[DllImport("Crypt32.dll", CharSet=CharSet.Auto,SetLastError=true)]
			[return : MarshalAs(UnmanagedType.Bool)]
			internal extern static bool CertFreeCertificateContext(int pCertContext);
			[DllImport("Advapi32.dll", CharSet=CharSet.Auto,SetLastError=true)]
			[return : MarshalAs(UnmanagedType.Bool)]
			internal extern static bool CryptReleaseContext(uint hProv, uint dwFlags);
		}

		#endregion 



		

	}
}

