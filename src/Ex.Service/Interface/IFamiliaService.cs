using Ex.DataModel.Model;
using Ex.DataModel.Model.Common;
using Ex.DataModel.Model.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Ex.Service.Interface
{
    public interface IFamiliaService
    {
        IQueryable<Familia> ObterTodos();
        Familia ObterFamilia(int familiaId);
        List<Familia> ObterTodosValidos();
        decimal ObterRendaFamiliar(Familia familia);
        Pessoa ObterPretendente(Familia familia);
        Resultado Adicionar(FamiliaDto familiaDto);
        int ObterQuantidadeDependentesMenoresDeIdade(Familia familia);
    }
}
