namespace LangJsonSharp;

public class MultipleLanguageManager
{
    private readonly string? _currentThreadUICulture;
    private readonly Dictionary<string, string>? _resources;

    private MultipleLanguageManager()
    {
        _currentThreadUICulture = Thread.CurrentThread.CurrentCulture.Name;
    }

    public MultipleLanguageManager(string prefix)
        : this()
    {
        _resources = ByCultureLoader.LoadJson(File.ReadAllText(ByCultureLoader.FindFourLetterCultureJson(prefix).Name));
    }

    public MultipleLanguageManager(string prefix, CultureLetterKind kind)
        : this()
    {
        _resources = kind switch
        {
            CultureLetterKind.Two => ByCultureLoader.LoadJson(ByCultureLoader.FindTwoLetterCultureJson(prefix).Name),
            CultureLetterKind.Four => ByCultureLoader.LoadJson(ByCultureLoader.FindFourLetterCultureJson(prefix).Name),
            _ => throw new ArgumentException("Unknown culture letter kind", nameof(kind)),
        };
    }

    public MultipleLanguageManager(string cultureName, string prefix)
        : this(prefix)
    {
        _currentThreadUICulture = cultureName;
    }

    public MultipleLanguageManager(string cultureName, string prefix, CultureLetterKind kind)
        : this(prefix, kind)
    {
        _currentThreadUICulture = cultureName;
    }

    public string GetResource(string res)
    {
        return _resources![res];
    }

    public string CurrentThreadUICulture
    {
        get
        {
            return _currentThreadUICulture!;
        }
    }

    public string this[string res]
    {
        get
        {
            return _resources![res];
        }
    }
}
