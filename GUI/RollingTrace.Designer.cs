namespace CANtact
{
	partial class RollingTrace
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			this.grid = new System.Windows.Forms.DataGridView();
			this.RxTx = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RTR = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DLC = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DATA0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DATA1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DATA2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DATA3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DATA4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DATA5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DATA6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DATA7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LAST = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.traceRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.traceRowBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// grid
			// 
			this.grid.AllowUserToAddRows = false;
			this.grid.AllowUserToDeleteRows = false;
			this.grid.AllowUserToResizeColumns = false;
			this.grid.AllowUserToResizeRows = false;
			this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.LAST});
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(0, 0);
			this.grid.MultiSelect = false;
			this.grid.Name = "grid";
			this.grid.ReadOnly = true;
			this.grid.RowHeadersVisible = false;
			this.grid.RowTemplate.Height = 24;
			this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grid.ShowEditingIcon = false;
			this.grid.Size = new System.Drawing.Size(900, 320);
			this.grid.TabIndex = 0;
			// 
			// RxTx
			// 
			this.RxTx.DataPropertyName = "RxTx";
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.RxTx.DefaultCellStyle = dataGridViewCellStyle1;
			this.RxTx.FillWeight = 60F;
			this.RxTx.HeaderText = "TRACE";
			this.RxTx.Name = "RxTx";
			this.RxTx.ReadOnly = true;
			this.RxTx.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.RxTx.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.RxTx.Width = 60;
			// 
			// ID
			// 
			this.ID.DataPropertyName = "ID";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.ID.DefaultCellStyle = dataGridViewCellStyle2;
			this.ID.FillWeight = 50F;
			this.ID.HeaderText = "ID";
			this.ID.Name = "ID";
			this.ID.ReadOnly = true;
			this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.ID.Width = 50;
			// 
			// RTR
			// 
			this.RTR.DataPropertyName = "RTR";
			this.RTR.FillWeight = 50F;
			this.RTR.HeaderText = "RTR";
			this.RTR.Name = "RTR";
			this.RTR.ReadOnly = true;
			this.RTR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.RTR.Width = 50;
			// 
			// DLC
			// 
			this.DLC.DataPropertyName = "DLC";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.DLC.DefaultCellStyle = dataGridViewCellStyle3;
			this.DLC.FillWeight = 40F;
			this.DLC.HeaderText = "DLC";
			this.DLC.Name = "DLC";
			this.DLC.ReadOnly = true;
			this.DLC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.DLC.Width = 40;
			// 
			// DATA0
			// 
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.NullValue = null;
			this.DATA0.DefaultCellStyle = dataGridViewCellStyle4;
			this.DATA0.FillWeight = 55F;
			this.DATA0.HeaderText = "DATA 0";
			this.DATA0.Name = "DATA0";
			this.DATA0.ReadOnly = true;
			this.DATA0.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.DATA0.Width = 55;
			// 
			// DATA1
			// 
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.DATA1.DefaultCellStyle = dataGridViewCellStyle5;
			this.DATA1.FillWeight = 55F;
			this.DATA1.HeaderText = "DATA 1";
			this.DATA1.Name = "DATA1";
			this.DATA1.ReadOnly = true;
			this.DATA1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.DATA1.Width = 55;
			// 
			// DATA2
			// 
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.DATA2.DefaultCellStyle = dataGridViewCellStyle6;
			this.DATA2.FillWeight = 55F;
			this.DATA2.HeaderText = "DATA 2";
			this.DATA2.Name = "DATA2";
			this.DATA2.ReadOnly = true;
			this.DATA2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.DATA2.Width = 55;
			// 
			// DATA3
			// 
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.DATA3.DefaultCellStyle = dataGridViewCellStyle7;
			this.DATA3.FillWeight = 55F;
			this.DATA3.HeaderText = "DATA 3";
			this.DATA3.Name = "DATA3";
			this.DATA3.ReadOnly = true;
			this.DATA3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.DATA3.Width = 55;
			// 
			// DATA4
			// 
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.DATA4.DefaultCellStyle = dataGridViewCellStyle8;
			this.DATA4.FillWeight = 55F;
			this.DATA4.HeaderText = "DATA 4";
			this.DATA4.Name = "DATA4";
			this.DATA4.ReadOnly = true;
			this.DATA4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.DATA4.Width = 55;
			// 
			// DATA5
			// 
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.DATA5.DefaultCellStyle = dataGridViewCellStyle9;
			this.DATA5.FillWeight = 55F;
			this.DATA5.HeaderText = "DATA 5";
			this.DATA5.Name = "DATA5";
			this.DATA5.ReadOnly = true;
			this.DATA5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.DATA5.Width = 55;
			// 
			// DATA6
			// 
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.DATA6.DefaultCellStyle = dataGridViewCellStyle10;
			this.DATA6.FillWeight = 55F;
			this.DATA6.HeaderText = "DATA 6";
			this.DATA6.Name = "DATA6";
			this.DATA6.ReadOnly = true;
			this.DATA6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.DATA6.Width = 55;
			// 
			// DATA7
			// 
			dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.DATA7.DefaultCellStyle = dataGridViewCellStyle11;
			this.DATA7.FillWeight = 55F;
			this.DATA7.HeaderText = "DATA 7";
			this.DATA7.Name = "DATA7";
			this.DATA7.ReadOnly = true;
			this.DATA7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.DATA7.Width = 55;
			// 
			// LAST
			// 
			this.LAST.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.LAST.HeaderText = "";
			this.LAST.Name = "LAST";
			this.LAST.ReadOnly = true;
			this.LAST.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// traceRowBindingSource
			// 
			this.traceRowBindingSource.DataSource = typeof(CANtact.TraceRow);
			// 
			// RollingTrace
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(900, 320);
			this.Controls.Add(this.grid);
			this.Name = "RollingTrace";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Rolling Trace";
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.traceRowBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView grid;
		private System.Windows.Forms.DataGridViewTextBoxColumn RxTx;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID;
		private System.Windows.Forms.DataGridViewTextBoxColumn RTR;
		private System.Windows.Forms.DataGridViewTextBoxColumn DLC;
		private System.Windows.Forms.DataGridViewTextBoxColumn DATA0;
		private System.Windows.Forms.DataGridViewTextBoxColumn DATA1;
		private System.Windows.Forms.DataGridViewTextBoxColumn DATA2;
		private System.Windows.Forms.DataGridViewTextBoxColumn DATA3;
		private System.Windows.Forms.DataGridViewTextBoxColumn DATA4;
		private System.Windows.Forms.DataGridViewTextBoxColumn DATA5;
		private System.Windows.Forms.DataGridViewTextBoxColumn DATA6;
		private System.Windows.Forms.DataGridViewTextBoxColumn DATA7;
		private System.Windows.Forms.DataGridViewTextBoxColumn LAST;
		private System.Windows.Forms.BindingSource traceRowBindingSource;
	}
}