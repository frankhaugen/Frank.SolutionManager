using System.Text;

namespace Frank.SolutionManager.Legacy;

public class IndentedStringBuilder : IDisposable
{
	private StringBuilder _builder;
	private int _indentLevel = 0;
	private readonly string _indentString;

	public IndentedStringBuilder(string indentString = "    ")  // Default to 4 spaces
	{
		_indentString = indentString;
		_builder = new StringBuilder();
	}

	public IndentedStringBuilder IncreaseIndent(int i = 1)
	{
		_indentLevel += i;
		
		return this;
	}

	public IndentedStringBuilder DecreaseIndent(int i = 1)
	{
		if (_indentLevel > 0 && i > 0 && i <= _indentLevel)
			_indentLevel -= i;
		return this;
	}

	public IndentedStringBuilder Write(string text)
	{
		_builder.Append(new String(_indentString[0], _indentLevel * _indentString.Length));
		_builder.Append(text);
		return this;
	}

	public IndentedStringBuilder WriteLine(string line = "")
	{
		_builder.Append(new String(_indentString[0], _indentLevel * _indentString.Length));
		_builder.AppendLine(line);
		return this;
	}

	public IndentedStringBuilder Write(string format, params object?[] args)
	{
		string formattedText = string.Format(format, args);
		_builder.Append(new String(_indentString[0], _indentLevel * _indentString.Length));
		_builder.Append(formattedText);
		return this;
	}

	public IndentedStringBuilder WriteLine(string format, params object[] args)
	{
		string formattedText = string.Format(format, args);
		_builder.Append(new String(_indentString[0], _indentLevel * _indentString.Length));
		_builder.AppendLine(formattedText);
		return this;
	}

	public IndentedStringBuilder WriteLine(IIndentedStringBuilder other)
	{
		if (other is IndentedStringBuilder otherBuilder)
		{
			string[] lines = otherBuilder.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
			foreach (var line in lines.Where(l => l.Any()))
			{
				this.WriteLine(line);
			}
		}
		return this;
	}

	/// <inheritdoc />
	public void Clear() => _builder.Clear();

	/// <summary>
	/// Returns the string representation of the string being built.
	/// </summary>
	/// <returns></returns>
	public override string ToString() => _builder.ToString();

	/// <inheritdoc />
	public void Dispose()
	{
		_builder.Clear();
		_builder = null!;
	}
}