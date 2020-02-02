using App.Features.MyName.Events;
using App.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Feature.MyName
{
    public class MyNameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IEventAggregator eventAggregator;

        public ICommand SubmitMyNameCommand => new Command<string>(Submit);

        public MyNameViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }

        public void Submit(string name)
        {
            TheName = $"Hello {name}!";

            eventAggregator.Send(new NameSubmittedEvent { Name = name });
        }

        private string theName;

        public string TheName
        {
            get
            {
                return theName;
            }
            set
            {
                theName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TheName"));
            }
        }
    }
}
