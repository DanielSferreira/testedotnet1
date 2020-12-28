using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gerenciador_de_horas_de_desenvolvedores.ContextDB
{
    [Table("Desenvolvedores")]
    public class DesenvolvedorTable : ITable
    {
        [Key]
        public int DesenvolvedorTableId {get; set;}
                
        [Required]
        [Column("Nome")]
        [MaxLength(120)]
        public string Nome {get; set;}
        
        [Required]
        [Column("Cargo")]
        [MaxLength(50)]
        public string Cargo {get; set;}
        
        [Required]
        [Column("Valor por hora")]
        public double ValorH {get; set;}
    }
}