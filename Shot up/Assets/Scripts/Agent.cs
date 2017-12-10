using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    public NavMeshAgent Nav;
    public SpriteRenderer Sprite;
    public bool TrackingSupports = true;
    public List<TargetTile> Tiles = new List<TargetTile>();

    private void Start()
    {
    }

    private void Update()
    {
        Sprite.transform.rotation = Quaternion.Euler(90, 0, 0);
        Sprite.flipX = Nav.velocity.x < 0;
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
