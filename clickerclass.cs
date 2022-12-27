using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace dosefx
{
    class clickerclass
    {


        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point lpPoint);

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);


        public static string javaw()
        {
            Process[] proc = Process.GetProcessesByName("javaw");
            foreach (var process in proc)
            {
                return process.MainWindowTitle;
            }
            return "Bulunamadı";
        }

        public static string java()
        {
            Process[] proc = Process.GetProcessesByName("java");
            foreach (var process in proc)
            {
                return process.MainWindowTitle;
            }
            return "Bulunamadı";
        }

        public static string craftrise()
        {
            Process[] proc = Process.GetProcessesByName("craftrise-x64");
            foreach (var process in proc)
            {
                return process.MainWindowTitle;
            }
            return "Bulunamadı";
        }

        public static string getjavawTitle()
        {
            if (javaw() == "Bulunamadı")
            {
                eturn craftrise();
            }
            else
            {
                return javaw();
            }
        }

        public static void leftclick(int count)
        {
            // Get cursor's position
            GetCursorPos(out Point lpPoint);

            // Find window where we want to send mouse click
            IntPtr parentWindow = FindWindow(null, getjavawTitle());

            // Prepare click argument
            IntPtr lParam = (IntPtr)((lpPoint.Y << 16) | lpPoint.X);

            for (int i = 0; i < count; ++i)
            {
                // Send button push down message
                PostMessage(parentWindow, 513, (IntPtr)1, lParam);
                PostMessage(parentWindow, 514, IntPtr.Zero, lParam);
            }
        }

        public static void rightclick(int count)
        {
            // Get cursor's position
            GetCursorPos(out Point lpPoint);

            // Find window where we want to send mouse click
            IntPtr parentWindow = FindWindow(null, getjavawTitle());

            // Prepare click argument
            IntPtr lParam = (IntPtr)((lpPoint.Y << 16) | lpPoint.X);

            for (int i = 0; i < count; ++i)
            {
                // Send button push down message
                PostMessage(parentWindow, 516, (IntPtr)1, lParam);
                PostMessage(parentWindow, 517, IntPtr.Zero, lParam);
            }
        }


    }
}
