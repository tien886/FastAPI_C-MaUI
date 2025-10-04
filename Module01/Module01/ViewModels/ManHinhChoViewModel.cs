using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Module01.Models;
using System.Diagnostics;
using System.Net.Http.Json;
namespace Module01.ViewModels;

public partial class ManHinhChoViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    public ManHinhChoViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    [ObservableProperty]
    bool isCalculated = false;
    [ObservableProperty]
    double ketqua = 0;
    [ObservableProperty]
    string pheptinh;
    [ObservableProperty]
    string so1;
    [ObservableProperty]
    string so2;
    [ObservableProperty]
    string so3;
    [ObservableProperty]
    string so4;

    [RelayCommand]
    public async Task Enter()
    {
        Console.WriteLine("HI");

        var client = new HttpClient();
        var inputdata = new Number
        {
            arr = new List<int>
{
            int.TryParse(So1, out var s1) ? s1 : 0,
            int.TryParse(So2, out var s2) ? s2 : 0,
            int.TryParse(So3, out var s3) ? s3 : 0,
            int.TryParse(So4, out var s4) ? s4 : 0
},
            operation = Pheptinh
        };
        var response = await client.PostAsJsonAsync("http://127.0.0.1:8000/execute_math", inputdata);
        if (response.IsSuccessStatusCode)
        {
            var resultObj = await response.Content.ReadFromJsonAsync<CalculationResult>();
            IsCalculated = true;
            Ketqua = resultObj.result;
        }
        Debug.WriteLine("HI");

    }
}
