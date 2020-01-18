using System.Collections.Generic;
using RedDragon.Application.Interface;
using RedDragon.Application.ViewModel;
using RedDragon.Domain.Inteface.Service;
using RedDragon.Repository.Interfaces;

namespace RedDragon.Application.Services
{
    public class AviaoServiceApp :BaseServiceApp, IAviaoServiceApp
    {
        private readonly IAviaoService service;
        public AviaoServiceApp(IAviaoService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
        }

        public IEnumerable<AviaoViewModel> ObterTodos()
        {
            var bancos = service.ObterTodos();
            var retorno = Mapper.Map<IEnumerable<AviaoViewModel>>(bancos);
            return retorno;

        }
    }
}