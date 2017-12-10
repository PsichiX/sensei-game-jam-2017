using UnityEngine;
using UnityEngine.AI;

public class DoorAriaScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crowd" && other.GetComponent<Agent>().TrackingSupports)
        {
            var agent = other.gameObject.GetComponent<NavMeshAgent>();
            if (agent.isActiveAndEnabled)
                agent.SetDestination(transform.parent.position);
        }
    }
}
