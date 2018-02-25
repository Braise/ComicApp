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
using Android.Database.Sqlite;
using ComicApp.DTO;
using ComicApp.DALInterface;
using ComicApp.Factory;
using Android.Database;
using SQLite;

namespace ComicApp.DAL {
    public class ComicDAO : IComicDAO {

        private IDBManager _db;

        public ComicDAO() {
            _db = BuilderDAL.Instance.GetInstance<IDBManager>();
        }

        public void InsertComic(ComicDTO comic) {
            _db.Insert(comic);
        }

        public IList<ComicDTO> ReadAllComics() {
            return _db.GetAllComics();
        }
    }
}