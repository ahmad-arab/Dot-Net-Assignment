using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dot_Net_Assignment.Authentication
{
    /// <summary>
    /// Defaines custom clame types to be included in returned tokens
    /// </summary>
    public static class CustomClameTypes
    {
        /// <summary>
        /// First name of the user
        /// </summary>
        public static readonly string FirstName = "FirstName";
        /// <summary>
        /// Last name of the user
        /// </summary>
        public static readonly string LastName = "LastName";
        /// <summary>
        /// Email address of the user
        /// </summary>
        public static readonly string Email = "Email";
        /// <summary>
        /// if "true" the user is active
        /// </summary>
        public static readonly string IsActive = "IsActive";
    }
}
