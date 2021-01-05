using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibMan.Models.DB;

namespace LibMan.Pages
{
    public class SearchModel : PageModel
    {
        private readonly LibMan.Models.DB.LibManContext _context;

        public SearchModel(LibMan.Models.DB.LibManContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; }

        public async Task<IActionResult> OnGetAsync(String find)
        {

            if (find == null)
            {
                return NotFound();
            }


            Book = await _context.Book
                .Where(b => b.Title == find)
                .ToListAsync();

            return Page();
        }
    }
}