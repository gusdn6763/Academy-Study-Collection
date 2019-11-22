Shader "Wallenstein/S05"
{
    Properties
    {
        _MainTex("Albedo(RGB)",2D) ="white" {}
        _SpecColor("Specular", color) =(1,1,1,1)
        _SpecPow("Specular Power",Range(0,1)) = 0
        _Specular("Specular",Range(0,1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        #pragma surface surf BlinnPhong 

        sampler2D _MainTex;
        float _SpecPow;
        float _Specular;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D(_MainTex,IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Specular =_Specular;
            o.Gloss = _SpecPow;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
