namespace Dot_Net_Assignment.Models
{
    /// <summary>
    /// Represents the token that will be used to authorize users
    /// </summary>
    public class Tokens
    {
        /// <summary>
        /// The token value
        /// </summary>
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
