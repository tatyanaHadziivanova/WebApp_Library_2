using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Library_All.Models.Entities;

namespace WebApp_Library_All.Models
{
    public class Book
    {
        public Book( string title, string author)
        {
            Title = title;
            Author = author;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }


        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
