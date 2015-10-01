using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;
using System.Drawing;

namespace CANtact
{
	public partial class CANtactGui : Form
	{
		private SerialPort m_port;
		private Log m_log;
		private RollingTrace m_rolling;
		private FixedTrace m_matrix;
		private string m_data = string.Empty;

		public CANtactGui()
		{
			InitializeComponent();
		}

		private void Exit_Click(object sender, EventArgs e)
		{
			Close();
		}

		#region Load/Save Settings
		private void LoadSettings()
		{
		}
		private void SaveSettings()
		{
		}
		#endregion

		#region Form Load
		private void CANtactGui_Load(object sender, EventArgs e)
		{
			m_port = new SerialPort();
			m_port.BaudRate = 115200;
			m_port.Handshake = Handshake.None;
			m_port.Parity = Parity.None;
			m_port.DataBits = 8;

			m_port.DataReceived += ComPort_DataReceived;
			m_port.PinChanged += ComPort_PinChanged;
			m_port.ErrorReceived += ComPort_ErrorReceived;

			LoadSettings();
			Refresh_Click(sender, e);
		}
		#endregion

		#region Form Closing
		private void CANtactGui_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (m_log != null)
				m_log.Close();

			try
			{
				if (m_port.IsOpen)
					m_port.Close();
			}
			catch { }
		}
		#endregion

		#region View Matrix Trace
		private void mi_ViewMatrix_Click(object sender, EventArgs e)
		{
			if (m_matrix == null)
			{
				m_matrix = new FixedTrace();
				m_matrix.Location = new Point(100, 100);
				m_matrix.FormClosed += MatrixTrace_Closed;
				m_matrix.MdiParent = this;
				m_matrix.Show();
			}
			else if (m_matrix.WindowState == FormWindowState.Minimized)
			{
				m_matrix.WindowState = FormWindowState.Normal;
			}
		}

		void MatrixTrace_Closed(object sender, FormClosedEventArgs e)
		{
			m_matrix = null;
		}
		#endregion

		#region View Rolling Trace
		private void mi_ViewRolling_Click(object sender, EventArgs e)
		{
			if (m_rolling == null)
			{
				m_rolling = new RollingTrace();
				m_rolling.Location = new Point(100, 0);
				m_rolling.FormClosed += RollingTrace_Closed;
				m_rolling.MdiParent = this;
				m_rolling.Show();
			}
			else if (m_rolling.WindowState == FormWindowState.Minimized)
			{
				m_rolling.WindowState = FormWindowState.Normal;
			}
		}
		void RollingTrace_Closed(object sender, FormClosedEventArgs e)
		{
			m_rolling = null;
		}
		#endregion

		#region View Log
		private void ViewLog_Click(object sender, EventArgs e)
		{
			if (m_log == null)
			{
				m_log = new Log();
				m_log.Location = new Point(0, 0);
				m_log.FormClosed += Log_FormClosed;
				m_log.MdiParent = this;
				m_log.Show();
			}
			else if (m_log.WindowState == FormWindowState.Minimized)
			{
				m_log.WindowState = FormWindowState.Normal;
			}
		}
		void Log_FormClosed(object sender, FormClosedEventArgs e)
		{
			m_log = null;
		}
		#endregion

		#region Refresh Ports
		private void Refresh_Click(object sender, EventArgs e)
		{
			string[] ports = SerialPort.GetPortNames();
			ComPorts.Items.Clear();
			if (ports.Length == 0)
			{
				Connect.Enabled = false;
				Status.Text = "COM ports not found.";
			}
			else
			{
				SortedList<string, string> sorted = new SortedList<string, string>(ports.Length);
				foreach (string port in ports)
				{
					string portUpper = port.ToUpperInvariant();
					if (!sorted.ContainsKey(portUpper))
						sorted.Add(portUpper, port);
				}
				foreach (string port in sorted.Values)
					ComPorts.Items.Add(port);
				if (ComPorts.Items.Count == 1)
					ComPorts.SelectedIndex = 0;

				Connect.Enabled = true;
			}
		}
		#endregion

		#region Set Status Text
		private void SetStatus(string text)
		{
			if (InvokeRequired)
				BeginInvoke(new Action<string>(SetStatus), text);
			else
				Status.Text = text;
		}
		#endregion

		#region Connect Click
		private void Connect_Click(object sender, EventArgs e)
		{
			if (m_port != null && m_port.IsOpen)
			{
				m_port.Close();
				ComPorts.Enabled = true;
				Connect.Text = "Connect";
				return;
			}

			if (ComPorts.SelectedIndex < 0)
			{
				SetStatus("COM Port not selected.");
				return;
			}

			m_port.PortName = ComPorts.SelectedItem.ToString();
			ViewLog_Click(sender, e);
			mi_ViewRolling_Click(sender, e);
			mi_ViewMatrix_Click(sender, e);

			try
			{
				m_port.Open();
				ComPorts.Enabled = false;
				Connect.Text = "Disconnect";
			}
			catch (Exception ex)
			{
				SetStatus(ex.Message);
				if (m_port.IsOpen)
					m_port.Close();
			}
		}
		#endregion

		#region COM Port events
		void ComPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
		{
		}

		void ComPort_PinChanged(object sender, SerialPinChangedEventArgs e)
		{
		}

		void ComPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			try
			{
				if (m_port.IsOpen)
				{
					string data = m_port.ReadExisting();
					if (!string.IsNullOrEmpty(data))
					{
						if (m_log != null)
							m_log.Add(data);
						data = string.Concat(m_data, data);

						int idx_start = 0;
						while (idx_start < data.Length)
						{
							int idx_end = data.IndexOf('\r', idx_start);
							if (idx_end < 0)
								break;

							string package = data.Substring(idx_start, idx_end - idx_start);
							if (!string.IsNullOrEmpty(package))
								ParsePackage(ref package);
							idx_start = idx_end + 1;
						}
						if (idx_start < data.Length)
							data = data.Substring(idx_start);
						else
							data = string.Empty;
						m_data = data;
						if (m_data.Length > 2000)
							m_data = string.Empty;
					}
				}
			}
			catch(Exception ex)
			{
				SetStatus(ex.Message);
			}
		}

		private byte GetPackData(ref string package, int idx)
		{
			byte nibble = 0;
			if (idx < package.Length)
			{
				nibble = (byte)Char.ToUpperInvariant(package[idx]);
				if (nibble < (byte)('A'))
					nibble -= (byte)('0');
				else
					nibble -= (byte)('A' - 0xA);
			}
			return nibble;
		}

		private void ParsePackage(ref string package)
		{
			if (package.Length > 1)
			{
				CANPackage pack = new CANPackage();
				int i, j;
				switch (package[0])
				{
					case 't':
						pack.FrameType = CanFrameType.CAN_RTR_DATA;
						pack.IdType = CanIdType.CAN_ID_STD;
						break;
					case 'T':
						pack.FrameType = CanFrameType.CAN_RTR_DATA;
						pack.IdType = CanIdType.CAN_ID_EXT;
						break;
					case 'r':
						pack.FrameType = CanFrameType.CAN_RTR_REMOTE;
						pack.IdType = CanIdType.CAN_ID_STD;
						break;
					case 'R':
						pack.FrameType = CanFrameType.CAN_RTR_REMOTE;
						pack.IdType = CanIdType.CAN_ID_EXT;
						break;
					default:
						return;
				}

				if (pack.IdType == CanIdType.CAN_ID_STD)
					j = 3;
				else if (pack.IdType == CanIdType.CAN_ID_EXT)
					j = 8;
				else
					return;

				for (i = 1; i <= j; )
				{
					pack.ID <<= 4;
					pack.ID |= GetPackData(ref package, i++);
				}
				pack.DLC = (UInt16)GetPackData(ref package, i++);
				if (pack.DLC <= 8)
				{
					for (j = 0; j < pack.DLC; j++)
					{
						pack.Data[j] = (byte)(GetPackData(ref package, i++) << 4);
						pack.Data[j] |= GetPackData(ref package, i++);
					}
				}
				if (m_rolling != null)
					m_rolling.Add(pack);
				if (m_matrix != null)
					m_matrix.Add(pack);
			}
		}
		#endregion

		private void mi_Tools_Click(object sender, EventArgs e)
		{

		}
	}
}
