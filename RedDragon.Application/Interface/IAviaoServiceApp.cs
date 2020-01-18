using System.Collections.Generic;
using RedDragon.Application.ViewModel;

namespace RedDragon.Application.Interface
{
    public interface IAviaoServiceApp
    {
        IEnumerable<AviaoViewModel> ObterTodos();
    }
}