#version 330 core

layout (location = 0) in vec3 position;
//layout (location = 1) in vec2 texCoord;

uniform mat4 LightSpace;

//out vec2 texCoord0;

void main()
{
	//texCoord0 = texCoord;
	gl_Position = LightSpace  * vec4(position, 1.0);
}