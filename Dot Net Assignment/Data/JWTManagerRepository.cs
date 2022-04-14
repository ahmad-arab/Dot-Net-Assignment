using Dot_Net_Assignment.Interfaces;
using Dot_Net_Assignment.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Dot_Net_Assignment.Authentication;

namespace Dot_Net_Assignment.Data
{
	/// <summary>
	/// Authenticates <see cref="Users"/> and generates tokens
	/// </summary>
	public class JWTManagerRepository : IJWTManagerRepository
	{
		/// <summary>
		/// App Configuration
		/// </summary>
		private readonly IConfiguration iconfiguration;
		/// <summary>
		/// The DBContext
		/// </summary>
		private readonly ApiContext _context;

		/// <summary>
		/// The Constructor
		/// </summary>
		/// <param name="iconfiguration">Injects app Configuration</param>
		/// <param name="context">Injects the DBContext</param>
		public JWTManagerRepository(IConfiguration iconfiguration, ApiContext context)
		{
			this.iconfiguration = iconfiguration;
			_context = context;
		}

		/// <summary>
		/// Does the primary job of authenticating users and generating tokens
		/// </summary>
		/// <param name="users">The loged in user</param>
		/// <returns>null if not authorized, a token otherwise</returns>
		public Tokens Authenticate(Users users)
		{
			//Find the user with the correct credentials
			var u = _context.Users.FirstOrDefault(x => x.Username == users.Username && x.Password == users.Password);
			//If null then it doesn't exists
			if (u == null)
			{
				return null;
			}

			// Else we generate JSON Web Token
			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				//Adds the clames to the token
				Subject = new ClaimsIdentity(new Claim[]
			    {
				  	new Claim(CustomClameTypes.FirstName, u.FirstName),
					new Claim(CustomClameTypes.LastName, u.LastName),
					new Claim(CustomClameTypes.Email, u.Email),
					new Claim(CustomClameTypes.IsActive, u.IsActive.ToString(), ClaimValueTypes.Boolean),
					new Claim(ClaimTypes.Role, u.Roles),
				}),

				//The token expires after 10 minutes
				Expires = DateTime.UtcNow.AddMinutes(10),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
			};
			// Create the token descibed by the tokenDescriptor
			var token = tokenHandler.CreateToken(tokenDescriptor);

			//return the generated token
			return new Tokens { Token = tokenHandler.WriteToken(token) };
		}
	}
}
