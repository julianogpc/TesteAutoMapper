using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteAutoMapper.ViewModels
{
    public class CadastrarFuncionarioViewModel
    {
        [DisplayName("Nome")]
        [Required]
        [StringLength(30)]
        public string Nome { get; set; }

        [DisplayName("Data de Nascimento")]
        [Required]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Usuário")]
        [Required]
        [StringLength(15)]
        public string NomeUsuario { get; set; }

        [DisplayName("Senha")]
        [DataType(DataType.Password)]
        [Required]
        [StringLength(50)]
        public string Senha { get; set; }

        [DisplayName("Confirmar Senha")]
        [DataType(DataType.Password)]
        [Compare("Senha")]
        [StringLength(50)]
        public string ConfirmarSenha { get; set; }
    }
}