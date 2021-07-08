using BankingRESTApi.Data.Converter.Contract;
using BankingRESTApi.Data.VO;
using BankingRESTApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace BankingRESTApi.Data.Converter.Implementations
{
    public class ContaConverter : IParser<ContaVO, Conta>, IParser<Conta, ContaVO>
    {
        public Conta Parse(ContaVO origin)
        {
            if (origin == null)
                return null;
            else
            {
                return new Conta
                {
                    Id = origin.Id,
                    Agencia = origin.Agencia,
                    Numero = origin.Numero,
                    Limite = origin.Limite,
                    Saldo = origin.Saldo,
                    DataCriacao = origin.DataCriacao,
                };
            }
        }

        public ContaVO Parse(Conta origin)
        {
            if (origin == null)
                return null;
            else
            {
                return new ContaVO
                {
                    Id = origin.Id,
                    Agencia = origin.Agencia,
                    Numero = origin.Numero,
                    Limite = origin.Limite,
                    Saldo = origin.Saldo,
                    DataCriacao = origin.DataCriacao,
                };
            }
        }

        public List<ContaVO> Parse(List<Conta> origin)
        {
            if (origin == null)
                return null;
            else
                return origin.Select(item => Parse(item)).ToList();
        }

        public List<Conta> Parse(List<ContaVO> origin)
        {
            if (origin == null)
                return null;
            else
                return origin.Select(item => Parse(item)).ToList();
        }
    }
}