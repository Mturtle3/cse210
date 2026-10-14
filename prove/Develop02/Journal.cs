
using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is empty.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void FindEntriesByDate(string searchDate)
    {
        bool found = false;

        foreach (Entry entry in _entries)
        {
            if (entry.GetDate() == searchDate)
            {
                entry.Display();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No entries found for that date.");
        }
    }

    public void Save()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(
                    $"{entry.GetDate()}|{entry.GetPrompt()}|{entry.GetResponse()}"
                );
            }
        }

        Console.WriteLine("Journal saved.");
    }

    public void Load()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        List<Entry> loadedEntries = new List<Entry>();

        foreach (string line in File.ReadAllLines(filename))
        {
            string[] parts = line.Split('|', 3);

            if (parts.Length == 3)
            {
                Entry entry = new Entry(parts[0], parts[1], parts[2]);
                loadedEntries.Add(entry);
            }
        }

        _entries = loadedEntries;

        Console.WriteLine("Journal loaded.");
    }
}
