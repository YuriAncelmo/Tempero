﻿using DDDWebAPI.Domain.Models;
namespace DDDWebAPI.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryProduto : IRepositoryBase<Produto>
    {
        IEnumerable<Produto> GetAllByNome(string nome_produto);
    }
}
