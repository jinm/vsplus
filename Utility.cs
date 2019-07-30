using System;
using Microsoft.VirtualServer.Interop;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Threading;
using System.Data;
using System.ComponentModel;

namespace VSPlus
{
	/// <summary>
	/// Summary description for Utility.
	/// </summary>

	public enum VMState 
	{
		Unknown = -1,
		Invalid	= 0,
		TurnedOff,
		Saved,	
		TurningOn,
		Restoring,
		Running,
		Paused,
		Saving,
		TurningOff,
		MergingDrives,
		DeleteMachine,
		Reset,
		Shutdown
	}

	public enum CPUUsageSize
	{
		Normal = 1,
		Large = 2
	}
	

	// Global Configuration Object
	[DefaultPropertyAttribute("RefreshInterval")]
	public class AppConfig
	{
		// This is the application configuration object.

		// Initial values
		private int _RefreshInterval = 2 ;
		[CategoryAttribute("Application Settings"), DefaultValueAttribute(2)]
		public int RefreshInterval
		{
			get { return _RefreshInterval; }
			set { _RefreshInterval = value;}
		}


		private bool _CheckUpdateOnExiting = true;
		[DescriptionAttribute("Check update on Exit?"), CategoryAttribute("Application Settings"), DefaultValueAttribute(true)]
		public bool CheckUpdateOnExiting
		{
			get { return _CheckUpdateOnExiting; }
			set { _CheckUpdateOnExiting = value;}
		}

	

		public string CONFIGFILE = Application.StartupPath + "/config.xml";
		public string currentVS = "";
		public string currentVM = "";
		public int currentVMRCPort = 5900;
		public string Language = "en-us";
		public VMVirtualServer vs = null;
		public VMVirtualMachine vm = null;

		public bool ConfigUpdated = false;

		public AppConfig()
		{
			// Constructor
			// Load from XML configuration file
		}


		public void UpdateAppConfig() 
		{
			XmlNode node = frmMain.xmlConfig.SelectSingleNode("//Configuration");	
			
			RefreshInterval = int.Parse(node.SelectSingleNode("RefreshInterval").InnerText);
			
			node = node.SelectSingleNode("CheckUpdateOnExiting");
			
			if (node.InnerText.ToUpper() == "TRUE") 
			{
				CheckUpdateOnExiting  = true;
			}
			else
			{
				CheckUpdateOnExiting = false;
			}
		}

	}

	public class Utility
	{
		public Utility()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		public static string FormatTimeNumber(int number) 
		{
			// Format a Hour/Minute/Second number to 2 digits if it is not.
			return (number>9)?number.ToString():"0"+number;
			
		}


		public static string ConvertVMStateToString(VMVMState vmstate) 
		{
			string sVMState = "";
			switch (vmstate) 
			{
				case VMVMState.vmVMState_Invalid:
					sVMState = "Invalid";
					break;
				case VMVMState.vmVMState_Paused:
					sVMState = "Paused";
					break;
				case VMVMState.vmVMState_Restoring:
					sVMState = "Restoring";
					break;
				case VMVMState.vmVMState_Running:
					sVMState = "Running";
					break;
				case VMVMState.vmVMState_Saved:
					sVMState = "Saved";
					break;
				case VMVMState.vmVMState_Saving:
					sVMState = "Saving";
					break;
				case VMVMState.vmVMState_TurnedOff:
					sVMState = "Turned Off";
					break;
				case VMVMState.vmVMState_TurningOff:
					sVMState = "Turning Off";
					break;
				case VMVMState.vmVMState_TurningOn:
					sVMState = "Turning On";
					break;
				default:
					sVMState = "Unknown";
					break;
			}
			
			return sVMState;

		}


		public static double AverageCPUUsage(VMVirtualMachine vm) 
		{
			double average = 0;
			double total = 0;

			foreach (object cpu in (IEnumerable) ((System.Array)vm.Accountant.CPUUtilizationHistory) ) 
			{
				total = total + double.Parse(cpu.ToString());
			}
			average = Math.Floor(total/60);
	        
			return average;
		}


		public static Bitmap GenerateThumbnail(VMDisplay vmdisplay) 
		{
			Bitmap thumbnail = null;
		
			// Count total number of pixels of the thumbnail. Can I use 64x48x4 directly?
			int count=0;
			foreach ( Object image in (IEnumerable)vmdisplay.Thumbnail) 
			{
				count++;
			}
			
			// Get a byte array to store the bitmap. Initial values are 0.
			// Every element has 4 bytes. Plus a 54 bytes Bitmap header.
			byte[] bitmapdata = new Byte[count*4+54];


			// Bitmap header.
			bitmapdata[0] = 66;
			bitmapdata[1] = 77;
			bitmapdata[2] = 54;
			bitmapdata[3] = 36;
			bitmapdata[10] = 54;
			bitmapdata[14] = 40;
			bitmapdata[18] = 64;	// Image width
			bitmapdata[22] = 48;	// Image height
			bitmapdata[26] = 1;		
			bitmapdata[28] = 24;	// Bit depth
			bitmapdata[35] = 36;

			int pixIndex = 54;
			long pixel = 0;
			foreach ( Object image in (IEnumerable)vmdisplay.Thumbnail) 
			{	
				// Every pixel has 4 bytes. Ignore the last one.
				pixel = long.Parse(image.ToString());
				bitmapdata[pixIndex] = byte.Parse( (pixel&4278190080)/16777216 + "");
				bitmapdata[pixIndex+1] = byte.Parse( (pixel&16711680)/65536 + "");
				bitmapdata[pixIndex+2] = byte.Parse( (pixel&65280)/256 + "");

				pixIndex += 3;
			}

			System.IO.MemoryStream streamBitmap = new  System.IO.MemoryStream(bitmapdata);
			thumbnail = new Bitmap( (Bitmap)Image.FromStream(streamBitmap));

			// Rotate and flip the image
			thumbnail.RotateFlip(RotateFlipType.Rotate180FlipX);

			return thumbnail;
		}


		public static Bitmap GenerateCPUUsage(VMVirtualMachine vm, VMVirtualServer vs, CPUUsageSize enum_scale) 
		{
			Bitmap bmpCPUUsage = null;
			int scale = (int)enum_scale;

			double ReservedCPU = Math.Floor(double.Parse(vm.Accountant.reservedSystemCapacity.ToString())) * vs.HostInfo.LogicalProcessorCount ;
			ReservedCPU = ReservedCPU * 0.5 * scale;
			if (ReservedCPU > 50*scale-1) ReservedCPU=50*scale-1;

			double MaximumCPU = Math.Floor(double.Parse(vm.Accountant.MaximumSystemCapacity.ToString())) * vs.HostInfo.LogicalProcessorCount  ;
			MaximumCPU = MaximumCPU * 0.5 * scale;
			if (MaximumCPU > 50*scale-1) MaximumCPU=50*scale-1;

			int[] CPUHistory = new int[122];

            // Get the first 2 values
			int count=0;
			foreach ( object cpu in ((System.Array)vm.Accountant.CPUUtilizationHistory) ) 
			{
				CPUHistory[count] = int.Parse(cpu.ToString())/2 * scale;
				break;
			}
			
			// Create value array
			count = 1;
			foreach ( object cpu in (IEnumerable) ((System.Array)vm.Accountant.CPUUtilizationHistory) ) 
			{
				CPUHistory[count+1] = int.Parse(cpu.ToString()) / 2 * scale;
				CPUHistory[count] = (CPUHistory[count+1] + CPUHistory[count-1])/2;
				count += 2;
			}
			CPUHistory[120] = CPUHistory[119];

			// Get a byte array to store the bitmap. Initial values are 0.
			// Every element has 3 bytes. Plus a 54 bytes Bitmap header.

			int bitmapSize = 18000*scale+54;
			byte[] bitmapdata = new Byte[bitmapSize];

			// Bitmap header.
			bitmapdata[0] = 0x42;									// Header ("BM")
			bitmapdata[1] = 0x4D;									// Header
			bitmapdata[2] = (byte)(bitmapSize&0xFF);				// File size lowbit (Image size + Header size)
			bitmapdata[3] = (byte) (bitmapSize&0xFF00/0x100);		// File size highbit
			bitmapdata[10] = 0x36;									//
			bitmapdata[14] = 0x28;									// specifies the size of the BITMAPINFOHEADER structure, in bytes.
			bitmapdata[18] = 0x78;									// Image width 120 pixels
			bitmapdata[22] = (byte)(50*scale);						// Image height 100 pixels (0-99)
			bitmapdata[26] = 1;										// Frame count
			bitmapdata[28] = 24;									// Bit depth
			bitmapdata[34] = (byte)((bitmapSize-54)&0xFF);			// Image size lowbit
			bitmapdata[35] =(byte) ((bitmapSize-54)&0xFF00/0x100);	// Image size highbit

			System.IO.MemoryStream streamBitmap = new  System.IO.MemoryStream(bitmapdata);
			bmpCPUUsage = new Bitmap( (Bitmap)Image.FromStream(streamBitmap));

			Graphics hG1 = Graphics.FromImage(bmpCPUUsage);
			Pen pen = new Pen(Color.Yellow);
			
			for(int i=0; i<120; i++) 
			{
				// Baseline
				bmpCPUUsage.SetPixel(i, 10*scale, Color.Green);
				bmpCPUUsage.SetPixel(i, 20*scale, Color.Green);
				bmpCPUUsage.SetPixel(i, 30*scale, Color.Green);
				bmpCPUUsage.SetPixel(i, 40*scale, Color.Green);

				// Reserved and Maximum Line
				bmpCPUUsage.SetPixel(i, (int)ReservedCPU, Color.Blue);
				bmpCPUUsage.SetPixel(i, (int)MaximumCPU, Color.Blue);
				
				// CPU Usage
				hG1.DrawLine(pen, i, CPUHistory[i]+1, i+1, CPUHistory[i+1]+1);
				
			}

			// Rotate and flip the image
			bmpCPUUsage.RotateFlip(RotateFlipType.Rotate180FlipX );
			


			return bmpCPUUsage;
		}


		// To Capture the screen
		[System.Runtime.InteropServices.DllImport("gdi32.dll")]
		public static extern long BitBlt (IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

		public static VMVirtualMachine getVM(string ServerAddress, string ServerDisplayName) 
		{
			VMVirtualMachine vm = null;


			try 
			{
				vm = getVS(ServerAddress).FindVirtualMachine(ServerDisplayName);
			}
			catch (Exception err)
			{
				//MessageBox.Show(err.Message, "Virtual Machine Error");

			}	

			return vm;
		}


		public static VMVirtualMachine getVM(VMVirtualServer vs, string ServerDisplayName) 
		{
			VMVirtualMachine vm = null;

			try 
			{
				vm = vs.FindVirtualMachine(ServerDisplayName);
			}
			catch (Exception err)
			{
				//MessageBox.Show(err.Message, "Virtual Machine Error");

			}	

			return vm;
		}


		public static VMVirtualServer getVS(string ServerAddress) 
		{
			VMVirtualServer vs = null;
			int count = 3;
			
			while (count>0) 
			{
				try 
				{
					vs = frmMain.myApp.GetVMVirtualServerClass(ServerAddress);
					break;
				}
				catch (Exception err)
				{
					// MessageBox.Show(err.Message, "Virtual Server Error");
					// In case myApp doesn't function, initialize it again.
					frmMain.myApp = new InitVS();		
					count--;
				}

			}

			return vs;
		}


		public static VMVirtualMachine getCurrentVM(int tabIndex)
		{
			VMVirtualMachine vm = null;
			XmlNodeList nodeList = frmMain.xmlConfig.SelectNodes("//VirtualServer");	

			if (nodeList.Count >0) 
			{
				foreach (XmlNode xmlNode in nodeList) 
				{	
					if ( xmlNode.SelectSingleNode("TabIndex").InnerText == tabIndex.ToString()) 
					{
						vm = getVM( xmlNode.SelectSingleNode("ServerAddress").InnerText, xmlNode.SelectSingleNode("ServerDisplayName").InnerText);	
					}
				}
			}
			
			return vm;
		}


		public static string ConvertUptimeToString(int UptimeInSec) 
		{
			string UptimeInStr = "";
			if (UptimeInSec > 3600) 
			{
				UptimeInStr = (UptimeInSec/3600) + "hr:" + (UptimeInSec%3600)/60 + "min";	
			} 
			else 
			{
				UptimeInStr = (UptimeInSec/60) + "min:" + (UptimeInSec%60) + "sec";
			}

			return UptimeInStr;
		}


		public static string ConvertByteToString(string SizeInStr) 
		{
			float SizeInByte = float.Parse(SizeInStr);
			
			string SizeInScale = "";
			if (SizeInByte > 1073741824) 
			{
				SizeInScale = Math.Round((SizeInByte/1073741824), 1) + "GB";	
			} 
			else if (SizeInByte > 1048576) 
			{
				SizeInScale = Math.Round((SizeInByte/1048576),1) + "MB" ;
			} 
			else 
			{

				SizeInScale = Math.Round((SizeInByte/1024),1) + "KB" ;
			}

			return SizeInScale;
		}


		public static string getConfigValue(string sConfig)
		{
//			XmlNode node = frmMain.xmlConfig.SelectSingleNode("//Configuration//" + sConfig);
//			XmlNode newNode = null;
//			newNode.Name = sConfig;
//			newNode.InnerText = 20;
//
//			if (node == null) 
//			{	
//				// If Configuration value isn't found, create it.
//				node = frmMain.xmlConfig.SelectSingleNode("//Configuration//");
//				XmlElement xe=xmlConfig.CreateElement(sConfig);
//				xe.InnerText = "20";
//
//				return 20;
//			}
//			else 
//			{
//				return node.InnerText;
//			}
			return "";
		}


		public static string Translate(string inMsg) 
		{
			string outMsg = "";

			// Get current language file

			// Translate
			outMsg = inMsg;

			return outMsg;

		}


		public static XmlDocument InitXmlConfig() 
		{
			// In case config file cannot be found, init frmMain.xmlConfig with default values.
			XmlDocument xmlDoc = new XmlDocument();
			XmlElement xmlElement = null;

			// Add XML Declearation
			XmlDeclaration xmlDecl;
			xmlDecl = xmlDoc.CreateXmlDeclaration("1.0",null,null);
			xmlDecl.Encoding="UTF-8";
			xmlElement = xmlDoc.DocumentElement;
			xmlDoc.InsertBefore(xmlDecl, xmlElement);

			// Create Root Node:
			xmlElement =xmlDoc.CreateElement("","VSPlus","");
			xmlDoc.AppendChild(xmlElement);

			// Create Configuration Node
			xmlElement = xmlDoc.CreateElement("","Configuration","");
		
			//		Create Elements
			XmlElement newElement = xmlDoc.CreateElement("RefreshInterval");
			newElement.InnerText = "20";
			xmlElement.AppendChild(newElement);

			newElement = xmlDoc.CreateElement("CheckUpdateOnExiting");
			newElement.InnerText = "true";
			xmlElement.AppendChild(newElement);
	
			xmlDoc.DocumentElement.AppendChild(xmlElement);		

			xmlDoc.Save(frmMain.conf.CONFIGFILE);
			return xmlDoc;

		}


		public static DataGrid getVSViewGrid(string ServerAddress, DataGrid dg)
		{

			DataTable dt = new DataTable("VSView");
			ArrayList bmpCPUUsage = new ArrayList();
			ArrayList bmpThumbnail = new ArrayList();

			VMVirtualServer vs = Utility.getVS(ServerAddress);
			if ( vs.VirtualMachines.Count>0)
			{	
				//create a datatable with columns
				dt.Columns.Add(new DataColumn("Thumbnail", typeof(int)));
				dt.Columns.Add(new DataColumn("VM"));
				dt.Columns.Add(new DataColumn("CPUUsage",typeof(int)));
				dt.Columns.Add(new DataColumn("Info"));
					
				// Get each row		
				VMVirtualMachine vm = null;
				for (int i=0; i<vs.VirtualMachines.Count;i++) 
				{
					DataRow dr = dt.NewRow();
					vm = vs.VirtualMachines[i+1];
					bmpCPUUsage.Add( Utility.GenerateCPUUsage(vm, vs, CPUUsageSize.Normal));
					bmpThumbnail.Add( Utility.GenerateThumbnail(vm.Display));

					dr[0] = i;
					dr[1] = "\n" + vm.Name + "\n(" + Utility.ConvertVMStateToString(vm.State) + ")";
					dr[2] = i;
					dr[3] = "\n" + "RAM: " + vm.Memory.ToString() + " MB" +
						"\n" + "Running Time: " + Utility.ConvertUptimeToString(vm.Accountant.UpTime) ;
					dt.Rows.Add(dr);
				}
				dt.DefaultView.AllowNew = false;		

			}



			if ( dt.Rows.Count>0)
			{	
				// Define table style
				DataGridTableStyle tableStyle = new DataGridTableStyle();
				tableStyle.MappingName = "VSView";

				// Add column styles
				// Graphic column
				DataGridImageCell imgtbc;
				// TextBox Column
				DataGridTextBoxColumn tbc;

				// Thumbnail column
				imgtbc = new DataGridImageCell();
				imgtbc.MappingName = "Thumbnail";
				imgtbc.HeaderText = "Thumbnail";
				imgtbc.Alignment = HorizontalAlignment.Center;
				imgtbc.theImages = bmpThumbnail;
				imgtbc.Width = 64;
				tableStyle.GridColumnStyles.Add(imgtbc);

				// VM Name column
				tbc = new DataGridTextBoxColumn();
				tbc.MappingName = "VM";
				tbc.HeaderText = "VM";
				tbc.Alignment = HorizontalAlignment.Center;
				tbc.TextBox.Multiline= true;
				tbc.TextBox.WordWrap = true;
				tbc.TextBox.AcceptsReturn = true;
				tbc.TextBox.Enabled = false;
				tbc.TextBox.TextAlign = HorizontalAlignment.Left;
				tbc.Width = 200;
				tableStyle.GridColumnStyles.Add(tbc);

				// CPU Usage column
				imgtbc = new DataGridImageCell();
				imgtbc.MappingName = "CPUUsage";
				imgtbc.HeaderText = "CPUUsage";
				imgtbc.Alignment = HorizontalAlignment.Center;
				imgtbc.theImages = bmpCPUUsage;
				imgtbc.Width = 120;
				tableStyle.GridColumnStyles.Add(imgtbc);
		
				// VM Info column
				tbc = new DataGridTextBoxColumn();
				tbc.MappingName = "Info";
				tbc.HeaderText = "Info";
				tbc.Alignment = HorizontalAlignment.Center;
				tbc.TextBox.Multiline= true;
				tbc.TextBox.WordWrap = true;
				tbc.TextBox.AcceptsReturn = true;
				tbc.TextBox.Enabled = false;
				tbc.TextBox.TextAlign = HorizontalAlignment.Right ;			// Overwritten by tbc.Alignment
				tbc.Width = 368;
				tableStyle.GridColumnStyles.Add(tbc);
				tableStyle.PreferredRowHeight = 50;		
				tableStyle.AllowSorting = false;
				dt.DefaultView.AllowNew = false;		

				dg.DataSource = null;
				dg.Dock = DockStyle.Fill;
				dg.TableStyles.Clear();
				dg.TableStyles.Add(tableStyle);
				dg.DataSource = dt;
				dg.AllowSorting = false;
				dg.ReadOnly = true;
				dg.Enabled = true;
 
			}

			return dg;
		}


		public static DataGrid getVSViewGrid(VMVirtualServer vs, DataGrid dg)
		{

			DataTable dt = new DataTable("VSView");
			ArrayList bmpCPUUsage = new ArrayList();
			ArrayList bmpThumbnail = new ArrayList();

			

				//create a datatable with columns
				dt.Columns.Add(new DataColumn("Thumbnail", typeof(int)));
				dt.Columns.Add(new DataColumn("VM"));
				dt.Columns.Add(new DataColumn("CPUUsage",typeof(int)));
				dt.Columns.Add(new DataColumn("Info"));

			if ( vs.VirtualMachines.Count>0)
			{						
				// Get each row		
				VMVirtualMachine vm = null;
				for (int i=0; i<vs.VirtualMachines.Count;i++) 
				{
					DataRow dr = dt.NewRow();
					vm = vs.VirtualMachines[i+1];
					bmpCPUUsage.Add( Utility.GenerateCPUUsage(vm, vs, CPUUsageSize.Normal));
					bmpThumbnail.Add( Utility.GenerateThumbnail(vm.Display));

					dr[0] = i;
					dr[1] = "\n" + vm.Name + "\n(" + Utility.ConvertVMStateToString(vm.State) + ")";
					dr[2] = i;
					dr[3] = "\n" + "RAM: " + vm.Memory.ToString() + " MB" +
						"\n" + "Running Time: " + Utility.ConvertUptimeToString(vm.Accountant.UpTime) ;
					dt.Rows.Add(dr);
				}
					

			}
			dt.DefaultView.AllowNew = false;	


//			if ( dt.Rows.Count>0)
//			{	
				// Define table style
				DataGridTableStyle tableStyle = new DataGridTableStyle();
				tableStyle.MappingName = "VSView";

				// Add column styles
				// Graphic column
				DataGridImageCell imgtbc;
				// TextBox Column
				DataGridTextBoxColumn tbc;

				// Thumbnail column
				imgtbc = new DataGridImageCell();
				imgtbc.MappingName = "Thumbnail";
				imgtbc.HeaderText = "Thumbnail";
				imgtbc.Alignment = HorizontalAlignment.Center;
				imgtbc.theImages = bmpThumbnail;
				imgtbc.Width = 64;
				tableStyle.GridColumnStyles.Add(imgtbc);

				// VM Name column
				tbc = new DataGridTextBoxColumn();
				tbc.MappingName = "VM";
				tbc.HeaderText = "VM";
				tbc.Alignment = HorizontalAlignment.Center;
				tbc.TextBox.Multiline= true;
				tbc.TextBox.WordWrap = true;
				tbc.TextBox.AcceptsReturn = true;
				tbc.TextBox.Enabled = false;
				tbc.TextBox.TextAlign = HorizontalAlignment.Left;
				tbc.Width = 200;
				tableStyle.GridColumnStyles.Add(tbc);

				// CPU Usage column
				imgtbc = new DataGridImageCell();
				imgtbc.MappingName = "CPUUsage";
				imgtbc.HeaderText = "CPUUsage";
				imgtbc.Alignment = HorizontalAlignment.Center;
				imgtbc.theImages = bmpCPUUsage;
				imgtbc.Width = 120;
				tableStyle.GridColumnStyles.Add(imgtbc);
		
				// VM Info column
				tbc = new DataGridTextBoxColumn();
				tbc.MappingName = "Info";
				tbc.HeaderText = "Info";
				tbc.Alignment = HorizontalAlignment.Center;
				tbc.TextBox.Multiline= true;
				tbc.TextBox.WordWrap = true;
				tbc.TextBox.AcceptsReturn = true;
				tbc.TextBox.Enabled = false;
				tbc.TextBox.TextAlign = HorizontalAlignment.Right ;			// Overwritten by tbc.Alignment
				tbc.Width = 368;
				tableStyle.GridColumnStyles.Add(tbc);
				tableStyle.PreferredRowHeight = 50;		
				tableStyle.AllowSorting = false;
				dt.DefaultView.AllowNew = false;		

				dg.DataSource = null;
				dg.TableStyles.Clear();
				dg.TableStyles.Add(tableStyle);
				dg.DataSource = dt;
				dg.AllowSorting = false;
				dg.ReadOnly = true;
				dg.Enabled = true;
 
//			}

			return dg;
		}


		
	}


	/// <summary>
	/// Summary description for DataGridImageCell.
	/// </summary>
	public class DataGridImageCell : DataGridTextBoxColumn
	{
		private ArrayList theImages1;
		public DataGridImageCell()
		{
			
		}
		public ArrayList theImages
		{
			get{return theImages1;}
			set{theImages1 = value;}
		}

		protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
		{
			object o = this.GetColumnValueAtRow(source, rowNum);
			if(o != null)
			{
				int i = (int)o;
				g.FillRectangle(backBrush, bounds);
				
				Bitmap bmp = (Bitmap)theImages[i];
			
				GridImageCellDrawOption cellDrawOption = GridImageCellDrawOption.NoResize;
				//GridImageCellDrawOption cellDrawOption = GridImageCellDrawOption.FitProportionally;
				//GridImageCellDrawOption cellDrawOption = GridImageCellDrawOption.FitToCell;
				
				
				System.Drawing.GraphicsUnit gu = System.Drawing.GraphicsUnit.Point;
					
				RectangleF srcRect = bmp.GetBounds(ref gu);
				Rectangle destRect = Rectangle.Empty;

				Region saveRegion = g.Clip;

				int DrawX = bounds.X + (bounds.Width - (int)srcRect.Width)/2;
				int DrawY = bounds.Y + (bounds.Height - (int)srcRect.Height)/2;

				destRect = new Rectangle( DrawX, DrawY, (int) srcRect.Width, (int) srcRect.Height);
				g.Clip = new Region(bounds);

//				switch(cellDrawOption)
//				{
//					case GridImageCellDrawOption.FitToCell:
//						destRect = bounds;
//						break;
//					case GridImageCellDrawOption.NoResize:
//						destRect = new Rectangle(bounds.X, bounds.Y, (int) srcRect.Width, (int) srcRect.Height);
//						g.Clip = new Region(bounds);
//						break;
//					case GridImageCellDrawOption.FitProportionally:
//					{
//						float srcRatio =  srcRect.Width / srcRect.Height;
//						float tarRatio = (float) bounds.Width / bounds.Height;
//						destRect = bounds;
//						if( tarRatio < srcRatio )
//						{
//							destRect.Height = (int) (destRect.Width * srcRatio);	
//						}
//						else
//						{
//							destRect.Width = (int) (destRect.Height * srcRatio);
//						}
//					}
//						break;
//						
//					default:
//						break;
//				}

				if(!destRect.IsEmpty)
					g.DrawImage(bmp,  destRect, srcRect, gu);

				g.Clip = saveRegion;
			}
		}

		protected override void Edit(System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Rectangle bounds, bool readOnly, string instantText, bool cellIsVisible)
		{
			//overridden to avoid editing
		}

		public enum GridImageCellDrawOption
		{
			FitToCell      = 0,
			NoResize      = 1,
			FitProportionally = 2,
		};
	}


}
