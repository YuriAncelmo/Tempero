using Microsoft.AspNetCore.Mvc;
using DDDWebAPI.Application.Interfaces;
using DDDWebAPI.Application.DTO.DTO;
using Microsoft.AspNetCore.Diagnostics;

namespace DDDWebAPI.Presentation.Controllers
{
    [Route("materia_prima")]
    public class MateriasPrimaController : Controller
    {
        private readonly ILogger<MateriasPrimaController> _logger;

        private readonly IApplicationServiceMateriaPrima _applicationServiceMateriaPrima;
        public MateriasPrimaController(IApplicationServiceMateriaPrima ApplicationServiceMateriaPrima, ILogger<MateriasPrimaController> logger)
        {
            _applicationServiceMateriaPrima = ApplicationServiceMateriaPrima;
            _logger = logger;
        }

        #region Inserir
        /// <summary>
        /// Insere uma nova materia prima
        /// </summary>
        /// <param name="model">MateriaPrimaDTO a ser inserido</param>
        /// <returns>Se a materia prima foi criado ou não</returns>
        /// <response code="200">MateriaPrima criado</response>
        /// <response code="400">materia prima nao enviado no body</response>
        /// <response code="422">materia prima enviado com problemas, veja a mensagem de erro</response>
        /// <response code="500">erro desconhecido</response>
        [HttpPost]
        [Route("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MateriaPrimaDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<MateriaPrimaDTO> Post([FromBody] MateriaPrimaDTO model)
        {
            _logger.LogInformation("Validando se a entidade já existe");

            if (model == null || !ModelState.IsValid)
                //Vericar como retornar a mensagem que está dentro do modelo
                return BadRequest("MateriaPrima inválido");
            if (model.nome == null)
                return UnprocessableEntity("É necessário ter um nome para cadastrar");

            _logger.LogInformation("Tentando incluir uma materia prima", model);
            _applicationServiceMateriaPrima.Add(model);
            return Ok();
        }
        #endregion 

        #region Buscas
        /// <summary>
        /// Busca uma materia prima pelo nome 
        /// </summary>
        /// <param name="nome_materia_prima">Nome do materia prima que será utilizado para a busca</param>
        /// <returns>Os materia primas que foram encontrados com aquele nome </returns>
        /// <response code="200">Retorna os materia primas encontrados</response>
        /// <response code="204">Nenhuma materia prima foi encontrado</response>
        /// <response code="400">Requisição mal formada,verifique a mensagem de erro</response>
        /// <response code="500">Erro interno</response>
        [HttpGet]
        [Route("nome/{nome_materia_prima}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<MateriaPrimaDTO>> GetMateriaPrimaByNome([FromRoute] string nome_materia_prima)
        {
            if (nome_materia_prima == null || nome_materia_prima == "")
                return BadRequest("Informe uma nome de materia prima");

            IEnumerable<MateriaPrimaDTO> materia_primas_por_nome;
            _logger.LogInformation("Tentando buscar uma materia prima pelo nome do materia prima " + nome_materia_prima);

            materia_primas_por_nome = _applicationServiceMateriaPrima.GetAllByNome(nome_materia_prima);


            if (materia_primas_por_nome == null)
            {
                _logger.LogInformation("Nada encontrado");

                return NoContent();
            }
            else
            {
                _logger.LogInformation("MateriasPrima retornados " + materia_primas_por_nome.Count());
                return Ok(materia_primas_por_nome);
            }
        }/// <summary>
         /// Busca uma materia prima pelo nome 
         /// </summary>
         /// <param name="id_materia_prima">id do materia prima que será utilizado para a busca</param>
         /// <returns>Os materia primas que foram encontrados com aquele nome </returns>
         /// <response code="200">Retorna os materia primas encontrados</response>
         /// <response code="204">Nenhum materia prima foi encontrado</response>
         /// <response code="400">Requisição mal formado,verifique a mensagem de erro</response>
         /// <response code="500">Erro interno</response>
        [HttpGet]
        [Route("id/{id_materia_prima}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<MateriaPrimaDTO> GetMateriaPrimaById([FromRoute] int id_materia_prima)
        {
            if (id_materia_prima == null || id_materia_prima == 0)
                return BadRequest("Informe um id de materia prima");

            MateriaPrimaDTO materia_prima;
            _logger.LogInformation("Tentando buscar uma materia prima pelo id " + id_materia_prima);

            materia_prima = _applicationServiceMateriaPrima.GetById(id_materia_prima);

            if (materia_prima == null)
            {
                _logger.LogInformation("Nada encontrado");

                return NoContent();
            }
            else
            {
                _logger.LogInformation("MateriaPrima retornado: " + materia_prima.nome);
                return Ok(materia_prima);
            }
        }
        #endregion

        #region Alteração
        /// <summary>
        /// Atualiza uma materia prima pelo codigo de id
        /// </summary>
        /// <param name="model">materia prima que será atualizada</param>
        /// <returns>Os materia primas que foram encontrados com aquele nome </returns>
        /// <response code="200">Retorna que a materia prima foi alterada</response>
        /// <response code="400">Requisição mal formada</response>
        /// <response code="404">Nenhum materia prima foi encontrada</response>
        /// <response code="500">Erro interno</response>
        [HttpPatch]
        [Route("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Patch([FromBody] MateriaPrimaDTO model)
        {
            if (model == null)
                return BadRequest();
            MateriaPrimaDTO materia_prima = _applicationServiceMateriaPrima.GetAll().Where(o => o.id == model.id).First();
            if (materia_prima == null)
            {
                _logger.LogInformation("MateriaPrimaDTO não existe, por isto não foi alterada.");

                return NotFound();
            }

            _logger.LogInformation("Tentando alterar a materia prima com código de id " + model.id);

            _applicationServiceMateriaPrima.Update(model);

            _logger.LogInformation("MateriaPrimaDTO com código de id " + model.id + " alterada.");
            return Ok(model);
        }
        #endregion

        #region Remover
        /// <summary>
        /// Remove uma materia prima pelo codigo de id
        /// </summary>
        /// <param name="id">código de id da materia prima que será removida</param>
        /// <returns>Se foi deletado</returns>
        /// <response code="202">Ok</response>
        /// <response code="204">Nenhum materia prima foi encontrada</response>
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

            _logger.LogInformation("Tentando deletar a materia prima com código de id " + id);
            MateriaPrimaDTO obj = _applicationServiceMateriaPrima.GetAll().Where(o => o.id == id).First();
            if (obj != null)
            {
                _logger.LogInformation("A materia prima existe");

                _applicationServiceMateriaPrima.Remove(obj);
                _logger.LogInformation("A materia prima foi deletada");

                return Accepted();
            }
            else
            {
                _logger.LogInformation("A materia prima não existe");

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
            _applicationServiceMateriaPrima.Dispose();
            base.Dispose(disposing);
        }
    }
}
