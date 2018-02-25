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
using ComicApp.DTO;
using ComicApp.Factory;

namespace ComicApp.Views {
    [Activity(Label = "AddAuthor")]
    public class AddAuthor : Activity {

        private IAddAuthorController _controller;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AddAuthor);

            _controller = BuilderController.Instance.GetInstance<IAddAuthorController>(this);

            FindViewById<Button>(Resource.Id.SaveAuthor).Click += SaveAuthor;
        }

        // TODO : Check value not empty
        private void SaveAuthor(object sender, EventArgs args) {
            string firstName = FindViewById<TextView>(Resource.Id.AuthorFirstNameValue).Text;
            string lastName = FindViewById<TextView>(Resource.Id.AuthorLastNameValue).Text;

            string result = _controller.AddNewAuthor(new AuthorDTO() {
                FirstName = firstName,
                LastName = lastName
            });

            if (string.IsNullOrEmpty(result)) {
                SetResult(Result.Ok, new Intent());
                Finish();
            }
        }
    }
}