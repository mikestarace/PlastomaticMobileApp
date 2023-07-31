using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using SimplePressureRegulator.Controls;
using SimplePressureRegulator.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace SimplePressureRegulator.Droid
{
    public class CustomPickerRenderer : PickerRenderer
    {
        AlertDialog listDialog;
        string[] items;
        public CustomPickerRenderer(Context context) : base(context)
        {
        }
        CustomPicker element;

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            element = (CustomPicker)this.Element;

            if (Control != null && this.Element != null && !string.IsNullOrEmpty(element.Image))
                Control.Background = AddPickerStyles(element.Image);
                Control.Click += Control_Click1; ;

        }

        public LayerDrawable AddPickerStyles(string imagePath)
        {
            ShapeDrawable border = new ShapeDrawable();
            border.Paint.Color = Android.Graphics.Color.Gray;
            border.SetPadding(10, 10, 10, 10);
            border.Paint.SetStyle(Paint.Style.Stroke);

            Drawable[] layers = { border, GetDrawable(imagePath) };
            LayerDrawable layerDrawable = new LayerDrawable(layers);
            layerDrawable.SetLayerInset(0, 0, 0, 0, 0);

            return layerDrawable;
        }

        private BitmapDrawable GetDrawable(string imagePath)
        {
            int resID = Resources.GetIdentifier(imagePath, "drawable", this.Context.PackageName);
            var drawable = ContextCompat.GetDrawable(this.Context, resID);
            var bitmap = ((BitmapDrawable)drawable).Bitmap;

            var result = new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, 25, 25, true));
            result.Gravity = Android.Views.GravityFlags.Right;

            return result;
        }
        private void Control_Click1(object sender, EventArgs e)
        {
            Picker model = Element;
            items = model.Items.ToArray();
            AlertDialog.Builder builder = new AlertDialog.Builder(this.Context);
            builder.SetTitle(model.Title ?? "");
            Android.Views.View view = LayoutInflater.From(this.Context).Inflate(Resource.Layout.listview, null);
            Android.Widget.ListView listView = view.FindViewById<Android.Widget.ListView>(Resource.Id.listView1); // finds listView 1 inside the listview xml file

            MyAdapter myAdapter = new MyAdapter(items, Element.SelectedIndex);
            listView.Adapter = myAdapter;
            listView.ItemClick += ListView_ItemClick;
            builder.SetView(view);
            listDialog = builder.Create();
            listDialog.Window.DecorView.SetBackgroundColor(Android.Graphics.Color.White); // set the dialog background color 
            listDialog.Show();
        }
            private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Control.Text = items[e.Position];
            Element.SelectedIndex = e.Position;
            Console.WriteLine(items[e.Position]);
            listDialog.Dismiss();
            listDialog = null;
        }
        class MyAdapter : BaseAdapter
        {
            private string[] items;
            private int selectedIndex;

            public MyAdapter(string[] items)
            {
                this.items = items;
            }

            public MyAdapter(string[] items, int selectedIndex) : this(items)
            {
                this.selectedIndex = selectedIndex;
            }

            public override int Count => items.Length;

            public override Java.Lang.Object GetItem(int position)
            {
                return items[position];
            }

            public override long GetItemId(int position)
            {
                return position;
            }

            public override Android.Views.View GetView(int position, Android.Views.View convertView, ViewGroup parent)
            {
                if (convertView == null)
                {
                    convertView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.listview_item, null);
                }
                TextView textView = convertView.FindViewById<TextView>(Resource.Id.textView1); // finds textView1 inside listview_item
                textView.Text = items[position];
                textView.SetTextSize(Android.Util.ComplexUnitType.Sp, 30);
                textView.SetPadding(5, 0, 5, 0);
                return convertView;
            }
        }
    }
}