using Microsoft.EntityFrameworkCore;
using WebAgendamento.Model;

namespace WebAgendamento.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {


        }

        public DbSet<CadastroServico> CadastroServicos { get; set; }

    }
}
