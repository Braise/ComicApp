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

    public class ComicAuthorDTO {
        [ForeignKey(typeof(AuthorDTO))]
        public int IdAuthor { get; set; }
        [ForeignKey(typeof(ComicDTO))]
        public int IdComic { get; set; }
    }
}