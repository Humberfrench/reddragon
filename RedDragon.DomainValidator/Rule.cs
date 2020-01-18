using French.DomainValidator.Interfaces;

namespace RedDragon.DomainValidator
{
    public class Rule<TEntity> : IRule<TEntity>
    {
        private readonly ISpecification<TEntity> _specificationRule;

        public string MensagemErro { get; private set; }

        public Rule(ISpecification<TEntity> rule, string mensagemErro)
        {
            this._specificationRule = rule;
            this.MensagemErro = mensagemErro;
        }

        public bool Validar(TEntity entity)
        {
            return this._specificationRule.IsSatisfiedBy(entity);
        }
    }
}
