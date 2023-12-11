using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskManager;

namespace TaskManager.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Task Task { get; set; }

        public void OnGet(int id)
        {
	        Task = Global.GetTaskById(id);
        }

        public IActionResult OnPost(int id)
        {
	        var task = Global.GetTaskById(id);



            task.Description = Task.Description;
            task.DueDate = Task.DueDate;
            task.IsCompleted = Task.IsCompleted;

            if (Task.IsCompleted)
            {
                task.CompletionDate = DateTime.Now;
            } else 
            { 
                task.CompletionDate = null; 
            }

            Global.GetTaskById(id);
            return RedirectToPage("Index");
        }
    }
}

