using Core.Entities;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace Core.Utilities.Security.JWT
{
	public class JwtHelper : ITokenHelper
	{
		private IConfiguration Configuration { get; }
		private readonly TokenOptions? _tokenOptions;
		private DateTime _expires;

		public JwtHelper(IConfiguration configuration)
		{
			Configuration = configuration;
			_tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
		}

		public AccessToken CreateToken(User user, List<Role> roles)
		{
			_expires = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
			var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
			var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
			var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, roles);
			var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
			var token = jwtSecurityTokenHandler.WriteToken(jwt);

			return new AccessToken
			{
				Token = token,
				Expiration = _expires
			};

		}

		public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
			SigningCredentials signingCredentials, List<Role> roles)
		{
			var jwt = new JwtSecurityToken(
				issuer: tokenOptions.Issuer,
				audience: tokenOptions.Audience,
				expires: _expires,
				notBefore: DateTime.Now,
				claims: SetClaims(user, roles),
				signingCredentials: signingCredentials
			);
			return jwt;
		}

		private IEnumerable<Claim> SetClaims(User user, List<Role> roles)
		{
			var claims = new List<Claim>();
			claims.AddNameIdentifier(user.Id.ToString());
			claims.AddEmail(user.Email);
			claims.AddName($"{user.FirstName} {user.LastName}");
			claims.AddRoles(roles.Select(c => c.Name).ToArray());

			return claims;
		}
	}
}
