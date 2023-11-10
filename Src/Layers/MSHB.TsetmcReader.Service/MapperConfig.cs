using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSHB.TsetmcReader.Dal;
using MSHB.TsetmcReader.DTO.DataModel;

namespace MSHB.TsetmcReader.Service
{
    public static class MapperConfig
    {
        private static Mapper instance;
        public static Mapper Instance { 
            get
            {
                instance= instance ?? InitializeAutomapper();
                return instance;
            } 
        }
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                
                cfg.CreateMap<Instrument, InstrumentDto>().ReverseMap();
                cfg.CreateMap<Type1Stock, Type1StockDto>().ReverseMap();
                cfg.CreateMap<Type1StockDto, TargetPrice>();
                cfg.CreateMap<TargetPrice, Type1Stock>()
                     .ForMember(dest => dest.tmst, act => act.MapFrom(src => DateTime.Now))
                     .ForMember(dest => dest.LastPrice, act => act.MapFrom(src => src.CurrentPrice))
                     ;

                //Any Other Mapping Configuration ....
            });

            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }

}
