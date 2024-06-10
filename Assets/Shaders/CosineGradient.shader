Shader "Hidden/CosineGradient"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}

        _Phase ("Phase", Vector) = (0, 0, 0, 0)
        _Amplitude ("Amplitude", Vector) = (1, 1, 1, 1)
        _Frequency ("Frequency", Vector) = (1, 1, 1, 1)
        _Offset ("Offset", Vector) = (0, 0, 0, 0)

        _ApplyValue ("ApplyValue", float) = 0.0
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float4 _Phase;
            float4 _Amplitude;
            float4 _Frequency;
            float4 _Offset;
            float _ApplyValue;

            float4 cosine_gradient(float x, float4 phase, float4 amp, float4 freq, float4 offset)
            {
                float TAU = 2. * 3.14159265;
                phase *= TAU;
                x *= TAU;

                return float4(
                    offset.r + amp.r * 0.5 * cos(x * freq.r + phase.r + _Time.y) + 0.5,
                    offset.g + amp.g * 0.5 * cos(x * freq.g + phase.g + _Time.y) + 0.5,
                    offset.b + amp.b * 0.5 * cos(x * freq.b + phase.b + _Time.y) + 0.5,
                    offset.a + amp.a * 0.5 * cos(x * freq.a + phase.a + _Time.y) + 0.5
                );
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                
                float brightness = max(col.r, max(col.g, col.b));

                float4 cos = float4(0, 0, 0, 1);

                if (brightness != 0.0)
                {
                    cos = cosine_gradient(brightness, _Phase, _Amplitude, _Frequency, _Offset);
                    cos = float4(cos.rgb, 1.0);
                }
                
                return lerp(col, cos, _ApplyValue);
            }
            ENDCG
        }
    }
}
