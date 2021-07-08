using BankingRESTApi.Data.VO;
using System.Collections.Generic;

namespace BankingRESTApi.Business
{
    public interface IContaBusiness
    {
        ContaVO Create(ContaVO conta);
        ContaVO FindByID(long id);
        ContaVO Depositar(int agencia, int numero, decimal valor);
        ContaVO Sacar(int agencia, int numero, decimal valor);
        List<ContaVO> Transferir(int agenciaOrigem, int numeroOrigem, int agenciaDestino, int numeroDestino, decimal valor);
        List<ContaVO> FindAll();
        ContaVO Update(ContaVO conta);
        void Delete(long id);
    }
}