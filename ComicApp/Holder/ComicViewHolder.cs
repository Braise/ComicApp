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

namespace ComicApp.Holder {
    public class ComicViewHolder : RecyclerView.ViewHolder {
        
        public TextView Title { get; private set; }

        public ComicViewHolder(View itemView, Action<int> listener) : base(itemView){
            Title = itemView.FindViewById<TextView>(Resource.Id.titleComic);
            itemView.Click += (sender, e) => listener(base.LayoutPosition);
        }

    }
}