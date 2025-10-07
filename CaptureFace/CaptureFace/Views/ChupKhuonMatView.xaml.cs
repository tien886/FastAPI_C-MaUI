using CaptureFace.Models;
using CaptureFace.ViewModels;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CaptureFace.Views;

public partial class ChupKhuonMatView : Popup
{
    string saveFolderPath;
    public ChupKhuonMatView(ChupKhuonMatViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		vm.SetCurrentPopup(this);
        string picturesPath = @"E:\UIT_AUTUMN2025-2026\IT008\FastAPI_C#MaUI\CaptureFace\CaptureFace\Resources\Images";
        saveFolderPath = Path.Combine(picturesPath, "MyAppPhotos");

        Directory.CreateDirectory(saveFolderPath);
    }

    private async void CaptureImageClicked(object sender, EventArgs e)
    {
        await Camera.CaptureImage(CancellationToken.None);
        Debug.WriteLine("HIII");
    }

    private void Camera_MediaCaptured(object sender, MediaCapturedEventArgs e)
    {
        var vm = BindingContext as ChupKhuonMatViewModel;
        var encodedstring = "";
        Debug.WriteLine("HI");
        // other gate for requirement of dispatcher 
        //if (Dispatcher.IsDispatchRequired)
        //{
        //    string fileName = $"{vm.MSSV}.jpg";
        //    string filePath = Path.Combine(saveFolderPath, fileName);
        //    using var fileStream = File.Create(filePath);
        //    e.Media.CopyTo(fileStream);
        //    Debug.WriteLine(filePath);
        //    try
        //    {
        //        var encodedstring = EncodeImageToBase64(filePath);
        //        Debug.WriteLine(encodedstring);
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.ToString());
        //    }
        //}
        try
        {
            string fileName = $"{vm.MSSV}.jpg";
            string filePath = Path.Combine(saveFolderPath, fileName);
            // easy meet the error open the opened file at the same time
            // add a block in using to end the open file action
            using (var fileStream = File.Create(filePath))
            {
                e.Media.CopyTo(fileStream);
            } 
            // block open file end
            Debug.WriteLine(filePath);
            try
            {
                encodedstring = EncodeImageToBase64(filePath);
                Debug.WriteLine($"base64string of image {vm.MSSV}: ",encodedstring);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine("SOMETHINGWENTWRONG: ",ex);

        }
        var client = new HttpClient();
        var inputdata = new User
        {
            Base64stringFaceOfUser = encodedstring,
            UserName = vm.TenSV,
            UserId = vm.MSSV
        };
        Debug.WriteLine(encodedstring);
        Debug.WriteLine(vm.TenSV);
        Debug.WriteLine(vm.MSSV);
        var response = client.PostAsJsonAsync("http://127.0.0.1:8000/execute_image", inputdata);
        
    }

    // Encode image to base64string
    public static string EncodeImageToBase64(string imagePath)
    {
        try
        {
            byte[] imageBytes = File.ReadAllBytes(imagePath);
            string base64String = Convert.ToBase64String(imageBytes);

            return base64String;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: Image file not found at '{imagePath}'");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return null;
        }
    }

}