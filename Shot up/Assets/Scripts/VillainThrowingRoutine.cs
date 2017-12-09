using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class VillainThrowingRoutine : Routine
{

	public GameObject ThrowableItem;
	public GameObject TargetLocationMarker;
	public Vector2 TargetAreaStart;
	public Vector2 TargetAreaEnd;
	public float MarkerToThrowDelay;
	public float ThrowToNextMarkerInterval;
	
	public override void StartRoutine()
	{
		StartCoroutine(throwItem());
		Debug.Log("VillainThrowingRoutine.StartRoutine(): throwItem() coroutine started");
	}

	private IEnumerator throwItem()
	{
		while (true)
		{
			Vector2 target = new Vector2(
				Random.Range(TargetAreaStart.x,
					TargetAreaEnd.x),
				Random.Range(TargetAreaStart.y,
					TargetAreaEnd.y));
			
			Debug.Log("VillainThrowingRoutine.throwItem(): New target: " + target);
			
			// TODO Spawn TargetLocationMarker at target coords
			
			yield return new WaitForSecondsRealtime(MarkerToThrowDelay);
			
			// TODO Throw ThrowableItem towards target coords

			yield return new WaitForSecondsRealtime(ThrowToNextMarkerInterval); 
		}
	}
	
}
