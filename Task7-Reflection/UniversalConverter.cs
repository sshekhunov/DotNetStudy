namespace Task7_Reflection;

public class UniversalConverter
{
    public static string ConvertToString(object obj)
    {
        Type type = obj.GetType();
        var propertyValues = type.GetProperties()
                                 .Select(p => $"{p.Name}={p.GetValue(obj)}")
                                 .ToList();

        return string.Join(", ", propertyValues);
    }

    public static T ConvertFromString<T>(string data) where T : new()
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
