Shader "Wallenstein/S02"
{
    Properties
    {
        _MainTex ("Albedo (RGB)",2D) ="white" {}
        _Glossiness ("Smoothness",Range(0,1)) =0.5
        _Metallic ("Metallic",Range(0,1)) = 0.0
        _BumpMap("Normalmap",2D) ="bump" {}
        _Occlusion ("Occulsion",2D) = "white" {}
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

       sampler2D _MainTex;
       sampler2D _BumpMap;
       sampler2D _Occlusion;
       half _Glossiness;
       half _Metallic;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;
           // float2 uv_Occulsion;
        }; 
       


        //호출되면 호출된 값의 정보를 바꿈
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
             fixed4 c = tex2D(_MainTex,IN.uv_MainTex);
             o.Normal = UnpackNormal(tex2D(_BumpMap,IN.uv_MainTex));
             o.Occlusion = tex2D(_Occlusion,IN.uv_MainTex);
             o.Albedo = c.rgb;
             o.Alpha =c.a;
             o.Metallic = _Metallic;
             o.Smoothness = _Glossiness;
            // o.Ao =_Ao;
        }
        ENDCG
    }

    FallBack "Diffuse"
}
