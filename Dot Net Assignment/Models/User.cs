using System;

namespace Dot_Net_Assignment.Models
{
    /// <summary>
    /// Represents Users of the API
    /// </summary>
    public class Users
    {
        /// <summary>
        /// The User's Id
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// The User's Username, used at log in
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// The User's Password, used at log in
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// The User's FirstName
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The User's LastName
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// The User's Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Is the user currently active
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// The roles of this user
        /// </summary>
        public string Roles { get; set; }
    }
}
