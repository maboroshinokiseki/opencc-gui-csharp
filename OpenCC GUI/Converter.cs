using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OpenCC_GUI
{
    public static class Converter
    {
        [DllImport("opencc.dll")]
        private static extern IntPtr opencc_open(string configFileName);

        [DllImport("opencc.dll")]
        private static extern IntPtr opencc_convert_utf8(IntPtr opencc, byte[] input, UIntPtr length);

        [DllImport("opencc.dll")]
        private static extern void opencc_convert_utf8_free(IntPtr str);

        [DllImport("opencc.dll")]
        private static extern int opencc_close(IntPtr opencc);

        private static string StringFromNativeUtf8(IntPtr nativeUtf8)
        {
            int len = 0;
            while (Marshal.ReadByte(nativeUtf8, len) != 0)
                ++len;
            byte[] buffer = new byte[len];
            Marshal.Copy(nativeUtf8, buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer);
        }

        public static string Convert(string input, string configFileName)
        {
            IntPtr opencc_ptr = opencc_open(configFileName);
            if (opencc_ptr == IntPtr.Zero)
                return null;
            byte[] u8StringBytes = Encoding.UTF8.GetBytes(input + char.MinValue);
            IntPtr resultPtr = opencc_convert_utf8(opencc_ptr, u8StringBytes, (UIntPtr)u8StringBytes.Length);
            string result = null;
            if (resultPtr != IntPtr.Zero)
            {
                result = StringFromNativeUtf8(resultPtr);
                opencc_convert_utf8_free(resultPtr);
            }
            opencc_close(opencc_ptr);
            return result;
        }
    }
}
