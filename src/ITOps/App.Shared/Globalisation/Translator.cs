using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
                //return AppResources.ResourceManager.GetString(text, AppResources.Culture);
            }
        }

        public void Invalidate()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }

    public class TranslateExtension : IMarkupExtension<BindingBase>
    {
        public TranslateExtension(string text)
        {
            Text = text;
        }

        public string Text { get; set; }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }

        public BindingBase ProvideValue(IServiceProvider serviceProvider)
        {
            var binding = new Binding
            {
                Mode = BindingMode.OneWay,
                Path = $"[{Text}]",
                Source = Translator.Instance,
            };
            return binding;
        }
    }

    public class Text
    {
        public string EN { get; set; }
        public string FR { get; set; }
        public string NL { get; set; }

        public Text(string en, string nl, string fr)
        {

        }
    }

    public class LocalisationProvider
    {

    }



    public class ITranslationProvider
    {
        IReadOnlyDictionary<string, Text> String;
    }

    public class Languages : ITranslationProvider
    {

        public IReadOnlyDictionary<string, Text> String = new Dictionary<string, Text>
        {
            {
                "Cancel", new Text
                (
                    en : "Cancel",
                    fr : "Annuler",
                    nl : "Annuleren"
                )
            },
            {
                "Close", new Text
                (
                    en : "Close",
                    fr : "Fermer",
                    nl : "Sluiten"
                )
            },
        };
    }
}