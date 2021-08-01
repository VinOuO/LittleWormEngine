#version 330 core

layout (location = 0) in vec3 position;
layout (location = 1) in vec2 texCoord;
layout (location = 2) in vec3 normal;

uniform mat4 Transform;


out vec3 Position;
out vec3 Normal;
out vec2 TexCoord;


void main()
{
	Position = position;
	Normal = normal;
	TexCoord = texCoord;
	gl_Position = Transform * vec4(position, 1.0);
}