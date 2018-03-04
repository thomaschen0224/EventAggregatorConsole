using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventAggregatorConsole.Contracts;
using EventAggregatorConsole.NinjectBindings;
using Ninject;

namespace EventAggregatorConsole
{
    public static class InstanceFactory
    {

        private static readonly IKernel Kernel;

        static InstanceFactory()
        {
            try
            {
                Kernel = new StandardKernel(new NinjectBinding());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }


        public static IEventAggregator EventAggregator => Kernel.Get<IEventAggregator>();

        public static ISubscriber<TEvent> GetSubscriber<TEvent>() where TEvent:class
        {
            return Kernel.Get<ISubscriber<TEvent>>();
        }





    }
}
