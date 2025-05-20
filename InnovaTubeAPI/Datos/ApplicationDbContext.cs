using InnovaTubeAPI.Entidades;
using Microsoft.EntityFrameworkCore;

namespace InnovaTubeAPI.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<VideoFavorito> VideosFavoritos { get; set; }
    }
}
