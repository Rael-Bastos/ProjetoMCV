using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoIHM.Auto_Mapper
{
    public class AutoMapper_config
    {
        public static IMapper Mapper { get; private set; }

        public static void RegisterMappings()
        {
            var _mapper = new MapperConfiguration((mapper) =>
            {
                mapper.AddProfile<DomainToViewModelMappingProfile>();
                mapper.AddProfile<ViewModelToDomainMappingProfile>();
            });
             Mapper = _mapper.CreateMapper();
        }
    }
}