using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Library_Managment.Models {
    public class BookImagePath {
        public int Id { get; set; }
        public long ISBN { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public IFormFile Image { get; set; }
        public int Amount { get; set; }
        public int Available { get; set; }
    }
}
