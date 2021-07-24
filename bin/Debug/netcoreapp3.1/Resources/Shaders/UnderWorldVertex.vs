#version 330 core

layout (location = 0) in vec3 position;
layout (location = 1) in vec2 texCoord;
layout (location = 2) in vec3 normal;

uniform vec3 cam_pos;
uniform mat4 transform;
uniform mat4 nptransform;

vec4 temp_Pos;

out vec3 normal0;
out vec2 texCoord0;
out vec3 cam_angle;
out vec3 position0;

void main()
{
	temp_Pos = nptransform * vec4(position, 1.0);
	position0 = vec3(temp_Pos.x,temp_Pos.y,temp_Pos.z);
	cam_angle = normalize(cam_pos - position0);
	normal0 = normal;
	texCoord0 = texCoord;
	gl_Position = transform * vec4(position, 1.0);
}