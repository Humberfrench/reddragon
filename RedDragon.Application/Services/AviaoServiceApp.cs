using System.Collections.Generic;
using RedDragon.Application.Interface;
using RedDragon.Application.ViewModel;
using RedDragon.Domain.Entity;
using RedDragon.Domain.Inteface.Service;
using RedDragon.DomainValidator;
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

        public ValidationResult Gravar(AviaoViewModel aviao)
        {
            BeginTransaction();
            var dadoIncluir = Mapper.Map<Aviao>(aviao);
            var retorno = service.Gravar(dadoIncluir);
            if(retorno.IsValid)
            {
                //commit transaction
                Commit();
                //commit error
                if(!ValidationResults.IsValid)
                {
                    return ValidationResults;
                }
            }
            return retorno;

        }

        public ValidationResult Excluir(int id)
        {
            BeginTransaction();
            var retorno = service.Excluir(id);
            if (retorno.IsValid)
            {
                //commit transaction
                Commit();
                //commit error
                if (!ValidationResults.IsValid)
                {
                    return ValidationResults;
                }
            }
            return retorno;

        }

        public AviaoViewModel ObterPorId(int id)
        {
            var avioes = service.ObterPorId(id);
            var retorno = Mapper.Map<AviaoViewModel>(avioes);
            return retorno;
        }

        public IEnumerable<AviaoViewModel> ObterTodos()
        {
            var avioes = service.ObterTodos();
            var retorno = Mapper.Map<IEnumerable<AviaoViewModel>>(avioes);
            return retorno;

        }

        public IEnumerable<AviaoViewModel> Filtrar(string query)
        {
            var avioes = service.Filtrar(query);
            var retorno = Mapper.Map<IEnumerable<AviaoViewModel>>(avioes);
            return retorno;

        }
    }
}