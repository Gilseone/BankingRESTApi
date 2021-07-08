using BankingRESTApi.Models;
using BankingRESTApi.Repository.Generic;
using System.Collections.Generic;

namespace BankingRESTApi.Repository
{
    public interface IContaRepository : IRepository<Conta>
    {
        Conta FindByAgenciaNumero(int agencia, int numero);
    }
}