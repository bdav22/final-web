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
            contact.CompletionDate = Task.CompletionDate;
            Global.SaveContactsToFile();
            return RedirectToPage("Index");
        }
    }
}

