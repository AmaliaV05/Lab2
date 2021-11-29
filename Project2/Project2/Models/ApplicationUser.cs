using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Project2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Reservation> Reservations { get; set; }
    }
}
