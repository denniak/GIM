Shader "Custom/WaterBall" {
    Properties {
        _MainTex ("Main Texture", 2D) = "white" {}  // Główna tekstura (domyślnie biała)
        _NormalMap ("Normal Map", 2D) = "bump" {}  // Mapa normalnych (domyślnie bump)
        _Color ("Color", Color) = (1, 1, 1, 1)  // Kolor
        _WaveSpeed ("Wave Speed", Range(0, 1)) = 0.5  // Prędkość fal
        _WaveStrength ("Wave Strength", Range(0, 1)) = 0.1  // Siła fal
    }

    SubShader {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }  // Tagi subshadera
        LOD 200

        Blend SrcAlpha OneMinusSrcAlpha  // Tryb mieszania kolorów
        ZWrite Off  // Wyłączenie zapisu do bufora Z
        Cull Off  // Wyłączenie renderowania niewidocznych ścian
        Lighting Off  // Wyłączenie oświetlenia

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;  // Tekstura główna
            sampler2D _NormalMap;  // Mapa normalnych
            float4 _Color;  // Kolor
            float _WaveSpeed;  // Prędkość fal
            float _WaveStrength;  // Siła fal

            struct appdata {
                float4 vertex : POSITION;  // Pozycja wierzchołka
                float2 uv : TEXCOORD0;  // Współrzędne UV
            };

            struct v2f {
                float2 uv : TEXCOORD0;  // Współrzędne UV
                float4 vertex : SV_POSITION;  // Pozycja wierzchołka
                float3 worldPosition : TEXCOORD1;  // Pozycja w świecie
            };

            v2f vert(appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);  // Przeliczenie pozycji wierzchołka do przestrzeni ekranu
                o.uv = v.uv;  // Przekazanie współrzędnych UV
                o.worldPosition = mul(unity_ObjectToWorld, v.vertex).xyz;  // Przeliczenie pozycji w świecie
                return o;
            }

            fixed4 frag(v2f i) : SV_Target {
                float2 uv = i.uv;
                uv += _WaveSpeed * (_Time.y * 0.1);  // Animacja fal na podstawie czasu

                float4 baseColor = tex2D(_MainTex, uv);  // Pobranie koloru z głównej tekstury
                float2 normalMap = UnpackNormal(tex2D(_NormalMap, uv));  // Pobranie wartości mapy normalnych
                normalMap = normalize(normalMap * 2.0f - 1.0f);  // Normalizacja mapy normalnych

                float waveDistortion = sin((uv.x + uv.y) * 10 * _WaveSpeed + _Time.y) * _WaveStrength;  // Obliczenie zniekształcenia fal
                uv += normalMap.xy * waveDistortion;  // Zastosowanie zniekształcenia fal

                float4 finalColor = baseColor * _Color;  // Połączenie koloru bazowego i koloru z shadera

                return finalColor;  // Zwrócenie koloru końcowego
            }
            ENDCG
        }
    }
}
