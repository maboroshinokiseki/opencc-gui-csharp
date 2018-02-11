using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCC_GUI
{
    public partial class Form_Main : Form
    {
        private static int spaceBetweenBoxes;
        private static int margin;
        private static CurrentWindow currentWindow = CurrentWindow.Text;

        private enum CurrentWindow
        {
            Text,
            FileList
        }

        private void ResizeControls()
        {
            // I can't find a better way to limit the minimum size of a cell.
            int halfWindowControlWidth = this.ClientSize.Width / 2 - spaceBetweenBoxes / 2 - margin;
            comboBox_Config.Width = halfWindowControlWidth < 200 ? 200 : halfWindowControlWidth;
        }

        private void PutFileContentToTextBox(string fileName)
        {
            textBox_Content.Text = System.IO.File.ReadAllText(fileName);
        }

        private void PutFileNamesToListView(string[] fileNames)
        {
            foreach (var fileName in fileNames)
            {
                listView_Files.Items.Add(fileName).SubItems.Add("");
            }
        }
        
        private void ConvertAndStoreFilesInListView(string outputFolder = null)
        {
            IProgress<Reportinfo> progress = new Progress<Reportinfo>(info =>
            {
                if (info.finishied)
                {
                    listView_Files.Items.Remove(info.item);
                }
                else
                {
                    info.item.SubItems[1].Text = info.message;
                }
            });

            string configFileName = ((TextValuePair)comboBox_Config.SelectedItem).Value;

            Parallel.ForEach(listView_Files.Items.Cast<ListViewItem>(), (item) =>
            {
                try
                {
                    string content = System.IO.File.ReadAllText(item.Text);
                    string result = Converter.Convert(content, configFileName);
                    if (result != null)
                    {
                        string outputPath;
                        if (outputFolder == null)
                        {
                            outputPath = item.Text;
                        }
                        else
                        {
                            outputPath = outputFolder + "\\" + System.IO.Path.GetFileName(item.Text);
                        }
                        System.IO.File.WriteAllText(outputPath, result, Encoding.UTF8);
                        progress.Report(new Reportinfo { finishied = true, item = item });
                    }
                    else
                    {
                        progress.Report(new Reportinfo { finishied = false, item = item , message = "OpenCC Unknown Error!" });
                    }
                }
                catch (Exception exception)
                {
                    progress.Report(new Reportinfo { finishied = false, item = item, message = exception.Message });
                }
            });
        }

        public Form_Main()
        {
            this.InitializeComponent();
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

            this.ResizeControls();
        }

        private async void button_Convert_Click(object sender, EventArgs e)
        {
            switch (currentWindow)
            {
                case CurrentWindow.Text:
                    string result = await Task.Run(() => Converter.Convert(textBox_Content.Text, ((TextValuePair)comboBox_Config.SelectedItem).Value));
                    if (result != null)
                    {
                        textBox_Content.Text = result;
                    }
                    break;
                case CurrentWindow.FileList:
                    ConvertAndStoreFilesInListView();
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
            PutFileNamesToListView(fileBrowser.FileNames);
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            listView_Files.Items.Clear();
        }

        private void Form_Main_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form_Main_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            switch (currentWindow)
            {
                case CurrentWindow.Text:
                    PutFileContentToTextBox(fileNames[0]);
                    break;
                case CurrentWindow.FileList:
                    PutFileNamesToListView(fileNames);
                    break;
            }
        }

        private void listView_Files_Resize(object sender, EventArgs e)
        {
            listView_Files.Columns[0].Width = listView_Files.Columns[1].Width = listView_Files.Width / 2 - SystemInformation.VerticalScrollBarWidth;
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

        private class Reportinfo
        {
            public bool finishied;
            public string message;
            public ListViewItem item;
        }
    }
}
