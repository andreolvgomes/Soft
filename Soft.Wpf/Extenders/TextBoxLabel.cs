using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Soft.Wpf.Extenders
{
    public class TextBoxLabel : TextBox
    {
        public event MouseButtonEventHandler LabelClick;

        private void OnLabelClick(object sender, MouseButtonEventArgs e)
        {
            MouseButtonEventHandler handler = LabelClick;
            if (handler != null)
                handler(sender, e);
        }

        public event RoutedEventHandler SearchClick;

        private void OnSearchClick(object sender, RoutedEventArgs e)
        {
            RoutedEventHandler handler = SearchClick;
            if (handler != null)
                handler(sender, e);
        }

        //public static readonly DependencyProperty TextBoxInfoProperty;
        //public static readonly DependencyProperty IsPasswordEnabledProperty;

        static TextBoxLabel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TextBoxLabel), new FrameworkPropertyMetadata(typeof(TextBoxLabel)));
            TextProperty.OverrideMetadata(typeof(TextBoxLabel), new FrameworkPropertyMetadata(new PropertyChangedCallback(TextPropertyChanged)));
            //TextBoxInfoProperty = DependencyProperty.Register("TextBoxInfo", typeof(string), typeof(InfoTextBox), new PropertyMetadata(string.Empty));
            //IsPasswordEnabledProperty = DependencyProperty.Register("IsPasswordEnabled", typeof(Boolean), typeof(InfoTextBox), new FrameworkPropertyMetadata(false));
            //LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(InfoTextBox), new PropertyMetadata(string.Empty));
        }

        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(TextBoxLabel), new PropertyMetadata(""));


        //public Boolean IsPasswordEnabled
        //{
        //    get { return (Boolean)base.GetValue(IsPasswordEnabledProperty); }
        //    set { base.SetValue(IsPasswordEnabledProperty, value); }
        //}

        //public string TextBoxInfo
        //{
        //    get { return (string)GetValue(TextBoxInfoProperty); }
        //    set { SetValue(TextBoxInfoProperty, value); }
        //}

        private static readonly DependencyPropertyKey HasTextPropertyKey = DependencyProperty.RegisterReadOnly(
            "HasText",
            typeof(bool),
            typeof(TextBoxLabel),
            new FrameworkPropertyMetadata(false));

        public static readonly DependencyProperty HasTextProperty = HasTextPropertyKey.DependencyProperty;

        public bool HasText
        {
            get
            {
                return (bool)GetValue(HasTextProperty);
            }
        }

        public override void OnApplyTemplate()
        {
            TextBlock PART_Label = base.GetTemplateChild("PART_Label") as TextBlock;
            if (PART_Label != null)
            {
                if (LabelClick != null)
                    PART_Label.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(LabelMouseLeftButtonDown);
            }

            Button PART_Button = base.GetTemplateChild("PART_Button") as Button;
            if (PART_Button != null)
            {
                if (SearchClick != null)
                    PART_Button.Click += new RoutedEventHandler(ButtonSearchClick);
            }

            base.OnApplyTemplate();
        }

        private void LabelMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OnLabelClick(sender, e);
        }

        private void ButtonSearchClick(object sender, RoutedEventArgs e)
        {
            OnSearchClick(sender, e);
        }

        private static void TextPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            TextBoxLabel itb = (TextBoxLabel)sender;
            bool actuallyHasText = itb.Text.Length > 0;
            if (actuallyHasText != itb.HasText)
            {
                itb.SetValue(HasTextPropertyKey, actuallyHasText);
            }
        }
    }
}