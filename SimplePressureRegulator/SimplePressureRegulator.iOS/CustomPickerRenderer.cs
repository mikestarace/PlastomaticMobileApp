using Foundation;
using SimplePressureRegulator.Controls;
using SimplePressureRegulator.iOS;
using SpriteKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace SimplePressureRegulator.iOS
{
    public class CustomPickerRenderer : PickerRenderer, IUIPickerViewDelegate, IUIPickerViewDataSource
    {
        int SelectedIndex = -1;
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            var element = (CustomPicker)this.Element;
            if (Control != null)
            {
                element.SelectedIndex = SelectedIndex;

                UIPickerView pickerView = (UIPickerView)Control.InputView;
                pickerView.WeakDelegate = this;
                pickerView.DataSource = this;

                UIToolbar toolbar = (UIToolbar)Control.InputAccessoryView;
                UIBarButtonItem doneBtn = new UIBarButtonItem("Done", UIBarButtonItemStyle.Done, (object sender, EventArgs click) =>
                {
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = 0;
                    }
                    element.SelectedIndex = SelectedIndex;
                    toolbar.RemoveFromSuperview();
                    pickerView.RemoveFromSuperview();
                    Control.ResignFirstResponder();
                });
                var doneBtnTextAttributes = new UITextAttributes
                {
                    TextColor = UIColor.Black
                };
                UIBarButtonItem pickerTitle = new UIBarButtonItem(element.Title, UIBarButtonItemStyle.Done, null);
                pickerTitle.SetTitleTextAttributes(doneBtnTextAttributes, UIControlState.Normal);
                UIBarButtonItem empty = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace);
                toolbar.Items = new UIBarButtonItem[] { empty, pickerTitle, empty, doneBtn };
            }
        }

        public nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }
        public nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return Element.Items.Count;
        }

        [Export("pickerView:viewForRow:forComponent:reusingView:")]
        public UIView GetView(UIPickerView pickerView, nint row, nint component, UIView view)
        {
            UILabel label = new UILabel
            {
                TextColor = UIColor.Black,
                Text = Element.Items[(int)row].ToString(),
                TextAlignment = UITextAlignment.Center,
            };
            return label;
        }

        [Export("pickerView:didSelectRow:inComponent:")]
        public void Selected(UIPickerView pickerView, nint row, nint component)
        {
            var element = (CustomPicker)this.Element;
            SelectedIndex = (int)row;
            element.SelectedIndex = SelectedIndex;
        }
    }
}
