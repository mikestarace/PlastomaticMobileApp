using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SimplePressureRegulator.Controls;
using SimplePressureRegulator.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace SimplePressureRegulator.Droid
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }
        CustomEntry element;
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            element = (CustomEntry)this.Element;

            if (Control != null)
                Control.Background = AddEntryStyles();
        }

        public ShapeDrawable AddEntryStyles()
        {
            ShapeDrawable border = new ShapeDrawable();
            border.Paint.Color = Android.Graphics.Color.Gray;
            border.SetPadding(10, 10, 10, 10);
            border.Paint.SetStyle(Paint.Style.Stroke);

            // Drawable[] layers = { border, GetDrawable(imagePath) };
            // LayerDrawable layerDrawable = new LayerDrawable(layers);
            // layerDrawable.SetLayerInset(0, 0, 0, 0, 0);

            return border;
        }
    }
}