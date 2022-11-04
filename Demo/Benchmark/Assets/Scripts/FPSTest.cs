using UnityEngine;
using System.Collections;

public class FPSTest : TestBase {

	public int numSampleFrames = 50;
	public float goalFPS = 20.0f;
	protected float curFPS = -1;
	float[] lastFrameTimes;
	int frameCount = 0;

	public virtual void UpdateTest () {}

	protected virtual void Start () {
		lastFrameTimes = new float[numSampleFrames];
	}

	void Update () {
		var frameTime = Time.time;
		System.Array.Copy(lastFrameTimes, 0, lastFrameTimes, 1, numSampleFrames - 1);
		lastFrameTimes[0] = frameTime;
		frameCount++;

		if (!done && frameCount > numSampleFrames)
		{
			var avgFrameTime = (lastFrameTimes[0] - lastFrameTimes[numSampleFrames - 1])/(numSampleFrames - 1);
			curFPS = 1.0f/avgFrameTime;
			if (curFPS < goalFPS)
				Done();
		}
		if (!done)
			UpdateTest();
	}
}
