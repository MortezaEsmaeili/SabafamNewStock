using MSHB.TsetmcReader.Dal;
using MSHB.TsetmcReader.DTO.DataModel;
using MSHB.TsetmcReader.Service.Contract;
using MSHB.TsetmcReader.Service.Helper;
using MSHB.TsetmcReader.Service.Repository;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;

namespace MSHB.TsetmcReader.Service.Impl
{
    public class DBWorkerService
    {
        private bool _bInit = false;
        private System.Timers.Timer timer1;
        private Dictionary<long, Tuple<string,decimal?>> InstrumentPriceDic;
        private TsetmcDataAnalyzer _tsetDataAnalyzer;
        private IType1StockRepository _Type1StockRepo;
        private IInstrumentHistoryRepository _InstrumentHistoryRepository;
        private static DBWorkerService instance;
        public static DBWorkerService Instance
        {
            get
            {
                instance = instance ?? new DBWorkerService();
                return instance;
            }
        }
        public DBWorkerService()
        {
            _InstrumentHistoryRepository = InstrumentHistoryRepository.Instance;
            _Type1StockRepo = Type1StockRepository.Instance;
            _tsetDataAnalyzer = TsetmcDataAnalyzer.Instance;
            _tsetDataAnalyzer.OnResultReady += _tsetDataAnalyzer_OnResultReady;

            timer1 = new System.Timers.Timer(1000*60*60);
            timer1.Elapsed += OnTimerEvent;
            timer1.AutoReset = true;
            timer1.Start();

            LoadInstrumentFromDB();
            _bInit = true;
        }

        private void OnTimerEvent(object sender, ElapsedEventArgs e)
        {
            if (DateTime.Now.Hour > 16)
                return;
            if (InstrumentPriceDic.Count < 1)
                return;
            
            _InstrumentHistoryRepository.SaveAndUpdateLastPrise(InstrumentPriceDic);
        }

        private void LoadInstrumentFromDB()
        {
            var type1Stocks = _Type1StockRepo.GetType1Stocks();
            InstrumentPriceDic = new Dictionary<long, Tuple<string,decimal?>>();
            foreach (var type in type1Stocks)
            {
                if(type.InsCode != null)
                {
                    if (!InstrumentPriceDic.ContainsKey((long)type.InsCode))
                    {
                        InstrumentPriceDic.Add((long)type.InsCode, Tuple.Create(type.Symbol, (decimal?)0));
                    }
                }
            }
        }

        private void _tsetDataAnalyzer_OnResultReady(System.Collections.Generic.Dictionary<decimal, DTO.DataModel.TsetmcDto> results)
        {
            if(!_bInit) return;
            if (InstrumentPriceDic == null || InstrumentPriceDic.Count == 0) return;
            List<long> keys = new List<long>(InstrumentPriceDic.Keys);
            foreach (var instrument in keys)
            {
                decimal insCode = Convert.ToDecimal(instrument);
                if (results.ContainsKey(insCode))
                {
                    if (results[insCode] == null) { continue; }
                    if (results[insCode].Ltp == null) { continue; }
                    if (results[insCode].Ltp != null && decimal.TryParse(results[insCode].Ltp, out decimal Ltp))
                    {
                        InstrumentPriceDic[instrument] = Tuple.Create(InstrumentPriceDic[instrument].Item1,(decimal?) Ltp);
                    }
                }
            }
        }
    }
}
