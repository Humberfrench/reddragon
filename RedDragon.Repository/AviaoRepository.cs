
using RedDragon.Domain.Entity;
using RedDragon.Domain.Inteface.Repository;
using RedDragon.Repository.Interfaces;

namespace RedDragon.Repository
{
    public class AviaoRepository : BaseRepository<Aviao>, IAviaoRepository
    {
        public AviaoRepository(IContextManager contextManager) : base(contextManager)
        {

        }
    }
}