using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
            TextValuePair[] configs = new TextValuePair[]
            {
                new TextValuePair("Simplified to Traditional", "s2t.json"),
                new TextValuePair("Traditional to Simplified", "t2s.json"),
                new TextValuePair("Simplified to Hong Kong", "s2hk.json"),
                new TextValuePair("Simplified to Taiwan", "s2tw.json"),
                new TextValuePair("Simplified to Taiwan with Taiwanese idiom", "s2twp.json"),
                new TextValuePair("Hong Kong to Simplified", "hk2s.json"),
                new TextValuePair("Taiwan to Simplified", "tw2s.json"),
                new TextValuePair("Taiwan to Simplified with Mainland idiom", "tw2sp.json"),
                new TextValuePair("Traditional to Taiwan", "t2tw.json"),
                new TextValuePair("Traditional to Hong Kong", "t2hk.json"),
            };
            comboBox_Config.Items.AddRange(configs);
            comboBox_Config.SelectedIndex = 0;

            textBox_Content.MaxLength = int.MaxValue;
            textBox_Content.ScrollBars = ScrollBars.Vertical;

            spaceBetweenBoxes = button_Convert.Left - (comboBox_Config.Left + comboBox_Config.Width);
            margin = comboBox_Config.Left;

            fileListItems = FileListUtility.CreateNewBindingList();
            dataGridView_FileList.DataSource = FileListUtility.CreateNewBindingSource(fileListItems);
            this.ResizeControls();
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
            fileListItems = FileListUtility.CreateNewBindingList();
            dataGridView_FileList.DataSource = FileListUtility.CreateNewBindingSource(fileListItems);
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
    }
}
