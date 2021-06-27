using System;
using System.Collections.Generic;
using System.Text;
using GLFW;
using static OpenGL.GL;
using LittleWormEngine.Renderer;

namespace LittleWormEngine
{
    class GameWindow
    {
        public static Window Create_Window(String _Title)
        {
            Core.Width = Glfw.PrimaryMonitor.WorkArea.Width;
            Core.Height = Glfw.PrimaryMonitor.WorkArea.Height;
            Window _Window = Glfw.CreateWindow(Core.Width, Core.Height, _Title, Glfw.PrimaryMonitor, Window.None);
            Glfw.MakeContextCurrent(_Window);
            Import(Glfw.GetProcAddress);
            return _Window;
        }

        public static Window Create_Window(int _Width, int _Height, String _Title)
        {
            Window _Window = Glfw.CreateWindow(_Width, _Height, _Title, Monitor.None, Window.None);
            var screen = Glfw.PrimaryMonitor.WorkArea;
            var x = (screen.Width - _Width) / 2;
            var y = (screen.Height - _Height) / 2;
            Glfw.SetWindowPosition(_Window, x, y);
            Glfw.MakeContextCurrent(_Window);
            Import(Glfw.GetProcAddress);
            return _Window;
        }

        public static void Render(Window _Window)
        {
            Glfw.SwapBuffers(_Window);
            Check_for_Events();
        }

        public static void Check_for_Events()
        {
            Glfw.PollEvents();
        }

        public static bool Close_Requested(Window _Window)
        {
            return (Glfw.WindowShouldClose(_Window) ? true : false);
        }
    }
}
