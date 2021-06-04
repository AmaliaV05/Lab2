using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.ViewModels.Reservations
{
    public class ReservationForUserResponse
    {
        public ApplicationUserViewModel ApplicationUser { get; set; }
        public List<FilmViewModel> Films { get; set; }
        public DateTime ReservationDateTime { get; set; }
    }
}
