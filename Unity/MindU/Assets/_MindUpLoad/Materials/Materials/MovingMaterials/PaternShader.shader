Shader "SubGraphOutputs"
{
    Properties
    {
        _tiling("Tiling", Vector) = (5, 5, 0, 0)
        _teeth("Teeth", Float) = 2
    }

    HLSLINCLUDE
    #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
    #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Packing.hlsl"
    #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"
    #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
    #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/UnityInstancing.hlsl"
    #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/EntityLighting.hlsl"
    #include "Packages/com.unity.shadergraph/ShaderGraphLibrary/ShaderVariables.hlsl"
    #include "Packages/com.unity.shadergraph/ShaderGraphLibrary/ShaderVariablesFunctions.hlsl"
    #include "Packages/com.unity.shadergraph/ShaderGraphLibrary/Functions.hlsl"
    #define SHADERGRAPH_PREVIEW 1

    CBUFFER_START(UnityPerMaterial)
    float2 _tiling;
    float _teeth;
    CBUFFER_END

    struct SurfaceDescriptionInputs
    {
        half4 uv0;
    };


    void Unity_TilingAndOffset_float(float2 UV, float2 Tiling, float2 Offset, out float2 Out)
    {
        Out = UV * Tiling + Offset;
    }

    void Unity_Fraction_float(float In, out float Out)
    {
        Out = frac(In);
    }

    void Unity_Smoothstep_float(float Edge1, float Edge2, float In, out float Out)
    {
        Out = smoothstep(Edge1, Edge2, In);
    }

    void Unity_Subtract_float(float A, float B, out float Out)
    {
        Out = A - B;
    }

    void Unity_Add_float(float A, float B, out float Out)
    {
        Out = A + B;
    }

    void Unity_Multiply_float(float A, float B, out float Out)
    {
        Out = A * B;
    }

    void Unity_Lerp_float(float A, float B, float T, out float Out)
    {
        Out = lerp(A, B, T);
    }

    struct SurfaceDescription
    {
        float Out_1;
    };

    SurfaceDescription PopulateSurfaceData(SurfaceDescriptionInputs IN)
    {
        SurfaceDescription surface = (SurfaceDescription)0;
        float2 _Property_4FC6F3FC_Out_0 = _tiling;
        float2 _TilingAndOffset_A0B8D390_Out_3;
        Unity_TilingAndOffset_float(IN.uv0.xy, _Property_4FC6F3FC_Out_0, float2 (0, 0), _TilingAndOffset_A0B8D390_Out_3);
        float _Split_1E3A60A9_R_1 = _TilingAndOffset_A0B8D390_Out_3[0];
        float _Split_1E3A60A9_G_2 = _TilingAndOffset_A0B8D390_Out_3[1];
        float _Split_1E3A60A9_B_3 = 0;
        float _Split_1E3A60A9_A_4 = 0;
        float _Fraction_F38A7DF8_Out_1;
        Unity_Fraction_float(_Split_1E3A60A9_R_1, _Fraction_F38A7DF8_Out_1);
        float _Smoothstep_9938D2E4_Out_3;
        Unity_Smoothstep_float(0.5, 0.55, _Fraction_F38A7DF8_Out_1, _Smoothstep_9938D2E4_Out_3);
        float _Smoothstep_36B52299_Out_3;
        Unity_Smoothstep_float(0.95, 1, _Fraction_F38A7DF8_Out_1, _Smoothstep_36B52299_Out_3);
        float _Subtract_F88518C1_Out_2;
        Unity_Subtract_float(_Smoothstep_9938D2E4_Out_3, _Smoothstep_36B52299_Out_3, _Subtract_F88518C1_Out_2);
        float _Fraction_7C39B158_Out_1;
        Unity_Fraction_float(_Split_1E3A60A9_G_2, _Fraction_7C39B158_Out_1);
        float _Smoothstep_D54A4762_Out_3;
        Unity_Smoothstep_float(0.5, 0.55, _Fraction_7C39B158_Out_1, _Smoothstep_D54A4762_Out_3);
        float _Smoothstep_4C4BA81B_Out_3;
        Unity_Smoothstep_float(0.95, 1, _Fraction_7C39B158_Out_1, _Smoothstep_4C4BA81B_Out_3);
        float _Subtract_68E0309D_Out_2;
        Unity_Subtract_float(_Smoothstep_D54A4762_Out_3, _Smoothstep_4C4BA81B_Out_3, _Subtract_68E0309D_Out_2);
        float _Split_54804B5D_R_1 = _TilingAndOffset_A0B8D390_Out_3[0];
        float _Split_54804B5D_G_2 = _TilingAndOffset_A0B8D390_Out_3[1];
        float _Split_54804B5D_B_3 = 0;
        float _Split_54804B5D_A_4 = 0;
        float _Add_5BC61C52_Out_2;
        Unity_Add_float(_Split_54804B5D_R_1, _Split_54804B5D_G_2, _Add_5BC61C52_Out_2);
        float _Property_B4C24C3A_Out_0 = _teeth;
        float _Multiply_809C0605_Out_2;
        Unity_Multiply_float(_Add_5BC61C52_Out_2, _Property_B4C24C3A_Out_0, _Multiply_809C0605_Out_2);
        float _Fraction_7A555C66_Out_1;
        Unity_Fraction_float(_Multiply_809C0605_Out_2, _Fraction_7A555C66_Out_1);
        float _Smoothstep_4D9CE18C_Out_3;
        Unity_Smoothstep_float(0.5, 0.55, _Fraction_7A555C66_Out_1, _Smoothstep_4D9CE18C_Out_3);
        float _Smoothstep_8C322935_Out_3;
        Unity_Smoothstep_float(0.95, 1, _Fraction_7A555C66_Out_1, _Smoothstep_8C322935_Out_3);
        float _Subtract_817099E6_Out_2;
        Unity_Subtract_float(_Smoothstep_4D9CE18C_Out_3, _Smoothstep_8C322935_Out_3, _Subtract_817099E6_Out_2);
        float _Lerp_D0B7EEA9_Out_3;
        Unity_Lerp_float(_Subtract_F88518C1_Out_2, _Subtract_68E0309D_Out_2, _Subtract_817099E6_Out_2, _Lerp_D0B7EEA9_Out_3);
        surface.Out_1 = _Lerp_D0B7EEA9_Out_3;
        return surface;
    }

    struct GraphVertexInput
    {
        float4 vertex : POSITION;
        float4 texcoord0 : TEXCOORD0;
        UNITY_VERTEX_INPUT_INSTANCE_ID
    };

    GraphVertexInput PopulateVertexData(GraphVertexInput v)
    {
        return v;
    }

    ENDHLSL

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            struct GraphVertexOutput
            {
                float4 position : POSITION;
                half4 uv0 : TEXCOORD;

            };

            GraphVertexOutput vert (GraphVertexInput v)
            {
                v = PopulateVertexData(v);

                GraphVertexOutput o;
                float3 positionWS = TransformObjectToWorld(v.vertex);
                o.position = TransformWorldToHClip(positionWS);
                float4 uv0 = v.texcoord0;
                o.uv0 = uv0;

                return o;
            }

            float4 frag (GraphVertexOutput IN ) : SV_Target
            {
                float4 uv0 = IN.uv0;

                SurfaceDescriptionInputs surfaceInput = (SurfaceDescriptionInputs)0;
                surfaceInput.uv0 = uv0;

                SurfaceDescription surf = PopulateSurfaceData(surfaceInput);
                return all(isfinite(surf.Out_1)) ? half4(surf.Out_1, surf.Out_1, surf.Out_1, 1.0) : float4(1.0f, 0.0f, 1.0f, 1.0f);

            }
            ENDHLSL
        }
    }
}
