using Microsoft.Extensions.Options;
using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using KVSolution.Common.Config;
using KVSolution.PIM.Application.User;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace KVSolution.PIM.Infrastructure.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly TokenConfig _tokenConfig;
        public AuthenticationService(IUserService userService, IOptions<TokenConfig> tokenConfig)
        {
            _userService = userService;
            _tokenConfig = tokenConfig.Value;
        }

        public async Task<string> IsAuthenticatedAsync(TokenRequest request)
        {
            var token = string.Empty;
            if ( !await _userService.IsValidUserAsync(request.Username, request.Password))
                return string.Empty;

            var claim = new[]
            {
                new Claim(ClaimTypes.Name, request.Username)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfig.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                _tokenConfig.Issuer,
                _tokenConfig.Audience,
                claim,
                expires: DateTime.Now.AddMinutes(_tokenConfig.AccessExpiration),
                signingCredentials: credentials
            );
            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return token;
        }
    }
}
