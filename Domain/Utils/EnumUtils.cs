namespace Domain.Utils;

public static class EnumUtils
{
    public static T GetRandomEnumValue<T>() where T : Enum
    {
        var values = Enum.GetValues(typeof(T));
        if (values.Length == 0)
        {
            throw new NotImplementedException();
        }

        var value = (T?)values.GetValue(Random.Shared.Next(values.Length));
        if (value == null)
        {
            throw new NotImplementedException();
        }

        return value;
    }
}