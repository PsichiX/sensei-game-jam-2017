using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using Random = UnityEngine.Random;

public class VillainThrowingRoutine : Routine
{

	public ThrowableItem Item;
	public GameObject TargetLocationMarker;
	public Vector2 TargetAreaStart;
	public Vector2 TargetAreaEnd;
	public float MarkerToThrowDelay;
	public float MarkerDisappearDelay = 1.0f;
	public float NextMarkerDelay;
	public TargetTile TilePrefab;

	private TargetTile[,] tiles = new TargetTile[4,4];
	
	public override void StartRoutine()
	{
		float xInterval = (TargetAreaEnd.x - TargetAreaStart.x) / 4.0f;
		float yInterval = (TargetAreaEnd.y - TargetAreaStart.y) / 4.0f;

		float xPos = (TargetAreaStart.x + xInterval / 2.0f);
		for (int i = 0; i < 4; i++)
		{
			float yPos = (TargetAreaStart.y + yInterval / 2.0f);
			for (int k = 0; k < 4; k++)
			{
				tiles[i, k] = Instantiate(
					TilePrefab,
					new Vector3(xPos, 0.0f, yPos),
					Quaternion.identity);
				tiles[i, k].GetComponent<BoxCollider>().size =
					new Vector3(xInterval, 2.0f, yInterval);
				yPos += yInterval;
			}
			xPos += xInterval;
		}
		
		Debug.Log("VillainThrowingRoutine.StartRoutine(): throwItem() coroutine starting");
		StartCoroutine(throwItem());
	}

	private IEnumerator throwItem()
	{
		while (true)
		{
			TargetTile targetTile = tiles[0, 0];
			foreach (TargetTile tile in tiles)
			{
				if (tile.AgentCount > targetTile.AgentCount)
				{
					targetTile = tile;
				}
			}
			
			Vector2 target = new Vector2(
				targetTile.transform.position.x,
				targetTile.transform.position.z);

			if (targetTile.Agents.Count > 0)
			{
				int index = Random.Range(0, targetTile.Agents.Count - 1);
				target = new Vector2(
					targetTile.Agents[index].transform.position.x, 
					targetTile.Agents[index].transform.position.z);
			}
			
			Debug.Log("VillainThrowingRoutine.throwItem(): New target: " + target);

			GameObject markerInstance = Instantiate(
				TargetLocationMarker, 
				new Vector3(target.x, 0.05f, target.y), 
				Quaternion.identity);
			
			yield return new WaitForSecondsRealtime(MarkerToThrowDelay);

			ThrowableItem itemInstance = Instantiate(
				Item,
				transform.position,
				Quaternion.identity);
			itemInstance.Fire(target);
			
			
			yield return new WaitForSecondsRealtime(MarkerDisappearDelay);
			Destroy(markerInstance);
			yield return new WaitForSecondsRealtime(NextMarkerDelay); 
		}
	}
	
}
