using BankingRESTApi.Hypermedia.Abstract;
using System.Collections.Generic;

namespace BankingRESTApi.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}