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
using ComicApp.DTO;
using ComicApp.Factory;

namespace ComicApp.Controllers {
    public class AddAuthorController : IAddAuthorController {
        private Context _context;
        private IAuthorDAO _authorDAO;

        public AddAuthorController(Context context) {
            _context = context;
            _authorDAO = BuilderDAL.Instance.GetInstance<IAuthorDAO>();
        }

        public string AddNewAuthor(AuthorDTO toAdd) {
            AuthorDTO result = _authorDAO.GetAuthor(toAdd.FirstName, toAdd.LastName);

            if(result != null) { // TODO : add error message
                return "Cet auteur existe déjà!";
            }

            _authorDAO.InsertAuthor(toAdd);

            return null;
        }
    }
}