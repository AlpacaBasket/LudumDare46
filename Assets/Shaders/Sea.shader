Shader "Custom/Sea" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_DisplaceTex ("Displacement", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.5
		_Scale ("Wave scale", Float) = 1
		_Speed ("Wave speed", Float) = 1
		_Frequency ("Wave frequency", Float) = 1
		_Foam ("Foam Thickness", Float) = 1
	}
	SubShader {
		Tags {"Queue" = "Transparent" "RenderType"="Transparent"}
		LOD 200
		CGPROGRAM
		#include "UnityCG.cginc"
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows vertex:vert addshadow alpha
		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 4.0
		#pragma debug
		sampler2D _MainTex;
		sampler2D _DisplaceTex;
		sampler2D _CameraDepthTexture;
		struct Input {
			float2 uv_MainTex;
			float3 vertexNormal;
			float4 pos : SV_POSITION;
			float4 screenpos : TEXCOORD1;
		};
		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		float _Scale, _Speed, _Frequency, _Foam;
		void vert( inout appdata_full v, out Input o)
		{
			half3 offset = (v.vertex.x * v.vertex.x) + (v.vertex.z * v.vertex.z);
			half3 value = tex2Dlod(_DisplaceTex, v.texcoord) * _Scale * sin(_Time.w);
			half d = (value.x*2,value.y*4,value.z*1);
			v.vertex.xyz += v.normal * value;
			UNITY_INITIALIZE_OUTPUT(Input, o);
			o.vertexNormal = value;
			o.pos = UnityObjectToClipPos(v.vertex);
			o.screenpos = ComputeScreenPos(o.pos);
		}
		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)
		void surf (Input IN, inout SurfaceOutputStandard o) {
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			half depth = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture, UNITY_PROJ_COORD(IN.screenpos))); // depth
			half4 foamLine = 1 - saturate(_Foam * (depth - IN.screenpos.w));// foam line by comparing depth and screenposition
			c += foamLine * _Color /2;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
			o.Normal += IN.vertexNormal;
		}
		ENDCG
	}
	FallBack "Sea_lowspec"
}
