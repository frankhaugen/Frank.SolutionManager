using System.Xml.Linq;

namespace Frank.SolutionManager;

public interface IXDocument
{
    XDocument Document { get; } 
}