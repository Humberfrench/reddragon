namespace French.DomainValidator.Interfaces
{
    public interface IRule<in TEntity>
    {
        string MensagemErro { get; }
        bool Validar(TEntity entity);
    }
}
