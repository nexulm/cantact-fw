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
		}

		public void Add(CANPackage package)
		{
			if (InvokeRequired)
			{
				BeginInvoke(new Action<CANPackage>(Add), package);
				return;
			}

			string[] subitems = package.ToStrings();
			ListViewItem item = new ListViewItem(subitems, 0);
			if (grid.Items.Count == 0)
				grid.Items.Add(item);
			else
				grid.Items.Insert(0, item);
		}
	}
}
