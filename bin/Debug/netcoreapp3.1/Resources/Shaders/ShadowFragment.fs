/*
#version 330 core

//layout(location = 0) out vec4 fragColor;

//uniform sampler2D sampler;

void main()
{
	gl_FragDepth = gl_FragCoord.z;
	//fragColor = vec4(gl_FragCoord.w,gl_FragCoord.w,gl_FragCoord.w,1);
	//fragColor = vec4(gl_FragDepth,gl_FragDepth,gl_FragDepth,1);
}
*/

#version 330 core
out vec4 FragColor;

float near = 0.1; 
float far  = 100.0; 
  
float LinearizeDepth(float depth) 
{
    float z = depth * 2.0 - 1.0; // back to NDC 
    return (2.0 * near * far) / (far + near - z * (far - near));	
}

void main()
{             
    float depth = LinearizeDepth(gl_FragCoord.z) / far; // divide by far for demonstration
	gl_FragDepth = depth;
    FragColor = vec4(vec3(depth), 1.0);
}
