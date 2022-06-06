using Microsoft.AspNetCore.Mvc;
using DDDWebAPI.Application.Interfaces;
using DDDWebAPI.Application.DTO.DTO;
using Microsoft.AspNetCore.Diagnostics;

namespace DDDWebAPI.Presentation.Controllers
{
    [Route("produto")]
    public class ProdutosController : Controller
    {
        private readonly ILogger<ProdutosController> _logger;

        private readonly IApplicationServiceProduto _applicationServiceProduto;
        public ProdutosController(IApplicationServiceProduto ApplicationServiceProduto, ILogger<ProdutosController> logger)
        {
            _applicationServiceProduto = ApplicationServiceProduto;
            _logger = logger;
        }

        #region Inserir
        /// <summary>
        /// Insere um nova produto
        /// </summary>
        /// <param name="model">ProdutoDTO a ser inserido</param>
        /// <returns>Se a produto foi criado ou não</returns>
        /// <response code="200">Produto criado</response>
        /// <response code="400">produto nao enviado no body</response>
        /// <response code="422">produto enviado com problemas, veja a mensagem de erro</response>
        /// <response code="500">erro desconhecido</response>
        [HttpPost]
        [Route("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProdutoDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ProdutoDTO> Post([FromBody] ProdutoDTO model)
        {
            _logger.LogInformation("Validando se a entidade já existe");

            if (model == null || !ModelState.IsValid)
                //Vericar como retornar a mensagem que está dentro do modelo
                return BadRequest("Produto inválido");
            if (model.nome == null)
                return UnprocessableEntity("É necessário ter um nome para cadastrar");

            _logger.LogInformation("Tentando incluir um produto", model);
            _applicationServiceProduto.Add(model);
            return Ok();
        }
        #endregion 

        #region Buscas
        /// <summary>
        /// Busca um produto pelo nome 
        /// </summary>
        /// <param name="nome_produto">Nome do produto que será utilizado para a busca</param>
        /// <returns>Os produtos que foram encontrados com aquele nome </returns>
        /// <response code="200">Retorna os produtos encontrados</response>
        /// <response code="204">Nenhum produto foi encontrado</response>
        /// <response code="400">Requisição mal formada,verifique a mensagem de erro</response>
        /// <response code="500">Erro interno</response>
        [HttpGet]
        [Route("nome/{nome_produto}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<ProdutoDTO>> GetProdutoByNome([FromRoute] string nome_produto)
        {
            if (nome_produto == null || nome_produto == "")
                return BadRequest("Informe um nome de produto");

            IEnumerable<ProdutoDTO> produtos_por_nome;
            _logger.LogInformation("Tentando buscar um produto pelo nome do produto " + nome_produto);

            produtos_por_nome = _applicationServiceProduto.GetAllByNome(nome_produto);


            if (produtos_por_nome == null)
            {
                _logger.LogInformation("Nada encontrado");

                return NoContent();
            }
            else
            {
                _logger.LogInformation("Produtos retornados " + produtos_por_nome.Count());
                return Ok(produtos_por_nome);
            }
        }/// <summary>
         /// Busca um produto pelo nome 
         /// </summary>
         /// <param name="id_produto">id do produto que será utilizado para a busca</param>
         /// <returns>Os produtos que foram encontrados com aquele nome </returns>
         /// <response code="200">Retorna os produtos encontrados</response>
         /// <response code="204">Nenhum produto foi encontrado</response>
         /// <response code="400">Requisição mal formado,verifique a mensagem de erro</response>
         /// <response code="500">Erro interno</response>
        [HttpGet]
        [Route("id/{id_produto}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ProdutoDTO> GetProdutoById([FromRoute] int id_produto)
        {
            if (id_produto == null || id_produto == 0)
                return BadRequest("Informe um id de produto");

            ProdutoDTO produto;
            _logger.LogInformation("Tentando buscar um produto pelo id " + id_produto);

            produto = _applicationServiceProduto.GetById(id_produto);

            if (produto == null)
            {
                _logger.LogInformation("Nada encontrado");

                return NoContent();
            }
            else
            {
                _logger.LogInformation("Produto retornado: " + produto.nome);
                return Ok(produto);
            }
        }
        #endregion

        #region Alteração
        /// <summary>
        /// Atualiza um produto pelo codigo de id
        /// </summary>
        /// <param name="model">produto que será atualizada</param>
        /// <returns>Os produtos que foram encontrados com aquele nome </returns>
        /// <response code="200">Retorna que a produto foi alterada</response>
        /// <response code="400">Requisição mal formada</response>
        /// <response code="404">Nenhum produto foi encontrada</response>
        /// <response code="500">Erro interno</response>
        [HttpPatch]
        [Route("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Patch([FromBody] ProdutoDTO model)
        {
            if (model == null)
                return BadRequest();
            ProdutoDTO produto = _applicationServiceProduto.GetAll().Where(o => o.id == model.id).First();
            if (produto == null)
            {
                _logger.LogInformation("ProdutoDTO não existe, por isto não foi alterada.");

                return NotFound();
            }

            _logger.LogInformation("Tentando alterar a produto com código de id " + model.id);

            _applicationServiceProduto.Update(model);

            _logger.LogInformation("ProdutoDTO com código de id " + model.id + " alterada.");
            return Ok(model);
        }
        #endregion

        #region Remover
        /// <summary>
        /// Remove um produto pelo codigo de id
        /// </summary>
        /// <param name="id">código de id da produto que será removida</param>
        /// <returns>Se foi deletado</returns>
        /// <response code="202">Ok</response>
        /// <response code="204">Nenhum produto foi encontrada</response>
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

            _logger.LogInformation("Tentando deletar a produto com código de id " + id);
            ProdutoDTO obj = _applicationServiceProduto.GetAll().Where(o => o.id == id).First();
            if (obj != null)
            {
                _logger.LogInformation("A produto existe");

                _applicationServiceProduto.Remove(obj);
                _logger.LogInformation("A produto foi deletada");

                return Accepted();
            }
            else
            {
                _logger.LogInformation("A produto não existe");

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
            _applicationServiceProduto.Dispose();
            base.Dispose(disposing);
        }
    }
}
