// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:34216,y:32914,varname:node_4013,prsc:2|diff-2980-OUT,emission-8693-OUT,clip-3372-OUT;n:type:ShaderForge.SFN_RemapRange,id:2020,x:32266,y:33092,varname:node_2020,prsc:2,frmn:0,frmx:1,tomn:-0.6,tomx:1|IN-9659-OUT;n:type:ShaderForge.SFN_Tex2d,id:8081,x:32113,y:33246,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_8081,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8940f0b1617b14d4ba346831d6519935,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:3372,x:32478,y:33218,varname:node_3372,prsc:2|A-2020-OUT,B-8081-R;n:type:ShaderForge.SFN_RemapRange,id:170,x:32651,y:33339,varname:node_170,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-3372-OUT;n:type:ShaderForge.SFN_Clamp01,id:269,x:32855,y:33366,varname:node_269,prsc:2|IN-170-OUT;n:type:ShaderForge.SFN_OneMinus,id:1121,x:33058,y:33351,varname:node_1121,prsc:2|IN-269-OUT;n:type:ShaderForge.SFN_Vector1,id:6202,x:33130,y:33501,varname:node_6202,prsc:2,v1:0;n:type:ShaderForge.SFN_Append,id:6604,x:33304,y:33121,varname:node_6604,prsc:2|A-1121-OUT,B-6202-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:670,x:33271,y:33479,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_670,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:04747486afb71a6468ec6926f49244f2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:3257,x:33459,y:33318,varname:node_3257,prsc:2,tex:04747486afb71a6468ec6926f49244f2,ntxv:0,isnm:False|UVIN-6604-OUT,TEX-670-TEX;n:type:ShaderForge.SFN_Tex2d,id:8491,x:33507,y:32933,ptovrint:False,ptlb:Object Texture,ptin:_ObjectTexture,varname:node_8491,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1640,x:33543,y:33121,varname:node_1640,prsc:2|A-3257-RGB,B-1121-OUT;n:type:ShaderForge.SFN_Slider,id:9659,x:31658,y:33077,ptovrint:False,ptlb:DissolveProg,ptin:_DissolveProg,varname:node_9659,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Vector1,id:2512,x:33491,y:32793,varname:node_2512,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:3332,x:33676,y:32807,varname:node_3332,prsc:2|A-8491-RGB,B-2512-OUT;n:type:ShaderForge.SFN_Color,id:8247,x:33632,y:32638,ptovrint:False,ptlb:EmissionColor,ptin:_EmissionColor,varname:node_8247,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Lerp,id:2980,x:33904,y:32703,varname:node_2980,prsc:2|A-3332-OUT,B-8247-RGB,T-3332-OUT;n:type:ShaderForge.SFN_Lerp,id:8693,x:33878,y:33056,varname:node_8693,prsc:2|A-1640-OUT,B-9268-OUT,T-8491-RGB;n:type:ShaderForge.SFN_Multiply,id:9268,x:33864,y:32862,varname:node_9268,prsc:2|A-8247-RGB,B-8841-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8841,x:33676,y:32948,ptovrint:False,ptlb:EmissionIntensity,ptin:_EmissionIntensity,varname:node_8841,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:10;proporder:8081-670-8491-9659-8247-8841;pass:END;sub:END;*/

Shader "Shader Forge/Dissolve" {
    Properties {
        _Noise ("Noise", 2D) = "white" {}
        _Ramp ("Ramp", 2D) = "white" {}
        _ObjectTexture ("Object Texture", 2D) = "black" {}
        _DissolveProg ("DissolveProg", Range(0, 1)) = 1
        _EmissionColor ("EmissionColor", Color) = (1,0,0,1)
        _EmissionIntensity ("EmissionIntensity", Float ) = 10
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform sampler2D _ObjectTexture; uniform float4 _ObjectTexture_ST;
            uniform float _DissolveProg;
            uniform float4 _EmissionColor;
            uniform float _EmissionIntensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float node_3372 = ((_DissolveProg*1.6+-0.6)+_Noise_var.r);
                clip(node_3372 - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                UNITY_LIGHT_ATTENUATION(attenuation, i, i.pos.xyz);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _ObjectTexture_var = tex2D(_ObjectTexture,TRANSFORM_TEX(i.uv0, _ObjectTexture));
                float3 node_3332 = (_ObjectTexture_var.rgb * 1.0);
                float3 diffuseColor = lerp(node_3332, _EmissionColor.rgb, node_3332);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float node_1121 = (1.0 - saturate((node_3372*2.0+-1.0)));
                float2 node_6604 = float2(node_1121,0.0);
                float4 node_3257 = tex2D(_Ramp,TRANSFORM_TEX(node_6604, _Ramp));
                float3 emissive = lerp((node_3257.rgb * node_1121), (_EmissionColor.rgb * _EmissionIntensity), _ObjectTexture_var.rgb);
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform sampler2D _ObjectTexture; uniform float4 _ObjectTexture_ST;
            uniform float _DissolveProg;
            uniform float4 _EmissionColor;
            uniform float _EmissionIntensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float node_3372 = ((_DissolveProg*1.6+-0.6)+_Noise_var.r);
                clip(node_3372 - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                UNITY_LIGHT_ATTENUATION(attenuation, i, i.pos.xyz);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _ObjectTexture_var = tex2D(_ObjectTexture,TRANSFORM_TEX(i.uv0, _ObjectTexture));
                float3 node_3332 = (_ObjectTexture_var.rgb * 1.0);
                float3 diffuseColor = lerp(node_3332, _EmissionColor.rgb, node_3332);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _DissolveProg;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float node_3372 = ((_DissolveProg*1.6+-0.6)+_Noise_var.r);
                clip(node_3372 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
