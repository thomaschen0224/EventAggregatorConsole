using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregatorConsole.Contracts
{
    public interface IEventAggregator
    {

        void Subscribe(object subscriber);
        void Publish<TEvent>(TEvent eventToPublish) where TEvent : class;






    }
}
