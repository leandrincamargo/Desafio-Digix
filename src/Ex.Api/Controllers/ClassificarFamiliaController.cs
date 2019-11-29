using Ex.Business;
using Ex.DataContext;
using Ex.DataModel.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using static Ex.DataModel.Model.Enumeradores;

namespace Ex.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClassificacaoFamiliaController : ControllerBase
    {
        private readonly DesafioContext _desafioContext;
        private readonly FamiliaBusiness _familiaBusiness;
        private readonly AvaliacaoFamiliarBusiness _avaliacaoFamiliarBusiness;

        public ClassificacaoFamiliaController(DesafioContext desafioContext)
        {
            _desafioContext = desafioContext;
            _familiaBusiness = new FamiliaBusiness(_desafioContext);
            _avaliacaoFamiliarBusiness = new AvaliacaoFamiliarBusiness(_desafioContext);
        }

        /// <summary>
        /// Obtém a classificação da familia seguindo as regras
        /// </summary>
        /// <param name="familiaId">Id da Familia a ser classificada</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{familiaId:int}")]
        public AvaliacaoFamiliarDto ObterClassificacaoFamiliar(int familiaId)
        {
            var familia = _familiaBusiness.ObterComPredicado(x => x.FamiliaId == familiaId).First();
            var avaliacaoFamiliarDto = _avaliacaoFamiliarBusiness.ClassificarFamilia(familia);

            return avaliacaoFamiliarDto;
        }

        /// <summary>
        /// Obtém a classificação da familias com cadastro válido
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public List<AvaliacaoFamiliarDto> ObterTodosClassificacaoFamiliar()
        {
            var familias = _familiaBusiness.ObterComPredicado(x => x.DominioIdStatus == (int)StatusFamilia.CadastroValido).ToList();

            var avaliacoesFamiliarDto = _avaliacaoFamiliarBusiness.ClassificarFamilias(familias);

            return avaliacoesFamiliarDto;
        }
    }
}
