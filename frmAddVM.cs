using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.VirtualServer.Interop;

namespace VSPlus
{
	/// <summary>
	/// Summary description for frmAddVM.
	/// </summary>
	public class frmAddVM : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtServerAddress;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox txtConfFile;
		private System.Windows.Forms.OpenFileDialog ofdVMC;

		// Initialize COM with Impersonate first
		private InitVS myApp;
		// Connect locally or remotely
		private VMVirtualServer myVS;


		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmAddVM(InitVS myAppAddVM)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myApp = myAppAddVM;
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
			this.label2 = new System.Windows.Forms.Label();
			this.txtConfFile = new System.Windows.Forms.TextBox();
			this.btnSelect = new System.Windows.Forms.Button();
			this.ofdVMC = new System.Windows.Forms.OpenFileDialog();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtServerAddress
			// 
			this.txtServerAddress.Location = new System.Drawing.Point(136, 32);
			this.txtServerAddress.Name = "txtServerAddress";
			this.txtServerAddress.Size = new System.Drawing.Size(280, 20);
			this.txtServerAddress.TabIndex = 2;
			this.txtServerAddress.Text = "localhost";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Virtual Server";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Fully qualified path to file:";
			// 
			// txtConfFile
			// 
			this.txtConfFile.Location = new System.Drawing.Point(136, 96);
			this.txtConfFile.Name = "txtConfFile";
			this.txtConfFile.Size = new System.Drawing.Size(280, 20);
			this.txtConfFile.TabIndex = 5;
			this.txtConfFile.Text = "";
			// 
			// btnSelect
			// 
			this.btnSelect.Location = new System.Drawing.Point(432, 96);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.TabIndex = 6;
			this.btnSelect.Text = "Select";
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// ofdVMC
			// 
			this.ofdVMC.Filter = "VM Configuration (*.vmc)|*.vmc";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(280, 160);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 7;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(384, 160);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Cancel";
			// 
			// frmAddVM
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(520, 210);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnSelect);
			this.Controls.Add(this.txtConfFile);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtServerAddress);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmAddVM";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add An Existing VM";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnSelect_Click(object sender, System.EventArgs e)
		{
			if(ofdVMC.ShowDialog() == DialogResult.OK)
			{
				string VMCFile = txtConfFile.Text;

				if( ofdVMC.FileName != "") 
				{
					// Insert code to read the stream here.
					txtConfFile.Text = ofdVMC.FileName;
				}
			}
		}
		

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.Enabled = false;
			// Connect to the Virtual Server
			try 
			{
				myVS = myApp.GetVMVirtualServerClass(txtServerAddress.Text);
			}
			catch
			{
				MessageBox.Show("Cannot connect to Virtual Server: " + txtServerAddress.Text);
			}

			try 
			{
				myVS.RegisterVirtualMachine("", txtConfFile.Text);
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
			this.Enabled = true;
			this.Close();
			

		}

	}
}
