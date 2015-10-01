using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CANtact
{
	public partial class RollingTrace : Form
	{
		public RollingTrace()
		{
			InitializeComponent();
			grid.AutoGenerateColumns = false;
		}

		public void Add(CanPackage package)
		{
			if (InvokeRequired)
				BeginInvoke(new Action<CanPackage>(Add), package);
			else
			{
				grid.Rows.Insert(0,
					"RX",
					"0x" + package.ID.ToString("X4"), 
					package.FrameType == CanFrameType.CAN_RTR_DATA ? "DATA" : "REM",
					package.DLC,
					"0x" + package.Data[0].ToString("X2"),
					"0x" + package.Data[1].ToString("X2"),
					"0x" + package.Data[2].ToString("X2"),
					"0x" + package.Data[3].ToString("X2"),
					"0x" + package.Data[4].ToString("X2"),
					"0x" + package.Data[5].ToString("X2"),
					"0x" + package.Data[6].ToString("X2"),
					"0x" + package.Data[7].ToString("X2"),
					""
				);
				grid.Rows[0].Selected = true;
			}
		}
	}
}
