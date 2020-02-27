using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace OpenCC_GUI
{
    public partial class Form_Main : Form
    {
        private int spaceBetweenBoxes;
        private int margin;
        private string configFileName;
        private CurrentMode currentMode = CurrentMode.Text;

        private BindingList<FileListItem> fileListItems;

        public Form_Main()
        {
            this.InitializeComponent();
            fileListItems = new BindingList<FileListItem>();
            dataGridView_FileList.DataSource = fileListItems;
        }

        private enum CurrentMode
        {
            Text,
            FileList
        }

        private void ResizeControls()
        {
            // I can't find a better way to limit the minimum size of a cell.
            int halfWindowControlWidth = (this.ClientSize.Width / 2) - (this.spaceBetweenBoxes / 2) - this.margin;
            comboBox_Config.Width = halfWindowControlWidth < 200 ? 200 : halfWindowControlWidth;
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            ChangeLanguage(Properties.Settings.Default.Language);
            spaceBetweenBoxes = button_Convert.Left - (comboBox_Config.Left + comboBox_Config.Width);
            margin = comboBox_Config.Left;
            Size = Properties.Settings.Default.Size;
            this.ResizeControls();
        }
        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Size = Size;
            Properties.Settings.Default.Save();
        }

        private void button_Convert_Click(object sender, EventArgs e)
        {
            switch (currentMode)
            {
                case CurrentMode.Text:
                    try
                    {
                        textBox_Content.Text = Converter.Convert(textBox_Content.Text, configFileName);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }

                    break;
                case CurrentMode.FileList:
                    FileListUtility.ConvertAndStoreFilesInList(fileListItems, configFileName);
                    break;
            }
        }

        private void Form_Main_Resize(object sender, EventArgs e)
        {
            this.ResizeControls();
        }

        private void button_Select_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileBrowser = new OpenFileDialog();
            fileBrowser.Multiselect = true;
            fileBrowser.ShowDialog();
            FileListUtility.AppendFileList(fileListItems, fileBrowser.FileNames);
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            fileListItems.Clear();
        }

        private void Form_Main_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form_Main_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            switch (currentMode)
            {
                case CurrentMode.Text:
                    TextUtility.LoadTextToTextBox(textBox_Content, fileNames[0]);
                    break;
                case CurrentMode.FileList:
                    FileListUtility.AppendFileList(fileListItems, fileNames);
                    break;
            }
        }

        private void comboBox_Config_SelectedIndexChanged(object sender, EventArgs e)
        {
            configFileName = ((TextValuePair)comboBox_Config.SelectedItem).Value;
        }

        private class TextValuePair
        {
            public string Text;
            public string Value;

            public TextValuePair(string text, string value)
            {
                this.Text = text;
                this.Value = value;
            }

            public override string ToString()
            {
                return this.Text;
            }
        }

        private void ChangeLanguage(string lang)
        {
            Properties.Settings.Default.Language = lang;
            Properties.Settings.Default.Save();

            Localizer.InitLocalizedResource(lang);

            TextValuePair[] configs = new TextValuePair[]
            {
                new TextValuePair("s2t".Localize(), "s2t.json"),
                new TextValuePair("t2s".Localize(), "t2s.json"),
                new TextValuePair("s2hk".Localize(), "s2hk.json"),
                new TextValuePair("s2tw".Localize(), "s2tw.json"),
                new TextValuePair("s2twp".Localize(), "s2twp.json"),
                new TextValuePair("hk2s".Localize(), "hk2s.json"),
                new TextValuePair("tw2s".Localize(), "tw2s.json"),
                new TextValuePair("tw2sp".Localize(), "tw2sp.json"),
                new TextValuePair("t2tw".Localize(), "t2tw.json"),
                new TextValuePair("t2hk".Localize(), "t2hk.json"),
            };
            var origIndex = comboBox_Config.SelectedIndex;
            comboBox_Config.Items.Clear();
            comboBox_Config.Items.AddRange(configs);
            comboBox_Config.SelectedIndex = origIndex == -1 ? 0 : origIndex;

            fileToolStripMenuItem.Text = "File".Localize();
            loadToolStripMenuItem.Text = "Load".Localize();
            saveToolStripMenuItem.Text = "Save".Localize();
            convertTextToolStripMenuItem.Text = "ConvertText".Localize();
            convertFilesToolStripMenuItem.Text = "ConvertFiles".Localize();
            exitToolStripMenuItem.Text = "Exit".Localize();

            editToolStripMenuItem.Text = "Edit".Localize();
            undoToolStripMenuItem.Text = "Undo".Localize();
            clearToolStripMenuItem.Text = "Clear".Localize();
            cutToolStripMenuItem.Text = "Cut".Localize();
            copyToolStripMenuItem.Text = "Copy".Localize();
            pasteToolStripMenuItem.Text = "Paste".Localize();
            deleteToolStripMenuItem.Text = "Delete".Localize();
            selectAllToolStripMenuItem.Text = "SelectAll".Localize();

            languageToolStripMenuItem.Text = "Language".Localize();

            button_Convert.Text = "Convert".Localize();
            button_Select.Text = "SelectFiles".Localize();
            button_Clear.Text = "Clear".Localize();

            dataGridView_FileList.Columns["FileName"].HeaderText = "FileName".Localize();
            dataGridView_FileList.Columns["ErrorMessage"].HeaderText = "ErrorMessage".Localize();
        }
    }
}
