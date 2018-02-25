using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace Tests {

    public class Address {

        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int? Id { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string Country { get; set; }

        [ManyToMany(typeof(PersonAddress), CascadeOperations = CascadeOperation.All)]
        public List<Person> Residents { get; set; }
    }
}
