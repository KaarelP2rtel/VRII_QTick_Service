using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        //Entity properties
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime Registered { get; set; }
        public bool Active { get; set; }

        //Table relations
        public List<Invoice> Invoices { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
