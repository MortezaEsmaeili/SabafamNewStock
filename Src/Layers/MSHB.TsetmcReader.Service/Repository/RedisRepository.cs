using AutoMapper;
using MSHB.TsetmcReader.DTO.DataModel;
using MSHB.TsetmcReader.Service.Contract;
using MSHB.TsetmcReader.Service.Helper;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSHB.TsetmcReader.Service.Repository
{
    public delegate void LastPriceAction(Dictionary<long, decimal> results);
    public class RedisRepository
    {
        
        private Dictionary<long, decimal> _InstrumentDictionary;
        private IType1StockRepository _Type1StockRepo;
        private static RedisRepository instance;
        public static RedisRepository Instance
        {
            get
            {
                instance = instance ?? new RedisRepository();
                return instance;
            }

        }
        private RedisRepository()
        {
            _InstrumentDictionary = new Dictionary<long, decimal>();
            _Type1StockRepo = Type1StockRepository.Instance;
            Connect();
            
            Task.Run(() =>
            {
                GetDataFromRedis();
            });
        }

        public event LastPriceAction OnResultReady;
        private void ResultIsReady(Dictionary<long, decimal> results)
        {
            if (OnResultReady != null) { OnResultReady(results); }
        }

        private void GetDataFromRedis()
        {
            //esi
            return;
            while (true)
            {
                GetInstrumentList();
                GetLatestValueFromRedis();

                Thread.Sleep(2000);
            }
        }

        private void GetLatestValueFromRedis()
        {
            var AnalyzedData = new Dictionary<long, decimal>();
            var cache = RedisConnectorHelper.Connection.GetDatabase();
            EndPoint endPoint = RedisConnectorHelper.Connection.GetEndPoints().First();
            RedisKey[] keys = RedisConnectorHelper.Connection.GetServer(endPoint).Keys(pattern: "*").ToArray();
            foreach (var item in keys)
            {
                
            }

            ResultIsReady(AnalyzedData);
        }

        public static bool Connect()
        {
            try
            {
   //             RedisConnectorHelper.Create("127.0.0.1:6379");
            }
            catch(Exception ex)
            {
                ex.ToString();
            }

            return true;
        }

        public bool GetInstrumentList()
        {
            var type1Stocks = _Type1StockRepo.GetType1Stocks();
            foreach(var t1Stock in type1Stocks)
            {
                if (!_InstrumentDictionary.ContainsKey((long)t1Stock.InsCode))
                    _InstrumentDictionary.Add((long)t1Stock.InsCode, 0);
            }
            return true;
        }
    }
}