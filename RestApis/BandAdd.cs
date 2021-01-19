namespace NUnitTestBandsApi.RestApis
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class BandAdd
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }
    }

    public partial class BandAdd
    {
        public static BandAdd FromJson(string json) => JsonConvert.DeserializeObject<BandAdd>(json, NUnitTestBandsApi.RestApis.BandAddConverter.Settings);
    }

    public static class BandAddSerialize
    {
        public static string ToJson(this BandAdd self) => JsonConvert.SerializeObject(self, NUnitTestBandsApi.RestApis.BandAddConverter.Settings);
    }

    internal static class BandAddConverter
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

