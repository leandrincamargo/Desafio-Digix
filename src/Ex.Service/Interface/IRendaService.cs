using Ex.DataModel.Model;
using Ex.DataModel.Model.Dto;

namespace Ex.Service.Interface
{
    public interface IRendaService
    {
        Renda Converter(RendaDto rendaDto, int pessoaId);
    }
}
