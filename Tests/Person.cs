using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace Tests {
    public class Person {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int? Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        [ManyToMany(typeof(PersonAddress),CascadeOperations = CascadeOperation.All)]
        public List<Address> Place { get; set; }
    }
}
