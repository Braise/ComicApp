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
    [Table("Comics")]
    public class ComicDTO {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Series { get; set; }

        [ManyToMany(typeof(ComicAuthorDTO), CascadeOperations = CascadeOperation.All)]
        public List<AuthorDTO> Authors { get; set; }

        [ManyToMany(typeof(ComicHeroDTO), CascadeOperations = CascadeOperation.All)]
        public List<HeroDTO> Heroess { get; set; }
    }
}