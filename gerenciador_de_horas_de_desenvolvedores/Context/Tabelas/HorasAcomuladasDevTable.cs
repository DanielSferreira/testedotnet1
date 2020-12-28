using System.ComponentModel.DataAnnotations;

namespace gerenciador_de_horas_de_desenvolvedores.ContextDB
{
    public class HorasAcomuladasDevTable : ITable
    {
        [Key]
        public int Id { get; set; }
        public string Desenvolvedor { get; set; }
        public double HorasAcomuladas { get; set; }
    }
}