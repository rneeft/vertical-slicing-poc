using System.ComponentModel;
using System.Text;

namespace App.Shared.Globalisation
{
    public class Translator : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static Translator Instance { get; } = new Translator();

        public string this[string text]
        {
            get
            {
                return ResourceManager.GetString(text, ResourceManager.CultureInfo);
            }
        }

        public void Invalidate()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}