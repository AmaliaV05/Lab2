using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project2.Data;
using Project2.Models;
using Project2.ViewModels;

namespace Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<FilmController> _logger;

        public FilmController(ApplicationDbContext context, IMapper mapper, ILogger<FilmController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get all films
        /// </summary>
        /// <returns>Returns all films</returns>
        // GET: api/Film
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Film>>> GetFilms()
        {
            return await _context.Films.ToListAsync();
        }

        /// <summary>
        /// Get film by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns film by id</returns>
        // GET: api/Film/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmViewModel>> GetFilm(int id)
        {
            var film = await _context.Films.FindAsync(id);

            if (film == null)
            {
                return NotFound();
            }

            var filmViewModel = _mapper.Map<FilmViewModel>(film);

            return filmViewModel;
        }

        /// <summary>
        /// Get all comments from a film by film id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returs a list of comments</returns>
        // GET: api/Film/5/Comment
        [HttpGet("{id}/Comments")]
        public ActionResult<IEnumerable<Object>> GetCommentsForProduct(int id)
        {
            var query = _context.Comments.Where(c => c.Film.Id == id)
                .Include(c => c.Film)
                .Select(c => new
                {
                    Film = c.Film.Title,
                    Comment = c.Text
                });
            
            _logger.LogInformation(query.ToQueryString());

            return query.ToList();
        }

        /// <summary>
        /// Gets all films between added dates
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="lastDate"></param>
        /// <returns>Returns all films between two added dates if they are given, else returns all films</returns>
        // GET: api/Film/filter/{firstDate, lastDate}
        [HttpGet]
        [Route("filter/{firstDate, lastDate}")]
        public ActionResult<IEnumerable<FilmViewModel>> FilterFilms(DateTime? firstDate, DateTime? lastDate)
        {
            var filmViewModelList = _context.Films.Select(film => _mapper.Map<FilmViewModel>(film)).ToList();
            if (firstDate == null || lastDate == null)
            {
                return filmViewModelList;
            }
            return _context.Films.Select(film => _mapper.Map<FilmViewModel>(film))
                                  .Where(film => film.DateAdded >= firstDate && film.DateAdded <= lastDate)
                                  .OrderByDescending(film => film.YearOfRelease)
                                  .ToList();
        }

        /// <summary>
        /// Update a film by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="filmViewModel"></param>
        /// <returns>Does not show any return value</returns>
        // PUT: api/Film/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilm(int id, FilmViewModel filmViewModel)
        {
            var film = _mapper.Map<Film>(filmViewModel);

            if (id != film.Id)
            {
                return BadRequest();
            }

            _context.Entry(film).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Create a new film entry
        /// </summary>
        /// <param name="filmViewModel"></param>
        /// <returns>Returns the new film entry</returns>
        // POST: api/Film
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Film>> PostFilm(FilmViewModel filmViewModel)
        {
            var film = _mapper.Map<Film>(filmViewModel);
            _context.Films.Add(film);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilm", new { id = film.Id }, film);
        }

        /// <summary>
        /// Creates a comment for a film by film id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comment"></param>
        /// <returns>The created OkResult for the response or NotFoundResult</returns>
        // POST: api/Film/5/Comment
        [HttpPost("{id}/Comments")]
        public IActionResult PostCommentForFilm(int id, Comment comment)
        {
            comment.Film = _context.Films.Find(id);
            if(comment.Film == null)
            {
                return NotFound();
            }
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Delete a film by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Film/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            var film = await _context.Films.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }

            _context.Films.Remove(film);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmExists(int id)
        {
            return _context.Films.Any(e => e.Id == id);
        }


    }
}
