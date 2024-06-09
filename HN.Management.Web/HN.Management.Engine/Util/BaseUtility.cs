using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;

namespace HN.Management.Engine.Util
{
    public static class BaseUtility
    {
        public const string PDFFileContentType = "application/pdf";

        public static readonly JsonSerializerSettings SerializerSettings = new() { NullValueHandling = NullValueHandling.Ignore };

        public static bool ObjectsEquals(object o1, object o2)
        {
            return o1 == null || o2 == null
                ? o1 == o2
                : o1.Equals(o2);
        }

        public static string Truncate(this string value, int maxLength)
        {
            return string.IsNullOrEmpty(value)
                ? value
                : value.Substring(0, Math.Min(value.Length, maxLength));
        }

        public static string ToJsonString(this object value)
        {
            return JsonConvert.SerializeObject(value, SerializerSettings);
        }

        public static string ToCamelCaseJsonString(this object userData)
            => JsonConvert.SerializeObject(userData, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy(),
                },
            });

        public static DateTime? ParseAsNullableDate(this string date)
        {
            if (string.IsNullOrEmpty(date))
            {
                return null;
            }

            return DateTime.Parse(date);
        }

        public static string HashPassword(this string password)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.HMACSHA256().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);

            return hash;
        }
    }
}
