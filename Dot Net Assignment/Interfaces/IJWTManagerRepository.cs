using Dot_Net_Assignment.Models;

namespace Dot_Net_Assignment.Interfaces
{
    /// <summary>
	/// Authenticates <see cref="Users"/> and generates tokens
	/// </summary>
    public interface IJWTManagerRepository
    {
        /// <summary>
		/// Does the primary job of authenticating users and generating tokens
		/// </summary>
		/// <param name="users">The loged in user</param>
		/// <returns>null if not authorized, a token otherwise</returns>
        Tokens Authenticate(Users users);
    }
}
