Shader "Tank/Transparent/GUI"
{
	Properties 
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}

	SubShader 
	{
		Tags {"Queue"="Transparent" "RenderType"="Transparent"}
		
		Fog {Mode Off}

		Pass
		{
			ColorMaterial AmbientAndDiffuse
			Name "BASE"
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			Lighting Off


			SetTexture [_MainTex]
			{
				combine texture * primary
			}
		}
	} 
}
