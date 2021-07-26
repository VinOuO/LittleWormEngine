#version 330

in vec3 cam_angle;
in vec2 texCoord0;
in vec3 normal0;
in vec3 position0;
out vec4 fragColor;

uniform vec3 FlashLightDir;
uniform vec3 cam_pos;
uniform vec3 light_angle;
uniform sampler2D sampler;
uniform sampler2D underworldsampler;

float light_intensity = 1;
float R = 0.0f;
void main()
{
	fragColor = texture(sampler, texCoord0);
	/*
	if(position0.x > 10 && position0.y > 5){
		fragColor = texture(underworldsampler, texCoord0);
	}
	else{
		fragColor = texture(sampler, texCoord0);
	}
	*/
	
	if(dot(normalize(FlashLightDir), normalize(position0 - cam_pos)) >= 0.9995f){
		fragColor = texture(underworldsampler, texCoord0);
	}
	else{
		fragColor = texture(sampler, texCoord0);
	}
    
	light_intensity = 0.1f + 0.6f * dot(light_angle, normal0) + R * dot(reflect(light_angle, normal0), cam_angle);
	fragColor *= light_intensity;
}