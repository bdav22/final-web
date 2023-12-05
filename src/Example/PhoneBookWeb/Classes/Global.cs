﻿using Newtonsoft.Json;

namespace TaskManager;

static class Global
{
	private static int s_id;

    public static string Root { get; private set; }

    public static List<Task> Contacts = new();

    public static void Add(Task contact)
    {
	    s_id++;
        contact.Id = s_id;
        Contacts.Add(contact);
        SaveContactsToFile();
    }

    public static void Init(string root)
    {
        Root = root;

        var filePath = Path.Combine(Root, "Contacts.json");
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            Contacts = JsonConvert.DeserializeObject<List<Task>>(json)!;
            s_id = Contacts.Max(c => c.Id);
        }
    }

    public static void SaveContactsToFile()
    {
        var json = JsonConvert.SerializeObject(Contacts, Formatting.Indented);
        var filePath = Path.Combine(Root, "Contacts.json");

        File.WriteAllText(filePath, json);
    }

    public static Task GetContactById(int id)
    {
	    return Contacts.Single(c => c.Id == id);
    }

    public static void DeleteContactById(int id)
    {
        Contacts.RemoveAll(c => c.Id == id);
        SaveContactsToFile();
    }
}
