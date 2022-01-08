using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoIndigenas.Models
{

    public class Denuncia
    {
        public int DenunciaID { get; set; }
        [Required]
        [Display(Name = "ID do Usuário")]
        public int PessoaID { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        [Display(Name = "Localização")]
        public string Localizacao { get; set; }
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        [Display(Name = "Última Atualização")]
        public DateTime UltimaAtt { get; set; }
        [Display(Name = "Denunciante")]
        public Pessoa Pessoa { get; set; }
    }
}
