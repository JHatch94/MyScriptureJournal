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
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Canons { get; set; }
        [BindProperty(SupportsGet = true)]
        //public SelectList Books { get; set; }
        //[BindProperty(SupportsGet = true)]
        public string ScriptureCanon { get; set; }
        //public string ScriptureBook { get; set; }
        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> canonQuery = from e in _context.Entry
                                            orderby e.Canon
                                            select e.Canon;
          /*  IQueryable<string> bookQuery = from e in _context.Entry
                                            orderby e.Book
                                            select e.Book;*/

            var entries = from e in _context.Entry
                          select e;
            if (!string.IsNullOrEmpty(SearchString))
            {
                entries = entries.Where(s => s.Book.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ScriptureCanon))
            {
                entries = entries.Where(x => x.Canon == ScriptureCanon);
            }
            Canons = new SelectList(await canonQuery.Distinct().ToListAsync());

/*            if (!string.IsNullOrEmpty(ScriptureBook))
            {
                entries = entries.Where(x => x.Book == ScriptureBook);
            }
            Books = new SelectList(await bookQuery.Distinct().ToListAsync());*/

            Entry = await _context.Entry.ToListAsync();
        }
    }
}
