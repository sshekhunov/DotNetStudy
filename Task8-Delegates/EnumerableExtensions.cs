namespace Task8_Delegates;

public static class EnumerableExtensions
{
    public static T? GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        T? maxItem = null;
        float maxValue = float.NegativeInfinity;

        foreach (var item in collection)
        {
            var value = convertToNumber(item);
            if (value > maxValue)
            {
                maxValue = value;
                maxItem = item;
            }
        }

        return maxItem;
    }
}
