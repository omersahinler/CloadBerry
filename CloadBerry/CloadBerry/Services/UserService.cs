using AutoMapper;
using CloadBerry.Models;
using CloadBerry.Models.DTO;
using CloadBerry.Services.Interfaces;
using Jose;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloadBerry.Services
{
    public class UserService: IUserServices
    {
        private readonly DbSet<User> _user;
        private readonly CloadBeryContext _cloadBeryContext;
        private const string _jwtKey = "msCcNCTw8RCZVSF3Sn";
        private readonly IMapper _mapper;
        public CurrentUserDTO CurrentUser { get; set; }
        public UserService(CloadBeryContext context, IMapper mapper)
        {
            _mapper = mapper;
            _user = context.Users;

        }
        public async Task<string> Login(LoginDTO login)

        {

            var dbUser = await _user.SingleOrDefaultAsync(x => x.Mail == login.Mail && x.Password == login.Password);

            if (dbUser == null)
            {
                return null;
            }

            dbUser.Password = null;

            return JWT.Encode(_mapper.Map<CurrentUserDTO>(dbUser),
                Encoding.UTF8.GetBytes(_jwtKey), JwsAlgorithm.HS256);
        }
        public CurrentUserDTO ValidateToken(string token)
        {
            try
            {
                CurrentUser = JWT.Decode<CurrentUserDTO>(token, Encoding.UTF8.GetBytes(_jwtKey));
            }
            catch
            {
                return null;
            }

            return CurrentUser;
        }
        public async Task<bool> ChangePassword(String Password, string NewPassword)
        {
            var user = await _user.SingleOrDefaultAsync(x => x.Id == CurrentUser.Id && x.Password == Password);
            if (user == null)
                return false;
            user.Password = NewPassword;
            return await _cloadBeryContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> Add(User model)
        {
            var user = _mapper.Map<User>(model);
            await _cloadBeryContext.Users.AddAsync(user);
            return await _cloadBeryContext.SaveChangesAsync() > 0;
        }
        public CurrentUserDTO Me() => CurrentUser;

    }
}
