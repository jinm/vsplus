using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.VirtualServer.Interop;
using System.Threading;
using System.Xml;
using System.Text ;
using System.IO;



namespace VSPlus
{
	/// <summary>
	/// Summary description for Connect.
	/// </summary>
	public class frmRemoveVM : System.Windows.Forms.Form
	{

		// Initialize COM with Impersonate first
		private InitVS myApp;
		// Connect locally or remotely
		private VMVirtualServer myVS;
		// Connect to parent form
		private frmMain frmMainRemove;

		// Path to config.xml
		static string CONFIGFILE = frmMain.conf.CONFIGFILE;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox lstVM;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox txtServerAddress;
		private System.Windows.Forms.Button btnRemove;




		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmRemoveVM(frmMain frmMain, InitVS myAppAdd)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myApp = myAppAdd;
			frmMainRemove = frmMain;
			
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
			this.txtServerAddress = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnConnect = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.lstVM = new System.Windows.Forms.ListBox();
			this.btnRemove = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtServerAddress
			// 
			this.txtServerAddress.Location = new System.Drawing.Point(144, 27);
			this.txtServerAddress.Name = "txtServerAddress";
			this.txtServerAddress.Size = new System.Drawing.Size(256, 20);
			this.txtServerAddress.TabIndex = 0;
			this.txtServerAddress.Text = "localhost";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Virtual Server";
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(192, 80);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(112, 23);
			this.btnConnect.TabIndex = 2;
			this.btnConnect.Text = "Connect";
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			this.btnConnect.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnConnect_MouseDown);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(312, 344);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(112, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Close";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 144);
			this.label2.Name = "label2";
			this.label2.TabIndex = 4;
			this.label2.Text = "Virtual Machines:";
			// 
			// lstVM
			// 
			this.lstVM.HorizontalScrollbar = true;
			this.lstVM.Location = new System.Drawing.Point(152, 144);
			this.lstVM.Name = "lstVM";
			this.lstVM.Size = new System.Drawing.Size(256, 173);
			this.lstVM.TabIndex = 5;
			this.lstVM.SelectedIndexChanged += new System.EventHandler(this.lstVM_SelectedIndexChanged);
			// 
			// btnRemove
			// 
			this.btnRemove.Enabled = false;
			this.btnRemove.Location = new System.Drawing.Point(184, 344);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(104, 23);
			this.btnRemove.TabIndex = 6;
			this.btnRemove.Text = "Remove";
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// frmRemoveVM
			// 
			this.AcceptButton = this.btnConnect;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(456, 378);
			this.Controls.Add(this.txtServerAddress);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.lstVM);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnConnect);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmRemoveVM";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Remove Virtual Machines";
			this.Load += new System.EventHandler(this.frmAdd_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
			
		}



		private void btnConnect_Click(object sender, System.EventArgs e)
		{
			lstVM.Items.Clear();
			
			// Connect to the Virtual Server
			try 
			{
				myVS = myApp.GetVMVirtualServerClass(txtServerAddress.Text);
			}
			catch
			{
				MessageBox.Show("Cannot connect to Virtual Server: " + txtServerAddress.Text +
					"\n\n Please open UDP 137/138, TCP 135/1050 for this connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				btnConnect.Text = "Connect";
				return;
			}
			btnConnect.Text = "Connect";


			// List all existing virtual machines
			if (myVS.VirtualMachines.Count >0 ) 
			{
				for(int i=1; i<=myVS.VirtualMachines.Count; i++) 
				{
					lstVM.Items.Add(myVS.VirtualMachines[i].Name.ToString());
				}
				btnRemove.Enabled = true;
			}


		}

		private void frmAdd_Load(object sender, System.EventArgs e)
		{
		

		}

		private void btnConnect_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			btnConnect.Text = "Connecting...";
			lstVM.Items.Clear();
			
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			btnRemove.Enabled = false;
			if (MessageBox.Show ("Configuration file and all VHD files in the VM folder might be deleted! Are you sure?", 
				"Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) 
			{
				return;
			}

			// Get information from config.xml
//			XmlDocument xmlDoc = new XmlDocument();
//			
//			try
//			{
//				// Load config.xml
//				xmlDoc.Load(CONFIGFILE);
//			}
//			catch(XmlException xmlEx)        // Handle the Xml exceptions here.         
//			{
//				Console.WriteLine("{0}", xmlEx.Message);
//			}
//			catch(Exception ex)              // Handle the generic exceptions. here
//			{
//				Console.WriteLine("{0}", ex.Message);
//			}
			


			// If this VM hasn't been added, add it to config.cml
			bool existVM = false;
			int VMIndex = -1;
			int tabIndex = 0;
			XmlNodeList nodeList = frmMain.xmlConfig.SelectNodes("//VirtualServer");
			for (int i=0; i<nodeList.Count; i++)
			{	
				if ( nodeList[i].SelectSingleNode("ServerAddress").InnerText  == txtServerAddress.Text &&
					nodeList[i].SelectSingleNode("ServerDisplayName").InnerText  == lstVM.Items[lstVM.SelectedIndex].ToString()) 
				{
					existVM = true;
					tabIndex = i;

				}
				
			}
			
			// Find out the VM index 
			try 
			{
				if (myVS.VirtualMachines.Count >0 ) 
				{
					for(int i=1; i<=myVS.VirtualMachines.Count; i++) 
					{	
						if (myVS.VirtualMachines[i].Name == lstVM.Items[lstVM.SelectedIndex].ToString()) 
						{
							VMIndex = i;
							
							break;
						}
					}
				}

			}
			catch
			{
				MessageBox.Show("Cannot connect to Virtual Server.");
			}


			
			// Process
			if (existVM) 
			{
				// Stop and Remove it from VS
				// Get State of this VM. If it is running, turn it off.
				VMVMState  thisVMState = myVS.VirtualMachines[VMIndex].State;
				if (thisVMState != VMVMState.vmVMState_TurnedOff && thisVMState != VMVMState.vmVMState_Saved) 
				{
					myVS.VirtualMachines[VMIndex].TurnOff();
					while (myVS.VirtualMachines[VMIndex].State != VMVMState.vmVMState_TurnedOff) 
					{
						Thread.Sleep(100);
					}	

				}

				// Remove from tabMain.
				frmMainRemove.removeTab(tabIndex);
				
				// Update Config
				nodeList[tabIndex].ParentNode.RemoveChild(nodeList[tabIndex]);
			} 
		
			// UnregisterVirtualMachine will remove the VM folder permanently.
			// .vhd stored at another location will not be deleted.
			// Save it first might be a good idea.
			string ConfFile = myVS.VirtualMachines[VMIndex].File;
			string ConfFilePath = ConfFile.Substring(0,(ConfFile.IndexOf(myVS.VirtualMachines[VMIndex].Name+".vmc"))-1 );
						
			myVS.UnregisterVirtualMachine(myVS.VirtualMachines[VMIndex]);
//
//			xmlDoc.PreserveWhitespace = true;
//			XmlTextWriter wrtr = new XmlTextWriter("config.xml", Encoding.UTF8);
//			wrtr.Formatting = Formatting.Indented ; 
//			xmlDoc.WriteTo(wrtr);
//			wrtr.Close();

			
			// Reload config.xml to reorder tabindex
			// Question: Why do I have to save XML first and reload?
//			xmlDoc.Load(CONFIGFILE);
			nodeList = frmMain.xmlConfig.SelectNodes("//VirtualServer");
			for(int i=0; i<nodeList.Count;i++)  
			{	
				nodeList[i].SelectSingleNode("TabIndex").InnerText = i.ToString();
			}
			frmMain.conf.ConfigUpdated = true;
			//xmlDoc.Save(CONFIGFILE);
		
			if (frmMainRemove.tabMain.TabPages.Count>0) 
			{
				frmMainRemove.touchTab();
			}

			btnConnect_Click(this, new System.EventArgs());

		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void lstVM_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			btnRemove.Enabled = true;
		}


	}
}
