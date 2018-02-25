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
using ComicApp.DTO;
using ComicApp.Factory;

namespace ComicApp.DAL {
    public class HeroDAO : IHeroDAO {
        private IDBManager _db;

        public HeroDAO() {
            _db = BuilderDAL.Instance.GetInstance<IDBManager>();
        }

        public void InsertHero(HeroDTO hero) {
            _db.Insert(hero);
        }

        public IList<HeroDTO> ReadAllHeroes() {
            return _db.GetAllHeroes();
        }

        public HeroDTO GetHero(string name) {
            return _db.GetSingleHero(name);
        }
    }
}