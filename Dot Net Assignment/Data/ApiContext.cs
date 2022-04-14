using Microsoft.EntityFrameworkCore;
using Dot_Net_Assignment.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Dot_Net_Assignment
{
    /// <summary>
    /// The DBContext for the API
    /// </summary>
    public class ApiContext : DbContext
    {
        /// <summary>
        /// The Constructoe
        /// </summary>
        /// <param name="options"></param>
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// The table that will store <see cref="TodoItem"/>s
        /// </summary>
        public DbSet<TodoItem> TodoItems { get; set; }

        /// <summary>
        /// The table that will store <see cref="Users"/>s
        /// usually Users table and all tables related to the authentication proccess would be stored in a different database
        /// but for the purpose of this assignment i store it in the same database
        /// </summary>
        public DbSet<Users> Users { get; set; }
    }
}
