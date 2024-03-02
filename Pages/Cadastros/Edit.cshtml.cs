using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAgendamento.Data;
using WebAgendamento.Model;

namespace WebAgendamento.Pages.Cadastro
{
    public class EditModel : PageModel
    {
        private readonly WebAgendamento.Data.ApplicationDbContext _context;

        public EditModel(WebAgendamento.Data.ApplicationDbContext context)
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

            var cadastroservico =  await _context.CadastroServicos.FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroservico == null)
            {
                return NotFound();
            }
            CadastroServico = cadastroservico;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CadastroServico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CadastroServicoExists(CadastroServico.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CadastroServicoExists(int id)
        {
            return _context.CadastroServicos.Any(e => e.Id == id);
        }
    }
}
