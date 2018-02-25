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
using ComicApp.DTO;
using Android.Database;

namespace ComicApp.DALInterface {
    interface IComicDAO {

        void InsertComic(ComicDTO comic);
        IList<ComicDTO> ReadAllComics();
    }
}