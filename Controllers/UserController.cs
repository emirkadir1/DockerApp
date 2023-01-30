using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DockerApp.Models;
using System.Security.Cryptography;

namespace DockerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _context;
       public UserController(UserDbContext context)
        {
            _context = context;
        }
        [HttpPost("register")]
        public async Task<IActionResult>Register(UserRegisterRequest request)
        {
            if (_context.Users.Any(u => u.Email == request.Email))
            {
                return BadRequest("Bu email kullanılmakta");
            }
            CreatePasswordHash(request.Password,out byte[] passwordHash,out byte[] passwordSalt);
            var user = new User
            {
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                VerificationToken = CreateRandomToken()
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok("Başarıyla Kayıt Olundu.");
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash,out byte[] passwordSalt)
        {
            using (var hmac=new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }
    }
}
