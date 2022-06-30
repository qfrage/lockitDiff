using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;


namespace lockitDiff
{
    public partial class Form1 : Form
    {
        string selectedDirectory = Properties.Settings.Default.directory;
        string sheetID = Properties.Settings.Default.sheetid;
        string[] languages = { "en", "ar","de","es","fa","fr","hi","id","it","nl","pl","pt","ro","ru","th","tr","uk","vi","zh" };
        string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        string range = Properties.Settings.Default.range;

        int checkInAllLanguages = 1;
        bool checkProjInLockit = false;

        UserCredential credential;
        List<string> allFoundedSheets = new List<string>();
        List<string> allParsedFiles = new List<string>();
        List<string> allFoundedFilesInDirectory = new List<string>();
        DataTable table = new DataTable();
        private struct lockitFile
        {
            public string filename;
            public string mySheet;
            public lockitFile(string _filename,string _sourceSheet)
            {
                filename = _filename;
                mySheet = _sourceSheet; 
            }
        }
        List<lockitFile> lockitFiles = new List<lockitFile>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            directoryTextBox.ReadOnly = true;
            directoryTextBox.Text = selectedDirectory;
            sheetIDTextBox.Text = sheetID;
            rangeTextBox.Text = range;

            currentSheetLabel.AutoSize = true;

            table.Columns.Add("Name", typeof(string)).ReadOnly = true;
            table.Columns.Add("Sheet", typeof(string)).ReadOnly = true;
            table.Columns.Add("Matched", typeof(int)).ReadOnly = false;
            for (var i = 0; i < languages.Length; i++) table.Columns.Add(languages[i],typeof(string)).ReadOnly=false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView1.DataSource = table;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void setDirectory(string path)
        {
            selectedDirectory = path;
            directoryTextBox.Text = selectedDirectory;
            Properties.Settings.Default.directory = selectedDirectory;
            Properties.Settings.Default.Save();

        }

        private void setSheetID(string id)
        {
            sheetID = id;
            sheetIDTextBox.Text = id;
            Properties.Settings.Default.sheetid = sheetID;
            Properties.Settings.Default.Save();
        }

        private void browseDirectoryButton_Click(object sender, EventArgs e)
        {
            if(selectedDirectory.Length != 0) folderBrowserDialog1.SelectedPath = selectedDirectory;
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                setDirectory(folderBrowserDialog1.SelectedPath);
            }
        }
        private void findInDirectory()
        {
            
            int iter = 0;
            foreach(lockitFile file in lockitFiles)
            {
                iter++;
                if(iter%(lockitFiles.Count/100) == 0)progressBar1.PerformStep();
                currentSheetLabel.Text = "Проверяем " + file;
                table.Rows.Add(file.filename,file.mySheet,0, "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-");
                int matchedCounter = 0;
                DataRow dr = table.Rows[table.Rows.Count - 1];
                var size = checkInAllLanguages;
                for (var i = 0; i < size; i++)
                {
                    if (Directory.Exists(selectedDirectory + "\\" + languages[i]))
                    {
                        currentSheetLabel.Text = "Проверяем " + file.filename + "[" + languages[i] + "]";
                        Application.DoEvents();
                        foreach (string dir in Directory.GetFiles(selectedDirectory + "\\" + languages[i], "*.ogg", SearchOption.AllDirectories))
                        {
                            if (dir.Contains(file.filename + ".ogg"))
                            {
                                matchedCounter++;
                                dr[3 + i] = "+";
                            }
                        }
                    }
                    else Console.WriteLine(selectedDirectory + "\\" + languages[i] + " не найдена директория");
                }
                dr[2] = matchedCounter;
                Application.DoEvents();
            }
            if (checkProjInLockit)
            {
                if (Directory.Exists(selectedDirectory + "\\en"))
                {
                    Console.WriteLine("Popal");
                    foreach (string file in Directory.GetFiles(selectedDirectory + "\\en", "*.ogg", SearchOption.AllDirectories))
                    {
                        bool founded = false;
                        string fileName = Path.GetFileNameWithoutExtension(file);
                        lockitFile dismatchedFile = new lockitFile(fileName, "Не в локките");
                        foreach (lockitFile fileFromSheets in lockitFiles)
                        {
                            if (fileName == fileFromSheets.filename)
                            {
                                founded = true;
                                break;
                            }
                        }
                        if (!founded)
                        {
                            table.Rows.Add(dismatchedFile.filename, dismatchedFile.mySheet, 0, "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-");
                        }
                    }
                }
            }
            currentSheetLabel.Text = "Файлы проверены";
            Console.WriteLine("Ready");
        }
        private void connectToSheets()
        {
            table.Clear();
            allParsedFiles.Clear();
            allFoundedSheets.Clear();
            allFoundedFilesInDirectory.Clear();
            progressBar1.Value = 0;
            currentSheetLabel.Text = "Инициализация ключа";
            range = rangeTextBox.Text;
            using (var stream =
                new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/sheets.googleapis.com-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }
            currentSheetLabel.Text = "Инициализация сервиса";
            // Создать сервис Google Sheets API.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential
            });



            try
            {
                //получаем все листы в таблице
                currentSheetLabel.Text = "Получение всех листов";
                var sheetRequest = service.Spreadsheets.Get(sheetID);
                var sheetResponse = sheetRequest.Execute();
                var sheetsList = sheetResponse.Sheets;
                for (int i = 0; i < sheetsList.Count; i++)
                {
                    allFoundedSheets.Add(sheetsList[i].Properties.Title);
                }
                if (range == null)
                {
                    showError("Поле диапазон не может быть пустым\nФормат: \"A1:A5000\"");
                    return;
                }
                foreach (string sheet in allFoundedSheets)
                {
                    currentSheetLabel.Text = "Собираем инфу с "+sheet;
                    Console.WriteLine("Лист: "+sheet);
                    SpreadsheetsResource.ValuesResource.GetRequest request =
                            service.Spreadsheets.Values.Get(sheetID, sheet+"!"+range);

                    ValueRange response = request.Execute();
                    IList<IList<Object>> values = response.Values;
                    if (values != null && values.Count > 0)
                    {
                        foreach (var row in values)
                        {
                            foreach (string val in row)
                            {
                                if (Regex.Match(val, "[А-Яа-яЁё]").Success)
                                {
                                    Console.WriteLine("Откинуто: "+val +":конец откинутого");
                                }
                                else
                                {
                                    lockitFile file = new lockitFile(val, sheet);
                                    lockitFiles.Add(file);
                                }
                            }
                            Application.DoEvents();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }

                }
                currentSheetLabel.Text = "Проверяем по директории";
                findInDirectory();
            }
            catch (Exception ex)
            {
                if(ex.ToString().Contains("HttpStatusCode is NotFound"))showError("Ошибка подключения к таблице\nВозможно, идентификатор введен неправильно\n\n"+"Log:\n"+ex.ToString());
            }
        }
        private void showError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void connectToSheetButton_Click(object sender, EventArgs e)
        {
            if (sheetIDTextBox.Text.Length == 0)
            {
                showError("Поле идентификатора таблицы не заполнено");
            }
            else
            {
                setSheetID(sheetIDTextBox.Text);
                connectToSheets();
            }
        }

        private void allLanguageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (allLanguageCheckBox.Checked) checkInAllLanguages = languages.Length;
            else checkInAllLanguages = 1;
        }

        private void projInLockitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            checkProjInLockit = projInLockitCheckBox.Checked;
        }
    }
}
