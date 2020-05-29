using Ex.DataModel.Model.Dto;
using Ex.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Ex.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliaController : ControllerBase
    {
        private readonly IFamiliaService _familiaService;

        public FamiliaController(IFamiliaService familiaService)
        {
            _familiaService = familiaService;
        }

        /// <summary>
        /// Obtém a classificação da familia seguindo as regras
        /// </summary>
        /// <param name="familia"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public ActionResult Adicionar(FamiliaDto familia)
        {
            if (!ModelState.IsValid) return BadRequest();

            var resultado = _familiaService.Adicionar(familia);

            if (!resultado.Success) return BadRequest(resultado);

            return Ok(resultado);
        }
    }
}
