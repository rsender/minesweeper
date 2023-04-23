namespace Minesweeper;

partial class GameForm {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.gamePanel = new System.Windows.Forms.TableLayoutPanel();
            this.header = new System.Windows.Forms.Panel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.easy = new System.Windows.Forms.ToolStripMenuItem();
            this.intermediate = new System.Windows.Forms.ToolStripMenuItem();
            this.hard = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gamePanel
            // 
            this.gamePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gamePanel.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.gamePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gamePanel.ColumnCount = 2;
            this.gamePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gamePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gamePanel.Location = new System.Drawing.Point(0, 71);
            this.gamePanel.Margin = new System.Windows.Forms.Padding(0);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Padding = new Padding(10);
            this.gamePanel.RowCount = 2;
            this.gamePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gamePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gamePanel.Size = new System.Drawing.Size(479, 500);
            this.gamePanel.TabIndex = 0;
            // 
            // header
            // 
            this.header.Location = new System.Drawing.Point(0, 31);
            this.header.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(282, 37);
            this.header.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(282, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuItem
            // 
            this.menuItem.BackColor = System.Drawing.Color.White;
            this.menuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easy,
            this.intermediate,
            this.hard});
            this.menuItem.Name = "menuItem";
            this.menuItem.Size = new System.Drawing.Size(62, 24);
            this.menuItem.Text = "Game";
            // 
            // easy
            // 
            this.easy.Checked = true;
            this.easy.CheckOnClick = true;
            this.easy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.easy.Name = "easy";
            this.easy.Size = new System.Drawing.Size(177, 26);
            this.easy.Tag = new int[] { 9, 9, 10 };
            this.easy.Text = "Easy";
            this.easy.Click += new System.EventHandler(this.OnMenuItemClick);
            // 
            // intermediate
            // 
            this.intermediate.CheckOnClick = true;
            this.intermediate.Name = "intermediate";
            this.intermediate.Size = new System.Drawing.Size(177, 26);
            this.easy.Tag = new int[] { 16, 16, 40 };
            this.intermediate.Text = "Intermediate";
            this.intermediate.Click += new System.EventHandler(this.OnMenuItemClick);
            // 
            // hard
            // 
            this.hard.CheckOnClick = true;
            this.hard.Name = "hard";
            this.hard.Size = new System.Drawing.Size(177, 26);
            this.easy.Tag = new int[] { 16, 30, 99 };
            this.hard.Text = "Hard";
            this.hard.Click += new System.EventHandler(this.OnMenuItemClick);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.header);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.gamePanel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "GameForm";
            this.Text = "Minesweeper";
            this.Load += new System.EventHandler(this.OnGameLoad);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private TableLayoutPanel gamePanel;
    private Panel header;
    private MenuStrip menuStrip;
    private ToolStripMenuItem menuItem;
    private ToolStripMenuItem easy;
    private ToolStripMenuItem intermediate;
    private ToolStripMenuItem hard;
}
