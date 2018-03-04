using EventAggregatorConsole.Models;

namespace EventAggregatorConsole.EventArgs
{
    public class PersonDelete
    {
        public Person Person { get; set; }

        public PersonDelete(Person person)
        {
            Person = person;
        }


    }
}