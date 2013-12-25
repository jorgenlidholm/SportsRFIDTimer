using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class User
    {
        public User(String name, int number)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException("Name may not be empty.", "name");
            if (number < 0)
                throw new ArgumentException("Number must be greater than or equal to 0.", "number");
            Id = Guid.NewGuid();
            Name = name;
            Number = number;
        }

        public Guid Id { get; private set; }
        public String Name { get; set; }
        public int Number { get; set; }
        public string TagId { get; set; }
        public String Meta { get; set; }
        public String Email { get; set; }
    }
}
