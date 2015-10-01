namespace CANtact
{
	partial class CANtactGui
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CANtactGui));
			this.stripTop = new System.Windows.Forms.ToolStrip();
			this.mi_Exit = new System.Windows.Forms.ToolStripButton();
			this.mi_View = new System.Windows.Forms.ToolStripDropDownButton();
			this.mi_ViewLog = new System.Windows.Forms.ToolStripMenuItem();
			this.mi_ViewTrace = new System.Windows.Forms.ToolStripMenuItem();
			this.b_Refresh = new System.Windows.Forms.ToolStripButton();
			this.ComPorts = new System.Windows.Forms.ToolStripComboBox();
			this.Connect = new System.Windows.Forms.ToolStripButton();
			this.stripBottom = new System.Windows.Forms.StatusStrip();
			this.Status = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
			this.stripTop.SuspendLayout();
			this.stripBottom.SuspendLayout();
			this.SuspendLayout();
			// 
			// stripTop
			// 
			this.stripTop.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.stripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_Exit,
            this.mi_View,
            this.b_Refresh,
            this.ComPorts,
            this.Connect});
			this.stripTop.Location = new System.Drawing.Point(0, 0);
			this.stripTop.Name = "stripTop";
			this.stripTop.Size = new System.Drawing.Size(1082, 28);
			this.stripTop.TabIndex = 3;
			this.stripTop.Text = "toolStrip1";
			// 
			// Exit
			// 
			this.mi_Exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.mi_Exit.Image = ((System.Drawing.Image)(resources.GetObject("Exit.Image")));
			this.mi_Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mi_Exit.Name = "Exit";
			this.mi_Exit.Size = new System.Drawing.Size(37, 25);
			this.mi_Exit.Text = "E&xit";
			this.mi_Exit.Click += new System.EventHandler(this.Exit_Click);
			// 
			// View
			// 
			this.mi_View.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.mi_View.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_ViewLog,
            this.mi_ViewTrace});
			this.mi_View.Image = ((System.Drawing.Image)(resources.GetObject("View.Image")));
			this.mi_View.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mi_View.Name = "View";
			this.mi_View.Size = new System.Drawing.Size(55, 25);
			this.mi_View.Text = "View";
			// 
			// ViewLog
			// 
			this.mi_ViewLog.Name = "ViewLog";
			this.mi_ViewLog.Size = new System.Drawing.Size(119, 26);
			this.mi_ViewLog.Text = "Log";
			this.mi_ViewLog.Click += new System.EventHandler(this.ViewLog_Click);
			// 
			// ViewTrace
			// 
			this.mi_ViewTrace.Name = "ViewTrace";
			this.mi_ViewTrace.Size = new System.Drawing.Size(119, 26);
			this.mi_ViewTrace.Text = "Trace";
			this.mi_ViewTrace.Click += new System.EventHandler(this.ViewTrace_Click);
			// 
			// Refresh
			// 
			this.b_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.b_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("Refresh.Image")));
			this.b_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.b_Refresh.Name = "Refresh";
			this.b_Refresh.Size = new System.Drawing.Size(62, 25);
			this.b_Refresh.Text = "&Refresh";
			this.b_Refresh.Click += new System.EventHandler(this.Refresh_Click);
			// 
			// ComPorts
			// 
			this.ComPorts.Name = "ComPorts";
			this.ComPorts.Size = new System.Drawing.Size(121, 28);
			// 
			// Connect
			// 
			this.Connect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.Connect.Image = ((System.Drawing.Image)(resources.GetObject("Connect.Image")));
			this.Connect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Connect.Name = "Connect";
			this.Connect.Size = new System.Drawing.Size(67, 25);
			this.Connect.Text = "&Connect";
			this.Connect.Click += new System.EventHandler(this.Connect_Click);
			// 
			// stripBottom
			// 
			this.stripBottom.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.stripBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status,
            this.toolStripSplitButton1});
			this.stripBottom.Location = new System.Drawing.Point(0, 527);
			this.stripBottom.Name = "stripBottom";
			this.stripBottom.Size = new System.Drawing.Size(1082, 26);
			this.stripBottom.TabIndex = 4;
			this.stripBottom.Text = "statusStrip1";
			// 
			// Status
			// 
			this.Status.Name = "Status";
			this.Status.Size = new System.Drawing.Size(1028, 21);
			this.Status.Spring = true;
			this.Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toolStripSplitButton1
			// 
			this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripSplitButton1.Enabled = false;
			this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
			this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripSplitButton1.Name = "toolStripSplitButton1";
			this.toolStripSplitButton1.Size = new System.Drawing.Size(39, 24);
			this.toolStripSplitButton1.Text = "toolStripSplitButton1";
			// 
			// CANtactGui
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1082, 553);
			this.Controls.Add(this.stripBottom);
			this.Controls.Add(this.stripTop);
			this.IsMdiContainer = true;
			this.Name = "CANtactGui";
			this.Text = "CANtact";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CANtactGui_FormClosing);
			this.Load += new System.EventHandler(this.CANtactGui_Load);
			this.stripTop.ResumeLayout(false);
			this.stripTop.PerformLayout();
			this.stripBottom.ResumeLayout(false);
			this.stripBottom.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip stripTop;
		private System.Windows.Forms.ToolStripComboBox ComPorts;
		private System.Windows.Forms.ToolStripButton Connect;
		private System.Windows.Forms.StatusStrip stripBottom;
		private System.Windows.Forms.ToolStripStatusLabel Status;
		private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
		private System.Windows.Forms.ToolStripButton mi_Exit;
		private System.Windows.Forms.ToolStripButton b_Refresh;
		private System.Windows.Forms.ToolStripDropDownButton mi_View;
		private System.Windows.Forms.ToolStripMenuItem mi_ViewLog;
		private System.Windows.Forms.ToolStripMenuItem mi_ViewTrace;
	}
}

