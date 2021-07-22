#version 330

out vec4 fragColor;

uniform int Is_Trigger;

void main()
{
	if(Is_Trigger == 1)
	{
		fragColor = vec4(0, 1, 1, 1);
	}
	else
	{
		fragColor = vec4(0.37f, 1, 0.5f, 1);
	}
}