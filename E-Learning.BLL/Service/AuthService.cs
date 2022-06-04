using E_Learning.DAL.Authentication;
using E_Learning.DAL.Interface;
using E_Learning.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BLL.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuth _auth;
        public AuthService(IAuth auth)
        {
            _auth = auth;
        }
        public async Task<TokenReturn> Login(LoginModel model)
        {
            return await _auth.Login(model);
        }

        public Task<Response> Register(RegisterModel registerModel)
        {
            throw new NotImplementedException();
        }
    }
}
