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
	        Task = Global.GetContactById(id);
        }

        public IActionResult OnPost(int id)
        {
	        var contact = Global.GetContactById(id);



            contact.Description = Task.Description;
            contact.DueDate = Task.DueDate;
            contact.IsCompleted = Task.IsCompleted;

            if (Task.IsCompleted)
            {
                contact.CompletionDate = DateTime.Now;
            } else 
            { 
                contact.CompletionDate = null; 
            }

            Global.SaveContactsToFile();
            return RedirectToPage("Index");
        }
    }
}

