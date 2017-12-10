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
	
	public override void StartRoutine()
	{
		//Debug.Log("VillainThrowingRoutine.StartRoutine(): throwItem() coroutine starting");
		StartCoroutine(throwItem());
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
			
			//Debug.Log("VillainThrowingRoutine.throwItem(): New target: " + target);

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
