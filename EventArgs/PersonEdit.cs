using EventAggregatorConsole.Models;

namespace EventAggregatorConsole.EventArgs
{
    public class PersonEdit
    {
        public Person Person { get; set; }

        public PersonEdit(Person person)
        {
            Person = person;

        }


    }
}