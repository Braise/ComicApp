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
using Android.Support.V7.Widget;
using ComicApp.DTO;
using ComicApp.Holder;
using Android.Database;

namespace ComicApp.Adapter {
    public class ComicAdapter : RecyclerView.Adapter {

        public IList<ComicDTO> listComic;
        private Context _context;
        public event EventHandler<int> ItemClick;

        public ComicAdapter(Context context, IList<ComicDTO> listComic) {
            this.listComic = listComic;
            _context = context;
        }

        public override int ItemCount => listComic.Count;

        public void OnClick(int position) {
            ItemClick?.Invoke(this, position);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType) {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ComicView, parent, false);
            ComicViewHolder comicHolder = new ComicViewHolder(itemView, OnClick);

            return comicHolder;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position) {
            ComicViewHolder comicHolder = holder as ComicViewHolder;
            comicHolder.Title.Text = listComic[position].Title;
        }
    }
}