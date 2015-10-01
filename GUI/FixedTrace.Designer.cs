namespace CANtact
{
	partial class FixedTrace
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.grid = new CANtact.ListViewEx();
			this.RxTx = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.RTR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.DLC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.DATA0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.DATA1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.DATA2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.DATA3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.DATA4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.DATA5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.DATA6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.DATA7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.COUNT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// grid
			// 
			this.grid.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RxTx,
            this.ID,
            this.RTR,
            this.DLC,
            this.DATA0,
            this.DATA1,
            this.DATA2,
            this.DATA3,
            this.DATA4,
            this.DATA5,
            this.DATA6,
            this.DATA7,
            this.COUNT});
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(0, 0);
			this.grid.Name = "grid";
			this.grid.Size = new System.Drawing.Size(932, 323);
			this.grid.TabIndex = 0;
			this.grid.UseCompatibleStateImageBehavior = false;
			// 
			// RxTx
			// 
			this.RxTx.Text = "TRACE";
			// 
			// ID
			// 
			this.ID.Text = "ID";
			this.ID.Width = 50;
			// 
			// RTR
			// 
			this.RTR.Text = "RTR";
			this.RTR.Width = 50;
			// 
			// DLC
			// 
			this.DLC.Text = "DLC";
			this.DLC.Width = 40;
			// 
			// DATA0
			// 
			this.DATA0.Text = "DATA 0";
			this.DATA0.Width = 55;
			// 
			// DATA1
			// 
			this.DATA1.Text = "DATA 1";
			this.DATA1.Width = 55;
			// 
			// DATA2
			// 
			this.DATA2.Text = "DATA 2";
			this.DATA2.Width = 55;
			// 
			// DATA3
			// 
			this.DATA3.Text = "DATA 3";
			this.DATA3.Width = 55;
			// 
			// DATA4
			// 
			this.DATA4.Text = "DATA 4";
			this.DATA4.Width = 55;
			// 
			// DATA5
			// 
			this.DATA5.Text = "DATA 5";
			this.DATA5.Width = 55;
			// 
			// DATA6
			// 
			this.DATA6.Text = "DATA 6";
			this.DATA6.Width = 55;
			// 
			// DATA7
			// 
			this.DATA7.Text = "DATA 7";
			this.DATA7.Width = 55;
			// 
			// COUNT
			// 
			this.COUNT.Text = "COUNT";
			this.COUNT.Width = 50;
			// 
			// FixedTrace
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(932, 323);
			this.Controls.Add(this.grid);
			this.DoubleBuffered = true;
			this.Name = "FixedTrace";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Fixed Trace";
			this.ResumeLayout(false);

		}

		#endregion

		private ListViewEx grid;
		private System.Windows.Forms.ColumnHeader RxTx;
		private System.Windows.Forms.ColumnHeader ID;
		private System.Windows.Forms.ColumnHeader RTR;
		private System.Windows.Forms.ColumnHeader DLC;
		private System.Windows.Forms.ColumnHeader DATA0;
		private System.Windows.Forms.ColumnHeader DATA1;
		private System.Windows.Forms.ColumnHeader DATA2;
		private System.Windows.Forms.ColumnHeader DATA3;
		private System.Windows.Forms.ColumnHeader DATA4;
		private System.Windows.Forms.ColumnHeader DATA5;
		private System.Windows.Forms.ColumnHeader DATA6;
		private System.Windows.Forms.ColumnHeader DATA7;
		private System.Windows.Forms.ColumnHeader COUNT;
	}
}