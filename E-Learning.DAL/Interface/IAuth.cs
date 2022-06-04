using E_Learning.DAL.Authentication;
using E_Learning.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.DAL.Interface
{
   public interface IAuth
    {
        Task<TokenReturn> Login(LoginModel model);
        Task<Response> Register(RegisterModel registerModel);
    }
}
