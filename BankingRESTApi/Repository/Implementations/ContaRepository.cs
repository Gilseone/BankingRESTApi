using BankingRESTApi.Models;
using BankingRESTApi.Models.Context;
using BankingRESTApi.Repository.Generic;
using System.Linq;

namespace BankingRESTApi.Repository.Implementations
{
    public class ContaRepository : GenericRepository<Conta>, IContaRepository
    {
        public ContaRepository(MySQLContext context) : base(context) { }

        public Conta FindByAgenciaNumero(int agencia, int numero)
        {
            var conta = _context.Contas.FirstOrDefault(p => p.Agencia.Equals(agencia) && p.Numero.Equals(numero));
            return conta;
        }
    }
}