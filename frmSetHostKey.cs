using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace VSPlus
{
	/// <summary>
	/// Summary description for SetHostKey.
	/// </summary>
	public class frmSetHostKey : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ComboBox cmbHostkey;
		private AxVMRCClientControlLib.AxVMRCClientControl myVMRC;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSetHostKey(AxVMRCClientControlLib.AxVMRCClientControl VMRC)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myVMRC = VMRC;
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
			this.label2 = new System.Windows.Forms.Label();
			this.cmbHostkey = new System.Windows.Forms.ComboBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(344, 48);
			this.label1.TabIndex = 0;
			this.label1.Text = "Choose a host key. When the host key is pressed, any other keys you press will no" +
				"t be sent to the VMRC server. This allows you to use keyboard accelerators local" +
				"ly.";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(56, 88);
			this.label2.Name = "label2";
			this.label2.TabIndex = 1;
			this.label2.Text = "Choose host key:";
			// 
			// cmbHostkey
			// 
			this.cmbHostkey.Items.AddRange(new object[] {
															"Application",
															"Left Alt",
															"Left Ctrl",
															"Left Shift",
															"Right Alt",
															"Right Ctrl",
															"Right Shift"});
			this.cmbHostkey.Location = new System.Drawing.Point(168, 88);
			this.cmbHostkey.Name = "cmbHostkey";
			this.cmbHostkey.Size = new System.Drawing.Size(152, 21);
			this.cmbHostkey.TabIndex = 2;
			this.cmbHostkey.Text = "Right Alt";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(192, 136);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(280, 136);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.button2_Click);
			// 
			// frmSetHostKey
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(392, 173);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.cmbHostkey);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSetHostKey";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Set Host Key";
			this.ResumeLayout(false);

		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			switch (cmbHostkey.Text) 
			{
				case "Application":
					myVMRC.HostKey = "Key_Application";
					break;
				case "Left Alt":
					myVMRC.HostKey = "Key_LeftAlt";
					break;
				case "Left Ctrl":
					myVMRC.HostKey = "Key_LeftCtrl";
					break;
				case "Left Shift":
					myVMRC.HostKey = "Key_LeftShift";
					break;
				case "Right Alt":
					myVMRC.HostKey = "Key_RightAlt";
					break;
				case "Right Ctrl":
					myVMRC.HostKey = "Key_RightCtrl";
					break;
				case "Right Shift":
					myVMRC.HostKey = "Key_RightShift";
					break;
				default:
					break;
			}

			this.Close();
		}
	}
}
