using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RegistroTecnicos.Models;
namespace RegistroTecnicos.DAL;

public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
{
    public DbSet<Tecnicos> Tecnicos { get; set; }
}
