using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.TsetmcReader.DTO.DataModel
{
    public class TargetPrice
    {
        public string InsCode { get; set;}
        public string Symbol { get;set;}
        public decimal Target1PricePercentage { get; set; } = 0;
        public decimal Target2PricePercentage { get; set; } = 0;
        public decimal Target3PricePercentage { get; set; } = 0;
        public decimal PriceSupportPercentage { get; set; } = 0;    
        public decimal CurrentPrice { get; set; } = 0;
        public decimal TargetPrice1 { get; set;}
        public decimal TargetPrice2 { get; set; }
        public decimal TargetPrice3 { get; set; }
        public decimal SupportPrice { get; set; }

    }
}
