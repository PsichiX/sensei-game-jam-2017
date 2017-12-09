using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class ExplosiveProjectile : ThrowableItem
{
	
	public float Speed = 1.0f;

	private Vector2 target = Vector2.zero;
	private float timeLeft;
	//private float velocity;
	private bool flying = false;
	
	// Use this for initialization
	//void Start () {
	//	
	//}
	
	// Update is called once per frame
	void Update ()
	{
		if (flying)
		{
			timeLeft -= Time.deltaTime;
			if (timeLeft <= 0.0f)
			{
				flying = false;
				GetComponent<Rigidbody>().velocity = Vector3.zero;
				Debug.Log("asplosions");
				// TODO asplosions
			}
		}
	}

	public override void Fire(Vector2 target)
	{
		this.target = target;
		
		Vector3 totalTranslation = new Vector3(
			target.x - transform.position.x,
			0.0f,
			target.y - transform.position.z);
		
		timeLeft = totalTranslation.magnitude / Speed;

		GetComponent<Rigidbody>().velocity = Vector3.Scale(
			Vector3.Normalize(totalTranslation),
			new Vector3(Speed, Speed, Speed));

		flying = true;
	}
	
}
