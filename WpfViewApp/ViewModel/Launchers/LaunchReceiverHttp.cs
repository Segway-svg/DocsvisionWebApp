using System;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using DocsvisionClientServer.Requests;
using Newtonsoft.Json;

namespace WpfViewApp.ViewModel.Launchers;

public class LaunchReceiverHttp : ICommand
{
    private readonly ViewModel _vm;
    public LaunchReceiverHttp(ViewModel vm)
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
            var endpoint = new Uri("https://localhost:8002/receiver/post");
            Random random = new Random();
            CreateReceiverRequest sender = new CreateReceiverRequest()
            {
                Name = "Name" + random.Next(0, 101)
            };

            var receiverJson = JsonConvert.SerializeObject(sender);
            var payload = new StringContent(receiverJson, Encoding.UTF8, "application/json");
            var result = client.PostAsync(endpoint, payload).Result.Content.ReadAsStringAsync().Result;
            _vm.LTB1 = result;
        }
    }

    public event EventHandler? CanExecuteChanged;
}