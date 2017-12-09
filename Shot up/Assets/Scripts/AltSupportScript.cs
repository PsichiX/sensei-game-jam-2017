using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class AltSupportScript : MonoBehaviour {
	[Serializable]	
	public enum Direction {Left, Right, Up, Down};
	
	public Direction CrowdControlDirection = Direction.Left;
	public float Range = 5.0f;


	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Crowd"){
			var agent = other.gameObject.GetComponent<NavMeshAgent>();
			if(CrowdControlDirection == Direction.Left){
				var target = transform.position + new Vector3(-Range, 0, 0);
				agent.SetDestination(target);
			}
			if (CrowdControlDirection == Direction.Right)
			{
				var target = transform.position + new Vector3(Range, 0, 0);
				agent.SetDestination(target);
			}
			if (CrowdControlDirection == Direction.Up)
			{
				var target = transform.position + new Vector3(0, 0, Range);
				agent.SetDestination(target);
			}
			if (CrowdControlDirection == Direction.Down)
			{
				var target = transform.position + new Vector3(0, 0, -Range);
				agent.SetDestination(target);
			}
			
		}
	}
}
