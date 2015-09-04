using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TesteAutoMapper.ViewModels
{
    //[Bind(Exclude = "Id")]
    public class EditarFuncionarioViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

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
        [Editable(false,AllowInitialValue=false)]
        public string NomeUsuario { get; set; }
    }
}