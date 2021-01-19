using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using RestSharp;
using NUnitTestBandsApi.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestBandsApi.Helpers
{
    class JsonHelper
    {
        public static bool ValidateJsonSchema(IRestResponse response, string schemaName)
        {
            // JSchema schema = JSchema.Parse(System.IO.File.ReadAllText("C:/Test automation/C#/api/NUnitTestBandsApi/JsonSchemas/" + schemaName));
            JSchema schema = JSchema.Parse(System.IO.File.ReadAllText(Config.jsonSchemasPath + schemaName));
            JArray jsonObject = JArray.Parse(response.Content);
                
            return jsonObject.IsValid(schema);
        }
    }
}
