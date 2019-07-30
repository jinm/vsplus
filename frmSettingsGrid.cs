using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace VSPlus
{
	/// <summary>
	/// Summary description for frmSettingsGrid.
	/// </summary>
	public class frmSettingsGrid : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.PropertyGrid pgridSettings;
		private bool PropertyGridChanged = false;
		private AppConfig appSettings = new AppConfig();
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSettingsGrid()
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
			this.pgridSettings = new System.Windows.Forms.PropertyGrid();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnApply = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// pgridSettings
			// 
			this.pgridSettings.CommandsVisibleIfAvailable = true;
			this.pgridSettings.Dock = System.Windows.Forms.DockStyle.Top;
			this.pgridSettings.LargeButtons = false;
			this.pgridSettings.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.pgridSettings.Location = new System.Drawing.Point(0, 0);
			this.pgridSettings.Name = "pgridSettings";
			this.pgridSettings.Size = new System.Drawing.Size(480, 296);
			this.pgridSettings.TabIndex = 0;
			this.pgridSettings.Text = "pgridSettings";
			this.pgridSettings.ViewBackColor = System.Drawing.SystemColors.Window;
			this.pgridSettings.ViewForeColor = System.Drawing.SystemColors.WindowText;
			this.pgridSettings.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgridSettings_PropertyValueChanged);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(200, 312);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnApply
			// 
			this.btnApply.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnApply.Enabled = false;
			this.btnApply.Location = new System.Drawing.Point(288, 312);
			this.btnApply.Name = "btnApply";
			this.btnApply.TabIndex = 1;
			this.btnApply.Text = "Apply";
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(376, 312);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmSettingsGrid
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(480, 350);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.pgridSettings);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.btnCancel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSettingsGrid";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "VSPlus Configuration Settings";
			this.Load += new System.EventHandler(this.frmSettingsGrid_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmSettingsGrid_Load(object sender, System.EventArgs e)
		{
			appSettings = frmMain.conf;
			pgridSettings.SelectedObject = appSettings;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			if (PropertyGridChanged) 
			{
				DialogResult result;
				result = MessageBox.Show("Discard changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
				if (result == DialogResult.Yes) 
				{	// Quit
					this.Close();
				}
			}
			else
			{
				this.Close();
			}
		}

		private void btnApply_Click(object sender, System.EventArgs e)
		{
		//	
			frmMain.conf.ConfigUpdated = true;
			frmMain.conf = appSettings;

			// Save to Global Configuration Object
			frmMain.conf.UpdateAppConfig();

			// Save to Configuration File
			frmMain.xmlConfig.Save(frmMain.conf.CONFIGFILE);


		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
				
		}

		private void pgridSettings_PropertyValueChanged(object s, System.Windows.Forms.PropertyValueChangedEventArgs e)
		{
			
			PropertyGridChanged = true;
			btnApply.Enabled = true;
		}
	}


}
