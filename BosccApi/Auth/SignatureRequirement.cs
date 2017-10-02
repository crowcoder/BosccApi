using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BosccApi.Auth
{
    public class ApiSecurity
    {
        public static bool AuthenticationIsValid(string username, string password)
        {
            Dictionary<string, string> validLogins = new Dictionary<string, string>
            {
                { "bob", "123password" },
                { "sally", "abcpassword" }
            };

            string pw = "";
            if(validLogins.TryGetValue(username, out pw))
            {
                return pw == password;
            }

            return false;
        }

        public static string GenerateToken()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Mares eat oats and does eat oats."));

            var claims = new Claim[] {
                new Claim(ClaimTypes.Name, "John"),
                new Claim(JwtRegisteredClaimNames.Email, "bob@contrivedexample.com")
            };

            var token = new JwtSecurityToken(issuer: "BosccApi", audience: "You", claims: claims,
                 notBefore: DateTime.UtcNow, expires: DateTime.UtcNow.AddMinutes(5),
                 signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
                );

            string tkn = new JwtSecurityTokenHandler().WriteToken(token);

            return tkn;
        }
    }
}
