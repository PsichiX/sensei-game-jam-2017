using System.Collections;
using UnityEngine;

public class VillainShootingRoutine : Routine {

	public Vector2 TargetAreaStart;
	public Vector2 TargetAreaEnd;
	public float FiringInterval = 7.5f;
	public TargetTile TilePrefab;

	private TargetTile tile;
	
	public override void StartRoutine()
	{
		tile = Instantiate(
			TilePrefab,
			new Vector3(
				(TargetAreaEnd.x - TargetAreaStart.x) / 2,
				0.0f,
				(TargetAreaEnd.y - TargetAreaStart.y) / 2),
			Quaternion.identity);
		
		Debug.Log("VillainShootingRoutine.StartRoutine(): fireShot() coroutine starting");
		StartCoroutine(fireShot());
	}

	private IEnumerator fireShot()
	{
		while (true)
		{
			Vector2 target = new Vector2(
				tile.transform.position.x,
				tile.transform.position.z);

			float distance = float.MaxValue;

			if (tile.Agents.Count > 0)
			{
				foreach (GameObject agent in tile.Agents)
				{
					if ((agent.transform.position - transform.position).magnitude < distance)
					{
						target = new Vector2(
							agent.transform.position.x,
							agent.transform.position.z);
					}
				}
			}

			Ray ray = new Ray(transform.position, target);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.tag == "Crowd")
				{
					Debug.Log(hit.ToString());
					Destroy(hit.collider.gameObject);
				}
			}
			
			yield return new WaitForSecondsRealtime(FiringInterval); 
		}
	}
	
}
