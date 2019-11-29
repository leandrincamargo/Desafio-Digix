using Ex.Business;
using Ex.DataContext;
using Ex.DataModel.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Ex.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliaController : ControllerBase
    {
        private readonly DesafioContext _desafioContext;
        private readonly FamiliaBusiness _familiaBusiness;

        public FamiliaController(DesafioContext desafioContext)
        {
            _desafioContext = desafioContext;
            _familiaBusiness = new FamiliaBusiness(_desafioContext);
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

            var resultado = _familiaBusiness.Adicionar(familia);

            if (!resultado.Success) return BadRequest(resultado);

            return Ok(resultado);
        }
    }
}
