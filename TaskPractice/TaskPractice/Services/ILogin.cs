using Microsoft.AspNetCore.Mvc;
using TaskPractice.Data.dto;
using TaskPractice.Data.Model;

namespace TaskPractice.Services
{
    public interface ILogin
    {
        public  Task<string> RegisterAsync(dto_Register users);
        public Task<ActionResult> LoginAsync(string email, string password);

        public Task<ActionResult> ResetPasswordAsync(string userEmail, string newPassword);
    }
}
