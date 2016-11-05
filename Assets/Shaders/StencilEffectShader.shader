/**
 * This shader taken from Shaders Laboratory
 * http://www.shaderslab.com/index.php?post/Stencil-effect-%3A-Invisible-crate
 * and modified for the use of this application
 * Other references:
 * http://answers.unity3d.com/questions/1240334/make-stencil-shader-target-materials-with-same-int.html
 */
Shader "Custom/StencilEffect" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
	    _StencilMask("Mask Layer", Range(0, 255)) = 1
		[Enum(CompareFunction)] _StencilComp("Mask Mode", Int) = 6
	}
	SubShader {
		Tags { "RenderType"="Opaque"}

		Stencil {
			Ref 255
			ReadMask[_StencilMask]
			Comp[_StencilComp]
			Pass Keep
		}

		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}