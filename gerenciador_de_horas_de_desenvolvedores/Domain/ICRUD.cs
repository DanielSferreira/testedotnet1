using System;
using System.Threading.Tasks;
using gerenciador_de_horas_de_desenvolvedores.ContextDB;

namespace gerenciador_de_horas_de_desenvolvedores.Domain
{
    public interface ICRUD
    {
        public Task<bool> Insert(ITable ety);
        public Task<bool> Update(ITable ety);
        public Task<bool> Delete(int id);
        public Task<ITable[]> GetAll();
        public Task<ITable> GetOne(ITable ety, bool isId = true);
    }
}