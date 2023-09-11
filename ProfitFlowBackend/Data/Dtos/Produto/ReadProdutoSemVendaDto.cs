using ProfitFlowBackend.Data.Dtos.Categoria;

namespace ProfitFlowBackend.Data.Dtos.Produto
{
    public class ReadProdutoSemVendaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public double Custo { get; set; }
        public string Imagem { get; set; }
        public string FormatoImagem { get; set; }

        public int Quantidade { get; set; }
        public ReadCategoriaDto Categoria { get; set; }
    }
}
