using System.Text.Json;

namespace Frank.SolutionManager;

public class DirectoryInfoJsonConverter : JsonConverter<DirectoryInfo>
{
    /// <inheritdoc />
    public override DirectoryInfo? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (value is null) return null;
        var directoryInfo = new DirectoryInfo(value);
        return directoryInfo;
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, DirectoryInfo value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.FullName);
    }
}

public class FileInfoJsonConverter : JsonConverter<FileInfo>
{
    /// <inheritdoc />
    public override FileInfo? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (value is null) return null;
        var fileInfo = new FileInfo(value);
        return fileInfo;
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, FileInfo value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.FullName);
    }
}