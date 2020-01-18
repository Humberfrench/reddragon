using RedDragon.Domain.Entity;
using RedDragon.Domain.Inteface.Repository;
using RedDragon.Domain.Inteface.Service;
using RedDragon.DomainValidator;
using RedDragon.Extensions;
using System.Collections.Generic;

namespace RedDragon.Services
{
    public class AviaoService : BaseService<Aviao>, IAviaoService
    {
        private readonly IAviaoRepository repository;
        private readonly ValidationResult validationResult;
        public AviaoService(IBaseRepository<Aviao> baseRepository, IAviaoRepository repository) : base(baseRepository)
        {
            this.repository = repository;
            validationResult = new ValidationResult();
        }

        public ValidationResult Gravar(Aviao aviao)
        {
            //validate
            if (aviao.Modelo.IsNullOrEmptyOrWhiteSpace())
            {
                validationResult.Add("Modelo não preenchido");
                return validationResult;
            }

            if (aviao.QuantidadeDePassageiros == 0)
            {
                validationResult.Add("Quantidade de Passageiros não preenchido");
                return validationResult;
            }

            //add or update
            if(aviao.AviaoId == 0)
            {
                base.Adicionar(aviao);
            }
            else
            {
                base.Atualizar(aviao);
            }

            return validationResult;
        }

        public ValidationResult Excluir(int id)
        {
            var aviao = ObterPorId(id);
            if(aviao == null)
            {
                validationResult.Add("Avião inexistente");
                return validationResult;
            }

            base.Remover(aviao);
            
            return validationResult;
        }

        public IEnumerable<Aviao> Filtrar(string query)
        {
            return repository.Filtrar(query);
        }
    }
}