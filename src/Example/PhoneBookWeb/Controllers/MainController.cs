using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainController : ControllerBase
    {
        [HttpGet("[action]")]
        public List<Task> GetTasks() => Global.Tasks;

        [HttpPost("[action]")]
        public IActionResult Add(
            [FromBody] Task newTask
        )
        {
            Global.Add(newTask);
            return Ok("Success");
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetTaskById(int id)
        {
            var task = Global.GetContactById(id);

            if (task == null)
            {
                return NotFound(); // Return 404 if the task with the given ID is not found
            }

            return Ok(task);
        }

        [HttpPut("[action]/{id}/description")]
        public IActionResult ChangeTaskDescription(int id, [FromBody] string newDescription)
        {
            var task = Global.GetContactById(id);

            if (task == null)
            {
                return NotFound(); // Return 404 if the task with the given ID is not found
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
                return NotFound(); // Return 404 if the task with the given ID is not found
            }

            task.IsCompleted = true;
            task.CompletionDate = DateTime.Now;
            Global.SaveContactsToFile();

            return Ok(task);
        }
    }
}