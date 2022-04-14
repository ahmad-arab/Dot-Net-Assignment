using Microsoft.AspNetCore.Mvc;
using Dot_Net_Assignment.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System;

namespace Dot_Net_Assignment.Controllers
{
    /// <summary>
    /// This Controller performs the following actions on <see cref="TodoItem"/>s:
    /// Get/GetAll/Create/Update/Delete
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles ="Admin,User")]
    public class TodoController : ControllerBase
    {
        /// <summary>
        /// The DBContext
        /// </summary>
        private readonly ApiContext _context;

        /// <summary>
        /// The Constructor
        /// </summary>
        /// <param name="context">Injects an <see cref="ApiContext"/> that that communicates with the database</param>
        public TodoController(ApiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all <see cref="TodoItem"/>s in the database
        /// All users are authorized to call this method
        /// </summary>
        /// <returns>returns a list of <see cref="TodoItem"/>s</returns>
        [HttpGet]
        [Route("getall")]
        public ActionResult<IEnumerable<TodoItem>> GetAll()
        {

            return _context.TodoItems;
        }
        
        /// <summary>
        /// Gets a specific <see cref="TodoItem"/>
        /// </summary>
        /// <param name="id">The Id of the <see cref="TodoItem"/> that is needed</param>
        /// <returns>The <see cref="TodoItem"/> that has the specifide Id, Status code Forbiddin if the suer is not authorized</returns>
        [HttpGet]
        [Route("get/{id}")]
        [Authorize(Roles ="Admin")]
        public ActionResult<TodoItem> Get(Guid id)
        {
            //get the needed todoItem
            var todoItem =  _context.TodoItems.FirstOrDefault(x => x.Id == id);

            //if todoItem == null then the needed todoItem doesn't exists
            if (todoItem == null)
                return NotFound();

            //return the wanted todoItem
            return todoItem;
        }

        /// <summary>
        /// Updates the specified <see cref="TodoItem"/>
        /// </summary>
        /// <param name="id">the Id of the <see cref="TodoItem"/> to be updated</param>
        /// <param name="item">the object that holds the updated properties that will replace the original properties of the specified <see cref="TodoItem"/></param>
        /// <returns>OK if all goes well, Notfound if not, Forbiddin if the user is not authorized</returns>
        [HttpPut]
        [Route("put/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id, TodoItem item)
        {
            //Get the specified todoItem
            var todoItem = _context.TodoItems.FirstOrDefault(x => x.Id == id);

            // If the todoItem is null then it doesn't exists
            if (todoItem == null)
                return NotFound();

            //update properties value
            todoItem.Title = item.Title;
            todoItem.Discrbtion = item.Discrbtion;
            todoItem.Date = item.Date;

            //Save changes to the database
            await _context.SaveChangesAsync();
            
            return Ok();
        }

        /// <summary>
        /// Creates ane <see cref="TodoItem"/>
        /// </summary>
        /// <param name="item">The <see cref="TodoItem"/> to be created</param>
        /// <returns>OK if all goes well, Forbiddin if the user is not authorized</returns>
        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(TodoItem item)
        {
            //The user does not specify the Id, we do
            item.Id = Guid.NewGuid();

            //Add the todoItem
            _context.TodoItems.Add(item);

            //Save changes to the database
            await _context.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// Deletes the specified <see cref="TodoItem"/>
        /// </summary>
        /// <param name="id">The id of the <see cref="TodoItem"/> to be deleted</param>
        /// <returns>OK if all goes well, Notfound if not, Forbiddin if the user is not authorized</returns>
        [HttpDelete]
        [Route("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            //Find the wanted todoItem 
            var todoItem = _context.TodoItems.FirstOrDefault(x => x.Id == id);

            //If the todoITem is null then it doesn't exists
            if (todoItem == null)
                return NotFound();

            //Remove the specified ITem
            _context.TodoItems.Remove(todoItem);

            //Save changes to the database
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
