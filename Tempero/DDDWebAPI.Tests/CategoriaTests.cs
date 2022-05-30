//using DDDWebAPI.Application.DTO.DTO;
//using DDDWebAPI.Application.Interfaces;
//using DDDWebAPI.Domain.Core.Interfaces.Repositorys;
//using DDDWebAPI.Domain.Models;
//using DDDWebAPI.Infrastructure.Data;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using System.Collections.Generic;
//using DDDWebAPI.Presentation.Controllers;

//namespace Teste_CategoriaLivre
//{
//    [TestClass]
//    public class CategoriaTests
//    {
//        #region Cadastros 
//        [TestMethod]
//        public void CadastroNovaCategoria()
//        {
//            // Arrange
//            CategoriaDTO categoria = new CategoriaDTO();
//            categoria.id = 1;

//            var mockRepo = new Mock<IApplicationServiceCategoria>();
//            var mockLog = new Mock<ILogger<CategoriasController>>();
//            var controller = new CategoriasController(mockRepo.Object, mockLog.Object);
//            var model = new CategoriaDTO { id = categoria.id };

//            // Act
//            ActionResult<CategoriaDTO> result = controller.Post(model);

//            // Assert
//            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
//        }
//        [TestMethod]
//        public void CadastroCategoriaDuplicada()
//        {
//            CategoriaDTO model = new CategoriaDTO();
//            model.id = 1;

//            var mockRepo = new Mock<IApplicationServiceCategoria>();
//            mockRepo.Setup(repo => repo.GetAll().(obj =>obj.id== 1)).Returns(model);

//            var mockLog = new Mock<ILogger<CategoriasController>>();

//            var controller = new CategoriasController(mockRepo.Object, mockLog.Object);

//            // Act
//            ActionResult<CategoriaDTO> result = controller.Post(model);

//            // Assert
//            Assert.IsInstanceOfType(result.Result, typeof(UnprocessableEntityObjectResult));
//        }
//        [TestMethod]
//        public void CadastroCategoriaNula()
//        {
//            CategoriaDTO model = null;

//            var mockRepo = new Mock<IApplicationServiceCategoria>();

//            var mockLog = new Mock<ILogger<CategoriasController>>();

//            var controller = new CategoriasController(mockRepo.Object, mockLog.Object);

//            // Act
//            ActionResult<CategoriaDTO> result = controller.Post(model);

//            // Assert
//            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
//        }
//        [TestMethod]
//        public void CadastroCategoriaSemRegistro()
//        {
//            CategoriaDTO model = new CategoriaDTO();

//            var mockRepo = new Mock<IApplicationServiceCategoria>();

//            var mockLog = new Mock<ILogger<CategoriasController>>();

//            var controller = new CategoriasController(mockRepo.Object, mockLog.Object);

//            // Act
//            ActionResult<CategoriaDTO> result = controller.Post(model);

//            // Assert
//            Assert.IsInstanceOfType(result.Result, typeof(UnprocessableEntityObjectResult));
//        }
//        #endregion

//        #region Busca
//        [TestMethod]
//        public void BuscaPorNome()
//        {
//            List<CategoriaDTO> model = new()
//            {
//                new CategoriaDTO() { id = "test", nome_categoria = "liberdade" },
//                new CategoriaDTO() { id = "test1", nome_categoria = "liberdade" },
//                new CategoriaDTO() { id = "test2", nome_categoria = "liberdade" },
//                new CategoriaDTO() { id = "test3", nome_categoria = "liberdade" },
//                new CategoriaDTO() { id = "test4", nome_categoria = "liberdade" },
//                new CategoriaDTO() { id = "test5", nome_categoria = "liberdade" },
//            };

//            var mockRepo = new Mock<IApplicationServiceCategoria>();
//            mockRepo.Setup(repo => repo.GetAllByNome("liberdade")).Returns(model);

//            var mockLog = new Mock<ILogger<CategoriasController>>();

//            var controller = new CategoriasController(mockRepo.Object, mockLog.Object);

//            // Act
//            ActionResult<IEnumerable<CategoriaDTO>> result = controller.GetNomeCategoria("liberdade");

//            // Assert
//            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
//        }
//        [TestMethod]
//        public void BuscaPorNomeVazio()
//        {
//            var mockRepo = new Mock<IApplicationServiceCategoria>();

//            var mockLog = new Mock<ILogger<CategoriasController>>();

//            var controller = new CategoriasController(mockRepo.Object, mockLog.Object);

//            // Act
//            ActionResult<IEnumerable<CategoriaDTO>> result = controller.GetNomeCategoria("");

//            // Assert
//            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
//        }
//        [TestMethod]
//        public void BuscaPorNomeNulo()
//        {
//            var mockRepo = new Mock<IApplicationServiceCategoria>();

//            var mockLog = new Mock<ILogger<CategoriasController>>();

//            var controller = new CategoriasController(mockRepo.Object, mockLog.Object);

//            // Act
//            ActionResult<IEnumerable<CategoriaDTO>> result = controller.GetNomeCategoria(null);

//            // Assert
//            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
//        }
//        [TestMethod]
//        public void BuscaPorNomeRetornaVazio()
//        {
//            var mockRepo = new Mock<IApplicationServiceCategoria>();

//            var mockLog = new Mock<ILogger<CategoriasController>>();

//            var controller = new CategoriasController(mockRepo.Object, mockLog.Object);
//            mockRepo.Setup(repo => repo.GetAllByNome("Mocoquinha")).Returns((IEnumerable<CategoriaDTO>)null);

//            // Act
//            ActionResult<IEnumerable<CategoriaDTO>> result = controller.GetNomeCategoria(null);

//            // Assert
//            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
//        }
//        #endregion

//        #region Deletar
//        [TestMethod]
//        public void DeletarCategoriaPorCodigoRegistroVazio()
//        {
//            string id = "";
//            var mockRepo = new Mock<IApplicationServiceCategoria>();

//            var mockLog = new Mock<ILogger<CategoriasController>>();

//            var controller = new CategoriasController(mockRepo.Object, mockLog.Object);

//            // Act
//            ActionResult<CategoriaDTO> result = controller.Delete(id);

//            // Assert
//            Assert.IsInstanceOfType(result.Result, typeof(BadRequestResult));

//        }
//        [TestMethod]
//        public void DeletarCategoriaPorCodigoRegistroNulo()
//        {
//            string id = null;
//            var mockRepo = new Mock<IApplicationServiceCategoria>();

//            var mockLog = new Mock<ILogger<CategoriasController>>();

//            var controller = new CategoriasController(mockRepo.Object, mockLog.Object);

//            // Act
//            ActionResult<CategoriaDTO> result = controller.Delete(id);

//            // Assert
//            Assert.IsInstanceOfType(result.Result, typeof(BadRequestResult));

//        }
//        [TestMethod]
//        public void DeletarCategoriaPorCodigoRegistro()
//        {
//            CategoriaDTO model = new CategoriaDTO() { id = "test" };
//            var mockRepo = new Mock<IApplicationServiceCategoria>();
//            mockRepo.Setup(repo => repo.GetByRegistro(model.id)).Returns(model);
//            var mockLog = new Mock<ILogger<CategoriasController>>();

//            var controller = new CategoriasController(mockRepo.Object, mockLog.Object);

//            // Act
//            ActionResult<CategoriaDTO> result = controller.Delete(model.id);

//            // Assert
//            Assert.IsInstanceOfType(result.Result, typeof(AcceptedResult));

//        }
//        [TestMethod]
//        public void DeletarCategoriaPorCodigoRegistroQueNaoExiste()
//        {
//            string id = "test";
//            var mockRepo = new Mock<IApplicationServiceCategoria>();
//            mockRepo.Setup(repo => repo.GetByRegistro(id)).Returns((CategoriaDTO)null);
//            var mockLog = new Mock<ILogger<CategoriasController>>();

//            var controller = new CategoriasController(mockRepo.Object, mockLog.Object);

//            // Act
//            ActionResult<CategoriaDTO> result = controller.Delete(id);

//            // Assert
//            Assert.IsInstanceOfType(result.Result, typeof(NoContentResult));

//        }
//        #endregion

//        #region Alteração
//        [TestMethod]
//        public void AtualizacaoCategoriaNaoExiste()
//        {
//            CategoriaDTO categoria = new CategoriaDTO() { id = "test" , id="id"};
//            var mockRepo = new Mock<IApplicationServiceCategoria>();
//            mockRepo.Setup(repo => repo.GetByRegistro(categoria.id)).Returns((CategoriaDTO)null);
//            var mockLog = new Mock<ILogger<CategoriasController>>();

//            var controller = new CategoriasController(mockRepo.Object, mockLog.Object);

//            // Act
//            ActionResult<CategoriaDTO> result = controller.Patch(categoria);

//            // Assert
//            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));

//        }
//        [TestMethod]
//        public void AtualizacaoCategoriaNula()
//        {
//            var mockRepo = new Mock<IApplicationServiceCategoria>();
//            var mockLog = new Mock<ILogger<CategoriasController>>();

//            var controller = new CategoriasController(mockRepo.Object, mockLog.Object);

//            // Act
//            ActionResult<CategoriaDTO> result = controller.Patch(null);

//            // Assert
//            Assert.IsInstanceOfType(result.Result, typeof(BadRequestResult));

//        }
//        [TestMethod]
//        public void AtualizacaoCategoria()
//        {
//            CategoriaDTO categoria = new CategoriaDTO() { id = "test", id = "id" };
//            var mockRepo = new Mock<IApplicationServiceCategoria>();
//            mockRepo.Setup(repo => repo.GetByRegistro(categoria.id)).Returns(categoria);
//            var mockLog = new Mock<ILogger<CategoriasController>>();

//            var controller = new CategoriasController(mockRepo.Object, mockLog.Object);

//            // Act
//            ActionResult<CategoriaDTO> result = controller.Patch(categoria);

//            // Assert
//            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
//        }
//        #endregion

//    }
//}