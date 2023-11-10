using DocumentFormat.OpenXml.InkML;
using MSHB.TsetmcReader.DTO.DataModel;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;


namespace MSHB.TsetmcReader.Service.Impl
{
    public delegate void DataResultAction(Dictionary<decimal, TsetmcDto> results);

    public class TsetmcDataAnalyzer
    {
        private ConcurrentBag<string> messages = new ConcurrentBag<string>();
        private static TsetmcDataAnalyzer instance;
        public static TsetmcDataAnalyzer Instance
        {
            get
            {
                instance = instance ?? new TsetmcDataAnalyzer();
                return instance;
            }
        }
        private TsetmcDataAnalyzer()
        {
            Task.Run(() =>
            {
                DoAnalysis();
            });
        }
        public void Add2MessageBag(string message)
        {
            messages.Add(message);
        }
        public event DataResultAction OnResultReady;
        private void ResultIsReady(Dictionary<decimal, TsetmcDto> results)
        {
            if (OnResultReady != null) { OnResultReady(results); }
        }

        private void DoAnalysis()
        {
            while (true)
            {
                if (messages.IsEmpty)
                {
                    Thread.Sleep(10);
                    continue;
                }
                messages.TryTake(out string message);
                ProcessMessage(message);
            }
        }


        public void ProcessMessage(string responseMessage)
        {
            System.Diagnostics.Trace.WriteLine(responseMessage);
            var logs = responseMessage.Trim().Split(';').Select(x => x.Trim()).ToArray();
            if (logs != null && logs.Length > 0)
            {
                var AnalyzedData = new Dictionary<decimal, TsetmcDto>();
                foreach (var log in logs)
                {
                    var data = log.Replace("'", "").Trim().Split(',').Select(x => x.Trim()).ToArray();
                    int dataLength = data.Length;

                    if ((dataLength == 8 && data[1] == "1") || dataLength == 10)
                    {
                        if (decimal.TryParse(data[0], out var value))
                        {
                            TsetmcDto tsetmcDto = new TsetmcDto { InsCode = value };
                            Analyze(data, ref tsetmcDto);
                            if (AnalyzedData.ContainsKey(value))
                                AnalyzedData.Remove(value);
                            AnalyzedData.Add(value, tsetmcDto);
                        }
                    }
                }

                ResultIsReady(AnalyzedData);//(proccessedData);
            }
        }

        private void Analyze(string[] data, ref TsetmcDto tsetmcDto)
        {
            //37762443198265540,1,1,1,1650,5311,6,5
            //insId,"1",x,x,Bbp,Bsp,Bbq,Bsq
            try
            {
                System.Diagnostics.Trace.WriteLine("Esi Analisssssssssssssssssssss");
                if (data.Length == 8)
                {
                    tsetmcDto.Bbp = data[4];
                    tsetmcDto.Bsp = data[5];
                    tsetmcDto.Bbq = data[6];
                    tsetmcDto.Bsq = data[7];
                }
                //43951910415124966,61223,0,14640,14870,0,0,0,0,0
                //insId,x,x,Cp,Ltp,Nt,Nst,Tv,x,x,x
                if (data.Length == 10)
                {
                    tsetmcDto.Cp = data[3];
                    tsetmcDto.Ltp = data[4];
                    tsetmcDto.Nt = data[5];
                    tsetmcDto.Nst = data[6];
                    tsetmcDto.Tv = data[7];
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}

