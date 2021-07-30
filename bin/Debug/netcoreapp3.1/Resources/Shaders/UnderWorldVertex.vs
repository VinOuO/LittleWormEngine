#version 330 core

layout (location = 0) in vec3 position;
layout (location = 1) in vec2 texCoord;
layout (location = 2) in vec3 normal;

uniform vec3 Camera_Pos;
uniform mat4 Transform;
uniform mat4 NPTransform;

vec4 temp_Pos;
vec4 temp_Pos2;
out vec3 normal0;
out vec2 texCoord0;
out vec3 cam_angle;
out vec3 position0;

void main()
{
	temp_Pos = NPTransform * vec4(position, 1.0);
	position0 = vec3(temp_Pos.x,temp_Pos.y,temp_Pos.z);
	cam_angle = normalize(position0 - Camera_Pos);
	normal0 = normal;
	texCoord0 = texCoord;
	gl_Position = Transform * vec4(position, 1.0);
}