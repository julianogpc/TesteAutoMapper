using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TesteAutoMapper.Models;
using TesteAutoMapper.ViewModels;

namespace TesteAutoMapper.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Usuario, CadastrarFuncionarioViewModel>();

            Mapper.CreateMap<Funcionario, CadastrarFuncionarioViewModel>()
                .ForMember(o => o.NomeUsuario, m=> m.MapFrom(s=>s.Usuario.NomeUsuario))
                .ForMember(o => o.Senha, m => m.MapFrom(s => s.Usuario.Senha))
                ;

            Mapper.CreateMap<Usuario, EditarFuncionarioViewModel>();

            Mapper.CreateMap<Funcionario, EditarFuncionarioViewModel>()
                .ForMember(o => o.NomeUsuario, m => m.MapFrom(s => s.Usuario.NomeUsuario))
                ;

        }
    }
}
