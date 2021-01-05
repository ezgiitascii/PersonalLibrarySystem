using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibMan.Models.DB;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using LibMan.Models.ViewModel;

namespace LibMan.Pages
{
    public class ListBookModel : PageModel
    {
        private readonly LibMan.Models.DB.LibManContext _context;
        public int UserId;

        public ListBookModel(LibMan.Models.DB.LibManContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }
        public BookAndUserViewModel BookAndUserVM { get; private set; }

        public async Task OnGetAsync()
        {
            UserId = (int)HttpContext.Session.GetInt32("id");
            BookAndUserVM = new BookAndUserViewModel()
            {
                Book = await _context.Book.Where(c => c.UserId== UserId).ToListAsync(),
                UserObj = await _context.User.FirstOrDefaultAsync(u => u.UserId == UserId)
            };
        }
    }
}
