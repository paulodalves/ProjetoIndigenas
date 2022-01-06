using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoIndigenas.Models
{

    public class Denuncia
    {
        public int DenunciaID { get; set; }
        public int PessoaID { get; set; }
        
        public string Tipo { get; set; }
        public string Localizacao { get; set; }
        public string? Descricao { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime UltimaAtt { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
