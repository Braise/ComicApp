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
using SQLiteNetExtensions.Extensions;
using ComicApp.DTO;
using ComicApp.DALInterface;

namespace ComicApp.DAL {
    public class DBManager : IDBManager {
        private SQLiteConnection _connection;

        public DBManager() {
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            _connection = new SQLiteConnection(System.IO.Path.Combine(folder, "collection.db"));
            DropAllTables();
            CreateTables();
        }

        private void CreateTables() {
            _connection.CreateTable<ComicDTO>();
            _connection.CreateTable<AuthorDTO>();
            _connection.CreateTable<ComicAuthorDTO>();
            _connection.CreateTable<HeroDTO>();
            _connection.CreateTable<ComicHeroDTO>();
        }

        private void DropAllTables() {
            _connection.DropTable<ComicDTO>();
            _connection.DropTable<AuthorDTO>();
            _connection.DropTable<ComicAuthorDTO>();
        }

        public void Insert<T>(T toInsert) {
             _connection.InsertWithChildren(toInsert, recursive: true);
        }

        /* Comics */

        public ComicDTO GetSingleComic(int id) {
            return _connection.GetWithChildren<ComicDTO>(id);
        }

        public IList<ComicDTO> GetAllComics() {
            return _connection.GetAllWithChildren<ComicDTO>();
        }

        public IList<ComicDTO> GetComics(string query) {
            return _connection.Query<ComicDTO>(query);
        }

        /* Authors */

        public AuthorDTO GetSingleAuthor(int id) {
            return _connection.GetWithChildren<AuthorDTO>(id);
        }

        public AuthorDTO GetSingleAuthor(string firstName, string lastName) {
            return _connection.Query<AuthorDTO>("SELECT * FROM AUTHOR WHERE FIRSTNAME = ? AND LASTNAME = ?", firstName, lastName).FirstOrDefault();
        }

        public IList<AuthorDTO> GetAllAuthors() {
            return _connection.GetAllWithChildren<AuthorDTO>();
        }

        public IList<AuthorDTO> GetAuthors(string query) {
            return _connection.Query<AuthorDTO>(query);
        }

        /* Heroes */

        public HeroDTO GetSinglHero(int id) {
            return _connection.GetWithChildren<HeroDTO>(id);
        }

        public HeroDTO GetSingleHero(string name) {
            return _connection.Query<HeroDTO>("SELECT * FROM HERO WHERE NAME = ?", name).FirstOrDefault();
        }

        public IList<HeroDTO> GetAllHeroes() {
            return _connection.GetAllWithChildren<HeroDTO>();
        }

        public IList<AuthorDTO> GetHeroes(string query) {
            return _connection.Query<AuthorDTO>(query);
        }
    }
}