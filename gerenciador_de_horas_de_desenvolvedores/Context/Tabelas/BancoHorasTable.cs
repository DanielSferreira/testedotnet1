using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gerenciador_de_horas_de_desenvolvedores.ContextDB
{
    [Table("BancoHoras")]
    public class BancoHorasTable : ITable
    {
        [Key]
        public int Id { get; set; }
        public int DataId { get; set; }

        [Required]
        [Column("Data Inicio")]
        public DateTime DataIni { get; set; }
        [Required]
        [Column("Data Final")]
        public DateTime DataFim { get; set; }

        [Required]
        [Column("Desenvolvedor")]
        [MaxLength(120)]
        public string Desenvolvedor { get; set; }
    }
}