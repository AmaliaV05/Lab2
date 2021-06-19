using Project2.Data;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project2.Services
{
    public class FilmService
    {
        public ApplicationDbContext _context;

        public FilmService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Film> GetAllFilmsBetweenDates(DateTime StartDate, DateTime EndDate)
        {
            return _context.Films.Where(f => f.DateAdded >= StartDate && f.DateAdded <= EndDate).ToList();
        }
    }
}
