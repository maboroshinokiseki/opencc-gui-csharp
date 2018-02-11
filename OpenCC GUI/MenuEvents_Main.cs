using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCC_GUI
{
    public partial class Form_Main : Form
    {
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileBrowser = new OpenFileDialog();
            switch (currentWindow)
            {
                case CurrentWindow.Text:
                    fileBrowser.Multiselect = false;
                    break;
                case CurrentWindow.FileList:
                    fileBrowser.Multiselect = true;
                    break;
            }
            fileBrowser.ShowDialog();
            switch (currentWindow)
            {
                case CurrentWindow.Text:
                    PutFileContentToTextBox(fileBrowser.FileName);
                    break;
                case CurrentWindow.FileList:
                    PutFileNamesToListView(fileBrowser.FileNames);
                    break;
            }
        }

        private async void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileBrowser = new OpenFileDialog();
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult dialogResult = DialogResult.None;

            switch (currentWindow)
            {
                case CurrentWindow.Text:
                    dialogResult = fileBrowser.ShowDialog();
                    break;
                case CurrentWindow.FileList:
                    dialogResult = folderBrowser.ShowDialog();
                    break;
            }

            if (dialogResult == DialogResult.OK)
            {
                switch (currentWindow)
                {
                    case CurrentWindow.Text:
                        string result = await Task.Run(() => Converter.Convert(textBox_Content.Text, ((TextValuePair)comboBox_Config.SelectedItem).Value));
                        if (result != null)
                        {
                            System.IO.File.WriteAllText(fileBrowser.FileName, result, Encoding.UTF8);
                        }
                        break;
                    case CurrentWindow.FileList:
                        ConvertAndStoreFilesInListView(folderBrowser.SelectedPath);
                        break;
                }
            }
        }

        private void convertTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_Content.Visible = true;
            listView_Files.Visible = false;
            button_Select.Visible = false;
            button_Clear.Visible = false;
            currentWindow = CurrentWindow.Text;
        }

        private void convertFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_Content.Visible = false;
            listView_Files.Visible = true;
            button_Select.Visible = true;
            button_Clear.Visible = true;
            currentWindow = CurrentWindow.FileList;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_Content.Clear();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_Content.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_Content.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_Content.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_Content.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_Content.Paste(string.Empty);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_Content.SelectAll();
        }
    }
}
