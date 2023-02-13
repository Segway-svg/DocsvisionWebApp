using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WpfViewApp.ViewModel.Launchers;

namespace WpfViewApp.ViewModel;

public class ViewModel : INotifyPropertyChanged
{
    private string _ltb1;
    private string _ltb2;
    private string _ltb3;
    
    private string _tb1;
    private string _tb2;
    private Guid _tb3;
    private Guid _tb4;
    public ICommand LaunchEmailHttp { get; set; }
    public ICommand LaunchSenderHttp { get; set; }
    public ICommand LaunchReceiverHttp { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;
    
    public ViewModel()
    {
        LaunchEmailHttp = new LaunchEmailHttp(this);
        LaunchSenderHttp = new LaunchSenderHttp(this);
        LaunchReceiverHttp = new LaunchReceiverHttp(this);
    }
    
    public string LTB1
    {
        get => _ltb1;
        set
        {
            if (value == _ltb1) return;
            _ltb1 = value;
            OnPropertyChanged();
        }
    }

    public string LTB2
    {
        get => _ltb2;
        set
        {
            if (value == _ltb2) return;
            _ltb2 = value;
            OnPropertyChanged();
        }
    }
    
    public string LTB3
    {
        get => _ltb3;
        set
        {
            if (value == _ltb3) return;
            _ltb3 = value;
            OnPropertyChanged();
        }
    }
    
    public string TB1
    {
        get => _tb1;
        set
        {
            if (value == _tb1) return;
            _tb1 = value;
            OnPropertyChanged();
        }
    }

    public string TB2
    {
        get => _tb2;
        set
        {
            if (value == _tb2) return;
            _tb2 = value;
            OnPropertyChanged();
        }
    }
    
    public Guid TB3
    {
        get => _tb3;
        set
        {
            if (value == _tb3) return;
            _tb3 = value;
            OnPropertyChanged();
        }
    }
    
    public Guid TB4
    {
        get => _tb4;
        set
        {
            if (value == _tb4) return;
            _tb4 = value;
            OnPropertyChanged();
        }
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}