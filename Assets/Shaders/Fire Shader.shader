Shader "Custom/Fire Shader"
{
    Properties
    {
        _MainTex ("Fire Shape", 2D) = "white" {}
        _NoiseTex ("Noise Texture", 2D) = "white" {}
        _Speed ("Speed", Float) = 1.0
        _NoiseTiling ("Noise Tiling", Float) = 1.0
        _Intensity ("Intensity", Float) = 1.0
        _Color1 ("Color1", Color) = (1,1,1,1)
        _Color2 ("Color2", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        Blend One One
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _NoiseTex;
            float _Speed;
            float _NoiseTiling;
            fixed4 _Color1;
            fixed4 _Color2;
            float _Intensity;
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                fixed4 noise = tex2D(_NoiseTex, i.uv * _NoiseTiling + float2(0, _Time.y * -_Speed));
                fixed4 lerpedColor = lerp(_Color1, _Color2, col.r);
                col *= noise * lerpedColor * _Intensity;
                return col;
            }
            ENDCG
        }
    }
}
