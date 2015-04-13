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
            this.flowlayoutMoveButton = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonMoveTo = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.populateDrives = new System.Windows.Forms.Button();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.dropdownProfiles = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.selectListDicom = new System.Windows.Forms.CheckedListBox();
            this.DriveList = new System.Windows.Forms.CheckedListBox();
            this.checklistMovieFiles = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowlayoutMoveButton.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.checklistMovieFiles, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowlayoutMoveButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.DriveList, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.selectListDicom, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.29512F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.704884F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(876, 471);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowlayoutMoveButton
            // 
            this.flowlayoutMoveButton.Controls.Add(this.buttonMoveTo);
            this.flowlayoutMoveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowlayoutMoveButton.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowlayoutMoveButton.Location = new System.Drawing.Point(441, 433);
            this.flowlayoutMoveButton.Name = "flowlayoutMoveButton";
            this.flowlayoutMoveButton.Size = new System.Drawing.Size(213, 35);
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(660, 433);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(213, 35);
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
            // buttonConvert
            // 
            this.buttonConvert.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonConvert.Location = new System.Drawing.Point(354, 3);
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
            this.dropdownProfiles.Location = new System.Drawing.Point(135, 4);
            this.dropdownProfiles.Name = "dropdownProfiles";
            this.dropdownProfiles.Size = new System.Drawing.Size(213, 21);
            this.dropdownProfiles.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.buttonConvert);
            this.flowLayoutPanel2.Controls.Add(this.dropdownProfiles);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 433);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(432, 35);
            this.flowLayoutPanel2.TabIndex = 9;
            // 
            // selectListDicom
            // 
            this.selectListDicom.CheckOnClick = true;
            this.selectListDicom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectListDicom.FormattingEnabled = true;
            this.selectListDicom.Location = new System.Drawing.Point(3, 3);
            this.selectListDicom.Name = "selectListDicom";
            this.selectListDicom.Size = new System.Drawing.Size(432, 424);
            this.selectListDicom.TabIndex = 8;
            // 
            // DriveList
            // 
            this.DriveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DriveList.FormattingEnabled = true;
            this.DriveList.Location = new System.Drawing.Point(660, 3);
            this.DriveList.Name = "DriveList";
            this.DriveList.Size = new System.Drawing.Size(213, 424);
            this.DriveList.TabIndex = 5;
            // 
            // checklistMovieFiles
            // 
            this.checklistMovieFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checklistMovieFiles.FormattingEnabled = true;
            this.checklistMovieFiles.Location = new System.Drawing.Point(441, 3);
            this.checklistMovieFiles.Name = "checklistMovieFiles";
            this.checklistMovieFiles.Size = new System.Drawing.Size(213, 424);
            this.checklistMovieFiles.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 471);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Dicom To Movie";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowlayoutMoveButton.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

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

    }
}