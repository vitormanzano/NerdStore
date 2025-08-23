using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Dimensoes
    {
        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Profundidade { get; private set; }

        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            AssertionConcern.ValidarSeMenorQue(altura, 1, "O campo altura deve ser no mínimo 1");
            AssertionConcern.ValidarSeMenorQue(largura, 1, "O campo largura deve ser no mínimo 1");
            AssertionConcern.ValidarSeMenorQue(profundidade, 1, "O campo profundidade deve ser no mínimo 1");

            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;
        }

        public string DescricaoFormatada()
        {
            return $"LxAxP: {Largura} x {Altura} x {Profundidade}";
        }

        public override string ToString()
        {
            return DescricaoFormatada();
        }
    }
}
