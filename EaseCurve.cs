using UnityEngine;
using System;

//Polynominal Interpolation. Works like Mathf.Lerp, but with easing curves.
//sources:
//https://github.com/jesusgollonet/processing-penner-easing/tree/master/src
//http://gizma.com/easing/
[Serializable]
public static class EaseCurve 
{
	public static float Linear(float from, float to, float t)
	{	
		float c = to - from;
		t /= 1f;
		return c*t/1f + from;
	}

	public static float InQuad(float from, float to, float t)
	{
		float c = to - from;
		t /= 1f;
		return c*t*t + from;
	}

	public static float OutQuad(float from, float to, float t)
	{
		float c = to - from;
		t /= 1f;
		return -c*t*(t-2f) + from; 
	}

	public static float InOutQuad(float from, float to, float t)
	{
		float c = to - from;
		t /= 0.5f;
		if (t < 1) return c/2f*t*t + from;
		t--;
		return -c/2f * (t*(t-2) - 1) + from;
	}

	public static float InCubic(float from, float to, float t)
	{
		float c = to - from;
		t /= 1f;
		return c*t*t*t + from;
	}

	public static float OutCubic(float from, float to, float t)
	{
		float c = to - from;
		t /= 1f;
		t--;
		return c*(t*t*t+1) + from;
	}

	public static float InOutCubic(float from, float to, float t)
	{
		float c = to - from;
		t /= 0.5f;
		if(t < 1) return c/2f*t*t*t + from;
		t -= 2;
		return c/2f*(t*t*t+2) + from;
	}

	public static float InQuart(float from, float to, float t)
	{
		float c = to - from;
		t /= 1f;
		return c*t*t*t*t + from;
	}

	public static float OutQuart(float from, float to, float t)
	{
		float c = to - from;
		t /= 1f;
		t--;
		return -c *(t*t*t*t-1) + from;
	}

	public static float InOutQuart(float from, float to, float t)
	{
		float c = to - from;
		t /= 0.5f;
		if(t < 1) return c/2f*t*t*t*t + from;
		t -= 2;
		return -c/2f * (t*t*t*t-2) + from;
	}

	public static float InQuint(float from, float to, float t)
	{
		float c = to - from;
		t /= 1f;
		return c*t*t*t*t*t + from;
	}

	public static float OutQuint(float from, float to, float t)
	{
		float c = to - from;
		t /= 1f;
		t--;
		return c *(t*t*t*t*t+1) + from;
	}

	public static float InOutQuint(float from, float to, float t)
	{
		float c = to - from;
		t /= 0.5f;
		if(t < 1) return c/2f*t*t*t*t*t + from;
		t -= 2;
		return c/2f * (t*t*t*t*t+2) + from;
	}

	public static float InSine(float from, float to, float t)
	{
		float c = to - from;
		return -c * Mathf.Cos(t/1f * (Mathf.PI/2f)) + c + from;
	}

	public static float OutSine(float from, float to, float t)
	{
		float c = to - from;
		return c * Mathf.Sin(t/1f * (Mathf.PI/2f)) + from;
	}

	public static float InOutSine(float from, float to, float t)
	{
		float c = to - from;
		return -c/2f * (Mathf.Cos(Mathf.PI*t/1f) - 1) + from;
	}

	public static float InExpo(float from, float to, float t)
	{
		float c = to - from;
		return c * Mathf.Pow( 2, 10 * (t/1f - 1)) + from;
	}

	public static float OutExpo(float from, float to, float t)
	{
		float c = to - from;
		return c * (-Mathf.Pow( 2, -10 * t/1f) +1 ) + from;
	}

	public static float InOutExpo(float from, float to, float t)
	{
		float c = to - from;
		t /= 0.5f;
		if(t < 1f) return c/2f * Mathf.Pow( 2, 10 * (t - 1) ) + from;
		t--;
		return c/2f * ( -Mathf.Pow(2, -10 * t) + 2) + from;
	}

	public static float InCirc(float from, float to, float t)
	{
		float c = to - from;
		t /= 1f;
		return -c * (Mathf.Sqrt(1 - t*t) -1) + from;
	}

	public static float OutCirc(float from, float to, float t)
	{
		float c = to - from;
		t /= 1f;
		t--;
		return c * Mathf.Sqrt(1 - t*t) + from;
	}

	public static float InOutCirc(float from, float to, float t)
	{
		float c = to - from;
		t /= 0.5f;
		if(t < 1) return -c/2f * (Mathf.Sqrt(1-t*t) -1) + from;
		t -= 2;
		return c/2f * (Mathf.Sqrt(1- t*t) +1) + from;
	}

	public static float InBounce(float from, float to, float t)
	{
		float c = to - from;
		return c - OutBounce(0f, c ,1f-t) + from; //does this work?
	}

	public static float OutBounce(float from , float to, float t) 
	{
		float c = to - from;

		if ((t/=1f) < (1/2.75f)) {
			return c*(7.5625f*t*t) + from;
		} else if (t < (2/2.75f)) {
			return c*(7.5625f*(t-=(1.5f/2.75f))*t + .75f) + from;
		} else if (t < (2.5/2.75)) {
			return c*(7.5625f*(t-=(2.25f/2.75f))*t + .9375f) + from;
		} else {
			return c*(7.5625f*(t-=(2.625f/2.75f))*t + .984375f) + from;
		}
	}

	public static float InOutBounce(float from, float to, float t)
	{
		float c = to - from;
		if( t < 0.5f) return InBounce(0, c, t*2f) * 0.5f + from;
		return OutBounce(0,c, t*2-1) * 0.5f + c*0.5f + from;
		
	}

	public static float InElastic(float from, float to, float t)
	{
		float c = to - from;
		if (t == 0) return from;
		if((t/=1f)==1) return from + c;
		float p = 0.3f;
		float s=p/4f;
		return -(c*Mathf.Pow(2, 10*(t-=1)) * Mathf.Sin( (t-s) * (2 *Mathf.PI)/p)) + from;
	}

	public static float OutElastic(float from, float to, float t)
	{
		float c = to - from;
		if (t == 0) return from;
		if((t/=1f)==1) return from + c;
		float p = 0.3f;
		float s = p/4f;
		return (c*Mathf.Pow(2, -10*t) * Mathf.Sin((t-s)* (2*Mathf.PI)/p) + c + from);
	}

	public static float InOutElastic(float from, float to, float t)
	{
		float c = to - from;
		if (t == 0) return from;
		if((t/=0.5f)==2) return from + c;
		float p = 0.3f * 1.5f;
		float s = p/4f;
		if(t < 1) return -0.5f*(c*Mathf.Pow(2,10*(t-=1f)) * Mathf.Sin((t-2)*(2*Mathf.PI)/p)) + from;
		return c * Mathf.Pow(2,-10*(t-=1)) * Mathf.Sin( (t-s) * (2f * Mathf.PI)/p) *0.5f + c + from;
	}

	public static float InBack(float from, float to, float t)
	{
		float c = to - from;
		float s = 1.70158f;
		t /= 0.5f;
		return c*t*t*((s+1)*t -s) + from;
	}

	public static float OutBack(float from, float to, float t)
	{
		float c = to - from;
		float s = 1.70158f;
		t = t/1f-1f;	
		return c*(t*t*((s+1)*t+s)+1) + from;
	}

	public static float InOutBack(float from, float to, float t)
	{
		float c = to - from;
		float s = 1.70158f;
		t /= 0.5f;
		if(t < 1) return c/2f*(t*t*(((s*=(1.525f))+1)*t - s)) + from;
		t -= 2;
		return c/2f*(t*t*(((s*=(1.525f))+1)*t+s) +2) + from;
	}
}
