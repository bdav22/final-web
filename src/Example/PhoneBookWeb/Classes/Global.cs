using Newtonsoft.Json;

namespace TaskManager;

static class Global
{
    private static int s_id;

    public static string Root { get; private set; }

    public static List<Task> Tasks = new();

    public static void Add(Task task)
    {

        s_id++;
        task.Id = s_id;
        Tasks.Add(task);
        SaveContactsToFile();
    }

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
            Tasks = new List<Task>();
            s_id = 1;
        }
    }

    public static void SaveContactsToFile()
    {
        var json = JsonConvert.SerializeObject(Tasks, Formatting.Indented);
        var filePath = Path.Combine(Root, "Tasks.json");

        File.WriteAllText(filePath, json);
    }

    public static Task GetContactById(int id)
    {
        var task = Tasks.SingleOrDefault(c => c.Id == id);
        return task;
    }
    public static void DeleteContactById(int id)
    {
        var task = Tasks.SingleOrDefault(c => c.Id == id);
        if (task != null)
        {
            Tasks.Remove(task);
            SaveContactsToFile();
        }
    }
}
