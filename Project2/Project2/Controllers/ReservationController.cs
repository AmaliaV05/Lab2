using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project2.Data;
using Project2.Models;
using Project2.ViewModels.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project2.Controllers
{
    [Authorize(AuthenticationSchemes = "Identity.Application,Bearer")]
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ReservationController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReservationController(ApplicationDbContext context, ILogger<ReservationController> logger, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }

        /// <summary>
        /// Make one or more reservations to films
        /// </summary>
        /// <param name="newReservationRequest"></param>
        /// <returns>returns Ok if reservation is successful, else Bad Request</returns>
        [HttpPost]
        public async Task<ActionResult> MakeReservation(NewReservationRequest newReservationRequest)
        {
            var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            List<Film> reservedFilms = new List<Film>();
            newReservationRequest.ReservedFilmsIds.ForEach(fid =>
            {
                var filmWithId = _context.Films.Find(fid);
                if(filmWithId != null)
                {
                    reservedFilms.Add(filmWithId);
                }
            });

            if(reservedFilms.Count == 0)
            {
                return BadRequest();
            }

            var reservation = new Reservation
            {
                ApplicationUser = user,
                Films = reservedFilms,
                ReservationDateTime = newReservationRequest.ReservationDateTime.GetValueOrDefault()
            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Get all reservations made
        /// </summary>
        /// <returns>Returns all revservations</returns>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var result = _context.Reservations.Where(r => r.ApplicationUser.Id == user.Id).Include(r => r.Films).FirstOrDefault();
            var resultViewModel = _mapper.Map<ReservationForUserResponse>(result);

            return Ok(resultViewModel);
        }
    }
}
