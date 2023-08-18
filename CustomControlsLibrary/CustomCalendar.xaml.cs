using CustomControlsLibrary.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static CustomControlsLibrary.Converters.ConvertorFunctions;

namespace CustomControlsLibrary
{
    /// <summary>
    /// Логика взаимодействия для CustomCalendar.xaml
    /// </summary>
    public partial class CustomCalendar : UserControl, INotifyPropertyChanged
    {        
        #region DProperty

        #region Reference to this

        #endregion


        #region Styles

        #region Calendar Static Components DP Styles

        public Style CalendarBorderStyle
        {
            get { return (Style)GetValue(CalendarBorderStyleProperty); }
            set { SetValue(CalendarBorderStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CalendarBorderStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CalendarBorderStyleProperty;



        public Style PrevButtonStyle
        {
            get { return (Style)GetValue(PrevButtonStyleProperty); }
            set { SetValue(PrevButtonStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PrevButtonStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PrevButtonStyleProperty;



        public Style DateTextBlockBackground
        {
            get { return (Style)GetValue(DateTextBlockBackgroundProperty); }
            set { SetValue(DateTextBlockBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DateTextBlockBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DateTextBlockBackgroundProperty;




        public Style YearMonthTxtBlockStyle
        {
            get { return (Style)GetValue(YearMonthTxtBlockStyleProperty); }
            set { SetValue(YearMonthTxtBlockStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for YearMonthTxtBlockStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YearMonthTxtBlockStyleProperty;

        public Style MainBorderStyle
        {
            get { return (Style)GetValue(MainBorderStyleProperty); }
            set { SetValue(MainBorderStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MainBorderStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MainBorderStyleProperty;


        public Style DayNameStyle
        {
            get { return (Style)GetValue(DayNameStyleProperty); }
            set { SetValue(DayNameStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DayNameStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DayNameStyleProperty;



        #endregion



        public Style YearButtonStyle
        {
            get { return (Style)GetValue(YearButtonStyleProperty); }
            set { SetValue(YearButtonStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for YearButtonStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YearButtonStyleProperty;


        public Style CurrentDateHighLightedStyle
        {
            get { return (Style)GetValue(CurrentDateHighLightedStyleProperty); }
            set { SetValue(CurrentDateHighLightedStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentDataHighLightedStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentDateHighLightedStyleProperty;

        public Style HighlightedDateStyle
        {
            get { return (Style)GetValue(HighlightedDateStyleProperty); }
            set { SetValue(HighlightedDateStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HighlightedDateStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HighlightedDateStyleProperty;



        public Style MonthButtonStyle
        {
            get { return (Style)GetValue(MonthButtonStyleProperty); }
            set { SetValue(MonthButtonStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonthButtonStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonthButtonStyleProperty;



        public Style DayButtonStyle
        {
            get { return (Style)GetValue(DayButtonStyleProperty); }
            set { SetValue(DayButtonStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DayButtonStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DayButtonStyleProperty;



        public Style NextButtonStyle
        {
            get { return (Style)GetValue(NextButtonStyleProperty); }
            set { SetValue(NextButtonStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NexButtonStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NextButtonStyleProperty;

        public Style HighlitedMonthButtonStyle
        {
            get { return (Style)GetValue(HighlitedMonthButtonStyleProperty); }
            set { SetValue(HighlitedMonthButtonStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HighlitedMonthButtonStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HighlitedMonthButtonStyleProperty;



        public Style HighlightedYearButtonStyle
        {
            get { return (Style)GetValue(HighlightedYearButtonStyleProperty); }
            set { SetValue(HighlightedYearButtonStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HighlightedYearButtonStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HighlightedYearButtonStyleProperty;




        #endregion

        public DateTime SelectedDate
        {
            get { return (DateTime)GetValue(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedDateProperty;

        #region Calendar items modifiers



        public double DayButtonWidthModifier
        {
            get { return (double)GetValue(DayButtonWidthModifierProperty); }
            set { SetValue(DayButtonWidthModifierProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DayButtonWidthModifier.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DayButtonWidthModifierProperty;



        public double DayButtonHeightModifier
        {
            get { return (double)GetValue(DayButtonHeightModifierProperty); }
            set { SetValue(DayButtonHeightModifierProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DayButtonHeightModifier.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DayButtonHeightModifierProperty;



        public double MonthButtonWidthModifier
        {
            get { return (double)GetValue(MonthButtonWidthModifierProperty); }
            set { SetValue(MonthButtonWidthModifierProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonthButtonWidthModifier.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonthButtonWidthModifierProperty;




        public double MonthButtonHeightModifier
        {
            get { return (double)GetValue(MonthButtonHeightModifierProperty); }
            set { SetValue(MonthButtonHeightModifierProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonthButtonHeightModifier.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonthButtonHeightModifierProperty;




        #endregion

        #endregion

        #region Fields

        #region Styles

        private Button m_highlited;

        #endregion

        DateTime m_currentDate;

        double m_ItemWidth;

        double m_ItemHeight;

        double m_dayButtonWidth;

        double m_dayButtonHeight;

        double m_MonthButtonWidth;

        double m_MonthButtonHeight;

        StringToDateTime m_strTodt;

        byte m_ClickCount;

        byte m_StringFormatType;

        #region Date Bounds

        int m_upperDateLimit;

        int m_lowerDateLimit;

        #endregion

        #region Calendar Items Size modifiers

        double m_DayButtonWidthMod;

        double m_DayButtonHeightMod;

        double m_MonthButtonWidthMod;

        double m_MonthButtonHeightMod;

        #endregion

        #endregion

        #region Properties

        public byte StringFormatType
        {
            get => m_StringFormatType;

            set { m_StringFormatType = value; OnPropertyChanged(nameof(StringFormatType)); }
        }

        public DateTime CurrentDate
        {
            get => m_currentDate; set
            { m_currentDate = value; OnPropertyChanged(nameof(CurrentDate)); }
        }

        #region Date bounds

        public int UpperDateLimit
        {
            get => m_upperDateLimit;
            set { m_upperDateLimit = value; OnPropertyChanged(nameof(UpperDateLimit)); }
        }

        public int LowerDateLimit
        {
            get => m_lowerDateLimit;
            set { m_lowerDateLimit = value; OnPropertyChanged(nameof(LowerDateLimit)); }
        }

        #endregion



        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        #region ctor

        static CustomCalendar()
        {
            SelectedDateProperty =
            DependencyProperty.Register("SelectedDate", typeof(DateTime), typeof(CustomCalendar),
            new PropertyMetadata(new DateTime(), OnSelectedDatePropertyChanged));

            #region Styles

            YearButtonStyleProperty =
            DependencyProperty.Register("YearButtonStyle", typeof(Style),
            typeof(CustomCalendar), new PropertyMetadata(default, OnYearButtonStylePropertyChanged));

            MonthButtonStyleProperty =
            DependencyProperty.Register("MonthButtonStyle", typeof(Style),
            typeof(CustomCalendar), new PropertyMetadata(default, OnMonthButtonStylePropertyChanged));

            CurrentDateHighLightedStyleProperty =
            DependencyProperty.Register("CurrentDateHighLightedStyle", typeof(Style), typeof(CustomCalendar),
            new PropertyMetadata(default, OnCurrentDateHighLightedStyleChanged));

            HighlightedDateStyleProperty =
            DependencyProperty.Register("HighlightedDateStyle", typeof(Style),
            typeof(CustomCalendar), new PropertyMetadata(default, OnHighLightedDateStyleChanged));

            DayButtonStyleProperty =
            DependencyProperty.Register("DayButtonStyle", typeof(Style), typeof(CustomCalendar),
            new PropertyMetadata(default, OnDayButtonStyleChanged));

            HighlitedMonthButtonStyleProperty =
            DependencyProperty.Register("HighlitedMonthButtonStyle", typeof(Style),
            typeof(CustomCalendar), new PropertyMetadata(default, OnHighlitedMonthButtonStylePropertyChanged));


            HighlightedYearButtonStyleProperty =
            DependencyProperty.Register("HighlightedYearButtonStyle", typeof(Style),
            typeof(CustomCalendar), new PropertyMetadata(default, OnHighlightedYearButtonStylePropertyChanged));

            #region Calendar Static Components DP Styles

            CalendarBorderStyleProperty =
            DependencyProperty.Register("CalendarBorderStyle", typeof(Style), typeof(CustomCalendar),
               new PropertyMetadata(default, OnCalendarBorderStyleChanged));

            PrevButtonStyleProperty =
            DependencyProperty.Register("PrevButtonStyle", typeof(Style),
                typeof(CustomCalendar), new PropertyMetadata(default, OnPrevButtonStyleChanged));

            DateTextBlockBackgroundProperty =
            DependencyProperty.Register("DateTextBlockBackground", typeof(Style),
            typeof(CustomCalendar), new PropertyMetadata(default, OnTextBlockBackGroundPropertyChanged));

            YearMonthTxtBlockStyleProperty =
             DependencyProperty.Register("YearMonthTxtBlockStyle", typeof(Style),
             typeof(CustomCalendar), new PropertyMetadata(default,
             OnYearMonthTxtBlockStylePropertyChanged));

            NextButtonStyleProperty =
            DependencyProperty.Register("NexButtonStyle", typeof(Style),
            typeof(CustomCalendar), new PropertyMetadata(default, OnNextButtonStylePropertyChanged
            ));

            MainBorderStyleProperty =
            DependencyProperty.Register("MainBorderStyle", typeof(Style),
            typeof(CustomCalendar), new PropertyMetadata(default, OnMainBorderStylePropertyChanged));

            DayNameStyleProperty =
            DependencyProperty.Register("DayNameStyle", typeof(Style), typeof(CustomCalendar),
            new PropertyMetadata(default, OnDayNameStylePropertyChanged));
            #endregion

            #endregion

            #region Calendar Items Modifier

            DayButtonWidthModifierProperty =
            DependencyProperty.Register("DayButtonWidthModifier",
            typeof(double), typeof(CustomCalendar), new PropertyMetadata(-2.0,
            OnDayButtonWidthModifierPropertyChanged));

            DayButtonHeightModifierProperty =
            DependencyProperty.Register("DayButtonHeightModifier",
            typeof(double), typeof(CustomCalendar), new PropertyMetadata(-2.0,
            OnDayButtonHeightModifierPropertyChanged));

            MonthButtonWidthModifierProperty =
            DependencyProperty.Register("MonthButtonWidthModifier",
            typeof(double), typeof(CustomCalendar), new PropertyMetadata(-2.0,
            OnMonthButtonWidthModifierPropertyChanged));

            MonthButtonHeightModifierProperty =
            DependencyProperty.Register("MonthButtonHeightModifier",
            typeof(double), typeof(CustomCalendar), new PropertyMetadata(-4.0,
            OnMonthButtonHeightModifierPropertyChanged));


            #endregion

        }

        public CustomCalendar()
        {
            InitializeComponent();

            this.DataContext = this;

            m_currentDate = DateTime.Now;

            m_strTodt = new StringToDateTime();

            m_ClickCount = 0;

            m_DayButtonHeightMod = -2;

            m_DayButtonWidthMod = -2;

            m_MonthButtonHeightMod = -2;

            m_MonthButtonWidthMod = -4;
        }

        #endregion



        #region Methods

        #region Size CalculationMethods

        private double CalculateDayButtonWidth()
        {
            return (m_ItemWidth - (this.brd.Margin.Left * 2 + this.PanelMain.Margin.Left * 2 + this.MainBorder.Margin.Left * 2)) / 7;
        }

        private double CalculateDayButtonHeight()
        {
            return (m_ItemHeight - (this.MainGrid.RowDefinitions[0].Height.Value +
                this.MainGrid.RowDefinitions[1].Height.Value + this.brd.Margin.Top * 2 + this.PanelMain.Margin.Top * 2
                + this.MainBorder.Margin.Top * 2)) / 6;
        }

        private double CalculateMonthButtonWidth()
        {
            return (m_ItemWidth - (this.brd.Margin.Left * 2 + this.PanelMain.Margin.Left * 2 + this.MainBorder.Margin.Left * 2)) / 4;
        }

        private double CalculateMonthButtonHeight()
        {
            return (m_ItemHeight - (this.MainGrid.RowDefinitions[0].Height.Value +
               this.MainGrid.RowDefinitions[1].Height.Value + this.brd.Margin.Top * 2 + this.PanelMain.Margin.Top * 2
               + this.MainBorder.Margin.Top * 2)) / 3;
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            m_ItemWidth = e.NewSize.Width;

            m_ItemHeight = e.NewSize.Height;

            m_dayButtonWidth = CalculateDayButtonWidth() + m_DayButtonWidthMod;

            m_dayButtonHeight = CalculateDayButtonHeight() + m_DayButtonHeightMod;

            m_MonthButtonWidth = CalculateMonthButtonWidth() + m_MonthButtonWidthMod;

            m_MonthButtonHeight = CalculateMonthButtonHeight() + m_MonthButtonHeightMod;

            GenerateDaysOfWeek(m_dayButtonWidth, m_dayButtonHeight);

            GenerateButtonTable(DateTime.DaysInMonth(CurrentDate.Year, CurrentDate.Month),
               m_dayButtonWidth, m_dayButtonHeight, (but, i) =>
               {
                   but.Content = i;

                   but.Click += But_ChooseDate;

                   but.Style = (Style)this.Resources["DayButtonStyle"];

               }, true);


        }

        #endregion

        #region Table Generating

        /// <summary>
        /// Generate days of the week TextBlocks
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void GenerateDaysOfWeek(double width, double height)
        {
            this.DaysOfWeek.Children.Clear();

            for (int i = 0; i < 7; i++)
            {
                TextBlock txt = new TextBlock();

                txt.Width = width;

                txt.Height = height;

                txt.TextAlignment = TextAlignment.Center;

                switch (i)
                {
                    case 0:

                        txt.Text = "M";

                        break;

                    case 1:
                        txt.Text = "Tu";
                        break;

                    case 2:
                        txt.Text = "W";
                        break;

                    case 3:
                        txt.Text = "Th";
                        break;

                    case 4:
                        txt.Text = "F";
                        break;

                    case 5:
                        txt.Text = "Sa";
                        break;

                    case 6:
                        txt.Text = "Su";
                        break;
                }

                txt.Style = (Style)this.Resources["DayNameStyle"];

                this.DaysOfWeek.Children.Add(txt);
            }
        }

        /// <summary>
        /// Generate Buttons (day, month, year)
        /// </summary>
        /// <param name="count"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="GetButton"></param>
        /// <param name="useOffset"></param>
        private void GenerateButtonTable(int count, double width, double height,
            Action<Button, int> GetButton, bool useOffset = false)
        {
            if (useOffset)
            {
                int offset = 0;

                var first = CurrentDate.AddDays(-(CurrentDate.Day - 1));

                DayOfWeek d = first.DayOfWeek;

                switch (d)
                {
                    case DayOfWeek.Sunday:
                        offset = 6;
                        break;
                    case DayOfWeek.Monday:
                        offset = 0;
                        break;
                    case DayOfWeek.Tuesday:
                        offset = 1;
                        break;
                    case DayOfWeek.Wednesday:
                        offset = 2;
                        break;
                    case DayOfWeek.Thursday:
                        offset = 3;
                        break;
                    case DayOfWeek.Friday:
                        offset = 4;
                        break;
                    case DayOfWeek.Saturday:
                        offset = 5;
                        break;
                }


                for (int i = 0; i < offset; i++)
                {
                    Button but = new Button();

                    but.Visibility = Visibility.Hidden;

                    but.Content = "*";

                    but.IsEnabled = false;

                    but.Width = width;

                    but.Height = height;

                    PanelMain.Children.Add(but);
                }
            }

            for (int i = 1; i <= count; i++)
            {
                Button but = new Button();

                GetButton.Invoke(but, i);

                but.Width = width;

                but.Height = height;

                HighlightCurrentDate(but);

                this.PanelMain.Children.Add(but);
            }
            if (m_ClickCount == 0)
                HighlightSelectedDate();
            else if (m_ClickCount == 1)
                HighLightSelectedMonth();
            else
                HighLightSelectedYear();
        }

        #endregion

        #region Event Handlers
        /// <summary>
        /// Prev button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            if (m_ClickCount == 0)
            {
                CurrentDate = CurrentDate.AddMonths(-1);

                PanelMain.Children.Clear();

                GenerateButtonTable(DateTime.DaysInMonth(CurrentDate.Year, CurrentDate.Month),
                  m_dayButtonWidth, m_dayButtonHeight, (but, i) =>
                  {
                      but.Content = i;

                      but.Click += But_ChooseDate;

                      but.Style = (Style)this.Resources["DayButtonStyle"];
                  }, true);
            }
            else if (m_ClickCount == 1)
            {
                CurrentDate = CurrentDate.AddYears(-1);

                GenerateButtonTable(12, m_MonthButtonWidth, m_MonthButtonHeight, (but, i) =>
                {
                    but.Click += But_ChooseMonth;

                    but.Style = (Style)this.Resources["MonthButtonStyle"];

                    but.Content = MonthToString(i);

                    //add Month button style

                });
            }
            else if (m_ClickCount == 2)
            {
                LowerDateLimit -= 12;

                UpperDateLimit -= 12;

                PanelMain.Children.Clear();

                GenerateButtonTable(12, m_MonthButtonWidth, m_MonthButtonHeight, (but, i) =>
                {
                    but.Click += But_ChooseYear;

                    but.Style = (Style)this.Resources["YearButtonStyle"];

                    //add Year button style

                    if (i == 1)
                    {
                        but.Content = LowerDateLimit;
                    }
                    else
                    {
                        but.Content = LowerDateLimit + i - 1;
                    }


                });
            }


        }

        /// <summary>
        /// Next button click event handler 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (m_ClickCount == 0)
            {
                CurrentDate = CurrentDate.AddMonths(1);

                PanelMain.Children.Clear();

                GenerateButtonTable(DateTime.DaysInMonth(CurrentDate.Year, CurrentDate.Month),
                  m_dayButtonWidth, m_dayButtonHeight, (but, i) =>
                  {
                      but.Content = i;

                      but.Click += But_ChooseDate;

                      but.Style = (Style)this.Resources["DayButtonStyle"];
                  }, true);
            }
            else if (m_ClickCount == 1)
            {
                CurrentDate = CurrentDate.AddYears(1);

                GenerateButtonTable(12, m_MonthButtonWidth, m_MonthButtonHeight, (but, i) =>
                {
                    but.Click += But_ChooseMonth;

                    but.Style = (Style)this.Resources["MonthButtonStyle"];

                    but.Content = MonthToString(i);

                    //add Month button style

                });
            }
            else if (m_ClickCount == 2)
            {
                LowerDateLimit += 12;

                UpperDateLimit += 12;

                PanelMain.Children.Clear();

                GenerateButtonTable(12, m_MonthButtonWidth, m_MonthButtonHeight, (but, i) =>
                {
                    but.Click += But_ChooseYear;

                    but.Style = (Style)this.Resources["YearButtonStyle"];

                    //add Year button style

                    if (i == 1)
                    {
                        but.Content = LowerDateLimit;
                    }
                    else
                    {
                        but.Content = LowerDateLimit + i - 1;
                    }
                });
            }

        }
        /// <summary>
        /// On "month year" click event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (m_ClickCount >= 2)
            {
                return;
            }

            m_ClickCount++;

            StringFormatType = m_ClickCount;

            PanelMain.Children.Clear();

            if (m_ClickCount == 1)
            {
                GenerateButtonTable(12, m_MonthButtonWidth, m_MonthButtonHeight, (but, i) =>
                {
                    but.Click += But_ChooseMonth;

                    but.Content = MonthToString(i);

                    but.Style = (Style)this.Resources["MonthButtonStyle"];

                    //add Month button style
                });
            }
            else if (m_ClickCount == 2)
            {
                GenerateButtonTable(12, m_MonthButtonWidth, m_MonthButtonHeight, (but, i) =>
                {
                    but.Click += But_ChooseYear;

                    //add Year button style

                    int year = CurrentDate.Year;

                    if (i == 1)
                    {
                        but.Content = year;
                    }
                    else
                    {
                        year += i - 1;

                        but.Content = year;
                    }

                    but.Style = (Style)this.Resources["YearButtonStyle"];
                });

                LowerDateLimit = CurrentDate.Year;

                UpperDateLimit = (CurrentDate.Year + 11);
            }



        }

        /// <summary>
        /// On year button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void But_ChooseYear(object sender, RoutedEventArgs e)
        {
            DateTime temp = CurrentDate;

            CurrentDate = new DateTime((int)(sender as Button).Content, temp.Month, 1);

            PanelMain.Children.Clear();

            m_ClickCount = 1;

            StringFormatType = m_ClickCount;

            GenerateButtonTable(12, m_MonthButtonWidth, m_MonthButtonHeight, (but, i) =>
            {
                but.Click += But_ChooseMonth;

                but.Content = MonthToString(i);

                but.Style = (Style)this.Resources["MonthButtonStyle"];
            });
        }



        /// <summary>
        /// On month button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void But_ChooseMonth(object sender, RoutedEventArgs e)
        {
            string month = (sender as Button).Content.ToString();

            this.PanelMain.Children.Clear();

            DateTime temp = CurrentDate;

            CurrentDate = new DateTime(temp.Year, StringToMonth(month), 1);

            m_ClickCount = 0;

            StringFormatType = m_ClickCount;

            GenerateButtonTable(DateTime.DaysInMonth(CurrentDate.Year, CurrentDate.Month),
                m_dayButtonWidth, m_dayButtonHeight, (but, i) =>
                {
                    but.Content = i;

                    but.Click += But_ChooseDate;

                    but.Style = (Style)this.Resources["DayButtonStyle"];
                }, true);


        }

        /// <summary>
        /// On day buuton click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void But_ChooseDate(object sender, RoutedEventArgs e)
        {
            var selected = sender as Button;

            if (m_highlited != null)
            {
                m_highlited.Style = (Style)this.Resources["DayButtonStyle"];
            }

            CurrentDate = new DateTime(CurrentDate.Year, CurrentDate.Month, (int)(sender as Button).Content);

            SelectedDate = CurrentDate;

            selected.Style = (Style)this.Resources["HighLightedDateStyle"];

            m_highlited = selected;
        }
        #endregion

        #region Highlighters

        private void HighlightCurrentDate(Button item)
        {
            DateTime temp = DateTime.Now;

            if (CurrentDate.Year == temp.Year && CurrentDate.Month == temp.Month)
            {
                if (item.Content.Equals(temp.Day))
                {
                    item.Style = (Style)this.Resources["CurrentDateHighLightedStyle"];
                }
            }
        }

        private void HighLightSelectedYear()
        {
            var now = DateTime.Now;

            DateTime date = default;

            if (SelectedDate == default)
                date = now;

            else
                date = SelectedDate;

            foreach (Button button in this.PanelMain.Children)
            {
                if (date.Year.Equals(int.Parse(button.Content.ToString())))
                    button.Style = (Style)this.Resources["HighlightedYearButtonStyle"];
                else
                    button.Style = (Style)this.Resources["YearButtonStyle"];
            }
        }

        private void HighLightSelectedMonth()
        {
            var now = DateTime.Now;

            DateTime date = default;

            if (SelectedDate == default)
                date = now;

            else
                date = SelectedDate;

            var strYear = int.Parse(MonthYear.Text.Split(' ')[0]);

            foreach (Button button in this.PanelMain.Children)
            {
                if (ConvertorFunctions.StringToMonth(button.Content.ToString()).Equals(date.Month)
                    && strYear.Equals(date.Year))
                    button.Style = (Style)this.Resources["HighLightedMonthButtonStyle"];
                else
                    button.Style = (Style)this.Resources["MonthButtonStyle"];
            }
        }

        private void HighlightSelectedDate()
        {
            if (SelectedDate.Equals(default))
            {
                return;
            }

            if (!(SelectedDate.Year == CurrentDate.Year && SelectedDate.Month == CurrentDate.Month))
            {
                return;
            }

            var temp = DateTime.Now;

            foreach (Button item in this.PanelMain.Children)
            {
                if (item.Content.Equals(SelectedDate.Day))
                {
                    item.Style = (Style)this.Resources["HighLightedDateStyle"];
                }
                else if (item.Content.Equals(temp.Day))
                    HighlightCurrentDate(item);

                else
                    item.Style = (Style)this.Resources["DayButtonStyle"];
            }
        }

        #endregion

        /// <summary>
        /// Property changed method of Interface INotifyPropertyChanged
        /// </summary>
        /// <param name="name"></param>
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        private static void SwapStyle(CustomCalendar This, FrameworkElement element, string key, Style newStyle)
        {
            if (This.Resources.Contains(key))
                This.Resources[key] = newStyle;
            else
                This.Resources.Add(key, newStyle);

            if (element != null)
                element.Style = (Style)This.Resources[key];
        }

        #region On Change styles Handlers

        private static void OnYearButtonStylePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = (d as CustomCalendar);

            SwapStyle(calendar, null, "YearButtonStyle", (Style)e.NewValue);
        }

        private static void OnMonthButtonStylePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = (d as CustomCalendar);

            SwapStyle(calendar, null, "MonthButtonStyle", (Style)e.NewValue);
        }

        private static void OnDayNameStylePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = (d as CustomCalendar);

            SwapStyle(calendar, null, "DayNameStyle", (Style)e.NewValue);

            foreach (TextBlock item in calendar.DaysOfWeek.Children)
            {
                item.Style = (Style)calendar.Resources["DayNameStyle"];
            }
        }

        private static void OnMainBorderStylePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = (d as CustomCalendar);

            SwapStyle(calendar, calendar.MainBorder, "MainBorderStyle", (Style)e.NewValue);
        }

        private static void OnNextButtonStylePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = (d as CustomCalendar);

            SwapStyle(calendar, calendar.NextButton, "NextButtonStyle", (Style)e.NewValue);
        }

        private static void OnYearMonthTxtBlockStylePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = (d as CustomCalendar);

            SwapStyle(calendar, calendar.MonthYear, "YearMonthTxtBlockStyle", (Style)e.NewValue);
        }

        private static void OnPrevButtonStyleChanged(DependencyObject obj,
            DependencyPropertyChangedEventArgs e)
        {
            var calendar = (obj as CustomCalendar);

            SwapStyle(calendar, calendar.PrevButton, "PrevButtonStyle", (Style)e.NewValue);
        }

        private static void OnTextBlockBackGroundPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = (d as CustomCalendar);

            SwapStyle(calendar, calendar.txtBack, "BackgroundDateTextBlock", (Style)e.NewValue);
        }

        private static void OnCurrentDateHighLightedStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = (d as CustomCalendar);
            SwapStyle(calendar, null, "CurrentDateHighLightedStyle", (Style)e.NewValue);
        }

        private static void OnDayButtonStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = (d as CustomCalendar);

            SwapStyle(calendar, null, "DayButtonStyle", (Style)e.NewValue);

            foreach (Button item in calendar.PanelMain.Children)
            {
                item.Style = (Style)calendar.Resources["DayButtonStyle"];
            }
        }

        private static void OnHighLightedDateStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = (d as CustomCalendar);

            SwapStyle(calendar, null, "HighLightedDateStyle", (Style)e.NewValue);
        }

        private static void OnCalendarBorderStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = (d as CustomCalendar);

            SwapStyle(calendar, calendar.brd, "CalendarBorderStyle", (Style)e.NewValue);
        }

        private static void OnHighlitedMonthButtonStylePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = (d as CustomCalendar);

            SwapStyle(calendar, null, "HighLightedMonthButtonStyle", (Style)e.NewValue);
        }

        private static void OnHighlightedYearButtonStylePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = (d as CustomCalendar);

            SwapStyle(calendar, null, "HighlightedYearButtonStyle", (Style)e.NewValue);
        }

        #endregion

        #region On Size Mod Change

        private static void OnMonthButtonHeightModifierPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = (d as CustomCalendar);

            calendar.m_MonthButtonHeightMod = (double)e.NewValue;
        }

        private static void OnMonthButtonWidthModifierPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = (d as CustomCalendar);

            calendar.m_MonthButtonWidthMod = (double)e.NewValue;
        }

        private static void OnDayButtonHeightModifierPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = (d as CustomCalendar);

            calendar.m_DayButtonHeightMod = (double)e.NewValue;
        }

        private static void OnDayButtonWidthModifierPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = (d as CustomCalendar);

            calendar.m_DayButtonWidthMod = (double)e.NewValue;
        }

        #endregion

        #region On Selected Date Changed

        private static void OnSelectedDatePropertyChanged(DependencyObject obj,
            DependencyPropertyChangedEventArgs e)
        {
            var This = obj as CustomCalendar;

            This.HighlightSelectedDate();           
        }

        #endregion
    }
}

