using RedDragon.Domain.Entity;
using RedDragon.Domain.Inteface.Repository;
using RedDragon.Domain.Inteface.Service;

namespace RedDragon.Services
{
    public class AviaoService:BaseService<Aviao>, IAviaoService
    {
        IAviaoRepository repository;
        public AviaoService(IBaseRepository<Aviao> baseRepository, IAviaoRepository repository) : base(baseRepository)
        {
            this.repository = repository;
        }
    }
}