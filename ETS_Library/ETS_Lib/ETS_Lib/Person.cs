using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS_Lib
{
    abstract class Person
    {
        string firstName;
        string lastName;

        public Person(string firstname, string lastname)
        {
            this.firstName = firstname;
            this.lastName = lastname;
        }

        public string Firstname
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string Lastname
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public virtual string toString()
        {
            return Firstname + "," + Lastname;
        }
    }
}
