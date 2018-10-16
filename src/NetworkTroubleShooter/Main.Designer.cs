namespace NetworkTroubleshooter
{
    partial class Main
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
            this.outputTextBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.troubleshootInterfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loggingLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verboseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.doneButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.serverTextBox = new System.Windows.Forms.TextBox();
            this.httpTimeoutUpDown = new System.Windows.Forms.NumericUpDown();
            this.pingTimeoutUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.httpTimeoutUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pingTimeoutUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // outputTextBox
            // 
            this.outputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputTextBox.Location = new System.Drawing.Point(0, 24);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(387, 389);
            this.outputTextBox.TabIndex = 0;
            this.outputTextBox.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.troubleshootInterfaceToolStripMenuItem,
            this.loggingLevelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(387, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.testToolStripMenuItem.Text = "Test Specifically...";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // troubleshootInterfaceToolStripMenuItem
            // 
            this.troubleshootInterfaceToolStripMenuItem.Name = "troubleshootInterfaceToolStripMenuItem";
            this.troubleshootInterfaceToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.troubleshootInterfaceToolStripMenuItem.Text = "Interfaces";
            // 
            // loggingLevelToolStripMenuItem
            // 
            this.loggingLevelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalToolStripMenuItem,
            this.verboseToolStripMenuItem});
            this.loggingLevelToolStripMenuItem.Name = "loggingLevelToolStripMenuItem";
            this.loggingLevelToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.loggingLevelToolStripMenuItem.Text = "Logging Level";
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
            // 
            // verboseToolStripMenuItem
            // 
            this.verboseToolStripMenuItem.Name = "verboseToolStripMenuItem";
            this.verboseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.verboseToolStripMenuItem.Text = "Verbose";
            this.verboseToolStripMenuItem.Click += new System.EventHandler(this.verboseToolStripMenuItem_Click);
            // 
            // optionsPanel
            // 
            this.optionsPanel.Controls.Add(this.doneButton);
            this.optionsPanel.Controls.Add(this.label3);
            this.optionsPanel.Controls.Add(this.label1);
            this.optionsPanel.Controls.Add(this.serverTextBox);
            this.optionsPanel.Controls.Add(this.httpTimeoutUpDown);
            this.optionsPanel.Controls.Add(this.pingTimeoutUpDown);
            this.optionsPanel.Controls.Add(this.label2);
            this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.optionsPanel.Location = new System.Drawing.Point(387, 0);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(200, 413);
            this.optionsPanel.TabIndex = 2;
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(122, 159);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(75, 23);
            this.doneButton.TabIndex = 6;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "Internet\r\nServer(s)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ping Timeout";
            // 
            // serverTextBox
            // 
            this.serverTextBox.Location = new System.Drawing.Point(77, 57);
            this.serverTextBox.Multiline = true;
            this.serverTextBox.Name = "serverTextBox";
            this.serverTextBox.Size = new System.Drawing.Size(120, 96);
            this.serverTextBox.TabIndex = 2;
            // 
            // httpTimeoutUpDown
            // 
            this.httpTimeoutUpDown.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.httpTimeoutUpDown.Location = new System.Drawing.Point(77, 30);
            this.httpTimeoutUpDown.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.httpTimeoutUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.httpTimeoutUpDown.Name = "httpTimeoutUpDown";
            this.httpTimeoutUpDown.Size = new System.Drawing.Size(120, 20);
            this.httpTimeoutUpDown.TabIndex = 1;
            this.httpTimeoutUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // pingTimeoutUpDown
            // 
            this.pingTimeoutUpDown.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.pingTimeoutUpDown.Location = new System.Drawing.Point(77, 3);
            this.pingTimeoutUpDown.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.pingTimeoutUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.pingTimeoutUpDown.Name = "pingTimeoutUpDown";
            this.pingTimeoutUpDown.Size = new System.Drawing.Size(120, 20);
            this.pingTimeoutUpDown.TabIndex = 0;
            this.pingTimeoutUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "HTTP Timeout";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 413);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.optionsPanel);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Network Troubleshooter";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.optionsPanel.ResumeLayout(false);
            this.optionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.httpTimeoutUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pingTimeoutUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox outputTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem troubleshootInterfaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loggingLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verboseToolStripMenuItem;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown pingTimeoutUpDown;
        private System.Windows.Forms.NumericUpDown httpTimeoutUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serverTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button doneButton;
    }
}

