using MSHB.TsetmcReader.DTO.DataModel;
using MSHB.TsetmcReader.Service;
using MSHB.TsetmcReader.Service.Contract;
using MSHB.TsetmcReader.Service.Helper;
using MSHB.TsetmcReader.Service.Impl;
using MSHB.TsetmcReader.Service.Repository;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public Dictionary<string, TargetPrice> InstrumentPriceDic;
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
            if (InstrumentPriceDic == null || InstrumentPriceDic.Count == 0) return;
            bool anyChange = false;
            // InstrumentPriceDic.Values.AsParallel().ForAll(x =>
            foreach (var x in InstrumentPriceDic.Values)
            {
                if (long.TryParse(x.InsCode, out var insCode))
                {
                    if (results.ContainsKey(insCode))
                    {
                        if (results[insCode] > 0)
                        {
                            x.CurrentPrice = results[insCode];
                            if (x.CurrentPrice < 1)
                                continue;
                            anyChange = true;
                            x.Target1PricePercentage = Math.Round(((x.TargetPrice1 / x.CurrentPrice) - 1) * 100, 1);
                            x.Target2PricePercentage = Math.Round(((x.TargetPrice2 / x.CurrentPrice) - 1) * 100, 1);
                            x.Target3PricePercentage = Math.Round(((x.TargetPrice3 / x.CurrentPrice) - 1) * 100, 1);
                            x.PriceSupportPercentage = Math.Round(((x.CurrentPrice / x.SupportPrice) - 1) * 100, 1);
                        }
                    }
                }
            }
            if (anyChange)
            {
                this.Invoke((MethodInvoker)(() => FillDataGrid()));
            }
        }

        private void _tsetDataAnalyzer_OnResultReady(Dictionary<decimal, TsetmcDto> results)
        {
            if (InstrumentPriceDic == null || InstrumentPriceDic.Count == 0) return;
            bool anyChange = false;
            // InstrumentPriceDic.Values.AsParallel().ForAll(x =>
            foreach (var x in InstrumentPriceDic.Values)
            {
                if (decimal.TryParse(x.InsCode, out var insCode))
                {
                    if (results.ContainsKey(insCode))
                    {
                        if (results[insCode].Ltp != null && decimal.TryParse(results[insCode].Ltp, out decimal Ltp))
                        {
                            x.CurrentPrice = Ltp;
                            if (x.CurrentPrice < 1)
                                continue;
                            anyChange = true;
                            x.Target1PricePercentage = Math.Round(((x.TargetPrice1 / x.CurrentPrice) - 1) * 100, 1);
                            x.Target2PricePercentage = Math.Round(((x.TargetPrice2 / x.CurrentPrice) - 1) * 100, 1);
                            x.Target3PricePercentage = Math.Round(((x.TargetPrice3 / x.CurrentPrice) - 1) * 100, 1);
                            x.PriceSupportPercentage = Math.Round(((x.CurrentPrice / x.SupportPrice) - 1) * 100, 1);
                        }
                    }
                }
            }
            //);
            if (anyChange)
            {
                this.Invoke((MethodInvoker)(() => FillDataGrid()));
                /*   var act = new Action(FillDataGrid);
                   if (this.InvokeRequired)
                   {
                       act.Invoke();
                   }
                   else
                       act();*/
            }

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
                loadFromExcel();
            }
            else
            {
                LoadFromDB();
            }
        }

        private void LoadFromDB()
        {
            var type1Stocks = _Type1StockRepo.GetType1Stocks();
            InstrumentPriceDic = new Dictionary<string, TargetPrice>();
            // int counter = 0;
            var targetPrices = type1Stocks.Convert<Type1StockDto, TargetPrice>();
            foreach (var t in targetPrices)
            {
                if (InstrumentPriceDic.ContainsKey(t.Symbol) == false)
                    InstrumentPriceDic.Add(t.Symbol, t);
            }

            FillDataGrid();
        }

        private async void loadFromExcel()
        {
            var result = openExcelFileDialog.ShowDialog();
            if (result != DialogResult.OK)
                return;

            var dataTable = ExelReader.ReadExcelFileDOM(openExcelFileDialog.FileName);
            if (dataTable == null)
            {
                MessageBox.Show("Please close the Excel file or Excel file is empty!");
                this.Close();
                return;
            }

            InstrumentPriceDic = new Dictionary<string, TargetPrice>();
            int counter = 0;
            foreach (var row in dataTable.ToArray())
            {
                if (counter == 0 || row == null || row[0] == null)
                {
                    counter++;
                    continue;
                }
                var inscode = GetInsCode(row[0]);

                var targetPrice = new TargetPrice
                {
                    InsCode = inscode == 0 ? "Not found" : inscode.ToString(),
                    Symbol = row[0],
                    Target1PricePercentage = 0,
                    Target2PricePercentage = 0,
                    Target3PricePercentage = 0,
                    CurrentPrice = 0,
                    TargetPrice1 = Math.Round(decimal.Parse(row[1]), 1),
                    TargetPrice2 = Math.Round(decimal.Parse(row[2]), 1),
                    TargetPrice3 = Math.Round(decimal.Parse(row[3]), 1),
                    SupportPrice = Math.Round(decimal.Parse(row[4]), 1)
                };
                InstrumentPriceDic.Add(targetPrice.Symbol, targetPrice);
            }
            FillDataGrid();
            await SaveExcelDataInDB();
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
                InstrumentPriceDic.Values.ToList().ForEach(item =>
                {
                    dg_InsData.Rows.Add();
                    dg_InsData["InsCode", dgrow].Value = item.InsCode?.ToString();
                    dg_InsData["Name", dgrow].Value = item.Symbol;
                    dg_InsData["Target1PricePercentage", dgrow].Value = item.Target1PricePercentage;
                    dg_InsData["Target2PricePercentage", dgrow].Value = item.Target2PricePercentage;
                    dg_InsData["Target3PricePercentage", dgrow].Value = item.Target3PricePercentage;
                    dg_InsData["PriceSupportPercentage", dgrow].Value = item.PriceSupportPercentage;
                    dg_InsData["CurrentPrice", dgrow].Value = item.CurrentPrice;
                    dg_InsData["TargetPrice1", dgrow].Value = item.TargetPrice1;
                    dg_InsData["TargetPrice2", dgrow].Value = item.TargetPrice2;
                    dg_InsData["TargetPrice3", dgrow].Value = item.TargetPrice3;
                    dg_InsData["SupportPrice", dgrow].Value = item.SupportPrice;

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

        private async Task SaveExcelDataInDB()
        {
            await _Type1StockRepo.SaveType1StockDataAsync(InstrumentPriceDic.Values.ToList());
        }

        private void Freez_CHB_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
