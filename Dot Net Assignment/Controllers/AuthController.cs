using Dot_Net_Assignment.Interfaces;
using Dot_Net_Assignment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dot_Net_Assignment.Controllers
{
	/// <summary>
	/// Controls the authentication logic of the API
	/// </summary>
	[Route("[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IJWTManagerRepository _jWTManager;

		/// <summary>
		/// The Constructor
		/// </summary>
		/// <param name="jWTManager">Injects a <see cref="IJWTManagerRepository"/> object that will handle the authentication and generate tokens</param>
		public AuthController(IJWTManagerRepository jWTManager)
		{
			this._jWTManager = jWTManager;
		}

		/// <summary>
		/// Authenticates users and generates tokens
		/// </summary>
		/// <param name="usersdata">includs the username and password writtin in this format: {"Username":"[user]","Password":"[password]"}</param>
		/// <returns>returns a token</returns>
		[HttpPost]
		public IActionResult Authenticate(Users usersdata)
		{
			var token = _jWTManager.Authenticate(usersdata);

			//if the token == null then the user has'nt been authorized
			//so we return status code 401 
			if (token == null)
			{
				return Unauthorized();
			}

			// returns the generated Token
			return Ok(token);
		}
	}
}
