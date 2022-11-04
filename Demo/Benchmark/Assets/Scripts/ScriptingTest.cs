using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScriptingTest : TestBase {

	public float totalTime = 0;
	public float frameMaxTime = 0.02f;
	public float maxTime = 10.0f;

	void Update ()
	{
		float startFrame = Time.realtimeSinceStartup;
		if (!done)
		{
			float t = startFrame;
			while (t < startFrame + frameMaxTime)
			{
				UpdateTest();
				score++;
				t = Time.realtimeSinceStartup;
			}
			totalTime += t - startFrame;
			if (totalTime > maxTime)
				Done();
		}
		UpdateFrame();
	}

	public virtual void UpdateFrame () {}

	public virtual void UpdateTest () {}

}
