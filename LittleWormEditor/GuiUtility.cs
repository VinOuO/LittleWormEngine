using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LittleWorm
{
    class GuiUtility
    {
        public static Control Find_Control(string _ControlName, Control.ControlCollection _Controls)
        {
            foreach (Control _Control in _Controls)
            {
                if(_Control.Name == _ControlName)
                {
                    return _Control;
                }
            }
            return null;
        }

        public static bool Is_Focused(Control.ControlCollection _Controls)
        {
            foreach (Control _Control in _Controls)
            {
                if (_Control is TextBox && _Control.Focused)
                {
                    return true;
                }
            }
            return false;
        }

        public static Label Captured_Label(Control.ControlCollection _Controls)
        {
            foreach (Control _Control in _Controls)
            {
                if (_Control is Label && _Control.Capture)
                {
                    return _Control as Label;
                }
            }
            return null;
        }

        public static string Captured_Label(Control.ControlCollection _Controls, int a)
        {
            foreach (Control _Control in _Controls)
            {
                if (_Control.Capture)
                {
                    return _Control.Name;
                }
            }
            return null;
        }
    }
}
