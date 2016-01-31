Shader "Hidden/HighlightShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				
				vec2 uv = fragCoord.xy / iResolution.xy;

				vec2 blurredUV = vec2(uv.x + 0.002, uv.y + 0.002);

				vec4 baseColor = vec4(texture2D(iChannel0, uv).rgb, 1);

				vec4 edges = 1.0 - (baseColor / vec4(texture2D(iChannel0, blurredUV).rgb, 1));

				fragColor = vec4(length(edges));
				
				col = 1 - col;
				return col;
			}
			ENDCG
		}
	}
}


/*


void mainImage( out vec4 fragColor, in vec2 fragCoord )
{
vec2 uv = fragCoord.xy / iResolution.xy;

vec2 blurredUV = vec2(uv.x+0.002,uv.y+0.002);

vec4 baseColor = vec4(texture2D(iChannel0,uv).rgb,1);

vec4 edges = 1.0 - (baseColor / vec4(texture2D(iChannel0,blurredUV).rgb, 1));

fragColor = vec4(length(edges));

}

*/