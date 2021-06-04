using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.ViewModels.Reservations
{
    public class NewReservationRequest
    {
        public List<int> ReservedFilmsIds { get; set; }
        public DateTime? ReservationDateTime { get; set; }
    }
}
