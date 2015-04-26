using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevNotepad.Library.Extensions
{
    public static class ControlExtensions
    {

        
            [DllImport("user32.dll")]
            public static extern bool LockWindowUpdate(IntPtr hWndLock);
            //private const int WM_SETREDRAW = 0x000B;

            public static void Suspend(this Control control)
            {
                //Message msgSuspendUpdate = Message.Create(control.Handle, WM_SETREDRAW, IntPtr.Zero,
                //    IntPtr.Zero);

                //NativeWindow window = NativeWindow.FromHandle(control.Handle);
                //window.DefWndProc(ref msgSuspendUpdate);
                LockWindowUpdate(control.Handle);
            }

            public static void Resume(this Control control)
            {
                // Create a C "true" boolean as an IntPtr
                //IntPtr wparam = new IntPtr(1);
                //Message msgResumeUpdate = Message.Create(control.Handle, WM_SETREDRAW, wparam,
                //    IntPtr.Zero);

                //NativeWindow window = NativeWindow.FromHandle(control.Handle);
                //window.DefWndProc(ref msgResumeUpdate);

                //control.Invalidate();
                LockWindowUpdate(IntPtr.Zero);
            }
        }
    }