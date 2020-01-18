using RedDragon.Repository.Context;
using RedDragon.Repository.Interfaces;
using System;
using RedDragon.DomainValidator;

namespace RedDragon.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly RedDragonContext dbContext;
        private readonly ValidationResult validationResult;

        private bool _disposed;

        public UnitOfWork(IContextManager contextManager)
        {
            this.dbContext = contextManager.GetContext();
            validationResult = new ValidationResult();
        }

        public void BeginTransaction()
        {
            this._disposed = false;
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ValidationResult SaveChanges()
        {
            try
            {
                this.dbContext.SaveChanges();
            }
            //EntityValidationException
            //catch (Microsoft.EntityFrameworkCore.DbUpdateException   exValidation)
            //{
            //    var erros = exValidation.Entries.ToList();
            //    if (erros.Any())
            //    {
            //        erros.ForEach(e => e.ValidationErrors.ToList().ForEach(ev => validationResult.Add($"Erro de Validção ao Gravar: {ev.ErrorMessage}")));
            //    }
            //    else
            //    {
            //        validationResult.Add(exValidation.Message);
            //    }
            //}
            catch (Exception ex)
            {
                validationResult.Add(ex.Message);
            }
            return validationResult;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    this.dbContext.Dispose();
                }
            }
            this._disposed = true;
        }
    }

}