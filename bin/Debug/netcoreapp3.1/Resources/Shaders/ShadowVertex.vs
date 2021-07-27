#version 330 core

layout (location = 0) in vec3 position;

uniform LightSpace;
uniform Transform;

void main()
{
	gl_Position = LightSpace * Transform * vec4(position, 1.0);
}