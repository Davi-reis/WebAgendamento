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
    public class DetailsModel : PageModel
    {
        private readonly WebAgendamento.Data.ApplicationDbContext _context;

        public DetailsModel(WebAgendamento.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public CadastroServico CadastroServico { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroservico = await _context.CadastroServicos.FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroservico == null)
            {
                return NotFound();
            }
            else
            {
                CadastroServico = cadastroservico;
            }
            return Page();
        }
    }
}
