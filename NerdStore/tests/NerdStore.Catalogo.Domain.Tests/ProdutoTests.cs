using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain.Tests
{
    public class ProdutoTests
    {
        [Fact]
        public void Produto_Validar_ValidacoesDevemRetornarExceptions()
        {
            var ex = Assert.Throws<DomainException>(() => 
                new Produto(string.Empty, "Descricao", false, 100, DateTime.Now, "Imagem", new Dimensoes(1, 1, 1), Guid.NewGuid())
            );

            Assert.Equal("O campo nome do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome", string.Empty, false, 100, DateTime.Now, "Imagem", new Dimensoes(1, 1, 1), Guid.NewGuid())
            );

            Assert.Equal("O campo descricao do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome", "Descricao", false, -1, DateTime.Now, "Imagem", new Dimensoes(1, 1, 1), Guid.NewGuid())
            );

            Assert.Equal("O campo valor do produto não pode ser menor igual a zero", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome", "Descricao", false, 100, DateTime.Now, "Imagem", new Dimensoes(1, 1, 1), Guid.Empty)
            );

            Assert.Equal("O campo CategoriaId do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome", "Descricao", false, 100, DateTime.Now, string.Empty, new Dimensoes(1, 1, 1), Guid.NewGuid())
            );

            Assert.Equal("O campo valor do produto não pode ser menor igual a zero", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome", "Descricao", false, 100, DateTime.Now, "Imagem", new Dimensoes(0, 1, 1), Guid.NewGuid())
            );

            Assert.Equal("O campo altura deve ser no mínimo 1", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome", "Descricao", false, 100, DateTime.Now, "Imagem", new Dimensoes(1, 0, 1), Guid.NewGuid())
            );

            Assert.Equal("O campo largura deve ser no mínimo 1", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome", "Descricao", false, 100, DateTime.Now, "Imagem", new Dimensoes(1, 1, 0), Guid.NewGuid())
            );

            Assert.Equal("O campo profundidade deve ser no mínimo 1", ex.Message);

        }
    }
}