#version 330

in vec3 cam_angle;
in vec2 texCoord0;
in vec3 normal0;
in vec3 position0;
out vec4 fragColor;

uniform vec3 FlashLightDir;
uniform vec3 Camera_Pos;
uniform vec3 CameraDir;
uniform sampler2D NormalSampler;
uniform mat4 Transform;
uniform mat4 NPTransform;
uniform sampler2D UnderWorldSampler;
uniform vec3 LightDir;
uniform int Light_On;

vec4 temp_Pos;

float light_intensity = 1;
float R = 0.0f;

float LightIntensity()
{
	float _Intensity = 0.1f + 0.6f * (1-dot(-LightDir, -normal0)) + 0.3f * (dot(reflect(-LightDir, -normal0), -CameraDir));
	return _Intensity * 0.5f + 0.5f;
}

void main()
{
	if(Light_On == 1)
	{
		if(dot(normalize(FlashLightDir), normalize(position0 - Camera_Pos)) >= 0.99f)
		{
			fragColor = texture(UnderWorldSampler, texCoord0);
		} 
		else
		{
			fragColor = texture(NormalSampler, texCoord0);
		}
		fragColor *= LightIntensity() * 0.5 + 0.5;
	}
	else
	{
		fragColor = texture(UnderWorldSampler, texCoord0);
		fragColor *= 0.2;
	}
    
}