using System.Collections.Generic;

namespace BankingRESTApi.Hypermedia.Abstract
{
    public interface ISupportsHypermedia
    {
        List<HyperMediaLink> Links { get; set; }
    }
}