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
using ComicApp.Controllers;
using ComicApp.Factory;
using ComicApp.ControllerInterfaces;
using ComicApp.DTO;

namespace ComicApp.Views {
    [Activity(Label = "AddComic")]
    public class AddComic : Activity {
        private IAddComicController _controller;
        private IList<AuthorDTO> _authorList;
        private IList<HeroDTO> _heroList;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AddComic);

            _controller = BuilderController.Instance.GetInstance<IAddComicController>(this);

            SetSpinnerAuthor();
            SetSpinnerHero();

            FindViewById<Button>(Resource.Id.SaveComic).Click += SaveComic;
            FindViewById<Button>(Resource.Id.CreateAuthor).Click += CreateAuthor;
            FindViewById<Button>(Resource.Id.CreateHero).Click += CreateHero;
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data) {
            SetSpinnerAuthor();
            SetSpinnerHero();
        }

        private void SetSpinnerAuthor() {
            _authorList = _controller.GetAllAuthors();

            Spinner authorSelect = FindViewById<Spinner>(Resource.Id.SelectAuthor);
            if (_authorList == null || _authorList.Count == 0) {
                authorSelect.Visibility = ViewStates.Invisible;
            }
            else {
                IList<string> names = _authorList.Select(o => o.FirstName + " " + o.LastName).ToList();
                ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, names);
                authorSelect.Adapter = adapter;
                authorSelect.Visibility = ViewStates.Visible;
            }
        }

        private void SetSpinnerHero() {
            _heroList = _controller.GetAllHeroes();

            Spinner heroSelect = FindViewById<Spinner>(Resource.Id.SelectHero);
            if (_heroList == null || _heroList.Count == 0) {
                heroSelect.Visibility = ViewStates.Invisible;
            }
            else {
                IList<string> names = _heroList.Select(o => o.Name).ToList();
                ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, names);
                heroSelect.Adapter = adapter;
                heroSelect.Visibility = ViewStates.Visible;
            }
        }

        private void SaveComic(object sender, EventArgs args) {
            string title = FindViewById<TextView>(Resource.Id.TitleValue).Text;
            string series = FindViewById<TextView>(Resource.Id.SeriesValue).Text;
            Spinner authorSelect = FindViewById<Spinner>(Resource.Id.SelectAuthor);
            AuthorDTO author =_authorList[authorSelect.SelectedItemPosition];

            _controller.AddComic(new ComicDTO {
                Title = title,
                Series = series,
                Authors = new List<AuthorDTO>() { author }
            });

            Finish();
        }

        private void CreateAuthor(object sender, EventArgs args) {
            Intent activity = new Intent(this, typeof(AddAuthor));

            StartActivityForResult(activity, 0);
        }

        private void CreateHero(object sender, EventArgs args) {
            Intent activity = new Intent(this, typeof(AddHero));

            StartActivityForResult(activity, 0);
        }
    }
}