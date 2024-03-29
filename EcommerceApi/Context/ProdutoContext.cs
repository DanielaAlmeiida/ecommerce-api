﻿using EcommerceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Context;

public class ProdutoContext : DbContext
{
    public ProdutoContext(DbContextOptions<ProdutoContext> opts) : base(opts) { }

    public DbSet<Produto> Produtos { get; set; }
}
