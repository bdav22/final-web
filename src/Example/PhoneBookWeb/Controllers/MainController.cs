using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MainController : ControllerBase
    {
        public List<Task> GetContacts() => Global.Contacts;

        public string Add(
            string description,
            DateTime dueDate,
            Boolean isCompleted,
            DateTime completionDate
           )
        {
            Global.Add(new Task
            {
                Description = description,
                DueDate = dueDate,
                IsCompleted = isCompleted,
                CompletionDate = completionDate,
                
            });
            return "Success";
        }
    }
}