using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoIndigenas.Models
{
    public class Pessoa
    {
        public int PessoaID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "CPF/RANI")]
        public string Cpf_Rani { get; set; }
        [Required]
        [Display(Name = "Tel 1")]
        public string Tel1 { get; set; }
        [Display(Name = "Tel 2")]
        public string? Tel2 { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Nascimento")]
        public DateTime? DatNasc { get; set; }
        public ICollection<Denuncia> Denuncias { get; set; }

    }
}
