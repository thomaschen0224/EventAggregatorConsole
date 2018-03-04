using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregatorConsole.Contracts
{
    public interface IEventAggregator
    {
        // if you are using Ninject, you do not need to subscribe anymore.
        void Subscribe(object subscriber);

        void Publish<TEvent>(TEvent eventToPublish) where TEvent : class;






    }
}
