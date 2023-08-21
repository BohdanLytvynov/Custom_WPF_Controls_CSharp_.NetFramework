using CustomControlsLibrary.Converters;
using CustomControlsLibrary.Utilities;
using CustomControlsLibrary.WPFConverters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class CustomDatePicker : UserControl, INotifyPropertyChanged
    {
        #region Dep Properties

        //try to bind dp via code behind



        public DateTime ChosenDate
        {
            get { return (DateTime)GetValue(ChosenDateProperty); }
            set { SetValue(ChosenDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChosenDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChosenDateProperty;



        public CustomCalendar Calendar
        {
            get { return (CustomCalendar)GetValue(CalendarProperty); }
            set { SetValue(CalendarProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Calendar.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CalendarProperty;

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
            ChosenDateProperty =
            DependencyProperty.Register("ChosenDate", typeof(DateTime), 
            typeof(CustomDatePicker), new PropertyMetadata(new DateTime(), OnChosenDatePropertyChanged));

            CalendarProperty =
             DependencyProperty.Register("Calendar", typeof(CustomCalendar),
                 typeof(CustomDatePicker), new PropertyMetadata(null, OnCalendarPropertyChanged));

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

        private static void OnCalendarPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var Cust = (CustomCalendar)e.NewValue;

            var This = (d as CustomDatePicker);

            //Rebuild Main Grid            

            This.Label.Content = Cust;
           
            //Set binding instance for CustomCalendar with path: SelectedDate
            Binding binding = new Binding("SelectedDate")
            {
                Source = Cust,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                Mode = BindingMode.TwoWay
            };

            This.SetBinding(ChosenDateProperty, binding);           
        }

       
        private static void OnChosenDatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var This = d as CustomDatePicker;

            if (This.m_dateToStr == null)
                This.m_dateToStr = new DateTimeToStringConverter();

            This.DatePresenter.Text = (string)This.m_dateToStr.Convert(e.NewValue, null, null, null);

            This.ToglButton.IsChecked = false;
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            var temp = Volatile.Read(ref PropertyChanged);

            temp?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion

        #endregion
    }
}
