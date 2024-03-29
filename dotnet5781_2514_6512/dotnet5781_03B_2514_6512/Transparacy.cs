﻿//using System;
//using System.Collections.Generic;
//using System.Runtime.InteropServices;
//using System.Windows;
//using System.Windows.Interop;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace dotnet5781_03B_2514_6512
//{
//    class TransparencyConverter
//    {
//        private readonly Window _window;

//        public TransparencyConverter(Window window)
//        {
//            _window = window;
//        }

//        public void MakeTransparent()
//        {
//            var mainWindowPtr = new WindowInteropHelper(_window).Handle;
//            var mainWindowSrc = HwndSource.FromHwnd(mainWindowPtr);
//            if (mainWindowSrc != null)
//                if (mainWindowSrc.CompositionTarget != null)
//                    mainWindowSrc.CompositionTarget.BackgroundColor = System.Windows.Media.Color.FromArgb(0, 0, 0, 0);

//            var margins = new Margins
//            {
//                cxLeftWidth = 0,
//                cxRightWidth = Convert.ToInt32(_window.Width) * Convert.ToInt32(_window.Width),
//                cyTopHeight = 0,
//                cyBottomHeight = Convert.ToInt32(_window.Height) * Convert.ToInt32(_window.Height)
//            };

//            if (mainWindowSrc != null) DwmExtendFrameIntoClientArea(mainWindowSrc.Handle, ref margins);
//        }

//        [StructLayout(LayoutKind.Sequential)]
//        public struct Margins
//        {
//            public int cxLeftWidth;
//            public int cxRightWidth;
//            public int cyTopHeight;
//            public int cyBottomHeight;
//        }

//        [DllImport("DwmApi.dll")]
//        public static extern int DwmExtendFrameIntoClientArea(IntPtr hwnd, ref Margins pMarInset);
//    }
//}
