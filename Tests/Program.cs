using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Extensions;
using SQLite;

namespace Tests {
    class Program {
        static void Main(string[] args) {
            SQLiteConnection db = new SQLiteConnection("Test");
            db.CreateTable<Person>();
            db.CreateTable<Address>();
            db.CreateTable<PersonAddress>();
            
            Person p = new Person() { Firstname = "Bastien", Lastname = "Boonen" };
            Person p2 = new Person() { Firstname = "Benoit", Lastname = "Boonen" };
            Address a1 = new Address() { Street = "Rue du Doignion", Town = "Braine l'Alleud", Country = "Belgique" };
            Address a2 = new Address() { Street = "Rue Wayiez", Town = "Braine l'Alleud", Country = "Belgique" };
            p.Place = new List<Address>();
            p.Place.Add(a1);

            p2.Place = new List<Address>();
            p2.Place.Add(a1);
            p2.Place.Add(a2);

            //db.InsertWithChildren(p, recursive: true);
            db.InsertWithChildren(p2, recursive: true);

            //p.AddressId = db.Insert(new Address() { Street = "Rue du Doignion", Town = "Braine l'Alleud", Country = "Belgique" });
            //p2.AddressId = p.AddressId;
            //db.Insert(p);

            //Address result = db.Query<Address>("select a.* from Address a where a.Id = ?", p.AddressId).FirstOrDefault();

            //Address a = db.GetWithChildren<Address>(p2.AddressId);

            IList<Address> addresses = db.GetAllWithChildren<Address>();
            IList<Person> persons = db.GetAllWithChildren<Person>();

            string empty = string.Empty;
        }
    }
}
