using System;
using System.Collections.Generic;
using System.Text;
using GLFW;
using static OpenGL.GL;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using LittleWormEngine.Utility;

namespace LittleWormEngine.Renderer
{
    class ShadowTexture
    {
        public uint TexID;
        public uint TexID2;
        public uint FrameBufferID;
        public uint DepthBufferID;
        public int Width = Core.Width;
        public int Height = Core.Height;

        public ShadowTexture()
        {
            //Create_Texture_Testing();
            Create_Texture_OK();
        }

        public unsafe void Create_Texture_Testing()
        {
            FrameBufferID = glGenFramebuffer();
            glBindFramebuffer(GL_FRAMEBUFFER, FrameBufferID);

            TexID = glGenTexture();
            glBindTexture(GL_TEXTURE_2D, TexID);
            glTexImage2D(GL_TEXTURE_2D, 0, GL_DEPTH_COMPONENT, Width, Height, 0, GL_DEPTH_COMPONENT, GL_FLOAT, NULL);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);

            glFramebufferTexture2D(GL_FRAMEBUFFER, GL_DEPTH_ATTACHMENT, GL_TEXTURE_2D, TexID, 0);

            glDrawBuffer(GL_NONE);
            glReadBuffer(GL_NONE);

            if (glCheckFramebufferStatus(GL_FRAMEBUFFER) != GL_FRAMEBUFFER_COMPLETE)
            {
                Debug.LogError("Something went wrong!: Code" + glCheckFramebufferStatus(GL_FRAMEBUFFER));
            }
            glBindFramebuffer(GL_FRAMEBUFFER, 0);
        }

        public unsafe void Create_Texture_OK()//Not using DepthBuffer
        {
            FrameBufferID = glGenFramebuffer();
            glBindFramebuffer(GL_FRAMEBUFFER, FrameBufferID);
            
            TexID = glGenTexture();
            glBindTexture(GL_TEXTURE_2D, TexID);
            glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, Width, Height, 0, GL_RGBA, GL_UNSIGNED_BYTE, NULL);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_BORDER);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_CLAMP_TO_BORDER);
            float[] _Color = new float[4]{ 1, 1, 1, 1 };
            fixed (float* p = &_Color[0])
            {
                glTexParameterfv(GL_TEXTURE_2D, GL_TEXTURE_BORDER_COLOR, p);
            }

            
            glFramebufferTexture(GL_FRAMEBUFFER, GL_COLOR_ATTACHMENT0, TexID, 0);

            glDrawBuffer(GL_COLOR_ATTACHMENT0);

            if (glCheckFramebufferStatus(GL_FRAMEBUFFER) != GL_FRAMEBUFFER_COMPLETE)
            {
                Debug.LogError("Something went wrong!: Code" + glCheckFramebufferStatus(GL_FRAMEBUFFER));
            }
            glBindFramebuffer(GL_FRAMEBUFFER, 0);
        }

        

        public unsafe void Create_Texture()
        {
            FrameBufferID = glGenFramebuffer();
            glBindFramebuffer(GL_FRAMEBUFFER, FrameBufferID);
            /*
            TexID = glGenTexture();
            glBindTexture(GL_TEXTURE_2D, TexID);
            glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB, Width, Height, 0, GL_RGB, GL_UNSIGNED_BYTE, NULL);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
            */
            TexID = glGenTexture();
            glBindTexture(GL_TEXTURE_2D, TexID);
            glTexImage2D(GL_TEXTURE_2D, 0, GL_DEPTH_COMPONENT, Width, Height, 0, GL_DEPTH_COMPONENT, GL_FLOAT, NULL);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_EDGE);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_CLAMP_TO_EDGE);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_COMPARE_MODE, GL_NONE);
            /*
            DepthBufferID = glGenFramebuffer();
            glBindFramebuffer(GL_RENDERBUFFER, DepthBufferID);
            glRenderbufferStorage(GL_RENDERBUFFER, GL_DEPTH_COMPONENT, Width, Height);
            glFramebufferRenderbuffer(GL_FRAMEBUFFER, GL_DEPTH_ATTACHMENT, GL_RENDERBUFFER, DepthBufferID);
            */
            //glFramebufferTexture2D(GL_FRAMEBUFFER, GL_DEPTH_ATTACHMENT, GL_TEXTURE_2D, TexID, 0);
            glFramebufferTexture(GL_FRAMEBUFFER, GL_DEPTH_ATTACHMENT, TexID, 0);
            //glDrawBuffer(GL_DEPTH_ATTACHMENT);
            glDrawBuffer(GL_NONE);
            glReadBuffer(GL_NONE);

            if (glCheckFramebufferStatus(GL_FRAMEBUFFER) != GL_FRAMEBUFFER_COMPLETE)
            {
                Debug.LogError("Something went wrong!");
            }
            glBindFramebuffer(GL_FRAMEBUFFER, 0);
        }

        public unsafe void Create_TextureD()
        {
            TexID = glGenTexture();
            glPixelStorei(GL_UNPACK_ALIGNMENT, 1);
            glBindTexture(GL_TEXTURE_2D, TexID);
            //glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB, Width, Height, 0, GL_RGB, GL_UNSIGNED_BYTE, NULL);
            glTexImage2D(GL_TEXTURE_2D, 0, GL_DEPTH_COMPONENT, Width, Height, 0, GL_DEPTH_COMPONENT, GL_FLOAT, NULL);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);

            DepthBufferID = glGenFramebuffer();
            glBindFramebuffer(GL_RENDERBUFFER, DepthBufferID);
            //glFramebufferTexture2D(GL_FRAMEBUFFER, GL_COLOR_ATTACHMENT0, GL_TEXTURE_2D, TexID, 0);
            glFramebufferTexture2D(GL_FRAMEBUFFER, GL_DEPTH_ATTACHMENT, GL_TEXTURE_2D, TexID, 0);
            glDrawBuffer(GL_NONE);
            glReadBuffer(GL_NONE);

            if (glCheckFramebufferStatus(GL_FRAMEBUFFER) != GL_FRAMEBUFFER_COMPLETE)
            {
                Debug.LogError("Something went wrong!");
            }
            glBindTexture(GL_TEXTURE_2D, 0);
            glBindFramebuffer(GL_FRAMEBUFFER, 0);
        }

    }
}
