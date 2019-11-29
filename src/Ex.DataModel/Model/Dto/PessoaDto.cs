using System;
using System.Collections.Generic;

namespace Ex.DataModel.Model.Dto
{
    public class PessoaDto
    {
        public string Nome { get; set; }
        
        public int TipoId { get; set; }

        public DateTime DataDeNascimento { get; set; }

        public virtual ICollection<RendaDto> Rendas { get; set; }
    }
}
