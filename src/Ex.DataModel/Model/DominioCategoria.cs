using Ex.DataModel.Model.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ex.DataModel.Model
{
    public class DominioCategoria : ModelBase<DominioCategoria>
    {
        public DominioCategoria()
        {
            Dominios = new HashSet<Dominio>();
        }
        
        [Column(Order = 1)]
        public int DominioCategoriaId { get; set; }
        
        [Column(Order = 2)]
        public string Nome { get; set; }

        public virtual ICollection<Dominio> Dominios { get; set; }
    }
}
