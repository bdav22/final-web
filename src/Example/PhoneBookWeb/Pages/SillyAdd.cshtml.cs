using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PhoneBookWeb.Pages
{
    public class SillyAddModel : PageModel
    {
        public IActionResult OnGet(string desc, DateTime dueDate, Boolean isCompleted, DateTime completionDate)
        {
            Global.Add(new Contact
            {
                Description = desc,
                DueDate = dueDate,
                IsCompleted = isCompleted,
                CompletionDate = completionDate
            });

            return RedirectToPage("Index");
        }
    }
}
