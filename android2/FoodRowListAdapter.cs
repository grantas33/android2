﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace android2
{
    public class FoodRowListAdapter : BaseAdapter<Food>
    {
        List<Food> items;
        Activity context;
       
        public FoodRowListAdapter(Activity context, List<Food> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override Food this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.FoodInfo, null);

            view.FindViewById<TextView>(Resource.Id.foodinfoname).Text = item.Name;
            view.FindViewById<TextView>(Resource.Id.foodinfocalories).Text = string.Format("{0} cal.", item.Calories.ToString());
            view.FindViewById<TextView>(Resource.Id.foodinfograms).Text = string.Format("{0} g.", item.Grams.ToString());
            view.FindViewById<TextView>(Resource.Id.foodinfocaloriestotal).Text = string.Format("{0} cal.", item.Calories * item.Multiplier);
            view.FindViewById<TextView>(Resource.Id.foodinfogramstotal).Text = string.Format("{0} g.", item.Grams * item.Multiplier);
            view.FindViewById<TextView>(Resource.Id.foodinfomultiplier).Text = "x" + item.Multiplier.ToString();
            if (item.Multiplier > 1)
            {
                view.FindViewById<TextView>(Resource.Id.foodinfomultiplier).Visibility =
                view.FindViewById<TextView>(Resource.Id.foodinfocaloriestotal).Visibility =
                view.FindViewById<TextView>(Resource.Id.foodinfogramstotal).Visibility = ViewStates.Visible;                    
            }
            else
            {
                view.FindViewById<TextView>(Resource.Id.foodinfomultiplier).Visibility =
                view.FindViewById<TextView>(Resource.Id.foodinfocaloriestotal).Visibility =
                view.FindViewById<TextView>(Resource.Id.foodinfogramstotal).Visibility = ViewStates.Gone;
            }
            return view;
        }

        public void UpdateAdapter(List<Food> list)
        {
            this.items = list;
            NotifyDataSetChanged();
        }
    }
}