using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabalhoIHM.Dtos;
using TrabalhoIHM.Models;

namespace TrabalhoIHM.Auto_Mapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AlunosDto, Aluno>();
        }
    }
}