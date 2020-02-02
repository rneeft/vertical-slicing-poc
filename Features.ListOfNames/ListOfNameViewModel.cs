using App.Features.MyName.Events;
using App.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Features.ListOfNames
{
    public class ListOfNameViewModel : INotifyPropertyChanged
    {
        private readonly IEventAggregator eventAggregator;

        public ListOfNameViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            eventAggregator.Subscribe<NameSubmittedEvent>(NewNameSubmittedEvent);
        }
        
        public ObservableCollection<string> Names { get; } = new ObservableCollection<string>();

        public event PropertyChangedEventHandler PropertyChanged;

        private void NewNameSubmittedEvent(NameSubmittedEvent obj)
        {
            Names.Add(obj.Name);
        }
    }
}
