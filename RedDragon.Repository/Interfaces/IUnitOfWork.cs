

using RedDragon.DomainValidator;

namespace RedDragon.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        ValidationResult SaveChanges();
    }
}