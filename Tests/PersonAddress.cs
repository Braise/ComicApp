using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests {
    public class PersonAddress {
        [ForeignKey(typeof(Address))]
        public int AddressId { get; set; }
        [ForeignKey(typeof(Person))]
        public int PersonId { get; set; }
    }
}
