using Ex.DataModel.Model.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ex.DataModel.Model
{
    public class Dominio : ModelBase<Dominio>
    {
        public Dominio()
        {
            Pessoas = new HashSet<Pessoa>();
            Familias = new HashSet<Familia>();
        }


        [Column(Order = 1)]
        public int DominioId { get; set; }


        [Column(Order = 2)]
        public string Nome { get; set; }


        [Column(Order = 3)]
        public int DominioCategoriaId { get; set; }

        public virtual ICollection<Pessoa> Pessoas { get; set; }

        public virtual ICollection<Familia> Familias { get; set; }

        public virtual DominioCategoria DominioCategoria { get; set; }
    }
}
