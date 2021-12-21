#version 330
out vec4 FragColor;

in vec3 Position;
in vec2 TexCoord;
in vec3 Normal;

uniform mat4 LightSpace;
uniform vec3 LightDir;
uniform vec3 CameraDir;
uniform sampler2D Sampler;
uniform sampler2D ShadowMap;

vec3 Pos;

float IsShadow()
{
	vec4 _Pos4 = LightSpace * vec4(Position, 1.0);
	vec3 _Pos3 = _Pos4.xyz * 0.5 + 0.5;
	if(_Pos3.z > 1)
	{
		_Pos3.z = 1;
	}
	float _Depth = texture(ShadowMap, _Pos3.xy).r;
	float _Bias = 0.05f;
	return (_Depth + _Bias) < _Pos3.z ? 0.6 : 1;
}

float LightIntensity()
{
	float _Intensity = 0.1f + 0.6f * (1-dot(-LightDir, -Normal)) + 0.3f * (dot(reflect(-LightDir, -Normal), -CameraDir));
	return _Intensity * 0.5f + 0.5f;
}


void main()
{
    FragColor = texture(Sampler, TexCoord);
	FragColor *= (IsShadow() * LightIntensity());
}