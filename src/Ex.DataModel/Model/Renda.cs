using Ex.DataModel.Model.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ex.DataModel.Model
{
    public class Renda : ModelBase<Renda>
    {
        [Column(Order = 1)]
        public int RendaId { get; set; }

        [Column(Order = 2)]
        public int PessoaId { get; set; }

        [Column(Order = 3)]
        public decimal Valor { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
