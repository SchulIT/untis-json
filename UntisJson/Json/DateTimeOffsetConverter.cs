using Newtonsoft.Json;
using System;

namespace UntisJson.Json
{
    /// <summary>
    /// Writes <see cref="DateTimeOffset"/>s to
    /// dates only -> YYYY-MM-DD format
    /// </summary>
    public class DateTimeOffsetConverter : JsonConverter
    {
        public override bool CanWrite { get { return true; } }

        public override bool CanRead { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dto = value as DateTimeOffset?;

            if (dto != null && dto.HasValue)
            {
                writer.WriteValue(dto.Value.ToString("yyyy-MM-dd"));
            }
            else
            {
                writer.WriteNull();
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTimeOffset) || objectType == typeof(DateTimeOffset?);
        }
    }
}
