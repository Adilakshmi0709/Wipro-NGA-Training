using DoConnect.Api.Data;
using DoConnect.Api.DTOs;
using DoConnect.Api.Models;
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net.BCrypt;

namespace DoConnect.Api.Services
{
    public class AuthService
    {
        private readonly DoConnectDbContext _db;
        public AuthService(DoConnectDbContext db)
        {
            _db = db;
        }
        public async Task<(bool Ok, string Message)> RegisterAsync(RegisterDto dto)
        {
            if (await _db.Users.AnyAsync(u => u.Username == dto.Username))
                return (false, "Username already exists");

            if (await _db.Users.AnyAsync(u => u.Email == dto.Email))
                return (false, "Email already registered");

            var user = new User
            {
                FirstName = dto.FirstName.Trim(),
                LastName = dto.LastName.Trim(),
                Username = dto.Username.Trim(),
                Email = dto.Email.Trim(),
                PasswordHash = BCryptNet.HashPassword(dto.Password),
                Role = "User"
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return (true, "Registration successful.");
        }

        public async Task<(bool Ok, string Message, User? User)> LoginAsync(string username, string password)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null) return (false, "Invalid credentials", null);
            if (!BCryptNet.Verify(password, user.PasswordHash)) return (false, "Invalid credentials", null);

            return (true, "Login success", user);
        }

        public async Task<(bool Ok, string Message)> ResetPasswordAsync(string usernameOrEmail, string newPassword)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail);
            if (user == null) return (false, "User not found");

            user.PasswordHash = BCryptNet.HashPassword(newPassword);
            await _db.SaveChangesAsync();

            return (true, "Password reset successful");
        }
    }
}
