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
            // Configure OAuth2 access token for authorization: oAuth2AuthCode
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ItemsApi(config);
            var accessToken = "accessToken_example";  // string | 
            // List<ItemPictures> pictures = new List<ItemPictures>();
            // pictures.Add(new ItemPictures() {
            //     Source = "https://http2.mlstatic.com/storage/developers-site-cms-admin/openapi/319968615067-mp3.jpg"});
            // List<AttributesValues> attrValues = new List<AttributesValues>();
            // attrValues.Add(new AttributesValues() {
            // Name = "8 GB",
            // });
            // List<Attributes> attributes = new List<Attributes>();
            // attributes.Add(new Attributes() {
            //     Id = "DATA_STORAGE_CAPACITY",
            //     Name = "Capacidad de almacenamiento de datos",
            //     ValueName = "8 GB",
            //     Values = attrValues,
            //     AttributeGroupId = "OTHERS",
            //     AttributeGroupName = "Otros",
            // });
            var item = new Item(
                // "Item de test - No Ofertar",
                // "MLA5991",
                // 350,
                // "ARS",
                // 12,
                // "buy_it_now",
                // "bronze",
                // "new",
                // "Item de Teste. Mercado Livre SDK",
                // "RXWn6kftTHY",
                // "12 month",
                // pictures,
                // atributtes
            ); // Item |             
            try
            {
                // Create a Item.
                apiInstance.ItemsPost(accessToken, item);
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