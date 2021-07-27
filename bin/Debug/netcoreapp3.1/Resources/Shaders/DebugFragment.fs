#version 330

out vec4 FragColor;

//in vec2 texCoord0;

//uniform sampler2D DepthMap;

void main()
{
    //float DepthValue = texture(DepthMap, texCoord0).r;
	//FragColor = vec4(vec3(DepthValue),1);
	FragColor = vec4(0, 1, 1, 1);
} 