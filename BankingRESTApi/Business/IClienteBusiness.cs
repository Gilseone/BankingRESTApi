using BankingRESTApi.Data.VO;
using System.Collections.Generic;

namespace BankingRESTApi.Business
{
    public interface IClienteBusiness
    {
        ClienteVO Create(ClienteVO cliente);
        ClienteVO FindByID(long id);
        List<ClienteVO> FindAll();
        ClienteVO Update(ClienteVO cliente);
        ClienteVO Disable(long id);
        void Delete(long id);
    }
}