namespace Frank.SolutionManager.Tool;

public interface ISettings
{
    string? GetValue(SettingKey key, SettingSection section = SettingSection.General);
    string? GetValue(string key, string section = "General");
    void SetValue(string key, string value, string section = "General");
    T? GetValue<T>(string key, string section = "General");
    T? GetValue<T>(SettingKey key, SettingSection section = SettingSection.General);
    void SetValue<T>(string key, T value, string section = "General");
}