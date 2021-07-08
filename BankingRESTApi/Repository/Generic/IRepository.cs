using BankingRESTApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingRESTApi.Repository.Generic
{
    public interface IRepository<T> where T : EntidadeBase
    {
        T Create(T item);
        T FindByID(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
        bool Exists(long id);
    }
}