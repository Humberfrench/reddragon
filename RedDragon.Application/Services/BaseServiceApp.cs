using System.Linq;
using AutoMapper;
using RedDragon.Application.AutoMapper;
using RedDragon.Application.Interface;
using RedDragon.DomainValidator;
using RedDragon.Repository.Interfaces;

namespace RedDragon.Application.Services
{
    public class BaseServiceApp : IBaseServiceApp
    {
        private readonly IUnitOfWork uow;
        protected readonly IMapper Mapper;
        protected ValidationResult ValidationResults;

        public BaseServiceApp(IUnitOfWork uow)
        {
            this.uow = uow;
            AutoMapperConfig.RegisterMappings();
            Mapper = AutoMapperConfig.Config.CreateMapper();
            ValidationResults = new ValidationResult();
        }

        public void BeginTransaction()
        {
            uow.BeginTransaction();
        }

        public void Commit()
        {
            var retorno = uow.SaveChanges();
            if (!retorno.IsValid)
            {
                retorno.Erros.ToList().ForEach(e => ValidationResults.Add(e.Messagem));
            }
        }
    }
}
