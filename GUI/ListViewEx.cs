using System.Windows.Forms;

namespace CANtact
{
	public class ListViewEx : ListView
	{
		public ListViewEx()
		{
			InitializeComponent();

			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// ListViewEx
			// 
			this.GridLines = true;
			this.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.HideSelection = false;
			this.MultiSelect = false;
			this.View = System.Windows.Forms.View.Details;
			this.ResumeLayout(false);

		}
	}
}

