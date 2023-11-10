using MSHB.TsetmcReader.DTO.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.TsetmcReader.Service.Contract
{
    public interface IInstrumentHistoryRepository
    {
        Instrument10DaysHistoryDto GetInsPrice(string symbol, string insCode, decimal supportPrice);
        List<InstrumentHistoryDto> GetInstrumentHistories(int dayCount);
        void SaveAndUpdateLastPrise(Dictionary<long, Tuple<string, decimal?>> instrumentPriceDic);
    }
}
