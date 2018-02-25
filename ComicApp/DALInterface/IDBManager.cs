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

namespace ComicApp.DALInterface {
    public interface IDBManager {

        void Insert<T>(T toInsert);

        ComicDTO GetSingleComic(int id);

        IList<ComicDTO> GetAllComics();

        IList<ComicDTO> GetComics(string query);

        AuthorDTO GetSingleAuthor(int id);

        AuthorDTO GetSingleAuthor(string firstName, string lastName);

        IList<AuthorDTO> GetAllAuthors();

        IList<AuthorDTO> GetAuthors(string query);

        HeroDTO GetSinglHero(int id);

        HeroDTO GetSingleHero(string name);

        IList<HeroDTO> GetAllHeroes();

        IList<AuthorDTO> GetHeroes(string query);
    }
}