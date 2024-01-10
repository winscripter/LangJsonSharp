using Newtonsoft.Json;

namespace LangJsonSharp;

internal class ByCultureLoader
{
    internal static string GetTwoLetterCulture()
        => Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;

    internal static string GetFourLetterCulture()
        => Thread.CurrentThread.CurrentUICulture.Name;

    public static Dictionary<string, string> LoadJson(string content)
    {
        return JsonConvert.DeserializeObject<Dictionary<string, string>>(content)!;
    }

    public static (bool Success, string Name, string Culture) FindTwoLetterCultureJson(string prefix)
    {
        return (
            File.Exists($"{prefix}.{GetTwoLetterCulture()}.json"),
            $"{prefix}.{GetTwoLetterCulture()}.json",
            GetTwoLetterCulture()
        );
    }

    public static (bool Success, string Name, string Culture) FindFourLetterCultureJson(string prefix)
    {
        return (
            File.Exists($"{prefix}.{GetFourLetterCulture()}.json"),
            $"{prefix}.{GetFourLetterCulture()}.json",
            GetFourLetterCulture()
        );
    }
}
