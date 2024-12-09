using Microsoft.AspNetCore.Components;
using System.Timers;

namespace WebUI.Pages.User;
public partial class Countdown : ComponentBase, IDisposable
{
    //private System.Timers.Timer _timer = null!;
    //private int _secondsToRun = 0;

    //protected string Time { get; set; } = "00:00";

    //[Parameter]
    //public EventCallback TimerOut { get; set; }
    //[Parameter]
    //public Guid BillId { get; set; }

    //public void Start(int secondsToRun)
    //{
    //    _secondsToRun = secondsToRun;

    //    if (_secondsToRun > 0)
    //    {
    //        Time = TimeSpan.FromSeconds(_secondsToRun).ToString(@"mm\:ss");
    //        StateHasChanged();
    //        _timer.Start();
    //    }
    //}

    //public void Stop()
    //{
    //    _timer.Stop();
    //}

    //protected override void OnParametersSet()
    //{
    //    if (BillId != Guid.Empty)
    //    {
    //        _timer = new System.Timers.Timer(1000);
    //        _timer.Elapsed += OnTimedEvent;
    //        _timer.AutoReset = true;
    //    }

    //}

    //private async void OnTimedEvent(object? sender, ElapsedEventArgs e)
    //{
    //    _secondsToRun--;

    //    await InvokeAsync(() =>
    //    {
    //        Time = TimeSpan.FromSeconds(_secondsToRun).ToString(@"mm\:ss");
    //        StateHasChanged();
    //    });

    //    if (_secondsToRun <= 0)
    //    {
    //        _timer.Stop();
    //        await TimerOut.InvokeAsync();
    //    }
    //}

    //public void Dispose()
    //{
    //    _timer.Dispose();
    //}

    private System.Timers.Timer? _timer;
    private int _secondsToRun = 0;
    protected string Time { get; set; } = string.Empty;

    [Parameter]
    public EventCallback TimerOut { get; set; }

    [Parameter]
    public Guid BillId { get; set; }

    public void Start(int secondsToRun)
    {
        if (_timer == null)
        {
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
        }

        _secondsToRun = secondsToRun;
        _timer.Enabled = true;
    }

    protected override void OnParametersSet()
    {
        if (_timer == null)
        {
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
        }
    }

    private async void OnTimedEvent(object? sender, ElapsedEventArgs e)
    {
        if (_secondsToRun > 0)
        {
            _secondsToRun--;
            Time = TimeSpan.FromSeconds(_secondsToRun).ToString(@"mm\:ss");
            await InvokeAsync(StateHasChanged);
        }
        else
        {
            _timer?.Stop();
            await TimerOut.InvokeAsync();
        }
    }

    public void Stop()
    {
        _timer?.Stop();
    }

    public void Dispose()
    {
        if (_timer != null)
        {
            _timer.Elapsed -= OnTimedEvent;
            _timer.Dispose();
            _timer = null;
        }
    }
}
