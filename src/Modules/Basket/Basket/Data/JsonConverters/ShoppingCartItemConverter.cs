using System.Text.Json;
using System.Text.Json.Serialization;

namespace Basket.Data.JsonConverters
{
    public class ShoppingCartItemConverter : JsonConverter<ShoppingCartItem>
    {
        public override ShoppingCartItem? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, ShoppingCartItem value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
