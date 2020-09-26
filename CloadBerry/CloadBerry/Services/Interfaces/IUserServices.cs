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
        CurrentUserDTO ValidateToken(string token);
    }
}
