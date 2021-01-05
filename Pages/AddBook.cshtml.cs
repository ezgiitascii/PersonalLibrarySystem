using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibMan.Models.DB;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace LibMan.Pages
{
    public class AddBookModel : PageModel
    {
        private readonly LibMan.Models.DB.LibManContext _context;

        private readonly IHostingEnvironment _environment;

        public AddBookModel(LibMan.Models.DB.LibManContext context, IHostingEnvironment envoriment)
        {
            _context = context;
            _environment = envoriment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            string resimler = Path.Combine(_environment.WebRootPath, "images");
            if (Book.ImageFile.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(resimler, Book.ImageFile.FileName), FileMode.Create))
                {
                    await Book.ImageFile.CopyToAsync(fileStream);
                }
            }
            Book.ImagePath = Book.ImageFile.FileName;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");



        }
    }
}
