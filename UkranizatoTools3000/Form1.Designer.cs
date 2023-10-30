using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace UkranizatoTools3000
{
    partial class Form1 : Form
    {
        private IContainer components = null;
        private TextBox selectedPathTextBox;
        private Button selectPathButton;
        private Button searchFilesButton;
        private ListBox folderList;
        private TextBox newLocalizationFileNameTextBox;
        private Button createLocalizationFileButton;
        private Button editLocalizationFileButton;

        private TextBox englishTranslationTextBox;
        private TextBox ukrainianTranslationTextBox;
        private TextBox russianTranslationTextBox;
        private Button previousTranslationButton;
        private Button nextTranslationButton;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            var firstColor = Color.FromArgb(218, 215, 211);

            this.selectedPathTextBox = new TextBox();
            this.selectPathButton = new Button();
            this.searchFilesButton = new Button();
            this.folderList = new ListBox();
            this.newLocalizationFileNameTextBox = new TextBox();
            this.createLocalizationFileButton = new Button();
            this.editLocalizationFileButton = new Button();

            this.englishTranslationTextBox = new TextBox();
            this.ukrainianTranslationTextBox = new TextBox();
            this.russianTranslationTextBox = new TextBox();
            this.previousTranslationButton = new Button();
            this.nextTranslationButton = new Button();

            this.selectedPathTextBox.Location = new System.Drawing.Point(10, 10);
            this.selectedPathTextBox.Size = new System.Drawing.Size(560, 30);
            this.selectedPathTextBox.BackColor = firstColor;
            this.selectedPathTextBox.ReadOnly = true;
            this.selectedPathTextBox.Text = "Виберіть шлях до папки";
            this.Controls.Add(this.selectedPathTextBox);

            this.selectPathButton.Location = new System.Drawing.Point(580, 10);
            this.selectPathButton.Size = new System.Drawing.Size(150, 30);
            this.selectPathButton.Text = "Вибрати папку";
            this.selectPathButton.BackColor = firstColor;
            this.selectPathButton.Click += new System.EventHandler(this.selectPathButton_Click);
            this.Controls.Add(this.selectPathButton);

            this.searchFilesButton.Location = new System.Drawing.Point(10, 50);
            this.searchFilesButton.Size = new System.Drawing.Size(150, 30);
            this.searchFilesButton.Text = "Пошук файлів";
            this.searchFilesButton.BackColor = firstColor;
            this.searchFilesButton.Click += new System.EventHandler(this.searchFilesButton_Click);
            this.Controls.Add(this.searchFilesButton);

            this.folderList.Location = new System.Drawing.Point(10, 90);
            this.folderList.Size = new System.Drawing.Size(720, 200);
            this.folderList.BackColor = firstColor;
            this.Controls.Add(this.folderList);

            this.newLocalizationFileNameTextBox.Location = new System.Drawing.Point(10, 300);
            this.newLocalizationFileNameTextBox.Size = new System.Drawing.Size(300, 30);
            this.newLocalizationFileNameTextBox.Text = "Введіть ім'я нового файлу";
            this.Controls.Add(this.newLocalizationFileNameTextBox);

            this.createLocalizationFileButton.Location = new System.Drawing.Point(320, 300);
            this.createLocalizationFileButton.Size = new System.Drawing.Size(150, 30);
            this.createLocalizationFileButton.Text = "Створити файл локалізації";
            this.createLocalizationFileButton.BackColor = firstColor;
            this.createLocalizationFileButton.Click += new System.EventHandler(this.createLocalizationFileButton_Click);
            this.Controls.Add(this.createLocalizationFileButton);

            this.editLocalizationFileButton.Location = new System.Drawing.Point(480, 300);
            this.editLocalizationFileButton.Size = new System.Drawing.Size(90, 30);
            this.editLocalizationFileButton.Text = "Редагувати";
            this.editLocalizationFileButton.BackColor = firstColor;
            this.editLocalizationFileButton.Click += new System.EventHandler(this.editLocalizationFileButton_Click);
            this.Controls.Add(this.editLocalizationFileButton);

            this.englishTranslationTextBox.Location = new System.Drawing.Point(10, 350);
            this.englishTranslationTextBox.Size = new System.Drawing.Size(720, 30);
            this.englishTranslationTextBox.BackColor = firstColor;
            this.englishTranslationTextBox.ReadOnly = true;
            this.englishTranslationTextBox.Text = "Англійський переклад";
            this.Controls.Add(this.englishTranslationTextBox);

            this.ukrainianTranslationTextBox.Location = new System.Drawing.Point(10, 390);
            this.ukrainianTranslationTextBox.Size = new System.Drawing.Size(720, 30);
            this.ukrainianTranslationTextBox.BackColor = firstColor;
            this.ukrainianTranslationTextBox.Text = "Український переклад";
            this.Controls.Add(this.ukrainianTranslationTextBox);

            this.russianTranslationTextBox.Location = new System.Drawing.Point(10, 430);
            this.russianTranslationTextBox.Size = new System.Drawing.Size(720, 30);
            this.russianTranslationTextBox.BackColor = firstColor;
            this.russianTranslationTextBox.Text = "Російський переклад";
            this.Controls.Add(this.russianTranslationTextBox);

            this.previousTranslationButton.Location = new System.Drawing.Point(10, 470);
            this.previousTranslationButton.Size = new System.Drawing.Size(120, 30);
            this.previousTranslationButton.Text = "Попередній переклад";
            this.previousTranslationButton.BackColor = firstColor;
            this.previousTranslationButton.Click += new System.EventHandler(this.previousTranslationButton_Click);
            this.Controls.Add(this.previousTranslationButton);

            this.nextTranslationButton.Location = new System.Drawing.Point(140, 470);
            this.nextTranslationButton.Size = new System.Drawing.Size(120, 30);
            this.nextTranslationButton.Text = "Наступний переклад";
            this.nextTranslationButton.BackColor = firstColor;
            this.nextTranslationButton.Click += new System.EventHandler(this.nextTranslationButton_Click);
            this.Controls.Add(this.nextTranslationButton);

            this.Text = "UkranizatoTools3000";
            this.BackColor = Color.Gray;
            this.Width = 800;
            this.Height = 550;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
