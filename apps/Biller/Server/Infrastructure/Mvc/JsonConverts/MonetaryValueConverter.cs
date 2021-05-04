using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Infrastructure.Mvc.JsonConverts
{
    public class MonetaryValueConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MonetaryValue);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            if (jObject.HasValues)
            {
                var monetaryValue = new MonetaryValue(
                    value: jObject["value"].Value<decimal>(),
                    currency: jObject["currency"].Value<string>());

                return monetaryValue;
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            if (!(value is MonetaryValue monetary))
                throw new InvalidCastException();

            serializer.Serialize(writer, new { monetary.Value, monetary.Currency });
            
        }
    }
}
