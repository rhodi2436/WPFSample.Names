using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Names.ExConsole;

[ObservableObject]
public partial class Man
{
    [ObservableProperty]
    [property: My("Hello!")]
    private string _name = string.Empty;

    [ObservableProperty]
    private string _description = string.Empty;

    [ObservableProperty]
    private int _count = 0;

    private TaskNotifier _manTask;

    public Task ManTask
    {
        get => _manTask;
        set => SetPropertyAndNotifyOnCompletion(ref _manTask, value);
    }

    public Man(Task manTask)
    {
        ManTask = manTask;
    }

    [RelayCommand]
    public void Increase(int i)
    {
        Count += i;
    }

    partial void OnCountChanged(int oldValue, int newValue)
    {
        Console.WriteLine($"From Mvvm: Count has changed. -> {Count}");
        var attr = this.GetType()!.GetProperty("Name")!.GetCustomAttributes(typeof(MyAttribute), true).FirstOrDefault();
        MyAttribute? mattr = attr as MyAttribute;
        Console.WriteLine($"From MyAttr: {mattr?.Description}");
    }
}
