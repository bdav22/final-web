using Newtonsoft.Json;

namespace TaskManager;

static class Global
{
    private static int s_id;

    public static string Root { get; private set; }

    public static List<Task> Tasks = new();

    public static void Add(Task task)
    {
        //if tasks are empty
        if (Tasks.Count == 0)
        {
            //start count at 1
            s_id = 1;
        } 
        else
        {
            //else couunt up from the max number 
            s_id = Tasks.Max(t => t.Id) + 1;

        }
        task.Id = s_id;
        Tasks.Add(task);
        //GetTaskById();
    }

    //method to init
    public static void Init(string root)
    {
        Root = root;
        s_id = 0;
        var filePath = Path.Combine(Root, "Tasks.json");
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            Tasks = JsonConvert.DeserializeObject<List<Task>>(json)!;

        }
        else
        {
            s_id = 1;
        }
    }


    public static Task GetTaskById(int id)
    {
        var task = Tasks.FirstOrDefault(c => c.Id == id);
        return task;
    }

    //deletes task by id
    public static void DeleteTaskById(int id)
    {
        Tasks.RemoveAll(c => c.Id == id);

        if (Tasks.Count > 0)
        {
            
            s_id = Tasks.Max(c => c.Id);
        }
        else
        {
            
            s_id = 0;
        }

        GetTaskById(id);
    }

}
