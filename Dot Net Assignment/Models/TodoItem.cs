using System;

namespace Dot_Net_Assignment.Models
{
    /// <summary>
    /// Represnts a todo entry
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// The Id of the Todo entry
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// The date of the Todoentry
        /// </summary>
        public DateTimeOffset Date { get; set; }
        /// <summary>
        /// The title of the Todoentry
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The discrbtion of the Todoentry
        /// </summary>
        public string Discrbtion { get; set; }
    }
}
