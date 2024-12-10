
using Microsoft.EntityFrameworkCore;
using MinhaPrimeiraApi.Entities;

namespace MinhaPrimeiraApi.context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {

        }

        public DbSet<Contatos> Contatos { get; set; }


    }
}