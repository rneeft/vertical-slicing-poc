using System.Globalization;

namespace App.Shared.Globalisation
{
    public class Text
    {
        private readonly string en;
        private readonly string nl;

        public Text(string en, string nl)
        {
            this.en = en;
            this.nl = nl;
        }

        public string GetString(CultureInfo info)
        {
            if (info != null)
            {
                if (info.TwoLetterISOLanguageName == "en")
                    return en;
            }

            return nl;
        }
    }
}