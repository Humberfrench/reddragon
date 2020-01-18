using RedDragon.Domain.Entity;

namespace Fred.Services
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