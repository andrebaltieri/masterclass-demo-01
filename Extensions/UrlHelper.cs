using System.Text.RegularExpressions;

namespace Blog.Extensions;

public static class UrlHelper
{
    public static string ToUrl(this string text)
    {
        text = text
            .ToLower()
            .Replace(" ", "_")
            .Replace("ã", "a")
            .Replace("à", "a")
            .Replace("â", "a")
            .Replace("ä", "a")
            .Replace("á", "a")
	
            .Replace("è", "e")
            .Replace("ê", "e")
            .Replace("é", "e")
            .Replace("ë", "e")

            .Replace("î", "i")
            .Replace("í", "i")
            .Replace("ï", "i")
            .Replace("ì", "i")
	
            .Replace("õ", "o")
            .Replace("ó", "o")
            .Replace("ö", "o")
            .Replace("ô", "o")
            .Replace("ò", "o")
	
            .Replace("ü", "u")
            .Replace("ú", "u")
            .Replace("û", "u")
            .Replace("ù", "u");

        return Regex.Replace(text, @"[^0-9a-zA-Z\._]", "");
    }
}