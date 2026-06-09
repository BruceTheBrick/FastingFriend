using CommunityToolkit.Mvvm.ComponentModel;
using FastingFriend.Services.BaseService;

namespace FastingFriend.Features;

public partial class DashboardPageViewModel : BasePageViewModel
{
    private readonly ITimeslotService _timeslotService;
    public DashboardPageViewModel(
        ITimeslotService timeslotService, 
        IBaseService baseService) 
        : base(baseService)
    {
        _timeslotService = timeslotService;
    }

    [ObservableProperty] private List<Timeslot> _timeslots;

    public override void Initialize(INavigationParameters parameters)
    {
        base.Initialize(parameters);    
        Timeslots = _timeslotService.GetAllTimeslots().ToList();
    }
}