using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhoneBookWeb;

namespace PhoneBookWeb.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Contact Contact { get; set; }

        public void OnGet(int id)
        {
	        Contact = Global.GetContactById(id);
        }

        public IActionResult OnPost(int id)
        {
	        var contact = Global.GetContactById(id);

            contact.Description = Contact.Description;
            contact.DueDate = Contact.DueDate;
            contact.IsCompleted = Contact.IsCompleted;
            contact.CompletionDate = Contact.CompletionDate;
            Global.SaveContactsToFile();
            return RedirectToPage("Index");
        }
    }
}

