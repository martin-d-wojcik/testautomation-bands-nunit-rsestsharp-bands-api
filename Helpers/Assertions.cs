using NUnit.Framework;
using NUnitTestBandsApi.RestApis;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestBandsApi.Helpers  
{
    class Assertions
    {
        public static void AssertBands(IRestResponse restResponse)
        {
            // deserialize to Bands object
            var bands = Bands.FromJson(restResponse.Content);
            Assert.That(bands, Is.All.Not.Null);
            Assert.AreEqual(restResponse.StatusCode, System.Net.HttpStatusCode.OK);

            foreach (RestApis.Bands band in bands)
            {
                string name = band.Name;
                bool active = band.Active;
                int id = band.Id;

                Assert.That(id, Is.InstanceOf<int>());
                Assert.That(name, Is.Not.Empty);
                Assert.That(name, Is.InstanceOf<string>());
                Assert.That(active, Is.InstanceOf<bool>());
            }
        }

        public static void AssertBand(IRestResponse restResponse)
        {
            // deserialize to Band object
            var band = Band.FromJson(restResponse.Content);
            Assert.AreEqual(restResponse.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.That(band, Is.All.Not.Null);

            foreach (Band bandInResponse in band)
            {
                string name = bandInResponse.Name;
                bool active = bandInResponse.Active;
                int id = bandInResponse.Id;

                Assert.That(id, Is.InstanceOf<int>());
                Assert.That(name, Is.Not.Empty);
                Assert.That(name, Is.InstanceOf<string>());
                Assert.That(active, Is.InstanceOf<bool>());

                // loop through albums for this band
                foreach (AlbumForOneBand album in bandInResponse.Albums)
                {
                    string albumName = album.Name;
                    string recordCompany = album.RecordCompany;

                    Assert.That(albumName, Is.InstanceOf<string>());
                    Assert.That(recordCompany, Is.InstanceOf<string>());
                }
            }
        }

        public static void AssertBandUpdate(IRestResponse response, string valueUpdated)
        {
            var bandUpdated = BandUpdate.FromJson(response.Content);
            Assert.That(bandUpdated, Is.Not.Null);
            Assert.AreEqual(bandUpdated.Name, valueUpdated);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        public static void AssertAlbums(IRestResponse restResponse)
        {
            // deserialize to Albums object
            var albums = Albums.FromJson(restResponse.Content);
            Assert.AreEqual(restResponse.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.That(albums, Is.All.Not.Null);

            foreach (Albums album in albums)
            {
                int id = album.Id;
                string name = album.Name;
                string recordCompany = album.RecordCompany;                

                Assert.That(id, Is.InstanceOf<int>());
                Assert.That(name, Is.Not.Empty);
                Assert.That(name, Is.InstanceOf<string>());
                Assert.That(recordCompany, Is.Not.Empty);
                Assert.That(recordCompany, Is.InstanceOf<string>());
            }
        }

        public static void AssertAlbum(IRestResponse restResponse)
        {
            // deserialize to Album object
            var albumFromResponse = Album.FromJson(restResponse.Content);
            Assert.That(albumFromResponse, Is.All.Not.Null);
            Assert.AreEqual(restResponse.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.Less(albumFromResponse.Length, 2);

            foreach (Album album in albumFromResponse)
            {
                int id = album.Id;
                string name = album.Name;                
                string recordCompany = album.RecordCompany;

                Assert.That(id, Is.InstanceOf<int>());
                Assert.That(name, Is.Not.Empty);
                Assert.That(name, Is.InstanceOf<string>());
                Assert.That(recordCompany, Is.InstanceOf<string>());
                Assert.That(recordCompany, Is.Not.Empty);
            }
        }

        public static void AssertAlbumAdd(IRestResponse restResponse)
        {
            Assert.AreEqual(restResponse.StatusCode, System.Net.HttpStatusCode.Created);
            Assert.IsTrue(restResponse.Content.Contains("successfully added to the SQLite database"));
        }
    }
}
