using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibMan.Models.DB;
using Microsoft.AspNetCore.Http;
using LibMan.Models.DB;


namespace LibMan.Pages
{
    public class IndexModel : PageModel
    {
        private readonly LibMan.Models.DB.LibManContext _context;

        public IndexModel(LibMan.Models.DB.LibManContext context)
        {
            _context = context;
        }

        public IList<User> User { get; set; }

        public async Task OnGetAsync()
        {
            User = await _context.User.ToListAsync();
        }
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public int Password { get; set; }
        public string Msg { get; set; }
        public int UserId { get; set; }
        private bool UserExists(string username, int password)
        {
            bool usern = false, pass = false;
            usern = _context.User.Any(e => e.Username == username);
            pass = _context.User.Any(e => e.Password == password);
            if (usern == true && pass == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       

        public IActionResult OnPost()
        {
            if (UserExists(Username, Password))
            {
                //HttpContext.Session.SetString("username", Username);
                var cust = _context.User.Single(a => a.Username == Username);
                HttpContext.Session.SetString("username", cust.Username);
                HttpContext.Session.SetInt32("id", cust.UserId);
                // return RedirectToPage("Welcome");
                return RedirectToPage("Welcome");
            }
           
            else
            {
                Msg = "Invalid";
                return Page();
            }
        }
       
    }
}
