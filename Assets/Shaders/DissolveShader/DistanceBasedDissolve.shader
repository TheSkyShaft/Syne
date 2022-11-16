// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:33989,y:32961,varname:node_4013,prsc:2|diff-777-OUT,spec-6682-OUT,gloss-3306-OUT,emission-3754-OUT,clip-3372-OUT;n:type:ShaderForge.SFN_RemapRange,id:2020,x:32266,y:33092,varname:node_2020,prsc:2,frmn:0,frmx:1,tomn:-0.6,tomx:1|IN-6119-OUT;n:type:ShaderForge.SFN_Tex2d,id:8081,x:32113,y:33246,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_8081,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8940f0b1617b14d4ba346831d6519935,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:3372,x:32478,y:33218,varname:node_3372,prsc:2|A-2020-OUT,B-8081-R;n:type:ShaderForge.SFN_RemapRange,id:170,x:32651,y:33339,varname:node_170,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-3372-OUT;n:type:ShaderForge.SFN_Clamp01,id:269,x:32855,y:33366,varname:node_269,prsc:2|IN-170-OUT;n:type:ShaderForge.SFN_OneMinus,id:1121,x:33058,y:33351,varname:node_1121,prsc:2|IN-269-OUT;n:type:ShaderForge.SFN_Vector1,id:6202,x:33130,y:33501,varname:node_6202,prsc:2,v1:0;n:type:ShaderForge.SFN_Append,id:6604,x:33304,y:33121,varname:node_6604,prsc:2|A-1121-OUT,B-6202-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:670,x:33271,y:33479,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_670,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:04747486afb71a6468ec6926f49244f2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:3257,x:33459,y:33318,varname:node_3257,prsc:2,tex:04747486afb71a6468ec6926f49244f2,ntxv:0,isnm:False|UVIN-6604-OUT,TEX-670-TEX;n:type:ShaderForge.SFN_Tex2d,id:8491,x:33374,y:32861,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_8491,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1640,x:33543,y:33074,varname:node_1640,prsc:2|A-3257-RGB,B-1121-OUT;n:type:ShaderForge.SFN_ValueProperty,id:428,x:31381,y:33219,ptovrint:False,ptlb:Dissolve Distance,ptin:_DissolveDistance,varname:node_428,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:5;n:type:ShaderForge.SFN_Depth,id:545,x:31635,y:32867,varname:node_545,prsc:2;n:type:ShaderForge.SFN_Subtract,id:6119,x:31950,y:33206,varname:node_6119,prsc:2|A-5354-OUT,B-1405-OUT;n:type:ShaderForge.SFN_RemapRange,id:5354,x:31894,y:33001,varname:node_5354,prsc:2,frmn:0,frmx:1,tomn:1,tomx:0|IN-545-OUT;n:type:ShaderForge.SFN_Lerp,id:777,x:33824,y:32633,varname:node_777,prsc:2|A-8491-RGB,B-811-OUT,T-8491-RGB;n:type:ShaderForge.SFN_Lerp,id:3754,x:33786,y:32986,varname:node_3754,prsc:2|A-1640-OUT,B-1039-OUT,T-8491-RGB;n:type:ShaderForge.SFN_Multiply,id:1039,x:33712,y:32702,varname:node_1039,prsc:2|A-811-OUT,B-8064-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9752,x:33228,y:32635,ptovrint:False,ptlb:EmissionIntensity,ptin:_EmissionIntensity,varname:node_8841,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:10;n:type:ShaderForge.SFN_Subtract,id:5776,x:32834,y:32476,varname:node_5776,prsc:2|A-5534-Y,B-7543-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7543,x:32660,y:32605,ptovrint:False,ptlb:Origin,ptin:_Origin,varname:node_7224,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Divide,id:1712,x:32995,y:32476,varname:node_1712,prsc:2|A-5776-OUT,B-1963-OUT;n:type:ShaderForge.SFN_ConstantClamp,id:1963,x:32834,y:32625,varname:node_1963,prsc:2,min:0,max:100|IN-1062-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1062,x:32660,y:32712,ptovrint:False,ptlb:Spread,ptin:_Spread,varname:node_9942,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ConstantClamp,id:2435,x:33162,y:32476,varname:node_2435,prsc:2,min:0,max:1|IN-1712-OUT;n:type:ShaderForge.SFN_Color,id:8378,x:33326,y:32326,ptovrint:False,ptlb:ColorBottom,ptin:_ColorBottom,varname:node_7618,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Color,id:9521,x:33162,y:32326,ptovrint:False,ptlb:ColorTop,ptin:_ColorTop,varname:node_1870,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.148332,c2:1,c3:0,c4:1;n:type:ShaderForge.SFN_Lerp,id:3792,x:33326,y:32476,varname:node_3792,prsc:2|A-8378-RGB,B-9521-RGB,T-2435-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:5534,x:32660,y:32455,varname:node_5534,prsc:2;n:type:ShaderForge.SFN_Slider,id:3306,x:33975,y:32724,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_3306,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:6682,x:33973,y:32605,ptovrint:False,ptlb:Specular,ptin:_Specular,varname:node_6682,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_RemapRange,id:1405,x:31699,y:33125,varname:node_1405,prsc:2,frmn:-99999,frmx:99999,tomn:99999,tomx:-99999|IN-428-OUT;n:type:ShaderForge.SFN_Tex2d,id:9430,x:33228,y:32722,ptovrint:False,ptlb:EmissionTexture,ptin:_EmissionTexture,varname:node_9430,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:8064,x:33427,y:32675,varname:node_8064,prsc:2|A-9430-RGB,B-9752-OUT;n:type:ShaderForge.SFN_ToggleProperty,id:4195,x:33544,y:32382,ptovrint:False,ptlb:DisableRamp,ptin:_DisableRamp,varname:node_4195,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False;n:type:ShaderForge.SFN_Subtract,id:4184,x:33727,y:32432,varname:node_4184,prsc:2|A-3792-OUT,B-4195-OUT;n:type:ShaderForge.SFN_Color,id:3521,x:33741,y:32171,ptovrint:False,ptlb:EmissionColor,ptin:_EmissionColor,varname:node_3521,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_RemapRange,id:1959,x:33882,y:32239,varname:node_1959,prsc:2,frmn:0,frmx:1,tomn:1,tomx:0|IN-4195-OUT;n:type:ShaderForge.SFN_Subtract,id:2313,x:34021,y:32153,varname:node_2313,prsc:2|A-3521-RGB,B-1959-OUT;n:type:ShaderForge.SFN_Add,id:811,x:34116,y:32383,varname:node_811,prsc:2|A-2313-OUT,B-4184-OUT;proporder:8081-670-8491-428-9752-7543-1062-8378-9521-6682-3306-9430-4195-3521;pass:END;sub:END;*/

Shader "Shader Forge/DistanceBasedDissolveWithRamp" {
    Properties {
        _Noise ("Noise", 2D) = "white" {}
        _Ramp ("Ramp", 2D) = "white" {}
        _Texture ("Texture", 2D) = "black" {}
        _DissolveDistance ("Dissolve Distance", Float ) = 5
        _EmissionIntensity ("EmissionIntensity", Float ) = 10
        _Origin ("Origin", Float ) = 0
        _Spread ("Spread", Float ) = 0
        _ColorBottom ("ColorBottom", Color) = (1,0,0,1)
        _ColorTop ("ColorTop", Color) = (0.148332,1,0,1)
        _Specular ("Specular", Range(0, 1)) = 0
        _Gloss ("Gloss", Range(0, 1)) = 0
        _EmissionTexture ("EmissionTexture", 2D) = "white" {}
        [MaterialToggle] _DisableRamp ("DisableRamp", Float ) = 0
        _EmissionColor ("EmissionColor", Color) = (1,1,1,1)
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
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _DissolveDistance;
            uniform float _EmissionIntensity;
            uniform float _Origin;
            uniform float _Spread;
            uniform float4 _ColorBottom;
            uniform float4 _ColorTop;
            uniform float _Gloss;
            uniform float _Specular;
            uniform sampler2D _EmissionTexture; uniform float4 _EmissionTexture_ST;
            uniform fixed _DisableRamp;
            uniform float4 _EmissionColor;
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
                float4 projPos : TEXCOORD3;
                LIGHTING_COORDS(4,5)
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
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
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float node_3372 = ((((partZ*-1.0+1.0) - (_DissolveDistance*-1.0+0.0))*1.6+-0.6)+_Noise_var.r);
                clip(node_3372 - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                UNITY_LIGHT_ATTENUATION(attenuation, i, i.pos.xyz);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_Specular,_Specular,_Specular);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float3 node_811 = ((_EmissionColor.rgb - (_DisableRamp*-1.0+1.0))+(lerp(_ColorBottom.rgb, _ColorTop.rgb, clamp(((i.posWorld.g - _Origin)/clamp(_Spread,0,100)),0,1)) - _DisableRamp));
                float3 diffuseColor = lerp(_Texture_var.rgb, node_811, _Texture_var.rgb);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float node_1121 = (1.0 - saturate((node_3372*2.0+-1.0)));
                float2 node_6604 = float2(node_1121,0.0);
                float4 node_3257 = tex2D(_Ramp,TRANSFORM_TEX(node_6604, _Ramp));
                float4 _EmissionTexture_var = tex2D(_EmissionTexture,TRANSFORM_TEX(i.uv0, _EmissionTexture));
                float3 emissive = lerp((node_3257.rgb * node_1121), (node_811 * (_EmissionTexture_var.rgb * _EmissionIntensity)), _Texture_var.rgb);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
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
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _DissolveDistance;
            uniform float _EmissionIntensity;
            uniform float _Origin;
            uniform float _Spread;
            uniform float4 _ColorBottom;
            uniform float4 _ColorTop;
            uniform float _Gloss;
            uniform float _Specular;
            uniform sampler2D _EmissionTexture; uniform float4 _EmissionTexture_ST;
            uniform fixed _DisableRamp;
            uniform float4 _EmissionColor;
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
                float4 projPos : TEXCOORD3;
                LIGHTING_COORDS(4,5)
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
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
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float node_3372 = ((((partZ*-1.0+1.0) - (_DissolveDistance*-1.0+0.0))*1.6+-0.6)+_Noise_var.r);
                clip(node_3372 - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                UNITY_LIGHT_ATTENUATION(attenuation, i, i.pos.xyz);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_Specular,_Specular,_Specular);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float3 node_811 = ((_EmissionColor.rgb - (_DisableRamp*-1.0+1.0))+(lerp(_ColorBottom.rgb, _ColorTop.rgb, clamp(((i.posWorld.g - _Origin)/clamp(_Spread,0,100)),0,1)) - _DisableRamp));
                float3 diffuseColor = lerp(_Texture_var.rgb, node_811, _Texture_var.rgb);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
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
            uniform float _DissolveDistance;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float4 projPos : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float node_3372 = ((((partZ*-1.0+1.0) - (_DissolveDistance*-1.0+0.0))*1.6+-0.6)+_Noise_var.r);
                clip(node_3372 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
