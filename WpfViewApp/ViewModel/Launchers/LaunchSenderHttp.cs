using System;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using DocsvisionClientServer.Requests;
using Newtonsoft.Json;

namespace WpfViewApp.ViewModel.Launchers;

public class LaunchSenderHttp : ICommand
{
    private readonly ViewModel _vm;
    public LaunchSenderHttp(ViewModel vm)
    {
        _vm = vm;
    }
    
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        using (var client = new HttpClient())
        {
            var endpoint = new Uri("https://localhost:8002/sender/post");
            Random random = new Random();
            CreateSenderRequest sender = new CreateSenderRequest()
            {
                Name = "Name" + random.Next(0, 101)
            };

            var senderJson = JsonConvert.SerializeObject(sender);
            var payload = new StringContent(senderJson, Encoding.UTF8, "application/json");
            var result = client.PostAsync(endpoint, payload).Result.Content.ReadAsStringAsync().Result;
            _vm.LTB2 = result;
        }
    }

    public event EventHandler? CanExecuteChanged;
}