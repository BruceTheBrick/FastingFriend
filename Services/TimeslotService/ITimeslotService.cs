namespace FastingFriend.Services;

public interface ITimeslotService
{
    public void AddTimeslot(Timeslot timeslot);
    public IList<Timeslot> GetAllTimeslots();
}