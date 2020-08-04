using System.Collections.Generic;
using System.Diagnostics;
using MeliLibTools.MeliLibApi;
using MeliLibTools.Client;
using MeliLibTools.Model;

namespace Example
{
    public class ItemsPostExample
    {
        public static void Mainext()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.mercadolibre.com";
            var apiInstance = new RestClientApi(config);
            var resource = "items";
            var accessToken = "access_token";
            List<ItemPictures> pictures = new List<ItemPictures>();
            pictures.Add(new ItemPictures() {
                Source = "https://http2.mlstatic.com/storage/developers-site-cms-admin/openapi/319968615067-mp3.jpg"});
            List<AttributesValues> attrValues = new List<AttributesValues>();
            attrValues.Add(new AttributesValues() {
            Name = "8 GB",
            });
            List<Attributes> attributes = new List<Attributes>();
            attributes.Add(new Attributes() {
                Id = "DATA_STORAGE_CAPACITY",
                Name = "Capacidad de almacenamiento de datos",
                ValueName = "8 GB",
                Values = attrValues,
                AttributeGroupId = "OTHERS",
                AttributeGroupName = "Otros",
            });
            var item = new Item(
                "Item de test - No Ofertar",
                "MLA5991",
                350,
                "ARS",
                "12",
                "buy_it_now",
                "bronze",
                "new",
                "Item de Teste. Mercado Livre SDK",
                "RXWn6kftTHY",
                pictures,
                attributes
            );
            try
            {
                // Return a Item.
                apiInstance.ResourcePost(resource, accessToken, item);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ItemsApi.ItemsPost: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}