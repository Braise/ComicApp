using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using ComicApp.DTO;
using System.Collections.Generic;
using ComicApp.Adapter;
using Android.Support.V7.Widget;
using Android.Content;
using ComicApp.Views;
using ComicApp.ControllerInterfaces;
using ComicApp.Factory;
using Android.Database;

namespace ComicApp {
    [Activity(Label = "ComicApp", MainLauncher = true)]
    public class ComicList : Activity {

        private IList<ComicDTO> _listComics;
        private ComicAdapter _comicAdapter;
        private RecyclerView _recyclerView;
        private RecyclerView.LayoutManager _layoutManager;
        private IListComicController _controller;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _controller = BuilderController.Instance.GetInstance<IListComicController>(this);

            // Set menu
            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "ComicDTO's";

            PopulateRecyclerView();

            _layoutManager = new LinearLayoutManager(this);
            _recyclerView.SetLayoutManager(_layoutManager);
        }

        public override bool OnCreateOptionsMenu(IMenu menu) {
            MenuInflater.Inflate(Resource.Menu.TopMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item) {
            int id = item.ItemId;

            if(id == Resource.Id.menu_add) {
                StartActivity();
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        protected override void OnResume() {
            base.OnResume();
            PopulateRecyclerView();
        }

        public void OnItemClick(object sender, int position) {
            int comicNum = position + 1;
            Toast.MakeText(this, "This is comic number " + comicNum, ToastLength.Short).Show();
        }

        private void PopulateRecyclerView() {
            // Data source
            _listComics = _controller.GetAllComics();

            // Adapter, pass in it the data source
            _comicAdapter = new ComicAdapter(this, _listComics);
            _comicAdapter.ItemClick += OnItemClick;

            // Get recycler view layout
            _recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            // Plug the adapter into the recyclerView
            _recyclerView.SetAdapter(_comicAdapter);
        }

        private void StartActivity() {
            Intent intent = new Intent(this, typeof(AddComic));
            StartActivity(intent);
        }
    }
}

