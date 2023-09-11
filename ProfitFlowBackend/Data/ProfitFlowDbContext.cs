using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProfitFlowBackend.Models;

namespace ProfitFlowBackend.Data;

public class ProfitFlowDbContext : IdentityDbContext<Usuario>
{
    public ProfitFlowDbContext(DbContextOptions<ProfitFlowDbContext> opts) : base(opts)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

    }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Venda> Venda { get; set; }
}
