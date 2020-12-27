using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gerenciador_de_horas_de_desenvolvedores.ContextDB
{
    public class DevsEmProjetosTable : ITable
    {
        [Key]
        public int Id { get; set; }
        public string Desenvolvedor { get; set; }
        public int ProjetoTableId { get; set; }
    }
}