using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskPractice.Data.dto;
using TaskPractice.Data.Model;
using BCrypt.Net;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Authentication;

namespace TaskPractice.Services
{
    public class Login : ILogin
    {
        private readonly ApplicationDbContext applicationDbContext;

        public Login(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
     /* public async Task<ActionResult> LoginAsync(string email, string password)
        {
           var user=  await AuthenticateUserAsync(email, password);
            if(user == null)
            {

            }
        }
     */
        [NonAction]
        private async Task<User> AuthenticateUserAsync(string email, string password)
        {

            string hashedPassword = await HashPassword(password);
            var user = applicationDbContext.Users.FirstOrDefault(u => u.UserEmail == email && u.Password == hashedPassword);

            if (user == null)
            {
                throw new AuthenticationException("Invalid username or password");
            }
            return user;
        }

        public async Task<String> RegisterAsync(dto_Register users)
        {
            var existingUser =  await applicationDbContext.Users.FirstOrDefaultAsync(x => x.UserEmail == users.UserEmail);
            if (existingUser != null)
            {
                return "User Is Registerd";
            }
            string hashedPassword = await HashPassword(users.Password);
            var user = new User
            {
             UserEmail=users.UserEmail,
              UserName=users.UserName,
               Password= hashedPassword
            };
            await applicationDbContext.AddAsync(user);
            await applicationDbContext.SaveChangesAsync();
            return "User Registered Successfull";
        }

        private async Task<string> HashPassword(string password)
        {
            // Generate a random salt
            byte[] salt = Encoding.UTF8.GetBytes("fixedSaltValue123");

            // Create a new instance of the Rfc2898DeriveBytes class
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);

            // Generate the hash value
            byte[] hash = pbkdf2.GetBytes(20);

            // Combine the salt and hash
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // Convert the combined salt+hash to a base64-encoded string
            string hashedPassword = Convert.ToBase64String(hashBytes);

            return hashedPassword;
        }

        public Task<ActionResult> ResetPasswordAsync(string userEmail, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
