using RedDragon.DomainValidator;

namespace French.DomainValidator.Interfaces
{
    public interface IValidator<in TEntity>
    {
        ValidationResult Validar(TEntity entity);
    }
}
