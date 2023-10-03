using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlataformaDeMembros.Data;
using PlataformaDeMembros.Models;

namespace PlataformaDeMembros.Pages_PremiumMember
{
    public class DeleteModel : PageModel
    {
        private readonly PlataformaDeMembros.Data.ApplicationDbContext _context;

        public DeleteModel(PlataformaDeMembros.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public PremiumMembers PremiumMembers { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PremiumMember == null)
            {
                return NotFound();
            }

            var premiummembers = await _context.PremiumMember.FirstOrDefaultAsync(m => m.id == id);

            if (premiummembers == null)
            {
                return NotFound();
            }
            else 
            {
                PremiumMembers = premiummembers;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.PremiumMember == null)
            {
                return NotFound();
            }
            var premiummembers = await _context.PremiumMember.FindAsync(id);

            if (premiummembers != null)
            {
                PremiumMembers = premiummembers;
                _context.PremiumMember.Remove(PremiumMembers);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
