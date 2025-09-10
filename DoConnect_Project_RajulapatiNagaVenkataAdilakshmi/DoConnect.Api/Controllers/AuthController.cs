using DoConnect.Api.Data;
using DoConnect.Api.DTOs;
using DoConnect.Api.Models;
using DoConnect.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net.BCrypt;

namespace DoConnect.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DoConnectDbContext _context;
        private readonly TokenService _tokenService;
        public AuthController(DoConnectDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        // ✅ Register new user
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Username == dto.Username))
                return BadRequest(new { Message = "Username already exists" });

            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                return BadRequest(new { Message = "Email already registered" });

            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = BCryptNet.HashPassword(dto.Password),
                Role = "User"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "User registered successfully. You can now log in." });

        }

        // ✅ Login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Username) || string.IsNullOrWhiteSpace(dto.Password))
                return BadRequest(new { Message = "Username and password are required" });

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == dto.Username);
            if (user == null) return Unauthorized(new { Message = "Invalid username" });

            if (!BCryptNet.Verify(dto.Password, user.PasswordHash))
                return Unauthorized(new { Message = "Invalid password" });

            var token = _tokenService.GenerateToken(user);

            return Ok(new
            {
                Message = "Login Successful",
                Token = token,
                Role = user.Role,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                email = user.Email
            });
        }

        // ✅ Forgot Password - (optional: just confirm user exists)
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.UsernameOrEmail))
                return BadRequest(new { Message = "Username or email is required" });

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == dto.UsernameOrEmail || u.Email == dto.UsernameOrEmail);

            if (user == null)
                return NotFound(new { Message = "User not found" });

            return Ok(new { Message = "User found, you can reset the password now." });
        }

        // ✅ Reset Password (directly with username/email)
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == dto.UsernameOrEmail || u.Email == dto.UsernameOrEmail);

            if (user == null)
                return NotFound(new { Message = "User not found" });

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Password reset successful" });
        }
    }
}