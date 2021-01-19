using NUnit.Framework;
using NUnitTestBandsApi.Helpers;
using NUnitTestBandsApi.RestApis;
using NUnitTestBandsApi.Resources;
using System;
using NUnitTestBandsApi.Requests;

namespace NUnitTestBandsApi
{
    public class SmokeTest
    {
        public string baseUri;

        [SetUp]
        public void Setup()
        {
            baseUri = Config.baseUri;
        }

        [Test]
        public void TestGetAllBandsPass()
        {
            // prepare
            string url = RequestHelper.SetBaseUrl("bands");

            // perform
            var response = RequestHelper.GetRequest(url);

            // assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            Assertions.AssertBands(response);

            // Json schema validation
            Assert.IsTrue(JsonHelper.ValidateJsonSchema(response, "BandsSchema.json"));
        }

        [Test]
        public void TestGetBandByIdPass()
        {
            // prepare
            string url = RequestHelper.SetUrl("band", "4");

            // perform
            var response = RequestHelper.GetRequest(url);

            // assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            Assertions.AssertBand(response);

            // Json schema validation
            Assert.IsTrue(JsonHelper.ValidateJsonSchema(response, "BandSchema.json"));
        }
    }
}