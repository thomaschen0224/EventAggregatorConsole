using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EventAggregatorConsole.Contracts;

namespace EventAggregatorConsole.Concretes
{
    public class NinjectEventAggregator: IEventAggregator
    {

        public void Subscribe(object subscriber)
        {
            
            // By using Ninject, we do not need this.


        }

        public void Publish<TEvent>(TEvent eventToPublish) where TEvent : class
        {

            try
            {

                var subscriber = InstanceFactory.GetSubscriber<TEvent>();
                var syncContext = SynchronizationContext.Current ?? new SynchronizationContext();
                syncContext.Post(s => subscriber.OnEvent(eventToPublish), null);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            

        }
    }
}
