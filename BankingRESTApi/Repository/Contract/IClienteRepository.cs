using BankingRESTApi.Models;
using BankingRESTApi.Repository.Generic;
using System.Collections.Generic;

namespace BankingRESTApi.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente Disable(long id);
    }
}