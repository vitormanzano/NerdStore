using AutoMapper;
using NerdStore.Catalago.Application.ViewModels;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalago.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProdutoViewModel, Produto>()
                .ConstructUsing(p =>
                    new Produto(p.Nome, p.Descricao, p.Ativo,
                        p.Valor, p.DataCadastro, p.Imagem,
                        new Dimensoes(p.Altura, p.Largura, p.Profundidade), p.CategoriaId));

            CreateMap<CategoriaViewModel, Categoria>()
                .ConstructUsing(c => new Categoria(c.Nome, c.Codigo));
        }
    }
}
