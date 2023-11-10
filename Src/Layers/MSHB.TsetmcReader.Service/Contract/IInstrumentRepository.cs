using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.TsetmcReader.Service.Contract
{
    public interface IInstrumentRepository
    {
        decimal GetInsCodeBySymbol(string symbol);
        void SaveInstrumentInDB(string sembol, decimal instrumentID);
        Task SaveInstrumentsInDBAsync(IEnumerable<Tuple<string, string>> symbolInsCodes);
    }
}
