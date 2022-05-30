
using Autofac;
using DDDWebAPI.Application.Interfaces;
using DDDWebAPI.Application.Services;
using DDDWebAPI.Domain.Core.Interfaces.Repositorys;
using DDDWebAPI.Domain.Core.Interfaces.Services;
using DDDWebAPI.Domain.Services.Services;
using DDDWebAPI.Infrastruture.CrossCutting.Adapter.Interfaces;
using DDDWebAPI.Infrastruture.CrossCutting.Adapter.Map;
using DDDWebAPI.Infrastruture.Repository.Repositorys;

namespace DDDWebAPI.Infrastruture.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region Registra IOC

            #region IOC Application
            builder.RegisterType<ApplicationServiceFeira>().As<IApplicationServiceFeira>();
            builder.RegisterType<ApplicationServiceCategoria>().As<IApplicationServiceCategoria>();
            #endregion

            #region IOC Services
            builder.RegisterType<ServiceFeira>().As<IServiceFeira>();
            builder.RegisterType<ServiceCategoria>().As<IServiceCategoria>();
            #endregion

            #region IOC Repositorys MySQL
            builder.RegisterType<RepositoryFeira>().As<IRepositoryFeira>();
            builder.RegisterType<RepositoryCategoria>().As<IRepositoryCategoria>();
            #endregion

            #region IOC Mapper
            builder.RegisterType<MapperFeira>().As<IMapperFeira>();
            builder.RegisterType<MapperCategoria>().As<IMapperCategoria>();
            #endregion

            #endregion

        }
    }
}
