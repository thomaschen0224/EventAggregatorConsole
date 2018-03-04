using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EventAggregatorConsole.Contracts;

namespace EventAggregatorConsole.Concretes
{
    public class SimpleEventAggregator: IEventAggregator
    {


        private readonly Dictionary<Type, List<WeakReference>> _eventSubcriberLists = new Dictionary<Type, List<WeakReference>>();
        private readonly object _lock = new object();


        public void Subscribe(object subscriber)
        {

            lock (_lock)
            {

                var subscriberTypes = subscriber.GetType().GetInterfaces().Where(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISubscriber<>));

                var weakReference = new WeakReference(subscriber);

                foreach (var subscriberType in subscriberTypes)
                {
                    var subscribers = GetSubscribers(subscriberType);
                    subscribers.Add(weakReference);

                }




            }

            
        }

        private List<WeakReference> GetSubscribers(Type subscriberType)
        {
            List<WeakReference> subscribers;
            lock (_lock)
            {
                var isFound = _eventSubcriberLists.TryGetValue(subscriberType, out subscribers);
                if (!isFound)
                {
                    subscribers = new List<WeakReference>();
                    _eventSubcriberLists.Add(subscriberType, subscribers);
                }

            }

            return subscribers;


        }

        public void Publish<TEvent>(TEvent eventToPublish) where TEvent : class
        {

            var subscriberType = typeof(ISubscriber<>).MakeGenericType(typeof(TEvent));
            var subscribers = GetSubscribers(subscriberType);
            var subscribersToRemove = new List<WeakReference>();

            foreach (var weakReference in subscribers)
            {
                if (weakReference.IsAlive)
                {
                    var subscriber = (ISubscriber<TEvent>) weakReference.Target;
                    var syncContext = SynchronizationContext.Current ?? new SynchronizationContext();
                    syncContext.Post(s=> subscriber.OnEvent(eventToPublish), null);

                }
                else
                {
                    subscribersToRemove.Add(weakReference);
                }
                
            }

            if (subscribersToRemove.Any())
            {
                lock (_lock)
                {
                    foreach (var weakReference in subscribersToRemove)
                    {
                        subscribers.Remove(weakReference);
                    }
                }
            }





        }
    }
}
