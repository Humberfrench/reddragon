using System;

namespace RedDragon.DomainValidator
{
    [Serializable]
    public class ValidationError
    {
        public ValidationError(string message)
        {
            Codigo = 0;
            Messagem = message;
            Erro = true;
        }
        public ValidationError(string message, bool erro)
        {
            Codigo = 0;
            Messagem = message;
            Erro = erro;
        }
        public ValidationError(int codigo, string message, bool erro)
        {
            Codigo = codigo;
            Messagem = message;
            Erro = erro;
        }  
        public int Codigo{ get; set; }

        public string Messagem { get; set; }

        public bool Erro { get; set; }
    }
}

