using System;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using DocsvisionClientServer.Requests;
using Newtonsoft.Json;

namespace WpfViewApp.ViewModel.Launchers;

public class LaunchEmailHttp : ICommand
{
    private readonly ViewModel _vm;
    public LaunchEmailHttp(ViewModel vm)
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
            var endpoint = new Uri("https://localhost:8002/email/post");
            CreateEmailRequest email = new CreateEmailRequest()
            {
                Name = _vm.TB1,
                ReceiverId = _vm.TB3,
                SenderId = _vm.TB4,
                Content = _vm.TB2
            };

            var emailJson = JsonConvert.SerializeObject(email);
            var payload = new StringContent(emailJson, Encoding.UTF8, "application/json");
            var result = client.PostAsync(endpoint, payload).Result.Content.ReadAsStringAsync().Result;
            _vm.LTB3 = result;
        }
    }

    public event EventHandler? CanExecuteChanged;
}