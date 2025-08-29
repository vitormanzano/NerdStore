using AutoMapper;
using NerdStore.Catalago.Application.ViewModels;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalago.Application.Services
{
    internal class ProdutoAppService(IProdutoRepository _produtoRepository,
                                     IMapper _mapper,
                                     IEstoqueService _estoqueService) : IProdutoAppService
    {
        public async Task<IEnumerable<ProdutoViewModel>> ObterPorCategoria(int codigo)
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterPorCategoria(codigo));
        }

        public async Task<ProdutoViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));

        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterTodos());

        }

        public async Task<IEnumerable<CategoriaViewModel>> ObterCategorias()
        {
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(await _produtoRepository.ObterCategorias());

        }

        public async Task AdicionarProduto(ProdutoViewModel produto)
        {
            var produtoMapper = _mapper.Map<Produto>(produto);
            _produtoRepository.Adicionar(produtoMapper);

            await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task AtualizarProduto(ProdutoViewModel produto)
        {
            var produtoMapper = _mapper.Map<Produto>(produto);
            _produtoRepository.Atualizar(produtoMapper);

            await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task<ProdutoViewModel> DebitarEstoque(Guid id, int quantidade)
        {
            if (!_estoqueService.DebitarEstoque(id, quantidade).Result)
                throw new DomainException("Falha ao debitar estoque");

            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));
        }

        public async Task<ProdutoViewModel> ReporEstoque(Guid id, int quantidade)
        {
            if (!_estoqueService.ReporEstoque(id, quantidade).Result)
                throw new DomainException("Falha ao debitar estoque");

            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));
        }
        public void Dispose()
        {
            _produtoRepository?.Dispose();
            _estoqueService?.Dispose();
        }

    }
}
