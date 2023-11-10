using AutoMapper;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using MSHB.TsetmcReader.Dal;
using MSHB.TsetmcReader.DTO.DataModel;
using MSHB.TsetmcReader.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.TsetmcReader.Service.Repository
{
    public class InstrumentHistoryRepository : IInstrumentHistoryRepository
    {
        private Mapper mapper;
        private static InstrumentHistoryRepository instance;
        public static InstrumentHistoryRepository Instance
        {
            get
            {
                instance = instance ?? (instance = new InstrumentHistoryRepository());
                return instance;
            }
        }
        private InstrumentHistoryRepository()
        {
            mapper = MapperConfig.Instance;

            //--------------Test-----------------
           /* Dictionary<long, Tuple<string, decimal?>> instrumentPriceDic =
                new Dictionary<long, Tuple<string, decimal?>>();

            instrumentPriceDic.Add(29974853866926823, Tuple.Create("فروی", (decimal?)16666));
            SaveAndUpdateLastPrise(instrumentPriceDic);*/
        }
        public List<InstrumentHistoryDto> GetInstrumentHistories(int dayCount)
        {
            using (var dbContext = new StockDbContext())
            {
                var instrumentHistory = mapper.Map<List<InstrumentHistoryDto>>(
                    dbContext.Type1Stock.Where(x => x.tmst > DateTime.Now).
                    ToList());
                return instrumentHistory;
            }
        }

        public Instrument10DaysHistoryDto GetInsPrice(string symbol, string insCode, decimal supportPrice)
        {
            int dayOfProcess = 10;
            long instrument = long.Parse(insCode);
            using (var dbContext = new StockDbContext())
            {
                DateTime dateTime = DateTime.Now.AddDays(-dayOfProcess);
                var history = dbContext.InstrumentHistory.Where(x => (x.InsCode == instrument && x.Tmst > dateTime)).OrderByDescending(t => t.Tmst).ToList();
                int count = history.Count(h => h.LastPrice < supportPrice);
                if (count < dayOfProcess / 3)
                    return null;
                Instrument10DaysHistoryDto instrumentHistory = new Instrument10DaysHistoryDto();
                instrumentHistory.Symbol = symbol;
                instrumentHistory.InsCode = instrument;
                instrumentHistory.PriceDate = new List<Tuple<decimal?, DateTime>>();
                foreach (var item in history)
                    instrumentHistory.PriceDate.Add(Tuple.Create(item.LastPrice, item.Tmst));

                return instrumentHistory;
            }
        }


        public void SaveAndUpdateLastPrise(Dictionary<long, Tuple<string, decimal?>> instrumentPriceDic)
        {
            DateTime dateTime = DateTime.Now;
            DateTime myTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,
                                            1, 1, 1);
            List<InstrumentHistory> ToUpdate = new List<InstrumentHistory>();
            List<InstrumentHistory> ToInsert = new List<InstrumentHistory>();

            using (var dbContext = new StockDbContext())
            {
                foreach (var item in instrumentPriceDic)
                {
                    //if(item)
                    var InsHistory = dbContext.InstrumentHistory.
                        FirstOrDefault(r => r.InsCode == item.Key && r.Tmst > myTime);
                    if (InsHistory == null)
                    {
                        InstrumentHistory instrumentHistory = new InstrumentHistory();
                        instrumentHistory.InsCode = item.Key;
                        instrumentHistory.Symbol = item.Value.Item1;
                        instrumentHistory.LastPrice = item.Value.Item2;
                        instrumentHistory.Tmst = DateTime.Now;
                        ToInsert.Add(instrumentHistory);
                    }
                    else
                    {
                        InsHistory.Tmst = DateTime.Now;
                        InsHistory.LastPrice = item.Value.Item2;
                        ToUpdate.Add(InsHistory);
                    }
                }
                dbContext.BulkInsert(ToInsert);
                dbContext.BulkUpdate(ToUpdate);
                dbContext.SaveChanges();
            }
        }
    }
}
