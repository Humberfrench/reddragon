using RedDragon.Domain.Entity;
using System.Collections.Generic;

namespace RedDragon.Domain.Inteface.Repository
{
    public interface IAviaoRepository: IBaseRepository<Aviao>
    {
        IEnumerable<Aviao> Filtrar(string query);
    }
}