using UnityEngine;

public class Villain : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		foreach (Routine routine in GetComponents(typeof(Routine)))
		{
			if (routine.enabled)
			{
				routine.StartRoutine();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
}
