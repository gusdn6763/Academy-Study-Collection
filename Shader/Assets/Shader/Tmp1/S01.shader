//크게 3가지
//Fixed Function Shader ->유니티 문법
//서페이스 쉐이더 ->유니티에서 만든 문법,Cg문법(쉐이더문법)
//버텍스 쉐이더 -> 어려움,세부적인 내용

Shader "Wallenstein/S01"
{
    //인스펙터에 노출될 문법
    Properties
    {
        _Red("Red", Range(0,1)) = 0
        _Green("Green",Range(0,1)) = 0
        _Blue("Blue",Range(0,1)) = 0
    }

    SubShader
    {
        //타입
        Tags { "RenderType"="Opaque" }

        //Level of detail
        //LOD 200
         
        CGPROGRAM
        //지시자
        //fullforwardshadows [옵션] fade,flender,decal:blend, keepalph, alpha:premul
        #pragma surface surf Standard fullforwardshadows

        float _Red;
        float _Green;
        float _Blue;

        struct Input
        {
            float color : COLOR;
        }; 
       

        //호출되면 호출된 값의 정보를 바꿈
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
             o.Albedo = float3(_Red,_Green,_Blue);
        }
        ENDCG
    }

    FallBack "Diffuse"
}
