using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Entries
{
    public class DeleteModel : PageModel
    {
        private readonly MyScriptureJournal.Models.MyScriptureJournalContext _context;

        public DeleteModel(MyScriptureJournal.Models.MyScriptureJournalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Entry Entry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Entry = await _context.Entry.FirstOrDefaultAsync(m => m.ID == id);

            if (Entry == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Entry = await _context.Entry.FindAsync(id);

            if (Entry != null)
            {
                _context.Entry.Remove(Entry);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
