using Ex.DataModel.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ex.DataModel.Model
{
    public class Pessoa : ModelBase<Pessoa>
    {
        public Pessoa()
        {
            Rendas = new HashSet<Renda>();
        }

        [Column(Order = 1)]
        public int PessoaId { get; set; }
        
        [Column(Order = 2)]
        public string Nome { get; set; }
        
        [Column(Order = 3)]
        public int FamiliaId { get; set; }
        
        [Column(Order = 4)]
        public int DominioIdTipo { get; set; }

        public DateTime DataDeNascimento { get; set; }

        public virtual Familia Familia { get; set; }

        public virtual Dominio DominioTipo { get; set; }

        public virtual ICollection<Renda> Rendas { get; set; }
    }
}
