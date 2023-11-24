using MSHB.TsetmcReader.DTO.DataModel;
using MSHB.TsetmcReader.Service.Helper;
using MSHB.TsetmcReader.WinApp.Helper;
using RestSharp;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MSHB.TsetmcReader.WinApp
{
    public partial class frmType1Excel : Form
    {
        public Dictionary<string, List<Price_PE>> StockData = new Dictionary<string, List<Price_PE>>();
        public Dictionary<string, MA_Data> StockMA_Data;
        public bool loadExcel { get; set; }
        private ConcurrentDictionary<string, decimal> _instrumentIds = new ConcurrentDictionary<string, decimal>();

        public frmType1Excel(bool _loadExcel)
        {
            loadExcel = _loadExcel;

            InitializeComponent();
        }

        private void frmType1Excel_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            GetFilesPath();
            timer1 = new Timer();
            timer1.Interval = 4000;
            timer1.Tick += GetDataFromTSETMC;
            timer1.Start();
        }

        private async void GetDataFromTSETMC(object sender, EventArgs e)
        {
            timer1.Stop();
            try
            {
                var options = new RestClientOptions("https://old.tsetmc.com/tsev2/data/MarketWatchInit.aspx?h=0&r=0");
                var request = new RestRequest();

                var client = new RestClient(options);
                var response = await client.GetAsync(request);
                string responseMessage = response.Content;
                _instrumentIds.Clear();
                try
                {
                    var logs = responseMessage.Trim().Split(';').Select(x => x.Trim()).ToArray();
                    if (logs != null && logs.Length > 0)
                    {

                        Parallel.ForEach(logs, item =>
                        //       foreach (var item in logs)
                        {
                            var data = item.Replace("'", "").Trim().Split(',').Select(x => x.Trim()).ToArray();
                            int dataLength = data.Length;
                            if (dataLength > 20)
                            {
                                try
                                {
                                    if (!decimal.TryParse(data[7], out decimal quantity))
                                    { quantity = 0; }
                                    if (!_instrumentIds.TryAdd(data[0], quantity))
                                        _instrumentIds.TryAdd(data[0], quantity);
                                }
                                catch { }

                            }
                        });
                    }
                }
                catch { }
                FillDataGrid();
            }
            catch { }
            timer1.Start();
        }

        private void GetFilesPath()
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
            string path = ConfigReaderHelper.GetExcelFolderPath();
            folderBrowserDialog1.SelectedPath = ConfigReaderHelper.GetExcelFolderPath();

            var result = folderBrowserDialog1.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var waitForm = new frmPleaseWait();
            waitForm.Show(this);

            string selectedFolder = folderBrowserDialog1.SelectedPath;
            foreach (var file in Directory.GetFiles(selectedFolder))
                loadFromExcel(file);
            ConfigReaderHelper.SetExcelFolderPath(selectedFolder);

            CalculateMA();
            FillDataGrid();

            waitForm.Close();
        }
        void CalculateMA()
        {
            StockMA_Data = new Dictionary<string, MA_Data>();

            foreach (var insData in StockData)
            {
                try
                {
                    var ma = new MA_Data()
                    {
                        PE = insData.Value[0].PE,
                        PE100 = (insData.Value.Where(x => x.PE > 0).Take(100).Sum(x => x.PE)) / 100,
                        Price100 = (insData.Value.Where(x => x.Price > 0).Take(100).Sum(x => x.Price)) / 100,
                        Earning100 = (insData.Value.Where(x => x.Earning > 0).Take(100).Sum(x => x.Earning)) / 100,
                        PE500 = (insData.Value.Where(x => x.PE > 0).Take(500).Sum(x => x.PE)) / 500,
                        Price500 = (insData.Value.Where(x => x.Price > 0).Take(500).Sum(x => x.Price)) / 500,
                        Earning500 = (insData.Value.Where(x => x.Earning > 0).Take(500).Sum(x => x.Earning)) / 500
                    };
                    StockMA_Data.Add(insData.Key, ma);
                }
                catch { }
            }

        }

        private void loadFromExcel(string filePath)
        {
            var dataTable = ExelReader.ReadExcelFileDOM(filePath);
            if (dataTable == null)
            {
                //         MessageBox.Show("Please close the Excel file or Excel file is empty!");
                return;
            }
            FileInfo info = new FileInfo(filePath);
            var insCode = info.Name.Split('.')[0];
            if (StockData.ContainsKey(insCode) == true)
                StockData.Remove(insCode);
            StockData.Add(insCode, new List<Price_PE>());

            int counter = 0;

            foreach (var row in dataTable.ToArray())
            {
                if (counter < 8 || row == null || row[1] == null)
                {
                    counter++;
                    continue;
                }
                try
                {
                    if (decimal.TryParse(row[6], out decimal price) &&
                        decimal.TryParse(row[15], out decimal pe))
                    {
                        var price_pe = new Price_PE()
                        {
                            PE = pe,
                            Price = price,
                            Earning = pe > 0 ? (price / pe) : -1
                        };
                        StockData[insCode].Add(price_pe);
                    }
                } catch { }
                if (StockData[insCode].Count > 600)
                    break;
            }
            decimal lastValidEaring = 0;
            for (int k = StockData[insCode].Count - 1; k >= 0; k--)
            {
                if (StockData[insCode][k].Earning == -1)
                    StockData[insCode][k].Earning = lastValidEaring;
                else
                    lastValidEaring = StockData[insCode][k].Earning;
            }
        }

        private void FillDataGrid()
        {
            if (Freez_CHB.Checked)
                return;
            try
            {
                dg_InsData.AutoGenerateColumns = false;
                int dgrow = 0;
                dg_InsData.Rows.Clear();
                StockMA_Data.ToList().ForEach(x =>
                {
                    dg_InsData.Rows.Add();
                    string insCode = x.Key.Split('_')[1];
                    string insName = x.Key.Split('_')[0];
                    dg_InsData["InsCode", dgrow].Value = insCode;
                    dg_InsData["InsName", dgrow].Value = insName;
                    dg_InsData["PE", dgrow].Value = Math.Round(x.Value.PE, 2);
                    dg_InsData["Price100", dgrow].Value = Math.Round(x.Value.Price100, 2);
                    dg_InsData["PE100", dgrow].Value = Math.Round(x.Value.PE100, 2);
                    dg_InsData["Earning100", dgrow].Value = Math.Round(x.Value.Earning100, 2);
                    dg_InsData["Price500", dgrow].Value = Math.Round(x.Value.Price500, 2);
                    dg_InsData["PE500", dgrow].Value = Math.Round(x.Value.PE500, 2);
                    dg_InsData["Earning500", dgrow].Value = Math.Round(x.Value.Earning500, 2);
                    if (_instrumentIds.ContainsKey(insCode))
                    {
                        decimal price = 0;
                        if (_instrumentIds.TryGetValue(insCode, out price))
                        {
                            if (price > 1)
                            {
                                dg_InsData["Price", dgrow].Value = price;
                                decimal earning = x.Value.PE > 0 ? price / x.Value.PE : -1;
                                dg_InsData["Earning", dgrow].Value = Math.Round(earning, 2);
                                dg_InsData["Price_Price100", dgrow].Value =
                                    Math.Round((((price - x.Value.Price100) / price) * 100), 2);
                                dg_InsData["Price_Price500", dgrow].Value =
                                    Math.Round(((price - x.Value.Price500) / price) * 100,2);
                                dg_InsData["PE_PE100", dgrow].Value =
                                    Math.Round(((x.Value.PE - x.Value.PE100) / x.Value.PE) * 100, 2);
                                dg_InsData["PE_PE500", dgrow].Value =
                                    Math.Round(((x.Value.PE - x.Value.PE500) / x.Value.PE) * 100, 2);
                            }
                        }
                        dgrow++;
                    }
                });
                dg_InsData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void LocateExcelFile_BT_Click(object sender, EventArgs e)
        {
            GetFilesPath();
        }

        private void Freez_CHB_CheckedChanged(object sender, EventArgs e)
        {
            if (Freez_CHB.Checked)
            {
                timer1.Stop();
            }
            else
            {
                timer1.Start();
            }
        }
    }
}
