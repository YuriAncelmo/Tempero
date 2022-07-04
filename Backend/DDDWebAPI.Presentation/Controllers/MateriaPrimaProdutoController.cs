using Microsoft.AspNetCore.Mvc;
using DDDWebAPI.Application.Interfaces;
using DDDWebAPI.Application.DTO.DTO;
using Microsoft.AspNetCore.Diagnostics;

namespace DDDWebAPI.Presentation.Controllers
{
    [Route("materia_prima_produto")]
    public class MateriasPrimaProdutoController : Controller
    {
        private readonly ILogger<MateriasPrimaProdutoController> _logger;

        private readonly IApplicationServiceMateriaPrimaProduto _applicationServiceMateriaPrimaProduto;
        public MateriasPrimaProdutoController(IApplicationServiceMateriaPrimaProduto ApplicationServiceMateriaPrimaProduto, ILogger<MateriasPrimaProdutoController> logger)
        {
            _applicationServiceMateriaPrimaProduto = ApplicationServiceMateriaPrimaProduto;
            _logger = logger;
        }

        #region Inserir
        /// <summary>
        /// Insere uma nova materia prima produto
        /// </summary>
        /// <param name="model">MateriaPrima_ProdutoDTO a ser inserido</param>
        /// <returns>Se a materia prima produto foi criado ou não</returns>
        /// <response code="200">MateriaPrimaProduto criado</response>
        /// <response code="400">materia prima produto nao enviado no body</response>
        /// <response code="422">materia prima produto enviado com problemas, veja a mensagem de erro</response>
        /// <response code="500">erro desconhecido</response>
        [HttpPost]
        [Route("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MateriaPrima_ProdutoDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Post([FromBody] MateriaPrima_ProdutoDTO model)
        {
            _logger.LogInformation("Validando se a entidade já existe");

            if (model == null || !ModelState.IsValid)
                //Vericar como retornar a mensagem que está dentro do modelo
                return BadRequest("MateriaPrimaProduto inválido");
            if (model.quantidade == 0)
                return UnprocessableEntity("É necessário ter quantidade para fazer o cadastro ");

            _logger.LogInformation("Tentando incluir uma materia prima produto", model);
            _applicationServiceMateriaPrimaProduto.Add(model);
            return Ok();
        }
        #endregion 

        #region Buscas
        /// <summary>
         /// Busca uma materia prima produto pelo nome 
         /// </summary>
         /// <param name="id_materia_prima_produto">id do materia prima produto que será utilizado para a busca</param>
         /// <returns>Os materia prima produtos que foram encontrados com aquele nome </returns>
         /// <response code="200">Retorna os materia prima produtos encontrados</response>
         /// <response code="204">Nenhum materia prima produto foi encontrado</response>
         /// <response code="400">Requisição mal formado,verifique a mensagem de erro</response>
         /// <response code="500">Erro interno</response>
        [HttpGet]
        [Route("id/{id_materia_prima_produto}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<MateriaPrima_ProdutoDTO> GetMateriaPrimaProdutoById([FromRoute] int id_materia_prima_produto)
        {
            if (id_materia_prima_produto == null || id_materia_prima_produto == 0)
                return BadRequest("Informe um id de materia prima produto");

            MateriaPrima_ProdutoDTO materia_prima;
            _logger.LogInformation("Tentando buscar uma materia prima produto pelo id " + id_materia_prima_produto);

            materia_prima = _applicationServiceMateriaPrimaProduto.GetById(id_materia_prima_produto);

            if (materia_prima == null)
            {
                _logger.LogInformation("Nada encontrado");

                return NoContent();
            }
            else
            {
                _logger.LogInformation("MateriaPrimaProduto retornado: " + materia_prima.id);
                return Ok(materia_prima);
            }
        }
        #endregion

        #region Alteração
        /// <summary>
        /// Atualiza uma materia prima produto pelo codigo de id
        /// </summary>
        /// <param name="model">materia prima produto que será atualizada</param>
        /// <returns>Os materia prima produtos que foram encontrados com aquele nome </returns>
        /// <response code="200">Retorna que a materia prima produto foi alterada</response>
        /// <response code="400">Requisição mal formada</response>
        /// <response code="404">Nenhum materia prima produto foi encontrada</response>
        /// <response code="500">Erro interno</response>
        [HttpPatch]
        [Route("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Patch([FromBody] MateriaPrima_ProdutoDTO model)
        {
            if (model == null)
                return BadRequest();
            MateriaPrima_ProdutoDTO materia_prima = _applicationServiceMateriaPrimaProduto.GetAll().Where(o => o.id == model.id).First();
            if (materia_prima == null)
            {
                _logger.LogInformation("MateriaPrima_ProdutoDTO não existe, por isto não foi alterada.");

                return NotFound();
            }

            _logger.LogInformation("Tentando alterar a materia prima produto com código de id " + model.id);

            _applicationServiceMateriaPrimaProduto.Update(model);

            _logger.LogInformation("MateriaPrima_ProdutoDTO com código de id " + model.id + " alterada.");
            return Ok(model);
        }
        #endregion

        #region Remover
        /// <summary>
        /// Remove uma materia prima produto pelo codigo de id
        /// </summary>
        /// <param name="id">código de id da materia prima produto que será removida</param>
        /// <returns>Se foi deletado</returns>
        /// <response code="202">Ok</response>
        /// <response code="204">Nenhum materia prima produto foi encontrada</response>
        /// <response code="400">Requisição mal formada</response>
        /// <response code="500">Erro interno</response>
        [HttpDelete]
        [Route("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete([FromRoute] int id)
        {
            if (id == null)
                return BadRequest();

            _logger.LogInformation("Tentando deletar a materia prima produto com código de id " + id);
            MateriaPrima_ProdutoDTO obj = _applicationServiceMateriaPrimaProduto.GetAll().Where(o => o.id == id).First();
            if (obj != null)
            {
                _logger.LogInformation("A materia prima produto existe");

                _applicationServiceMateriaPrimaProduto.Remove(obj);
                _logger.LogInformation("A materia prima produto foi deletada");

                return Accepted();
            }
            else
            {
                _logger.LogInformation("A materia prima produto não existe");

                return NoContent();
            }
        }
        #endregion

        #region Error 
        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult HandleError()
        {
            var exceptionHandlerFeature =
                HttpContext.Features.Get<IExceptionHandlerFeature>()!;
            _logger.LogInformation("Ocorreu algum erro");

            return Problem(
                detail: exceptionHandlerFeature.Error.InnerException.ToString(),

                title: exceptionHandlerFeature.Error.Message
                );

        }
        #endregion
        protected override void Dispose(bool disposing)
        {
            _applicationServiceMateriaPrimaProduto.Dispose();
            base.Dispose(disposing);
        }
    }
}
