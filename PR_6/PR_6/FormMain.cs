using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Ionic.Zip;

namespace PR_6
{
    public partial class FormMain : Form
    {
        //Хранит путь к архиву, который открыт в настоящий момент
        static public string zipFullNameNow;
        public FormMain()
        {
            InitializeComponent();
            EncryptRSA.GetPartOfKeys(2, 100);
            EncryptRSA.Calculate_e();
            EncryptRSA.Calculate_d();
        }

        private void OpenFilesToolStripMenuItemOnClick(object sender, EventArgs e)
        {
            labelInfoAboutWork.Text = "Идет работа с файлами.";
            ListViewWorker.PrintFiles(listViewFiles);
        }

        private void OpenFolderToolStripMenuItemOnClick(object sender, EventArgs e)
        {
            ListViewWorker.PrintFilesFromFolder(listViewFiles, labelInfoAboutWork);
        }

        private void EncryptArchiveToolStripMenuItemOnClick(object sender, EventArgs e)
        {
            if (listViewFiles.Items.Count != 0)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "(*.zip)|*.zip|(*.rar)|*.rar";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    FileInfo info = new FileInfo(saveFile.FileName);
                    EncryptRSA.EncryptAnFiles(info.FullName.Replace(info.Name, ""));
                    ZipFile zip = new ZipFile(saveFile.FileName, System.Text.Encoding.UTF8);
                    zip.AddFiles(EncryptRSA.encryptFileName, "");
                    zip.Save();
                }

                foreach (string fileOnDelete in EncryptRSA.encryptFileName)
                {
                    File.Delete(fileOnDelete);
                }

            }
            else
            {
                MessageBox.Show("Файлы не были выбраны!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void OpenArcviveToolStripMenuItemOnClick(object sender, EventArgs e)
        {
            zipFullNameNow = ListViewWorker.PrintFilesFromArchive(listViewFiles, labelInfoAboutWork);
        }

        private void DecryptArchiveToolStripMenuItemOnClick(object sender, EventArgs e)
        {
            if (listViewFiles.Items.Count != 0)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    Directory.CreateDirectory(saveFile.FileName);
                    ZipFile zip = new ZipFile(zipFullNameNow);
                    zip.ExtractAll(saveFile.FileName);
                    EncryptRSA.DecryptAnFiles(Directory.GetFiles(saveFile.FileName));
                }
            }
            else
            {
                MessageBox.Show("Архив не был выбран или был пуст!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CreateFolderToolStripMenuItemOnClick(object sender, EventArgs e)
        {
            int counter = 0;
            using (ZipFile zip = new ZipFile(zipFullNameNow))
            {
                foreach (ZipEntry entry in zip)
                {
                    if (entry.FileName.Contains("New folder"))
                    {
                        counter++;
                    }
                }
                if (counter > 0)
                {
                    zip.AddDirectoryByName("New folder (" + counter + ")");
                }
                else
                {
                    zip.AddDirectoryByName("New folder");
                }
                zip.Save();
                ListViewWorker.UpdateListView(zipFullNameNow, listViewFiles);
            }
        }

        private void ContextMenuStripIsOpening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (listViewFiles.Items.Count == 0)
            {
                contextMenuStrip.Items[2].Visible = false;
            }
        }

        private void DeleteToolStripMenuItemOnClick(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count != 0)
            {
                foreach (ListViewItem item in listViewFiles.SelectedItems)
                {
                    ListViewWorker.filesName.Remove(item.Text);
                    item.Remove();
                }
            }
            else
            {
                MessageBox.Show("Файлы для удаления не были выбраны!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SaveArchiveToolStripMenuItemOnClick(object sender, EventArgs e)
        {
            List<string> fileNameFromDelete = new List<string>();
            using (ZipFile zip = new ZipFile(zipFullNameNow))
            {
                foreach (ZipEntry entry in zip)
                {
                    FileInfo info = new FileInfo(entry.FileName);
                    if (!ListViewWorker.filesName.Contains(info.Name))
                    {
                        fileNameFromDelete.Add(info.Name);
                    }
                }
                zip.RemoveEntries(fileNameFromDelete);
                zip.Save();
            }
        }

        private void ListViewFilesOnDragDrop(object sender, DragEventArgs e)
        {
            ListViewWorker.AddItemInListView((string[])e.Data.GetData(DataFormats.FileDrop), listViewFiles);

            ZipFile zip = new ZipFile(zipFullNameNow);
            FileInfo infoZip = new FileInfo(zip.Name);
            foreach (string fileName in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                FileInfo infoFile = new FileInfo(fileName);
                ListViewWorker.filesName.Add(infoFile.Name);
                EncryptRSA.EncryptAnFilesAddedToArchive(zip.Name.Replace(infoZip.Name, ""), fileName);
                zip.AddFiles(EncryptRSA.encryptFileName, "");
            }
            zip.Save();

            foreach (string fileOnDelete in EncryptRSA.encryptFileName)
            {
                File.Delete(fileOnDelete);
            }
        }

        private void ListViewFilesOnDragEnter(object sender, DragEventArgs e)
        {
            if (ListViewWorker.IsWorkingArchive)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
    }
}
