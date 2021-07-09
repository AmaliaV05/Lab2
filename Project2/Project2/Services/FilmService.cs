using Microsoft.EntityFrameworkCore;
using Project2.Data;
using Project2.Helpers;
using Project2.Models;
using Project2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Services
{
    public class FilmService : IFilmService
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

        public async Task<PagedList<Film>> GetAllFilms(FilmParams filmParams)
        {
           var query = _context.Films.AsQueryable();

           if (!String.IsNullOrEmpty(filmParams.Title))
           {
               query = query.Where(f => f.Title == filmParams.Title);
           }

           return await PagedList<Film>.CreateAsync(query.AsNoTracking(),
               filmParams.PageNumber, filmParams.PageSize);
        }

        public Task<Film> GetFilmById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FilmWithCommentViewModel> GetCommentsForFilm(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FilmViewModel> FilterFilms(DateTime firstDate, DateTime lastDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FilmViewModel> FilterFilmsByGenre(Genre genre)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutFilm(int id, FilmViewModel filmViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutComment(int idFilm, int idComment, CommentViewModel commentViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<Film> PostFilm(FilmViewModel filmRequest)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> PostCommentForFilm(int id, Comment comment)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFilm(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteComment(int idFilm, int idComment)
        {
            throw new NotImplementedException();
        }
    }
}
