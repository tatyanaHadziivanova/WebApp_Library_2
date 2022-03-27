using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Library_All.Models.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Auhtor { get; set; }

        public string CreatedBy { get; set; }
        public string UserEmail { get; set; }
    }
}
