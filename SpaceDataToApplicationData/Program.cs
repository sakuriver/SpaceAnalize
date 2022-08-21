// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.IO;

Console.ForegroundColor = ConsoleColor.Gray;

HttpClient client = new HttpClient();
HttpResponseMessage response;




Console.WriteLine("Nasa Data Api Analize Start");


/// <summary>
/// 過去5年分ぐらいの宇宙情報を取得してみる
/// </summary>

var startYear = DateTime.Now.Year - 6;
var endYear = DateTime.Now.Year - 1;
string demoKey = "Your Nasa Demo Key Input";
SpaceBasicData.NasaEpicHistoryRoot rootData = new SpaceBasicData.NasaEpicHistoryRoot();
rootData.dataHistories = new List<SpaceBasicData.NasaEpicDataResponse>();
for (; startYear < endYear; startYear++) {
    for (var i = 1; i <= 12; i++) {
        var requestDate = $"{startYear}-{i}-15";
        response = await client.GetAsync($"https://api.nasa.gov/EPIC/api/enhanced/date/{requestDate}?api_key={demoKey}");
        response.EnsureSuccessStatusCode();
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            Console.WriteLine("openapiへの通信に失敗したので、検索システムを終了します");
            return;
        }
        string nasaApiResponseBody = await response.Content.ReadAsStringAsync();

        Console.WriteLine(nasaApiResponseBody);

        List<SpaceBasicData.NasaEpicDateRecord> nasaEpicDataRoot = JsonSerializer.Deserialize<List<SpaceBasicData.NasaEpicDateRecord>>(nasaApiResponseBody);

        var spaceData = new SpaceBasicData.NasaEpicDataResponse();
        spaceData.statDate = requestDate;
        spaceData.epicDateRecords = new List<SpaceBasicData.NasaEpicDateRecord>();
        foreach (var nasaDataRoot in nasaEpicDataRoot)
        {
            spaceData.epicDateRecords.Add(nasaDataRoot);
        }
        rootData.dataHistories.Add(spaceData);
    }

}
try
{
    var rootDataStr = JsonSerializer.Serialize(rootData);
    File.WriteAllText("./nasadata.json", rootDataStr);
}
catch (Exception ex)
{
}
