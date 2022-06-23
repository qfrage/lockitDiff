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
        string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        // Определить параметры запроса.
        string range = Properties.Settings.Default.range;
        UserCredential credential;
        List<string> allFoundedSheets = new List<string>();
        List<string> allParsedFiles = new List<string>();
        List<string> allFoundedFilesInDirectory = new List<string>();
        DataTable table = new DataTable();
        string[] languages = {"ar","de","en","es","fa","fr","hi","id","it","nl","pl","pt","ro","ru","th","tr","uk","vi","zh" };

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

            table.Columns.Add("Name", typeof(string)).ReadOnly = true;
            table.Columns.Add("Sheet", typeof(string)).ReadOnly = true;

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
            foreach(string file in allParsedFiles)
            {
                int foundedLanguages = 0;
                foreach (string dir in Directory.GetFiles(selectedDirectory, "*.ogg", SearchOption.AllDirectories))
                {
                    if (dir.Contains(file))
                    {
                        foundedLanguages++;
                    }
                }
                table.Rows.Add(file,foundedLanguages.ToString());
            }
            Console.WriteLine("Ready");
        }
        private void connectToSheets()
        {
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

            // Создать сервис Google Sheets API.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential
            });



            try
            {
                //получаем все листы в таблице
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
                                    allParsedFiles.Add(val);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }

                }
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
    }
}
