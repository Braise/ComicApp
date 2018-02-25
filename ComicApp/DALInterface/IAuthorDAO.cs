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

namespace ComicApp.DALInterface {
    public interface IAuthorDAO {

        void InsertAuthor(AuthorDTO author);

        IList<AuthorDTO> ReadAllAuthor();

        AuthorDTO GetAuthor(string firstName, string lastname);
    }
}