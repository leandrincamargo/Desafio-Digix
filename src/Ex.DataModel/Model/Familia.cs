using Ex.DataModel.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ex.DataModel.Model
{
    public class Familia : ModelBase<Familia>
    {
        public Familia()
        {
            Pessoas = new HashSet<Pessoa>();
        }

        [Column(Order = 1)]
        public int FamiliaId { get; set; }

        [Column(Order = 2)]
        public int DominioIdStatus { get; set; }

        public virtual Dominio DominioStatus { get; set; }

        public virtual ICollection<Pessoa> Pessoas { get; set; }
        public virtual ICollection<AvaliacaoFamiliar> AvaliacoesFamiliar { get; set; }
    }
}
