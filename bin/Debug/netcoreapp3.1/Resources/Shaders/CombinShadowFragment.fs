#version 330 core

out vec4 FragColor;

in vec2 texCoord0;

uniform sampler2D CombinedMap;
uniform sampler2D DepthMap;

void main()
{
	float CombinedValue = texture(CombinedMap, texCoord0).r;
    float DepthValue = texture(DepthMap, texCoord0).r;
	
	if(CombinedValue > DepthValue && DepthValue != 0)
	{
		FragColor = vec4(vec3(DepthValue), 1);
	}
	else
	{
		FragColor = vec4(vec3(CombinedValue), 1);
	}

	/*
	if(texture(CombinedMap, texCoord0).a == 0)
	{
		FragColor = vec4(1,0,1, 1);
	}
	else
	{
		FragColor = vec4(1,1,0, 1);
	}
	*/
	/*
	if(DepthValue != 0)
	{
		FragColor = vec4(vec3(DepthValue), 1);
	}
	else
	{
		FragColor = vec4(vec3(CombinedValue), 1);
	}
	*/
	//FragColor = vec4(1,0,1, 1);
} 