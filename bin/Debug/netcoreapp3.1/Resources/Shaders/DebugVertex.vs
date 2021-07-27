#version 330 core

layout (location = 0) in vec3 position;
//layout (location = 1) in vec2 texCoord;

//out vec2 texCoord0;

void main()
{
	//texCoord0 = texCoord;
	gl_Position = vec4(position, 1.0);
	//gl_Position = vec4(position.x * 2,position.y * 2,position.z * 2,1);
}