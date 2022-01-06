using Microsoft.EntityFrameworkCore;

namespace ProjetoIndigenas.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Denuncia> Denuncia { get; set; }
    }
}
