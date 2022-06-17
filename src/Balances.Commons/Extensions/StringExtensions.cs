using System.ComponentModel;
using System.Reflection;
using System.Text.Json;

namespace Balances.Commons.Extensions;

public static class StringExtensions
{
    private const string EmptyObject = "{}";

    private static readonly Dictionary<Type, Dictionary<int, string>> Cache = new();

    public static string ToJson(this object data)
    {
        return data is null ? EmptyObject : JsonSerializer.Serialize(data);
    }

    public static T FromJson<T>(this string data)
    {
        return JsonSerializer.Deserialize<T>(string.IsNullOrWhiteSpace(data) ? EmptyObject : data);
    }

    public static string EnumToString(this Enum @enum)
    {
        var enumType = @enum.GetType();
        if (Cache.ContainsKey(enumType))
        {
            var key = Convert.ToInt32(@enum);
            return Cache[enumType].ContainsKey(key) ? Cache[enumType][key] : @enum.ToString();
        }

        Cache.Add(enumType, new Dictionary<int, string>());
        var values = Enum.GetValues(enumType);
        foreach (var value in values)
        {
            var memberInfo = enumType.GetMember(value.ToString() ?? string.Empty);
            var attributes = memberInfo.First().GetCustomAttribute<DescriptionAttribute>();

            Cache[enumType].Add(
                Convert.ToInt32(value),
                attributes is { } ? attributes.Description : value.ToString());
        }

        return @enum.EnumToString();
    }

    public static string Numbers(this string text)
        => string.IsNullOrWhiteSpace(text) ? text : new string(text.Where(char.IsDigit).ToArray());
}