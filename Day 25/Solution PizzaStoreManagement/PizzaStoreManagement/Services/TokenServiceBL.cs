using Microsoft.IdentityModel.Tokens;
using PizzaStoreManagement.Interfaces;
using PizzaStoreManagement.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace PizzaStoreManagement.Services
{
    public class TokenServiceBL : ITokenService
    {
        private readonly string _key;
        private readonly SymmetricSecurityKey _symmetricSecurityKey;

        public TokenServiceBL(IConfiguration configuration)
        {
            _key = configuration.GetSection("TokenKey").GetSection("JWT").Value.ToString();
            _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
        }
        public async Task<string> GenerateToken(User user)
        {
            try
            {
                string token = string.Empty;
                var claims = new List<Claim>(){
                new Claim(ClaimTypes.Name, user.Id.ToString()) };
                var credentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
                var myToken = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddDays(2), signingCredentials: credentials);
                token = new JwtSecurityTokenHandler().WriteToken(myToken);
                return token;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error in generating tokens");
            }
               
       
        }
    }
}
