using UnityEngine;
using System.Collections;

public class Agent : PrefabBase {

	protected UnityEngine.AI.NavMeshAgent agent;

	public Vector2 spawnAreaLL;
	public Vector2 spawnAreaUR;

	void Awake() 
	{
		agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
		agent.Warp(getRandomPositionOnNavMesh());
		SetDestination();

		agent.avoidancePriority = (int)Random.value * 100; 
	}

	Vector3 getRandomPositionOnNavMesh()
	{
		Vector3 randomPosition = getDestination();
		UnityEngine.AI.NavMeshHit hit;
		do
		{
			randomPosition = getDestination();
			UnityEngine.AI.NavMesh.SamplePosition(randomPosition, out hit, 10, 0xFFFFFFF);
		} while ((hit.position - randomPosition).magnitude > 0.1);
		return randomPosition;
	}

	Vector3 getDestination()
	{

		var spawnPositionX = Random.value * (spawnAreaUR.x - spawnAreaLL.x) + spawnAreaLL.x;
		var spawnPositionY = Random.value * (spawnAreaUR.y - spawnAreaLL.y) + spawnAreaLL.y;
		return new Vector3(spawnPositionX, 0.0f, spawnPositionY);
	}

	protected void SetDestination()
	{
		//do this instead of setting agent.destination to force immediate path calculation
		UnityEngine.AI.NavMeshPath path = new UnityEngine.AI.NavMeshPath();
		agent.CalculatePath(getRandomPositionOnNavMesh(), path);
		agent.path = path;
	}
	
	protected bool AgentDone()
	{
		return !agent.pathPending && AgentStopping();
	}

	protected bool AgentStopping()
	{
		return agent.remainingDistance <= agent.stoppingDistance;
	}
	
	// Update is called once per frame
	public override void ManualUpdate() 
	{
		if (AgentDone())
		{
			SetDestination();
		}
	}
}
