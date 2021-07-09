using Project2.Helpers;
using Project2.Models;
using Project2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Services
{
    public interface IFilmService
    {
        Task<PagedList<Film>> GetAllFilms(FilmParams filmParams);
        List<Film> GetAllFilmsBetweenDates(DateTime StartDate, DateTime EndDate);

        Task<Film> GetFilmById(int id);

        IEnumerable<FilmWithCommentViewModel> GetCommentsForFilm(int id);

        IEnumerable<FilmViewModel> FilterFilms(DateTime firstDate, DateTime lastDate);

        IEnumerable<FilmViewModel> FilterFilmsByGenre(Genre genre);

        Task<bool> PutFilm(int id, FilmViewModel filmViewModel);

        Task<bool> PutComment(int idFilm, int idComment, CommentViewModel commentViewModel);

        Task<Film> PostFilm(FilmViewModel filmRequest);

        Task<Comment> PostCommentForFilm(int id, Comment comment);

        Task<bool> DeleteFilm(int id);
    
        Task<bool> DeleteComment(int idFilm, int idComment);    

    }
}
