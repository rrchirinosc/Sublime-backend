using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sublime.Database.Pocos
{
    public class Contact
    {
        public long Personalnr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
