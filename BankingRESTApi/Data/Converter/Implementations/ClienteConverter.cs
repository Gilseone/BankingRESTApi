using BankingRESTApi.Data.Converter.Contract;
using BankingRESTApi.Data.VO;
using BankingRESTApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace BankingRESTApi.Data.Converter.Implementations
{
    public class ClienteConverter : IParser<ClienteVO, Cliente>, IParser<Cliente, ClienteVO>
    {
        public Cliente Parse(ClienteVO origin)
        {
            if (origin == null)
                return null;
            else
            {
                return new Cliente
                {
                    Id = origin.Id,
                    Nome = origin.Nome,
                    CPF = origin.CPF,
                    Endereco = origin.Endereco,
                    Ativo = origin.Ativo,
                    ContaId = origin.ContaId,
                    Conta = new ContaConverter().Parse(origin.Conta)
                };
            }
        }

        public ClienteVO Parse(Cliente origin)
        {
            if (origin == null)
                return null;
            else
            {
                return new ClienteVO
                {
                    Id = origin.Id,
                    Nome = origin.Nome,
                    CPF = origin.CPF,
                    Endereco = origin.Endereco,
                    Ativo = origin.Ativo,
                    ContaId = origin.ContaId,
                    Conta = new ContaConverter().Parse(origin.Conta)
                };
            }
        }

        public List<ClienteVO> Parse(List<Cliente> origin)
        {
            if (origin == null)
                return null;
            else
                return origin.Select(item => Parse(item)).ToList();
        }

        public List<Cliente> Parse(List<ClienteVO> origin)
        {
            if (origin == null)
                return null;
            else
                return origin.Select(item => Parse(item)).ToList();
        }
    }
}