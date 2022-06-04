using Dapper;
using E_Learning.DAL.Authentication;
using E_Learning.DAL.Interface;
using E_Learning.DAL.Models;
using E_Learning.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.DAL.Repository
{
    public class AuthRepository : IAuth
    {
        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private string _connection;
        public AuthRepository(/*UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, */IConfiguration configuration)
        {
            //_userManager = userManager;
            //_roleManager = roleManager;
            //_signInManager = signInManager;
            _connection = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<TokenReturn> Login(LoginModel model)
        {
            using (var connection = new NpgsqlConnection(_connection))
            {
                connection.Open();
                var user = connection.Query<AspNetUsers>($"SELECT * FROM AspNetUsers WHERE UserName = '{model.Username}';");
                if (user != null && _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var userRoles = _userManager.GetRolesAsync(user);
                    _signInManager.SignInAsync(user, false);
                    var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }

                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(3),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                        );

                    //string userId = "";
                    //if (userRoles[0] == "Student")
                    //{
                    //    Student student = await _dbContext.Students.FirstOrDefaultAsync(x => x.Username == model.Username);
                    //    userId = student.Id;
                    //}
                    //else if (userRoles[0] == "Faculty")
                    //{
                    //    Faculty faculty = await _dbContext.Faculties.FirstOrDefaultAsync(x => x.Username == model.Username);
                    //    userId = faculty.Id;
                    //}

                    TokenReturn tokenReturn = new TokenReturn()
                    {
                        Status = $"Username {model.Username} logged in...",
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        Expiration = token.ValidTo
                    };

                    return tokenReturn;
                }
            }
        }

        public Task<Response> Register(RegisterModel registerModel)
        {
            throw new NotImplementedException();
        }
    }
}
