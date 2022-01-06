using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoIndigenas.Models
{
    public class Pessoa
    {
        public int PessoaID { get; set; }
        public string Nome { get; set; }
        public string Cpf_Rani { get; set; }
        public string Tel1 { get; set; }
        public string? Tel2 { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DatNasc { get; set; }
        public ICollection<Denuncia> Denuncias { get; set; }

    }
}
