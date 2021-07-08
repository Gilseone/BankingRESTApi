using BankingRESTApi.Hypermedia;
using BankingRESTApi.Hypermedia.Abstract;
using System.Collections.Generic;

namespace BankingRESTApi.Data.VO
{
    public class ClienteVO : ISupportsHypermedia
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public bool Ativo { get; set; }
        public long? ContaId { get; set; }
        public ContaVO Conta { get; set; } = new ContaVO();
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}