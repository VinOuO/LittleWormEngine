#version 330

in vec3 cam_angle;
in vec2 texCoord0;
in vec3 normal0;
in vec3 position0;
out vec4 fragColor;

uniform vec3 FlashLightDir;
uniform vec3 Camera_Pos;
//uniform vec3 light_angle;
uniform sampler2D NormalSampler;
uniform mat4 Transform;
uniform mat4 NPTransform;
uniform sampler2D UnderWorldSampler;

vec4 temp_Pos;

float light_intensity = 1;
float R = 0.0f;
void main()
{
	if(dot(normalize(FlashLightDir), normalize(position0 - Camera_Pos)) >= 0.999f){
		fragColor = texture(UnderWorldSampler, texCoord0);
	} 
	else{
		fragColor = texture(NormalSampler, texCoord0);
	}
    
	//light_intensity = 0.1f + 0.6f * dot(light_angle, normal0) + R * dot(reflect(light_angle, normal0), cam_angle);
	//fragColor *= light_intensity;
}