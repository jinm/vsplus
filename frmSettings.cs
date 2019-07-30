using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml;
using System.Text;

namespace VSPlus
{
	/// <summary>
	/// Summary description for frmSettings.
	/// </summary>
	public class frmSettings : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ComboBox cmbRefreshInterval;

		private XmlNode node = null;
		private System.Windows.Forms.CheckBox ckbCheckUpdate;
		private System.Windows.Forms.GroupBox groupBox1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSettings()
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
			this.cmbRefreshInterval = new System.Windows.Forms.ComboBox();
			this.ckbCheckUpdate = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(216, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Interval to refresh VM status: (in seconds) ";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(288, 272);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(384, 272);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// cmbRefreshInterval
			// 
			this.cmbRefreshInterval.Items.AddRange(new object[] {
																	"2",
																	"5",
																	"10",
																	"15",
																	"30",
																	"60"});
			this.cmbRefreshInterval.Location = new System.Drawing.Point(240, 32);
			this.cmbRefreshInterval.Name = "cmbRefreshInterval";
			this.cmbRefreshInterval.Size = new System.Drawing.Size(48, 21);
			this.cmbRefreshInterval.TabIndex = 4;
			this.cmbRefreshInterval.Text = "2";
			this.cmbRefreshInterval.TextChanged += new System.EventHandler(this.cmbRefreshInterval_TextChanged);
			this.cmbRefreshInterval.SelectedIndexChanged += new System.EventHandler(this.cmbRefreshInterval_SelectedIndexChanged);
			// 
			// ckbCheckUpdate
			// 
			this.ckbCheckUpdate.Checked = true;
			this.ckbCheckUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckbCheckUpdate.Location = new System.Drawing.Point(16, 56);
			this.ckbCheckUpdate.Name = "ckbCheckUpdate";
			this.ckbCheckUpdate.Size = new System.Drawing.Size(224, 24);
			this.ckbCheckUpdate.TabIndex = 5;
			this.ckbCheckUpdate.Text = "Automatically check updates on exiting";
			this.ckbCheckUpdate.CheckedChanged += new System.EventHandler(this.ckbCheckUpdate_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cmbRefreshInterval);
			this.groupBox1.Controls.Add(this.ckbCheckUpdate);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(16, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(464, 240);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Settings";
			// 
			// frmSettings
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(496, 310);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSettings";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "VSPlus Settings";
			this.Load += new System.EventHandler(this.frmSettings_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{	
			// Update xmlConfig
			node = frmMain.xmlConfig.SelectSingleNode("//Configuration//RefreshInterval");
			node.InnerText = cmbRefreshInterval.Text;

			node = frmMain.xmlConfig.SelectSingleNode("//Configuration//CheckUpdateOnExiting");
			node.InnerText = ckbCheckUpdate.Checked.ToString();

			// Save to Global Configuration Object
			frmMain.conf.UpdateAppConfig();

			// Save to Configuration File
			frmMain.xmlConfig.Save(frmMain.conf.CONFIGFILE);

			this.Close();
		}

		private void cmbRefreshInterval_TextChanged(object sender, System.EventArgs e)
		{
			if (Regex.IsMatch(cmbRefreshInterval.Text,"[^0-9]")) 
			{
				MessageBox.Show("Please enter an integer for refreshing interval.");
				cmbRefreshInterval.Text = "2";
				cmbRefreshInterval.Focus();
			}

		}

		private void frmSettings_Load(object sender, System.EventArgs e)
		{
			// Load Configuration.
	
			node = frmMain.xmlConfig.SelectSingleNode("//Configuration//RefreshInterval");
			cmbRefreshInterval.Text = node.InnerText;

			node = frmMain.xmlConfig.SelectSingleNode("//Configuration//CheckUpdateOnExiting");
			if (node.InnerText == "true") 
			{
				ckbCheckUpdate.Checked = true;
			}
			else
			{
				ckbCheckUpdate.Checked = false;
			}

		}

		private void cmbRefreshInterval_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			frmMain.conf.ConfigUpdated = true;
		}

		private void ckbCheckUpdate_CheckedChanged(object sender, System.EventArgs e)
		{
			frmMain.conf.ConfigUpdated = true;
		}




	}
}
