using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.VirtualServer.Interop;
using System.Threading;
using System.Xml;
using System.Text;
using System.Drawing.Imaging;
using System.IO;



namespace VSPlus
{
	/// <summary>
	/// Summary description for Connect.
	/// </summary>
	public class frmAdd : System.Windows.Forms.Form
	{

		// Initialize COM with Impersonate first
		private InitVS myAppAdd;
		// Connect locally or remotely
		private VMVirtualServer myVS;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ImageList imglistThumbnail;
		private System.Windows.Forms.Button btnAddVSView;
		private System.Windows.Forms.DataGrid dgVSView;
		private System.Windows.Forms.Button btnAddVM;
		// Connect to parent form
		private frmMain frmMainAdd;

		// To Display the Thumbnail
		[System.Runtime.InteropServices.DllImport("gdi32.dll")]
		public static extern int CreateBitmap  (int nWidth, int nHeight, int nPlanes, int nBitCount,Object lpBits);


		// Path to config.xml
		static string CONFIGFILE = frmMain.conf.CONFIGFILE;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox txtServerAddress;
		private System.ComponentModel.IContainer components;

		public frmAdd(frmMain frmMain, InitVS myApp)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myAppAdd = myApp;
			frmMainAdd = frmMain;
			
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
			this.txtServerAddress = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnConnect = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.imglistThumbnail = new System.Windows.Forms.ImageList(this.components);
			this.btnAddVSView = new System.Windows.Forms.Button();
			this.dgVSView = new System.Windows.Forms.DataGrid();
			this.btnAddVM = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgVSView)).BeginInit();
			this.SuspendLayout();
			// 
			// txtServerAddress
			// 
			this.txtServerAddress.Location = new System.Drawing.Point(128, 64);
			this.txtServerAddress.Name = "txtServerAddress";
			this.txtServerAddress.Size = new System.Drawing.Size(256, 20);
			this.txtServerAddress.TabIndex = 0;
			this.txtServerAddress.Text = "localhost";
			this.txtServerAddress.TextChanged += new System.EventHandler(this.txtServerAddress_TextChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Virtual Server";
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(432, 64);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(96, 23);
			this.btnConnect.TabIndex = 2;
			this.btnConnect.Text = "Connect";
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			this.btnConnect.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnConnect_MouseDown);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(408, 496);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(112, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Close";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 112);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Available Virtual Machines:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(32, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(480, 40);
			this.label3.TabIndex = 9;
			this.label3.Text = "Please enter the name or IP address of the Virtual Server you want to connect to:" +
				"";
			// 
			// imglistThumbnail
			// 
			this.imglistThumbnail.ImageSize = new System.Drawing.Size(64, 48);
			this.imglistThumbnail.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// btnAddVSView
			// 
			this.btnAddVSView.Enabled = false;
			this.btnAddVSView.Location = new System.Drawing.Point(272, 496);
			this.btnAddVSView.Name = "btnAddVSView";
			this.btnAddVSView.Size = new System.Drawing.Size(112, 23);
			this.btnAddVSView.TabIndex = 11;
			this.btnAddVSView.Text = "Add VS View";
			this.btnAddVSView.Click += new System.EventHandler(this.btnAddVSView_Click);
			// 
			// dgVSView
			// 
			this.dgVSView.DataMember = "";
			this.dgVSView.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgVSView.Location = new System.Drawing.Point(32, 136);
			this.dgVSView.Name = "dgVSView";
			this.dgVSView.Size = new System.Drawing.Size(632, 336);
			this.dgVSView.TabIndex = 12;
			this.dgVSView.Click += new System.EventHandler(this.dgVSView_Click);
			// 
			// btnAddVM
			// 
			this.btnAddVM.Enabled = false;
			this.btnAddVM.Location = new System.Drawing.Point(152, 496);
			this.btnAddVM.Name = "btnAddVM";
			this.btnAddVM.Size = new System.Drawing.Size(88, 23);
			this.btnAddVM.TabIndex = 13;
			this.btnAddVM.Text = "Add VM View";
			this.btnAddVM.Click += new System.EventHandler(this.btnAddVM_Click);
			// 
			// frmAdd
			// 
			this.AcceptButton = this.btnConnect;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(688, 550);
			this.Controls.Add(this.btnAddVM);
			this.Controls.Add(this.dgVSView);
			this.Controls.Add(this.btnAddVSView);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtServerAddress);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnConnect);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmAdd";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add Virtual Machines";
			((System.ComponentModel.ISupportInitialize)(this.dgVSView)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
			
		}

		private void btnConnect_Click(object sender, System.EventArgs e)
		{

			// Connect to the Virtual Server
			try 
			{
				myVS = myAppAdd.GetVMVirtualServerClass(txtServerAddress.Text);
			}
			catch
			{
				MessageBox.Show("Cannot connect to Virtual Server: " + txtServerAddress.Text +
					"\n\n Please make sure the virtual server is running and open firewall ports: UDP 137, TCP 135/3183 for this connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				btnConnect.Text = "Connect";
				btnAddVSView.Enabled = false;
				return;
			}
			btnConnect.Text = "Connect";

			try 
			{
				if (myVS.VirtualMachines.Count>0) 
				{
					dgVSView  = Utility.getVSViewGrid(myVS, dgVSView);	
					dgVSView_Click(this, new System.EventArgs());
				}
				else
				{
					MessageBox.Show("No Virtual Machines found on this Virtual Server");
				}
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
			btnAddVSView.Enabled = true;

		}

		private void btnConnect_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			btnConnect.Text = "Connecting...";			
		}



		private void dgVSView_Click(object sender, System.EventArgs e)
		{
			dgVSView.Select(dgVSView.CurrentCell.RowNumber);
			btnAddVM.Enabled = true;
		}

		private void txtServerAddress_TextChanged(object sender, System.EventArgs e)
		{
			if (txtServerAddress.Text.Length == 0) 
			{
				btnConnect.Enabled = false;
			}
			else 
			{	
				btnConnect.Enabled = true;
			}	
		}

		private void btnAddVSView_Click(object sender, System.EventArgs e)
		{
			// Get information from config.xml
			int LastTabIndex = -1;
			XmlNodeList nodeList = null;

			
			try
			{
				// Read last TabIndex fromXml
				nodeList = frmMain.xmlConfig.SelectNodes("//VirtualServer");
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
			

			// Add tabs and save VS to config.xml
			// If this VS hasn't been added, add it to config.cml

			bool existVS = false;

			nodeList = frmMain.xmlConfig.SelectNodes("//VirtualServer");
			foreach (XmlNode xmlNode in nodeList) 
			{	

				if ( xmlNode.SelectSingleNode("ServerAddress").InnerText == ((myVS.VMRCAdminAddress=="")?txtServerAddress.Text:myVS.VMRCAdminAddress) &&
					xmlNode.SelectSingleNode("ServerDisplayName").InnerText == "Virtual Server") 
				{
					existVS = true;
					MessageBox.Show("This Virtual Server has already been added to VSPlus.");
					return;
				}
			}
			
			if (!existVS) 
			{
				// Insert a new node in config.xml
				XmlElement xmlElement = frmMain.xmlConfig.CreateElement("VirtualServer");
				
				XmlElement  newElement = frmMain.xmlConfig.CreateElement("TabIndex");
				newElement.InnerText  = (LastTabIndex+1).ToString();
				xmlElement.AppendChild(newElement);

				newElement = frmMain.xmlConfig.CreateElement("ServerAddress");
				newElement.InnerText = txtServerAddress.Text;
				xmlElement.AppendChild(newElement);
			
				newElement = frmMain.xmlConfig.CreateElement("ServerPort");
				newElement.InnerText  = myVS.VMRCAdminPortNumber.ToString();
				xmlElement.AppendChild(newElement);
			
				newElement = frmMain.xmlConfig.CreateElement("ServerDisplayName");
				newElement.InnerText = "Virtual Server";
				xmlElement.AppendChild(newElement);

				newElement = frmMain.xmlConfig.CreateElement("ViewOnlyMode");
				newElement.InnerText = "false";
				xmlElement.AppendChild(newElement);

				frmMain.xmlConfig.DocumentElement.AppendChild(xmlElement);		

				// Add tabpage in the main form.
				frmMainAdd.addVSTab(txtServerAddress.Text);
			}
		
		
			// Update global xmlConfig
			//frmMain.xmlConfig = xmlDoc;
			frmMainAdd.touchTab();
		
		}


		private void btnAddVM_Click(object sender, System.EventArgs e)
		{
			if (dgVSView.CurrentRowIndex<0 ) return;

			// Get information from config.xml
			int LastTabIndex = -1;
				
			//XmlDocument xmlDoc = new XmlDocument();
			XmlNodeList nodeList = null;
			
			try
			{
				// Read last TabIndex fromXml
				nodeList = frmMain.xmlConfig.SelectNodes("//VirtualServer");
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
			

			// Add tabs and save VMs to global config object

			// If this VM hasn't been added, add it to global config object

			bool existVM = false;
			string newVM = myVS.VirtualMachines[dgVSView.CurrentRowIndex+1].Name;


			nodeList = frmMain.xmlConfig.SelectNodes("//VirtualServer");
			foreach (XmlNode xmlNode in nodeList) 
			{	

				if ( xmlNode.SelectSingleNode("ServerAddress").InnerText == ((myVS.VMRCAdminAddress=="")?txtServerAddress.Text:myVS.VMRCAdminAddress) &&
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
				newElement.InnerText = (myVS.VMRCAdminAddress=="")?txtServerAddress.Text:myVS.VMRCAdminAddress;
				xmlElement.AppendChild(newElement);
			
				newElement = frmMain.xmlConfig.CreateElement("ServerPort");
				newElement.InnerText  = myVS.VMRCAdminPortNumber.ToString();
				xmlElement.AppendChild(newElement);
			
				newElement = frmMain.xmlConfig.CreateElement("ServerDisplayName");
				newElement.InnerText = newVM;
				xmlElement.AppendChild(newElement);

				newElement = frmMain.xmlConfig.CreateElement("ViewOnlyMode");
				newElement.InnerText = "false";
				xmlElement.AppendChild(newElement);

				frmMain.xmlConfig.DocumentElement.AppendChild(xmlElement);		

				// Add tabpage in the main form.
				frmMainAdd.addVMTab((myVS.VMRCAdminAddress=="")?txtServerAddress.Text:myVS.VMRCAdminAddress, newVM);
			}
		

			// Update global xmlConfig
			//frmMain.xmlConfig = xmlDoc;
			frmMainAdd.touchTab();
			//this.Close();
		}





















	}
}
