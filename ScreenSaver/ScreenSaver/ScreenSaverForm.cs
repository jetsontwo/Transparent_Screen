using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ScreenSaver
{
    //Code taken from https://www.harding.edu/fmccown/screensaver/screensaver.html

    public partial class ScreenSaverForm : Form
    {

        //[DllImport("user32.dll")]
        //static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        //[DllImport("user32.dll")]
        //static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        //[DllImport("user32.dll", SetLastError = true)]
        //static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        //[DllImport("user32.dll")]
        //static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);


        private Point mouseLocation;
        private bool previewMode = false;


        //Basic Constructor
        public ScreenSaverForm(Rectangle Bounds)
        {
            InitializeComponent();
            this.Bounds = Bounds;
        }

        //Preview Constructor
        //public ScreenSaverForm(IntPtr PreviewWndHandle)
        //{
        //    InitializeComponent();

        //    // Set the preview window as the parent of this window
        //    SetParent(this.Handle, PreviewWndHandle);

        //    // Make this a child window so it will close when the parent dialog closes
        //    // GWL_STYLE = -16, WS_CHILD = 0x40000000
        //    SetWindowLong(this.Handle, -16, new IntPtr(GetWindowLong(this.Handle, -16) | 0x40000000));

        //    // Place our window inside the parent
        //    Rectangle ParentRect;
        //    GetClientRect(PreviewWndHandle, out ParentRect);
        //    Size = ParentRect.Size;
        //    Location = new Point(0, 0);

        //    // Make text smaller
        //    textLabel.Font = new System.Drawing.Font("Arial", 6);

        //    previewMode = true;
        //}






        //Event Handlers

        private void ScreenSaverForm_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
            TopMost = true;
        }

        private void ScreenSaverForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseLocation.IsEmpty && !previewMode)
            {
                // Terminate if mouse is moved a significant distance
                if (Math.Abs(mouseLocation.X - e.X) > 5 ||
                    Math.Abs(mouseLocation.Y - e.Y) > 5)
                    Application.Exit();
            }

            // Update current mouse location
            mouseLocation = e.Location;

        }

        private void ScreenSaverForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (!previewMode)
                Application.Exit();

        }

        private void ScreenSaverForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!previewMode)
                Application.Exit();

        }
    }
}
