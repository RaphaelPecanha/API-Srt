using Microsoft.EntityFrameworkCore;
using SRT.ServiceAPI.Models;

namespace SRT.ServiceAPI.Context
{
    public class AppDbContext : DbContext
    {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
            public DbSet<Cotacao> Cotacao { get; set; }
   
}
}