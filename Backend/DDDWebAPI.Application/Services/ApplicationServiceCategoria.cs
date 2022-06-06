using DDDWebAPI.Application.DTO.DTO;
using DDDWebAPI.Application.Interfaces;
using DDDWebAPI.Domain.Core.Interfaces.Services;
using DDDWebAPI.Infrastruture.CrossCutting.Adapter.Interfaces;

namespace DDDWebAPI.Application.Services
{

    public class ApplicationServiceCategoria : IApplicationServiceCategoria
    {
        private readonly IServiceCategoria _serviceCategoria;
        private readonly IMapperCategoria _mapperCategoria;

        public ApplicationServiceCategoria(IServiceCategoria ServiceCategoria
                                                 , IMapperCategoria MapperCategoria)

        {
            _serviceCategoria = ServiceCategoria;
            _mapperCategoria = MapperCategoria;
        }


        public void Add(CategoriaDTO obj)
        {
            var objCategoria = _mapperCategoria.MapperToEntity(obj);
            _serviceCategoria.Add(objCategoria);
        }

        public void Dispose()
        {
            _serviceCategoria.Dispose();
        }

        public IEnumerable<CategoriaDTO> GetAll()
        {
            var objProdutos = _serviceCategoria.GetAll();
            return _mapperCategoria.MapperListCategorias(objProdutos);
        }
        public IEnumerable<CategoriaDTO> GetAllByNome(string nome)
        {
            var objCategoria = _serviceCategoria.GetAllByNome(nome);
            return _mapperCategoria.MapperListCategorias(objCategoria);
        }

        public CategoriaDTO GetById(int id)
        {
            var objCategoria = _serviceCategoria.GetById(id);
            return _mapperCategoria.MapperToDTO(objCategoria);
        }

        public void Remove(CategoriaDTO obj)
        {
            var objCategoria = _mapperCategoria.MapperToEntity(obj);
            _serviceCategoria.Remove(objCategoria);
        }

        public void Update(CategoriaDTO obj)
        {
            var objCategoria = _mapperCategoria.MapperToEntity(obj);
            _serviceCategoria.Update(objCategoria);
        }
    }
}
