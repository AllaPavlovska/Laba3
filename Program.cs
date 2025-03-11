using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

class ScheduleEntry
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Location { get; set; }
    public string Comment { get; set; }

    public ScheduleEntry(DateTime start, DateTime end, string location, string comment)
    {
        StartTime = start;
        EndTime = end;
        Location = location;
        Comment = comment;
    }

    public override string ToString()
    {
        return $"{StartTime:HH:mm} - {EndTime:HH:mm} | {Location} | {Comment}";
    }
}

class Schedule
{
    private List<ScheduleEntry> entries = new List<ScheduleEntry>();

    public void AddEntry(ScheduleEntry entry)
    {
        entries.Add(entry);
    }

    public void RemoveEntry(ScheduleEntry entry)
    {
        entries.Remove(entry);
    }

    public void Display()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    // Додаємо методи пошуку записів
    public List<ScheduleEntry> GetEntriesByDate(DateTime date)
    {
        return entries.Where(e => e.StartTime.Date == date.Date).ToList();
    }

    public List<ScheduleEntry> GetEntriesByLocation(string location)
    {
        return entries.Where(e => e.Location == location).ToList();
    }

    // Метод для серіалізації об'єкта Schedule в JSON файл
    public void SaveToJson(string filePath)
    {
        string jsonString = JsonSerializer.Serialize(entries);
        File.WriteAllText(filePath, jsonString);
    }

    // Метод для десеріалізації JSON файлу в об'єкт Schedule
    public void LoadFromJson(string filePath)
    {
        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            entries = JsonSerializer.Deserialize<List<ScheduleEntry>>(jsonString);
        }
        else
        {
            Console.WriteLine("Файл не знайдено.");
        }
    }
}

class Program
{
    static void Main()
    {
        Schedule schedule = new Schedule();

        schedule.AddEntry(new ScheduleEntry(DateTime.Parse("2025-03-11 09:00"), DateTime.Parse("2025-03-11 10:00"), "Кабінет 101", "Лекція з програмування"));
        schedule.AddEntry(new ScheduleEntry(DateTime.Parse("2025-03-11 11:00"), DateTime.Parse("2025-03-11 12:00"), "Аудиторія 5", "Практика з фізики"));

        Console.WriteLine("Розклад на 11 березня 2025:");
        schedule.Display();

        // Тестуємо серіалізацію
        string filePath = "schedule.json";
        schedule.SaveToJson(filePath);
        Console.WriteLine("\nРозклад збережено у файл schedule.json.");

        // Тестуємо десеріалізацію
        Schedule loadedSchedule = new Schedule();
        loadedSchedule.LoadFromJson(filePath);

        Console.WriteLine("\nЗавантажений розклад з файлу:");
        loadedSchedule.Display();
    }
}
