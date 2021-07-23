using System;
using System.Collections.Generic;
using System.Text;
using GLFW;
using static OpenGL.GL;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace LittleWormEngine.Renderer
{
    class Texture
    {
        public uint TexID;
        Bitmap Image;

        public Texture(string _FileName)
        {
            Image = new Bitmap(Directory.GetCurrentDirectory() + @"\Resources" + @"\Textures\" + _FileName);
            Create_Texture();
        }

        public void Create_Texture()
        {
            TexID = glGenTexture();
            glBindTexture(GL_TEXTURE_2D, TexID);
            glPixelStorei(GL_UNPACK_ALIGNMENT, 1);
            BitmapData _Bmp_Data = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB, _Bmp_Data.Width, _Bmp_Data.Height, 0, GL_BGR, GL_UNSIGNED_BYTE, _Bmp_Data.Scan0);
            Image.UnlockBits(_Bmp_Data);
            Set_TextureMode();
            glGenerateMipmap(GL_TEXTURE_2D);
        }

        public static void Set_TextureMode()
        {
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
        } 
    }
}
