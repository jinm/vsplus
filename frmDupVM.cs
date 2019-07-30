using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.VirtualServer.Interop;
using System.IO;
using System.Management;
using System.Threading;

namespace VSPlus
{
	/// <summary>
	/// Summary description for frmDupVM.
	/// </summary>
	public class frmDupVM : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnDupVM;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.FolderBrowserDialog fbdMain;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label lblVMName;
		private System.Windows.Forms.Label lblVMPath;
		private System.Windows.Forms.Label lblVMState;
		private System.Windows.Forms.Label lblVMSize;
		private System.Windows.Forms.TextBox txtNewVMName;
		private System.Windows.Forms.TextBox txtNewVMPath;
		private System.Windows.Forms.CheckBox ckbRegisterVM;
		private System.Windows.Forms.CheckBox ckbTurnOnVM;
		private System.Windows.Forms.ProgressBar pbarMain;

		private VMVirtualMachine vm;
		private VMVirtualServer	vs;
		private VMVirtualMachine newvm;
		private System.Windows.Forms.Label lblProgress;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblFreeSpace;
		private System.Windows.Forms.Button btnClose;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDupVM(string currentVS, string currentVM)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			vs = Utility.getVS(currentVS);
			vm = Utility.getVM(currentVS, currentVM);
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
			this.lblVMName = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnDupVM = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.lblVMPath = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.lblVMState = new System.Windows.Forms.Label();
			this.lblVMSize = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.txtNewVMName = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtNewVMPath = new System.Windows.Forms.TextBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.ckbRegisterVM = new System.Windows.Forms.CheckBox();
			this.ckbTurnOnVM = new System.Windows.Forms.CheckBox();
			this.fbdMain = new System.Windows.Forms.FolderBrowserDialog();
			this.pbarMain = new System.Windows.Forms.ProgressBar();
			this.label11 = new System.Windows.Forms.Label();
			this.lblProgress = new System.Windows.Forms.Label();
			this.lblFreeSpace = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name:";
			// 
			// lblVMName
			// 
			this.lblVMName.Location = new System.Drawing.Point(88, 24);
			this.lblVMName.Name = "lblVMName";
			this.lblVMName.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblVMSize);
			this.groupBox1.Controls.Add(this.lblVMState);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.lblVMPath);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.lblVMName);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(16, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(568, 176);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Source VM";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.lblFreeSpace);
			this.groupBox2.Controls.Add(this.ckbTurnOnVM);
			this.groupBox2.Controls.Add(this.ckbRegisterVM);
			this.groupBox2.Controls.Add(this.btnBrowse);
			this.groupBox2.Controls.Add(this.txtNewVMPath);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.txtNewVMName);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Location = new System.Drawing.Point(16, 216);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(568, 240);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Destination VM";
			// 
			// btnDupVM
			// 
			this.btnDupVM.Location = new System.Drawing.Point(392, 496);
			this.btnDupVM.Name = "btnDupVM";
			this.btnDupVM.TabIndex = 4;
			this.btnDupVM.Text = "Duplicate";
			this.btnDupVM.Click += new System.EventHandler(this.btnDupVM_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Path:";
			// 
			// lblVMPath
			// 
			this.lblVMPath.Location = new System.Drawing.Point(88, 88);
			this.lblVMPath.Name = "lblVMPath";
			this.lblVMPath.Size = new System.Drawing.Size(456, 48);
			this.lblVMPath.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(24, 144);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 23);
			this.label5.TabIndex = 4;
			this.label5.Text = "Size:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(24, 56);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 23);
			this.label6.TabIndex = 5;
			this.label6.Text = "State:";
			// 
			// lblVMState
			// 
			this.lblVMState.Location = new System.Drawing.Point(88, 56);
			this.lblVMState.Name = "lblVMState";
			this.lblVMState.TabIndex = 6;
			// 
			// lblVMSize
			// 
			this.lblVMSize.Location = new System.Drawing.Point(88, 144);
			this.lblVMSize.Name = "lblVMSize";
			this.lblVMSize.TabIndex = 7;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(24, 24);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(88, 23);
			this.label9.TabIndex = 0;
			this.label9.Text = "New VM Name:";
			// 
			// txtNewVMName
			// 
			this.txtNewVMName.Location = new System.Drawing.Point(112, 24);
			this.txtNewVMName.Name = "txtNewVMName";
			this.txtNewVMName.Size = new System.Drawing.Size(352, 20);
			this.txtNewVMName.TabIndex = 1;
			this.txtNewVMName.Text = "";
			this.txtNewVMName.TextChanged += new System.EventHandler(this.txtNewVMName_TextChanged);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(24, 56);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(88, 23);
			this.label10.TabIndex = 2;
			this.label10.Text = "New VM Path:";
			// 
			// txtNewVMPath
			// 
			this.txtNewVMPath.Location = new System.Drawing.Point(112, 56);
			this.txtNewVMPath.Name = "txtNewVMPath";
			this.txtNewVMPath.Size = new System.Drawing.Size(352, 20);
			this.txtNewVMPath.TabIndex = 3;
			this.txtNewVMPath.Text = "";
			this.txtNewVMPath.TextChanged += new System.EventHandler(this.txtNewVMPath_TextChanged);
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(472, 56);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(72, 23);
			this.btnBrowse.TabIndex = 4;
			this.btnBrowse.Text = "Browse ...";
			// 
			// ckbRegisterVM
			// 
			this.ckbRegisterVM.Checked = true;
			this.ckbRegisterVM.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckbRegisterVM.Location = new System.Drawing.Point(24, 200);
			this.ckbRegisterVM.Name = "ckbRegisterVM";
			this.ckbRegisterVM.TabIndex = 5;
			this.ckbRegisterVM.Text = "Register VM";
			// 
			// ckbTurnOnVM
			// 
			this.ckbTurnOnVM.Checked = true;
			this.ckbTurnOnVM.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckbTurnOnVM.Location = new System.Drawing.Point(152, 200);
			this.ckbTurnOnVM.Name = "ckbTurnOnVM";
			this.ckbTurnOnVM.TabIndex = 6;
			this.ckbTurnOnVM.Text = "Turn On VM";
			// 
			// pbarMain
			// 
			this.pbarMain.Location = new System.Drawing.Point(88, 496);
			this.pbarMain.Name = "pbarMain";
			this.pbarMain.Size = new System.Drawing.Size(288, 23);
			this.pbarMain.TabIndex = 6;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(16, 472);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(64, 23);
			this.label11.TabIndex = 7;
			this.label11.Text = "Progress:";
			// 
			// lblProgress
			// 
			this.lblProgress.BackColor = System.Drawing.Color.Transparent;
			this.lblProgress.Location = new System.Drawing.Point(88, 472);
			this.lblProgress.Name = "lblProgress";
			this.lblProgress.Size = new System.Drawing.Size(288, 23);
			this.lblProgress.TabIndex = 8;
			this.lblProgress.Text = "Ready";
			// 
			// lblFreeSpace
			// 
			this.lblFreeSpace.ForeColor = System.Drawing.Color.Black;
			this.lblFreeSpace.Location = new System.Drawing.Point(184, 88);
			this.lblFreeSpace.Name = "lblFreeSpace";
			this.lblFreeSpace.Size = new System.Drawing.Size(360, 56);
			this.lblFreeSpace.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(160, 23);
			this.label2.TabIndex = 8;
			this.label2.Text = "Free Space after duplication:";
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(488, 496);
			this.btnClose.Name = "btnClose";
			this.btnClose.TabIndex = 9;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// frmDupVM
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(608, 542);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.lblProgress);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.pbarMain);
			this.Controls.Add(this.btnDupVM);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmDupVM";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Duplicate Virtual Machine...";
			this.Load += new System.EventHandler(this.frmDupVM_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		private void btnDupVM_Click(object sender, System.EventArgs e)
		{
			// Create new VM folder
			lblProgress.Text = "Creating VM folder";
			lblProgress.Update();
			if (Directory.Exists(txtNewVMPath.Text))
			{
				DialogResult result;
				result = MessageBox.Show("Destination VM Folder exists, Overwrite?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
				if (result == DialogResult.No) 
				{
					return;
				}
			}
			
			try
			{

				Directory.CreateDirectory(txtNewVMPath.Text);
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
				lblProgress.Text = "Duplication failed: Unable to create VM folder.";
				return;
			}

			pbarMain.Value = 10;
		
			

			// Copy VM files
			lblProgress.Text = "Copying VM files";
			lblProgress.Update();
	
			try 
			{
				for (int i=1; i<=vm.HardDiskConnections.Count;i++)
				{
					FileInfo vhdfi = new FileInfo(vm.HardDiskConnections[i].HardDisk.File); 
					File.Copy(vm.HardDiskConnections[i].HardDisk.File, txtNewVMPath.Text + @"\" + vhdfi.Name, true);

					FileInfo undofi = new FileInfo(vm.HardDiskConnections[i].UndoHardDisk.File);
					File.Copy(vm.HardDiskConnections[i].UndoHardDisk.File, txtNewVMPath.Text + @"\" + undofi.Name, true);

				}
				
				FileInfo vmfi = new FileInfo(vm.File);
				File.Copy(vm.File, txtNewVMPath.Text + @"\" + txtNewVMName.Text + ".vmc", true);
			}
			catch (Exception err) 
			{
				MessageBox.Show(err.Message);
				lblProgress.Text = "Duplication failed: Unable to copy VM files.";
				return;
			}
			

			pbarMain.Value = 40;
					

			// Adjust new VM settings
			lblProgress.Text = "Adjust new VM settings";

			pbarMain.Value = 60;
						

			// Register new VM
			if (ckbRegisterVM.Checked) 
			{
				lblProgress.Text = "Register VM...";
				lblProgress.Update();
				Console.WriteLine(txtNewVMPath.Text + @"\" + txtNewVMName.Text + ".vmc");
				try
				{
					newvm = vs.RegisterVirtualMachine(txtNewVMName.Text, txtNewVMPath.Text);
				}
				catch (Exception err)
				{
					MessageBox.Show(err.Message);
					lblProgress.Text = "Duplication failed: Unable to register VM.";
					return;
				}

			}
			pbarMain.Value = 80;
					

			// Turn On VM
			if (ckbTurnOnVM.Checked) 
			{
				lblProgress.Text = "Turning on VM...";
				lblProgress.Update();
				try
				{
					VMTask task = newvm.Startup();
					while (!task.IsComplete) 
					{
						Thread.Sleep(200);
					}
				}
				catch (Exception err)
				{
					MessageBox.Show(err.Message);
					lblProgress.Text = "Duplication failed: Unable to turn on VM.";
					return;
				}
			}

			pbarMain.Value = 100;
						
			lblProgress.Text = "Duplication Finished Successfully.";


		}

		private void frmDupVM_Load(object sender, System.EventArgs e)
		{
			// Load current VM information
			lblVMName.Text = vm.Name;
			lblVMState.Text = Utility.ConvertVMStateToString(vm.State);
			FileInfo fi = new FileInfo(vm.File);
			lblVMPath.Text = fi.Directory.FullName;

			VMHardDisk vhd = null;
			long vhdSize = 0;
			for (int i=1; i<=vm.HardDiskConnections.Count;i++) 
			{
				vhd = vm.HardDiskConnections[i].HardDisk;
				vhdSize +=  long.Parse(vhd.SizeOnHost.ToString()); 
			}
			lblVMSize.Text = Utility.ConvertByteToString(vhdSize.ToString());

			// Prepare for destination VM
			txtNewVMName.Text = lblVMName.Text + "-1";
			txtNewVMPath.Text = lblVMPath.Text + "-1";

		}

		private void txtNewVMName_TextChanged(object sender, System.EventArgs e)
		{
			FileInfo fi = new FileInfo(vm.File);
			txtNewVMPath.Text = fi.Directory.Parent.FullName + @"\" + txtNewVMName.Text;
		}

		private void txtNewVMPath_TextChanged(object sender, System.EventArgs e)
		{
			string deviceID = txtNewVMPath.Text.Substring(0,1);
			long FreeDiskSpace = 0;
			try 
			{
				ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\'" + deviceID + ":'", null);; 
				disk.Get(); 
				FreeDiskSpace = long.Parse(disk["FreeSpace"].ToString());
				
			}
			catch (Exception err)
			{
				btnDupVM.Enabled = true;
				lblFreeSpace.Text = "Unable to read free disk space on the destination drive. You may not be able to duplication VM.";
				lblFreeSpace.ForeColor = Color.Red;
				return;
			}


			VMHardDisk vhd = null;
			long vhdSize = 0;
			for (int i=1; i<=vm.HardDiskConnections.Count;i++) 
			{
				vhd = vm.HardDiskConnections[i].HardDisk;
				vhdSize +=  long.Parse(vhd.SizeOnHost.ToString()); 
			}
			
			if (vhdSize> FreeDiskSpace) 
			{
				btnDupVM.Enabled = false;
				lblFreeSpace.Text = "Destination Drive has no enough space! \nAvailable space: " + Utility.ConvertByteToString(FreeDiskSpace.ToString())
					+ " only. To duplicate this VM, the destination disk must have at least " + Utility.ConvertByteToString(vhdSize.ToString()) + ". Please free at least " + Utility.ConvertByteToString((vhdSize-FreeDiskSpace) + "")
					+ " or save it to another disk.";
				lblFreeSpace.ForeColor = Color.Red;
			}
			else
			{
				btnDupVM.Enabled = true;
				lblFreeSpace.Text = Utility.ConvertByteToString((FreeDiskSpace-vhdSize) + "");
				lblFreeSpace.ForeColor = Color.Black;
			}

			
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}



	}
}
