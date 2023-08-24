using CustomControlsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Custom_WPF_Controls_DotNetFramework
{
    public class MWViewModel : ViewModelBaseLib.ViewModelBase.ViewModelBase
    {
        DateTime date;

        public DateTime Date { get=> date; set
            {
                SetProperty(ref date, value, nameof(date));

                Console.WriteLine(date.ToShortDateString());
            }
            }

              
        #region Ctor

        public MWViewModel()
        {
            date = DateTime.Now.Date;

            
        }

        #endregion
    }
}
