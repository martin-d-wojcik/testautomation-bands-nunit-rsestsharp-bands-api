using NUnit.Framework;
using NUnitTestBandsApi.Helpers;
using NUnitTestBandsApi.Resources;
using System.Configuration;
using System.Collections.Specialized;
using NUnitTestBandsApi.RestApis;
using System;
using NUnitTestBandsApi.Requests;
using Newtonsoft.Json.Linq;

namespace NUnitTestBandsApi.Test
{
    class RegressionTest
    {
        public string baseUri;

        [SetUp]
        public void Setup()
        {
            RequestHelper.baseUri = Config.baseUri;
        }

        [Test]
        public void TestGetAllBandsPass()
        {
            // prepare
            string url = RequestHelper.SetBaseUrl("bands");

            // perform
            var response = RequestHelper.GetRequest(url);

            // assert            
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
            Assertions.AssertBand(response);

            // Json schema validation
            Assert.IsTrue(JsonHelper.ValidateJsonSchema(response, "BandSchema.json"));
        }

        [Test]
        public void TestAddBandPass()
        {
            string url = RequestHelper.SetBaseUrl("bands");

            // prepare. Serialize object of band class to json body
            BandAdd bandAdd = new BandAdd();
            bandAdd.Name = "Opeth";  
            bandAdd.Active = true;
            string body = BandAddSerialize.ToJson(bandAdd);

            // perform
            var response = RequestHelper.PostRequest(url, body);

            // assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.Created);
        }

        [Test]
        public void TestDeleteBandPass()
        {
            int bandId = 13;

            // prepare
            string url = RequestHelper.SetUrl("band", bandId.ToString());

            // perform
            var response = RequestHelper.DeleteRequest(url);
            string message = response.Content;

            // assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.IsTrue(message.Contains(bandId.ToString()));
        }

        [Test]
        public void TestUpdateBandIdPass()
        {
            int bandId = 12;
            string bandNameUpdated = "pInK";

            // prepare
            string url = RequestHelper.SetUrl("band", bandId.ToString());

            // prepare. Serialize object of band class to json body
            BandUpdate bandUpdate = new BandUpdate();
            bandUpdate.Id = bandId;
            bandUpdate.Active = true;
            bandUpdate.Name = bandNameUpdated;
            string body = SerializeBandUpdate.ToJson(bandUpdate);

            // perform
            var response = RequestHelper.PutRequest(url, body);

            // assert
            Assertions.AssertBandUpdate(response, bandNameUpdated);

            // Json schema validation
            Assert.IsTrue(JsonHelper.ValidateJsonSchema(response, "BandUpdateSchema.json"));
        }

        [Test]
        public void TestGetAllAlbumsPass()
        {
            // prepare
            string url = RequestHelper.SetBaseUrl("albums");

            // perform
            var response = RequestHelper.GetRequest(url);

            // assert            
            Assertions.AssertAlbums(response);

            // Json schema validation
            Assert.IsTrue(JsonHelper.ValidateJsonSchema(response, "AlbumsSchema.json"));
        }

        [Test]
        public void TestGetAlbumByIdPass()
        {
            // prepare
            string url = RequestHelper.SetUrl("album", "22");

            // perform
            var response = RequestHelper.GetRequest(url);

            // assert            
            Assertions.AssertAlbum(response);

            // Json schema validation
            Assert.IsTrue(JsonHelper.ValidateJsonSchema(response, "AlbumsSchema.json"));
        }

        [Test]
        public void TestAddAlbumPass()
        {
            // prepare
            string url = RequestHelper.SetBaseUrl("albums");

            AlbumAdd album = new AlbumAdd();
            album.BandId = 10;
            album.Name = "no idea";
            album.RecordCompany = "Earache records";
            string jsonBody = AlbumAddSerialize.ToJson(album);

            // perform
            var response = RequestHelper.PostRequest(url, jsonBody);

            // assert
            Assertions.AssertAlbumAdd(response);
        }
    }
}
