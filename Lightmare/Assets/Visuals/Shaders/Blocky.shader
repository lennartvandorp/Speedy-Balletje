Shader "Unlit/Blocky"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _shades ("Shades", int) = 2
        _shadeMult("ShadeMult", float) = .8
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"


            struct v2f
            {
                half3 worldNormal : TEXCOORD0;
                half3 uv : TEXCOORD1;
                float4 pos : SV_POSITION;
                fixed4 diff : COLOR0;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            uint _shades;
            fixed _shadeMult;

            v2f vert (float4 vertex: POSITION, float3 normal: NORMAL, appdata_base v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(vertex);
                o.worldNormal = UnityObjectToWorldNormal(normal);
                o.uv = v.texcoord;
                half nl =  dot(o.worldNormal, _WorldSpaceLightPos0.xyz);
                o.diff = nl;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 c = tex2D(_MainTex, i.uv);
                
                fixed j = 0;

                while(j < _shades){
                    if(i.diff.x < ((j-1) / _shades)){
                        c *= _shadeMult;
                    }
                    j++;
                }
                return c;
            }
            ENDCG
        }
    }
}
