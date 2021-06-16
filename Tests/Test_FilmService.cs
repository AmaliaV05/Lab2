using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System;
using Project2.Models;
using Project2.Data;
using Project2.Services;

namespace Tests
{
    class Test_FilmService
    {
        private ApplicationDbContext _context;
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("In setup.");
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            _context = new ApplicationDbContext(options, new OperationalStoreOptionsForTests());

            _context.Films.Add(new Film { Title = "p1 test", Description = "fsd ds fsd fsd", Genre = Genre.Action, Duration = "2 h", YearOfRelease = 1222, Director = "", DateAdded = new DateTime(2008, 3, 1, 7, 0, 0), Rating = 5, Watched = "yes" });
            _context.Films.Add(new Film { Title = "p2 test", Description = "dfs sd sd fsd", Genre = Genre.Comedy, Duration = "2 h", YearOfRelease = 1222, Director = "", DateAdded = new DateTime(2020, 3, 1, 7, 0, 0), Rating = 5, Watched = "yes" });
            _context.SaveChanges();
        }

        [TearDown]
        public void Teardown()
        {
            Console.WriteLine("In teardown");

            foreach (var film in _context.Films)
            {
                _context.Remove(film);
            }
            _context.SaveChanges();
        }

        [Test]
        public void TestGetAllFilmsBetweenDates()
        {
            var service = new FilmService(_context);
            Assert.AreEqual(1, service.GetAllFilmsBetweenDates(new DateTime(2008, 3, 1, 7, 0, 0), new DateTime(2020, 2, 1, 7, 0, 0)).Count);
            Assert.AreEqual(2, service.GetAllFilmsBetweenDates(new DateTime(2008, 3, 1, 7, 0, 0), new DateTime(2020, 4, 1, 7, 0, 0)).Count);
        }        
    }
}
