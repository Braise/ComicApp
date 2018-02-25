using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ComicApp.DTO {
    [Table("Author")]
    public class AuthorDTO {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [ManyToMany(typeof(ComicAuthorDTO), CascadeOperations = CascadeOperation.All)]
        List<ComicDTO> Comics { get; set; }
    }
}