using System;
using NUnit.Framework;

namespace MercadoLibre.SDK.Meta
{
    [TestFixture]
    public class MeliSiteExtensionsTest
    {
        [Test]
        public void TestToMeliSite()
        {
            Assert.AreEqual(MeliSite.Argentina, "MLA".ToMeliSite());
            Assert.AreEqual(MeliSite.Brasil, "MLB".ToMeliSite());
            Assert.AreEqual(MeliSite.Chile, "MCL".ToMeliSite());
            Assert.AreEqual(MeliSite.Colombia, "MCO".ToMeliSite());
            Assert.AreEqual(MeliSite.CostaRica, "MCR".ToMeliSite());
            Assert.AreEqual(MeliSite.Dominicana, "MRD".ToMeliSite());
            Assert.AreEqual(MeliSite.Ecuador, "MEC".ToMeliSite());
            Assert.AreEqual(MeliSite.Mexico, "MLM".ToMeliSite());
            Assert.AreEqual(MeliSite.Panama, "MPA".ToMeliSite());
            Assert.AreEqual(MeliSite.Peru, "MPE".ToMeliSite());
            Assert.AreEqual(MeliSite.Portugal, "MPT".ToMeliSite());
            Assert.AreEqual(MeliSite.Uruguay, "MLU".ToMeliSite());
            Assert.AreEqual(MeliSite.Venezuela, "MLV".ToMeliSite());
        }

        [Test]
        public void TestToMeliSiteIsCaseInvariant()
        {
            Assert.AreEqual(MeliSite.Argentina, "mla".ToMeliSite());
        }

        [Test]
        public void TestToMeliSiteWhenOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "abc".ToMeliSite());
        }

        [Test]
        public void TestToSiteId()
        {
            Assert.AreEqual("MLA", MeliSite.Argentina.ToSiteId());
            Assert.AreEqual("MLB", MeliSite.Brasil.ToSiteId());
            Assert.AreEqual("MCL", MeliSite.Chile.ToSiteId());
            Assert.AreEqual("MCO", MeliSite.Colombia.ToSiteId());
            Assert.AreEqual("MCR", MeliSite.CostaRica.ToSiteId());
            Assert.AreEqual("MRD", MeliSite.Dominicana.ToSiteId());
            Assert.AreEqual("MEC", MeliSite.Ecuador.ToSiteId());
            Assert.AreEqual("MLM", MeliSite.Mexico.ToSiteId());
            Assert.AreEqual("MPA", MeliSite.Panama.ToSiteId()); 
            Assert.AreEqual("MPE", MeliSite.Peru.ToSiteId());
            Assert.AreEqual("MPT", MeliSite.Portugal.ToSiteId());
            Assert.AreEqual("MLU", MeliSite.Uruguay.ToSiteId());
            Assert.AreEqual("MLV", MeliSite.Venezuela.ToSiteId());
        }

        [Test]
        public void TestToSiteIdWhenOutOfRange()
        {
            const MeliSite @enum = (MeliSite) 100;

            Assert.Throws<InvalidOperationException>(() => @enum.ToSiteId());
        }

        [Test]
        public void TestToCountryCode()
        {
            Assert.AreEqual("AR", MeliSite.Argentina.ToCountryCode());
            Assert.AreEqual("BR", MeliSite.Brasil.ToCountryCode());
            Assert.AreEqual("CL", MeliSite.Chile.ToCountryCode());
            Assert.AreEqual("CO", MeliSite.Colombia.ToCountryCode());
            Assert.AreEqual("CR", MeliSite.CostaRica.ToCountryCode());
            Assert.AreEqual("DO", MeliSite.Dominicana.ToCountryCode());
            Assert.AreEqual("EC", MeliSite.Ecuador.ToCountryCode());
            Assert.AreEqual("MX", MeliSite.Mexico.ToCountryCode());
            Assert.AreEqual("PA", MeliSite.Panama.ToCountryCode());
            Assert.AreEqual("PE", MeliSite.Peru.ToCountryCode());
            Assert.AreEqual("PT", MeliSite.Portugal.ToCountryCode());
            Assert.AreEqual("UY", MeliSite.Uruguay.ToCountryCode());
            Assert.AreEqual("VE", MeliSite.Venezuela.ToCountryCode());
        }

        [Test]
        public void TestToCountryCodeWhenOutOfRange()
        {
            const MeliSite @enum = (MeliSite) 100;

            Assert.Throws<InvalidOperationException>(() => @enum.ToCountryCode());
        }

        [Test]
        public void TestToDomain()
        {
            Assert.AreEqual("mercadolibre.com.ar", MeliSite.Argentina.ToDomain());
            Assert.AreEqual("mercadolibre.com.br", MeliSite.Brasil.ToDomain());
            Assert.AreEqual("mercadolibre.cl", MeliSite.Chile.ToDomain());
            Assert.AreEqual("mercadolibre.com.co", MeliSite.Colombia.ToDomain());
            Assert.AreEqual("mercadolibre.co.cr", MeliSite.CostaRica.ToDomain());
            Assert.AreEqual("mercadolibre.com.do", MeliSite.Dominicana.ToDomain());
            Assert.AreEqual("mercadolibre.com.ec", MeliSite.Ecuador.ToDomain());
            Assert.AreEqual("mercadolibre.com.mx", MeliSite.Mexico.ToDomain());
            Assert.AreEqual("mercadolibre.com.pa", MeliSite.Panama.ToDomain());
            Assert.AreEqual("mercadolibre.com.pe", MeliSite.Peru.ToDomain());
            Assert.AreEqual("mercadolibre.pt", MeliSite.Portugal.ToDomain());
            Assert.AreEqual("mercadolibre.com.uy", MeliSite.Uruguay.ToDomain());
            Assert.AreEqual("mercadolibre.com.ve", MeliSite.Venezuela.ToDomain());
        }

        [Test]
        public void TestToDomainWhenOutOfRange()
        {
            const MeliSite @enum = (MeliSite)100;

            Assert.Throws<InvalidOperationException>(() => @enum.ToDomain());
        }
    }
}
