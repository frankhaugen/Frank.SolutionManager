namespace Frank.SolutionManager.Tool;

public class ValueConverter : IValueConverter
{
    public string? Convert<T>(T? value)
    {
        if (value == null)
            return null;

        return value.ToString();
    }

    public T? Convert<T>(string? value)
    {
        if (value == null)
            return default;

        return (T?)System.Convert.ChangeType(value, typeof(T));
    }
}