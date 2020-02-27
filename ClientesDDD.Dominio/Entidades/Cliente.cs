using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClientesDDD.Dominio.Entidades
{
    public class Cliente
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe um nome.")]
        [MinLength(2, ErrorMessage = "Nome deve ter no mínimo 2 caracteres")]
        [MaxLength(200, ErrorMessage = "Nome deve ter no máximo 200 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe um sobrenome.")]
        [MinLength(2, ErrorMessage = "Sobrenome deve ter no mínimo 2 caracteres")]
        [MaxLength(200, ErrorMessage = "Sobrenome deve ter no máximo 200 caracteres")]
        public string Sobrenome { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de Nascimento")]       
        public DateTime DataNascimento { get; set; }

    }
}
