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

namespace ComicApp.Controllers {
    public class AddHeroController {
        private Context _context;
        private IHeroDAO _heroDAO;

        public AddHeroController(Context context) {
            _context = context;
            _heroDAO = BuilderDAL.Instance.GetInstance<IHeroDAO>();
        }

        public string AddNewHero(HeroDTO toAdd) {
            HeroDTO result = _heroDAO.GetHero(toAdd.Name);

            if (result != null) { // TODO : add error message
                return "Cet héro existe déjà!";
            }

            _heroDAO.InsertHero(toAdd);

            return null;
        }
    }
}