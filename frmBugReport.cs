using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;

namespace VSPlus
{
	/// <summary>
	/// Summary description for frmBugReport.
	/// </summary>
	public class frmBugReport : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox txtSubject;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.RichTextBox txtBody;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmBugReport()
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
			this.txtSubject = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.txtBody = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// txtSubject
			// 
			this.txtSubject.Location = new System.Drawing.Point(168, 72);
			this.txtSubject.Name = "txtSubject";
			this.txtSubject.Size = new System.Drawing.Size(488, 20);
			this.txtSubject.TabIndex = 0;
			this.txtSubject.Text = "Comments for VSPlus.";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(48, 72);
			this.label1.Name = "label1";
			this.label1.TabIndex = 1;
			this.label1.Text = "Subject:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(48, 112);
			this.label2.Name = "label2";
			this.label2.TabIndex = 2;
			this.label2.Text = "Body:";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(280, 400);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(392, 400);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(48, 32);
			this.label3.Name = "label3";
			this.label3.TabIndex = 6;
			this.label3.Text = "Mail to:";
			// 
			// textBox1
			// 
			this.textBox1.Enabled = false;
			this.textBox1.Location = new System.Drawing.Point(168, 32);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(320, 20);
			this.textBox1.TabIndex = 7;
			this.textBox1.Text = "jmao@gc.cuny.edu";
			// 
			// txtBody
			// 
			this.txtBody.Location = new System.Drawing.Point(168, 112);
			this.txtBody.Name = "txtBody";
			this.txtBody.Size = new System.Drawing.Size(488, 264);
			this.txtBody.TabIndex = 8;
			this.txtBody.Text = "";
			// 
			// frmBugReport
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(680, 442);
			this.Controls.Add(this.txtBody);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtSubject);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmBugReport";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Report A Bug";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			string toEmail = "jmao@gc.cuny.edu";
			string subject = txtSubject.Text;
			string body = txtBody.Text;
			string message = string.Format( "mailto:{0}?subject={1}&body={2}", toEmail, subject, body );
			Process.Start( message ); 
		}
	}
}
