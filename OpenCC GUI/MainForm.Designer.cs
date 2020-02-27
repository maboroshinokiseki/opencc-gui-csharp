namespace OpenCC_GUI
{
    partial class Form_Main
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
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
            this.comboBox_Config = new System.Windows.Forms.ComboBox();
            this.button_Convert = new System.Windows.Forms.Button();
            this.textBox_Content = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel_Main = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_FileButtons = new System.Windows.Forms.TableLayoutPanel();
            this.button_Select = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.panel_Content = new System.Windows.Forms.Panel();
            this.dataGridView_FileList = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel_ConfigAndConvert = new System.Windows.Forms.TableLayoutPanel();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simplifiedChineseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traditionalChineseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tableLayoutPanel_Main.SuspendLayout();
            this.tableLayoutPanel_FileButtons.SuspendLayout();
            this.panel_Content.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_FileList)).BeginInit();
            this.tableLayoutPanel_ConfigAndConvert.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(202, 6);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(161, 6);
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(161, 6);
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(161, 6);
            // 
            // comboBox_Config
            // 
            this.comboBox_Config.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Config.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Config.FormattingEnabled = true;
            this.comboBox_Config.Location = new System.Drawing.Point(3, 4);
            this.comboBox_Config.Name = "comboBox_Config";
            this.comboBox_Config.Size = new System.Drawing.Size(297, 21);
            this.comboBox_Config.TabIndex = 0;
            this.comboBox_Config.SelectedIndexChanged += new System.EventHandler(this.comboBox_Config_SelectedIndexChanged);
            // 
            // button_Convert
            // 
            this.button_Convert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Convert.Location = new System.Drawing.Point(306, 3);
            this.button_Convert.Name = "button_Convert";
            this.button_Convert.Size = new System.Drawing.Size(475, 23);
            this.button_Convert.TabIndex = 2;
            this.button_Convert.Text = "Convert";
            this.button_Convert.UseVisualStyleBackColor = true;
            this.button_Convert.Click += new System.EventHandler(this.button_Convert_Click);
            // 
            // textBox_Content
            // 
            this.textBox_Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Content.Location = new System.Drawing.Point(0, 0);
            this.textBox_Content.MaxLength = 0;
            this.textBox_Content.Multiline = true;
            this.textBox_Content.Name = "textBox_Content";
            this.textBox_Content.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Content.Size = new System.Drawing.Size(778, 473);
            this.textBox_Content.TabIndex = 3;
            // 
            // tableLayoutPanel_Main
            // 
            this.tableLayoutPanel_Main.ColumnCount = 1;
            this.tableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Main.Controls.Add(this.tableLayoutPanel_FileButtons, 0, 2);
            this.tableLayoutPanel_Main.Controls.Add(this.panel_Content, 0, 1);
            this.tableLayoutPanel_Main.Controls.Add(this.tableLayoutPanel_ConfigAndConvert, 0, 0);
            this.tableLayoutPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Main.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel_Main.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_Main.Name = "tableLayoutPanel_Main";
            this.tableLayoutPanel_Main.RowCount = 3;
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_Main.Size = new System.Drawing.Size(784, 537);
            this.tableLayoutPanel_Main.TabIndex = 8;
            // 
            // tableLayoutPanel_FileButtons
            // 
            this.tableLayoutPanel_FileButtons.AutoSize = true;
            this.tableLayoutPanel_FileButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel_FileButtons.ColumnCount = 2;
            this.tableLayoutPanel_FileButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_FileButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_FileButtons.Controls.Add(this.button_Select, 0, 0);
            this.tableLayoutPanel_FileButtons.Controls.Add(this.button_Clear, 1, 0);
            this.tableLayoutPanel_FileButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel_FileButtons.Location = new System.Drawing.Point(0, 508);
            this.tableLayoutPanel_FileButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_FileButtons.Name = "tableLayoutPanel_FileButtons";
            this.tableLayoutPanel_FileButtons.RowCount = 1;
            this.tableLayoutPanel_FileButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_FileButtons.Size = new System.Drawing.Size(784, 29);
            this.tableLayoutPanel_FileButtons.TabIndex = 9;
            // 
            // button_Select
            // 
            this.button_Select.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Select.Location = new System.Drawing.Point(3, 3);
            this.button_Select.Name = "button_Select";
            this.button_Select.Size = new System.Drawing.Size(386, 23);
            this.button_Select.TabIndex = 6;
            this.button_Select.Text = "Select files...";
            this.button_Select.UseVisualStyleBackColor = true;
            this.button_Select.Visible = false;
            this.button_Select.Click += new System.EventHandler(this.button_Select_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Clear.Location = new System.Drawing.Point(395, 3);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(386, 23);
            this.button_Clear.TabIndex = 7;
            this.button_Clear.Text = "Clear list";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Visible = false;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // panel_Content
            // 
            this.panel_Content.Controls.Add(this.dataGridView_FileList);
            this.panel_Content.Controls.Add(this.textBox_Content);
            this.panel_Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Content.Location = new System.Drawing.Point(3, 32);
            this.panel_Content.Name = "panel_Content";
            this.panel_Content.Size = new System.Drawing.Size(778, 473);
            this.panel_Content.TabIndex = 10;
            // 
            // dataGridView_FileList
            // 
            this.dataGridView_FileList.AllowUserToAddRows = false;
            this.dataGridView_FileList.AllowUserToDeleteRows = false;
            this.dataGridView_FileList.AllowUserToOrderColumns = true;
            this.dataGridView_FileList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_FileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_FileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_FileList.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_FileList.Name = "dataGridView_FileList";
            this.dataGridView_FileList.ReadOnly = true;
            this.dataGridView_FileList.RowHeadersVisible = false;
            this.dataGridView_FileList.RowHeadersWidth = 51;
            this.dataGridView_FileList.Size = new System.Drawing.Size(778, 473);
            this.dataGridView_FileList.TabIndex = 6;
            this.dataGridView_FileList.Visible = false;
            // 
            // tableLayoutPanel_ConfigAndConvert
            // 
            this.tableLayoutPanel_ConfigAndConvert.AutoSize = true;
            this.tableLayoutPanel_ConfigAndConvert.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel_ConfigAndConvert.ColumnCount = 2;
            this.tableLayoutPanel_ConfigAndConvert.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_ConfigAndConvert.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_ConfigAndConvert.Controls.Add(this.button_Convert, 1, 0);
            this.tableLayoutPanel_ConfigAndConvert.Controls.Add(this.comboBox_Config, 0, 0);
            this.tableLayoutPanel_ConfigAndConvert.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel_ConfigAndConvert.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_ConfigAndConvert.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_ConfigAndConvert.Name = "tableLayoutPanel_ConfigAndConvert";
            this.tableLayoutPanel_ConfigAndConvert.RowCount = 1;
            this.tableLayoutPanel_ConfigAndConvert.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_ConfigAndConvert.Size = new System.Drawing.Size(784, 29);
            this.tableLayoutPanel_ConfigAndConvert.TabIndex = 11;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            toolStripSeparator1,
            this.convertTextToolStripMenuItem,
            this.convertFilesToolStripMenuItem,
            toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.loadToolStripMenuItem.Text = "&Load...";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.saveToolStripMenuItem.Text = "Convert && &Save...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // convertTextToolStripMenuItem
            // 
            this.convertTextToolStripMenuItem.Name = "convertTextToolStripMenuItem";
            this.convertTextToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.convertTextToolStripMenuItem.Text = "Convert text";
            this.convertTextToolStripMenuItem.Click += new System.EventHandler(this.convertTextToolStripMenuItem_Click);
            // 
            // convertFilesToolStripMenuItem
            // 
            this.convertFilesToolStripMenuItem.Name = "convertFilesToolStripMenuItem";
            this.convertFilesToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.convertFilesToolStripMenuItem.Text = "Convert files";
            this.convertFilesToolStripMenuItem.Click += new System.EventHandler(this.convertFilesToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            toolStripSeparator3,
            this.clearToolStripMenuItem,
            toolStripSeparator4,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            toolStripSeparator5,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.simplifiedChineseToolStripMenuItem,
            this.traditionalChineseToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // simplifiedChineseToolStripMenuItem
            // 
            this.simplifiedChineseToolStripMenuItem.Name = "simplifiedChineseToolStripMenuItem";
            this.simplifiedChineseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.simplifiedChineseToolStripMenuItem.Text = "简体中文";
            this.simplifiedChineseToolStripMenuItem.Click += new System.EventHandler(this.simplifiedChineseToolStripMenuItem_Click);
            // 
            // traditionalChineseToolStripMenuItem
            // 
            this.traditionalChineseToolStripMenuItem.Name = "traditionalChineseToolStripMenuItem";
            this.traditionalChineseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.traditionalChineseToolStripMenuItem.Text = "繁體中文";
            this.traditionalChineseToolStripMenuItem.Click += new System.EventHandler(this.traditionalChineseToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.languageToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "menuStrip1";
            // 
            // Form_Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel_Main);
            this.Controls.Add(this.menuStrip);
            this.MinimumSize = new System.Drawing.Size(339, 98);
            this.Name = "Form_Main";
            this.Text = "Open Chinese Convert";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form_Main_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_Main_DragEnter);
            this.Resize += new System.EventHandler(this.Form_Main_Resize);
            this.tableLayoutPanel_Main.ResumeLayout(false);
            this.tableLayoutPanel_Main.PerformLayout();
            this.tableLayoutPanel_FileButtons.ResumeLayout(false);
            this.panel_Content.ResumeLayout(false);
            this.panel_Content.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_FileList)).EndInit();
            this.tableLayoutPanel_ConfigAndConvert.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Config;
        private System.Windows.Forms.Button button_Convert;
        private System.Windows.Forms.TextBox textBox_Content;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Main;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_FileButtons;
        private System.Windows.Forms.Button button_Select;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Panel panel_Content;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_ConfigAndConvert;
        private System.Windows.Forms.DataGridView dataGridView_FileList;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem simplifiedChineseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traditionalChineseToolStripMenuItem;
    }
}

