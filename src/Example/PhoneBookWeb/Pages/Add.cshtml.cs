using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaskManager.Pages
{
    public class AddModel : PageModel
    {
		[BindProperty]
        public Task Task { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            //if (Task.Email.Contains("@gmail.com"))
            //{
            //    ModelState.AddModelError(string.Empty, "Gmail is not supported");
            //    return Page();
            //}



            Global.Add(Task);

            return RedirectToPage("Index");
        }
    }
}
