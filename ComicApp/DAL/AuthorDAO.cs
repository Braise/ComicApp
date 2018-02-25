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
using ComicApp.DALInterface;
using ComicApp.Factory;
using ComicApp.DTO;

namespace ComicApp.DAL {
    public class AuthorDAO : IAuthorDAO {
        private IDBManager _db;

        public AuthorDAO() {
            _db = BuilderDAL.Instance.GetInstance<IDBManager>();
        }

        public void InsertAuthor(AuthorDTO author) {
             _db.Insert(author);
        }

        public IList<AuthorDTO> ReadAllAuthor() {
            return _db.GetAllAuthors();
        }

        public AuthorDTO GetAuthor(string firstName, string lastname) {
            return _db.GetSingleAuthor(firstName, lastname);
        }
    }
}