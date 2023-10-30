using Gustav2.Repositorios;
using Gustav2.Repositorios.Interfaces;
using Gustav2.ViewData;
using Microsoft.AspNetCore.Mvc;

namespace Gustav2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProdutoModel>>> GetProdutos()
        {
            List<ProdutoModel> listaProdutos = await _produtoRepositorio.GetProdutos();
            return Ok(listaProdutos);
        }
        [HttpGet]
        public async Task<ActionResult<ProdutoModel>> GetProdutoByDescription(string DescricaoProduto)
        {
            ProdutoModel produto = await _produtoRepositorio.GetProdutoByDescription(DescricaoProduto);
            return Ok(produto);
        }
        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> InsertProduto(ProdutoModel ProdutoNovo)
        {
            ProdutoModel produtoNovo = await _produtoRepositorio.InsertProduto(ProdutoNovo);
            return Ok(produtoNovo);
        }
        [HttpPut]
        public async Task<ActionResult<ProdutoModel>> EditProduto(ProdutoModel Produto, int IdProduto)
        {
            ProdutoModel produtoEditado = await _produtoRepositorio.EditProduto(Produto, IdProduto);
            return Ok(produtoEditado);
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteProduto(int IdProduto)
        {
            bool delete = await _produtoRepositorio.DeleteProduto(IdProduto);
            return Ok(delete);
        }
    }
}
