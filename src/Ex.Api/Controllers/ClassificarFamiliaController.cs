using Ex.DataModel.Model.Dto;
using Ex.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Ex.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClassificacaoFamiliaController : ControllerBase
    {
        private readonly IAvalicaoFamiliarService _avaliacaoFamiliarService;

        public ClassificacaoFamiliaController(IAvalicaoFamiliarService avaliacaoFamiliarService)
        {
            _avaliacaoFamiliarService = avaliacaoFamiliarService;
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
            var avaliacaoFamiliarDto = _avaliacaoFamiliarService.ClassificarFamiliaPorId(familiaId);

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
            var avaliacoesFamiliarDto = _avaliacaoFamiliarService.ClassificarFamilias();

            return avaliacoesFamiliarDto;
        }
    }
}
