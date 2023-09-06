using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using C_INFO.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace C_INFO.ViewModels
{
    public class JWTManagerRepository
    {
        Dictionary<string, string> UserRecords;



        private readonly IConfiguration configuration;
        private readonly CarContext db;



        public JWTManagerRepository(IConfiguration _configuration, CarContext _db)
        {
            db = _db;
            configuration = _configuration;
        }
        public Tokens Authenicate(LoginViewModel registerViewModel, bool IsRegister)
        {
            var _isAdmin = false;
            //var _isRestaurant = false;
            if (IsRegister)
            {
                RegisterTbl tblLogin = new RegisterTbl();
                tblLogin.UserName = registerViewModel.UserName;
                tblLogin.Password = registerViewModel.Password;
                tblLogin.PhoneNo = registerViewModel.PhoneNo;
                tblLogin.Email = registerViewModel.Email;
                db.RegisterTbls.Add(tblLogin);
                db.SaveChanges();
            }
            /* else if (db.RegisterTbls.Any(x => x.UserName == registerViewModel.UserName && x.Password == registerViewModel.Password))
             {
                 _isRestaurant = db.RegisterTbls.Any(x => x.UserName == registerViewModel.UserName && x.Password == registerViewModel.Password && x.IsRestaurant == 1);
             }*/
            else
            {
                _isAdmin = db.RegisterTbls.Any(x => x.UserName == registerViewModel.UserName && x.Password == registerViewModel.Password && x.IsAdmin == 1);
            }
            UserRecords = db.RegisterTbls.ToList().ToDictionary(x => x.UserName, x => x.Password);
            if (!UserRecords.Any(x => x.Key == registerViewModel.UserName && x.Value == registerViewModel.Password))
            {
                return null;
            }



            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);



            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name,registerViewModel.UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token), IsAdmin = _isAdmin };
        }


  
    }
}
