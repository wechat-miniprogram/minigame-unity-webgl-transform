Shader "Custom/TextureCoordinates/Mandelbrot" {
	Properties {
	//  _MaxIter ("MaxIter", Range (1,1000)) = 20
		_Scale ("Scale", Range (0,1)) = 1
		_xShift ("_xShift", Range (0,10)) = 0
	}
	SubShader {
		Pass {
			GLSLPROGRAM 

			#ifdef VERTEX

			attribute vec4 _glesVertex;
			attribute vec4 _glesMultiTexCoord0;
			uniform highp mat4 glstate_matrix_mvp;
			varying mediump vec2 xlv_TEXCOORD0;
			void main ()
			{
				gl_Position = (glstate_matrix_mvp * _glesVertex);
				xlv_TEXCOORD0 = _glesMultiTexCoord0.xy;
			}

			#endif // VERTEX

			#ifdef FRAGMENT

			uniform highp float _MaxIter;
			uniform highp float _Scale;
			uniform highp float _xShift;
			varying mediump vec2 xlv_TEXCOORD0;
			void main ()
			{
				highp vec4 color_1;
				highp float iteration;
				highp vec2 coord_3;
				highp vec2 mcoord_4;
				coord_3 = vec2(0.0, 0.0);
				mcoord_4.x = (((
					(xlv_TEXCOORD0.x * 3.5)
					- 2.5) * _Scale) - _xShift);
				mcoord_4.y = (((xlv_TEXCOORD0.y * 2.0) - 1.0) * _Scale);
				for (highp float iteration_2 = 0.0; iteration_2 < 10000.0; iteration_2 += 1.0)
				{
					iteration = iteration_2;
					if ((((coord_3.x * coord_3.x) + (coord_3.y * coord_3.y)) > 4.0))
					{
						break;
					};
					highp float tmpvar_5;
					tmpvar_5 = (((coord_3.x * coord_3.x) - (coord_3.y * coord_3.y)) + mcoord_4.x);
					coord_3.y = (((2.0 * coord_3.x) * coord_3.y) + mcoord_4.y);
					coord_3.x = tmpvar_5;
				};
				color_1 = vec4(0.0, 0.0, 0.0, 1.0);
				if ((iteration < 9999.0))
				{
					color_1.x = (0.5 + (0.5 * sin(
					(iteration * 0.11)
					)));
					color_1.y = (0.5 + (0.5 * cos(
					(iteration * 0.077)
					)));
					color_1.z = (0.5 + (0.5 * sin(
					(iteration * 0.027)
					)));
					color_1.w = 1.0;
				};
				gl_FragData[0] = color_1;
			}

			#endif // FRAGMENT

			ENDGLSL  
		}
	}
	SubShader {
		Pass {
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			#pragma target 3.0

			//uniform float _MaxIter;
			uniform float _Scale;
			uniform float _xShift;

			#include "UnityCG.cginc"
            
			float4 frag(v2f_img i) : COLOR
			{
				float2 mcoord;
				float2 coord = float2(0.0,0.0);
				mcoord.x = (((i.uv.x)*3.5)-2.5)*_Scale - _xShift;
				mcoord.y = ((i.uv.y*2.0)-1.0)*_Scale;
				float iteration = 0.0;
				const float PI = 3.14159;
				float xtemp;
				const float _MaxIter = 10000;
				for ( iteration = 0.0; iteration < _MaxIter; iteration += 1.0)
				{
					if ( coord.x*coord.x + coord.y*coord.y > 4 )
						break;
					xtemp = coord.x*coord.x - coord.y*coord.y + mcoord.x;
					coord.y = 2.0*coord.x*coord.y + mcoord.y;
					coord.x = xtemp;
				}
				float4 color = float4(0,0,0,1);
				if (iteration < _MaxIter)
				{                					
					color.r = 0.5 + 0.5 * sin (iteration * 0.11);
					color.g = 0.5 + 0.5 * cos (iteration * 0.077);
					color.b = 0.5 + 0.5 * sin (iteration * 0.027);
					color.a = 1.0;
				}
				return color;
			}
			ENDCG
		}
	}
}
