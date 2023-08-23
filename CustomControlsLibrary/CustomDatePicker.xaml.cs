using CustomControlsLibrary.Converters;
using CustomControlsLibrary.Utilities;
using CustomControlsLibrary.WPFConverters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomControlsLibrary
{
    /// <summary>
    /// Логика взаимодействия для CustomDatePicker.xaml
    /// </summary>
    public partial class CustomDatePicker : UserControl
    {
        #region Dep Properties
        public CustomCalendar CustomCalendar
        {
            get { return (CustomCalendar)GetValue(CustomCalendarProperty); }
            set { SetValue(CustomCalendarProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CustomCalendar.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomCalendarProperty;



        public DateTime ChosenDate
        {
            get { return (DateTime)GetValue(ChosenDateProperty); }
            set { SetValue(ChosenDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChosenDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChosenDateProperty;

        #region Styles

        public Style MainBorderStyle
        {
            get { return (Style)GetValue(MainBorderStyleProperty); }
            set { SetValue(MainBorderStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MainBorderStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MainBorderStyleProperty;



        public Style DatePresenterStyle
        {
            get { return (Style)GetValue(DatePresenterStyleProperty); }
            set { SetValue(DatePresenterStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DatePresenterStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DatePresenterStyleProperty;



        public Style ToggleButtonStyle
        {
            get { return (Style)GetValue(ToggleButtonStyleProperty); }
            set { SetValue(ToggleButtonStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ToggleButtonStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToggleButtonStyleProperty;



        public Style PopupStyle
        {
            get { return (Style)GetValue(PopupStyleProperty); }
            set { SetValue(PopupStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PopupStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PopupStyleProperty;


        #endregion

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Fields

        DateTimeToStringConverter m_dateToStr;

        #endregion

        #region Static Ctor

        static CustomDatePicker()
        {
            CustomCalendarProperty =
            DependencyProperty.Register("CustomCalendar", typeof(CustomCalendar),
                typeof(CustomDatePicker), new PropertyMetadata(null, OnCustomCalendarPropertyChanged));

            ChosenDateProperty =
            DependencyProperty.Register("ChosenDate", typeof(DateTime),
                typeof(CustomDatePicker),
                new PropertyMetadata(new DateTime()));

            #region Styles

            MainBorderStyleProperty =
            DependencyProperty.Register("MainBorderStyle", typeof(Style),
            typeof(CustomDatePicker), new PropertyMetadata(default,
            OnMainBorderStylePropertyChanged));

            DatePresenterStyleProperty =
            DependencyProperty.Register("DatePresenterStyle", typeof(Style),
            typeof(CustomDatePicker), new PropertyMetadata(default,
            OnDatePresenterStylePropertyChanged));

            ToggleButtonStyleProperty =
            DependencyProperty.Register("ToggleButtonStyle",
            typeof(Style), typeof(CustomDatePicker), new PropertyMetadata(default,
            OnToggleButtonStylePropertyChanged));

            PopupStyleProperty =
            DependencyProperty.Register("PopupStyle", typeof(Style),
            typeof(CustomDatePicker), new PropertyMetadata(default,
            OnPopupStylePropertyChanged));

            #endregion
        }
        
        #endregion

        #region Ctor

        public CustomDatePicker()
        {
            InitializeComponent();

            m_dateToStr = new DateTimeToStringConverter();


        }

        #endregion

        #region Methods

        #region On Properties Changed

        private static void OnCustomCalendarPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var This = (CustomDatePicker)d;

            var Calendar = (CustomCalendar)e.NewValue;

            Calendar.OnDateSelected += This.Calendar_OnDateSelected;

            This.Label.Content = Calendar;

            Calendar.SetBinding(CustomCalendar.SelectedDateProperty,
                new Binding()
                {
                    Source = This,
                    Mode = BindingMode.TwoWay,
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                    Path = new PropertyPath("ChosenDate")
                }
                );

            Debug.WriteLine("InMethod");
        }

        private void Calendar_OnDateSelected(object arg1, DateTime arg2)
        {
            if (m_dateToStr == null)
                m_dateToStr = new DateTimeToStringConverter();

            this.DatePresenter.Text = (string)m_dateToStr.Convert(arg2, null, null, null);

            this.ToglButton.IsChecked = false;            
        }

        #region Styles

        private static void SwapStyle(CustomDatePicker This, FrameworkElement element, string key, Style newStyle)
        {
            if (This.Resources.Contains(key))
                This.Resources[key] = newStyle;
            else
                This.Resources.Add(key, newStyle);

            if (element != null)
                element.Style = (Style)This.Resources[key];
        }

        private static void OnMainBorderStylePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var datePicker = d as CustomDatePicker;

            SwapStyle(datePicker, datePicker.MainBorder, "MainBorderStyle", (Style)e.NewValue);
        }

        private static void OnDatePresenterStylePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var datePicker = d as CustomDatePicker;

            SwapStyle(datePicker, datePicker.DatePresenter, "DatePresenterStyle", (Style)e.NewValue);
        }

        private static void OnToggleButtonStylePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var datePicker = d as CustomDatePicker;

            SwapStyle(datePicker, datePicker.ToglButton, "ToggleButtonStyle", (Style)e.NewValue);
        }

        private static void OnPopupStylePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var datePicker = d as CustomDatePicker;

            SwapStyle(datePicker, datePicker.Popup, "PopupStyle", (Style)e.NewValue);
        }

        #endregion
       
        #endregion

        #endregion
    }
}
