using System.Reflection;

namespace Task7_Reflection;

public class UniversalConverter<T> where T : new()
{
    public static string ConvertToString(T obj) 
    {
        Type type = obj!.GetType();

        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.CanRead && p.CanWrite);

        var members = fields.Cast<MemberInfo>()
            .Concat(properties)
            .OrderBy(m => m.Name)
            .ToArray();

        var values = new string[members.Length];
        string name = string.Empty;

        for (int i = 0; i < members.Length; i++)
        {
            object? value = null;

            if (members[i] is FieldInfo field)
            {
                name = field.Name;
                value = field.GetValue(obj);
            }

            values[i] = name + "=" + value?.ToString();
        }

        return string.Join(", ", values);
    }

    public static T ConvertFromString(string data)
    {
        T obj = new T();
        Type type = typeof(T);
        var properties = type.GetProperties();

        var keyValuePairs = data.Split(',').Select(part => part.Split('=')).ToDictionary(s => s[0].Trim(), s => s[1].Trim());

        foreach (var property in properties)
        {
            if (keyValuePairs.ContainsKey(property.Name))
            {
                object value = Convert.ChangeType(keyValuePairs[property.Name], property.PropertyType);
                property.SetValue(obj, value);
            }
        }

        return obj;
    }
}
