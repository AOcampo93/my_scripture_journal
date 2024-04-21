using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Models.Scriptures> Scripture { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchStringNotes { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Book { get; set; }



        public async Task OnGetAsync()
        {
            var book = from m in _context.Scripture
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                book = book.Where(s => s.Book.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(SearchStringNotes))
            {
                book = book.Where(s => s.Note.Contains(SearchStringNotes));
            }

            Scripture = await book.ToListAsync();
        }




    }
}
