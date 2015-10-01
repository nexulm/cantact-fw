using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CANtact
{
	public partial class Log : Form
	{
		private StreamWriter m_File;

		public Log()
		{
			InitializeComponent();
		}

		/*
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
				return cp;
			}
		}
		*/
		public void Add(string text)
		{
			if (InvokeRequired)
				BeginInvoke(new Action<string>(Add), text);
			else
			{
				if (!string.IsNullOrEmpty(text))
				{
					text = text.Replace('\r', '\n');
					TB.Text += text;
					TB.SelectionStart = TB.Text.Length;
					TB.ScrollToCaret();

					if (m_File != null)
					{
						m_File.Write(text);
					}
				}
			}
		}

		private void Clear_Click(object sender, EventArgs e)
		{
			TB.Text = string.Empty;
		}

		private void Log_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (m_File != null)
			{
				m_File.Close();
				m_File = null;
			}
		}

		private void Save_Click(object sender, EventArgs e)
		{
			if (m_File == null)
			{
				if (saveFile.ShowDialog() == DialogResult.OK)
				{
					string fileName = saveFile.FileName;
					m_File = new StreamWriter(fileName, true, Encoding.UTF8);
					Save.Text = "Close";
				}
			}
			else
			{
				m_File.Close();
				m_File = null;
				Save.Text = "Save";
			}
		}
	}
}
