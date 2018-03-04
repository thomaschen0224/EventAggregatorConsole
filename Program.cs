using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventAggregatorConsole.Concretes;
using EventAggregatorConsole.Contracts;
using EventAggregatorConsole.EventArgs;
using EventAggregatorConsole.Models;
using EventAggregatorConsole.Services;

namespace EventAggregatorConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Practices of event aggregator");
            
            //IEventAggregator ea = new SimpleEventAggregator();
            //var service = new PersonService(ea);

            var ea = InstanceFactory.EventAggregator;

            var pCreate = new PersonCreate(new Person() {Id = 3, LastName = "Test", FirstName = "Sally"});
            var pDelete = new PersonDelete(new Person() { Id = 5, LastName = "Test", FirstName = "Dora" });
            var pEdit = new PersonEdit(new Person() { Id = 9, LastName = "Test", FirstName = "Thomas" });

            ea.Publish(pCreate);
            ea.Publish(pDelete);
            ea.Publish(pEdit);
            


            Console.ReadLine();



        }
    }
}
