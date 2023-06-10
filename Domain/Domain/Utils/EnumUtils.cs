using Domain.Common.Exceptions;

namespace Domain.Utils;

public static class EnumUtils
{
    public static T GetRandomEnumValue<T>() where T : Enum
    {
        var values = Enum.GetValues(typeof(T)).Cast<T?>().Where(value => value != null).Cast<T>().ToList();

        if (!values.Any())
        {
            throw EnumUtilsException.NoValues(typeof(T));
        }

        return values[Random.Shared.Next(values.Count)];
    }
}