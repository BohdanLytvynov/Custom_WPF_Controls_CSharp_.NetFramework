using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CustomControlsLibrary.Extentions
{
    public unsafe static class SecureStringExtentions
    {
        #region Static Ctor

        static SecureStringExtentions()
        {
            m_enc = Encoding.GetEncoding(1251);
        }

        #endregion

        #region Static state variables

        static Encoding m_enc;

        #endregion

        #region Methods
        public static byte[] GetBytes(this SecureString secString, Encoding enc)
        { 
            int length = secString.Length;
            
            IntPtr ptr = IntPtr.Zero;

            byte[] workArray = null;

            byte[] result = null;

            GCHandle? handle = null;

            try
            {
                char* bstrBytes = (char*)Marshal.SecureStringToBSTR(secString);
                workArray = new byte[length];
                handle = GCHandle.Alloc(workArray, GCHandleType.Pinned); // Hats off to Tobias Bauer

                for (int i = 0; i < workArray.Length; i++)
                {
                    if (*bstrBytes != 0)
                        workArray[i] = (byte)(*bstrBytes++);                   
                }

                //Recode encoding
                result = Encoding.Convert(m_enc, enc, workArray);                
            }
            catch (Exception e)
            {
                
            }
            finally
            {                               
                handle?.Free();

                if (ptr != IntPtr.Zero)
                    Marshal.ZeroFreeBSTR(ptr);
            }

            return result;
        }
       
        public static bool Equals(this SecureString SecureString1, SecureString SecureString2)
        {
            bool isCorrect = true;

            if (SecureString1 == null || SecureString2 == null)
                return false;

            if (SecureString1.Length != SecureString2.Length)
                return false;

            IntPtr ss1 = IntPtr.Zero;

            IntPtr ss2 = IntPtr.Zero;

            try
            {
                ss1 = Marshal.SecureStringToBSTR(SecureString1);

                ss2 = Marshal.SecureStringToBSTR(SecureString2);

                char* ptr1 = (char*)ss1.ToPointer();

                char* ptr2 = (char*)ss2.ToPointer();

                for (; *ptr1 != 0; ptr1++, ptr2++)
                {
                    if (*ptr1 != *ptr2)
                    {
                        isCorrect = false;

                        break;
                    }
                }
            }
            catch (Exception)
            {
                isCorrect = false;
            }
            finally
            {
                Marshal.FreeBSTR(ss1);

                Marshal.FreeBSTR(ss2);
            }
           
            return isCorrect;
        }

        

        #endregion
    }
}
