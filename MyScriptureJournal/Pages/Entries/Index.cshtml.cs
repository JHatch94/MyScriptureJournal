using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Entries
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Models.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Models.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Entry> Entry { get;set; }
        //[BindProperty(SupportsGet = true)]
        //public string SearchString { get; set; }
        //public SelectList Canons { get; set; }
        //[BindProperty(SupportsGet = true)]
        //public string ScriptureCanon { get; set; }

        public async Task OnGetAsync()
        {
        //    var entries = from e in _context.Entry
        //                 select e;
        //    if (!string.IsNullOrEmpty(SearchString))
        //    {
        //        Entry = Entry.Where(s => s.Book.Contains(SearchString));
        //    }
        //
            Entry = await _context.Entry.ToListAsync();
        }
    }
}
