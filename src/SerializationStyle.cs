using System.Text.Json;
using System.Text.Json.Serialization;

namespace Payconiq
{
    public class UpperCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            return name.ToUpper();
        }
    }

    public class SerializationStyle
    {
        public static JsonSerializerOptions GetJsonSerializationOptions()
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IgnoreNullValues = true
            };
            options.Converters.Add(new JsonStringEnumConverter(new UpperCaseNamingPolicy()));

            return options;
        }
    }
}