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
using SQLiteNetExtensions.Attributes;

namespace ComicApp.DTO {
    public class ComicHeroDTO {
        [ForeignKey(typeof(AuthorDTO))]
        public int IdHero { get; set; }
        [ForeignKey(typeof(ComicDTO))]
        public int IdComic { get; set; }
    }
}