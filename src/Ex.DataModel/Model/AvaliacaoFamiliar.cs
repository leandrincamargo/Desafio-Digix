using Ex.DataModel.Model.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ex.DataModel.Model
{
    public class AvaliacaoFamiliar : ModelBase<AvaliacaoFamiliar>
    {
        [Column(Order = 1)]
        public int AvaliacaoFamiliarId { get; set; }

        [Column(Order = 2)]
        public int Pontuacao { get; set; }
        
        [Column(Order = 3)]
        public int FamiliaId { get; set; }

        public virtual Familia Familia { get; set; }
    }
}
