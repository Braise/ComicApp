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
using ComicApp.ControllerInterfaces;
using ComicApp.DALInterface;
using ComicApp.Factory;

namespace ComicApp.Controllers {
    public class AddComicController : IAddComicController {
        private Context _context;
        private IComicDAO _comicDAO;
        private IAuthorDAO _authorDAO;
        private IHeroDAO _heroDAO;

        public AddComicController(Context context) {
            _context = context;
            _comicDAO = BuilderDAL.Instance.GetInstance<IComicDAO>();
            _authorDAO = BuilderDAL.Instance.GetInstance<IAuthorDAO>();
            _heroDAO = BuilderDAL.Instance.GetInstance<IHeroDAO>();
        }

        public IList<AuthorDTO> GetAllAuthors() {
            return _authorDAO.ReadAllAuthor();
        }

        public IList<HeroDTO> GetAllHeroes() {
            return _heroDAO.ReadAllHeroes();
        }

        public void AddComic(ComicDTO toAdd) {
            if (!CheckComic(toAdd)) {
                return; // launch exception
            }

            _comicDAO.InsertComic(toAdd);
        }

        private bool CheckComic(ComicDTO toCheck) {

            if (string.IsNullOrEmpty(toCheck.Series)) {
                return false;
            }

            if (string.IsNullOrEmpty(toCheck.Title)) {
                return false;
            }

            return true;
        }
    }
}