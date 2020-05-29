using Ex.DataModel.Model;
using Ex.DataModel.Model.Dto;
using System.Collections.Generic;

namespace Ex.Service.Interface
{
    public interface IAvalicaoFamiliarService
    {
        List<AvaliacaoFamiliarDto> ClassificarFamilias();
        AvaliacaoFamiliarDto ClassificarFamiliaPorId(int familiaId);
    }
}
