using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorInnerZone : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Crowd")
		{
			var agent = other.gameObject.GetComponent<NavMeshAgent>();
			if(agent.isActiveAndEnabled){
				agent.SetDestination(transform.parent.position);
			}
			other.GetComponent<Agent>().TrackingSupports = false;

		}
	}
	
}
