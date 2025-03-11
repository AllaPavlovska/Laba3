using System;
using System.Collections.Generic;
using System.Linq;

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

        // Тестуємо пошук записів за датою
        Console.WriteLine("\nЗаписи на 11 березня 2025:");
        var entriesByDate = schedule.GetEntriesByDate(DateTime.Parse("2025-03-11"));
        foreach (var entry in entriesByDate)
        {
            Console.WriteLine(entry);
        }

        // Тестуємо пошук записів за місцем
        Console.WriteLine("\nЗаписи у 'Кабінет 101':");
        var entriesByLocation = schedule.GetEntriesByLocation("Кабінет 101");
        foreach (var entry in entriesByLocation)
        {
            Console.WriteLine(entry);
        }
    }
}
