using Microsoft.EntityFrameworkCore;
using GestaoFacil.Models;
using System.ComponentModel.DataAnnotations;

namespace GestaoFacil.DataContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        
        public DbSet<Servidor> Servidores {get; set;} = null!;
    }
}