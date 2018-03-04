using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventAggregatorConsole.Concretes;
using EventAggregatorConsole.Contracts;
using EventAggregatorConsole.EventArgs;
using EventAggregatorConsole.Services;
using Ninject.Modules;

namespace EventAggregatorConsole.NinjectBindings
{
    public class NinjectBinding:NinjectModule
    {
        public override void Load()
        {

            // Event Aggregator
            Bind<IEventAggregator>().To<NinjectEventAggregator>();


            // Services
            Bind<ISubscriber<PersonCreate>>().To<PersonService>();
            Bind<ISubscriber<PersonDelete>>().To<PersonService>();
            Bind<ISubscriber<PersonEdit>>().To<PersonService>();


        }
    }
}
