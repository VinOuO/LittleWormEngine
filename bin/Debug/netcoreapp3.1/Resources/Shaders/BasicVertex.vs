#version 330 core

layout (location = 0) in vec3 position;
layout (location = 1) in vec2 texCoord;
layout (location = 2) in vec3 normal;

uniform vec3 cam_pos;
uniform mat4 transform;
uniform mat4 nptransform;

vec4 translated_pos;
out vec3 normal0;
out vec2 texCoord0;
out vec3 cam_angle;


void main()
{
	translated_pos = nptransform * vec4(position, 1.0);
	cam_angle = normalize(cam_pos - vec3(translated_pos.x, translated_pos.y, translated_pos.z)); //position is wrong, need to * transform
	normal0 = normal;
	texCoord0 = texCoord;
	gl_Position = transform * vec4(position, 1.0);
}