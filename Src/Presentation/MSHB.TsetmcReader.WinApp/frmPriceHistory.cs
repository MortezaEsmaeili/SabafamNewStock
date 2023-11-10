using MSHB.TsetmcReader.DTO.DataModel;
using MSHB.TsetmcReader.Service.Contract;
using MSHB.TsetmcReader.Service.Helper;
using MSHB.TsetmcReader.Service.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSHB.TsetmcReader.WinApp
{
    public partial class frmPriceHistory : Form
    {
        private IType1StockRepository _Type1StockRepo;
        private IInstrumentRepository _InstrumentRepo;
        private IInstrumentHistoryRepository _InstrumentHistoryRepo;

        public frmPriceHistory()
        {
            _Type1StockRepo = Type1StockRepository.Instance;
            _InstrumentRepo = InstrumentRepository.Instance;
            _InstrumentHistoryRepo = InstrumentHistoryRepository.Instance;

            InitializeComponent();
        }

        private void frmPriceHistory_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            LoadBelowTheSupportPrice();
        }

        private void LoadBelowTheSupportPrice()
        {
            return;
            //var type1Stocks = _Type1StockRepo.GetType1Stocks();
            //var InstrumentPriceDic = new Dictionary<string, TargetPrice>();
            //var targetPrices = type1Stocks.Convert<Type1StockDto, TargetPrice>();
            //foreach (var t in targetPrices)
            //{
            //    if (InstrumentPriceDic.ContainsKey(t.Symbol) == false)
            //        InstrumentPriceDic.Add(t.Symbol, t);
            //    var priceHistory = _InstrumentHistoryRepo.
            //        GetInsPrice(t.Symbol, t.InsCode, t.SupportPrice);
            //    if (priceHistory != null)
            //        Add2List(priceHistory, t.SupportPrice);
            //}
        }

        private void Add2List(Instrument10DaysHistoryDto priceHistory, decimal SupportPrice)
        {
            int rowCount = dg_InsHistory.RowCount;
            dg_InsHistory.Rows.Add();
            dg_InsHistory["Symbol", rowCount].Value = priceHistory.Symbol;
            int counter = 0;
            foreach(var price in priceHistory.PriceDate)
            {
                decimal p = priceHistory.PriceDate[counter].Item1 ?? 0;
                decimal percent = Math.Round(((p- SupportPrice)/ p) *100, 1);
                dg_InsHistory[$"day{counter + 1}", rowCount].Value = percent.ToString();
                counter++;
                if (counter > 6)
                    return;
            }
        }
    }
}
