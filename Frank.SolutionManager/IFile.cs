namespace Frank.SolutionManager;

public interface IFile : INamed
{
    [JsonConverter(typeof(FileInfoJsonConverter))]
    FileInfo FileInfo { get; }
    
    string RelativePath { get; }
}