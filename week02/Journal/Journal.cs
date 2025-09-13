using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine("Date,Prompt,Response");

            foreach (Entry entry in _entries)
            {
                // code before trying csv.  outputFile.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}"); 

                string date = EscapeForCsv(entry._date);
                string prompt = EscapeForCsv(entry._prompt);
                string response = EscapeForCsv(entry._response);

                outputFile.WriteLine($"{date},{prompt},{response}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = ParseCsvLine(line);

            Entry newEntry = new Entry();
            newEntry._date = parts[0];
            newEntry._prompt = parts[1];
            newEntry._response = parts[2];

            _entries.Add(newEntry);
        }
    }
    private string EscapeForCsv(string field)
    {
        if (field.Contains(",") || field.Contains("\""))
        {
            field = "\"" + field.Replace("\"", "\"\"") + "\"";
        }
        return field;
    }

    private string[] ParseCsvLine(string line)
    {
        List<string> fields = new List<string>();
        bool insideQuotes = false;
        string currentField = "";

        foreach (char c in line)
        {
            if (c == '"' && !insideQuotes)
            {
                insideQuotes = true;
            }
            else if (c == '"' && insideQuotes)
            {
                insideQuotes = false;
            }
            else if (c == ',' && !insideQuotes)
            {
                fields.Add(currentField);
                currentField = "";
            }
            else
            {
                currentField += c;
            }
        }
        fields.Add(currentField);

        return fields.ToArray();
    }
}