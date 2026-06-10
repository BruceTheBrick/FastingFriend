using System.Text.Json;
namespace FastingFriend.Services;

[SingletonService]
public class TimeslotService : ITimeslotService
{
    private readonly IPreferences _preferences;
    public TimeslotService(IPreferences preferences)
    {
        _preferences = preferences;
    }

    public void AddTimeslot(Timeslot timeslot)
    {
        var timeslots = GetAllTimeslots();
        timeslots.Add(timeslot);
        _preferences.Set(PreferencesConstants.Timeslots, JsonSerializer.Serialize(timeslots));
    }

    public IList<Timeslot> GetAllTimeslots()
    {
        try
        {
            var timeslotsString = _preferences.Get(PreferencesConstants.Timeslots, string.Empty);
            if (string.IsNullOrEmpty(timeslotsString))
            {
                return new List<Timeslot>();
            }
            
            var timeslotList = JsonSerializer.Deserialize<List<Timeslot>>(timeslotsString);
            return timeslotList ?? [];
        }
        catch (Exception e)
        {
            return new List<Timeslot>();
        }
    }
}