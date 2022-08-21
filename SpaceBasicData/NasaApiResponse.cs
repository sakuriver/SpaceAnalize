using System.Text.Json.Serialization;

namespace SpaceBasicData
{

    public class NasaEpicHistoryRoot
    {
        [JsonPropertyName("histories")]
        public List<NasaEpicDataResponse> dataHistories { get; set; }
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
        public string statDate { get; set; }

        [JsonPropertyName("records")]
        public List<NasaEpicDateRecord> epicDateRecords { get; set; }




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