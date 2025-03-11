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
}
