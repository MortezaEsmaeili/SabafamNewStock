using MSHB.TsetmcReader.DTO.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.TsetmcReader.Service.Contract
{
    public interface IType1StockRepository
    {
        Task ClearDataAsync();
        List<Type1StockDto> GetType1Stocks();
       // Task SaveType1StockDataAsync(List<TargetPrice> targetPrices);
    }
}
