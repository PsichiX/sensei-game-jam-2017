using System.Collections.Generic;
using UnityEngine;

public class TargetTile : MonoBehaviour
{

	public int AgentCount;
	public List<GameObject> Agents = new List<GameObject>();

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Crowd")
		{
			AgentCount++;
			Agents.Add(other.gameObject);
			other.GetComponent<Agent>().Tiles.Add(this);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Crowd")
		{
			AgentCount--;
			Agents.Remove(other.gameObject);
			other.GetComponent<Agent>().Tiles.Remove(this);
		}
	}
}
