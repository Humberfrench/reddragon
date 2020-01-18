using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace RedDragon.DomainValidator
{
    [Serializable]
    public class ValidationResult
    {
        private readonly List<ValidationError> errors = new List<ValidationError>();

        public HttpStatusCode StatusCode { get; set; }

        public void Add(ValidationError error)
        {
            this.errors.Add(error);
        }

        public void Add(params ValidationResult[] validationResults)
        {
            if (validationResults != null)
            {
                foreach (var result in from result in validationResults
                                       where result != null
                                       select result)
                {
                    this.errors.AddRange(result.errors);
                }
            }
        }

        public void Add(string error, bool erro = true)
        {
            var validationErro = new ValidationError(error, erro);
            this.errors.Add(validationErro);
        }
        public void Add(int codigo, string error, bool erro = true)
        {
            var validationErro = new ValidationError(codigo, error, erro);
            this.errors.Add(validationErro);
        }

        public void AddError(string error)
        {
            var validationErro = new ValidationError(error, true);
            this.errors.Add(validationErro);
        }

        public void AddWarning(string error)
        {
            var validationErro = new ValidationError(error, false);
            this.errors.Add(validationErro);
        }

        public void Remove(ValidationError error)
        {
            if (this.errors.Contains(error))
            {
                this.errors.Remove(error);
            }
        }

        public IList<ValidationError> Erros => errors;

        public bool IsValid
        {
            get
            {
                return !errors.Any(vr => vr.Erro);
            }
        }

        public string Messagem { get; set; }

        public int CodigoMessagem { get; set; }

        public object Retorno { get; set; }

        public bool ProblemaDeInfraestrutura { get; set; }

        public bool Warning
        {
            get
            {
                return this.errors.Count(vr => vr.Erro) != this.Erros.Count;
            }
        }
    }
}

