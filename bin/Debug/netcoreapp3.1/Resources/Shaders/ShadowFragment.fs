#version 330

//in vec2 texCoord0;
layout(location = 0) out vec4 fragColor;

//uniform sampler2D sampler;

void main()
{
	gl_FragDepth = gl_FragCoord.z;
	fragColor = vec4(gl_FragCoord.z,gl_FragCoord.z,gl_FragCoord.z,1);
}