using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Managment.Models {
    public class TakenBooks {
        public int Id { get; set; }
        public string UserId { get; set; }
        public UserNewData User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime TakenDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool Returned { get; set; }
    }
}
