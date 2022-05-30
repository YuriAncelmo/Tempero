using Microsoft.AspNetCore.Mvc;
using DDDWebAPI.Application.Interfaces;
using DDDWebAPI.Application.DTO.DTO;
using Microsoft.AspNetCore.Diagnostics;

namespace DDDWebAPI.Presentation.Controllers
{
    [Route("categoria")]
    public class CategoriasController : Controller
    {
        private readonly ILogger<CategoriasController> _logger;

        private readonly IApplicationServiceCategoria _applicationServiceCategoria;
        public CategoriasController(IApplicationServiceCategoria ApplicationServiceCategoria, ILogger<CategoriasController> logger)
        {
            _applicationServiceCategoria = ApplicationServiceCategoria;
            _logger = logger;
        }

        #region Inserir
        /// <summary>
        /// Insere uma nova categoria
        /// </summary>
        /// <param name="model">CategoriaDTO a ser inserida</param>
        /// <returns>Se a categoria foi criada ou não</returns>
        /// <response code="200">Categoria criada</response>
        /// <response code="400">categoria nao enviada no body</response>
        /// <response code="422">categoria enviada com problemas, veja a mensagem de erro</response>
        /// <response code="500">erro desconhecido</response>
        [HttpPost]
        [Route("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoriaDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CategoriaDTO> Post([FromBody] CategoriaDTO model)
        {
            _logger.LogInformation("Validando se a entidade já existe");

            if (model == null)
                return BadRequest("Categoria inválida");
            if (model.nome == null)
                return UnprocessableEntity("É necessário ter um id para cadastrar");

            _logger.LogInformation("Tentando incluir uma categoria", model);
            _applicationServiceCategoria.Add(model);
            return Ok(model);
        }
        #endregion 

        #region Buscas
        /// <summary>
        /// Busca uma categoria pelo nome 
        /// </summary>
        /// <param name="nome_categoria">Nome da categoria que será utilizado para a busca</param>
        /// <returns>As categorias que foram encontradas com aquele nome </returns>
        /// <response code="200">Retorna as categorias encontradas</response>
        /// <response code="204">Nenhuma categoria foi encontrada</response>
        /// <response code="400">Requisição mal formada,verifique a mensagem de erro</response>
        /// <response code="500">Erro interno</response>
        [HttpGet]
        [Route("nome/{nome_categoria}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<CategoriaDTO>> GetCategoriaByNome([FromRoute] string nome_categoria)
        {
            if (nome_categoria == null || nome_categoria == "")
                return BadRequest("Informe um nome de categoria");

            IEnumerable<CategoriaDTO> categorias_por_nome;
            _logger.LogInformation("Tentando buscar uma categoria pelo nome da categoria " + nome_categoria);

            categorias_por_nome = _applicationServiceCategoria.GetAllByNome(nome_categoria);


            if (categorias_por_nome == null)
            {
                _logger.LogInformation("Nada encontrado");

                return NoContent();
            }
            else
            {
                _logger.LogInformation("Categorias retornadas " + categorias_por_nome.Count());
                return Ok(categorias_por_nome);
            }
        }/// <summary>
         /// Busca uma categoria pelo nome 
         /// </summary>
         /// <param name="id_categoria">id da categoria que será utilizado para a busca</param>
         /// <returns>As categorias que foram encontradas com aquele nome </returns>
         /// <response code="200">Retorna as categorias encontradas</response>
         /// <response code="204">Nenhuma categoria foi encontrada</response>
         /// <response code="400">Requisição mal formada,verifique a mensagem de erro</response>
         /// <response code="500">Erro interno</response>
        [HttpGet]
        [Route("id/{id_categoria}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CategoriaDTO> GetCategoriaById([FromRoute] int id_categoria)
        {
            if (id_categoria == null || id_categoria == 0)
                return BadRequest("Informe um id de categoria");

            CategoriaDTO categoria;
            _logger.LogInformation("Tentando buscar uma categoria pelo id " + id_categoria);

            categoria = _applicationServiceCategoria.GetById(id_categoria);


            if (categoria == null)
            {
                _logger.LogInformation("Nada encontrado");

                return NoContent();
            }
            else
            {
                _logger.LogInformation("Categoria retornada: " + categoria.nome);
                return Ok(categoria);
            }
        }
        #endregion

        #region Alteração
        /// <summary>
        /// Atualiza uma categoria pelo codigo de id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PATCH categoria/
        ///     {
        ///       "id": "4044-3",
        ///       "id": "1233123",
        ///       "longitude": "-12312399",
        ///       "latitude": "-12312399",
        ///       "setcens": "cadacal",
        ///       "areap": "vila santa rosa",
        ///       "coddist": "123",
        ///       "distrito": "Mococa",
        ///       "codsubpref": "pref",
        ///       "subprefe": "taboao",
        ///       "regiao5": "1233",
        ///       "regiao8": "12334",
        ///       "nome_categoria": "Santa Rosa",
        ///       "logradouro": "Fundo",
        ///       "numero": "432",
        ///       "bairro": "Santa rosa",
        ///       "referencia": "Casa azul"
        ///     }
        /// </remarks>
        /// <param name="model">categoria que será atualizada</param>
        /// <returns>As categorias que foram encontradas com aquele nome </returns>
        /// <response code="200">Retorna que a categoria foi alterada</response>
        /// <response code="400">Requisição mal formada</response>
        /// <response code="404">Nenhuma categoria foi encontrada</response>
        /// <response code="500">Erro interno</response>
        [HttpPatch]
        [Route("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Patch([FromBody] CategoriaDTO model)
        {
            if (model == null)
                return BadRequest();
            CategoriaDTO categoria = _applicationServiceCategoria.GetAll().Where(o => o.id == model.id).First();
            if (categoria == null)
            {
                _logger.LogInformation("CategoriaDTO não existe, por isto não foi alterada.");

                return NotFound();
            }

            _logger.LogInformation("Tentando alterar a categoria com código de id " + model.id);

            _applicationServiceCategoria.Update(model);

            _logger.LogInformation("CategoriaDTO com código de id " + model.id + " alterada.");
            return Ok(model);
        }
        #endregion

        #region Remover
        /// <summary>
        /// Remove uma categoria pelo codigo de id
        /// </summary>
        /// <param name="id">código de id da categoria que será removida</param>
        /// <returns>Se foi deletado</returns>
        /// <response code="202">Ok</response>
        /// <response code="204">Nenhuma categoria foi encontrada</response>
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

            _logger.LogInformation("Tentando deletar a categoria com código de id " + id);
            CategoriaDTO obj = _applicationServiceCategoria.GetAll().Where(o => o.id == id).First();
            if (obj != null)
            {
                _logger.LogInformation("A categoria existe");

                _applicationServiceCategoria.Remove(obj);
                _logger.LogInformation("A categoria foi deletada");

                return Accepted();
            }
            else
            {
                _logger.LogInformation("A categoria não existe");

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
            _applicationServiceCategoria.Dispose();
            base.Dispose(disposing);
        }
    }
}
