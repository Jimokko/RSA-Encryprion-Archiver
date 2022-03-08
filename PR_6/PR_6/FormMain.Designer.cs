
namespace PR_6
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.encryptArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openArcviveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveArchiveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.decryptArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewFiles = new System.Windows.Forms.ListView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inforamtionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListEncryption = new System.Windows.Forms.ImageList(this.components);
            this.labelInfoAboutWork = new System.Windows.Forms.Label();
            this.mainMenu.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.Color.Gray;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem,
            this.archiveToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1273, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFilesToolStripMenuItem,
            this.openFolderToolStripMenuItem,
            this.toolStripSeparator1,
            this.encryptArchiveToolStripMenuItem});
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.filesToolStripMenuItem.Text = "Файлы";
            // 
            // openFilesToolStripMenuItem
            // 
            this.openFilesToolStripMenuItem.Name = "openFilesToolStripMenuItem";
            this.openFilesToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.openFilesToolStripMenuItem.Text = "Выбрать файлы";
            this.openFilesToolStripMenuItem.Click += new System.EventHandler(this.OpenFilesToolStripMenuItemOnClick);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.openFolderToolStripMenuItem.Text = "Выбрать папку";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.OpenFolderToolStripMenuItemOnClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // encryptArchiveToolStripMenuItem
            // 
            this.encryptArchiveToolStripMenuItem.Name = "encryptArchiveToolStripMenuItem";
            this.encryptArchiveToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.encryptArchiveToolStripMenuItem.Text = "Зашифровать";
            this.encryptArchiveToolStripMenuItem.Click += new System.EventHandler(this.EncryptArchiveToolStripMenuItemOnClick);
            // 
            // archiveToolStripMenuItem
            // 
            this.archiveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openArcviveToolStripMenuItem,
            this.saveArchiveToolStripMenuItem,
            this.saveArchiveAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.decryptArchiveToolStripMenuItem});
            this.archiveToolStripMenuItem.Name = "archiveToolStripMenuItem";
            this.archiveToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.archiveToolStripMenuItem.Text = "Архив";
            // 
            // openArcviveToolStripMenuItem
            // 
            this.openArcviveToolStripMenuItem.Name = "openArcviveToolStripMenuItem";
            this.openArcviveToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.openArcviveToolStripMenuItem.Text = "Открыть";
            this.openArcviveToolStripMenuItem.Click += new System.EventHandler(this.OpenArcviveToolStripMenuItemOnClick);
            // 
            // saveArchiveToolStripMenuItem
            // 
            this.saveArchiveToolStripMenuItem.Name = "saveArchiveToolStripMenuItem";
            this.saveArchiveToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.saveArchiveToolStripMenuItem.Text = "Сохранить";
            this.saveArchiveToolStripMenuItem.Click += new System.EventHandler(this.SaveArchiveToolStripMenuItemOnClick);
            // 
            // saveArchiveAsToolStripMenuItem
            // 
            this.saveArchiveAsToolStripMenuItem.Name = "saveArchiveAsToolStripMenuItem";
            this.saveArchiveAsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.saveArchiveAsToolStripMenuItem.Text = "Сохранить как...";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(165, 6);
            // 
            // decryptArchiveToolStripMenuItem
            // 
            this.decryptArchiveToolStripMenuItem.Name = "decryptArchiveToolStripMenuItem";
            this.decryptArchiveToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.decryptArchiveToolStripMenuItem.Text = "Разархивировать";
            this.decryptArchiveToolStripMenuItem.Click += new System.EventHandler(this.DecryptArchiveToolStripMenuItemOnClick);
            // 
            // listViewFiles
            // 
            this.listViewFiles.AllowDrop = true;
            this.listViewFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewFiles.ContextMenuStrip = this.contextMenuStrip;
            this.listViewFiles.HideSelection = false;
            this.listViewFiles.LargeImageList = this.imageListEncryption;
            this.listViewFiles.Location = new System.Drawing.Point(12, 60);
            this.listViewFiles.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.listViewFiles.Name = "listViewFiles";
            this.listViewFiles.Size = new System.Drawing.Size(1249, 584);
            this.listViewFiles.TabIndex = 1;
            this.listViewFiles.UseCompatibleStateImageBehavior = false;
            this.listViewFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListViewFilesOnDragDrop);
            this.listViewFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListViewFilesOnDragEnter);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createFolderToolStripMenuItem,
            this.inforamtionToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(153, 70);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripIsOpening);
            // 
            // createFolderToolStripMenuItem
            // 
            this.createFolderToolStripMenuItem.Name = "createFolderToolStripMenuItem";
            this.createFolderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.createFolderToolStripMenuItem.Text = "Создать папку";
            this.createFolderToolStripMenuItem.Click += new System.EventHandler(this.CreateFolderToolStripMenuItemOnClick);
            // 
            // inforamtionToolStripMenuItem
            // 
            this.inforamtionToolStripMenuItem.Name = "inforamtionToolStripMenuItem";
            this.inforamtionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.inforamtionToolStripMenuItem.Text = "Свойства";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Удалить";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItemOnClick);
            // 
            // imageListEncryption
            // 
            this.imageListEncryption.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListEncryption.ImageStream")));
            this.imageListEncryption.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListEncryption.Images.SetKeyName(0, "exe");
            this.imageListEncryption.Images.SetKeyName(1, "txt");
            this.imageListEncryption.Images.SetKeyName(2, "png");
            this.imageListEncryption.Images.SetKeyName(3, "jpeg");
            this.imageListEncryption.Images.SetKeyName(4, "enother");
            this.imageListEncryption.Images.SetKeyName(5, "folder");
            // 
            // labelInfoAboutWork
            // 
            this.labelInfoAboutWork.AutoSize = true;
            this.labelInfoAboutWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInfoAboutWork.Location = new System.Drawing.Point(12, 33);
            this.labelInfoAboutWork.Name = "labelInfoAboutWork";
            this.labelInfoAboutWork.Size = new System.Drawing.Size(0, 24);
            this.labelInfoAboutWork.TabIndex = 2;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1273, 656);
            this.Controls.Add(this.labelInfoAboutWork);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.listViewFiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RSA-Архиватор";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFilesToolStripMenuItem;
        private System.Windows.Forms.ListView listViewFiles;
        private System.Windows.Forms.ToolStripMenuItem encryptArchiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ImageList imageListEncryption;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem archiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openArcviveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveArchiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveArchiveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem decryptArchiveToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem createFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inforamtionToolStripMenuItem;
        private System.Windows.Forms.Label labelInfoAboutWork;
    }
}

