using DDDWebAPI.Application.DTO.DTO;
using DDDWebAPI.Application.Interfaces;
using DDDWebAPI.Domain.Core.Interfaces.Services;
using DDDWebAPI.Infrastruture.CrossCutting.Adapter.Interfaces;

namespace DDDWebAPI.Application.Services
{

    public class ApplicationServiceMateriaPrima : IApplicationServiceMateriaPrima
    {
        private readonly IServiceMateriaPrima _serviceMateriaPrima;
        private readonly IMapperMateriaPrima _mapperMateriaPrima;

        public ApplicationServiceMateriaPrima(IServiceMateriaPrima ServiceMateriaPrima
                                                 , IMapperMateriaPrima MapperMateriaPrima)

        {
            _serviceMateriaPrima = ServiceMateriaPrima;
            _mapperMateriaPrima = MapperMateriaPrima;
        }


        public void Add(MateriaPrimaDTO obj)
        {
            var objMateriaPrima = _mapperMateriaPrima.MapperToEntity(obj);
            _serviceMateriaPrima.Add(objMateriaPrima);
        }

        public void Dispose()
        {
            _serviceMateriaPrima.Dispose();
        }

        public IEnumerable<MateriaPrimaDTO> GetAll()
        {
            var objMateriaPrimas = _serviceMateriaPrima.GetAll();
            return _mapperMateriaPrima.MapperListMateriaPrimaDTO(objMateriaPrimas);
        }
        public MateriaPrimaDTO GetById(int id)
        {
            var objMateriaPrimas = _serviceMateriaPrima.GetById(id);
            return _mapperMateriaPrima.MapperToDTO(objMateriaPrimas);
        }
        public IEnumerable<MateriaPrimaDTO> GetAllByNome(string nome)
        {
            var objMateriaPrima = _serviceMateriaPrima.GetAllByNome(nome);
            return _mapperMateriaPrima.MapperListMateriaPrimaDTO(objMateriaPrima);
        }

        public void Remove(MateriaPrimaDTO obj)
        {
            var objMateriaPrima = _mapperMateriaPrima.MapperToEntity(obj);
            _serviceMateriaPrima.Remove(objMateriaPrima);
        }

        public void Update(MateriaPrimaDTO obj)
        {
            var objMateriaPrima = _mapperMateriaPrima.MapperToEntity(obj);
            _serviceMateriaPrima.Update(objMateriaPrima);
        }
    }
}
