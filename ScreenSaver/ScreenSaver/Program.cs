﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ScreenSaver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                string firstArgument = args[0].ToLower().Trim();
                string secondArgument = null;

                // Handle cases where arguments are separated by colon.
                // Examples: /c:1234567 or /P:1234567
                if (firstArgument.Length > 2)
                {
                    secondArgument = firstArgument.Substring(3).Trim();
                    firstArgument = firstArgument.Substring(0, 2);
                }
                else if (args.Length > 1)
                    secondArgument = args[1];

                if (firstArgument == "/c")           // Configuration mode
                {
                    // TODO
                }
                else if (firstArgument == "/p")      // Preview mode
                {
                    //if (secondArgument == null)
                    //{
                    //    MessageBox.Show("Sorry, but the expected window handle was not provided.",
                    //        "ScreenSaver", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    return;
                    //}

                    //IntPtr previewWndHandle = new IntPtr(long.Parse(secondArgument));
                    //Application.Run(new ScreenSaverForm(previewWndHandle));
                    Application.Exit();

                }
                else if (firstArgument == "/s")      // Full-screen mode
                {
                    Process.Start("E:/Github/Transparent_Window_Builds/Transparent_Screen_Build1.exe");
                    //ShowScreenSaver();
                    //Application.Run();
                }
                else    // Undefined argument
                {
                    MessageBox.Show("Sorry, but the command line argument \"" + firstArgument +
                        "\" is not valid.", "ScreenSaver",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else    // No arguments - treat like /c
            {
                // TODO
            }

        }

        static void ShowScreenSaver()
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                ScreenSaverForm screensaver = new ScreenSaverForm(screen.Bounds);
                screensaver.Show();
            }
        }
    }
}
