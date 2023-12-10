using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaskManager.Pages
{
    public class DeleteModel : PageModel
    {
        public Task Task { get; set; }

        public void OnGet(int id)
        {
            Task = Global.GetTaskById(id);
        }

        public IActionResult OnPost(int id)
        {
            Global.DeleteTaskById(id);
            return RedirectToPage("Index");
        }
    }
}
