using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventAggregatorConsole.Contracts;
using EventAggregatorConsole.EventArgs;

namespace EventAggregatorConsole.Services
{
    public class PersonService: ISubscriber<PersonCreate>, ISubscriber<PersonEdit>, ISubscriber<PersonDelete>
    {

        public PersonService(IEventAggregator eventAggregator)
        {
            eventAggregator.Subscribe(this);
        }


        public void OnEvent(PersonCreate e)
        {
            var person = e.Person;
            var log = $"{person.Id}: {person.FirstName} {person.LastName} was created.";
            Console.WriteLine(log);

        }

        public void OnEvent(PersonEdit e)
        {
            var person = e.Person;
            var log = $"{person.Id}: {person.FirstName} {person.LastName} was edited.";
            Console.WriteLine(log);
        }

        public void OnEvent(PersonDelete e)
        {
            var person = e.Person;
            var log = $"{person.Id}: {person.FirstName} {person.LastName} was deleted.";
            Console.WriteLine(log);
        }
    }
}
