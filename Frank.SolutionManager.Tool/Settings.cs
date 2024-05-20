using IniSharpLite;

namespace Frank.SolutionManager.Tool;



public class Settings(IValueConverter converter) : ISettings
{
    private readonly Configuration _iniFile = GetIniConfiguration();

    public string? GetValue(SettingKey key, SettingSection section = SettingSection.General) => GetValue(key.ToString(), section.ToString());
    public string? GetValue(string key, string section = "General") => _iniFile[CreateKey(section, key)];
    public void SetValue(string key, string value, string section = "General")
    {
        _iniFile[CreateKey(section, key)] = value;
        _iniFile.SaveChanges();
    }

    public T? GetValue<T>(string key, string section = "General") => converter.Convert<T>(GetValue(key, section));

    public T? GetValue<T>(SettingKey key, SettingSection section = SettingSection.General) => GetValue<T>(key.ToString(), section.ToString());

    public void SetValue<T>(string key, T value, string section = "General") => SetValue(key, converter.Convert(value) ?? string.Empty, section);

    private static string CreateKey(string section, string key) => $"{section}:{key}";
    
    private static Configuration GetIniConfiguration() => new(GetIniFilePath(), false);
    
    private static string GetIniFilePath() => Path.Combine(AppContext.BaseDirectory, "appsettings.ini");
}