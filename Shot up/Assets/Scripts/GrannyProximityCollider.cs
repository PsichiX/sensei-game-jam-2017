using UnityEngine;

public class GrannyProximityCollider : MonoBehaviour {
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Crowd")
		{
			Destroy(other.gameObject);
		}
	}
	
}
