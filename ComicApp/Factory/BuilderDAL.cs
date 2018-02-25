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
using ComicApp.DAL;

namespace ComicApp.Factory {
    public class BuilderDAL {
        private static BuilderDAL instance;

        private BuilderDAL() { }

        public static BuilderDAL Instance {
            get {
                if (instance == null) {
                    instance = new BuilderDAL();
                }
                return instance;
            }
        }

        public T GetInstance<T>() {
            if (typeof(T) == typeof(IComicDAO)) {
                return (T)(IComicDAO)new ComicDAO();
            }
            else if(typeof(T) == typeof(IDBManager)) {
                return (T)(IDBManager)new DBManager();
            }
            else if(typeof(T) == typeof(IAuthorDAO)) {
                return (T)(IAuthorDAO)new AuthorDAO();
            }
            else if(typeof(T) == typeof(IHeroDAO)) {
                return (T)(IHeroDAO)new HeroDAO();
            }
            throw new NotImplementedException();
        }
    }
}