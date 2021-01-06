using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Managment.Models {
    public class UserNewData : IdentityUser{
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Occupation { get; set; }
        public ICollection<TakenBooks> TakenBooks { get; set; }

    }
}
