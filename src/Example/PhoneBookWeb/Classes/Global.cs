using Newtonsoft.Json;

namespace TaskManager;

static class Global
{
	private static int s_id;

    public static string Root { get; private set; }

    public static List<Task> Tasks = new();

    public static void Add(Task contact)
    {
	    s_id++;
        contact.Id = s_id;
        Tasks.Add(contact);
        SaveContactsToFile();
    }

    public static void Init(string root)
    {
        Root = root;

        var filePath = Path.Combine(Root, "Tasks.json");
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            Tasks = JsonConvert.DeserializeObject<List<Task>>(json)!;
            s_id = Tasks.Max(c => c.Id);
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
	    return Tasks.Single(c => c.Id == id);
    }

    public static void DeleteContactById(int id)
    {
        Tasks.RemoveAll(c => c.Id == id);
        SaveContactsToFile();
    }
}
