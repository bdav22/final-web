using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PhoneBookWeb;

public class Contact
{
    public int Id { get; set; }

    [Display(Name = "Task Description:")]
    public string Description { get; set; }

    [Display(Name = "Due Date:")]
    public DateTime DueDate { get; set; }

    [Display(Name = "Is Completed:")]
    public bool IsCompleted { get; set; }

    [Display(Name = "Completion Date:")]
    public DateTime? CompletionDate { get; set; }

    public static readonly List<SelectListItem> Genders = new()
    {
        new() { Value = "M", Text = "Male" },
        new() { Value = "F", Text = "Female" },
        new() { Value = "O", Text = "Other" },
    };
}
