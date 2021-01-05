using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibMan.Models.DB
{
    public partial class Book
    {
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string ImagePath { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Translator { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public string ReadingStatus { get; set; }
        public byte[] Cover { get; set; }
        public string Categories { get; set; }
    }
}
