namespace NUnitTestBandsApi.RestApis
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class AlbumAdd
    {
        [JsonProperty("band_id")]
        public long BandId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("record_company")]
        public string RecordCompany { get; set; }
    }

    public partial class AlbumAdd
    {
        public static AlbumAdd FromJson(string json) => JsonConvert.DeserializeObject<AlbumAdd>(json, NUnitTestBandsApi.RestApis.AlbumAddConverter.Settings);
    }

    public static class AlbumAddSerialize
    {
        public static string ToJson(this AlbumAdd self) => JsonConvert.SerializeObject(self, NUnitTestBandsApi.RestApis.AlbumAddConverter.Settings);
    }

    internal static class AlbumAddConverter
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
