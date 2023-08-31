using CustomControlsLibrary.Utilities;
using System;
using System.Collections.Generic;
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

namespace CustomControlsLibrary
{
    /// <summary>
    /// Логика взаимодействия для CustomPasswordBox.xaml
    /// </summary>
    public partial class CustomPasswordBox : UserControl
    {
        #region Dependency Properties

        public Style PasswordBoxStyle
        {
            get { return (Style)GetValue(PasswordBoxStyleProperty); }
            set { SetValue(PasswordBoxStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PasswordBoxStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordBoxStyleProperty;

        public Style BorderStyle
        {
            get { return (Style)GetValue(BorderStyleProperty); }
            set { SetValue(BorderStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BorderStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BorderStyleProperty;



        public Style ErrorTextBlockStyle
        {
            get { return (Style)GetValue(ErrorTextBlockStyleProperty); }
            set { SetValue(ErrorTextBlockStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorTextBlockStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorTextBlockStyleProperty;



        public Style MainGridStyle
        {
            get { return (Style)GetValue(MainGridStyleProperty); }
            set { SetValue(MainGridStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MainGridStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MainGridStyleProperty;


        #endregion


        #region Fields

        ResourceSwaper m_swaper;

        #endregion

        #region Staatic ctor

        static CustomPasswordBox()
        {
            #region Register Dependency Properties

            BorderStyleProperty =
            DependencyProperty.Register("BorderStyle", typeof(Style),
            typeof(CustomPasswordBox), new PropertyMetadata(null, OnBorderStylePropertyChanged));

            PasswordBoxStyleProperty =
            DependencyProperty.Register("PasswordBoxStyle", typeof(Style), 
            typeof(CustomPasswordBox), new PropertyMetadata(null, OnPasswordBoxStylePropertyChanged));

            ErrorTextBlockStyleProperty =
            DependencyProperty.Register("ErrorTextBlockStyle", typeof(Style), 
            typeof(CustomPasswordBox), new PropertyMetadata(null, OnErrorTextBlockStylePropertyChanged));

            MainGridStyleProperty =
            DependencyProperty.Register("MainGridStyle", typeof(Style), 
            typeof(CustomPasswordBox), new PropertyMetadata(null, OnMainGridStylePropertyChanged));

            #endregion
        }
        

        #endregion

        #region Ctor

        public CustomPasswordBox()
        {
            InitializeComponent();

            m_swaper = new ResourceSwaper(this.Resources);
        }

        #endregion

        #region Methods

        #region Property Changes

        #region Styles

        private static void OnBorderStylePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var This = d as CustomPasswordBox;

            This.m_swaper.Swap("BorderStyle", e.NewValue);
        }

        private static void OnPasswordBoxStylePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var This = d as CustomPasswordBox;

            This.m_swaper.Swap("PasswordBoxStyle", e.NewValue);
        }

        private static void OnErrorTextBlockStylePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var This = d as CustomPasswordBox;

            This.m_swaper.Swap("ErrorTextBlockStyle", e.NewValue);
        }

        private static void OnMainGridStylePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var This = d as CustomPasswordBox;

            This.m_swaper.Swap("MainGridStyle", e.NewValue);
        }

        #endregion

        #endregion

        #region UI Elements Event Handlers

        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #endregion


    }
}
