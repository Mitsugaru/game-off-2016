/**
 * This shader taken from Shaders Laboratory
 * http://www.shaderslab.com/index.php?post/Stencil-effect-%3A-Invisible-crate
 * and modified for the use of this application.
 * Other references:
 * http://answers.unity3d.com/questions/1240334/make-stencil-shader-target-materials-with-same-int.html
 */
Shader "Custom/StencilMask" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_Color("Color", Color) = (1, 1, 1, 0)
		_StencilMask("Mask Layer", Range(0, 255)) = 1
	}
	SubShader {
		Tags { "RenderType"="Transparent" }

		Cull Off
		ZTest always

		Stencil {
			Ref 255
			WriteMask[_StencilMask]
			Comp always
			Pass replace
		}

		CGPROGRAM
		#pragma surface surf Lambert alpha

		sampler2D _MainTex;
		fixed3 _Color;

		struct Input {
			fixed3 Albedo;
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			
		}
		ENDCG
	}
	FallBack "Diffuse"
}