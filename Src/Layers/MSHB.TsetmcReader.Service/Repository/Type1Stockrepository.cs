using AutoMapper;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Wordprocessing;
using MSHB.TsetmcReader.Dal;
using MSHB.TsetmcReader.DTO.DataModel;
using MSHB.TsetmcReader.Service.Contract;
using MSHB.TsetmcReader.Service.Helper;
using MSHB.TsetmcReader.Service.Impl;
using RestSharp.Extensions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.TsetmcReader.Service.Repository
{
    public class Type1StockRepository : IType1StockRepository
    {
        private Mapper mapper;
        private static Type1StockRepository instance;
        public static Type1StockRepository Instance
        {
            get { 
                instance= instance?? new Type1StockRepository();
                return instance;
            }
        }
        private Type1StockRepository()
        {
            mapper = MapperConfig.Instance;
            
        }

        public async Task ClearDataAsync()
        {
            using (var dbContext = new StockDbContext())
            {
                await dbContext.Type1Stock.BulkDeleteAsync<Type1Stock>(dbContext.Type1Stock);
            }
        }
        public List<Type1StockDto> GetType1Stocks()
        {
            using (var dbContext = new StockDbContext())
            {
                var Type1Stocks = mapper.Map<List<Type1StockDto>>(dbContext.Type1Stock.ToList());
                return Type1Stocks;
            }

        }

        public async Task SaveType1StockDataAsync(List<TargetPrice> targetPrices)
        {
            List<Type1Stock> ToUpdate = new List<Type1Stock>();
            List<Type1Stock> ToInsert = new List<Type1Stock>();
            using (var dbContext = new StockDbContext())
            {
                foreach (var targetPrice in targetPrices)
                {
                    if (targetPrice == null) continue;
                    if (long.TryParse(targetPrice.InsCode, out long insCode) && insCode > 0)
                    {
                        var t1stock = dbContext.Type1Stock.FirstOrDefault(x => x.InsCode == insCode);

                        if (t1stock != null)
                        {
                            t1stock = mapper.Map<Type1Stock>(targetPrice);
                            ToUpdate.Add(t1stock);
                        }
                        else
                        {
                            t1stock = mapper.Map<Type1Stock>(targetPrice);
                            ToInsert.Add(t1stock);
                        }
                    }
                    
                }
                await dbContext.BulkInsertAsync(ToInsert);
                await dbContext.BulkUpdateAsync(ToUpdate);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
