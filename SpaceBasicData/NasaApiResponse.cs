using System.Text.Json.Serialization;

namespace SpaceBasicData
{

    public class NasaMarsRoot
    {
        [JsonPropertyName("photos")]
        public List<NasaMarsPhotoRecord>? photos { get; set; }
    }

    public class NasaMarsPhotoRecord
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        [JsonPropertyName("sol")]
        public int? Sol { get; set; }
        [JsonPropertyName("img_src")]
        public string? ImgSrc { get; set; }
        [JsonPropertyName("earth_date")]
        public string? EarthDate { get; set; }
        //[JsonPropertyName("camera")]
        //public NasaMarsCameraData Camera;
        //[JsonPropertyName("rover")]
        //public NasaMarsRoverData Rover;

    }





    public class NasaMarsCameraData
    {
        [JsonPropertyName("id")]
        public int id;
        [JsonPropertyName("name")]
        public string name;
        [JsonPropertyName("rover_id")]
        public int rover_id;
        [JsonPropertyName("full_name")]
        public string full_name;

    }
    public class NasaMarsRoverData
    {
        [JsonPropertyName("id")]
        public int Id;
        [JsonPropertyName("name")]
        public string Name;
        [JsonPropertyName("landing_date")]
        public string LandingDate;
        [JsonPropertyName("launch_date")]
        public string LaunchDate;
        [JsonPropertyName("status")]
        public string Status;

    }

    public class NasaEpicHistoryRoot
    {
        [JsonPropertyName("histories")]
        public List<NasaEpicDataResponse> DataHistories { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class NasaEpicDataResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("stat_date")]
        public string StatDate { get; set; }

        [JsonPropertyName("records")]
        public List<NasaEpicDateRecord> EpicDateRecords { get; set; }




    }

    /// <summary>
    /// 
    /// </summary>
    public class NasaEpicDateRecord
    {
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("caption")]
        public string Caption { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }


        [JsonPropertyName("version")]
        public string Version { get; set; }


        ///
        /// 重心の場所
        ///
        [JsonPropertyName("centroid_coordinates")]
        public NasaLocation CentroidCoordinates { get; set; }

    }

    public class NasaLocation
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }
        
        [JsonPropertyName("lon")]
        public double Lon { get; set; }

    }





}