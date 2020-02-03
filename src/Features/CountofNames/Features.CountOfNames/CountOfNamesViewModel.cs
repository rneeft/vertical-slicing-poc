using App.Features.MyName.Events;
using App.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Features.CountOfNames
{
    public class CountOfNamesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public CountOfNamesViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.Subscribe<NameSubmittedEvent>(NewNameSubmittedEvent);
        }

        private void NewNameSubmittedEvent(NameSubmittedEvent obj)
        {
            NamesCount++;
        }

        private int count;

        public int NamesCount
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NamesCount"));
            }
        }
    }
}
