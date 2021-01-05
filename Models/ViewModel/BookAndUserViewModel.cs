using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibMan.Models.DB;

namespace LibMan.Models.ViewModel
{
    public class BookAndUserViewModel
    {
        public User UserObj { get; set; }
        public IEnumerable<Book> Book { get; set; }
        public IEnumerable<User> User { get; set; }
    }
}
