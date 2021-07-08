using BankingRESTApi.Hypermedia;
using BankingRESTApi.Hypermedia.Abstract;
using BankingRESTApi.Models;
using System;
using System.Collections.Generic;

namespace BankingRESTApi.Data.VO
{
    public class ContaVO : ISupportsHypermedia
    {
        public long Id { get; set; }
        public int Agencia { get; set; }
        public int Numero { get; set; }
        public decimal Limite { get; set; }
        public decimal Saldo { get; set; }
        public DateTime DataCriacao { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}