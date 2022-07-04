using DDDWebAPI.Application.DTO.DTO;
using DDDWebAPI.Application.Interfaces;
using DDDWebAPI.Domain.Core.Interfaces.Services;
using DDDWebAPI.Infrastruture.CrossCutting.Adapter.Interfaces;

namespace DDDWebAPI.Application.Services
{

    public class ApplicationServiceMateriaPrimaProduto : IApplicationServiceMateriaPrimaProduto
    {
        private readonly IServiceMateriaPrimaProduto _serviceMateriaPrimaProduto;
        private readonly IMapperMateriaPrimaProduto _mapperMateriaPrimaProduto;

        public ApplicationServiceMateriaPrimaProduto(IServiceMateriaPrimaProduto ServiceMateriaPrimaProduto
                                                 , IMapperMateriaPrimaProduto MapperMateriaPrimaProduto)

        {
            _serviceMateriaPrimaProduto = ServiceMateriaPrimaProduto;
            _mapperMateriaPrimaProduto = MapperMateriaPrimaProduto;
        }


        public void Add(MateriaPrima_ProdutoDTO obj)
        {
            var objMateriaPrimaProduto = _mapperMateriaPrimaProduto.MapperToEntity(obj);
            _serviceMateriaPrimaProduto.Add(objMateriaPrimaProduto);
        }

        public void Dispose()
        {
            _serviceMateriaPrimaProduto.Dispose();
        }

        public IEnumerable<MateriaPrima_ProdutoDTO> GetAll()
        {
            var objMateriaPrimaProdutos = _serviceMateriaPrimaProduto.GetAll();
            return _mapperMateriaPrimaProduto.MapperListMateriaPrima_ProdutoDTO(objMateriaPrimaProdutos);
        }
        public MateriaPrima_ProdutoDTO GetById(int id)
        {
            var objMateriaPrimaProdutos = _serviceMateriaPrimaProduto.GetById(id);
            return _mapperMateriaPrimaProduto.MapperToDTO(objMateriaPrimaProdutos);
        }
       
        public void Remove(MateriaPrima_ProdutoDTO obj)
        {
            var objMateriaPrimaProduto = _mapperMateriaPrimaProduto.MapperToEntity(obj);
            _serviceMateriaPrimaProduto.Remove(objMateriaPrimaProduto);
        }

        public void Update(MateriaPrima_ProdutoDTO obj)
        {
            var objMateriaPrimaProduto = _mapperMateriaPrimaProduto.MapperToEntity(obj);
            _serviceMateriaPrimaProduto.Update(objMateriaPrimaProduto);
        }
    }
}
