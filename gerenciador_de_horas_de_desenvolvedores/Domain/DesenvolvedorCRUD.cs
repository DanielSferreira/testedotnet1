using System.Linq;
using System.Threading.Tasks;
using gerenciador_de_horas_de_desenvolvedores.ContextDB;
using Microsoft.EntityFrameworkCore;

namespace gerenciador_de_horas_de_desenvolvedores.Domain
{
    public class DesenvolvedorCRUD : ICRUD
    {
        private LubyTestDB context;
        public DesenvolvedorCRUD(LubyTestDB _context)
        {
            context = _context;
        }
        public async Task<bool> Insert(ITable ety)
        {
            DesenvolvedorTable entity = (DesenvolvedorTable)ety;
            await context.Desenvolvedores.AddAsync(entity);
            await context.SaveChangesAsync();
            return true;

        }
        public async Task<bool> Update(ITable ety)
        {
            DesenvolvedorTable entity = (DesenvolvedorTable)ety;
            var res = context.Desenvolvedores.FirstOrDefault(x => x.Nome == entity.Nome);
            if (res is not null)
            {
                res.Nome = entity.Nome;
                res.Cargo = entity.Cargo;
                res.ValorH = entity.ValorH;
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> Delete(int id)
        {
            var delete = context.Desenvolvedores.FirstOrDefault(x => x.DesenvolvedorTableId == id);
            context.Entry(delete).State = EntityState.Deleted;
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<ITable[]> GetAll()
        {
            return await context.Desenvolvedores.Select(x => x).ToArrayAsync();
        }
        public async Task<ITable> GetOne(ITable ety, bool isId = true)
        {
            DesenvolvedorTable entity = (DesenvolvedorTable)ety;
            if (isId)
                return await context.Desenvolvedores.FirstOrDefaultAsync(x => x.DesenvolvedorTableId == entity.DesenvolvedorTableId);
            else
                return await context.Desenvolvedores.FirstOrDefaultAsync(x => x.Nome == entity.Nome);

        }
    }
}