using System;
using System.Collections.Generic;

namespace LibMan.Models.DB
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int Password { get; set; }
        public byte[] Photo { get; set; }
    }
}
