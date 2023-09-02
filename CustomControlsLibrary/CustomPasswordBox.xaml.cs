using CustomControlsLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
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

        #region Styles

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

        #region Additional Values

        public bool IsCorrect
        {
            get { return (bool)GetValue(IsCorrectProperty); }
            set { SetValue(IsCorrectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsCorrect.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsCorrectProperty;



        public Func<SecureString, TextBlock, bool> CheckPasswordDelegate
        {
            get { return (Func<SecureString, TextBlock, bool>)GetValue(CheckPasswordDelegateProperty); }
            set { SetValue(CheckPasswordDelegateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CheckPasswordDelegate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CheckPasswordDelegateProperty;



        public double ErrorTextBlockHeight
        {
            get { return (double)GetValue(ErrorTextBlockHeightProperty); }
            set { SetValue(ErrorTextBlockHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorTextBlockHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorTextBlockHeightProperty;



        #endregion

        #region ErrorStyle

        public Style CaseErrorStyle
        {
            get { return (Style)GetValue(CaseErrorStyleProperty); }
            set { SetValue(CaseErrorStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CaseErrorStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CaseErrorStyleProperty;

        #endregion

        #endregion

        #region Fields

        ResourceSwaper m_swaper;

        #endregion

        #region Staatic ctor

        static CustomPasswordBox()
        {
            #region Register Dependency Properties

            #region Styles

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

            CaseErrorStyleProperty =
            DependencyProperty.Register("CaseErrorStyle", typeof(Style), 
            typeof(CustomPasswordBox), new PropertyMetadata(null, OnCaseErrorStylePropertyChanged));

            #endregion

            #region Additional Properties

            ErrorTextBlockHeightProperty =
            DependencyProperty.Register("ErrorTextBlockHeight", typeof(double), 
            typeof(CustomPasswordBox), new PropertyMetadata((double)15, OnErrorTextBlockHeightPropertyChanged));

            IsCorrectProperty =
            DependencyProperty.Register("IsCorrect", typeof(bool), 
            typeof(CustomPasswordBox), new PropertyMetadata(false));

            CheckPasswordDelegateProperty =
            DependencyProperty.Register("CheckPasswordDelegate", typeof(Func<SecureString, TextBlock, bool>), 
            typeof(CustomPasswordBox), new PropertyMetadata(null, OnCheckPasswordDelegatePropertyChanged));

            #endregion

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

        private static void OnCaseErrorStylePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var This = d as CustomPasswordBox;

            This.m_swaper.Swap("CaseErrorStyle", e.NewValue);
        }

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

        private static void OnCheckPasswordDelegatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var This = d as CustomPasswordBox;

            This.CheckPasswordDelegate = (Func<SecureString, TextBlock, bool>)e.NewValue;
        }

        private static void OnErrorTextBlockHeightPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var This = d as CustomPasswordBox;

            if (This.MainGrid.RowDefinitions[1] != null)
                This.MainGrid.RowDefinitions[1].Height =
                    new GridLength((double)e.NewValue, GridUnitType.Pixel);
        }

        #endregion

        #region UI Elements Event Handlers

        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Check();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Check();
        }

        private void Check()
        {
            IsCorrect = CheckPasswordDelegate?.Invoke(this.Password.SecurePassword, Error) ?? false;

            if (IsCorrect)
            {
                this.Error.Visibility = Visibility.Hidden;

                this.MainBorder.Style = (Style)this.Resources["BorderStyle"];
            }
            else
            {
                this.Error.Visibility = Visibility.Visible;

                this.MainBorder.Style = (Style)this.Resources["CaseErrorStyle"];
            }
        }

        #endregion

        #endregion        
    }
}
