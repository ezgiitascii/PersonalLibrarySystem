using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibMan.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibMan.Pages
{

    public class WelcomeModel : PageModel
    {
        public string Username { get; set; }
        public int UserId;

        public void OnGet()
        {
            UserId = (int)HttpContext.Session.GetInt32("id");
            Username = HttpContext.Session.GetString("username");
        }
        void SubmitBtn_Click(Object sender, EventArgs e)
        {
            RedirectToPage("Privacy");
        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("username");

            return RedirectToPage("Index");
        }
        
        
    }
}