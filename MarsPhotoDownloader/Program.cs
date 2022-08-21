using System.Text.Json;
using System.Net;


Console.WriteLine("火星の撮影結果を開始します");
HttpResponseMessage response;
HttpClient client = new HttpClient();

response = await client.GetAsync($"https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?sol=1000&api_key=DEMO_KEY");
response.EnsureSuccessStatusCode();
if (response.StatusCode != System.Net.HttpStatusCode.OK)
{
    Console.WriteLine("火星情報取得に失敗したので、検索システムを終了します");
    return;
}
string nasaMarsApiResponseBody = await response.Content.ReadAsStringAsync();
var marsRootData = JsonSerializer.Deserialize<SpaceBasicData.NasaMarsRoot>(nasaMarsApiResponseBody);


foreach (var marsPhoto in marsRootData.photos)
{

    using (WebClient webClient = new WebClient())
    {
        var id = marsPhoto.Id;
        var sol = marsPhoto.Sol;
        var earthDate = marsPhoto.EarthDate;
        var imageName = $"{id}_{sol}_{earthDate}";
        var retryNum = 0;
        // システムが落ちるまで何度でも投げてみる
        while(true)
        {
            try
            {
                webClient.DownloadFile(new Uri(marsPhoto.ImgSrc), $"{imageName}.jpg");
                break;
            }
            catch (Exception ex)
            {
                // 画像で回線圧迫があるので、リトライしてみる
                Thread.Sleep(1000);
                retryNum++;
                Console.WriteLine($"{retryNum}回目のリトライを開始します");
            }
        }
        Console.WriteLine($"{imageName} download complete");
        Thread.Sleep(30);
    }
}

try
{
    var marsRootDataStr = JsonSerializer.Serialize(marsRootData);
    File.WriteAllText("./nasamarsdata.json", marsRootDataStr);

}
catch (Exception ex)
{
}
