using CommunityToolkit.Mvvm.Input;
using FastingFriend.Services.BaseService;

namespace FastingFriend.Features;

public partial class NewTimeslotPageViewModel : BasePageViewModel
{
    public NewTimeslotPageViewModel(IBaseService baseService) 
        : base(baseService)
    {
    }

    public DateTime StartDateTime { get; } = DateTime.Now;
    public DateTime EndDateTime { get; } = DateTime.Now.AddHours(1);

    [RelayCommand]
    private Task Confirm()
    {
        var newTimeSlot = new Timeslot(StartDateTime, EndDateTime);
        var parameters = new NavigationParameters { { NavigationConstants.NewTimeslot, newTimeSlot } };
        return NavigationService.GoBackAsync(parameters, true);  
    }

    [RelayCommand]
    private Task Cancel()
    {
        return NavigationService.GoBackAsync(true);   
    }
}