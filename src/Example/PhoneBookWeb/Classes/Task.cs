using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TaskManager;

public class Task
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

   
}
