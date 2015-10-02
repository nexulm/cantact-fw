using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace CANtact
{
	public partial class Transmit : Form
	{
		private bool m_errors = false;

		public Transmit()
		{
			InitializeComponent();
		}

		#region Transmit Load 
		private void Transmit_Load(object sender, EventArgs e)
		{
			List<Control> controls = GetRowControls(null, Controls, 1);
			SuspendLayout();
			grid.SuspendLayout();

			if (AppendRow(controls)
			&& AppendRow(controls)
			&& AppendRow(controls)
			&& AppendRow(controls)
			&& AppendRow(controls)
			&& AppendRow(controls)
			&& AppendRow(controls)
			)
			{ }

			grid.ResumeLayout(false);
			grid.PerformLayout();
			ResumeLayout(false);
		}
		#endregion

		#region Get controls from row 
		/// <summary>
		/// Get controls from row
		/// </summary>
		/// <param name="row_controls"></param>
		/// <param name="form_controls"></param>
		/// <param name="row"></param>
		/// <returns></returns>
		private List<Control> GetRowControls(List<Control> row_controls, Control.ControlCollection form_controls, int row)
		{
			if (row_controls == null)
				row_controls = new List<Control>(20);

			foreach (Control c in form_controls)
			{
				if (c.HasChildren)
					GetRowControls(row_controls, c.Controls, row);
				else if (grid.GetRow(c) == row)
				{
					if (c.BackColor != SystemColors.Window)
						c.BackColor = SystemColors.Window;
					row_controls.Add(c);
					c.Tag = grid.GetColumn(c);
				}
			}
			return row_controls;
		}
		#endregion

		#region Append CAN row 
		/// <summary>
		/// Appena row
		/// </summary>
		/// <param name="controls"></param>
		private bool AppendRow(List<Control> controls)
		{
			bool success = true;

			int iRow = grid.RowStyles.Count;
			grid.RowStyles.Add(new RowStyle(SizeType.Absolute, grid.RowStyles[1].Height));

			try
			{
				foreach (Control c in controls)
				{
					Control nc = null;
					if (c is TextBox)
						nc = ((TextBox)c).Clone();
					else if (c is CheckBox)
						nc = ((CheckBox)c).Clone();
					else if (c is Button)
					{
						nc = ((Button)c).Clone();
						if (nc.Name == R_SEND.Name)
							nc.Click += new System.EventHandler(Send_Click);
					}
					else
						throw new Exception("Unknown control type.");

					grid.Controls.Add(nc, (int)c.Tag, iRow);
				}
			}
			catch (Exception ex)
			{
				success = false;
				MessageBox.Show(ex.Message);
			}
			return success;
		}
		#endregion

		#region Build CAN package from row values 
		/// <summary>
		/// Build CAN package from Row
		/// </summary>
		/// <param name="iRow"></param>
		/// <returns></returns>
		private CANPackage BuildPackage(int iRow)
		{
			List<Control> controls = GetRowControls(null, Controls, iRow);
			CANPackage package = new CANPackage();
			package.Use = false;
			UInt32 v_base = 16;
			UInt32 max_id = 0x7FF;
			bool failed = false;

			SetStatus();

			// Prescan controls to define values base and IDE
			foreach (Control c in controls)
			{
				if (c.Name == R_HEX.Name)
					v_base = (UInt32)(((CheckBox)c).Checked ? 16 : 10);
				else if (c.Name == R_EXT_ID.Name)
				{
					package.IdType = ((CheckBox)c).Checked ? CanIdType.CAN_ID_EXT : CanIdType.CAN_ID_STD;
					max_id =
						(package.IdType == CanIdType.CAN_ID_STD)
						? 0x7FFu
						: 0x1FFFFFFFu;
				}
			}

			// Scan controls and build CAN package
			foreach (Control c in controls)
			{
				try
				{
					if (c.Name == R_HEX.Name)
						continue;
					else if (c.Name == R_ID.Name)
						package.ID = ParseValue(c.Text, v_base, max_id, 0);
					else if (c.Name == R_EXT_ID.Name)
						continue;
					else if (c.Name == R_RTR_DATA.Name)
						package.FrameType = ((CheckBox)c).Checked ? CanFrameType.CAN_RTR_DATA : CanFrameType.CAN_RTR_REMOTE;
					else if (c.Name == R_DLC.Name)
						package.DLC = (UInt16)ParseValue(c.Text, v_base, 8, 0);
					else if (c.Name == R_D0.Name)
						package.Data[0] = (byte)ParseValue(c.Text, v_base, 0xFF, 0);
					else if (c.Name == R_D1.Name)
						package.Data[1] = (byte)ParseValue(c.Text, v_base, 0xFF, 0);
					else if (c.Name == R_D2.Name)
						package.Data[2] = (byte)ParseValue(c.Text, v_base, 0xFF, 0);
					else if (c.Name == R_D3.Name)
						package.Data[3] = (byte)ParseValue(c.Text, v_base, 0xFF, 0);
					else if (c.Name == R_D4.Name)
						package.Data[4] = (byte)ParseValue(c.Text, v_base, 0xFF, 0);
					else if (c.Name == R_D5.Name)
						package.Data[5] = (byte)ParseValue(c.Text, v_base, 0xFF, 0);
					else if (c.Name == R_D6.Name)
						package.Data[6] = (byte)ParseValue(c.Text, v_base, 0xFF, 0);
					else if (c.Name == R_D7.Name)
						package.Data[7] = (byte)ParseValue(c.Text, v_base, 0xFF, 0);
					else if (c.Name == R_DELAY.Name)
						package.Delay = ParseValue(c.Text, 10, 300000, 100);
					else if (c.Name == R_COUNT.Name)
						package.Count = ParseValue(c.Text, 10, 1000, 1);
					else if (c.Name == R_USE.Name)
						package.Use = ((CheckBox)c).Checked;
					else if (c.Name == R_SEND.Name)
						continue;
					else
						throw new Exception("Unknown row control.");
				}
				catch(Exception ex)
				{
					SetStatus(ex.Message);
					c.BackColor = Color.Red;
					failed = true;
				}
			}
			if (failed)
				package = null;
			return package;
		}
		#endregion

		#region Set Status message 
		private void SetStatus(string text)
		{
			CANtactGui f = ParentForm as CANtactGui;
			if (f != null)
			{
				m_errors = true;
				f.SetStatus(text);
			}
		}
		private void SetStatus()
		{
			if (m_errors)
			{
				SetStatus("");
				m_errors = false;
			}
		}
		#endregion

		#region Parse Numeric Value 
		/// <summary>
		/// Parse text string to value
		/// </summary>
		/// <param name="text"></param>
		/// <param name="value_base"></param>
		/// <returns></returns>
		private UInt32 ParseValue(string text, UInt32 value_base, UInt32 max, UInt32 min)
		{
			UInt32 value = 0;
			int mode = 0;

			if (text == null)
				text = string.Empty;
			text = text.Trim();
			text = text.ToUpperInvariant();
			foreach (char ch in text)
			{
				if (mode == 0)
				{
					if (ch == '0')
						continue;
					if (ch == 'X')
					{
						mode++;
						continue;
					}
				}
				if (mode == 1 && ch == '0')
					continue;

				if (ch >= '0' && ch <= '9')
				{
					value *= value_base;
					value += (UInt32)(ch - '0');
					mode = 2;
					continue;
				}
				if (value_base == 16 && ch >= 'A' && ch <= 'F')
				{
					value *= value_base;
					value += (UInt32)(ch - 'A' + 0xA);
					mode = 2;
					continue;
				}
				throw new Exception("Bad value.");
			}

			if (value > max)
				throw new Exception("Value too big.");
			if (min != 0 && value < min)
				throw new Exception("Value too small.");

			return value;
		}
		#endregion

		#region Send to CAN 
		/// <summary>
		/// Send all rows
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SendAll_Click(object sender, EventArgs e)
		{
			for (int iRow = 1; iRow < grid.RowStyles.Count; iRow++ )
			{
				CANPackage package = BuildPackage(iRow);
				if (package == null)
					break;

				MessageBox.Show("Not implement");
				break;
			}
		}

		private void Send_Click(object sender, EventArgs e)
		{
			CANPackage package = BuildPackage(grid.GetRow((Control)sender));
			if (package != null)
			{
				MessageBox.Show("Not implemented");
			}
		}
		#endregion
	}

	#region Control helper 
	public static class ControlExtensions
	{
		private static int cid = 0;
		public static T Clone<T>(this T controlToClone)
			where T : Control
		{
			PropertyInfo[] controlProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
			T instance = Activator.CreateInstance<T>();
			foreach (PropertyInfo propInfo in controlProperties)
				if (propInfo.CanWrite && propInfo.Name != "WindowTarget")
					propInfo.SetValue(instance, propInfo.GetValue(controlToClone, null), null);
			cid++;
			return instance;
		}
	}
	#endregion
}
