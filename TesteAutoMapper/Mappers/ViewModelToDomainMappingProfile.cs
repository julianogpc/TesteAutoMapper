using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TesteAutoMapper.Models;
using TesteAutoMapper.ViewModels;

namespace TesteAutoMapper.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CadastrarFuncionarioViewModel, Usuario>()
                .AfterMap((src, dest) => dest.DataCricao = DateTime.Now)
                .AfterMap((src, dest) => dest.Ativo = true)
                .AfterMap((src, dest) => dest.UsuarioCriacao = "juliano");

            Mapper.CreateMap<CadastrarFuncionarioViewModel, Funcionario>()
                .AfterMap((src, dest) => dest.Usuario = Mapper.Map<CadastrarFuncionarioViewModel, Usuario>(src))
                ;

            Mapper.CreateMap<EditarFuncionarioViewModel, Funcionario>()
                .AfterMap((src, dest) => dest.Usuario.NomeUsuario = Mapper.Map<EditarFuncionarioViewModel, Usuario>(src).NomeUsuario)
                ;
        }
    }
}