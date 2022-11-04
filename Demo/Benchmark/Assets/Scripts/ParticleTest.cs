using UnityEngine;
using System.Collections;

public class ParticleTest : FPSTest {

	public int minCount = 70;
	public int maxCount = 1000;

	public override void UpdateTest () {
		var increment = minCount + (int)(curFPS - goalFPS) * 20;
		if (increment > maxCount)
			increment = maxCount;
		if (increment > 0)
		{
			var main = GetComponent<ParticleSystem>().main;
			main.maxParticles += increment;
			score += increment;
		}
	}
}
