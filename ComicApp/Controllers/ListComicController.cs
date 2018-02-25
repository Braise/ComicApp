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
using ComicApp.ControllerInterfaces;
using ComicApp.DALInterface;
using ComicApp.Factory;
using Android.Database;
using ComicApp.DTO;

namespace ComicApp.Controllers {
    public class ListComicController : IListComicController {

        private Context _context;
        private IComicDAO _comicDAO;

        public ListComicController(Context context) {
            _context = context;
            _comicDAO = BuilderDAL.Instance.GetInstance<IComicDAO>();
        }

        public IList<ComicDTO> GetAllComics() {
            return _comicDAO.ReadAllComics();
        }
    }
}