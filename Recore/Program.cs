using Newtonsoft.Json;
using Recore.Console;
using System.Text;

//var mainPage = new MainPage();
//mainPage.MainView();

var httpClient = new HttpClient();

string url = "https://localhost:5001/api/adresses";

var ad = new Address
{
    Department = "asd",
    DistrictId = 1,
    DomofonCode = "sad",
    Floor = "asd",
    Home = "Home",
    Latitude = "12",
    Longitude = "12",
    RegionId = 1,
    Street = "asd"
};

var content = new StringContent(JsonConvert.SerializeObject(ad), Encoding.UTF8, "application/json");

var request = await httpClient.PostAsync(url, content);

var response = await request.Content.ReadAsStringAsync();

Console.WriteLine(response);