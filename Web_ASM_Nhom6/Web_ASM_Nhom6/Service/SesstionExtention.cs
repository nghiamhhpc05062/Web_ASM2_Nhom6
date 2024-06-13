using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Web_ASM_Nhom6.Service
{
    public static class SesstionExtention
    {
        public static T GetObject<T>(this ISession session, string key)
        {
            var data = session.GetString(key);
            return data == null ? default(T) : JsonSerializer.Deserialize<T>(data);
        }

        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
    }
}
