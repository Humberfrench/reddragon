using System.Collections.Generic;
using French.DomainValidator.Interfaces;

namespace RedDragon.DomainValidator
{
    public abstract class Validator<TEntity> : IValidator<TEntity> where TEntity : class
    {
        private readonly Dictionary<string, IRule<TEntity>> _validations = new Dictionary<string, IRule<TEntity>>();

        protected virtual void AdicionarRegra(string nomeRegra, IRule<TEntity> rule)
        {
            _validations.Add(nomeRegra, rule);
        }

        protected virtual void RemoverRegra(string nomeRegra)
        {
            _validations.Remove(nomeRegra);
        }

        public virtual ValidationResult Validar(TEntity entity)
        {
            var result = new ValidationResult();

            foreach (var x in _validations.Keys)
            {
                var rule = _validations[x];
                if (!rule.Validar(entity))
                    result.Add(new ValidationError(rule.MensagemErro));
            }

            return result;
        }

        protected IRule<TEntity> ObterRegra(string nomeRegra)
        {
            IRule<TEntity> rule;
            _validations.TryGetValue(nomeRegra, out rule);
            return rule;
        }



    }
}
