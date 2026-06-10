namespace FastingFriend.Services;

public class Timeslot
{
    public Timeslot()
    {
    }

    public Timeslot(DateTime startTime, DateTime endTime)
    {
        StartTime = startTime;
        EndTime = endTime;
    }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}