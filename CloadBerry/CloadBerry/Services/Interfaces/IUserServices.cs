using CloadBerry.Models;
using CloadBerry.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloadBerry.Services.Interfaces
{
    public interface IUserServices
    {
        Task<string> Login(LoginDTO login);
        Task<bool> ChangePassword(String Password, string NewPassword);
        Task<bool> Add(UserRegisterDTO model);
        CurrentUserDTO ValidateToken(string token);
        CurrentUserDTO Me();
    }
}
