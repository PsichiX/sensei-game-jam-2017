using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{

	public bool TrackingSupports = true;
	public List<TargetTile> Tiles = new List<TargetTile>();

	private void OnDestroy()
	{
		foreach (TargetTile tile in Tiles)
		{
			tile.AgentCount--;
			tile.Agents.Remove(gameObject);
		}
	}
}
