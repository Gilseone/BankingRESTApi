using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingRESTApi.Models
{
    [Table("Contas")]
    public class Conta : EntidadeBase
    {
        [Column("Agencia")]
        public int Agencia { get; set; }

        [Column("Numero")]
        public int Numero { get; set; }

        [Column("Limite")]
        public decimal Limite { get; set; }

        [Column("Saldo")]
        public decimal Saldo { get; set; }

        [Column("DataCriacao")]
        public DateTime DataCriacao { get; set; }

        public Cliente Cliente { get; set; }
    }
}