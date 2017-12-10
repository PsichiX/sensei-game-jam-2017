using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    public GameObject CrowdPrefab;
    public GameObject Door;
    public int CrowdCount = 100;
    public float Range = 10;

    private void Awake()
    {
        var pos = transform.position;

        for (int i = 0; i < CrowdCount; ++i)
        {
            var offset = Random.insideUnitCircle * Range;
            var instance = Instantiate(CrowdPrefab);
            instance.transform.position = pos + new Vector3(offset.x, 0.0f, offset.y);
            var agent = instance.GetComponent<NavMeshAgent>();
            agent.SetDestination(Door.transform.position);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
