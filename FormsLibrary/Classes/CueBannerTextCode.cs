﻿using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FormsLibrary.Classes
{
    /// <summary>
    /// This is not needed in .NET Core
    /// </summary>
    public static class CueBannerTextCode
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        [DllImport("user32", EntryPoint = "FindWindowExA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]

        private static extern IntPtr FindWindowEx(IntPtr hWnd1, IntPtr hWnd2, string lpsz1, string lpsz2);
        private const int EmSetCueBanner = 0x1501;

        /// <summary>
        /// Set place holder
        /// </summary>
        /// <param name="control">Controls e.g. TextBox</param>
        /// <param name="text">Place holder text to display when control loses focus with no text</param>
        public static void SetCueText(Control control, string text)
        {

            if (control is ComboBox)
            {
                var handle = FindWindowEx(control.Handle, IntPtr.Zero, "Edit", null);

                if (!(handle == IntPtr.Zero))
                {
                    SendMessage(handle, EmSetCueBanner, 0, text);
                }
            }
            else if (control is TextBox)
            {
                SendMessage(control.Handle, EmSetCueBanner, 0, text);
            }
        }

    }
}