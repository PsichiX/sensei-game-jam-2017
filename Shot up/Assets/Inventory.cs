using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	public GameObject activeItem;	

	public void Update(){
		if(Input.GetMouseButtonDown(0) && (activeItem != null)){
			Debug.Log(Input.mousePosition);
		}
	}
}
