using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAgendamento.Data;
using WebAgendamento.Model;

namespace WebAgendamento.Pages.Cadastro
{
    public class CreateModel : PageModel
    {
        private readonly WebAgendamento.Data.ApplicationDbContext _context;

        public CreateModel(WebAgendamento.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CadastroServico CadastroServico { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CadastroServicos.Add(CadastroServico);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
