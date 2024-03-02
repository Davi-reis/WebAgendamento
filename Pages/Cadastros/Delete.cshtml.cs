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
    public class DeleteModel : PageModel
    {
        private readonly WebAgendamento.Data.ApplicationDbContext _context;

        public DeleteModel(WebAgendamento.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroservico = await _context.CadastroServicos.FindAsync(id);
            if (cadastroservico != null)
            {
                CadastroServico = cadastroservico;
                _context.CadastroServicos.Remove(CadastroServico);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
