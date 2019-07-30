using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection ;
using System.Diagnostics;

namespace VSPlus
{
	/// <summary>
	/// Summary description for frmAbout.
	/// </summary>
	public class frmAbout : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblVersion;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmAbout()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAbout));
			this.label1 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.lblVersion = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(56, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 40);
			this.label1.TabIndex = 0;
			this.label1.Text = "VSPlus";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(192, 200);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(88, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "Author:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblVersion
			// 
			this.lblVersion.Location = new System.Drawing.Point(200, 33);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(144, 23);
			this.lblVersion.TabIndex = 4;
			this.lblVersion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// label5
			// 
			this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
			this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label5.Location = new System.Drawing.Point(152, 153);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(216, 23);
			this.label5.TabIndex = 6;
			this.label5.Text = "New York .NET Developers Group";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label5.Click += new System.EventHandler(this.label5_Click);
			this.label5.MouseHover += new System.EventHandler(this.label5_MouseHover);
			this.label5.MouseLeave += new System.EventHandler(this.label5_MouseLeave);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(48, 120);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(96, 24);
			this.label6.TabIndex = 7;
			this.label6.Text = "I am a member of ";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
			this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label4.Location = new System.Drawing.Point(152, 120);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(256, 24);
			this.label4.TabIndex = 5;
			this.label4.Text = "New York Enterprise Windows User Group";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label4.Click += new System.EventHandler(this.label4_Click);
			this.label4.MouseHover += new System.EventHandler(this.label4_MouseHover);
			this.label4.MouseLeave += new System.EventHandler(this.label4_MouseLeave);
			// 
			// label3
			// 
			this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
			this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label3.Location = new System.Drawing.Point(152, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(168, 24);
			this.label3.TabIndex = 9;
			this.label3.Text = "jmao@gc.cuny.edu";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label3.Click += new System.EventHandler(this.label3_Click);
			this.label3.MouseHover += new System.EventHandler(this.label3_MouseHover);
			this.label3.MouseLeave += new System.EventHandler(this.label3_MouseLeave);
			// 
			// frmAbout
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(442, 255);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lblVersion);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmAbout";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "About VSPlus";
			this.Load += new System.EventHandler(this.frmAbout_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmAbout_Load(object sender, System.EventArgs e)
		{
			lblVersion.Text = "Version: " + Assembly.GetExecutingAssembly().GetName().Version.Major + "." +
								Assembly.GetExecutingAssembly().GetName().Version.Minor + "." +
								Assembly.GetExecutingAssembly().GetName().Version.Build;
		}


		private void label4_Click(object sender, System.EventArgs e)
		{
			Process.Start("http://www.nyewin.org");
		}

		private void label5_Click(object sender, System.EventArgs e)
		{
			Process.Start("http://www.nycdotnetdev.com");
		}

		private void label3_Click(object sender, System.EventArgs e)
		{
			Process.Start("mailto:jmao@gc.cuny.edu");
		}

		private void label3_MouseHover(object sender, System.EventArgs e)
		{
			label3.ForeColor = Color.Red;
		}

		private void label4_MouseHover(object sender, System.EventArgs e)
		{
			label4.ForeColor = Color.Red;
		}

		private void label5_MouseHover(object sender, System.EventArgs e)
		{
			label5.ForeColor = Color.Red;
		}

		private void label5_MouseLeave(object sender, System.EventArgs e)
		{
			label5.ForeColor = Color.Black;
		}

		private void label4_MouseLeave(object sender, System.EventArgs e)
		{
			label4.ForeColor = Color.Black;
		}

		private void label3_MouseLeave(object sender, System.EventArgs e)
		{
			label3.ForeColor = Color.Black;
		}

	}
}
