using System.Text;

namespace Kunc.RiotGames;

public abstract partial class QueryBuilder
{
    private readonly StringBuilder _stringBuilder;

    /// <summary>
    /// Initializes a new instance of the <see cref="QueryBuilder"/> class. 
    /// </summary>
    /// <param name="stringBuilderCapacity">Default StringBuilder capacity.</param>
    public QueryBuilder(int stringBuilderCapacity)
    {
        _stringBuilder = new(stringBuilderCapacity);
    }
    
    protected abstract void ToStringCore(StringBuilder stringBuilder);

    /// <inheritdoc/>
    public override string ToString()
    {
        _stringBuilder.Length = 0;
        ToStringCore(_stringBuilder);
        if (_stringBuilder.Length > 0 && _stringBuilder[0] == '&')
        {
            _stringBuilder[0] = '?';
        }
        return _stringBuilder.ToString();
    }
}
