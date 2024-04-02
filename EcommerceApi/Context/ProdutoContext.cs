using EcommerceApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Context;

public class ProdutoContext : IdentityDbContext<IdentityUser>
{
    public ProdutoContext(DbContextOptions<ProdutoContext> opts) : base(opts) { }

    public DbSet<Produto> Produtos { get; set; }
}
