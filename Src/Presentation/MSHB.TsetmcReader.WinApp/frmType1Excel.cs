using MSHB.TsetmcReader.DTO.DataModel;
using MSHB.TsetmcReader.Service;
using MSHB.TsetmcReader.Service.Contract;
using MSHB.TsetmcReader.Service.Helper;
using MSHB.TsetmcReader.Service.Impl;
using MSHB.TsetmcReader.Service.Repository;
using MSHB.TsetmcReader.WinApp.Helper;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;


namespace MSHB.TsetmcReader.WinApp
{
    public partial class frmType1Excel : Form
    {
        public Dictionary<string, List<Price_PE>> StockData = new Dictionary<string, List<Price_PE>>();
        public Dictionary<string, MA_Data> StockMA_Data;
        public bool loadExcel { get; set; }
        private IType1StockRepository _Type1StockRepo;
        private IInstrumentRepository _InstrumentRepo;
        private RedisRepository _RedisRepo;
        //       private TsetmcDataAnalyzer _tsetDataAnalyzer;


        public frmType1Excel(bool _loadExcel)
        {
            loadExcel = _loadExcel;
            _Type1StockRepo = Type1StockRepository.Instance;
            _InstrumentRepo = InstrumentRepository.Instance;
            _RedisRepo = RedisRepository.Instance;
            _RedisRepo.OnResultReady += RedisRepository_DataReady;
            //          _tsetDataAnalyzer = TsetmcDataAnalyzer.Instance;
            //          _tsetDataAnalyzer.OnResultReady += _tsetDataAnalyzer_OnResultReady;

            InitializeComponent();
        }

        private void RedisRepository_DataReady(Dictionary<long, decimal> results)
        {
            return;
            //if (InstrumentPriceDic == null || InstrumentPriceDic.Count == 0) return;
            //bool anyChange = false;
            //// InstrumentPriceDic.Values.AsParallel().ForAll(x =>
            //foreach (var x in InstrumentPriceDic.Values)
            //{
            //    if (long.TryParse(x.InsCode, out var insCode))
            //    {
            //        if (results.ContainsKey(insCode))
            //        {
            //            if (results[insCode] > 0)
            //            {
            //                x.CurrentPrice = results[insCode];
            //                if (x.CurrentPrice < 1)
            //                    continue;
            //                anyChange = true;
            //                x.Target1PricePercentage = Math.Round(((x.TargetPrice1 / x.CurrentPrice) - 1) * 100, 1);
            //                x.Target2PricePercentage = Math.Round(((x.TargetPrice2 / x.CurrentPrice) - 1) * 100, 1);
            //                x.Target3PricePercentage = Math.Round(((x.TargetPrice3 / x.CurrentPrice) - 1) * 100, 1);
            //                x.PriceSupportPercentage = Math.Round(((x.CurrentPrice / x.SupportPrice) - 1) * 100, 1);
            //            }
            //        }
            //    }
            //}
            //if (anyChange)
            //{
            //    this.Invoke((MethodInvoker)(() => FillDataGrid()));
            //}
        }

        private void _tsetDataAnalyzer_OnResultReady(Dictionary<decimal, TsetmcDto> results)
        {
            return;
            //if (InstrumentPriceDic == null || InstrumentPriceDic.Count == 0) return;
            //bool anyChange = false;
            //// InstrumentPriceDic.Values.AsParallel().ForAll(x =>
            //foreach (var x in InstrumentPriceDic.Values)
            //{
            //    if (decimal.TryParse(x.InsCode, out var insCode))
            //    {
            //        if (results.ContainsKey(insCode))
            //        {
            //            if (results[insCode].Ltp != null && decimal.TryParse(results[insCode].Ltp, out decimal Ltp))
            //            {
            //                x.CurrentPrice = Ltp;
            //                if (x.CurrentPrice < 1)
            //                    continue;
            //                anyChange = true;
            //                x.Target1PricePercentage = Math.Round(((x.TargetPrice1 / x.CurrentPrice) - 1) * 100, 1);
            //                x.Target2PricePercentage = Math.Round(((x.TargetPrice2 / x.CurrentPrice) - 1) * 100, 1);
            //                x.Target3PricePercentage = Math.Round(((x.TargetPrice3 / x.CurrentPrice) - 1) * 100, 1);
            //                x.PriceSupportPercentage = Math.Round(((x.CurrentPrice / x.SupportPrice) - 1) * 100, 1);
            //            }
            //        }
            //    }
            //}
            ////);
            //if (anyChange)
            //{
            //    this.Invoke((MethodInvoker)(() => FillDataGrid()));
            //    /*   var act = new Action(FillDataGrid);
            //       if (this.InvokeRequired)
            //       {
            //           act.Invoke();
            //       }
            //       else
            //           act();*/
            //}

        }

        private void frmType1Excel_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (loadExcel)
            {
                GetFilesPath();
            }
            else
            {
                LoadFromDB();
            }
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
        private void LoadFromDB()
        {
            return;
            //var type1Stocks = _Type1StockRepo.GetType1Stocks();
            //InstrumentPriceDic = new Dictionary<string, TargetPrice>();
            //// int counter = 0;
            //var targetPrices = type1Stocks.Convert<Type1StockDto, TargetPrice>();
            //foreach (var t in targetPrices)
            //{
            //    if (InstrumentPriceDic.ContainsKey(t.Symbol) == false)
            //        InstrumentPriceDic.Add(t.Symbol, t);
            //}

            //FillDataGrid();
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

            //FillDataGrid();
            // await SaveExcelDataInDB();
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
                    dg_InsData["InsCode", dgrow].Value = x.Key;
                    dg_InsData["Price100", dgrow].Value = Math.Round(x.Value.Price100, 2);
                    dg_InsData["PE100", dgrow].Value = Math.Round(x.Value.PE100, 2);
                    dg_InsData["Earning100", dgrow].Value = Math.Round(x.Value.Earning100, 2);
                    dg_InsData["Price500", dgrow].Value = Math.Round(x.Value.Price500, 2);
                    dg_InsData["PE500", dgrow].Value = Math.Round(x.Value.PE500, 2);
                    dg_InsData["Earning500", dgrow].Value = Math.Round(x.Value.Earning500, 2);
                    dgrow++;
                });
            }
            catch (Exception ex)
            {

            }
        }

        private decimal GetInsCode(string symbol)
        {
            var inscode = _InstrumentRepo.GetInsCodeBySymbol(symbol);
            if (inscode < 1)
            {
                frmInsCode frmInstrumentID = new frmInsCode(symbol);
                if (frmInstrumentID.ShowDialog() == DialogResult.OK)
                {
                    SaveInstrumentIdinDB(frmInstrumentID.Sembol, frmInstrumentID.instrumentID);
                    inscode = frmInstrumentID.instrumentID;
                }
            }
            return inscode;
        }

        private void SaveInstrumentIdinDB(string sembol, decimal instrumentID)
        {
            _InstrumentRepo.SaveInstrumentInDB(sembol, instrumentID);
        }

        //private async Task SaveExcelDataInDB()
        //{
        //    await _Type1StockRepo.SaveType1StockDataAsync(InstrumentPriceDic.Values.ToList());
        //}

        private void Freez_CHB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LocateExcelFile_BT_Click(object sender, EventArgs e)
        {
            GetFilesPath();
        }
    }
}
