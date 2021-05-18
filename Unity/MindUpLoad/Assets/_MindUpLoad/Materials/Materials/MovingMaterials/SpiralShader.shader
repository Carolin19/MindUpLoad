Shader "SubGraphOutputs"
{
    Properties
    {
        _tiling("Tiling", Vector) = (3, 3, 0, 0)
        _position("Position", Vector) = (1.5, 1.5, 0, 0)
        _number("Number", Float) = 1
        _width("Width", Float) = 0.6
        _separation("Separation", Float) = 0.5
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
    float2 _position;
    float _number;
    float _width;
    float _separation;
    CBUFFER_END

    struct SurfaceDescriptionInputs
    {
        half4 uv0;
    };


    void Unity_TilingAndOffset_float(float2 UV, float2 Tiling, float2 Offset, out float2 Out)
    {
        Out = UV * Tiling + Offset;
    }

    void Unity_PolarCoordinates_float(float2 UV, float2 Center, float RadialScale, float LengthScale, out float2 Out)
    {
        float2 delta = UV - Center;
        float radius = length(delta) * 2 * RadialScale;
        float angle = atan2(delta.x, delta.y) * 1.0/6.28 * LengthScale;
        Out = float2(radius, angle);
    }

    void Unity_Multiply_float(float A, float B, out float Out)
    {
        Out = A * B;
    }

    void Unity_Subtract_float(float A, float B, out float Out)
    {
        Out = A - B;
    }

    void Unity_Preview_float(float In, out float Out)
    {
        Out = In;
    }

    void Unity_Divide_float(float A, float B, out float Out)
    {
        Out = A / B;
    }

    void Unity_Round_float(float In, out float Out)
    {
        Out = round(In);
    }

    void Unity_Absolute_float(float In, out float Out)
    {
        Out = abs(In);
    }

    void Unity_Smoothstep_float(float Edge1, float Edge2, float In, out float Out)
    {
        Out = smoothstep(Edge1, Edge2, In);
    }

    struct SurfaceDescription
    {
        float Out_1;
    };

    SurfaceDescription PopulateSurfaceData(SurfaceDescriptionInputs IN)
    {
        SurfaceDescription surface = (SurfaceDescription)0;
        float2 _Property_36D9F1D8_Out_0 = _tiling;
        float2 _TilingAndOffset_FA37A4D8_Out_3;
        Unity_TilingAndOffset_float(IN.uv0.xy, _Property_36D9F1D8_Out_0, float2 (0, 0), _TilingAndOffset_FA37A4D8_Out_3);
        float2 _Property_58E1667F_Out_0 = _position;
        float2 _PolarCoordinates_997FE17_Out_4;
        Unity_PolarCoordinates_float(_TilingAndOffset_FA37A4D8_Out_3, _Property_58E1667F_Out_0, 1, 1, _PolarCoordinates_997FE17_Out_4);
        float _Split_A8357C55_R_1 = _PolarCoordinates_997FE17_Out_4[0];
        float _Split_A8357C55_G_2 = _PolarCoordinates_997FE17_Out_4[1];
        float _Split_A8357C55_B_3 = 0;
        float _Split_A8357C55_A_4 = 0;
        float _Multiply_51B73F0D_Out_2;
        Unity_Multiply_float(_Split_A8357C55_R_1, 3.141593, _Multiply_51B73F0D_Out_2);
        float _Property_8D12C036_Out_0 = _number;
        float _Property_7C6E1C89_Out_0 = _separation;
        float _Multiply_B791277A_Out_2;
        Unity_Multiply_float(_Property_7C6E1C89_Out_0, 6.283185, _Multiply_B791277A_Out_2);
        float _Multiply_B60AFA73_Out_2;
        Unity_Multiply_float(_Property_8D12C036_Out_0, _Multiply_B791277A_Out_2, _Multiply_B60AFA73_Out_2);
        float _Multiply_9D30F96F_Out_2;
        Unity_Multiply_float(_Split_A8357C55_G_2, _Multiply_B60AFA73_Out_2, _Multiply_9D30F96F_Out_2);
        float _Subtract_735640F3_Out_2;
        Unity_Subtract_float(_Multiply_51B73F0D_Out_2, _Multiply_9D30F96F_Out_2, _Subtract_735640F3_Out_2);
        float _Preview_648F6EFA_Out_1;
        Unity_Preview_float(_Multiply_B791277A_Out_2, _Preview_648F6EFA_Out_1);
        float _Divide_B0F10454_Out_2;
        Unity_Divide_float(_Subtract_735640F3_Out_2, _Preview_648F6EFA_Out_1, _Divide_B0F10454_Out_2);
        float _Round_3B8F3C_Out_1;
        Unity_Round_float(_Divide_B0F10454_Out_2, _Round_3B8F3C_Out_1);
        float _Subtract_E72E840_Out_2;
        Unity_Subtract_float(_Divide_B0F10454_Out_2, _Round_3B8F3C_Out_1, _Subtract_E72E840_Out_2);
        float _Preview_90811122_Out_1;
        Unity_Preview_float(_Multiply_B791277A_Out_2, _Preview_90811122_Out_1);
        float _Multiply_7242EC49_Out_2;
        Unity_Multiply_float(_Subtract_E72E840_Out_2, _Preview_90811122_Out_1, _Multiply_7242EC49_Out_2);
        float _Absolute_3599E2A8_Out_1;
        Unity_Absolute_float(_Multiply_7242EC49_Out_2, _Absolute_3599E2A8_Out_1);
        float _Property_F69C1DEF_Out_0 = _width;
        float _Multiply_3130902C_Out_2;
        Unity_Multiply_float(_Absolute_3599E2A8_Out_1, _Property_F69C1DEF_Out_0, _Multiply_3130902C_Out_2);
        float _Smoothstep_6688810E_Out_3;
        Unity_Smoothstep_float(0.4, 0.6, _Multiply_3130902C_Out_2, _Smoothstep_6688810E_Out_3);
        surface.Out_1 = _Smoothstep_6688810E_Out_3;
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
