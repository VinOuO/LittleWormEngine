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
    class ShadowTexture
    {
        public uint TexID;
        public uint FrameBufferID;
        public int Width = 1024;
        public int Height = 1024;

        public ShadowTexture()
        {
            Create_Texture();
        }

        public unsafe void Create_Texture()
        {
            TexID = glGenTexture();
            glBindTexture(GL_TEXTURE_2D, TexID);
            glTexImage2D(GL_TEXTURE_2D, 0, GL_DEPTH_COMPONENT, Width, Height, 0, GL_DEPTH_COMPONENT, GL_FLOAT, NULL);
            Set_TextureMode();

            FrameBufferID = glGenFramebuffer();
            glBindFramebuffer(GL_FRAMEBUFFER, FrameBufferID);
            glFramebufferTexture2D(GL_FRAMEBUFFER, GL_DEPTH_ATTACHMENT, GL_TEXTURE_2D, TexID, 0);
            glDrawBuffer(GL_NONE);
            glReadBuffer(GL_NONE);
            glBindFramebuffer(GL_FRAMEBUFFER, 0);
        }

        public void Set_TextureMode()
        {
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
        }
    }
}
