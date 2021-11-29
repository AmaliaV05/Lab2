using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project2.Data;
using Project2.Models;
using Project2.ViewModels;

namespace Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(
            ApplicationDbContext context, 
            IMapper mapper, 
            RoleManager<IdentityRole> roleManager, 
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        [Route("listRoles")]
        public IQueryable<IdentityRole> ListRoles()
        {
            var roles = _roleManager.Roles;
            return roles;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUserViewModel>>> GetUsers()
        {
            var result = await _context.ApplicationUsers.ToListAsync();

            var mappedResult = new List<ApplicationUserViewModel>();

            foreach (ApplicationUser user in result)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var mappedUser = _mapper.Map<ApplicationUserViewModel>(user);
                mappedUser.UserRoles = roles.ToList();
                mappedResult.Add(mappedUser);
            }

            mappedResult = mappedResult.OrderBy(u => !u.UserRoles.Contains(UserRole.ROLE_ADMIN)).ToList();

            return mappedResult;
        }

        [HttpGet("current")]
        [Authorize(AuthenticationSchemes = "Identity.Application,Bearer")]
        public async Task<ActionResult<ApplicationUserViewModel>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirst(ClaimTypes.Email).Value);

            if (user == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<ApplicationUserViewModel>(user);

            return viewModel;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUserViewModel>> GetUser(String id)
        {
            var user = await _context.ApplicationUsers.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var mappedUser = _mapper.Map<ApplicationUserViewModel>(user);
            var roles = await _userManager.GetRolesAsync(user);
            mappedUser.UserRoles = roles.ToList();
            return mappedUser;
        }

        // PUT: api/UserRole/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, ApplicationUserViewModel user)
        {
            var currentUser = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (id != currentUser.Id && !await _userManager.IsInRoleAsync(currentUser, UserRole.ROLE_ADMIN))
            {
                return Unauthorized();
            }

            if (!user.Id.Equals(id))
            {
                return BadRequest();
            }

            var userEntity = await _context.Users.FindAsync(id);
            userEntity.Email = user.Email;
            
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApplicationUser>> PostUser(ApplicationUserViewModel newUser)
        {
            var currentUser = await _userManager.FindByEmailAsync(User.FindFirst(ClaimTypes.Email).Value);

            if (!await _userManager.IsInRoleAsync(currentUser, UserRole.ROLE_ADMIN))
            {
                return StatusCode(403);
            }

            var user = new ApplicationUser
            {
                Email = newUser.Email,                
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true // a hack, but we're not implementing email confirmation
            };

            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, newUser.UserRoles);
                var mappedUser = _mapper.Map<ApplicationUserViewModel>(user);
                mappedUser.UserRoles = newUser.UserRoles;

                return CreatedAtAction("GetUser", new { id = user.Id }, mappedUser);
            }

            return BadRequest(result.Errors);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var currentUser = await _userManager.FindByEmailAsync(User.FindFirst(ClaimTypes.Email).Value);

            if (!await _userManager.IsInRoleAsync(currentUser, UserRole.ROLE_ADMIN))
            {
                return StatusCode(403);
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(string id)
        {
            return _context.ApplicationUsers.Any(e => e.Id.Equals(id));
        }
    }
}
