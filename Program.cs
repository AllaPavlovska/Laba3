using System;

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
        return $"{StartTime} - {EndTime} | {Location} | {Comment}";
    }
}
