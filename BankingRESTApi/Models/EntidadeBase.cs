using System.ComponentModel.DataAnnotations.Schema;

namespace BankingRESTApi.Models
{
    public class EntidadeBase
    {
        [Column("Id")]
        public long Id { get; set; }
    }
}