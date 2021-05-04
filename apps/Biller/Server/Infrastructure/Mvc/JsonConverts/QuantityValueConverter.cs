using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Infrastructure.Mvc.JsonConverts
{
    public class QuantityValueConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(QuantityValue);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {

            var jObj = JObject.Load(reader);
            if (jObj.HasValues)
            {
                var quantityValue = new QuantityValue(
                    jObj["value"].Value<decimal>(),
                    jObj["unitMeasurement"].Value<string>());

                return quantityValue;
            }

            return default;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            if (!(value is QuantityValue quantity))
                throw new InvalidCastException();

            serializer.Serialize(writer, new { quantity.Value, quantity.UnitMeasurement });
        }
    }
}
