using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.VirtualServer.Interop;
using System.Resources;
using System.Xml;
using System.Xml.XPath;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;



namespace VSPlus
{

	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	/// 

	public class frmMain : System.Windows.Forms.Form
	{
		
		// Initialize COM with Impersonate first

		private System.Windows.Forms.ToolBarButton tbbCapScr;
		private System.Windows.Forms.ToolBarButton tbbFullScreen;
		private System.Windows.Forms.MenuItem mnuFullScr;
		private System.Windows.Forms.MenuItem mnuInsAddition;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.ToolBarButton tbbSep3;
		private System.Windows.Forms.ToolTip VMProperty;
		private System.Windows.Forms.MenuItem mnuCheckUpdate;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem mnuWeb;
		private System.Windows.Forms.MenuItem mnuForum;
		private System.Windows.Forms.MenuItem mnuLoadConfig;
		private System.Windows.Forms.OpenFileDialog ofdMain;
		private System.Windows.Forms.SaveFileDialog sfdMain;
		private System.Windows.Forms.MenuItem mnuSettings;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mnuLanguage;
		private System.Windows.Forms.MenuItem mnuFile;
		private System.Windows.Forms.MenuItem mnuExit;
		private System.Windows.Forms.MenuItem mnuHelp;
		private System.Windows.Forms.MenuItem mnuAbout;
		private System.Windows.Forms.StatusBar sbrMain;
		private System.Windows.Forms.MainMenu mnuMain;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBarButton tbbAdd;
		private System.Windows.Forms.ToolBarButton tbbStart;
		private System.Windows.Forms.ToolBarButton tbbStop;
		private System.Windows.Forms.ToolBarButton tbbPause;
		private System.Windows.Forms.ToolBarButton tbbReset;
		private System.Windows.Forms.ToolBar tbarMain;
		private System.Windows.Forms.ToolBarButton tbbRemove;
		public System.Windows.Forms.TabControl tabMain;
		private System.Windows.Forms.MenuItem mnuVSCreateVM;
		private System.Windows.Forms.MenuItem mnuVSRemoveVM;
		private System.Windows.Forms.MenuItem mnuVSProperties;
		private System.Windows.Forms.MenuItem mnuVMStart;
		private System.Windows.Forms.MenuItem mnuVMStop;
		private System.Windows.Forms.MenuItem mnuVMPause;
		private System.Windows.Forms.MenuItem mnuVMReset;
		private System.Windows.Forms.MenuItem mnuVMProperties;
		private System.Windows.Forms.ToolBarButton tbbShutdown;
		private System.Windows.Forms.StatusBarPanel sbpState;
		private System.Windows.Forms.StatusBarPanel sbpUptime;
		private System.Windows.Forms.StatusBarPanel sbpCPU;
		private System.Windows.Forms.StatusBarPanel sbpDiskIO;
		private System.Windows.Forms.StatusBarPanel sbpNetIO;
		private System.Windows.Forms.Timer tmrStatusbar;
		private System.Windows.Forms.StatusBarPanel sbpRes;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ToolBarButton tbbSep1;
		private System.Windows.Forms.ToolBarButton tbbSep2;
		private System.Windows.Forms.ToolBarButton tbbViewOnly;
		private System.Windows.Forms.ToolBarButton tbbSetHostKey;
		private System.Windows.Forms.ToolBarButton tbbCADKey;
		private System.Windows.Forms.ToolBarButton tbbPrintScr;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem mnuVSHostKey;
		private System.Windows.Forms.MenuItem mnuVMCADKey;
		private System.Windows.Forms.MenuItem mnuVMPrtScr;
		private System.Windows.Forms.MenuItem mnuVMConnProp;
		private System.Windows.Forms.MenuItem mnuAddVM;
		private System.Windows.Forms.MenuItem mnuRemoveVSPlus;
		private System.Windows.Forms.MenuItem mnuAddVSPlus;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem mnuVS;
		private System.Windows.Forms.MenuItem mnuVM;
		private System.Windows.Forms.MenuItem mnuVD;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem mnuVMShutdown;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem mnuCapScr;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MenuItem mnuBrowseVMFolder;
		private System.Windows.Forms.MenuItem mnuSaveAs;
		private System.Windows.Forms.MenuItem mnuSave;
		private System.Windows.Forms.MenuItem mnuENG;
		private System.Windows.Forms.MenuItem mnuCHS;
		private System.Windows.Forms.MenuItem mnuCHT;
		private AxVMRCClientControlLib.AxVMRCClientControl myVMRC;
		private System.Windows.Forms.ToolBarButton tbbVMProp;
		private System.Windows.Forms.ToolBarButton tbbVMSave;
		private System.Windows.Forms.MenuItem mnuVMSave;
		private System.Windows.Forms.MenuItem mnuVMDiscardSaved;
		private System.Windows.Forms.MenuItem mnuVMMergeUndo;
		private System.Windows.Forms.MenuItem mnuVMDiscardUndo;
		private System.Windows.Forms.DataGrid dgVSView;
		private System.Windows.Forms.ContextMenu cxmVSView;
		private System.Windows.Forms.ToolBarButton tbbOpen;
		private System.Windows.Forms.ToolBarButton tbbSave;

		// Initialize Global Configuration Varibles
		public static InitVS myApp = new InitVS();

		// Keep config.xml in memory
		public static XmlDocument xmlConfig = new XmlDocument();
		private System.Windows.Forms.MenuItem mnuAttachISO;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem mnuDupVM;
		private System.Windows.Forms.MenuItem mnuRemoveFromVS;
		private System.Windows.Forms.MenuItem mnuAddVMView;
		private System.Windows.Forms.MenuItem mnuVSStopAllVM;
		private System.Windows.Forms.MenuItem mnuVSSaveAllVM;
		private System.Windows.Forms.MenuItem mnuVSPauseAllVM;
		private System.Windows.Forms.MenuItem mnuVSShutdownAllVM;
		private System.Windows.Forms.MenuItem mnuVSStartAllVM;
		private System.Windows.Forms.MenuItem mnuVSResetAllVM;
		private System.Windows.Forms.MenuItem mnuVSSep;
		private System.Windows.Forms.MenuItem mnuVSRestoreAllVM;
		private System.Windows.Forms.MenuItem mnuReportBug;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem9;

		// Application Configuration Object
		public static AppConfig conf = new AppConfig();
        

		public frmMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
			this.mnuMain = new System.Windows.Forms.MainMenu();
			this.mnuFile = new System.Windows.Forms.MenuItem();
			this.mnuAddVSPlus = new System.Windows.Forms.MenuItem();
			this.mnuRemoveVSPlus = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.mnuSave = new System.Windows.Forms.MenuItem();
			this.mnuSaveAs = new System.Windows.Forms.MenuItem();
			this.mnuLoadConfig = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.mnuLanguage = new System.Windows.Forms.MenuItem();
			this.mnuENG = new System.Windows.Forms.MenuItem();
			this.mnuCHS = new System.Windows.Forms.MenuItem();
			this.mnuCHT = new System.Windows.Forms.MenuItem();
			this.mnuSettings = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuExit = new System.Windows.Forms.MenuItem();
			this.mnuVS = new System.Windows.Forms.MenuItem();
			this.mnuVSCreateVM = new System.Windows.Forms.MenuItem();
			this.mnuAddVM = new System.Windows.Forms.MenuItem();
			this.mnuVSRemoveVM = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.mnuVSStartAllVM = new System.Windows.Forms.MenuItem();
			this.mnuVSShutdownAllVM = new System.Windows.Forms.MenuItem();
			this.mnuVSPauseAllVM = new System.Windows.Forms.MenuItem();
			this.mnuVSRestoreAllVM = new System.Windows.Forms.MenuItem();
			this.mnuVSSaveAllVM = new System.Windows.Forms.MenuItem();
			this.mnuVSStopAllVM = new System.Windows.Forms.MenuItem();
			this.mnuVSResetAllVM = new System.Windows.Forms.MenuItem();
			this.mnuVSSep = new System.Windows.Forms.MenuItem();
			this.mnuVSProperties = new System.Windows.Forms.MenuItem();
			this.mnuVSHostKey = new System.Windows.Forms.MenuItem();
			this.mnuVM = new System.Windows.Forms.MenuItem();
			this.mnuVMStart = new System.Windows.Forms.MenuItem();
			this.mnuVMStop = new System.Windows.Forms.MenuItem();
			this.mnuVMSave = new System.Windows.Forms.MenuItem();
			this.mnuVMDiscardSaved = new System.Windows.Forms.MenuItem();
			this.mnuVMMergeUndo = new System.Windows.Forms.MenuItem();
			this.mnuVMDiscardUndo = new System.Windows.Forms.MenuItem();
			this.mnuVMPause = new System.Windows.Forms.MenuItem();
			this.mnuVMReset = new System.Windows.Forms.MenuItem();
			this.mnuVMShutdown = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.mnuVMPrtScr = new System.Windows.Forms.MenuItem();
			this.mnuVMCADKey = new System.Windows.Forms.MenuItem();
			this.mnuCapScr = new System.Windows.Forms.MenuItem();
			this.mnuFullScr = new System.Windows.Forms.MenuItem();
			this.mnuAttachISO = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.mnuVMProperties = new System.Windows.Forms.MenuItem();
			this.mnuVMConnProp = new System.Windows.Forms.MenuItem();
			this.mnuInsAddition = new System.Windows.Forms.MenuItem();
			this.mnuBrowseVMFolder = new System.Windows.Forms.MenuItem();
			this.mnuDupVM = new System.Windows.Forms.MenuItem();
			this.mnuRemoveFromVS = new System.Windows.Forms.MenuItem();
			this.mnuAddVMView = new System.Windows.Forms.MenuItem();
			this.mnuVD = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.mnuHelp = new System.Windows.Forms.MenuItem();
			this.mnuWeb = new System.Windows.Forms.MenuItem();
			this.mnuForum = new System.Windows.Forms.MenuItem();
			this.mnuCheckUpdate = new System.Windows.Forms.MenuItem();
			this.mnuReportBug = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.mnuAbout = new System.Windows.Forms.MenuItem();
			this.sbrMain = new System.Windows.Forms.StatusBar();
			this.sbpState = new System.Windows.Forms.StatusBarPanel();
			this.sbpUptime = new System.Windows.Forms.StatusBarPanel();
			this.sbpCPU = new System.Windows.Forms.StatusBarPanel();
			this.sbpDiskIO = new System.Windows.Forms.StatusBarPanel();
			this.sbpNetIO = new System.Windows.Forms.StatusBarPanel();
			this.sbpRes = new System.Windows.Forms.StatusBarPanel();
			this.tbarMain = new System.Windows.Forms.ToolBar();
			this.tbbAdd = new System.Windows.Forms.ToolBarButton();
			this.tbbRemove = new System.Windows.Forms.ToolBarButton();
			this.tbbOpen = new System.Windows.Forms.ToolBarButton();
			this.tbbSave = new System.Windows.Forms.ToolBarButton();
			this.tbbSep1 = new System.Windows.Forms.ToolBarButton();
			this.tbbStart = new System.Windows.Forms.ToolBarButton();
			this.tbbStop = new System.Windows.Forms.ToolBarButton();
			this.tbbVMSave = new System.Windows.Forms.ToolBarButton();
			this.tbbPause = new System.Windows.Forms.ToolBarButton();
			this.tbbReset = new System.Windows.Forms.ToolBarButton();
			this.tbbShutdown = new System.Windows.Forms.ToolBarButton();
			this.tbbSep2 = new System.Windows.Forms.ToolBarButton();
			this.tbbVMProp = new System.Windows.Forms.ToolBarButton();
			this.tbbViewOnly = new System.Windows.Forms.ToolBarButton();
			this.tbbCADKey = new System.Windows.Forms.ToolBarButton();
			this.tbbFullScreen = new System.Windows.Forms.ToolBarButton();
			this.tbbPrintScr = new System.Windows.Forms.ToolBarButton();
			this.tbbCapScr = new System.Windows.Forms.ToolBarButton();
			this.tbbSetHostKey = new System.Windows.Forms.ToolBarButton();
			this.tbbSep3 = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.tabMain = new System.Windows.Forms.TabControl();
			this.tmrStatusbar = new System.Windows.Forms.Timer(this.components);
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.VMProperty = new System.Windows.Forms.ToolTip(this.components);
			this.ofdMain = new System.Windows.Forms.OpenFileDialog();
			this.sfdMain = new System.Windows.Forms.SaveFileDialog();
			this.myVMRC = new AxVMRCClientControlLib.AxVMRCClientControl();
			this.dgVSView = new System.Windows.Forms.DataGrid();
			this.cxmVSView = new System.Windows.Forms.ContextMenu();
			((System.ComponentModel.ISupportInitialize)(this.sbpState)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpUptime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpCPU)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpDiskIO)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpNetIO)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpRes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.myVMRC)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgVSView)).BeginInit();
			this.SuspendLayout();
			// 
			// mnuMain
			// 
			this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuFile,
																					this.mnuVS,
																					this.mnuVM,
																					this.mnuVD,
																					this.mnuHelp});
			// 
			// mnuFile
			// 
			this.mnuFile.Index = 0;
			this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuAddVSPlus,
																					this.mnuRemoveVSPlus,
																					this.menuItem8,
																					this.mnuSave,
																					this.mnuSaveAs,
																					this.mnuLoadConfig,
																					this.menuItem3,
																					this.mnuLanguage,
																					this.mnuSettings,
																					this.menuItem9,
																					this.menuItem1,
																					this.mnuExit});
			this.mnuFile.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
			this.mnuFile.Text = "&File";
			// 
			// mnuAddVSPlus
			// 
			this.mnuAddVSPlus.Index = 0;
			this.mnuAddVSPlus.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
			this.mnuAddVSPlus.Text = "&Connect VM ";
			this.mnuAddVSPlus.Click += new System.EventHandler(this.mnuAddVSPlus_Click);
			// 
			// mnuRemoveVSPlus
			// 
			this.mnuRemoveVSPlus.Index = 1;
			this.mnuRemoveVSPlus.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
			this.mnuRemoveVSPlus.Text = "&Disconnect VM";
			this.mnuRemoveVSPlus.Click += new System.EventHandler(this.mnuRemoveVSPlus_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 2;
			this.menuItem8.Text = "-";
			// 
			// mnuSave
			// 
			this.mnuSave.Index = 3;
			this.mnuSave.Text = "Save";
			this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
			// 
			// mnuSaveAs
			// 
			this.mnuSaveAs.Index = 4;
			this.mnuSaveAs.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
			this.mnuSaveAs.Text = "Save &As...";
			this.mnuSaveAs.Click += new System.EventHandler(this.mnuSaveAS_Click);
			// 
			// mnuLoadConfig
			// 
			this.mnuLoadConfig.Index = 5;
			this.mnuLoadConfig.Shortcut = System.Windows.Forms.Shortcut.CtrlL;
			this.mnuLoadConfig.Text = "&Load ...";
			this.mnuLoadConfig.Click += new System.EventHandler(this.mnuLoadConfig_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 6;
			this.menuItem3.Text = "Config Editor...";
			this.menuItem3.Visible = false;
			// 
			// mnuLanguage
			// 
			this.mnuLanguage.Index = 7;
			this.mnuLanguage.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.mnuENG,
																						this.mnuCHS,
																						this.mnuCHT});
			this.mnuLanguage.Text = "Language";
			this.mnuLanguage.Visible = false;
			// 
			// mnuENG
			// 
			this.mnuENG.Checked = true;
			this.mnuENG.Index = 0;
			this.mnuENG.Text = "English";
			// 
			// mnuCHS
			// 
			this.mnuCHS.Index = 1;
			this.mnuCHS.Text = "Simplified Chinese";
			// 
			// mnuCHT
			// 
			this.mnuCHT.Index = 2;
			this.mnuCHT.Text = "Triditional Chinese";
			// 
			// mnuSettings
			// 
			this.mnuSettings.Index = 8;
			this.mnuSettings.Text = "Settings...";
			this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 9;
			this.menuItem9.Text = "Settings Grid...";
			this.menuItem9.Visible = false;
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 10;
			this.menuItem1.Text = "-";
			// 
			// mnuExit
			// 
			this.mnuExit.Index = 11;
			this.mnuExit.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
			this.mnuExit.Text = "E&xit";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// mnuVS
			// 
			this.mnuVS.Index = 1;
			this.mnuVS.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				  this.mnuVSCreateVM,
																				  this.mnuAddVM,
																				  this.mnuVSRemoveVM,
																				  this.menuItem4,
																				  this.mnuVSStartAllVM,
																				  this.mnuVSShutdownAllVM,
																				  this.mnuVSPauseAllVM,
																				  this.mnuVSRestoreAllVM,
																				  this.mnuVSSaveAllVM,
																				  this.mnuVSStopAllVM,
																				  this.mnuVSResetAllVM,
																				  this.mnuVSSep,
																				  this.mnuVSProperties,
																				  this.mnuVSHostKey});
			this.mnuVS.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.mnuVS.Text = "&Server";
			// 
			// mnuVSCreateVM
			// 
			this.mnuVSCreateVM.Index = 0;
			this.mnuVSCreateVM.Text = "Create VM";
			this.mnuVSCreateVM.Click += new System.EventHandler(this.mnuVSCreateVM_Click);
			// 
			// mnuAddVM
			// 
			this.mnuAddVM.Index = 1;
			this.mnuAddVM.Text = "Add VM";
			this.mnuAddVM.Click += new System.EventHandler(this.mnuAddVM_Click);
			// 
			// mnuVSRemoveVM
			// 
			this.mnuVSRemoveVM.Index = 2;
			this.mnuVSRemoveVM.Text = "Remove VM";
			this.mnuVSRemoveVM.Click += new System.EventHandler(this.mnuVSRemoveVM_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 3;
			this.menuItem4.Text = "-";
			// 
			// mnuVSStartAllVM
			// 
			this.mnuVSStartAllVM.Index = 4;
			this.mnuVSStartAllVM.Text = "Start All VM";
			this.mnuVSStartAllVM.Visible = false;
			this.mnuVSStartAllVM.Click += new System.EventHandler(this.mnuVSStartAllVM_Click);
			// 
			// mnuVSShutdownAllVM
			// 
			this.mnuVSShutdownAllVM.Index = 5;
			this.mnuVSShutdownAllVM.Text = "Shutdown All VM";
			this.mnuVSShutdownAllVM.Visible = false;
			this.mnuVSShutdownAllVM.Click += new System.EventHandler(this.mnuVSShutdownAllVM_Click);
			// 
			// mnuVSPauseAllVM
			// 
			this.mnuVSPauseAllVM.Index = 6;
			this.mnuVSPauseAllVM.Text = "Pause All VM";
			this.mnuVSPauseAllVM.Visible = false;
			this.mnuVSPauseAllVM.Click += new System.EventHandler(this.mnuVSPauseAllVM_Click);
			// 
			// mnuVSRestoreAllVM
			// 
			this.mnuVSRestoreAllVM.Index = 7;
			this.mnuVSRestoreAllVM.Text = "Restore All VM";
			this.mnuVSRestoreAllVM.Visible = false;
			this.mnuVSRestoreAllVM.Click += new System.EventHandler(this.mnuVSRestoreAllVM_Click);
			// 
			// mnuVSSaveAllVM
			// 
			this.mnuVSSaveAllVM.Index = 8;
			this.mnuVSSaveAllVM.Text = "Save All VM";
			this.mnuVSSaveAllVM.Visible = false;
			// 
			// mnuVSStopAllVM
			// 
			this.mnuVSStopAllVM.Index = 9;
			this.mnuVSStopAllVM.Text = "Stop All VM";
			this.mnuVSStopAllVM.Visible = false;
			this.mnuVSStopAllVM.Click += new System.EventHandler(this.mnuVSStopAllVM_Click);
			// 
			// mnuVSResetAllVM
			// 
			this.mnuVSResetAllVM.Index = 10;
			this.mnuVSResetAllVM.Text = "Reset All VM";
			this.mnuVSResetAllVM.Visible = false;
			this.mnuVSResetAllVM.Click += new System.EventHandler(this.mnuVSResetAllVM_Click);
			// 
			// mnuVSSep
			// 
			this.mnuVSSep.Index = 11;
			this.mnuVSSep.Text = "-";
			this.mnuVSSep.Visible = false;
			// 
			// mnuVSProperties
			// 
			this.mnuVSProperties.Index = 12;
			this.mnuVSProperties.Text = "VS &Properties";
			this.mnuVSProperties.Click += new System.EventHandler(this.mnuVSProperties_Click);
			// 
			// mnuVSHostKey
			// 
			this.mnuVSHostKey.Index = 13;
			this.mnuVSHostKey.Text = "Set Host Key";
			this.mnuVSHostKey.Click += new System.EventHandler(this.mnuVSHostKey_Click);
			// 
			// mnuVM
			// 
			this.mnuVM.Enabled = false;
			this.mnuVM.Index = 2;
			this.mnuVM.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				  this.mnuVMStart,
																				  this.mnuVMStop,
																				  this.mnuVMSave,
																				  this.mnuVMDiscardSaved,
																				  this.mnuVMMergeUndo,
																				  this.mnuVMDiscardUndo,
																				  this.mnuVMPause,
																				  this.mnuVMReset,
																				  this.mnuVMShutdown,
																				  this.menuItem5,
																				  this.mnuVMPrtScr,
																				  this.mnuVMCADKey,
																				  this.mnuCapScr,
																				  this.mnuFullScr,
																				  this.mnuAttachISO,
																				  this.menuItem6,
																				  this.mnuVMProperties,
																				  this.mnuVMConnProp,
																				  this.mnuInsAddition,
																				  this.mnuBrowseVMFolder,
																				  this.mnuDupVM,
																				  this.mnuRemoveFromVS,
																				  this.mnuAddVMView});
			this.mnuVM.Shortcut = System.Windows.Forms.Shortcut.CtrlM;
			this.mnuVM.Text = "V&M";
			// 
			// mnuVMStart
			// 
			this.mnuVMStart.Index = 0;
			this.mnuVMStart.Text = "Start";
			this.mnuVMStart.Click += new System.EventHandler(this.mnuVMStart_Click);
			// 
			// mnuVMStop
			// 
			this.mnuVMStop.Index = 1;
			this.mnuVMStop.Text = "Stop";
			this.mnuVMStop.Click += new System.EventHandler(this.mnuVMStop_Click);
			// 
			// mnuVMSave
			// 
			this.mnuVMSave.Index = 2;
			this.mnuVMSave.Text = "Save";
			this.mnuVMSave.Click += new System.EventHandler(this.mnuVMSave_Click);
			// 
			// mnuVMDiscardSaved
			// 
			this.mnuVMDiscardSaved.Index = 3;
			this.mnuVMDiscardSaved.Text = "Discard Saved State";
			this.mnuVMDiscardSaved.Visible = false;
			this.mnuVMDiscardSaved.Click += new System.EventHandler(this.mnuVMDiscardSaved_Click);
			// 
			// mnuVMMergeUndo
			// 
			this.mnuVMMergeUndo.Index = 4;
			this.mnuVMMergeUndo.Text = "Merge Undo Disks";
			this.mnuVMMergeUndo.Visible = false;
			this.mnuVMMergeUndo.Click += new System.EventHandler(this.mnuVMMergeUndo_Click);
			// 
			// mnuVMDiscardUndo
			// 
			this.mnuVMDiscardUndo.Index = 5;
			this.mnuVMDiscardUndo.Text = "Discard Undo Disks";
			this.mnuVMDiscardUndo.Visible = false;
			this.mnuVMDiscardUndo.Click += new System.EventHandler(this.mnuVMDiscardUndo_Click);
			// 
			// mnuVMPause
			// 
			this.mnuVMPause.Index = 6;
			this.mnuVMPause.Text = "Pause";
			this.mnuVMPause.Click += new System.EventHandler(this.mnuVMPause_Click);
			// 
			// mnuVMReset
			// 
			this.mnuVMReset.Index = 7;
			this.mnuVMReset.Text = "Reset";
			this.mnuVMReset.Click += new System.EventHandler(this.mnuVMReset_Click);
			// 
			// mnuVMShutdown
			// 
			this.mnuVMShutdown.Index = 8;
			this.mnuVMShutdown.Text = "Shutdown";
			this.mnuVMShutdown.Click += new System.EventHandler(this.mnuVMShutdown_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 9;
			this.menuItem5.Text = "-";
			// 
			// mnuVMPrtScr
			// 
			this.mnuVMPrtScr.Index = 10;
			this.mnuVMPrtScr.Text = "Send PrintScreen";
			this.mnuVMPrtScr.Click += new System.EventHandler(this.mnuVMPrtScr_Click);
			// 
			// mnuVMCADKey
			// 
			this.mnuVMCADKey.Index = 11;
			this.mnuVMCADKey.Text = "Send Ctrl-Alt-Del";
			this.mnuVMCADKey.Click += new System.EventHandler(this.mnuVMCADKey_Click);
			// 
			// mnuCapScr
			// 
			this.mnuCapScr.Index = 12;
			this.mnuCapScr.Text = "Capture Screen";
			this.mnuCapScr.Click += new System.EventHandler(this.mnuCapScr_Click);
			// 
			// mnuFullScr
			// 
			this.mnuFullScr.Index = 13;
			this.mnuFullScr.Text = "Full Screen Mode";
			this.mnuFullScr.Click += new System.EventHandler(this.mnuFullScr_Click);
			// 
			// mnuAttachISO
			// 
			this.mnuAttachISO.Index = 14;
			this.mnuAttachISO.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem2});
			this.mnuAttachISO.Text = "Attach ISO";
			this.mnuAttachISO.Click += new System.EventHandler(this.mnuAttachISO_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "-";
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 15;
			this.menuItem6.Text = "-";
			// 
			// mnuVMProperties
			// 
			this.mnuVMProperties.Index = 16;
			this.mnuVMProperties.Text = "VM Properties";
			this.mnuVMProperties.Click += new System.EventHandler(this.mnuVMProperties_Click);
			// 
			// mnuVMConnProp
			// 
			this.mnuVMConnProp.Index = 17;
			this.mnuVMConnProp.Text = "Connection Properties";
			this.mnuVMConnProp.Click += new System.EventHandler(this.mnuVMConnProp_Click);
			// 
			// mnuInsAddition
			// 
			this.mnuInsAddition.Index = 18;
			this.mnuInsAddition.Text = "Install Additions";
			this.mnuInsAddition.Click += new System.EventHandler(this.mnuInsAddition_Click);
			// 
			// mnuBrowseVMFolder
			// 
			this.mnuBrowseVMFolder.Index = 19;
			this.mnuBrowseVMFolder.Text = "Browse VM Folder";
			this.mnuBrowseVMFolder.Click += new System.EventHandler(this.mnuBrowseVMFolder_Click);
			// 
			// mnuDupVM
			// 
			this.mnuDupVM.Index = 20;
			this.mnuDupVM.Text = "Duplicate VM";
			this.mnuDupVM.Click += new System.EventHandler(this.mnuDupVM_Click);
			// 
			// mnuRemoveFromVS
			// 
			this.mnuRemoveFromVS.Index = 21;
			this.mnuRemoveFromVS.Text = "Remove from VS";
			this.mnuRemoveFromVS.Click += new System.EventHandler(this.mnuRemoveFromVS_Click);
			// 
			// mnuAddVMView
			// 
			this.mnuAddVMView.Index = 22;
			this.mnuAddVMView.Text = "Add VM View";
			this.mnuAddVMView.Visible = false;
			// 
			// mnuVD
			// 
			this.mnuVD.Index = 3;
			this.mnuVD.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				  this.menuItem12,
																				  this.menuItem13});
			this.mnuVD.Text = "&Disk";
			this.mnuVD.Visible = false;
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 0;
			this.menuItem12.Text = "Create";
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 1;
			this.menuItem13.Text = "Inspect";
			// 
			// mnuHelp
			// 
			this.mnuHelp.Index = 4;
			this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuWeb,
																					this.mnuForum,
																					this.mnuCheckUpdate,
																					this.mnuReportBug,
																					this.menuItem7,
																					this.mnuAbout});
			this.mnuHelp.Shortcut = System.Windows.Forms.Shortcut.CtrlH;
			this.mnuHelp.Text = "&Help";
			// 
			// mnuWeb
			// 
			this.mnuWeb.Index = 0;
			this.mnuWeb.Text = "VSPlus on the Web";
			this.mnuWeb.Click += new System.EventHandler(this.mnuWeb_Click);
			// 
			// mnuForum
			// 
			this.mnuForum.Index = 1;
			this.mnuForum.Text = "VSPlus Forums";
			this.mnuForum.Click += new System.EventHandler(this.mnuForum_Click);
			// 
			// mnuCheckUpdate
			// 
			this.mnuCheckUpdate.Index = 2;
			this.mnuCheckUpdate.Text = "Check for Updates";
			this.mnuCheckUpdate.Click += new System.EventHandler(this.mnuCheckUpdate_Click);
			// 
			// mnuReportBug
			// 
			this.mnuReportBug.Index = 3;
			this.mnuReportBug.Text = "Report A Bug";
			this.mnuReportBug.Click += new System.EventHandler(this.mnuReportBug_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 4;
			this.menuItem7.Text = "-";
			// 
			// mnuAbout
			// 
			this.mnuAbout.Index = 5;
			this.mnuAbout.Text = "About VSPlus...";
			this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
			// 
			// sbrMain
			// 
			this.sbrMain.Location = new System.Drawing.Point(0, 523);
			this.sbrMain.Name = "sbrMain";
			this.sbrMain.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																					   this.sbpState,
																					   this.sbpUptime,
																					   this.sbpCPU,
																					   this.sbpDiskIO,
																					   this.sbpNetIO,
																					   this.sbpRes});
			this.sbrMain.Size = new System.Drawing.Size(792, 22);
			this.sbrMain.SizingGrip = false;
			this.sbrMain.TabIndex = 6;
			this.sbrMain.Text = "Ready";
			this.sbrMain.PanelClick += new System.Windows.Forms.StatusBarPanelClickEventHandler(this.sbrMain_PanelClick);
			// 
			// sbpState
			// 
			this.sbpState.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.Raised;
			this.sbpState.Text = "State: n/a";
			// 
			// sbpUptime
			// 
			this.sbpUptime.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.Raised;
			this.sbpUptime.Text = "Uptime: n/a sec";
			// 
			// sbpCPU
			// 
			this.sbpCPU.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.Raised;
			this.sbpCPU.Text = "CPU: n/a";
			// 
			// sbpDiskIO
			// 
			this.sbpDiskIO.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.Raised;
			this.sbpDiskIO.Text = "Disk: n/a";
			// 
			// sbpNetIO
			// 
			this.sbpNetIO.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.Raised;
			this.sbpNetIO.Text = "Network: n/a";
			// 
			// sbpRes
			// 
			this.sbpRes.Text = "Res: n/a";
			// 
			// tbarMain
			// 
			this.tbarMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.tbarMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbbAdd,
																						this.tbbRemove,
																						this.tbbOpen,
																						this.tbbSave,
																						this.tbbSep1,
																						this.tbbStart,
																						this.tbbStop,
																						this.tbbVMSave,
																						this.tbbPause,
																						this.tbbReset,
																						this.tbbShutdown,
																						this.tbbSep2,
																						this.tbbVMProp,
																						this.tbbViewOnly,
																						this.tbbCADKey,
																						this.tbbFullScreen,
																						this.tbbPrintScr,
																						this.tbbCapScr,
																						this.tbbSetHostKey,
																						this.tbbSep3});
			this.tbarMain.ButtonSize = new System.Drawing.Size(28, 28);
			this.tbarMain.DropDownArrows = true;
			this.tbarMain.ImageList = this.imageList1;
			this.tbarMain.Location = new System.Drawing.Point(0, 0);
			this.tbarMain.Name = "tbarMain";
			this.tbarMain.ShowToolTips = true;
			this.tbarMain.Size = new System.Drawing.Size(792, 31);
			this.tbarMain.TabIndex = 7;
			this.tbarMain.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbarMain_ButtonClick);
			// 
			// tbbAdd
			// 
			this.tbbAdd.ImageIndex = 5;
			this.tbbAdd.ToolTipText = "Add a VM";
			// 
			// tbbRemove
			// 
			this.tbbRemove.Enabled = false;
			this.tbbRemove.ImageIndex = 9;
			this.tbbRemove.ToolTipText = "Remove VM";
			// 
			// tbbOpen
			// 
			this.tbbOpen.ImageIndex = 16;
			this.tbbOpen.ToolTipText = "Open Configuration";
			// 
			// tbbSave
			// 
			this.tbbSave.ImageIndex = 17;
			this.tbbSave.ToolTipText = "Save Configuration";
			// 
			// tbbSep1
			// 
			this.tbbSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbStart
			// 
			this.tbbStart.Enabled = false;
			this.tbbStart.ImageIndex = 14;
			this.tbbStart.ToolTipText = "Start VM";
			// 
			// tbbStop
			// 
			this.tbbStop.Enabled = false;
			this.tbbStop.ImageIndex = 10;
			this.tbbStop.ToolTipText = "Stop VM";
			// 
			// tbbVMSave
			// 
			this.tbbVMSave.Enabled = false;
			this.tbbVMSave.ImageIndex = 18;
			this.tbbVMSave.ToolTipText = "Save VM";
			// 
			// tbbPause
			// 
			this.tbbPause.Enabled = false;
			this.tbbPause.ImageIndex = 6;
			this.tbbPause.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.tbbPause.ToolTipText = "Pause VM";
			// 
			// tbbReset
			// 
			this.tbbReset.Enabled = false;
			this.tbbReset.ImageIndex = 7;
			this.tbbReset.ToolTipText = "Reset VM";
			// 
			// tbbShutdown
			// 
			this.tbbShutdown.Enabled = false;
			this.tbbShutdown.ImageIndex = 1;
			this.tbbShutdown.ToolTipText = "Shutdown VM";
			// 
			// tbbSep2
			// 
			this.tbbSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbVMProp
			// 
			this.tbbVMProp.Enabled = false;
			this.tbbVMProp.ImageIndex = 3;
			this.tbbVMProp.ToolTipText = "VM Properties";
			// 
			// tbbViewOnly
			// 
			this.tbbViewOnly.Enabled = false;
			this.tbbViewOnly.ImageIndex = 4;
			this.tbbViewOnly.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.tbbViewOnly.ToolTipText = "View Only Mode";
			this.tbbViewOnly.Visible = false;
			// 
			// tbbCADKey
			// 
			this.tbbCADKey.Enabled = false;
			this.tbbCADKey.ImageIndex = 2;
			this.tbbCADKey.ToolTipText = "Send Ctrl-Alt-Del Key";
			// 
			// tbbFullScreen
			// 
			this.tbbFullScreen.Enabled = false;
			this.tbbFullScreen.ImageIndex = 15;
			this.tbbFullScreen.ToolTipText = "Full Screen Mode";
			// 
			// tbbPrintScr
			// 
			this.tbbPrintScr.Enabled = false;
			this.tbbPrintScr.ImageIndex = 12;
			this.tbbPrintScr.ToolTipText = "Send Print Screen";
			// 
			// tbbCapScr
			// 
			this.tbbCapScr.Enabled = false;
			this.tbbCapScr.ImageIndex = 13;
			this.tbbCapScr.ToolTipText = "Capture Screen";
			// 
			// tbbSetHostKey
			// 
			this.tbbSetHostKey.Enabled = false;
			this.tbbSetHostKey.ImageIndex = 11;
			this.tbbSetHostKey.ToolTipText = "Set Host Key";
			// 
			// tbbSep3
			// 
			this.tbbSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(19, 19);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// tabMain
			// 
			this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabMain.Location = new System.Drawing.Point(0, 31);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.ShowToolTips = true;
			this.tabMain.Size = new System.Drawing.Size(792, 492);
			this.tabMain.TabIndex = 9;
			this.tabMain.Click += new System.EventHandler(this.tabMain_Click);
			// 
			// tmrStatusbar
			// 
			this.tmrStatusbar.Interval = 2000;
			this.tmrStatusbar.Tick += new System.EventHandler(this.tmrStatusbar_Tick);
			// 
			// timer1
			// 
			this.timer1.Interval = 1;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// myVMRC
			// 
			this.myVMRC.Location = new System.Drawing.Point(96, 80);
			this.myVMRC.Name = "myVMRC";
			this.myVMRC.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("myVMRC.OcxState")));
			this.myVMRC.Size = new System.Drawing.Size(576, 376);
			this.myVMRC.TabIndex = 10;
			// 
			// dgVSView
			// 
			this.dgVSView.AllowSorting = false;
			this.dgVSView.ContextMenu = this.cxmVSView;
			this.dgVSView.DataMember = "";
			this.dgVSView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgVSView.Enabled = false;
			this.dgVSView.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgVSView.Location = new System.Drawing.Point(0, 0);
			this.dgVSView.Name = "dgVSView";
			this.dgVSView.Size = new System.Drawing.Size(792, 545);
			this.dgVSView.TabIndex = 11;
			this.dgVSView.Click += new System.EventHandler(this.dgVSView_Click);
			// 
			// cxmVSView
			// 
			this.cxmVSView.Popup += new System.EventHandler(this.cxmVSView_Popup);
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 545);
			this.Controls.Add(this.tabMain);
			this.Controls.Add(this.tbarMain);
			this.Controls.Add(this.sbrMain);
			this.Controls.Add(this.myVMRC);
			this.Controls.Add(this.dgVSView);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Menu = this.mnuMain;
			this.Name = "frmMain";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "VSPlus";
			this.Resize += new System.EventHandler(this.frmMain_Resize);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.sbpState)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpUptime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpCPU)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpDiskIO)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpNetIO)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpRes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.myVMRC)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgVSView)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}


		private void frmMain_Load(object sender, System.EventArgs e)
		{
			// Load all VMs in the default config.xml
			try
			{
				xmlConfig.Load(conf.CONFIGFILE);
			}
			catch
			{
				// If CONFIGFILE not found or invalid, Give a default one.
				DialogResult result;
				result = MessageBox.Show("Unable to load configuration file. \n\nClick Yes to load default configuration. \nClick No to quit.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
				if (result == DialogResult.No) 
				{
					Application.Exit();
					return;
				}
				else 
				{
					xmlConfig = Utility.InitXmlConfig();
				}
			}

			conf.UpdateAppConfig();
			

			XmlNodeList nodeList = xmlConfig.SelectNodes("//VirtualServer");	

			if (nodeList.Count >0) 
			{
				foreach (XmlNode xmlNode in nodeList) 
				{	
					if ( xmlNode.SelectSingleNode("ServerDisplayName").InnerText == "Virtual Server" )
					{
						addVSTab(xmlNode.SelectSingleNode("ServerAddress").InnerText);
					}
					else
					{
						addVMTab(xmlNode.SelectSingleNode("ServerAddress").InnerText , xmlNode.SelectSingleNode("ServerDisplayName").InnerText);
					}
				}

				// Touch the current tabpage.
				if (tabMain.TabPages.Count>0) 
				{
					timer1.Enabled  = true;
				}
			}
				
			myVMRC.MenuEnabled = false;
			// Reset to the configuration
			UpdateWindowTitle(false);


		}


		private void tbarMain_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{

			#region Method for Add button.
			if ( e.Button == tbbAdd )
			{
				mnuAddVSPlus_Click(this, new System.EventArgs());
			} 
			#endregion
	
			#region Method for Remove button.
			if ( e.Button == tbbRemove) 
			{
				mnuRemoveVSPlus_Click(this, new System.EventArgs());
			} 
			#endregion

			#region Method for Open button.
			if ( e.Button == tbbOpen) 
			{
				mnuLoadConfig_Click(this, new System.EventArgs());
			} 
			#endregion

			#region Method for Save button.
			if ( e.Button == tbbSave) 
			{
				mnuSave_Click(this, new System.EventArgs());
			} 
			#endregion


			#region Method for Pause button.
			if ( e.Button == tbbPause  )
			{
				mnuVMPause_Click(this, new System.EventArgs());
			} 
			#endregion

			#region Method for Reset button.
			if ( e.Button == tbbReset  )
			{
				mnuVMReset_Click(this, new System.EventArgs());
			} 
			#endregion

			#region Method for Start button.
			if ( e.Button == tbbStart )
			{
				mnuVMStart_Click(this, new System.EventArgs());
			}
			#endregion

			#region Method for Stop button.
			if ( e.Button == tbbStop )
			{
				mnuVMStop_Click(this, new System.EventArgs());
			}
			#endregion

			#region Method for Save button.
			if ( e.Button == tbbVMSave ) 
			{
				mnuVMSave_Click(this, new System.EventArgs());
			} 
			#endregion

			#region Method for Shutdown button.
			if ( e.Button == tbbShutdown  )
			{
				mnuVMShutdown_Click(this, new System.EventArgs());
			}
			#endregion

			#region Method for VM Properties button
			if ( e.Button == tbbVMProp )
			{
				mnuVMProperties_Click(this, new System.EventArgs());
			}
			#endregion

			#region Method for View Only button
			if ( e.Button == tbbViewOnly )
			{
//				if (tbbViewOnly.Pushed)  
//				{
//					myVMRC.ViewOnlyMode = true;
//				}
//				else 
//				{
//					myVMRC.ViewOnlyMode = false;
//				}
				
			}
			#endregion

			#region Method for Set Hot key button
			if ( e.Button == tbbSetHostKey )
			{
				mnuVSHostKey_Click(this, new System.EventArgs());
			}
			#endregion

			#region Method for Send key sequence button
			if ( e.Button == tbbCADKey )
			{	
				mnuVMCADKey_Click(this, new System.EventArgs());
			}
			#endregion

			#region Method for Print Screen button
			if ( e.Button == tbbPrintScr  )
			{	
				mnuVMPrtScr_Click(this, new System.EventArgs());
			}
			#endregion

			#region Method for Capture Screen
			if ( e.Button == tbbCapScr  )
			{	
				mnuCapScr_Click(this, new System.EventArgs());
			}
			#endregion

			#region Method for Full Screen
			if ( e.Button == tbbFullScreen  )
			{	
				mnuFullScr_Click(this, new System.EventArgs());
			}
			#endregion

		}

		private void tabMain_Click(object sender, System.EventArgs e)
		{	
			// Debug: // May have problems.
			sbrMain.Text = "Ready";
			sbrMain.ShowPanels = false;
			if (tabMain.TabCount == 0) return;

			// Read last TabIndex fromXml
			XmlNodeList nodeList = xmlConfig.SelectNodes("//VirtualServer");

			// Find this node from config.xml. This step is necessary if config.xml was updated by another program.
			bool vmFound = false;
			foreach (XmlNode xmlNode in nodeList) 
			{	
				if (  int.Parse(xmlNode.SelectSingleNode("TabIndex").InnerText) == tabMain.SelectedIndex) 
				{
					conf.currentVS   = xmlNode.SelectSingleNode("ServerAddress").InnerText ;
					conf.currentVMRCPort  = int.Parse(xmlNode.SelectSingleNode("ServerPort").InnerText );
					conf.currentVM = xmlNode.SelectSingleNode("ServerDisplayName").InnerText ;
					conf.vs = Utility.getVS(conf.currentVS);
					conf.vm = Utility.getVM(conf.vs, conf.currentVM);


					myVMRC.ServerAddress = conf.currentVS;
					myVMRC.ServerPort = conf.currentVMRCPort;
					myVMRC.ServerDisplayName = conf.currentVM;

					if (xmlNode.SelectSingleNode("ViewOnlyMode").InnerText  == "true")  
					{
						myVMRC.ViewOnlyMode = true;
					}
					else 
					{
						myVMRC.ViewOnlyMode = false;
					}
					
					vmFound = true;
					break;
				} 
			}

			if (conf.currentVM =="Virtual Server") 
			{	// This is a VS view

				// Adjust Window size
				this.ClientSize = new System.Drawing.Size(800, 600);

				dgVSView  = Utility.getVSViewGrid(conf.vs, dgVSView);	
				tabMain.SelectedTab.Controls.Add(dgVSView);
				dgVSView_Click(this, new System.EventArgs());

				// Update Status bar
				setStatusbar(conf.currentVS, conf.currentVM);

				// Update the VS View status
				tmrStatusbar.Enabled = true;


			}
			else 
			{	// This is a VM view

				// Delete this tab and return if the xml does not match or VM doesn't exist
				VMVirtualMachine vm = conf.vm;
				if ( !vmFound || vm==null) 
				{
					MessageBox.Show( "Unable to connect VM. It may be removed from the configuration file or the virtual server. This tab will be removed." );
					RemoveFromConfigFile(conf.currentVS, conf.currentVM);
					removeTab( tabMain.SelectedIndex );
					UpdateWindowTitle(true);
					return;
				}

				if (myVMRC.ViewOnlyMode) 
				{
					tbbViewOnly.Pushed = true;
				}
				else
				{
					tbbViewOnly.Pushed = false;
				}

				switch (vm.State) 
				{
					case VMVMState.vmVMState_Paused:
						tabMain.SelectedTab.Controls.Remove(myVMRC);
						UpdateMenuToolBarStatus(vm, VMVMState.vmVMState_Paused);
						break;
					case VMVMState.vmVMState_Invalid:
						// Touch the Timer for Statusbar, make sure it's there.
						// This timer will be turned off when there is no tab
						tmrStatusbar.Enabled = false;

						// IF it's off, disable STOP/PAUSE/RESET/CAD/Shutdown/PrtScr, enable START
						tabMain.SelectedTab.Controls.Remove(myVMRC);
						this.ClientSize = new System.Drawing.Size(800, 600);
						sbrMain.ShowPanels = false;
						UpdateMenuToolBarStatus(vm, VMVMState.vmVMState_Invalid);
						break;
					case VMVMState.vmVMState_TurnedOff:
					case VMVMState.vmVMState_TurningOff:
						// Touch the Timer for Statusbar, make sure it's there.
						// This timer will be turned off when there is no tab
						tmrStatusbar.Enabled = false;

						// IF it's off, disable STOP/PAUSE/RESET/CAD/Shutdown/PrtScr, enable START
						tabMain.SelectedTab.Controls.Remove(myVMRC);
						this.ClientSize = new System.Drawing.Size(800, 600);
						sbrMain.ShowPanels = false;
						UpdateMenuToolBarStatus(vm, VMVMState.vmVMState_TurnedOff);
						break;
					case VMVMState.vmVMState_Saved:
					case VMVMState.vmVMState_Saving:
						// Touch the Timer for Statusbar, make sure it's there.
						// This timer will be turned off when there is no tab
						tmrStatusbar.Enabled = false;

						tabMain.SelectedTab.Controls.Remove(myVMRC);
						this.ClientSize = new System.Drawing.Size(800, 600);
						sbrMain.ShowPanels = false;
						UpdateMenuToolBarStatus(vm, VMVMState.vmVMState_Saved);
						break;
					case VMVMState.vmVMState_Running:
					case VMVMState.vmVMState_TurningOn:
					case VMVMState.vmVMState_Restoring:
						// IF it's ON, disable START, enable STOP/PAUSE/RESET/CAD/Shutdown/PrtScr
						myVMRC.Connect();
						UpdateMenuToolBarStatus(vm, VMVMState.vmVMState_Running );

						// Move the VMRC control to current tab.
						tabMain.SelectedTab.Controls.Add(myVMRC);
						myVMRC.Dock = System.Windows.Forms.DockStyle.Fill;

						// Turn on Status Bar
						sbrMain.ShowPanels = true;

						// Resize frmMan to fix this VM.
						adjustRes(conf.currentVS, conf.currentVM);	

						// Touch the Timer for Statusbar, make sure it's there.
						// This timer will be turned off when there is no tab
						tmrStatusbar.Enabled = true;
						break;
					default:
						break;
				}

				// Update Status bar
				setStatusbar(conf.currentVS, conf.currentVM);

				// Update the name of the tabpage
				tabMain.TabPages[tabMain.SelectedIndex].Text = conf.currentVM + "@" + conf.currentVS;		

			}
			
		}

		private void mnuVMProperties_Click(object sender, System.EventArgs e)
		{
			// VMRC set ServerDisplayName to 'Virtual Server' if the VM stopped or disconnected
			if (conf.currentVM  =="Virtual Server") 
			{
				touchTab();
			}

			// Show VM Property window
			frmVMProperty frm1 = new frmVMProperty(conf.currentVS, conf.currentVM, myApp, this);
			frm1.ShowDialog();

		}

		private void mnuAbout_Click(object sender, System.EventArgs e)
		{
			// Display About window
			frmAbout frm1 = new frmAbout();
			frm1.ShowDialog();
		}

		private void mnuExit_Click(object sender, System.EventArgs e)
		{
			// Exit Application
			Application.Exit();
		}

		private void frmMain_Resize(object sender, System.EventArgs e)
		{
			// Resize the main frame to fix current VM
			// Debug: Will there be any problem if myVMRC has incorrect information?
			if (tabMain.TabCount>0) 
			{
				adjustRes(conf.currentVS, conf.currentVM);
			}
		}
		
		private void mnuVSProperties_Click(object sender, System.EventArgs e)
		{
			string ServerAddress = "";
			// Show VS Property Window
			frmConnectVS frmCVS = new frmConnectVS(conf.currentVS, myApp);
			
			ServerAddress = frmCVS.getVSAddress();

			
			if (ServerAddress != "") // Cancel button pressed or user entered a blank server address
			{
				frmVSProperty frm1 = new frmVSProperty(ServerAddress, myApp);
				frm1.ShowDialog();
			}
		

		}

		private void sbrMain_PanelClick(object sender, System.Windows.Forms.StatusBarPanelClickEventArgs e)
		{
			// When clicked, update status bar data
			setStatusbar(conf.currentVS, conf.currentVM);
		}

		private void mnuVMStart_Click(object sender, System.EventArgs e)
		{
			// VMRC set ServerDisplayName to 'Virtual Server' if the VM stopped or disconnected
			if (conf.currentVM=="Virtual Server") 
			{
				touchTab();
			}

			changeVMState(conf.currentVS, conf.currentVM, VMState.Running );

			touchTab();
		}

		private void mnuVMStop_Click(object sender, System.EventArgs e)
		{

			changeVMState(conf.currentVS, conf.currentVM, VMState.TurnedOff );
			tabMain.SelectedTab.Controls.Remove(myVMRC);
			touchTab();
		}

		
		private void mnuVMSave_Click(object sender, System.EventArgs e)
		{
			
			changeVMState(conf.currentVS, conf.currentVM, VMState.Saved );
			tabMain.SelectedTab.Controls.Remove(myVMRC);
			touchTab();
		}

		private void mnuVMDiscardSaved_Click(object sender, System.EventArgs e)
		{
			VMVirtualMachine vm = Utility.getCurrentVM(tabMain.SelectedIndex);
			if (vm.State==VMVMState.vmVMState_Saved) 
			{
				vm.DiscardSavedState();
				mnuVMDiscardSaved.Visible = false;
			}
		}

		private void mnuVMMergeUndo_Click(object sender, System.EventArgs e)
		{
			VMVirtualMachine vm = Utility.getCurrentVM(tabMain.SelectedIndex);
			if (vm.Undoable) 
			{
				VMTask task = vm.MergeUndoDisks();
				while (!task.IsComplete) 
				{
					Thread.Sleep(100);
				}
			}
			mnuVMMergeUndo.Visible = false;
			mnuVMDiscardUndo.Visible = false;
		}

		private void mnuVMDiscardUndo_Click(object sender, System.EventArgs e)
		{
			VMVirtualMachine vm = Utility.getCurrentVM(tabMain.SelectedIndex);
			if (vm.Undoable) 
			{
				vm.DiscardUndoDisks();
			}
			mnuVMMergeUndo.Visible = false;
			mnuVMDiscardUndo.Visible = false;

		}

		private void mnuVMPause_Click(object sender, System.EventArgs e)
		{
			if (conf.vm.State == VMVMState.vmVMState_Paused) 
			{

				// Resume this VM
				changeVMState(conf.currentVS, conf.currentVM, VMState.Restoring);
				mnuVMPause.Text = "Pause";
				tbbPause.ToolTipText = "Pause VM";
				tbbPause.Pushed = false;

				touchTab();
			} 
			else
			{
				// Pause this VM
				changeVMState(conf.currentVS, conf.currentVM, VMState.Paused);
				mnuVMPause.Text = "Resume";
				tbbPause.ToolTipText = "Resume VM";
				tbbPause.Pushed = true;
				touchTab();
			}


		}

		private void mnuVMShutdown_Click(object sender, System.EventArgs e)
		{
			changeVMState(conf.currentVS, conf.currentVM, VMState.Shutdown);
			tabMain.SelectedTab.Controls.Remove(myVMRC);
			touchTab();
		}

		private void mnuVMReset_Click(object sender, System.EventArgs e)
		{
			changeVMState(conf.currentVS, conf.currentVM, VMState.Reset);
			//touchTab();
		}

		private void mnuVMCADKey_Click(object sender, System.EventArgs e)
		{
			myVMRC.SendKeySequence("DOWN,Key_LeftAlt,DOWN,Key_LeftCtrl,DOWN,Key_Delete,UP,Key_LeftAlt,UP,Key_LeftCtrl,UP,Key_Delete");

			// Wait to refresh tab until VM is running.
			VMVirtualMachine vm = conf.vm;
			while ( vm.State != VMVMState.vmVMState_Running ) 
			{
				Thread.Sleep(100);
			}	
			
		}

		private void mnuVMPrtScr_Click(object sender, System.EventArgs e)
		{
			myVMRC.SendKeySequence("DOWN,Key_SysReq,UP,Key_SysReq");
		}

		private void mnuVMConnProp_Click(object sender, System.EventArgs e)
		{
			myVMRC.ShowConnectionInfo();
		}

		private void mnuAttachISO_Click(object sender, System.EventArgs e)
		{
			// VMRC set ServerDisplayName to 'Virtual Server' if the VM stopped or disconnected
			if (conf.currentVM  =="Virtual Server") 
			{
				touchTab();
			}


		}
		private void mnuVSHostKey_Click(object sender, System.EventArgs e)
		{
			frmSetHostKey frmSHK = new frmSetHostKey(myVMRC);
			frmSHK.ShowDialog();
		}

		private void mnuVSCreateVM_Click(object sender, System.EventArgs e)
		{
			frmCreateVM frmCVM = new frmCreateVM(conf.currentVS, myApp);
			frmCVM.ShowDialog();
		}

		private void mnuVSRemoveVM_Click(object sender, System.EventArgs e)
		{
			frmRemoveVM frmRVM = new frmRemoveVM(this, myApp);
			frmRVM.ShowDialog();
		}

		private void mnuRemoveVSPlus_Click(object sender, System.EventArgs e)
		{

			DialogResult result;
			result = MessageBox.Show("Remove VM " + tabMain.SelectedTab.Text + " from VMPlus?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
			if (result == DialogResult.Yes) 
			{
				
				// Read last TabIndex fromXml
				XmlNodeList nodeList = xmlConfig.SelectNodes("//VirtualServer");
				
				// Find and delete this node from config.xml. 
				foreach (XmlNode xmlNode in nodeList) 
				{	
					int thisTabIndex = int.Parse(xmlNode.SelectSingleNode("TabIndex").InnerText );
					if ( thisTabIndex == tabMain.SelectedIndex) 
					{
						xmlNode.ParentNode.RemoveChild(xmlNode);
					}
				}
				
				// Sort the Tabindex in the Config
				nodeList = xmlConfig.SelectNodes("//VirtualServer");
				for(int i=0; i<nodeList.Count;i++)  
				{	
					nodeList[i].SelectSingleNode("TabIndex").InnerText = i.ToString();
				}

				// Update Window title
				UpdateWindowTitle(true);

				// Remove this tab
				tabMain.TabPages.Remove(tabMain.SelectedTab);

				// Update current tabMain page if there is a tabpage.
				// Also disable 'Remove' button on toolbar
				if (tabMain.TabCount>0) 
				{
					//tabMain_Click(this, new System.EventArgs());
					tbbRemove.Enabled = true;
					touchTab();
				} 
				else 
				{
					UpdateMenuToolBarStatus(null, VMVMState.vmVMState_Invalid );
					sbrMain.ShowPanels = false;
					sbrMain.Text = "Ready";
					tmrStatusbar.Enabled = false;
					this.ClientSize = new System.Drawing.Size(800, 600);
				}
				
	
			}
		}

		private void mnuAddVSPlus_Click(object sender, System.EventArgs e)
		{
			frmAdd formConnect = new frmAdd(this, myApp);
			formConnect.ShowDialog();
		}

		private void mnuAddVM_Click(object sender, System.EventArgs e)
		{
			frmAddVM frmAVM = new frmAddVM(myApp);
			frmAVM.ShowDialog();
			touchTab();
		}

		private void mnuCapScr_Click(object sender, System.EventArgs e)
		{
			// Wait the menu
			
			Thread.Sleep(500);

			// Capture the screen
			Bitmap memoryImage;
			Graphics mygraphics = myVMRC.CreateGraphics();
			Size s = myVMRC.Size;
			memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
			Graphics memoryGraphics = Graphics.FromImage(memoryImage);
			IntPtr dc1 = mygraphics.GetHdc();
			IntPtr dc2 = memoryGraphics.GetHdc();
			Utility.BitBlt(dc2, myVMRC.Location.X, myVMRC.Location.Y, myVMRC.Size.Width-1 , myVMRC.Size.Height-1, dc1, 0, 0, 13369376);
			mygraphics.ReleaseHdc(dc1);
			memoryGraphics.ReleaseHdc(dc2);

			// Get current VM folder, find the available file index. Save it
			VMVirtualMachine vm = conf.vm;
			FileInfo fi = new FileInfo(vm.File); 

			int i=1;
			while ( File.Exists( fi.DirectoryName + @"\Screen" + i + ".jpg") ) 
			{
				i++;
			}
	
			try 
			{
				memoryImage.Save( fi.DirectoryName+ @"\Screen" + i + ".jpg"   , System.Drawing.Imaging.ImageFormat.Jpeg);
			}
			catch (Exception err) 
			{
				MessageBox.Show(err.Message);
				return;
			}

			MessageBox.Show("Screenshot is saved to the following place:\n\n" + 
				fi.DirectoryName+ @"\Screen" + i + ".jpg", "Screenshot Saved" );

		}

		private void mnuFullScr_Click(object sender, System.EventArgs e)
		{
			// Locate VMRC client. Default is located at current VSPlus folder.
			String VMRCPath = "";
			if (File.Exists(@"C:\Program Files\Microsoft Virtual Server\VMRC Client\VMRC.exe")) VMRCPath = @"C:\Program Files\Microsoft Virtual Server\VMRC Client\";
			if (File.Exists(@"D:\Program Files\Microsoft Virtual Server\VMRC Client\VMRC.exe")) VMRCPath = @"D:\Program Files\Microsoft Virtual Server\VMRC Client\";

			try 
			{
				Process.Start(VMRCPath+"vmrc.exe", "-fullscreen vmrc://" + conf.currentVS + ":" + conf.currentVMRCPort + "/" + conf.currentVM);
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message + "\n\n Please copy VMRC.EXE from Virtual Server folder to VSPlus folder.");
			}
		}

		private void mnuInsAddition_Click(object sender, System.EventArgs e)
		{
			try 
			{
				VMVirtualMachine vm = conf.vm;
				vm.GuestOS.InstallAdditions();
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}

		}

		private void mnuCheckUpdate_Click(object sender, System.EventArgs e)
		{
			XmlDocument xmlDoc = new XmlDocument();

			try
			{
				System.Net.WebClient client = new System.Net.WebClient();
				client.DownloadFile("http://citynav.com/vsplus/version.xml", "version.xml");
				xmlDoc.Load("version.xml");
				File.Delete("version.xml");
			}
			catch (Exception err)
			{
				MessageBox.Show("Unable to access VSPlus website. \n\n" + err.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning );
				return;
			}
			

			string CurrentVersion = Assembly.GetExecutingAssembly().GetName().Version.Major + "." +
				Assembly.GetExecutingAssembly().GetName().Version.Minor + "." +
				Assembly.GetExecutingAssembly().GetName().Version.Build;
			try 
			{
				if ( xmlDoc.SelectSingleNode("//Version").InnerText == CurrentVersion ) 
				{
					if (sender.ToString().IndexOf("Text: VSPlus")<0) 
					{
						MessageBox.Show("No update available at this time.");
					}
				} 
				else 
				{
					DialogResult result;
					result = MessageBox.Show("New version " + xmlDoc.SelectSingleNode("//Version").InnerText + " is available for download now! \n\n" +
						"Do you want to check the website for new features?", "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
					if (result == DialogResult.Yes) 
					{
						Process.Start("http://citynav.com/vsplus/version.htm");
					}

				}

			} 
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
				return;
			}
			
		}

		private void mnuWeb_Click(object sender, System.EventArgs e)
		{
			Process.Start("http://citynav.com/vsplus/");
		}

		private void mnuForum_Click(object sender, System.EventArgs e)
		{
			Process.Start("http://citynav.com/phpBB2");
		}

		private void mnuBrowseVMFolder_Click(object sender, System.EventArgs e)
		{
			VMVirtualMachine vm = conf.vm;
			if ( vm!=null) 
			{
				Process.Start( Path.GetDirectoryName(vm.File) );
			}

		}

		

		public void changeVMState(string ServerAddress, string ServerDisplayName, VMState thisVMState) 
		{
			/*
			IVMVirtualMachine.Pause() and IVMVirtualMachine.Resume() doesn't not return a IVMTask.  
			  
			*/
			
			// Debug: Need more work
			VMVirtualMachine vm = conf.vm;
			VMTask task = null;
	
			// Status String
			string sState = "Unknown State";

			sbrMain.ShowPanels = false;
			// Do somethin here
			switch (thisVMState) 
			{
				// Turn on or Restore VM
				case VMState.Running :
					sState = "Turning on " + vm.Name;
					sbrMain.Text = sState;
					try 
					{
						task = vm.Startup();
					}
					catch (Exception err)
					{
						MessageBox.Show(err.Message);
						return;
					}
					break;

				// Turn off VM with different possibilities to deal with undo disks
				case VMState.TurnedOff :
					sState = "Turning off " + vm.Name;
					sbrMain.Text = sState;
					if (vm.Undoable) 
					{
						DialogResult result;
						result = MessageBox.Show("Do you want to keep undo disks, commit undo disks or discard undo disks?\n\nSelect Yes to keep undo disk; \nSelect No to commit undo disk; \nSelect Cancel to discard undo disks.\n", "Undo Disks Available", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
						if (result == DialogResult.Yes) 
						{	
							try 
							{
								task = vm.TurnOff();
							}
							catch(Exception err)
							{
								MessageBox.Show(err.Message);
								return;
							}
						} 
						else if (result == DialogResult.No)
						{
							try
							{
								task = vm.TurnOff();
								while (!task.IsComplete) 
								{
									Thread.Sleep(100);
									sbrMain.Text = sState + " (" + task.PercentCompleted + "%)";
								}
					
								task = vm.MergeUndoDisks();
							}
							catch(Exception err)
							{	
								MessageBox.Show(err.Message);
								return;
							}
						}
						else
						{
							try
							{
								task = vm.TurnOff();

								while (!task.IsComplete) 
								{
									Thread.Sleep(100);
									sbrMain.Text  = sState + " (" + task.PercentCompleted + "%)";
								}
	
								vm.DiscardUndoDisks();
							}
							catch (Exception err)
							{
								MessageBox.Show(err.Message);
								return;
							}
						}
					}
					else
					{
						try
						{
							task = vm.TurnOff();	
						}
						catch(Exception err)
						{
							MessageBox.Show(err.Message);
							return;
						}
					}
					break;

				// Reset VM
				case VMState.Reset:
					sState = "Resetting " + vm.Name;
					sbrMain.Text = sState;
					try
					{
						task = vm.Reset();
					}
					catch (Exception err)
					{
						MessageBox.Show(err.Message);
						return;
					}
					break;

				// Pause VM
				case VMState.Paused:
					sState= "Pausing " + vm.Name;
					sbrMain.Text = sState;
					try
					{
						vm.Pause();
					}
					catch (Exception err)
					{
						MessageBox.Show(err.Message);
						return;
					}
					break;

				// Restore VM from Saved state
				case VMState.Restoring:
					sState = "Restoring " + vm.Name;
					sbrMain.Text = sState;
					try
					{
						vm.Resume();
					}
					catch (Exception err)
					{
						MessageBox.Show(err.Message);
						return;
					}
					break;

				// Save VM with different possibilities to deal with undo disks
				case VMState.Saved:
					sState = "Saving " + vm.Name;
					sbrMain.Text = sState;
					if (vm.Undoable) 
					{
						DialogResult result;
						result = MessageBox.Show("Do you want to keep undo disks or commit undo disks. \n\nSelect Yes for keep undo disks; \nSelect No for commit undo disks.\n", "Undo Disks Available", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
						if (result == DialogResult.Yes) 
						{
							try
							{
								task = vm.Save();
							}
							catch (Exception err)
							{
								MessageBox.Show(err.Message);
								return;
							}	
						}
						else
						{
							try
							{
								task = vm.Save();	
								while (!task.IsComplete) 
								{
									Thread.Sleep(100);
									sbrMain.Text = sState + " (" + task.PercentCompleted + "%)";
								}
								task = vm.MergeUndoDisks();
							}
							catch (Exception err)
							{
								MessageBox.Show(err.Message);
								return;
							}
						}
					}
					else
					{
						try
						{
							task = vm.Save();	
						}
						catch (Exception err)
						{
							MessageBox.Show(err.Message);
							return;
						}
					}
					break;
				case VMState.Shutdown:
					if (vm.GuestOS.CanShutdown) 
					{
						sState = "Shutting down " + vm.Name;
						sbrMain.Text = sState;
						try
						{
							task = vm.GuestOS.Shutdown();
						}
						catch (Exception err)
						{
							MessageBox.Show(err.Message);
							return;
						}

					} 
					else 
					{
						MessageBox.Show("This guest operating system doesn't support shutdown or doesn't have VM Additions installed.");
					}
					break;
				default:
					break;
			}

			// Wait till the command is executed. The if is needed, because several commands has no VMTask returned
			if (task != null) 
			{
				while (!task.IsComplete) 
				{
					Thread.Sleep(100);
					sbrMain.Text = sState + " (" + task.PercentCompleted + "%)";
				}
			}

			return;		
		}
		
		public void touchTab() 
		{
			// Touch each tab; Set Static for access by others
			tabMain_Click(this, new System.EventArgs());
		}

		public void removeTab(int tabIndex) 
		{
			tabMain.TabPages.Remove(tabMain.TabPages[tabIndex]);
		}

		public void addVMTab(string ServerAddress, string ServerDisplayName) 
		{
			// Add tab for each VM.	

			// Debug: If item in config.xml doesn't exist, skip it.
			conf.currentVS = ServerAddress;
			conf.currentVM = ServerDisplayName;
			conf.vs = Utility.getVS(conf.currentVS);
			conf.vm = Utility.getVM(conf.vs, conf.currentVM);

			myVMRC.ServerAddress = conf.currentVS;
			myVMRC.ServerDisplayName = conf.currentVM;

			VMVirtualMachine vm = conf.vm;
			if ( vm==null ) 
			{
				MessageBox.Show("Cannot find virtual machine " + ServerDisplayName + " on virtual server " + ServerAddress + ". " + 
								"\n\nIt may be removed from the configuration file or the virtual server. ");
				RemoveFromConfigFile(conf.currentVS, conf.currentVM);
				return;
			}
			
			// Add a new tab
			TabPage thisTabPage = new TabPage(ServerDisplayName + "@" + ServerAddress);
			tabMain.TabPages.Add(thisTabPage);


			
			// Enable quick buttons on toolbar
			for (int i=0; i<tbarMain.Buttons.Count; i++) 
			{
				tbarMain.Buttons[i].Enabled = true;
			}

			// Enable "Remove" button
			tbbRemove.Enabled = true;

			// Touch Panel of the Statusbar, make sure it's there.
			// This panel will be disabled when there is no tab
			sbrMain.ShowPanels  = true;
			
			// Enable VM menu
			mnuVM.Enabled = true;

			// Mark this change to the configuration
			UpdateWindowTitle(true);;

			// Start clock to update status
			tmrStatusbar.Enabled = true;

			return;
		}

		public void addVSTab(string ServerAddress)  
		{
			// Add tab for this VS	
			VMVirtualServer vs = Utility.getVS(ServerAddress);
			if ( vs==null ) 
			{
				MessageBox.Show("Cannot find virtual server  " + ServerAddress + ". " + "\n\n ");
				//RemoveFromConfigFile(myVMRC.ServerAddress, myVMRC.ServerDisplayName);
				return;
			}
			
			// Add a new tab
			TabPage thisTabPage = new TabPage(ServerAddress);
			tabMain.TabPages.Add(thisTabPage);

			// Enable VSViewGrid	
			dgVSView.Enabled = true;

			
			// Enable quick buttons on toolbar
			for (int i=0; i<tbarMain.Buttons.Count; i++) 
			{
				tbarMain.Buttons[i].Enabled = true;
			}

			// Enable "Remove" button
			tbbRemove.Enabled = true;

			// Touch Panel of the Statusbar, make sure it's there.
			// This panel will be disabled when there is no tab
			sbrMain.ShowPanels  = true;
			
			// Enable VM menu
			mnuVM.Enabled = true;

			// Mark this change to the configuration
			UpdateWindowTitle(true);;

			// Start clock to update status
			tmrStatusbar.Enabled = true;

			return;
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			touchTab();
			timer1.Enabled = false;
		}

		private void tmrStatusbar_Tick(object sender, System.EventArgs e)
		{
			// If this is a VSView, update the datagrid
			if (tabMain.SelectedTab.Text.IndexOf("@")<0) 
			{
				int currentRow = dgVSView.CurrentRowIndex ;
				if (currentRow<0) return;

				dgVSView = Utility.getVSViewGrid(conf.vs, dgVSView);

				int totalRows = 0;
				try
				{
					totalRows = ((DataTable)dgVSView.DataSource).Rows.Count;
				}
				catch
				{
					totalRows = 0;
				}

				if (totalRows!=0) 
				{
					if (currentRow > totalRows) 
					{
						dgVSView.CurrentRowIndex = totalRows;
						dgVSView.Select(totalRows);
					}
					else
					{
						dgVSView.CurrentRowIndex = currentRow;
						dgVSView.Select(currentRow);
					}
				}
			}
	
			setStatusbar(conf.currentVS, conf.currentVM);
			adjustRes(conf.currentVS, conf.currentVM);
			
			// Read Global Configuration Object to get current interval
			tmrStatusbar.Interval = conf.RefreshInterval * 1000;
		}

		
		public void adjustRes(string ServerAddress, string ServerDisplayName)
		{
			if (tabMain.SelectedTab.Text.IndexOf("@")<0) 
			{	// Current tab is a VS VSView, Change current window size to 800x600
				this.ClientSize = new System.Drawing.Size(800, 600);
			}
			else
			{	// Current tab is a VM View
				// Adjust the size of frmMain to fix current VM.
				int WidthBorder = 7;
				int HeightBorder = 81;

				VMVirtualMachine vm = conf.vm;
				
				// Debug. The following line has an error
				// 11/25/04 An unhandled exception of type 'System.Runtime.InteropServices.COMException' occurred in VSPlus.exe
				// Additional information: An outgoing call cannot be made since the application is dispatching an input-synchronous call.
				// 11/27/04 Add a try...catch to avoid the unknown problem. 
				// 11/27/04 DO not resize if the windows is minimized.

				try 
				{
					if (  vm==null || vm.State!=VMVMState.vmVMState_Running ) 
					{
						return;
					}
					else
					{
						if (this.WindowState != FormWindowState.Minimized) 
						{
							this.ClientSize = new System.Drawing.Size(vm.Display.Width  + WidthBorder, vm.Display.Height + HeightBorder);
						}
					}

				}
				catch
				{
					Console.WriteLine(ServerAddress + "  " + ServerDisplayName + "  " + conf.vm.Name );
					
				}



			}
			
		}

		public void setStatusbar(string ServerAddress, string ServerDisplayName) 
		{
			if (tabMain.SelectedTab.Text.IndexOf("@")<0) 
			{	// Current tab is a VS VSView
				sbrMain.ShowPanels = false;
				sbrMain.Text = "VSView";
			}
			else
			{	// Current tab is a VM View
				// Set the data on Status bar
				VMVirtualMachine vm = conf.vm;
				// If the VM is not exist or VM is not running or the window is minimized, don't update.
				if ( vm==null || vm.State!=VMVMState.vmVMState_Running || this.ClientSize.Width==0) 
				{
					return;
				}

				int windowWidth = this.ClientSize.Width;
				sbrMain.ShowPanels = true;

				sbpState.Width = (int)(windowWidth * 0.15);
				sbpState.Text = "State: " + Utility.ConvertVMStateToString(vm.State);

				sbpUptime.Width = (int)(windowWidth * 0.2);
				sbpUptime.Text = "Uptime: " + Utility.ConvertUptimeToString(vm.Accountant.UpTime);

				sbpCPU.Width = (int)(windowWidth * 0.1);
				sbpCPU.Text = "CPU: " + Utility.AverageCPUUsage(vm) + "%";

				sbpDiskIO.Width = (int)(windowWidth * 0.2);
				sbpDiskIO.Text = "Disk: " + Utility.ConvertByteToString(vm.Accountant.DiskBytesRead.ToString()) + "/" + Utility.ConvertByteToString(vm.Accountant.DiskBytesWritten.ToString()) ;

				sbpNetIO.Width = (int)(windowWidth * 0.2);
				sbpNetIO.Text = "Network: " + Utility.ConvertByteToString(vm.Accountant.NetworkBytesReceived.ToString()) + "/" + Utility.ConvertByteToString(vm.Accountant.NetworkBytesSent.ToString()) ;

				sbpRes.Width = (int)(windowWidth * 0.15);

				if (vm.State == VMVMState.vmVMState_Invalid || vm.State == VMVMState.vmVMState_TurnedOff || vm.State == VMVMState.vmVMState_Paused || vm.State == VMVMState.vmVMState_Saved  ) 
				{
					sbpRes.Text = "Res: Unknown";		
				} 
				else
				{
					sbpRes.Text = "Res: " + vm.Display.Width.ToString() + "x" + vm.Display.Height.ToString();
				}

			}
		}

		private void UpdateMenuToolBarStatus(VMVirtualMachine vm, VMVMState vmstate)
		{
			// Display Menu items applied to all VMs if this is a VSView tab
			if (tabMain.TabCount>0 && tabMain.SelectedTab.Text.IndexOf("@")<0 && conf.vs.VirtualMachines.Count>0) 
			{	// This is a VS View Tab
				mnuVSStartAllVM.Visible = true;
				mnuVSStopAllVM.Visible = true;
				mnuVSPauseAllVM.Visible = true;
				mnuVSResetAllVM.Visible = true;
				mnuVSSaveAllVM.Visible = true;
				mnuVSShutdownAllVM.Visible = true;
				mnuVSSep.Visible = true;
			}
			else
			{
				mnuVSStartAllVM.Visible = false;
				mnuVSStopAllVM.Visible = false;
				mnuVSPauseAllVM.Visible = false;
				mnuVSResetAllVM.Visible = false;
				mnuVSSaveAllVM.Visible = false;
				mnuVSShutdownAllVM.Visible = false;
				mnuVSSep.Visible = false;
			}

			if (vm!=null) 
			{	// There is a VM
				mnuVM.Enabled = true;
				switch (vmstate) 
				{
					case VMVMState.vmVMState_Invalid:
						// VM Action
						tbbStart.Enabled = false;
						mnuVMStart.Enabled = false;

						tbbStop.Enabled = false;
						mnuVMStop.Enabled = false;

						tbbVMSave.Enabled = false;
						mnuVMSave.Enabled = false;
						mnuVMDiscardSaved.Visible = false;
						mnuVMDiscardUndo.Visible = false;
						mnuVMMergeUndo.Visible = false;

						tbbReset.Enabled = false;
						mnuVMReset.Enabled = false;

						tbbPause.Enabled = false;
						mnuVMPause.Enabled = false;

						tbbShutdown.Enabled = false;
						mnuVMShutdown.Enabled = false;
					
						mnuAttachISO.Enabled = false;

						// Properties
						mnuVMConnProp.Enabled = false;

						tbbVMProp.Enabled = true;
						mnuVMProperties.Enabled = true;

						// Other Functions
						tbbCADKey.Enabled = false;
						mnuVMCADKey.Enabled = false;

						tbbPrintScr.Enabled = false;
						mnuVMPrtScr.Enabled = false;

						tbbCapScr.Enabled = false;
						mnuCapScr.Enabled = false;

						tbbFullScreen.Enabled = false;
						mnuFullScr.Enabled = false;
					
						mnuInsAddition.Enabled = false;

						tbbSetHostKey.Enabled = false;

						mnuRemoveFromVS.Enabled = false;



						break;
					case VMVMState.vmVMState_Paused:
						// VM Action
						tbbStart.Enabled = false;
						mnuVMStart.Enabled = false;

						tbbStop.Enabled = true;
						mnuVMStop.Enabled = true;

						tbbVMSave.Enabled = true;
						mnuVMSave.Enabled = true;
						mnuVMDiscardSaved.Visible = false;
						mnuVMDiscardUndo.Visible = false;
						mnuVMMergeUndo.Visible = false;

						tbbReset.Enabled = true;
						mnuVMReset.Enabled = true;

						tbbPause.Enabled = true;
						tbbPause.Pushed = true;
						mnuVMPause.Enabled = true;

						tbbShutdown.Enabled = true;
						mnuVMShutdown.Enabled = true;

						mnuAttachISO.Enabled = true;

					
						// Properties
						mnuVMConnProp.Enabled = true;

						tbbVMProp.Enabled = true;
						mnuVMProperties.Enabled = true;

						// Other Functions
						tbbCADKey.Enabled = false;
						mnuVMCADKey.Enabled = false;

						tbbPrintScr.Enabled = false;
						mnuVMPrtScr.Enabled = false;

						tbbCapScr.Enabled = false;
						mnuCapScr.Enabled = false;

						tbbFullScreen.Enabled = false;
						mnuFullScr.Enabled = false;
					
						mnuInsAddition.Enabled = false;

						tbbSetHostKey.Enabled = true;

						mnuRemoveFromVS.Enabled = false;

						break;
					case VMVMState.vmVMState_TurnedOff :
					case VMVMState.vmVMState_TurningOff:
						// VM Action
						tbbStart.Enabled = true;
						mnuVMStart.Enabled = true;

						tbbStop.Enabled = false;
						mnuVMStop.Enabled = false;

						tbbVMSave.Enabled = false;
						mnuVMSave.Enabled = false;
						mnuVMDiscardSaved.Visible = false;

						if (vm!=null && vm.Undoable) 
						{
							mnuVMDiscardUndo.Visible = true;
							mnuVMMergeUndo.Visible = true;
						}

						tbbReset.Enabled = false;
						mnuVMReset.Enabled = false;

						tbbPause.Enabled = false;
						tbbPause.Pushed = false;
						mnuVMPause.Enabled = false;

						tbbShutdown.Enabled = false;
						mnuVMShutdown.Enabled = false;
					
						mnuAttachISO.Enabled = true;

						// Properties
						mnuVMConnProp.Enabled = true;

						tbbVMProp.Enabled = true;
						mnuVMProperties.Enabled = true;

						// Other Functions
						tbbCADKey.Enabled = false;
						mnuVMCADKey.Enabled = false;

						tbbPrintScr.Enabled = false;
						mnuVMPrtScr.Enabled = false;

						tbbCapScr.Enabled = false;
						mnuCapScr.Enabled = false;

						tbbFullScreen.Enabled = false;
						mnuFullScr.Enabled = false;
					
						mnuInsAddition.Enabled = false;

						tbbSetHostKey.Enabled = true;

						mnuRemoveFromVS.Enabled = true;

						break;

					case VMVMState.vmVMState_Saved:
					case VMVMState.vmVMState_Saving:
						// VM Action
						tbbStart.Enabled = true;
						mnuVMStart.Enabled = true;

						tbbStop.Enabled = false;
						mnuVMStop.Enabled = false;

						tbbVMSave.Enabled = false;
						mnuVMSave.Enabled = false;

						mnuVMDiscardSaved.Visible = true;

						if (vm!=null && vm.Undoable) 
						{
							mnuVMDiscardUndo.Visible = true;
							mnuVMMergeUndo.Visible = true;
						}

						tbbReset.Enabled = false;
						mnuVMReset.Enabled = false;

						tbbPause.Enabled = false;
						tbbPause.Pushed = false;
						mnuVMPause.Enabled = false;

						tbbShutdown.Enabled = false;
						mnuVMShutdown.Enabled = false;
					
						mnuAttachISO.Enabled = true;

						// Properties
						mnuVMConnProp.Enabled = true;

						tbbVMProp.Enabled = true;
						mnuVMProperties.Enabled = true;

						// Other Functions
						tbbCADKey.Enabled = false;
						mnuVMCADKey.Enabled = false;

						tbbPrintScr.Enabled = false;
						mnuVMPrtScr.Enabled = false;

						tbbCapScr.Enabled = false;
						mnuCapScr.Enabled = false;

						tbbFullScreen.Enabled = false;
						mnuFullScr.Enabled = false;
					
						mnuInsAddition.Enabled = false;

						tbbSetHostKey.Enabled = true;

						mnuRemoveFromVS.Enabled = true;

						break;
					case VMVMState.vmVMState_Running :
					case VMVMState.vmVMState_TurningOn :
					case VMVMState.vmVMState_Restoring :
						// VM Action
						tbbStart.Enabled = false;
						mnuVMStart.Enabled = false;

						tbbStop.Enabled = true;
						mnuVMStop.Enabled = true;

						tbbVMSave.Enabled = true;
						mnuVMSave.Enabled = true;
						mnuVMDiscardSaved.Visible = false;
						mnuVMDiscardUndo.Visible = false;
						mnuVMMergeUndo.Visible = false;

						tbbReset.Enabled = true;
						mnuVMReset.Enabled = true;

						tbbPause.Enabled = true;
						tbbPause.Pushed = false;
						mnuVMPause.Enabled = true;

						tbbShutdown.Enabled = true;
						mnuVMShutdown.Enabled = true;
					
						mnuAttachISO.Enabled = true;

						// Properties
						mnuVMConnProp.Enabled = true;

						tbbVMProp.Enabled = true;
						mnuVMProperties.Enabled = true;

						// Other Functions
						tbbCADKey.Enabled = true;
						mnuVMCADKey.Enabled = true;

						tbbPrintScr.Enabled = true;
						mnuVMPrtScr.Enabled = true;

						tbbCapScr.Enabled = true;
						mnuCapScr.Enabled = true;

						tbbFullScreen.Enabled = true;
						mnuFullScr.Enabled = true;
					
						mnuInsAddition.Enabled = true;

						tbbSetHostKey.Enabled = true;

						mnuRemoveFromVS.Enabled = false;
						break;
					default:
						break;
				}

				if (mnuAttachISO.Enabled) 
				{
					AttachISOSubMenu();
				}

			}
			else
			{	// This is a VS with no VM
				mnuVM.Enabled = false;

				// VM Action
				tbbStart.Enabled = false;
				tbbStop.Enabled = false;
				tbbVMSave.Enabled = false;
				tbbReset.Enabled = false;
				tbbPause.Enabled = false;
				tbbShutdown.Enabled = false;
				tbbVMProp.Enabled = false;
				// Other Functions
				tbbCADKey.Enabled = false;
				tbbPrintScr.Enabled = false;
				tbbCapScr.Enabled = false;
				tbbFullScreen.Enabled = false;
				tbbSetHostKey.Enabled = false;
			}


		}


		private void RemoveFromConfigFile(string ServerAddress, string ServerDisplayName) 
		{
			// Update server list file.
					
			//XmlDocument xmlDoc = new XmlDocument();
			try
			{
				// Load config.xml
				//xmlDoc.Load(conf.CONFIGFILE);
				// Read last TabIndex fromXml
				XmlNodeList nodeList = xmlConfig.SelectNodes("//VirtualServer");

				// Find and delete this node from config.xml. 
				string thisAddress="", thisDisplayName="";
				foreach (XmlNode xmlNode in nodeList) 
				{	
					thisAddress = xmlNode.SelectSingleNode("ServerAddress").InnerText ;
					thisDisplayName = xmlNode.SelectSingleNode("ServerDisplayName").InnerText ;
					if ( thisAddress==ServerAddress && thisDisplayName==ServerDisplayName) 
					{
						xmlNode.ParentNode.RemoveChild(xmlNode);
					}
				}
				//xmlDoc.Save(conf.CONFIGFILE);


				// Reload config.xml to reorder tabindex
				// Question: Why do I have to save XML first and reload?
				//xmlDoc.Load(conf.CONFIGFILE);
				nodeList = xmlConfig.SelectNodes("//VirtualServer");
				for(int i=0; i<nodeList.Count;i++)  
				{	
					nodeList[i].SelectSingleNode("TabIndex").InnerText  = i.ToString();
				}
				
				//xmlDoc.Save(conf.CONFIGFILE);
					
				UpdateWindowTitle(true);


			}
			catch(XmlException xmlEx)        // Handle the Xml exceptions here.         
			{
				MessageBox.Show(xmlEx.Message);
			}
			catch(Exception ex)              // Handle the generic exceptions. here
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void mnuSave_Click(object sender, System.EventArgs e)
		{
			// Save
			try
			{
				xmlConfig.Save(conf.CONFIGFILE);
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
				return;
			}

			// Make sure the * is removed.
			UpdateWindowTitle(false);
		}

		private void mnuSaveAS_Click(object sender, System.EventArgs e)
		{
			sfdMain.Filter = "Configuration File (*.xml)|*.xml"  ;
			sfdMain.RestoreDirectory = true ;
			FileInfo fi = new FileInfo(conf.CONFIGFILE);
			sfdMain.InitialDirectory = fi.DirectoryName;

			if(sfdMain.ShowDialog() == DialogResult.OK)
			{
				// Save it.
				conf.CONFIGFILE = sfdMain.FileName;

				xmlConfig.Save(conf.CONFIGFILE);

				// Update Form Title text
				UpdateWindowTitle(false);
			}

		}

		private void mnuLoadConfig_Click(object sender, System.EventArgs e)
		{
			
			ofdMain.Filter = "Configuration Files (*.xml)|*.xml";

			FileInfo fi = new FileInfo(conf.CONFIGFILE);
			ofdMain.InitialDirectory = fi.DirectoryName;

			if(ofdMain.ShowDialog() == DialogResult.OK)
			{
				//string VDDFile = txtVDDFilePath.Text;

				if( ofdMain.FileName != "") 
				{
					// Insert code to read the stream here.
					conf.CONFIGFILE = ofdMain.FileName;

					// Load all VMs in the default config.xml
					xmlConfig.Load(conf.CONFIGFILE);
					XmlNodeList nodeList = xmlConfig.SelectNodes("//VirtualServer");	
											
					// Clean TabControl
					tabMain.TabPages.Clear();
					
					// Load tabs in the new configuration
					if (nodeList.Count >0) 
					{
						foreach (XmlNode xmlNode in nodeList) 
						{	
							addVMTab(xmlNode.SelectSingleNode("ServerAddress").InnerText, xmlNode.SelectSingleNode("ServerDisplayName").InnerText  );
						}

						// Touch the current tabpage.
						if (tabMain.TabPages.Count>0) 
						{
							timer1.Enabled  = true;
						}
					}
					sbrMain.ShowPanels = false;
					myVMRC.MenuEnabled = false;
					
					// Update Form Title text
					UpdateWindowTitle(false);

				}

			}
		}

		private void myVMRC_OnStateChanged(object sender, AxVMRCClientControlLib._IVMRCClientControlEvents_OnStateChangedEvent e)
		{
			string vmrcState = myVMRC.CtlState.ToString();
			switch(vmrcState)
			{
				case "vmrcState_NotConnected":
					sbrMain.Text = "Ready";
					sbrMain.ShowPanels = false;
					tmrStatusbar.Enabled = false;
					break;
				case "vmrcState_Connecting":
					sbrMain.Text = "Connecting to the Virtual Machine: " + myVMRC.ServerDisplayName + " on " + myVMRC.ServerAddress ;
					sbrMain.ShowPanels = false;
					tmrStatusbar.Enabled = false;
					
					break;
				case "vmrcState_Authenticating":
					sbrMain.Text = "Authenticating ...";
					sbrMain.ShowPanels = false;
					tmrStatusbar.Enabled = false;
					
					break;
				case "vmrcState_Connected":
					sbrMain.ShowPanels = true;
					tmrStatusbar.Enabled = true;
					
					break;
				case "vmrcState_ConnectionFailed":
					sbrMain.Text = "Failed to Connect to the Virtual Machine: " + myVMRC.ServerDisplayName + " on " + myVMRC.ServerAddress;
					sbrMain.ShowPanels = false;
					tmrStatusbar.Enabled = false;
					break;
				default:
					break;
			}

		}

		private void mnuSettings_Click(object sender, System.EventArgs e)
		{
			frmSettings frm1 = new frmSettings();
			frm1.ShowDialog();

			
		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			frmSettingsGrid frm2 = new frmSettingsGrid();
			frm2.ShowDialog();
			//Debug
			MessageBox.Show(conf.CheckUpdateOnExiting.ToString());
		}

		private void frmMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if ( this.Text.Substring( this.Text.Length-1, 1) =="*" || conf.ConfigUpdated == true) 
			{
				DialogResult result;
				result = MessageBox.Show("Do you want to save changes?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
				if (result == DialogResult.Cancel) 
				{
					e.Cancel = true;
					return;
				}
				if (result == DialogResult.Yes) 
				{
					mnuSave_Click(this, new System.EventArgs());
				}

			}

			if ( conf.CheckUpdateOnExiting  == true) 
			{
				mnuCheckUpdate_Click(this, new System.EventArgs());
			}

		}


		public void UpdateWindowTitle(bool Updated) 
		{
			if (Updated) 
			{
				this.Text  = "VSPlus - " + Path.GetFullPath(conf.CONFIGFILE) + "*";
			}
			else
			{
				this.Text  = "VSPlus - " + Path.GetFullPath(conf.CONFIGFILE);
			}
		}


		private void dgVSView_Click(object sender, System.EventArgs e)
		{
			if (conf.vs.VirtualMachines.Count > 0)
			{	// There is at least one VM registered on this VS.

				// Highlight current row.
				dgVSView.Select(dgVSView.CurrentCell.RowNumber);
				//Debug Error: An unhandled exception of type 'System.IndexOutOfRangeException' occurred in system.windows.forms.dll
				// Additional information: Index was outside the bounds of the array.
				VMVirtualMachine vm = Utility.getVS(tabMain.SelectedTab.Text).VirtualMachines[dgVSView.CurrentRowIndex+1];

				// When a VM in the VSView is selected, update current VS/VM info and update menu/toolbar status
				conf.currentVS = tabMain.SelectedTab.Text;
				conf.currentVMRCPort = Utility.getVS(tabMain.SelectedTab.Text).VMRCAdminPortNumber;
				conf.currentVM = vm.Name;
				conf.vs = Utility.getVS(conf.currentVS);
				conf.vm = Utility.getVM(conf.vs, conf.currentVM);

				UpdateMenuToolBarStatus(vm, vm.State);
			}
			else
			{	// There is no VM registered on this VS.
				// When a VM in the VSView is selected, update current VS/VM info and update menu/toolbar status
				conf.currentVS = tabMain.SelectedTab.Text;
				conf.currentVMRCPort = Utility.getVS(tabMain.SelectedTab.Text).VMRCAdminPortNumber;
				conf.currentVM = "Virtual Server";
				conf.vs = Utility.getVS(conf.currentVS);
				conf.vm = null;
				
				UpdateMenuToolBarStatus(null, VMVMState.vmVMState_Invalid);

			}
		}

		private void cxmVSView_Popup(object sender, System.EventArgs e)
		{
			// If there is no VM on this VS, disable right click popup menu.
			if (conf.vs.VirtualMachines.Count==0) return;

			VMVirtualMachine vm = Utility.getVS(tabMain.SelectedTab.Text).VirtualMachines[dgVSView.CurrentRowIndex+1];
			
			cxmVSView.MenuItems.Clear();
			cxmVSView.MenuItems.Add(vm.Name);
			cxmVSView.MenuItems[0].Enabled =true;
			cxmVSView.MenuItems.Add("-");

			switch (vm.State) 
			{
				case VMVMState.vmVMState_Invalid:

					break;
				case VMVMState.vmVMState_Paused:
					cxmVSView.MenuItems.Add("Stop", new EventHandler(mnuVMStop_Click));
					cxmVSView.MenuItems.Add("Save", new EventHandler(mnuVMSave_Click));
					cxmVSView.MenuItems.Add("Reset", new EventHandler(mnuVMReset_Click));
					cxmVSView.MenuItems.Add("Restore", new EventHandler(mnuVMStart_Click));
					cxmVSView.MenuItems.Add("Shutdown", new EventHandler(mnuVMShutdown_Click));
					break;
				case VMVMState.vmVMState_TurnedOff :
				case VMVMState.vmVMState_TurningOff:
					cxmVSView.MenuItems.Add("Start", new EventHandler(mnuVMStart_Click));
					if (vm!=null && vm.Undoable) 
					{
						cxmVSView.MenuItems.Add("Discard Undo Disk", new EventHandler(mnuVMDiscardUndo_Click ));
						cxmVSView.MenuItems.Add("Merge Undo Disk", new EventHandler(mnuVMMergeUndo_Click));
					}
					cxmVSView.MenuItems.Add("Remove from VS", new EventHandler(mnuRemoveFromVS_Click));
					break;
				case VMVMState.vmVMState_Saved:
				case VMVMState.vmVMState_Saving:
					cxmVSView.MenuItems.Add("Start", new EventHandler(mnuVMStart_Click));
					cxmVSView.MenuItems.Add("Discard Saved State", new EventHandler(mnuVMDiscardSaved_Click));
					if (vm!=null && vm.Undoable) 
					{
						cxmVSView.MenuItems.Add("Discard Undo Disk", new EventHandler(mnuVMDiscardUndo_Click));
						cxmVSView.MenuItems.Add("Merge Undo Disk", new EventHandler(mnuVMMergeUndo_Click));
					}
					cxmVSView.MenuItems.Add("Remove from VS", new EventHandler(mnuRemoveFromVS_Click));
					break;
				case VMVMState.vmVMState_Running :
				case VMVMState.vmVMState_TurningOn :
				case VMVMState.vmVMState_Restoring :
					// VM Action
					cxmVSView.MenuItems.Add("Stop", new EventHandler(mnuVMStop_Click));
					cxmVSView.MenuItems.Add("Save", new EventHandler(mnuVMSave_Click));
					cxmVSView.MenuItems.Add("Reset", new EventHandler(mnuVMReset_Click));
					cxmVSView.MenuItems.Add("Save", new EventHandler(mnuVMSave_Click));
					cxmVSView.MenuItems.Add("Shutdown", new EventHandler(mnuVMShutdown_Click));
					break;
				default:
					break;

			}

			cxmVSView.MenuItems.Add("-");
			cxmVSView.MenuItems.Add("VM Properties", new EventHandler(mnuVMProperties_Click ));	
			cxmVSView.MenuItems.Add("VS Properties", new EventHandler(mnuVSProperties_Click));
			cxmVSView.MenuItems.Add("Add VM View", new EventHandler(mnuAddVMView_Click));
	

		}


		private void AttachISOSubMenu() 
		{
			VMVirtualMachine vm = conf.vm;
			mnuAttachISO.MenuItems.Clear();
			mnuAttachISO.MenuItems.Add("Existing DVD/CD Drives on " + vm.Name);
			//mnuAttachISO.MenuItems[0].Enabled = false;
			mnuAttachISO.MenuItems.Add("-");
			VMDVDDrive dvd = null;
			for (int i=1; i<=vm.DVDROMDrives.Count; i++) 
			{
				dvd = vm.DVDROMDrives[i];
				if (dvd.Attachment==VMDVDDriveAttachmentType.vmDVDDrive_HostDrive) 
				{
					mnuAttachISO.MenuItems.Add(i + ": Host Drive " + dvd.HostDriveLetter + ":", new EventHandler(AttachISOSubMenu_Click));
				}
				if (dvd.Attachment==VMDVDDriveAttachmentType.vmDVDDrive_Image)
				{
					mnuAttachISO.MenuItems.Add(i + ": " + dvd.ImageFile , new EventHandler(AttachISOSubMenu_Click));
				}
				if (dvd.Attachment==VMDVDDriveAttachmentType.vmDVDDrive_None)
				{
					mnuAttachISO.MenuItems.Add(i + ": None" , new EventHandler(AttachISOSubMenu_Click));
				}

			}
		}

		private void AttachISOSubMenu_Click(object sender, System.EventArgs e)
		{
			VMVirtualMachine vm = conf.vm;
			VMDVDDrive dvd = null;

			// Get ISO file path
			string ISOFile = "";
			ofdMain.Filter = "ISO files (*.iso)|*.iso";
			if(ofdMain.ShowDialog() == DialogResult.OK)
			{
				//string VDDFile = txtVDDFilePath.Text;

				if( ofdMain.FileName != "") 
				{
					// Insert code to read the stream here.
					ISOFile = ofdMain.FileName;
				}
			}

			// Detach  current connection
			int dvdid = int.Parse( ((MenuItem)sender).Text.Substring(0,1));
			dvd = vm.DVDROMDrives[dvdid];

			try 
			{
				if (dvd.Attachment==VMDVDDriveAttachmentType.vmDVDDrive_HostDrive) 
				{
					dvd.ReleaseHostDrive();
				}
			
				if (dvd.Attachment==VMDVDDriveAttachmentType.vmDVDDrive_Image)
				{
					dvd.ReleaseImage();
				}
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
				return;
			}
			
			// Attach ISO
			try 
			{
				dvd.AttachImage(ISOFile);
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}



		private void mnuDupVM_Click(object sender, System.EventArgs e)
		{
			frmDupVM frm1 = new frmDupVM(conf.currentVS, conf.currentVM);
			frm1.ShowDialog();
		}

		private void mnuRemoveFromVS_Click(object sender, System.EventArgs e)
		{
			DialogResult result;
			result = MessageBox.Show("Remove Virtual Machine from Virtual Server?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
			if (result == DialogResult.Yes) 
			{
				VMVirtualServer vs = conf.vs;
				VMVirtualMachine vm = conf.vm;

				if (vm.State==VMVMState.vmVMState_Paused || vm.State==VMVMState.vmVMState_Running)  
				{
					MessageBox.Show("Cannot remove VM when it is running or paused.");
					return;
				}

				try 
				{
					vs.UnregisterVirtualMachine(vm);
				}
				catch (Exception err)
				{
					MessageBox.Show(err.Message);
				}
			}

			// If this is a VSView, update the datagrid
			if (tabMain.SelectedTab.Text.IndexOf("@")<0) 
			{
				dgVSView = Utility.getVSViewGrid(conf.vs, dgVSView);
				touchTab();
			}

		}

		private void mnuAddVMView_Click(object sender, System.EventArgs e)
		{
			// Get information from config.xml
			int LastTabIndex = -1;
				
			//XmlDocument xmlDoc = new XmlDocument();
			XmlNodeList nodeList = null;
			
			try
			{
				// Read last TabIndex fromXml
				nodeList = xmlConfig.SelectNodes("//VirtualServer");
				foreach (XmlNode xmlNode in nodeList) 
				{	
					int thisTabIndex = int.Parse(xmlNode.SelectSingleNode("TabIndex").InnerText);
					if ( thisTabIndex> LastTabIndex) 
					{
						LastTabIndex = thisTabIndex;
					}
				}
			}
			catch(XmlException xmlEx)        // Handle the Xml exceptions here.         
			{
				Console.WriteLine("{0}", xmlEx.Message);
			}
			catch(Exception err)              // Handle the generic exceptions. here
			{
				Console.WriteLine("{0}", err.Message);
			}


			// If this VM hasn't been added, add it to global config object
			VMVirtualServer vs = conf.vs;
			VMVirtualMachine vm = conf.vm;
				
			bool existVM = false;
			string newVM = vs.VirtualMachines[dgVSView.CurrentRowIndex+1].Name;


			nodeList = xmlConfig.SelectNodes("//VirtualServer");
			foreach (XmlNode xmlNode in nodeList) 
			{	

				if ( xmlNode.SelectSingleNode("ServerAddress").InnerText == ((vs.VMRCAdminAddress=="")?conf.currentVS:vs.VMRCAdminAddress) &&
					xmlNode.SelectSingleNode("ServerDisplayName").InnerText == newVM) 
				{
					existVM = true;
					MessageBox.Show("This Virtual Machine has already been added to VSPlus.");
					return;
				}
			}


			if (!existVM) 
			{
				// Insert a new node in config.xml
				XmlElement xmlElement = frmMain.xmlConfig.CreateElement("VirtualServer");
				
				XmlElement  newElement = frmMain.xmlConfig.CreateElement("TabIndex");
				newElement.InnerText  = (LastTabIndex+1).ToString();
				xmlElement.AppendChild(newElement);

				newElement = frmMain.xmlConfig.CreateElement("ServerAddress");
				newElement.InnerText = (vs.VMRCAdminAddress=="")?conf.currentVS:vs.VMRCAdminAddress;
				xmlElement.AppendChild(newElement);
			
				newElement = frmMain.xmlConfig.CreateElement("ServerPort");
				newElement.InnerText  = vs.VMRCAdminPortNumber.ToString();
				xmlElement.AppendChild(newElement);
			
				newElement = frmMain.xmlConfig.CreateElement("ServerDisplayName");
				newElement.InnerText = newVM;
				xmlElement.AppendChild(newElement);

				newElement = frmMain.xmlConfig.CreateElement("ViewOnlyMode");
				newElement.InnerText = "false";
				xmlElement.AppendChild(newElement);

				frmMain.xmlConfig.DocumentElement.AppendChild(xmlElement);		

				// Add tabpage in the main form.
				addVMTab((vs.VMRCAdminAddress=="")?conf.currentVS:vs.VMRCAdminAddress, newVM);
			}


		}

		private void mnuVSStartAllVM_Click(object sender, System.EventArgs e)
		{
			VMVirtualServer vs = conf.vs;
			VMVirtualMachine vm = null;
			VMTask task = null;
			sbrMain.ShowPanels = false;

			for (int i=1; i<=vs.VirtualMachines.Count;i++)
			{
				vm = vs.VirtualMachines[i];
				try
				{
					sbrMain.Text = "Turning on " + vm.Name;
					if (vm.State != VMVMState.vmVMState_Running) 
					{
						task = vm.Startup();
						while (!task.IsComplete) 
						{
							Thread.Sleep(100);
						}
					}
					
				}
				catch (Exception err)
				{
					MessageBox.Show(err.Message);
				}
			}

			sbrMain.ShowPanels = true;
		}		
		
		private void mnuVSResetAllVM_Click(object sender, System.EventArgs e)
		{
			VMVirtualServer vs = conf.vs;
			VMVirtualMachine vm = null;
			VMTask task = null;
			sbrMain.ShowPanels = false;

			for (int i=1; i<=vs.VirtualMachines.Count;i++)
			{
				vm = vs.VirtualMachines[i];
				try
				{
					sbrMain.Text = "Resetting " + vm.Name;
					task = vm.Reset();
					while (!task.IsComplete) 
					{
						Thread.Sleep(100);
					}
					
				}
				catch (Exception err)
				{
					MessageBox.Show(err.Message);
				}
			}

			sbrMain.ShowPanels = true;
		}

		private void mnuVSStopAllVM_Click(object sender, System.EventArgs e)
		{
			VMVirtualServer vs = conf.vs;
			VMVirtualMachine vm = null;
			VMTask task = null;
			sbrMain.ShowPanels = false;

			for (int i=1; i<=vs.VirtualMachines.Count;i++)
			{
				vm = vs.VirtualMachines[i];
				try
				{
					sbrMain.Text = "Turning off " + vm.Name;
					if (vm.State!=VMVMState.vmVMState_TurnedOff)
					{
						task = vm.TurnOff();
						while (!task.IsComplete) 
						{
							Thread.Sleep(100);
						}
					}
					
				}
				catch (Exception err)
				{
					MessageBox.Show(err.Message);
				}
			}

			sbrMain.ShowPanels = true;
		}

		private void mnuVSPauseAllVM_Click(object sender, System.EventArgs e)
		{
			VMVirtualServer vs = conf.vs;
			VMVirtualMachine vm = null;
			VMTask task = null;
			sbrMain.ShowPanels = false;

			for (int i=1; i<=vs.VirtualMachines.Count;i++)
			{
				vm = vs.VirtualMachines[i];
				try
				{
					sbrMain.Text = "Pausing " + vm.Name;
					vm.Pause();
				}
				catch (Exception err)
				{
					MessageBox.Show(err.Message);
				}
			}

			sbrMain.ShowPanels = true;
		}

		private void mnuVSShutdownAllVM_Click(object sender, System.EventArgs e)
		{
			VMVirtualServer vs = conf.vs;
			VMVirtualMachine vm = null;
			VMTask task = null;
			sbrMain.ShowPanels = false;

			for (int i=1; i<=vs.VirtualMachines.Count;i++)
			{
				vm = vs.VirtualMachines[i];
				try
				{
					sbrMain.Text = "Shutting down " + vm.Name;
					if (vm.GuestOS.CanShutdown) 
					{
						task = vm.GuestOS.Shutdown();
						while (!task.IsComplete)
						{
							Thread.Sleep(100);
						}
					}
					else
					{
						MessageBox.Show("Virtual Machine " + vm.Name + " cannot be shutdown.");
					}
				}
				catch (Exception err)
				{
					MessageBox.Show(err.Message);
				}
			}

			sbrMain.ShowPanels = true;
		}

		private void mnuVSRestoreAllVM_Click(object sender, System.EventArgs e)
		{
			VMVirtualServer vs = conf.vs;
			VMVirtualMachine vm = null;
			VMTask task = null;
			sbrMain.ShowPanels = false;

			for (int i=1; i<=vs.VirtualMachines.Count;i++)
			{
				vm = vs.VirtualMachines[i];
				try
				{
					sbrMain.Text = "Restoring " + vm.Name;
					vm.Resume();
				}
				catch (Exception err)
				{
					MessageBox.Show(err.Message);
				}
			}

			sbrMain.ShowPanels = true;
		}

		private void mnuReportBug_Click(object sender, System.EventArgs e)
		{
			frmBugReport frmBR = new frmBugReport();
			frmBR.ShowDialog();
		}













		
	}


}



	


