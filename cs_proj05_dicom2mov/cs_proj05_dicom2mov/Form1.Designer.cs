namespace cs_proj05_dicom2mov
{
    partial class Form1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checklistMovieFiles = new System.Windows.Forms.CheckedListBox();
            this.flowlayoutMoveButton = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonMoveTo = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.populateDrives = new System.Windows.Forms.Button();
            this.DriveList = new System.Windows.Forms.CheckedListBox();
            this.selectListDicom = new System.Windows.Forms.CheckedListBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.dropdownProfiles = new System.Windows.Forms.ComboBox();
            this.Details = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.increaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decreaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowlayoutMoveButton.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.checklistMovieFiles, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowlayoutMoveButton, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.DriveList, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.selectListDicom, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Details, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.29652F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.99902F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.704457F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(876, 447);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // checklistMovieFiles
            // 
            this.checklistMovieFiles.CheckOnClick = true;
            this.checklistMovieFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checklistMovieFiles.FormattingEnabled = true;
            this.checklistMovieFiles.Location = new System.Drawing.Point(440, 3);
            this.checklistMovieFiles.Name = "checklistMovieFiles";
            this.tableLayoutPanel1.SetRowSpan(this.checklistMovieFiles, 2);
            this.checklistMovieFiles.Size = new System.Drawing.Size(213, 401);
            this.checklistMovieFiles.TabIndex = 3;
            // 
            // flowlayoutMoveButton
            // 
            this.flowlayoutMoveButton.Controls.Add(this.buttonMoveTo);
            this.flowlayoutMoveButton.Controls.Add(this.Delete);
            this.flowlayoutMoveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowlayoutMoveButton.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowlayoutMoveButton.Location = new System.Drawing.Point(440, 410);
            this.flowlayoutMoveButton.Name = "flowlayoutMoveButton";
            this.flowlayoutMoveButton.Size = new System.Drawing.Size(213, 34);
            this.flowlayoutMoveButton.TabIndex = 4;
            // 
            // buttonMoveTo
            // 
            this.buttonMoveTo.Location = new System.Drawing.Point(135, 3);
            this.buttonMoveTo.Name = "buttonMoveTo";
            this.buttonMoveTo.Size = new System.Drawing.Size(75, 23);
            this.buttonMoveTo.TabIndex = 5;
            this.buttonMoveTo.Text = "Move to -->";
            this.buttonMoveTo.UseVisualStyleBackColor = true;
            this.buttonMoveTo.Click += new System.EventHandler(this.buttonMoveTo_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.populateDrives);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(659, 410);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(214, 34);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // populateDrives
            // 
            this.populateDrives.Location = new System.Drawing.Point(3, 3);
            this.populateDrives.Name = "populateDrives";
            this.populateDrives.Size = new System.Drawing.Size(75, 23);
            this.populateDrives.TabIndex = 6;
            this.populateDrives.Text = "Refresh";
            this.populateDrives.UseVisualStyleBackColor = true;
            this.populateDrives.Click += new System.EventHandler(this.populateDrives_Click);
            // 
            // DriveList
            // 
            this.DriveList.CheckOnClick = true;
            this.DriveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DriveList.FormattingEnabled = true;
            this.DriveList.Location = new System.Drawing.Point(659, 3);
            this.DriveList.Name = "DriveList";
            this.tableLayoutPanel1.SetRowSpan(this.DriveList, 2);
            this.DriveList.Size = new System.Drawing.Size(214, 401);
            this.DriveList.TabIndex = 5;
            // 
            // selectListDicom
            // 
            this.selectListDicom.CheckOnClick = true;
            this.tableLayoutPanel1.SetColumnSpan(this.selectListDicom, 2);
            this.selectListDicom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectListDicom.FormattingEnabled = true;
            this.selectListDicom.Location = new System.Drawing.Point(3, 3);
            this.selectListDicom.Name = "selectListDicom";
            this.selectListDicom.Size = new System.Drawing.Size(431, 312);
            this.selectListDicom.TabIndex = 8;
            // 
            // flowLayoutPanel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel2, 2);
            this.flowLayoutPanel2.Controls.Add(this.buttonConvert);
            this.flowLayoutPanel2.Controls.Add(this.dropdownProfiles);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 410);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(431, 34);
            this.flowLayoutPanel2.TabIndex = 9;
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(353, 3);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(75, 23);
            this.buttonConvert.TabIndex = 0;
            this.buttonConvert.Text = "Convert -->";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // dropdownProfiles
            // 
            this.dropdownProfiles.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dropdownProfiles.FormattingEnabled = true;
            this.dropdownProfiles.Items.AddRange(new object[] {
            "preset1",
            "preset2"});
            this.dropdownProfiles.Location = new System.Drawing.Point(134, 4);
            this.dropdownProfiles.Name = "dropdownProfiles";
            this.dropdownProfiles.Size = new System.Drawing.Size(213, 21);
            this.dropdownProfiles.TabIndex = 1;
            // 
            // Details
            // 
            this.Details.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Details.Location = new System.Drawing.Point(134, 321);
            this.Details.Multiline = true;
            this.Details.Name = "Details";
            this.Details.ReadOnly = true;
            this.Details.Size = new System.Drawing.Size(300, 83);
            this.Details.TabIndex = 10;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 321);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(125, 83);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "Name:\r\nDate:\r\nTime:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.fontSizeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(876, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // fontSizeToolStripMenuItem
            // 
            this.fontSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.increaseToolStripMenuItem,
            this.decreaseToolStripMenuItem});
            this.fontSizeToolStripMenuItem.Name = "fontSizeToolStripMenuItem";
            this.fontSizeToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.fontSizeToolStripMenuItem.Text = "Font Size";
            // 
            // increaseToolStripMenuItem
            // 
            this.increaseToolStripMenuItem.Name = "increaseToolStripMenuItem";
            this.increaseToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.increaseToolStripMenuItem.Text = "Increase";
            this.increaseToolStripMenuItem.Click += new System.EventHandler(this.increaseToolStripMenuItem_Click);
            // 
            // decreaseToolStripMenuItem
            // 
            this.decreaseToolStripMenuItem.Name = "decreaseToolStripMenuItem";
            this.decreaseToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.decreaseToolStripMenuItem.Text = "Decrease";
            this.decreaseToolStripMenuItem.Click += new System.EventHandler(this.decreaseToolStripMenuItem_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(54, 3);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 6;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 471);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Dicom To Movie";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowlayoutMoveButton.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowlayoutMoveButton;
        private System.Windows.Forms.Button buttonMoveTo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button populateDrives;
        private System.Windows.Forms.CheckedListBox checklistMovieFiles;
        private System.Windows.Forms.CheckedListBox DriveList;
        private System.Windows.Forms.CheckedListBox selectListDicom;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.ComboBox dropdownProfiles;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem increaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decreaseToolStripMenuItem;
        private System.Windows.Forms.TextBox Details;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Delete;

    }
}