using EDWARDSOLUTIONApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EDWARDSOLUTIONApi.Contexts
{
    public class AppDBContext:DbContext 
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {

        }

        public DbSet<Producto> Producto{get; set;}

    }
}