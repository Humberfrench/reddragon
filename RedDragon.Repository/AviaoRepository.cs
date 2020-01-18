
using Dapper;
using RedDragon.Domain.Entity;
using RedDragon.Domain.Inteface.Repository;
using RedDragon.Repository.Interfaces;
using System.Collections.Generic;

namespace RedDragon.Repository
{
    public class AviaoRepository : BaseRepository<Aviao>, IAviaoRepository
    {
        public AviaoRepository(IContextManager contextManager) : base(contextManager)
        {

        }

        public IEnumerable<Aviao> Filtrar(string query)
        {
            var sql = $@"SELECT * FROM Aviao WHERE Modelo like '%{query}%'";

            return this.Connection.Query<Aviao>(sql);
        }
    }
}