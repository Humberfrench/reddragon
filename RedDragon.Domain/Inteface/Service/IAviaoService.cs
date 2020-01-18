using RedDragon.Domain.Entity;
using RedDragon.DomainValidator;
using System.Collections.Generic;

namespace RedDragon.Domain.Inteface.Service
{
    public interface IAviaoService:IBaseService<Aviao>
    {
        ValidationResult Gravar(Aviao aviao);
        ValidationResult Excluir(int id);
        IEnumerable<Aviao> Filtrar(string query);
    }
}