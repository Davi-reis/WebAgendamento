using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAgendamento.Data;
using WebAgendamento.Model;

namespace WebAgendamento.Pages.Cadastro
{
    public class IndexModel : PageModel
    {
        private readonly WebAgendamento.Data.ApplicationDbContext _context;

        public IndexModel(WebAgendamento.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CadastroServico> CadastroServico { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CadastroServico = await _context.CadastroServicos.ToListAsync();
        }
    }
}
