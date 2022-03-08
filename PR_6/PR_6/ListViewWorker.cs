using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR_6
{
    /// <summary>
    /// Класс для работы с отображением выбранных файлов в листвью
    /// </summary>
    public class ListViewWorker
    {
        public static List<string> filesName = new List<string>();//Список для хранения пути всех добавленных в листвью файлов 
        public static bool IsWorkingArchive = false;//Переменная для проверки работы с архивом
        /// <summary>
        /// Выводит файлы в листвью
        /// </summary>
        /// <param name="listView">Листвью в который нужно вывести файлы</param>
        public static void PrintFiles(ListView listView)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                listView.Clear();
                filesName = dialog.FileNames.ToList();
                foreach (string file in filesName)
                {
                    FileInfo infoFile = new FileInfo(file);
                    ListViewItem item = new ListViewItem();

                    switch (infoFile.Extension)
                    {
                        case ".txt":
                            item.ImageIndex = 1;
                            break;
                        case ".exe":
                            item.ImageIndex = 0;
                            break;
                        case ".png":
                            item.ImageIndex = 2;
                            break;
                        case ".jpeg":
                            item.ImageIndex = 3;
                            break;
                        default:
                            item.ImageIndex = 4;
                            break;
                    }

                    item.Text = infoFile.Name;
                    listView.Items.Add(item);
                }
            }
            IsWorkingArchive = false;
        }

        /// <summary>
        /// Выводит файлы в листвью из выбранной папки
        /// </summary>
        /// <param name="listView">Листвью в который нужно вывести файлы</param>
        /// <param name="lableInfo">Метка для отображения с чем в данный момент идет работа</param>
        public static void PrintFilesFromFolder(ListView listView, Label lableInfo)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                listView.Clear();
                lableInfo.Text = dialog.SelectedPath;
                filesName = Directory.GetFiles(dialog.SelectedPath).ToList();
                foreach (string file in filesName)
                {
                    FileInfo infoFile = new FileInfo(file);
                    ListViewItem item = new ListViewItem();

                    switch (infoFile.Extension)
                    {
                        case ".txt":
                            item.ImageIndex = 1;
                            break;
                        case ".exe":
                            item.ImageIndex = 0;
                            break;
                        case ".png":
                            item.ImageIndex = 2;
                            break;
                        case ".jpeg":
                            item.ImageIndex = 3;
                            break;
                        case "":
                            item.ImageIndex = 5;
                            break;
                        default:
                            item.ImageIndex = 4;
                            break;
                    }
                    if (infoFile.Extension == "")
                    {
                        DirectoryInfo infoFolder = new DirectoryInfo(file);
                        item.Text = infoFolder.Name;
                    }
                    else
                    {
                        item.Text = infoFile.Name;
                    }
                    listView.Items.Add(item);
                }
            }
            IsWorkingArchive = false;
        }

        /// <summary>
        /// Выводит файлы в листвью из выбранного архива и возвращает имя выбранного ахива
        /// </summary>
        /// <param name="listView">Листвью в который нужно вывести файлы</param>
        /// <param name="labelInfo">Метка для отображения с чем в данный момент идет работа</param>
        /// <returns>Имя выбранного архива</returns>
        public static string PrintFilesFromArchive(ListView listView, Label labelInfo)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "(*.zip)|*.zip|(*.rar)|*.rar";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                listView.Clear();
                labelInfo.Text = openFile.FileName;
                using (ZipFile zip = new ZipFile(openFile.FileName, Encoding.UTF8))
                {
                    foreach (ZipEntry entry in zip)
                    {
                        filesName.Add(entry.FileName);
                        FileInfo infoFile = new FileInfo(entry.FileName);
                        ListViewItem item = new ListViewItem();
                        switch (infoFile.Extension)
                        {
                            case ".txt":
                                item.ImageIndex = 1;
                                break;
                            case ".exe":
                                item.ImageIndex = 0;
                                break;
                            case ".png":
                                item.ImageIndex = 2;
                                break;
                            case ".jpeg":
                                item.ImageIndex = 3;
                                break;
                            case "":
                                item.ImageIndex = 5;
                                break;
                            default:
                                item.ImageIndex = 4;
                                break;
                        }
                        if (infoFile.Extension == "")
                        {
                            DirectoryInfo infoFolder = new DirectoryInfo(entry.FileName);
                            item.Text = infoFolder.Name;
                        }
                        else
                        {
                            item.Text = infoFile.Name;
                        }
                        listView.Items.Add(item);
                    }
                }
            }
            IsWorkingArchive = true;
            return openFile.FileName;
        }

        /// <summary>
        /// Обновляет информацию в листвью
        /// </summary>
        /// <param name="pathArchive">путь к архиву обновления</param>
        /// <param name="listView">Листвью в котором идет работа с файлами</param>
        public static void UpdateListView(string pathArchive, ListView listView)
        {
            listView.Clear();
            using (ZipFile zip = new ZipFile(pathArchive, Encoding.UTF8))
            {
                foreach (ZipEntry entry in zip)
                {
                    FileInfo infoFile = new FileInfo(entry.FileName);
                    ListViewItem item = new ListViewItem();

                    switch (infoFile.Extension)
                    {
                        case ".txt":
                            item.ImageIndex = 1;
                            break;
                        case ".exe":
                            item.ImageIndex = 0;
                            break;
                        case ".png":
                            item.ImageIndex = 2;
                            break;
                        case ".jpeg":
                            item.ImageIndex = 3;
                            break;
                        case "":
                            item.ImageIndex = 5;
                            break;
                        default:
                            item.ImageIndex = 4;
                            break;
                    }
                    if (infoFile.Extension == "")
                    {
                        DirectoryInfo infoFolder = new DirectoryInfo(entry.FileName);
                        item.Text = infoFolder.Name;
                    }
                    else
                    {
                        item.Text = infoFile.Name;
                    }
                    listView.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// Метод работает в связке с драг ин дроп , отображает добавленный на листвью элемент
        /// </summary>
        /// <param name="filesName">Имя добавленного файла(файлов)</param>
        /// <param name="listView">Листвью с которым идет работа</param>
        public static void AddItemInListView(string[] filesName, ListView listView)
        {
            foreach (string file in filesName)
            {
                FileInfo infoFile = new FileInfo(file);
                ListViewItem item = new ListViewItem();

                //Можно вынести в отдельный метод, чтобы избежать дублирования кода
                switch (infoFile.Extension)
                {
                    case ".txt":
                        item.ImageIndex = 1;
                        break;
                    case ".exe":
                        item.ImageIndex = 0;
                        break;
                    case ".png":
                        item.ImageIndex = 2;
                        break;
                    case ".jpeg":
                        item.ImageIndex = 3;
                        break;
                    case "":
                        item.ImageIndex = 5;
                        break;
                    default:
                        item.ImageIndex = 4;
                        break;
                }
                if (infoFile.Extension == "")
                {
                    DirectoryInfo infoFolder = new DirectoryInfo(file);
                    item.Text = infoFolder.Name;
                }
                else
                {
                    item.Text = infoFile.Name;
                }
                listView.Items.Add(item);
            }
        }
    }
}
