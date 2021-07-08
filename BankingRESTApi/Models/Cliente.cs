using System.ComponentModel.DataAnnotations.Schema;

namespace BankingRESTApi.Models
{
    [Table("Clientes")]
    public class Cliente : EntidadeBase
    {
        [Column("Nome")]
        public string Nome { get; set; }

        [Column("CPF")]
        public string CPF { get; set; }

        [Column("Endereco")]
        public string Endereco { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }

        public long? ContaId { get; set; }
        public Conta Conta { get; set; }
    }
}