using CustomControlsLibrary;
using CustomControlsLibrary.Extentions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Custom_WPF_Controls_DotNetFramework
{
    public class MWViewModel : ViewModelBaseLib.ViewModelBase.ViewModelBase
    {
        DateTime date;

        Func<int, SecureString, TextBlock, bool> CheckPassDelegate;

        public DateTime Date { get=> date; set
            {
                SetProperty(ref date, value, nameof(date));

                Console.WriteLine(date.ToShortDateString());
            }
        }

        public Func<int, SecureString, TextBlock, bool> CheckPass 
        {
            get=> CheckPassDelegate;
            set=> SetProperty(ref CheckPassDelegate, value, nameof(CheckPass));
        }


        #region Ctor

        public MWViewModel()
        {
            date = DateTime.Now.Date;

            CheckPassDelegate = new Func<int, SecureString, TextBlock, bool>(
                (id, secStrig, textblock) => 
                {
                    if (secStrig.Length != 0)
                    {
                        var f = id;
                        //Place Here Some Check Code

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
