using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteAutoMapper.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string NomeUsuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(50)]
        public string Senha { get; set; }

        public bool Ativo { get; set; }

        [Required]
        public DateTime DataCricao { get; set; }

        [Required]
        [StringLength(15)]
        public string UsuarioCriacao { get; set; }
    }
}