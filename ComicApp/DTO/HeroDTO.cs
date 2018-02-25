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
    [Table("Hero")]
    public class HeroDTO {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }

        [ManyToMany(typeof(ComicHeroDTO), CascadeOperations = CascadeOperation.All)]
        List<ComicDTO> Comics { get; set; }
    }
}