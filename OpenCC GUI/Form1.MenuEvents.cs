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
            switch (currentMode)
            {
                case CurrentMode.Text:
                    fileBrowser.Multiselect = false;
                    break;
                case CurrentMode.FileList:
                    fileBrowser.Multiselect = true;
                    break;
            }

            fileBrowser.ShowDialog();
            switch (currentMode)
            {
                case CurrentMode.Text:
                    TextUtility.LoadTextToTextBox(textBox_Content, fileBrowser.FileName);
                    break;
                case CurrentMode.FileList:
                    FileListUtility.AppendFileList(fileListItems, fileBrowser.FileNames);
                    break;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileBrowser = new OpenFileDialog();
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult dialogResult = DialogResult.None;

            switch (currentMode)
            {
                case CurrentMode.Text:
                    dialogResult = fileBrowser.ShowDialog();
                    break;
                case CurrentMode.FileList:
                    dialogResult = folderBrowser.ShowDialog();
                    break;
            }

            if (dialogResult == DialogResult.OK)
            {
                switch (currentMode)
                {
                    case CurrentMode.Text:
                        try
                        {
                            string result = Converter.Convert(textBox_Content.Text, configFileName);
                            System.IO.File.WriteAllText(fileBrowser.FileName, result, Encoding.UTF8);
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message);
                        }

                        break;

                    case CurrentMode.FileList:
                        FileListUtility.ConvertAndStoreFilesInList(fileListItems, configFileName, folderBrowser.SelectedPath);
                        break;
                }
            }
        }

        private void convertTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_Content.Visible = true;
            dataGridView_FileList.Visible = false;
            button_Select.Visible = false;
            button_Clear.Visible = false;
            currentMode = CurrentMode.Text;
        }

        private void convertFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_Content.Visible = false;
            dataGridView_FileList.Visible = true;
            button_Select.Visible = true;
            button_Clear.Visible = true;
            currentMode = CurrentMode.FileList;
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
