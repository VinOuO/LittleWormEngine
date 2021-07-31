#version 330 core

out vec4 FragColor;

in vec2 texCoord0;

uniform sampler2D DepthMap;

void main()
{
    float DepthValue = texture(DepthMap, texCoord0).r;
	FragColor = texture(DepthMap, texCoord0);
	//FragColor = vec4(vec3(DepthValue), 1);
	//FragColor =  texture(DepthMap, texCoord0);
} 