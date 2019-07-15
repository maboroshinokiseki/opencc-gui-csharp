namespace OpenCC_GUI
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    public static class Converter
    {
        /// <summary>
        /// object for lock statement.
        /// </summary>
        private static object locker = new object();

        /// <summary>
        /// Convert input string with certain config files.
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="configFileName">Config file name.</param>
        /// <returns></returns>
        /// <exception cref="ExternalException">Throw when OpenCC occurs an error!</exception>
        public static string Convert(string input, string configFileName)
        {
            IntPtr opencc_ptr = opencc_open(configFileName);
            if (opencc_ptr == new IntPtr(-1))
            {
                ThrowOpenccException();
            }

            byte[] utf8StringBytes = Encoding.UTF8.GetBytes(input + char.MinValue);
            IntPtr resultPtr = opencc_convert_utf8(opencc_ptr, utf8StringBytes, (UIntPtr)utf8StringBytes.Length);
            if (resultPtr == IntPtr.Zero)
            {
                ThrowOpenccException();
            }

            string result = StringFromNativeUtf8(resultPtr);
            opencc_convert_utf8_free(resultPtr);

            var closeResult = opencc_close(opencc_ptr);
            if (closeResult != 0)
            {
                ThrowOpenccException();
            }

            return result;
        }

        private static string StringFromNativeUtf8(IntPtr nativeUtf8)
        {
            int len = String.Strlen(nativeUtf8);

            byte[] buffer = new byte[len];
            Marshal.Copy(nativeUtf8, buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer);
        }

        private static void ThrowOpenccException()
        {
            lock (locker)
            {
                var errorMessage = opencc_error();
                var errorMessageString = StringFromNativeUtf8(errorMessage);
                throw new ExternalException(errorMessageString);
            }
        }

        /// <summary>
        /// Makes an instance of opencc.
        /// </summary>
        /// <param name="configFileName">Location of configuration file. If this is set to NULL, OPENCC_DEFAULT_CONFIG_SIMP_TO_TRAD will be loaded.</param>
        /// <returns>A description pointer of the newly allocated instance of opencc. On error the return value will be (opencc_t) -1.</returns>
        [DllImport("libopencc")]
        private static extern IntPtr opencc_open(string configFileName);

        /// <summary>
        /// Converts UTF-8 string This function returns an allocated C-Style string, which stores the converted string.
        /// You MUST call opencc_convert_utf8_free() to release allocated memory.
        /// </summary>
        /// <param name="opencc">The opencc description pointer.</param>
        /// <param name="input">The UTF-8 encoded string.</param>
        /// <param name="length">The maximum length in byte to convert. If length is (size_t)-1, the whole string (terminated by '\0') will be converted.</param>
        /// <returns>The newly allocated UTF-8 string that stores text converted, or NULL on error.</returns>
        [DllImport("libopencc")]
        private static extern IntPtr opencc_convert_utf8(IntPtr opencc, byte[] input, UIntPtr length);

        /// <summary>
        /// Releases allocated buffer by opencc_convert_utf8.
        /// </summary>
        /// <param name="str">Pointer to the allocated string buffer by opencc_convert_utf8.</param>
        [DllImport("libopencc")]
        private static extern void opencc_convert_utf8_free(IntPtr str);

        /// <summary>
        /// Destroys an instance of opencc.
        /// </summary>
        /// <param name="opencc">The description pointer.</param>
        /// <returns>0 on success or non-zero number on failure.</returns>
        [DllImport("libopencc")]
        private static extern int opencc_close(IntPtr opencc);

        /// <summary>
        /// Returns the last error message.
        /// Note that this function is the only one which is NOT thread-safe.
        /// </summary>
        /// <returns>Error message</returns>
        [DllImport("libopencc")]
        private static extern IntPtr opencc_error();
    }
}
