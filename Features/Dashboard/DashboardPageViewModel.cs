using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        LoadTimeslots();
    }

    public override void OnNavigatedTo(INavigationParameters parameters)
    {
        base.OnNavigatedTo(parameters);
        if (parameters.TryGetValue<Timeslot>(NavigationConstants.NewTimeslot, out var newTimeSlot))
        {
            AddNewTimeslot(newTimeSlot);
        }
    }

    [RelayCommand]
    private async Task AddNewTimeslot()
    {
        var t = await NavigationService.NavigateAsync(Routes.NewTimeslotPage, true); 
    }

    private void AddNewTimeslot(Timeslot newTimeslot)
    {
        _timeslotService.AddTimeslot(newTimeslot);
        LoadTimeslots();
    }

    private void LoadTimeslots()
    {
        Timeslots = _timeslotService.GetAllTimeslots().ToList();
    }
}