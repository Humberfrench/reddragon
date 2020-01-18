using System.Collections.Generic;
using System.Linq.Expressions;
using RedDragon.Application.ViewModel;
using RedDragon.DomainValidator;

namespace RedDragon.Application.Interface
{
    public interface IAviaoServiceApp
    {
        IEnumerable<AviaoViewModel> ObterTodos();
        IEnumerable<AviaoViewModel> Filtrar(string query);
        ValidationResult Gravar(AviaoViewModel aviao);
        ValidationResult Excluir(int id);
        AviaoViewModel ObterPorId(int id);
    }
}