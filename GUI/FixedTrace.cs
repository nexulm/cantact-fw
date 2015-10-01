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
	public partial class FixedTrace : Form
	{
		#region class MatrixRow
		public class MatrixRow
		{
			public int Count { get; set; }
			public CANPackage LastPackage { get; set; }
			public DateTime LastTime;
			public MatrixRow()
			{
			}
		}
		#endregion

		private SortedList<UInt32, MatrixRow> m_ids = new SortedList<uint, MatrixRow>(50);

		public FixedTrace()
		{
			InitializeComponent();
		}

		internal void Add(CANPackage package)
		{
			if (InvokeRequired)
			{
				BeginInvoke(new Action<CANPackage>(Add), package);
				return;
			}

			if (!m_ids.ContainsKey(package.ID))
				m_ids.Add(package.ID, new MatrixRow());
			MatrixRow row = m_ids[package.ID];
			row.Count++;
			row.LastPackage = package;
			row.LastTime = DateTime.Now;
			string[] subitems = package.ToStrings(row.Count);

			if (row.Count == 1)
			{	// Add new row to grid
				ListViewItem item = new ListViewItem(subitems, 0);
				item.Tag = package.ID;

				int idx = 0;
				for (; idx < grid.Items.Count; idx++)
				{
					ListViewItem current = grid.Items[idx];
					if (((UInt32)current.Tag) > package.ID)
						break;
				}
				if (idx >= grid.Items.Count)
					grid.Items.Add(item);
				else
					grid.Items.Insert(idx, item);
			}
			else
			{	// Change existed grid row
				for (int idx = 0; idx < grid.Items.Count; idx++)
				{
					ListViewItem current = grid.Items[idx];
					if (((UInt32)current.Tag) == package.ID)
					{	// Found it and change
						current.SubItems[0].Text = subitems[0];
						current.SubItems[1].Text = subitems[1];
						current.SubItems[2].Text = subitems[2];
						current.SubItems[3].Text = subitems[3];
						current.SubItems[4].Text = subitems[4];
						current.SubItems[5].Text = subitems[5];
						current.SubItems[6].Text = subitems[6];
						current.SubItems[7].Text = subitems[7];
						current.SubItems[8].Text = subitems[8];
						current.SubItems[9].Text = subitems[9];
						current.SubItems[10].Text = subitems[10];
						current.SubItems[11].Text = subitems[11];
						current.SubItems[12].Text = subitems[12];
						break;
					}
				}
			}
		}
	}
}
