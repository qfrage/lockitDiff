﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
            UserCredential credential;
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


            // Определить параметры запроса.
            String spreadsheetId = "13uungy3pXzqo4eHe8-ZfzM7GFZ3Dida5ASXWJUysRW8";
            String range = $"Локкит!A2:A5000";
            //получаем все листы в таблице
            var sheetRequest = service.Spreadsheets.Get(spreadsheetId);
            var sheetResponse = sheetRequest.Execute();
            var sheetsList = sheetResponse.Sheets;
            for (int i = 0; i < sheetsList.Count; i++)
            {
                //Console.WriteLine(sheetsList[i].Properties.Title);
            }
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);
            
            

            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            List<string> arr = new List<string>();

            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    // Выведите столбцы A и E, соответствующие индексам 0 и 4.
                    foreach (var val in row)
                    {
                        arr.Add(val.ToString());
                    }
                }
                Console.WriteLine(arr.Count);
            }
            else
            {
                Console.WriteLine("No data found.");
            }
        }
    }
}
