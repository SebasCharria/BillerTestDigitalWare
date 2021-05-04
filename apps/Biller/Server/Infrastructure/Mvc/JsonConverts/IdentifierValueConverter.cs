using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shared.Domain.Enums;
using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Infrastructure.Mvc.JsonConverts
{
    public class IdentifierValueConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IdentifierValue);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jobject = JObject.Load(reader);
            if (jobject.HasValues)
            {
                if (!Enum.TryParse(jobject["taxIdentifier"].Value<string>(), out TaxIdentifier taxIdentifier))
                    throw new InvalidCastException();

                var identifier = new IdentifierValue(
                    taxIdentifier,
                    jobject["value"].Value<string>());

                return identifier;
            }

            return default;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (!(value is IdentifierValue identifier))
                throw new InvalidCastException();

            serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            serializer.Serialize(writer, new { identifier.TaxIdentifier, identifier.Value });
        }
    }
}
