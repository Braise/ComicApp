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
    [Activity(Label = "AddHero")]
    public class AddHero : Activity {
        private IAddHeroController _controller;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AddHero);

            _controller = BuilderController.Instance.GetInstance<IAddHeroController>(this);

            FindViewById<Button>(Resource.Id.SaveHero).Click += SaveHero;
        }

        // TODO : Check value not empty
        private void SaveHero(object sender, EventArgs args) {
            string name = FindViewById<TextView>(Resource.Id.HeroNameValue).Text;

            string result = _controller.AddNewHero(new HeroDTO() {
                Name = name
            });

            if (string.IsNullOrEmpty(result)) {
                SetResult(Result.Ok, new Intent());
                Finish();
            }
        }
    }
}