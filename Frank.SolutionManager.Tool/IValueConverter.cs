namespace Frank.SolutionManager.Tool;

public interface IValueConverter
{
    string? Convert<T>(T? value);
    T? Convert<T>(string? value);
}