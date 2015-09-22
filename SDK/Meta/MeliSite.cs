namespace MercadoLibre.SDK.Meta
{
    /// <summary>
    /// Enumeration listing all the available mercado libre sites
    /// </summary>
    /// <remarks>
    /// Use <see cref="MeliSiteExtensions.ToSiteId" />, <see cref="MeliSiteExtensions.ToCountryCode" /> 
    /// and <see cref="MeliSiteExtensions.ToDomain" /> methods to extract attribute information.
    /// </remarks>
    public enum MeliSite
    {
        [MeliSiteId("MLA")]
        [MeliCountryCode("AR")]
        [MeliDomain("mercadolibre.com.ar")]
        Argentina,
        
        [MeliSiteId("MLB")]
        [MeliCountryCode("BR")]
        [MeliDomain("mercadolivre.com.br")]
        Brasil,
        
        [MeliSiteId("MCO")]
        [MeliCountryCode("CO")]
        [MeliDomain("mercadolibre.com.co")]
        Colombia,
        
        [MeliSiteId("MCR")]
        [MeliCountryCode("CR")]
        [MeliDomain("mercadolibre.co.cr")]
        CostaRica,
        
        [MeliSiteId("MEC")]
        [MeliCountryCode("EC")]
        [MeliDomain("mercadolibre.com.ec")]
        Ecuador,
        
        [MeliSiteId("MCL")]
        [MeliCountryCode("CL")]
        [MeliDomain("mercadolibre.cl")]
        Chile,
        [MeliSiteId("MLM")]
        [MeliCountryCode("MX")]
        [MeliDomain("mercadolibre.com.mx")]
        Mexico,
        
        [MeliSiteId("MLU")]
        [MeliCountryCode("UY")]
        [MeliDomain("mercadolibre.com.uy")]
        Uruguay,
        
        [MeliSiteId("MLV")]
        [MeliCountryCode("VE")]
        [MeliDomain("mercadolibre.com.ve")]
        Venezuela,
        
        [MeliSiteId("MPA")]
        [MeliCountryCode("PA")]
        [MeliDomain("mercadolibre.com.pa")]
        Panama,
        
        [MeliSiteId("MPE")]
        [MeliCountryCode("PE")]
        [MeliDomain("mercadolibre.com.pe")]
        Peru,
        
        [MeliSiteId("MPT")]
        [MeliCountryCode("PT")]
        [MeliDomain("mercadolivre.pt")]
        Portugal,
        
        [MeliSiteId("MRD")]
        [MeliCountryCode("DO")]
        [MeliDomain("mercadolibre.com.do")]
        Dominicana
    }
}
