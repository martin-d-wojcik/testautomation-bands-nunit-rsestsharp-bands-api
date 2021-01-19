namespace NUnitTestBandsApi.RestApis
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Bands
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Bands
    {
        public static Bands[] FromJson(string json) => JsonConvert.DeserializeObject<Bands[]>(json, NUnitTestBandsApi.RestApis.BandsConverter.Settings);
    }

    public static class BandsSerialize
    {
        public static string ToJson(this Bands[] self) => JsonConvert.SerializeObject(self, NUnitTestBandsApi.RestApis.BandsConverter.Settings);
    }

    internal static class BandsConverter
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

