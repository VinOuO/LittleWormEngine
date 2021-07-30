using System;
using System.Collections.Generic;
using System.Text;
using GLFW;
using LittleWormEngine.Utility;
using static OpenGL.GL;

namespace LittleWormEngine
{
    class Input
    {
        public static Vector2 mousePosition { get; set; }
        public static Vector2 MousePosition { get {return (mousePosition == null? Vector2.Zero : mousePosition); } set { mousePosition = value; } }
        static List<Keys> Pressing_Keys = new List<Keys>();
        static List<Keys> Releasing_Keys = new List<Keys>();
        static List<Keys> Current_Keys = new List<Keys>();
        static List<MouseButton> Pressing_MouseButtons = new List<MouseButton>();
        static List<MouseButton> Releasing_MouseButtons = new List<MouseButton>();
        static List<MouseButton> Current_MouseButtons = new List<MouseButton>();

        public static void Update(Window _Window)
        {
            Check_Input_State(_Window);
        }

        public static void Check_Cursor_Position(Window _Window, double _x, double _y)
        {
            Vector2 _Temp = new Vector2((float)_x, (float)_y);
            MousePosition = _Temp;
        }

        public static void Check_Input_State(Window _Window)
        {
            int _State = 0;

            Pressing_MouseButtons.Clear();
            foreach (MouseButton _MouseButton in Enum.GetValues(typeof(MouseButton)))
            {
                _State = (int)Glfw.GetMouseButton(_Window, _MouseButton);
                if (!Current_MouseButtons.Contains(_MouseButton) && _State == (int)InputState.Press)
                {
                    //Console.WriteLine("Mouse : " + _MouseButton.ToString() + " is pressed");
                    Pressing_MouseButtons.Add(_MouseButton);
                }
            }

            Releasing_MouseButtons.Clear();
            foreach (MouseButton _MouseButton in Enum.GetValues(typeof(MouseButton)))
            {
                _State = (int)Glfw.GetMouseButton(_Window, _MouseButton);
                if (Current_MouseButtons.Contains(_MouseButton) && _State == (int)InputState.Release)
                {
                    //Console.WriteLine("Mouse : " + _MouseButton.ToString() + " is released");
                    Releasing_MouseButtons.Add(_MouseButton);
                }
            }

            Current_MouseButtons.Clear();
            foreach (MouseButton _MouseButton in Enum.GetValues(typeof(MouseButton)))
            {
                _State = (int)Glfw.GetMouseButton(_Window, _MouseButton);
                if (_State == (int)InputState.Press)
                {
                    Current_MouseButtons.Add(_MouseButton);
                }
            }

            Pressing_Keys.Clear();
            foreach (Keys _Key in Enum.GetValues(typeof(Keys)))
            {
                _State = (int)Glfw.GetKey(_Window, _Key);
                if (!Current_Keys.Contains(_Key) && _State == (int)InputState.Press)
                {
                    //Console.WriteLine("Key : " + _Key.ToString() + " is pressed");
                    Pressing_Keys.Add(_Key);
                }
            }

            Releasing_Keys.Clear();
            foreach (Keys _Key in Enum.GetValues(typeof(Keys)))
            {
                _State = (int)Glfw.GetKey(_Window, _Key);
                if (Current_Keys.Contains(_Key) && _State == (int)InputState.Release)
                {
                    //Console.WriteLine("Key : " + _Key.ToString() + " is released");
                    Releasing_Keys.Add(_Key);
                }
            }

            Current_Keys.Clear();
            foreach (Keys _Key in Enum.GetValues(typeof(Keys)))
            {
                _State = (int)Glfw.GetKey(_Window, _Key);
                if (_State == (int)InputState.Press)
                {
                    Current_Keys.Add(_Key);
                }
            }
        }

        public static bool GetKeyDown(KeyCode _Key)
        {
            switch (_Key)
            {
                case KeyCode.Any:
                    return (Pressing_Keys.Count > 0 || Pressing_MouseButtons.Count > 0) ? true : false;
            }
            return Pressing_Keys.Contains((Keys)_Key) ? true : false;
        }

        public static bool GetKey(KeyCode _Key)
        {
            switch (_Key)
            {
                case KeyCode.Any:
                    return (Current_Keys.Count > 0 || Current_MouseButtons.Count > 0) ? true : false;
            }
            return Current_Keys.Contains((Keys)_Key) ? true : false;
        }

        public static bool GetKeyUp(KeyCode _Key)
        {
            switch (_Key)
            {
                case KeyCode.Any:
                    return (Releasing_Keys.Count > 0 || Releasing_MouseButtons.Count > 0) ? true : false;
            }
            return Releasing_Keys.Contains((Keys)_Key) ? true : false;
        }

        public static bool GetKeyDown(MouseCode _Mouse)
        {
            return Pressing_MouseButtons.Contains((MouseButton)_Mouse) ? true : false;
        }

        public static bool GetKey(MouseCode _Mouse)
        {
            return Current_MouseButtons.Contains((MouseButton)_Mouse) ? true : false;
        }

        public static bool GetKeyUp(MouseCode _Mouse)
        {
            return Releasing_MouseButtons.Contains((MouseButton)_Mouse) ? true : false;
        }

    }

    public enum MouseCode
    {
        Left = 0,
        Right = 1,
        Middle = 2,
    }

    public enum KeyCode
    {
        //Unknown = -1,
        Any = -1,
        Space = 32,
        Apostrophe = 39,
        Comma = 44,
        Minus = 45,
        Period = 46,
        Slash = 47,
        Alpha0 = 48,
        Alpha1 = 49,
        Alpha2 = 50,
        Alpha3 = 51,
        Alpha4 = 52,
        Alpha5 = 53,
        Alpha6 = 54,
        Alpha7 = 55,
        Alpha8 = 56,
        Alpha9 = 57,
        SemiColon = 59,
        Equal = 61,
        A = 65,
        B = 66,
        C = 67,
        D = 68,
        E = 69,
        F = 70,
        G = 71,
        H = 72,
        I = 73,
        J = 74,
        K = 75,
        L = 76,
        M = 77,
        N = 78,
        O = 79,
        P = 80,
        Q = 81,
        R = 82,
        S = 83,
        T = 84,
        U = 85,
        V = 86,
        W = 87,
        X = 88,
        Y = 89,
        Z = 90,
        LeftBracket = 91,
        Backslash = 92,
        RightBracket = 93,
        GraveAccent = 96,
        World1 = 161,
        World2 = 162,
        Escape = 256,
        Enter = 257,
        Tab = 258,
        Backspace = 259,
        Insert = 260,
        Delete = 261,
        Right = 262,
        Left = 263,
        Down = 264,
        Up = 265,
        PageUp = 266,
        PageDown = 267,
        Home = 268,
        End = 269,
        CapsLock = 280,
        ScrollLock = 281,
        NumLock = 282,
        PrintScreen = 283,
        Pause = 284,
        F1 = 290,
        F2 = 291,
        F3 = 292,
        F4 = 293,
        F5 = 294,
        F6 = 295,
        F7 = 296,
        F8 = 297,
        F9 = 298,
        F10 = 299,
        F11 = 300,
        F12 = 301,
        F13 = 302,
        F14 = 303,
        F15 = 304,
        F16 = 305,
        F17 = 306,
        F18 = 307,
        F19 = 308,
        F20 = 309,
        F21 = 310,
        F22 = 311,
        F23 = 312,
        F24 = 313,
        F25 = 314,
        Numpad0 = 320,
        Numpad1 = 321,
        Numpad2 = 322,
        Numpad3 = 323,
        Numpad4 = 324,
        Numpad5 = 325,
        Numpad6 = 326,
        Numpad7 = 327,
        Numpad8 = 328,
        Numpad9 = 329,
        NumpadDecimal = 330,
        NumpadDivide = 331,
        NumpadMultiply = 332,
        NumpadSubtract = 333,
        NumpadAdd = 334,
        NumpadEnter = 335,
        NumpadEqual = 336,
        LeftShift = 340,
        LeftControl = 341,
        LeftAlt = 342,
        LeftSuper = 343,
        RightShift = 344,
        RightControl = 345,
        RightAlt = 346,
        RightSuper = 347,
        Menu = 348
    }
}
