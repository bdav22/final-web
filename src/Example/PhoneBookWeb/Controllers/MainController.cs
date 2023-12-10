using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainController : ControllerBase
    {
        //api for getting all tasks
        [HttpGet("[action]")]
        public List<Task> GetTasks() => Global.Tasks;

     

        //api for getting completed tasks
        [HttpGet("[action]")]
        public IActionResult GetCompletedTasks()
        {
            var completedTasks = Global.Tasks.FindAll(task => task.IsCompleted);

            return Ok(completedTasks);
        }

        //api for getting task by id
        [HttpGet("[action]/{id}")]
        public IActionResult GetTaskById(int id)
        {
            var task = Global.GetContactById(id);

            if (task == null)
            {
                return NotFound(); 
            }

            return Ok(task);
        }

        [HttpPut("[action]/{id}/description")]
        public IActionResult ChangeTaskDescription(int id, [FromBody] string newDescription)
        {
            var task = Global.GetContactById(id);

            if (task == null)
            {
                return NotFound(); 
            }

            task.Description = newDescription;
            Global.SaveContactsToFile();

            return Ok(task);
        }

        [HttpPut("[action]/{id}/complete")]
        public IActionResult MarkTaskAsCompleted(int id)
        {
            var task = Global.GetContactById(id);

            if (task == null)
            {
                return NotFound(); 
            }

            task.IsCompleted = true;
            task.CompletionDate = DateTime.Now;
            Global.SaveContactsToFile();

            return Ok(task);
        }
    }
}