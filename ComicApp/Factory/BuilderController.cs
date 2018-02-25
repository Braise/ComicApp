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
using ComicApp.ControllerInterfaces;

namespace ComicApp.Factory {
    public class BuilderController {
        private static BuilderController instance;

        private BuilderController() { }

        public static BuilderController Instance {
            get {
                if(instance == null) {
                    instance = new BuilderController();
                }

                return instance;
            }
        }

        public T GetInstance<T>(Context context) {
            if (typeof(T) == typeof(IAddComicController)) {
                return (T)(IAddComicController)new AddComicController(context);
            }
            else
            if (typeof(T) == typeof(IListComicController)) {
                return (T)(IListComicController)new ListComicController(context);
            }
            else
            if (typeof(T) == typeof(IAddAuthorController)) {
                return (T)(IAddAuthorController)new AddAuthorController(context);
            }
            throw new NotImplementedException();
        } 
    }
}