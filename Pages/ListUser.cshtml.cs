using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibMan.Models.DB;

using Microsoft.AspNetCore.Http;
using LibMan.Models.ViewModel;

namespace LibMan.Pages
{
    public class ListUserModel : PageModel
    {
        private readonly LibMan.Models.DB.LibManContext _context;


        public ListUserModel(LibMan.Models.DB.LibManContext context)
        {
            _context = context;
        }
        public int UserID;

        [BindProperty]
        public BookAndUserViewModel BookAndUserVM { get; set; }
        public IList<User> User { get; set; }


        public async Task OnGetAsync()
        {
            UserID = (int)HttpContext.Session.GetInt32("id");

            BookAndUserVM = new BookAndUserViewModel()
            {
                User = await _context.User.Where(c => c.UserId == UserID).ToListAsync(),
                UserObj = await _context.User.FirstOrDefaultAsync(u => u.UserId == UserID)
            };


        }

    }

}