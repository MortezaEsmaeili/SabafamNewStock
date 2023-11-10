using AutoMapper;
using MSHB.TsetmcReader.DTO.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.TsetmcReader.Service.Helper
{
    public static class Extensions
    {
        private static Mapper _mapper = MapperConfig.Instance;
        public static string ToCleanString(this string input)
        {
            return input.Replace("ی", "ي").Replace("ک", "ك");
        }
        public static IEnumerable<T> Convert<S,T>(this IEnumerable<S> source) 
            where T:class
            where S : class
        {
           return _mapper.Map<IEnumerable<T>>(source);
        }
    }
}
