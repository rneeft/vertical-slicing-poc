using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App.Shared
{
    public interface IEventAggregator
    {
        void Send<T>(T message);
        void Subscribe<T>(Action<T> action);

    }

    public class EventAggregator : IEventAggregator
    {
        private readonly IMessagingCenter messagingCenter;

        public EventAggregator(IMessagingCenter messagingCenter)
        {
            this.messagingCenter = messagingCenter;
        }

        public void Send<T>(T message)
        {
            messagingCenter.Send(this, nameof(T), message);
        }

        public void Subscribe<T>(Action<T> action)
        {
            Action<EventAggregator, T> actionX = (_, t) => 
            {
                action(t);
            };

            messagingCenter.Subscribe(this, nameof(T), actionX);
        }
    }



    public class TheApp
    {
    }
}
