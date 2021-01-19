namespace NUnitTestBandsApi.RestApis
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Band
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("albums")]
        public AlbumForOneBand[] Albums { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class AlbumForOneBand
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("record_company")]
        public string RecordCompany { get; set; }
    }

    public partial class Band
    {
        public static Band[] FromJson(string json) => JsonConvert.DeserializeObject<Band[]>(json, NUnitTestBandsApi.RestApis.BandConverter.Settings);
    }

    public static class BandSerialize
    {
        public static string ToJson(this Band[] self) => JsonConvert.SerializeObject(self, NUnitTestBandsApi.RestApis.BandConverter.Settings);
    }

    internal static class BandConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
