﻿using Gustav2.ViewData;

namespace Gustav2.Repositorios.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<List<ProdutoModel>> GetProdutos();
        Task<ProdutoModel> GetProdutoByDescription(string NomeProduto);
        Task<ProdutoModel> GetProdutoById(int IdProduto);
        Task<ProdutoModel> InsertProduto(ProdutoModel NovoProduto);
        Task<ProdutoModel> EditProduto(ProdutoModel EdicaoProduto, int IdProduto);
        Task<bool> DeleteProduto(int IdProduto);
    }
}
