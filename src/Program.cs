using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace UltraCtrlAltF4
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(int hWnd, out int ProcessId);

        [DllImport("user32.dll")]
        private static extern int GetForegroundWindow();


        static KeyboardHook hook = new KeyboardHook();

        [STAThread]
        static void Main(string[] args)
        {
            // register the event that is fired after the key press.
            hook.KeyPressed +=
                new EventHandler<KeyPressedEventArgs>(keyDown);
            // register the control + alt + F4 combination as hot key.
            hook.RegisterHotKey(ModifierKeys.Control | ModifierKeys.Alt,
                Keys.F4);

            Application.Run(new Form1());

            hook.Dispose();
        }

        public static Process GetActiveProcess()
        {
            Int32 hwnd = 0;
            Int32 pid = 1;

            hwnd = GetForegroundWindow();

            GetWindowThreadProcessId(hwnd, out pid);

            return Process.GetProcessById(pid);

            //string appProcessName = Process.GetProcessById(GetWindowProcessID(hwnd)).ProcessName;
            //string appExePath = Process.GetProcessById(GetWindowProcessID(hwnd)).MainModule.FileName;
            //string appExeName = appExePath.Substring(appExePath.LastIndexOf(@"\") + 1);
            
        }

        public static void KillActiveProcess()
        {

            Process p = GetActiveProcess();
            p.Kill();

        }

        public static void keyDown(object sender, KeyPressedEventArgs e)
        {
            Debug.WriteLine("Ctrl-Alt-F4 PRESSED");
            KillActiveProcess();
        }

    }
}
