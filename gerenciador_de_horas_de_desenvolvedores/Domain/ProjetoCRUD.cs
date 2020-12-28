using System.Threading.Tasks;
using System.Linq;
using gerenciador_de_horas_de_desenvolvedores.ContextDB;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace gerenciador_de_horas_de_desenvolvedores.Domain
{
    public class ProjetoCRUD : ICRUD
    {
        private LubyTestDB context;
        public ProjetoCRUD(LubyTestDB _context)
        {
            context = _context;
        }

        public async Task<ITable[]> GetAll()
        {
            return await context.Projetos.Select(x => x).ToArrayAsync();
        }

        public async Task<ITable[]> GetDevInProject()
        {
            return await context.DevsEmProjetos.Select(x => x).ToArrayAsync();
        }

        public async Task<ITable> GetOne(ITable ety, bool isId = true)
        {

            ProjetoTable entity = (ProjetoTable)ety;
            if (isId)
                return await context.Projetos.FirstOrDefaultAsync(x => x.Id == entity.Id);
            else
                return await context.Projetos.FirstOrDefaultAsync(x => x.projeto == entity.projeto);

        }

        public async Task<bool> Insert(ITable ety)
        {
            ProjetoTable entity = (ProjetoTable)ety;
            await context.Projetos.AddAsync(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(ITable ety)
        {
            ProjetoTable entity = (ProjetoTable)ety;
            var res = context.Projetos.FirstOrDefault(x => x.Id == entity.Id);
            if (res is not null)
            {
                res.projeto = entity.projeto;
                res.descricao = entity.descricao;
                //foreach (var item in entity.DevsEmProjetosTable)
                //    context.DevsEmProjetos.Remove(item);
                //await this.UpdateProjetos(entity);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateProjetos(ITable[] ety)
        {
            DevsEmProjetosTable[] entity = (DevsEmProjetosTable[])ety;
            var res = context.DevsEmProjetos.Select(x => x);
            if (res is not null)
            {
                foreach (var item in res)
                    context.DevsEmProjetos.Remove(item);

                context.DevsEmProjetos.AddRange(entity);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var delete = context.Projetos.FirstOrDefault(x => x.Id == id);
            context.Entry(delete).State = EntityState.Deleted;
            await context.SaveChangesAsync();
            return true;
        }
    }
}
