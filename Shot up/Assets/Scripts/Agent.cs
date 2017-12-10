using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public Transform Sprite;
	public bool TrackingSupports = true;
	public List<TargetTile> Tiles = new List<TargetTile>();

    private void Update()
    {
        Sprite.rotation = Quaternion.Euler(90, 0, 0);
    }

    private void OnDestroy()
	{
		foreach (TargetTile tile in Tiles)
		{
			tile.AgentCount--;
			tile.Agents.Remove(gameObject);
		}
	}
}
