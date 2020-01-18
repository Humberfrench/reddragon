using System;

namespace RedDragon.Domain.Entity
{
    public class Aviao
    {
        public int AviaoId { get; set; }
        public string Modelo { get; set; }
        public int QuantidadeDePassageiros { get; set; }
        public DateTime DataCriacao { get; set; }

    }
}