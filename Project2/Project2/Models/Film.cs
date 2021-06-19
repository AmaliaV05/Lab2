using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public enum Genre {
        Action,
        Comedy,
        Horror,
        Thriller
    }

    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public string Duration { get; set; }
        public int YearOfRelease { get; set; }
        public string Director { get; set; }
        public DateTime DateAdded { get; set; }
        public int Rating { get; set; }
        public string Watched { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Reservation> Reservations { get; set; }

        public Film()
        {

        }
    }
}
