using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDo.Domain.Models.Users;

namespace ToDo.API.Services
{
    public interface ITokenService
    {
        SecurityToken GetToken(User user);
    }

    public class SecurityToken
    {
        public string Token { get; }
        public DateTime IssuedDate { get; }
        public DateTime Expires { get; }

        public SecurityToken(string token, DateTime issuedDate, DateTime expires)
        {
            Token = token;
            IssuedDate = issuedDate;
            Expires = expires;
        }
    }

    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SecurityToken GetToken(User user)
        {
            var issuer = _configuration["Authentication:Issuer"] ?? throw new NullReferenceException();
            var audience = _configuration["Authentication:Audience"] ?? throw new NullReferenceException();
            var signingKey = _configuration["Authentication:SigningKey"] ?? throw new NullReferenceException();
            var tokenDuration = _configuration["Authentication:TokenDuration"] ?? throw new NullReferenceException();

            var encodedKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(signingKey));
            var signingCredentials = new SigningCredentials(encodedKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimNames.UserId, user.Id.ToString()),
                new Claim(ClaimNames.Email, user.Email),
                new Claim(ClaimNames.Role, user.Role)
            };

            var issuedDate = DateTime.UtcNow;
            var expiresDate = issuedDate.AddMinutes(int.Parse(tokenDuration));
            var jwtToken = new JwtSecurityToken(issuer, audience, claims, DateTime.UtcNow, DateTime.UtcNow.AddMinutes(int.Parse(tokenDuration)), signingCredentials);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenModel = new SecurityToken(tokenHandler.WriteToken(jwtToken), issuedDate, expiresDate);
            return tokenModel;
        }

        
    }
}
