#version 330 core

layout (location = 0) in vec3 position;
layout (location = 1) in vec2 texCoord;
layout (location = 2) in vec3 normal;

uniform vec3 cam_pos;
uniform mat4 transform;

out vec3 normal0;
out vec2 texCoord0;
out vec3 cam_angle;


void main()
{
	cam_angle = normalize(cam_pos - position);
	normal0 = normal;
	texCoord0 = texCoord;
	gl_Position = transform * vec4(position, 1.0);
}