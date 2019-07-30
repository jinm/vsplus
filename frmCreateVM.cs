using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.VirtualServer.Interop;
using System.Threading;
using System.IO;

namespace VSPlus
{
	/// <summary>
	/// Summary description for frmCreateVM.
	/// </summary>
	public class frmCreateVM : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RadioButton rdbCreateVHD;
		private System.Windows.Forms.RadioButton rdbSelectVHD;
		private System.Windows.Forms.RadioButton rdbNoVHD;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox txtVMName;
		private System.Windows.Forms.TextBox txtMemory;
		private System.Windows.Forms.TextBox txtVHDSize;
		private System.Windows.Forms.ComboBox cmbVHDScale;
		private System.Windows.Forms.TextBox txtVHDPath;
		private System.Windows.Forms.ComboBox cmbNetworkAdapter;


		// Initialize COM with Impersonate first
		private InitVS myApp;
		// Connect locally or remotely
		private VMVirtualServer myVS;

		private string thisVSAddress;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtVirtualServer;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblMemoryNote;
		private System.Windows.Forms.OpenFileDialog ofdVHD;
		private System.Windows.Forms.Label lblConnecting;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.Button btnOK;


		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCreateVM(string ServerAddress, InitVS myAppCreateVM)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myApp = myAppCreateVM;
			if (ServerAddress=="")
			{
				txtVirtualServer.Text = "localhost";
			}
			else
			{
				txtVirtualServer.Text = ServerAddress;
			}
			thisVSAddress = ServerAddress;
			
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtVMName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtMemory = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.rdbCreateVHD = new System.Windows.Forms.RadioButton();
			this.rdbSelectVHD = new System.Windows.Forms.RadioButton();
			this.rdbNoVHD = new System.Windows.Forms.RadioButton();
			this.txtVHDSize = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbVHDScale = new System.Windows.Forms.ComboBox();
			this.txtVHDPath = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cmbNetworkAdapter = new System.Windows.Forms.ComboBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.txtVirtualServer = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.lblMemoryNote = new System.Windows.Forms.Label();
			this.ofdVHD = new System.Windows.Forms.OpenFileDialog();
			this.lblConnecting = new System.Windows.Forms.Label();
			this.btnSelect = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 152);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Virtual Machine Name";
			// 
			// txtVMName
			// 
			this.txtVMName.Location = new System.Drawing.Point(176, 152);
			this.txtVMName.Name = "txtVMName";
			this.txtVMName.Size = new System.Drawing.Size(232, 20);
			this.txtVMName.TabIndex = 2;
			this.txtVMName.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 200);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(128, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "Memory (in MB)";
			// 
			// txtMemory
			// 
			this.txtMemory.Location = new System.Drawing.Point(184, 200);
			this.txtMemory.Name = "txtMemory";
			this.txtMemory.Size = new System.Drawing.Size(64, 20);
			this.txtMemory.TabIndex = 3;
			this.txtMemory.Text = "128";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 288);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "Virtual Hard Disk";
			// 
			// rdbCreateVHD
			// 
			this.rdbCreateVHD.Checked = true;
			this.rdbCreateVHD.Location = new System.Drawing.Point(160, 280);
			this.rdbCreateVHD.Name = "rdbCreateVHD";
			this.rdbCreateVHD.Size = new System.Drawing.Size(184, 24);
			this.rdbCreateVHD.TabIndex = 4;
			this.rdbCreateVHD.TabStop = true;
			this.rdbCreateVHD.Text = "Create a new virtual hard disk";
			// 
			// rdbSelectVHD
			// 
			this.rdbSelectVHD.Location = new System.Drawing.Point(160, 328);
			this.rdbSelectVHD.Name = "rdbSelectVHD";
			this.rdbSelectVHD.Size = new System.Drawing.Size(184, 24);
			this.rdbSelectVHD.TabIndex = 7;
			this.rdbSelectVHD.Text = "Use an existing virtual hard disk";
			// 
			// rdbNoVHD
			// 
			this.rdbNoVHD.Location = new System.Drawing.Point(160, 408);
			this.rdbNoVHD.Name = "rdbNoVHD";
			this.rdbNoVHD.Size = new System.Drawing.Size(216, 24);
			this.rdbNoVHD.TabIndex = 10;
			this.rdbNoVHD.Text = "Attach a virtual hard disk later (None)";
			// 
			// txtVHDSize
			// 
			this.txtVHDSize.Location = new System.Drawing.Point(392, 280);
			this.txtVHDSize.Name = "txtVHDSize";
			this.txtVHDSize.TabIndex = 5;
			this.txtVHDSize.Text = "16";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(344, 280);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "Size";
			// 
			// cmbVHDScale
			// 
			this.cmbVHDScale.Items.AddRange(new object[] {
															 "GB",
															 "MB"});
			this.cmbVHDScale.Location = new System.Drawing.Point(504, 280);
			this.cmbVHDScale.MaxDropDownItems = 2;
			this.cmbVHDScale.Name = "cmbVHDScale";
			this.cmbVHDScale.Size = new System.Drawing.Size(64, 21);
			this.cmbVHDScale.TabIndex = 6;
			this.cmbVHDScale.Text = "GB";
			// 
			// txtVHDPath
			// 
			this.txtVHDPath.Location = new System.Drawing.Point(176, 360);
			this.txtVHDPath.Name = "txtVHDPath";
			this.txtVHDPath.Size = new System.Drawing.Size(392, 20);
			this.txtVHDPath.TabIndex = 8;
			this.txtVHDPath.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(24, 456);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(136, 23);
			this.label5.TabIndex = 10;
			this.label5.Text = "Virtual network adapter";
			// 
			// cmbNetworkAdapter
			// 
			this.cmbNetworkAdapter.Location = new System.Drawing.Point(168, 488);
			this.cmbNetworkAdapter.Name = "cmbNetworkAdapter";
			this.cmbNetworkAdapter.Size = new System.Drawing.Size(392, 21);
			this.cmbNetworkAdapter.TabIndex = 11;
			this.cmbNetworkAdapter.Text = "Not connected";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(536, 584);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 13;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(40, 104);
			this.label6.Name = "label6";
			this.label6.TabIndex = 14;
			this.label6.Text = "Virtual Server";
			// 
			// txtVirtualServer
			// 
			this.txtVirtualServer.Location = new System.Drawing.Point(176, 104);
			this.txtVirtualServer.Name = "txtVirtualServer";
			this.txtVirtualServer.Size = new System.Drawing.Size(232, 20);
			this.txtVirtualServer.TabIndex = 1;
			this.txtVirtualServer.Text = "";
			this.txtVirtualServer.Leave += new System.EventHandler(this.txtVirtualServer_Leave);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(160, 456);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(496, 32);
			this.label7.TabIndex = 16;
			this.label7.Text = "A virtual machine is preconfigured with one Ethernet network adapter that can be " +
				"connected to a virtual network.";
			// 
			// lblMemoryNote
			// 
			this.lblMemoryNote.Location = new System.Drawing.Point(288, 200);
			this.lblMemoryNote.Name = "lblMemoryNote";
			this.lblMemoryNote.Size = new System.Drawing.Size(312, 32);
			this.lblMemoryNote.TabIndex = 17;
			// 
			// lblConnecting
			// 
			this.lblConnecting.Location = new System.Drawing.Point(424, 104);
			this.lblConnecting.Name = "lblConnecting";
			this.lblConnecting.Size = new System.Drawing.Size(144, 23);
			this.lblConnecting.TabIndex = 18;
			// 
			// btnSelect
			// 
			this.btnSelect.Location = new System.Drawing.Point(584, 360);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(80, 23);
			this.btnSelect.TabIndex = 19;
			this.btnSelect.Text = "Select";
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(432, 584);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 20;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click_1);
			// 
			// frmCreateVM
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(688, 626);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnSelect);
			this.Controls.Add(this.lblConnecting);
			this.Controls.Add(this.lblMemoryNote);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtVirtualServer);
			this.Controls.Add(this.txtVHDPath);
			this.Controls.Add(this.txtVHDSize);
			this.Controls.Add(this.txtVMName);
			this.Controls.Add(this.txtMemory);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.cmbNetworkAdapter);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.cmbVHDScale);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.rdbNoVHD);
			this.Controls.Add(this.rdbSelectVHD);
			this.Controls.Add(this.rdbCreateVHD);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmCreateVM";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Create Virtual Machine";
			this.Load += new System.EventHandler(this.frmCreateVM_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmCreateVM_Load(object sender, System.EventArgs e)
		{
			// Load information
			

		}


		private void btnOK_Click(object sender, System.EventArgs e)
		{
			try 
			{
				myVS.CreateVirtualMachine(txtVMName.Text, myVS.DefaultVMConfigurationPath + "\\" + txtVMName.Text);
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
			}

		}

		private void txtVirtualServer_Leave(object sender, System.EventArgs e)
		{
			// Connect to the Virtual Server

			lblConnecting.Text = "Connecting...";
			
			try 
			{
				myVS = myApp.GetVMVirtualServerClass(txtVirtualServer.Text);
				lblConnecting.Text = "";
				lblMemoryNote.Text = "The amount of memory can be from " +  myVS.MinimumMemoryPerVM + " MB through " + myVS.MaximumMemoryPerVM + " MB (" + myVS.SuggestedMaximumMemoryPerVM + " MB is the maximum recommended value).";

			}
			catch (Exception err)
			{
				//MessageBox.Show("Cannot connect to Virtual Server: " + txtVirtualServer.Text);
				MessageBox.Show(err.Message);
				txtVirtualServer.Focus();
			}

//			lblConnecting.Text = "";
//			lblMemoryNote.Text = "The amount of memory can be from " +  myVS.MinimumMemoryPerVM + " MB through " + myVS.MaximumMemoryPerVM + " MB (" + myVS.SuggestedMaximumMemoryPerVM + " MB is the maximum recommended value).";

		}

		private void btnSelect_Click(object sender, System.EventArgs e)
		{
			if(ofdVHD.ShowDialog() == DialogResult.OK)
			{
				string VHDFile = txtVHDPath.Text;

				if( ofdVHD.FileName != "") 
				{
					// Insert code to read the stream here.
					txtVHDPath.Text = ofdVHD.FileName;
				}
			}
		}

		private void btnOK_Click_1(object sender, System.EventArgs e)
		{
			try 
			{
				myVS.CreateVirtualMachine(txtVMName.Text, myVS.DefaultVMConfigurationPath + "\\" + txtVMName.Text);
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}






	}
}
