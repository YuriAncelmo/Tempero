using DDDWebAPI.Application.DTO.DTO;
using DDDWebAPI.Application.Interfaces;
using DDDWebAPI.Domain.Core.Interfaces.Services;
using DDDWebAPI.Infrastruture.CrossCutting.Adapter.Interfaces;

namespace DDDWebAPI.Application.Services
{

    public class ApplicationServiceProduto : IApplicationServiceProduto
    {
        private readonly IServiceProduto _serviceProduto;
        private readonly IMapperProduto _mapperProduto;

        public ApplicationServiceProduto(IServiceProduto ServiceProduto
                                                 , IMapperProduto MapperProduto)

        {
            _serviceProduto = ServiceProduto;
            _mapperProduto = MapperProduto;
        }


        public void Add(ProdutoDTO obj)
        {
            var objProduto = _mapperProduto.MapperToEntity(obj);
            _serviceProduto.Add(objProduto);
        }

        public void Dispose()
        {
            _serviceProduto.Dispose();
        }

        public IEnumerable<ProdutoDTO> GetAll()
        {
            var objProdutos = _serviceProduto.GetAll();
            return _mapperProduto.MapperListProdutosDTO(objProdutos);
        }
        public ProdutoDTO GetById(int id)
        {
            var objProdutos = _serviceProduto.GetById(id);
            return _mapperProduto.MapperToDTO(objProdutos);
        }
        public IEnumerable<ProdutoDTO> GetAllByNome(string nome)
        {
            var objProduto = _serviceProduto.GetAllByNome(nome);
            return _mapperProduto.MapperListProdutosDTO(objProduto);
        }

        public void Remove(ProdutoDTO obj)
        {
            var objProduto = _mapperProduto.MapperToEntity(obj);
            _serviceProduto.Remove(objProduto);
        }

        public void Update(ProdutoDTO obj)
        {
            var objProduto = _mapperProduto.MapperToEntity(obj);
            _serviceProduto.Update(objProduto);
        }
    }
}
