# EaseCurvesForUnity
How To:
Drop EaseCurve.cs into Assets/Plugins. Thats it!

Example usage: 

	[Range(0f, 1f)]
	public float t;

	private void Update()
	{
		transform.position = new Vector3(0f, EaseCurve.InOutElastic(0f, 1f, t), 0f);
	}

(Basically works like Mathf.Lerp, but with easing curves.)
