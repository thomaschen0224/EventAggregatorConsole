using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventAggregatorConsole.Models;

namespace EventAggregatorConsole.EventArgs
{
    public class PersonCreate
    {

        public Person Person { get; set; }

        public PersonCreate(Person person)
        {
            Person = person;

        }


    }
}
