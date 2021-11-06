using System.Text.Json;

namespace Core.Extentions
{
    public static class ObjectExtentions
    {
        public static T DeepCopy<T>(this T model)
        {
            var serialized = JsonSerializer.Serialize(model);
            return JsonSerializer.Deserialize<T>(serialized);
        }
    }
}
