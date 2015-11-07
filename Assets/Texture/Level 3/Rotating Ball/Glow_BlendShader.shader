Shader "Custom/Glow&BlendShader" {
	Properties {
		_ColorTint ("Color Tint", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_BumpMap ("Normal Map", 2D) = "bump" {}
		_AlphaMain ("AlphaMain", Range(0,1)) = 0.5
		_RimColor ("Rim Color", Color) = (1,1,1,1)
		_RimPower ("Rim Power", Range(1,10)) = 5
		_PulsatingSpeed("Pulsating Speed", Range(1,200)) = 30
		_PulsatingSize("Pulsating Size", Range(0.01,0.5)) = 0.1
		_SecondTex("Overlapping tex", 2D) = "white" {}
		_Alpha ("Alpha", Range(0,1)) = 0.5
		_OffsetX("Offset X", Range(0,1)) = 0
		_OffsetY("Offset Y", Range(0,1)) = 0
	}
	SubShader {
		Tags { "Queue"="Transparent" "IGNOREPROJECTOR"="true" "RenderType" = "Transparent"}
//		LOD 200
//		ZWrite off
//		Cull off
  		Blend SrcAlpha OneMinusSrcAlpha
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows alpha
		//#pragma surface surf Lambert alpha

		// Use shader model 3.0 target, to get nicer looking lighting
		//#pragma target 3.0
		
		sampler2D _BumpMap;
		sampler2D _MainTex;
		fixed4 _ColorTint;
		fixed4 _RimColor;
		fixed _AlphaMain;
		half _RimPower;
		half _PulsatingSpeed;
		half _PulsatingSize;

		struct Input {
			fixed4 color : Color;
			float2 uv_BumpMap;
			float2 uv_MainTex;
			float3 viewDir;
		};

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			o.Alpha = _AlphaMain;
			o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb * _ColorTint;
			
			o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
			
			half rim = saturate(dot(normalize(IN.viewDir), o.Normal));
			o.Emission = _RimColor.rgb * pow(rim, ((sin(_Time.x*_PulsatingSpeed))/(1.1-_PulsatingSize)) + (12 - _RimPower));
		}
		ENDCG
		
		Pass
		{
		CGPROGRAM
		#pragma exclude_renderers ps3 xbox360 flash
		#pragma vertex vert
		#pragma fragment frag
		
		#include "UnityCG.cginc"

		uniform sampler2D _SecondTex;
		uniform float4 _SecondTex_ST;
		uniform fixed _TextureMix;
		uniform half _Alpha;
		uniform fixed _OffsetX;
		uniform fixed _OffsetY;
		uniform half _SpeedX;
		uniform half _SpeedY;
		
		struct vertexInput
		{
			float4 vertex : POSITION;
			float4 texcoord : TEXCOORD0;
		};
		
		struct vertexOutput
		{
			float4 pos : SV_POSITION;
			half2 uv2 : TEXCOORD1;
			fixed2 localPos : TEXCOORD2;
		};
		
		vertexOutput vert(vertexInput i)
		{
			vertexOutput o;
			
			//o.localPos = i.vertex.xy + fixed2(0.5,0.5);
			i.texcoord.y += _Time.x * _SpeedY;
			i.texcoord.x += _Time.x * _SpeedX;
			//i.texcoord.xy = i.texcoord.xy + _Offset;
			
			o.pos = mul(UNITY_MATRIX_MVP, i.vertex);
			//o.uv2 = TRANSFORM_TEX(i.texcoord, _SecondTex);
			o.uv2 = (i.texcoord.xy * _SecondTex_ST.xy);
			o.uv2.x = o.uv2.x + _OffsetX;
			o.uv2.y = o.uv2.y + _OffsetY;
			
			return o;
		}
		
		float4 frag(vertexOutput i) : COLOR
		{
			fixed4 secondTexColor = tex2D(_SecondTex, i.uv2);
			secondTexColor.w -= 1 - _Alpha+.2;
			
			return secondTexColor;
		}

		ENDCG
		}
		
		Pass
		{
		CGPROGRAM
		#pragma exclude_renderers ps3 xbox360 flash
		#pragma vertex vert
		#pragma fragment frag
		
		#include "UnityCG.cginc"

		uniform sampler2D _SecondTex;
		uniform float4 _SecondTex_ST;
		uniform fixed _TextureMix;
		uniform half _Alpha;
		uniform fixed _OffsetX;
		uniform fixed _OffsetY;
		uniform half _SpeedX;
		uniform half _SpeedY;
		
		struct vertexInput
		{
			float4 vertex : POSITION;
			float4 texcoord : TEXCOORD0;
		};
		
		struct vertexOutput
		{
			float4 pos : SV_POSITION;
			half2 uv2 : TEXCOORD1;
			fixed2 localPos : TEXCOORD2;
		};
		
		vertexOutput vert(vertexInput i)
		{
			vertexOutput o;
			
			half scale = 1.2;
			
			//o.localPos = i.vertex.xy + fixed2(0.5,0.5);
			i.texcoord.y += _Time.x * _SpeedY*1.2;
			i.texcoord.x += _Time.x * _SpeedX*1.2;
			//i.texcoord.xy = i.texcoord.xy + _Offset;
			
			o.pos = mul(UNITY_MATRIX_MVP, i.vertex);
			//o.uv2 = TRANSFORM_TEX(i.texcoord, _SecondTex);
			o.uv2 = (i.texcoord.xy * _SecondTex_ST.xy);
			o.uv2.x = o.uv2.x + _OffsetX*2;
			o.uv2.y = o.uv2.y + _OffsetY*2;
			
			return o;
		}
		
		float4 frag(vertexOutput i) : COLOR
		{
			fixed4 secondTexColor = tex2D(_SecondTex, i.uv2);
			secondTexColor.w -= 1 - _Alpha;
			
			return secondTexColor;
		}

		ENDCG
		}
		
	}  
	
	FallBack "Diffuse"
}