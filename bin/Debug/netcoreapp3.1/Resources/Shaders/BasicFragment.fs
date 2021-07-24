#version 330

in vec3 cam_angle;
in vec2 texCoord0;
in vec3 normal0;
out vec4 fragColor;


uniform vec3 light_angle;
uniform sampler2D sampler;
float light_intensity = 1;
float R = 0.0f;
float Temp_ScatteringLight = 0;
void main()
{
    fragColor = texture(sampler, texCoord0);
	/*
	if(fragColor.b < 0.05f)
	{
		R = 100;
	}
	*/
	Temp_ScatteringLight = 0.6f * dot(light_angle, normal0);
	if(Temp_ScatteringLight < 0){
		Temp_ScatteringLight = 0;
	}
	light_intensity = 0.1f + Temp_ScatteringLight + R * dot(reflect(light_angle, normal0), cam_angle);
	//fragColor *= 0.1f;
	fragColor *= light_intensity;
	//fragColor = vec4(texCoord0.x,texCoord0.y,1,1);
}