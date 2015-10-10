using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProjetoDDDMota2.Domain.Entities;
using ProjetoDDDMota2.MVC.ViewModels;

namespace ProjetoDDDMota2.MVC.AutoMapper
{

    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ClienteViewModel, Cliente>();
            Mapper.CreateMap<ProdutoViewModel, Produto>();
            Mapper.CreateMap<LoginViewModel, Login>();
        }
    }
}
