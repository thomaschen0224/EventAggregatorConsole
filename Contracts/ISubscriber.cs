using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregatorConsole.Contracts
{
    public interface ISubscriber<in T> where T:class 
    {
        void OnEvent(T e);

    }
}
