using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace App.Shared.Globalisation
{
    public static class ResourceManager
    {
        private static Dictionary<string, Text> translations = new Dictionary<string, Text>();

        public static string GetString(string text, CultureInfo cultureInfo) => translations[text].GetString(cultureInfo);

        public static void AddTranslation(IReadOnlyDictionary<string, Text> translation) => translations = translations.Union(translation).ToDictionary(k => k.Key, v => v.Value);

        public static CultureInfo CultureInfo { get; set; }
    }
}