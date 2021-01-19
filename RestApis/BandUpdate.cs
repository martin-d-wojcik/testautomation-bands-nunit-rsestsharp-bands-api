namespace NUnitTestBandsApi.RestApis
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class BandUpdate
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }
    }

    public partial class BandUpdate
    {
        public static BandUpdate FromJson(string json) => JsonConvert.DeserializeObject<BandUpdate>(json, NUnitTestBandsApi.RestApis.ConverterBandUpdate.Settings);
    }

    public static class SerializeBandUpdate
    {
        public static string ToJson(this BandUpdate self) => JsonConvert.SerializeObject(self, NUnitTestBandsApi.RestApis.ConverterBandUpdate.Settings);
    }

    internal static class ConverterBandUpdate
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
