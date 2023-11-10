using AutoMapper;
using MSHB.TsetmcReader.Dal;
using MSHB.TsetmcReader.DTO.DataModel;
using MSHB.TsetmcReader.Service.Contract;
using MSHB.TsetmcReader.Service.Helper;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.TsetmcReader.Service.Repository
{
    public class InstrumentRepository: IInstrumentRepository
    {
        private ConcurrentDictionary<string, InstrumentDto>Instruments = new ConcurrentDictionary<string, InstrumentDto>();
        private Mapper mapper;
        private static InstrumentRepository instance;
        public static InstrumentRepository Instance
        {
            get {
                instance= instance ?? new InstrumentRepository(); 
                return instance;
            }

        }
        private InstrumentRepository() {
            mapper = MapperConfig.Instance;
            FillInstrumentCache();
        }

        private void FillInstrumentCache()
        {
            using(var contextDb = new StockDbContext() )
            {
                contextDb.Instruments.AsParallel().ForAll(x => 
                Instruments.TryAdd(x.Name.ToCleanString(), mapper.Map<InstrumentDto>(x)));                
            }
        }

        public decimal GetInsCodeBySymbol(string symbol)
        {
            symbol = symbol.ToCleanString();
            if (Instruments.ContainsKey(symbol))
                return (decimal)Instruments[symbol].InsCode;            
            else return 0;
        }

        public void SaveInstrumentInDB(string symbol, decimal instrumentID)
        {
            if(instrumentID<=0) return;
            symbol= symbol.ToCleanString();
            using(var dbContext = new StockDbContext() )
            {
                var ins = dbContext.Instruments.FirstOrDefault(x => x.Name == symbol);
                string name = symbol.ToCleanString();
                if (ins==null)
                {                    
                    var insertedIns = dbContext.Instruments.Add(new Instrument
                    {
                        Name = name,
                        InsCode = (long)instrumentID
                    });
                    dbContext.SaveChanges();
                    Instruments.TryAdd(name, new InstrumentDto
                    {
                        Name = name,
                        InsCode = instrumentID,
                        ID = insertedIns.ID
                    });
                }
                else
                {
                    if(Instruments.ContainsKey(name))
                        Instruments[name].InsCode = instrumentID; 
                    else
                        Instruments.TryAdd(name, new InstrumentDto
                        {
                            Name = name,
                            InsCode = instrumentID,
                            ID = ins.ID
                        });
                    ins.InsCode = (long)instrumentID;
                    dbContext.SaveChanges();                    
                }
            }
        }

        public async Task SaveInstrumentsInDBAsync(IEnumerable<Tuple<string, string>> symbolInsCodes)
        {
            List<Instrument>ToInsert = new List<Instrument>();
            //symbolInsCodes.AsParallel().ForAll(x =>
            foreach(var x in symbolInsCodes)
            {
                if(long.TryParse(x.Item2, out var insCode)&& insCode>0)
                {
                    var symbol = x.Item1.ToCleanString();
                    if (!Instruments.ContainsKey(symbol) )
                    {
                        ToInsert.Add(new Instrument { Name = symbol, InsCode = insCode });
                        Instruments.TryAdd(symbol, new InstrumentDto { Name = symbol, InsCode = insCode });
                    }
                }
            }
            //);
            using (var dbContext = new StockDbContext())
            {
                await dbContext.BulkInsertAsync(ToInsert);
                dbContext.SaveChanges();
            }
                
            
        }
    }

}
