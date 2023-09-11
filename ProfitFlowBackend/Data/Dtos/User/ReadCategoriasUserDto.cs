using ProfitFlowBackend.Data.Dtos.Categoria;

namespace ProfitFlowBackend.Data.Dtos.User
{
    public class ReadCategoriasUserDto
    {
        public ICollection<ReadCategoriaDto> Categorias { get; set; }

    }
}
