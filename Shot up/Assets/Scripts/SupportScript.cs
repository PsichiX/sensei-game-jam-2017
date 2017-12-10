using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
public class SupportScript : MonoBehaviour
{
    [Serializable]
    public enum Direction { Left, Right, Up, Down };
    public Direction direction = Direction.Left;
    public float range = 5;

	private Inventory inventoryRef;

	public void SetInventoryRef(Inventory inventory)
	{
		inventoryRef = inventory;
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.color = Color.white;
    }

	void OnTriggerEnter(Collider o)
	{
		var other = o;
		if(other.tag == "Crowd" && other.GetComponent<Agent>().TrackingSupports){
			var agent = other.gameObject.GetComponent<NavMeshAgent>();
			if(agent.isActiveAndEnabled)
			{
				if(direction == Direction.Left){
					var target = transform.position + new Vector3(-range, 0, 0);
					agent.SetDestination(target);
				}
				if (direction == Direction.Right)
				{
					var target = transform.position + new Vector3(range, 0, 0);
					agent.SetDestination(target);
				}
				if (direction == Direction.Up)
				{
					var target = transform.position + new Vector3(0, 0, range);
					agent.SetDestination(target);
				}
				if (direction == Direction.Down)
				{
					var target = transform.position + new Vector3(0, 0, -range);
					agent.SetDestination(target);
				}
			}
		}
	}

	private void OnDestroy()
	{
		inventoryRef.supportAgents.Remove(gameObject.transform.parent.gameObject);
	}
}
