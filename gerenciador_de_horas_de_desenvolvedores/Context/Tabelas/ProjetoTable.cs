using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gerenciador_de_horas_de_desenvolvedores.ContextDB
{
    public class ProjetoTable : ITable
    {
        [Key]
        public int Id { get; set; }
        public string projeto { get; set; }
        public string descricao { get; set; }
        public ICollection<DevsEmProjetosTable> DevsEmProjetosTable { get; set; }
    }
}
