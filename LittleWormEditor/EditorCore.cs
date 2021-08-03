using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LittleWormEngine;

namespace LittleWorm
{
    static class EditorCore
    {
        public static GameObject SelectingGameObject;
        public static Component SelectingComponent;
        public static List<string> MeshFileNames;
        public static List<string> TextureFileNames;
        public static bool ChangeGameObjectDropDown = false, ChangeCompontentDropDown = false;

        [STAThread]
        public static void Start()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Inspector());
        }
    }
}
