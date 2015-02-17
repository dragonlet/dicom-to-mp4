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
            this.selectListDicom = new System.Windows.Forms.CheckedListBox();
            this.dropdownProfiles = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanelConvertButton = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.checklistMovieFiles = new System.Windows.Forms.CheckedListBox();
            this.flowlayoutMoveButton = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonMoveTo = new System.Windows.Forms.Button();
            this.FileNavigator = new System.Windows.Forms.ListView();
            this.moveToPath = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanelConvertButton.SuspendLayout();
            this.flowlayoutMoveButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.selectListDicom, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dropdownProfiles, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelConvertButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.checklistMovieFiles, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowlayoutMoveButton, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.FileNavigator, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(876, 471);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // selectListDicom
            // 
            this.selectListDicom.CheckOnClick = true;
            this.selectListDicom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectListDicom.FormattingEnabled = true;
            this.selectListDicom.Location = new System.Drawing.Point(3, 3);
            this.selectListDicom.Name = "selectListDicom";
            this.tableLayoutPanel1.SetRowSpan(this.selectListDicom, 3);
            this.selectListDicom.Size = new System.Drawing.Size(213, 465);
            this.selectListDicom.TabIndex = 0;
            // 
            // dropdownProfiles
            // 
            this.dropdownProfiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dropdownProfiles.FormattingEnabled = true;
            this.dropdownProfiles.Items.AddRange(new object[] {
            "test",
            "test1",
            "test2"});
            this.dropdownProfiles.Location = new System.Drawing.Point(222, 3);
            this.dropdownProfiles.Name = "dropdownProfiles";
            this.dropdownProfiles.Size = new System.Drawing.Size(213, 21);
            this.dropdownProfiles.TabIndex = 1;
            // 
            // flowLayoutPanelConvertButton
            // 
            this.flowLayoutPanelConvertButton.Controls.Add(this.buttonConvert);
            this.flowLayoutPanelConvertButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelConvertButton.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanelConvertButton.Location = new System.Drawing.Point(222, 426);
            this.flowLayoutPanelConvertButton.Name = "flowLayoutPanelConvertButton";
            this.flowLayoutPanelConvertButton.Size = new System.Drawing.Size(213, 42);
            this.flowLayoutPanelConvertButton.TabIndex = 2;
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(135, 3);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(75, 23);
            this.buttonConvert.TabIndex = 0;
            this.buttonConvert.Text = "Convert -->";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // checklistMovieFiles
            // 
            this.checklistMovieFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checklistMovieFiles.FormattingEnabled = true;
            this.checklistMovieFiles.Location = new System.Drawing.Point(441, 3);
            this.checklistMovieFiles.Name = "checklistMovieFiles";
            this.tableLayoutPanel1.SetRowSpan(this.checklistMovieFiles, 2);
            this.checklistMovieFiles.Size = new System.Drawing.Size(213, 417);
            this.checklistMovieFiles.TabIndex = 3;
            // 
            // flowlayoutMoveButton
            // 
            this.flowlayoutMoveButton.Controls.Add(this.buttonMoveTo);
            this.flowlayoutMoveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowlayoutMoveButton.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowlayoutMoveButton.Location = new System.Drawing.Point(441, 426);
            this.flowlayoutMoveButton.Name = "flowlayoutMoveButton";
            this.flowlayoutMoveButton.Size = new System.Drawing.Size(213, 42);
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
            // FileNavigator
            // 
            this.FileNavigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileNavigator.Location = new System.Drawing.Point(660, 3);
            this.FileNavigator.Name = "FileNavigator";
            this.tableLayoutPanel1.SetRowSpan(this.FileNavigator, 3);
            this.FileNavigator.Size = new System.Drawing.Size(213, 465);
            this.FileNavigator.TabIndex = 5;
            this.FileNavigator.UseCompatibleStateImageBehavior = false;
            // 
            // moveToPath
            // 
            this.moveToPath.RootFolder = System.Environment.SpecialFolder.MyComputer;
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
            this.flowLayoutPanelConvertButton.ResumeLayout(false);
            this.flowlayoutMoveButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckedListBox selectListDicom;
        private System.Windows.Forms.ComboBox dropdownProfiles;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelConvertButton;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.CheckedListBox checklistMovieFiles;
        private System.Windows.Forms.FlowLayoutPanel flowlayoutMoveButton;
        private System.Windows.Forms.Button buttonMoveTo;
        private System.Windows.Forms.ListView FileNavigator;
        private System.Windows.Forms.FolderBrowserDialog moveToPath;
    }
}