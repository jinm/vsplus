using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.VirtualServer.Interop;

namespace VSPlus
{
	/// <summary>
	/// Summary description for frmConnectVS.
	/// </summary>
	public class frmConnectVS : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		public string thisVSAddress;
		private System.Windows.Forms.TextBox txtVSAddress;

		// Initialize COM with Impersonate first
		private System.Windows.Forms.Label label2;



		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmConnectVS(string VSAddress, InitVS myApp)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			thisVSAddress = VSAddress;

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
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.txtVSAddress = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Virtual Server";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(152, 104);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(240, 104);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// txtVSAddress
			// 
			this.txtVSAddress.Location = new System.Drawing.Point(136, 64);
			this.txtVSAddress.Name = "txtVSAddress";
			this.txtVSAddress.Size = new System.Drawing.Size(160, 20);
			this.txtVSAddress.TabIndex = 3;
			this.txtVSAddress.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(280, 32);
			this.label2.TabIndex = 4;
			this.label2.Text = "Please enter the name or IP address of the Virtual Server you want to connect to:" +
				"";
			// 
			// frmConnectVS
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(336, 142);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtVSAddress);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmConnectVS";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Connect to...";
			this.Load += new System.EventHandler(this.frmConnectVS_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		public string getVSAddress() 
		{
			this.ShowDialog();
			return txtVSAddress.Text;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			// Return empty value to cancel this action
			txtVSAddress.Text = "";
			this.Close();
		}

		private void frmConnectVS_Load(object sender, System.EventArgs e)
		{
			// Value passed from frmMain.
			if (thisVSAddress == "") 
			{
				txtVSAddress.Text = "localhost";
			}
			else 
			{
				txtVSAddress.Text = thisVSAddress;
			}
			txtVSAddress.Focus();
		}
	}
}
