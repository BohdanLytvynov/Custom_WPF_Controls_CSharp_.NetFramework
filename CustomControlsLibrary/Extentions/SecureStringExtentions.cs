using System;
using System.Collections.Generic;
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
        #region Methods
        public static byte[] GetBytes(this SecureString secString, Encoding encoding = null)
        { 
            byte[] bytes = new byte[secString.Length];

            IntPtr ptr = IntPtr.Zero;

            try
            {
                ptr = Marshal.SecureStringToBSTR(secString);

                byte* bytePtr = (byte*)ptr.ToPointer();

                int i = 0;

                for (; *bytePtr != 0; bytePtr++, i++)
                {
                    bytes[i] = *bytePtr;
                }
            }
            catch (Exception e)
            {

                throw;
            }
            finally
            {
                Marshal.FreeBSTR(ptr);
            }

            return bytes;
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
