namespace CANtact
{
	partial class Log
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Log));
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.Clear = new System.Windows.Forms.ToolStripButton();
			this.Save = new System.Windows.Forms.ToolStripButton();
			this.saveFile = new System.Windows.Forms.SaveFileDialog();
			this.TB = new System.Windows.Forms.RichTextBox();
			this.toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Clear,
            this.Save});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(432, 27);
			this.toolStrip.TabIndex = 0;
			this.toolStrip.Text = "toolStrip1";
			// 
			// Clear
			// 
			this.Clear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.Clear.Image = ((System.Drawing.Image)(resources.GetObject("Clear.Image")));
			this.Clear.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Clear.Name = "Clear";
			this.Clear.Size = new System.Drawing.Size(47, 24);
			this.Clear.Text = "Clear";
			this.Clear.ToolTipText = "Clear screen log";
			this.Clear.Click += new System.EventHandler(this.Clear_Click);
			// 
			// Save
			// 
			this.Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.Save.Image = ((System.Drawing.Image)(resources.GetObject("Save.Image")));
			this.Save.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Save.Name = "Save";
			this.Save.Size = new System.Drawing.Size(44, 24);
			this.Save.Text = "Save";
			this.Save.ToolTipText = "Save/Close log file";
			this.Save.Click += new System.EventHandler(this.Save_Click);
			// 
			// saveFile
			// 
			this.saveFile.DefaultExt = "txt";
			this.saveFile.Filter = "Log|*.txt";
			this.saveFile.OverwritePrompt = false;
			this.saveFile.Title = "Save log to ...";
			// 
			// TB
			// 
			this.TB.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TB.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.TB.Location = new System.Drawing.Point(0, 27);
			this.TB.Name = "TB";
			this.TB.ShortcutsEnabled = false;
			this.TB.Size = new System.Drawing.Size(432, 376);
			this.TB.TabIndex = 2;
			this.TB.Text = "";
			// 
			// Log
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(432, 403);
			this.Controls.Add(this.TB);
			this.Controls.Add(this.toolStrip);
			this.Name = "Log";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Log";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Log_FormClosing);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton Clear;
		private System.Windows.Forms.ToolStripButton Save;
		private System.Windows.Forms.SaveFileDialog saveFile;
		private System.Windows.Forms.RichTextBox TB;
	}
}