using CustomControlsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Custom_WPF_Controls_DotNetFramework
{
    public class MWViewModel : ViewModelBaseLib.ViewModelBase.ViewModelBase
    {
        DateTime date;

        Func<SecureString, TextBlock, bool> CheckPassDelegate;

        public DateTime Date { get=> date; set
            {
                SetProperty(ref date, value, nameof(date));

                Console.WriteLine(date.ToShortDateString());
            }
        }

        public Func<SecureString, TextBlock, bool> CheckPass 
        {
            get=> CheckPassDelegate;
            set=> SetProperty(ref CheckPassDelegate, value, nameof(CheckPass));
        }


        #region Ctor

        public MWViewModel()
        {
            date = DateTime.Now.Date;

            CheckPassDelegate = new Func<SecureString, TextBlock, bool>(
                (secStrig, textblock) => 
                {
                    if (secStrig.Length != 0)
                    {
                        return true;
                    }
                    else
                    {
                        textblock.Text = "Пустое поле!";
                        return false;
                    }
                }
                );                
        }

        #endregion
    }
}
