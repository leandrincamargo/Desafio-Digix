using System.Collections.Generic;

namespace Ex.DataModel.Model.Dto
{
    public class FamiliaDto
    {
        public virtual ICollection<PessoaDto> Pessoas { get; set; }
    }
}
